using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace LKGrubGrub
{
    public partial class Main : Form
    {
        #region 本程序中用到的API函数
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn, int wMsg, int mParam, int lParam);
        #endregion
        #region 本程序中需要声明的变量
        public const int WM_SYSCOMMAND = 0x0112;//该变量表示将向Windows发送的消息类型          
        public const int SC_MOVE = 0xF010;//该变量表示发送消息的附加消息         
        public const int HTCAPTION = 0x0002;//该变量表示发送消息的附加消息         
        #endregion
        private string LastUrl = "";
        private int IlluIndex_I = 0;//本地图片数量
        private int IlluIndex_O = 0;//外链类型数量
        private int WenKuChapter = 0;//文库下载时，一共完成了多少章，在webbroswer_DocumentCompleted中使用
        private bool StopDownLoad = false;
        List<Illu_Model> WaitingForDownload = new List<Illu_Model>();
        Book_Model book = new Book_Model();
        public Main()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            webBrowser1.ScriptErrorsSuppressed = true; //禁止弹出脚本错误
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(wbWebBrowser_Navigated);
            tb_url.KeyDown += tb_url_KeyDown;
            tb_url.MouseDoubleClick += tb_url_MouseDown;
            webBrowser1.Visible = false;
            WaitingForDownload = new List<Illu_Model>();

            //多线程检查更新,动态更新界面
            new Thread((ThreadStart)(delegate()
            {
                //需要执行的多线程操作
                if (LKGrubGrub.Version.Check())
                {
                    // 此处警惕值类型装箱造成的"性能陷阱"
                    gb_update.Invoke((MethodInvoker)delegate()
                    {
                        gb_update.Visible = true;
                        lb_info.Text = LKGrubGrub.Version.GetInfo();
                        lb_date.Text = "更新时间：" + LKGrubGrub.Version.GetDate();
                        lb_version.Text = "版本号：" + LKGrubGrub.Version.GetVersion();
                    });
                    Thread.Sleep(1500);
                    gb_update.Invoke((MethodInvoker)delegate()
                    {
                        gb_update.BringToFront();
                    });
                }
            }))
            .Start();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        { ReleaseCapture(); SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0); }

        void tb_url_MouseDown(object sender, MouseEventArgs e)
        {
            tb_url.SelectAll();
        }
        void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Nav(tb_url.Text.Trim());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void wbWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)  //屏蔽alert等弹框弹窗的情况
        {

            WebBrowser wbWebBrowser = (WebBrowser)sender;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function alert(){return;}");
            sb.AppendLine("function confirm(){return;}");
            sb.AppendLine("function showModalDialog(){return;}");
            sb.AppendLine("function window.open(){return;}");
            sb.AppendLine("function prompt(){return;}");
            //string strJS = sb.ToString();
            //IHTMLWindow2 win = (IHTMLWindow2)wbWebBrowser.Document.Window.DomWindow;
            //win.execScript(strJS, "Javascript");
            //win = null;

        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            Nav(tb_url.Text.Trim());
        }
        private void btn_work_Click(object sender, EventArgs e)
        {
            string title = webBrowser1.DocumentTitle;
            if (title.Trim() == "" || webBrowser1.Visible == false)
            {
                MessageBox.Show("请先加载网页");
                return;
            }
            if (title.IndexOf("-轻之国度") > 0)
            {
                title = title.Substring(0, title.IndexOf("-轻之国度"));
            }
            if (title.IndexOf(" - 轻之国度") > 0)
            {
                title = title.Substring(0, title.IndexOf(" - 轻之国度"));
            }
            title = title.Replace(@"/", "").Replace(@"\", "").Replace("?", "").Replace("*", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace(":", "").Replace("\"", "");


            //选择目标文件夹
            string defaultfilePath = "";//SofeSetting.Get("ImgPath");
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录
                fbd.SelectedPath = defaultfilePath;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultfilePath = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            book = new Book_Model();
            book.bookName = title;
            book.imgs = new List<Illu_Model>();
            book.imgs_O = new List<Illu_Model>();
            book.floors = new List<Floor>();
            book.text = "";
            IlluIndex_I = 0;
            IlluIndex_O = 0;
            book.path = defaultfilePath;


            book.path += @"\" + book.bookName + @"\";
            if (Directory.Exists(book.path))
            {
                Directory.Delete(book.path, true);
            }
            Directory.CreateDirectory(book.path);

            btn_add.Enabled = true;
            //轻之国度轻小说文库
            if (webBrowser1.Url.ToString().ToLower().IndexOf("lknovel.lightnovel.cn") > 0)
            {
                workForlknovel();
            }
            //轻之国度论坛
            else
            {
                work();
            }
        }
        private void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (LastUrl == tb_url.Text.Trim())
            {
                MessageBox.Show("这一页虫虫已经爬过了，换个网址再试吧。");
                return;
            }
            if (webBrowser1.Visible == false)
            {
                MessageBox.Show("请先加载网页");
                return;
            }
            work();
        }
        private void btn_setting_Click(object sender, EventArgs e)
        {
            HideBroswer();
        }
        private void Nav(string url)
        {
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Navigate(url);
        }
        private void HideBroswer()
        {
            webBrowser1.Visible = false;
            webBrowser1.SendToBack();
        }
        private void work()
        {
            LastUrl = tb_url.Text.Trim();
            string html = webBrowser1.DocumentText;
            //隐藏浏览器
            HideBroswer();
            //提取出内容部分，即提出出楼层，去除头尾
            Match div1 = Regex.Match(html, @"<div id=""postlist"" class=""pl bm"">[\s\S]*?<div id=""postlistreply""");
            //是否匹配成功
            if (!div1.Success)
            {
                MessageBox.Show("无匹配，可能是未加载完成，请重新加载帖子页面后再试。");
                return;
            }
            html = div1.ToString();
            //提取出每层楼， 循环处理
            MatchCollection divs = Regex.Matches(html, @"<div\sid=.post_(\d+)([\s\S]*?)<div\sid=.comment_\d+");//regDivs.Matches(html);
            String strimg = "";//图片部分html
            for (int i = 0; i < divs.Count; i++)
            {
                Floor newfloor = new Floor();
                //原始html
                String strBody = newfloor.html = divs[i].ToString();
                strBody = Regex.Match(strBody, @"id=""postmessage_\d*"">([\s\S]*?)<div id=""comment_").ToString();
                strBody = strBody.Substring(strBody.IndexOf(">") + 1);
                //提取文字部分
                strBody = strBody.Substring(0, strBody.LastIndexOf(@"</td></tr></table>"));


                //为使用标签换行的帖子添加换行
                strBody = Regex.Replace(strBody, "</div>", "\r\n</div>");
                strBody = Regex.Replace(strBody, "</p>", "\r\n</p>");
                //strBody = Regex.Replace(strBody, "</font>", "\r\n</font>");
                #region 提取LK内部图片
                //处理图片 对于上传至LK的
                #region 例子
                //<ignore_js_op>

                //<div class="mbn">

                //<img id="aimg_363300" aid="363300" src="static/image/common/none.gif" zoomfile="data/attachment/forum/201405/31/131658t8w880d3t88h6wsh.jpg" file="data/attachment/forum/201405/31/131658t8w880d3t88h6wsh.jpg" class="zoom" onclick="zoom(this, this.src, 0, 0, 0)" width="1000" id="aimg_363300" inpost="1" onmouseover="showMenu({'ctrlid':this.id,'pos':'12'})" />

                //</div>

                //<div class="tip tip_4 aimg_tip" id="aimg_363300_menu" style="position: absolute; display: none" disautofocus="true">
                //<div class="xs0">
                //<p><strong>000002-1k.jpg</strong> <em class="xg1">(493.12 KB, 下载次数: 1)</em></p>
                //<p>
                //<a href="forum.php?mod=attachment&amp;aid=MzYzMzAwfDRhNmRlZjg1fDE0MDE4MDkyNDF8NTk4Njk3fDc0OTQ0Mg%3D%3D&amp;nothumb=yes" target="_blank">下载附件</a>

                //&nbsp;<a href="javascript:;" onclick="showWindow(this.id, this.getAttribute('url'), 'get', 0);" id="savephoto_363300" url="home.php?mod=spacecp&amp;ac=album&amp;op=saveforumphoto&amp;aid=363300&amp;handlekey=savephoto_363300">保存到相册</a>

                //</p>

                //<p class="xg1 y">2014-5-31 13:16 上传</p>

                //</div>
                //<div class="tip_horn"></div>
                //</div>

                //</ignore_js_op>
                #endregion
                MatchCollection imgs_I = Regex.Matches(strBody, @"<ignore_js_op>([\s\S]*?)</ignore_js_op>");//regDivs.Matches(html);
                if (imgs_I.Count > 0)
                {
                    //去除图片的代码
                    strBody = Regex.Replace(strBody, @"<ignore_js_op>([\s\S]*?)</ignore_js_op>", "[shawn]插图[lk虫虫]");
                    for (int j = 0; j < imgs_I.Count; j++)
                    {
                        //插图数+1
                        IlluIndex_I++;
                        strimg += @"\r\n" + imgs_I[j].ToString();
                        Illu_Model nill = new Illu_Model(imgs_I[j].ToString());
                        //在文章中标记插图
                        int index = strBody.IndexOf("[shawn]插图[lk虫虫]") + 9;//[shawn]插图[lk虫虫]
                        //为文中插图编号[shawn]插图[lk虫虫]------[shawn]插图1[lk虫虫]
                        if (cb_downImgs.Checked)
                            strBody = strBody.Insert(index, IlluIndex_I.ToString());

                        //提取图片url
                        Match mat_url = Regex.Match(nill.html, @"zoomfile=""(.*?)""");
                        //是否匹配成功
                        if (mat_url.Success)
                        {
                            string url = mat_url.ToString();
                            url = url.Substring(url.IndexOf('"') + 1);
                            url = url.Substring(0, url.IndexOf('"'));
                            //补全http
                            if (url.IndexOf("http") == -1)
                            {
                                url = "http://www.lightnovel.cn/" + url;
                            }
                            nill.url = url;
                            nill.name = "[shawn]插图" + IlluIndex_I + "[lk虫虫]" + url.Substring(url.LastIndexOf("."));
                        }
                        else
                        {
                            nill.url = nill.name = "";
                        }
                        book.imgs.Add(nill);
                    }
                }
                #endregion
                #region 提取外链图片
                //处理图片 对于外链
                #region 例子
                //<br />
                //<img id="aimg_G898H" onclick="zoom(this, this.src, 0, 0, 0)" class="zoom" src="http://img13.poco.cn/mypoco/myphoto/20140320/16/55151916201403201646572772539475565_001.jpg" onmouseover="img_onmouseoverfunc(this)" onload="thumbImg(this)" border="0" alt="" /><br />
                //*<br />
                //<font color="green">“那，那个金惠酱……”<br />
                //<font color="darkorange">“嗯？什么？”<br />
                #endregion
                MatchCollection imgs_O = Regex.Matches(strBody, @"<img([\s\S]*?)/>");//regDivs.Matches(html);
                if (imgs_O.Count > 0)
                {
                    //去除图片的代码
                    strBody = Regex.Replace(strBody, @"<img([\s\S]*?)/>", "[shawn]插图外链[lk虫虫]");
                    for (int j = 0; j < imgs_O.Count; j++)
                    {
                        //图片数加1
                        IlluIndex_O++;
                        strimg += @"\r\n" + imgs_O[j].ToString();
                        Illu_Model nill = new Illu_Model(imgs_O[j].ToString());

                        //在文章中标记插图
                        int index = strBody.IndexOf("[shawn]插图外链[lk虫虫]") + 9;//[shawn]插图[lk虫虫]
                        //为文中插图编号[shawn]插图[lk虫虫]------[shawn]插图1[lk虫虫]
                        if (cb_downImgs.Checked)
                            strBody = strBody.Insert(index, IlluIndex_O.ToString());
                        //提取图片url
                        Match mat_url = Regex.Match(nill.html, @"src=""(.*?)""");
                        //是否匹配成功
                        if (mat_url.Success)
                        {
                            string url = mat_url.ToString();
                            url = url.Substring(url.IndexOf('"') + 1);
                            url = url.Substring(0, url.IndexOf('"'));
                            //补全http
                            if (url.IndexOf("http") == -1)
                            {
                                url = "http://www.lightnovel.cn/" + url;
                            }

                            //如果有这种情况，去掉后缀之后的东西 http://image15.poco.cn/mypoco/myphoto/20140811/20/55392017201408112045501061479020503_001.jpg?1280x902_120
                            if (url.Substring(url.LastIndexOf(".")).IndexOf("?") > 0)
                            {
                                url = url.Substring(0, url.LastIndexOf("?"));
                            }

                            nill.url = url;
                            nill.name = "[shawn]插图" + IlluIndex_O + "外链[lk虫虫]" + url.Substring(url.LastIndexOf("."));


                        }
                        else
                        {
                            nill.url = nill.name = "";
                        }

                        book.imgs_O.Add(nill);
                    }
                }
                #endregion

                //去除【本帖最后由 XXXX 于 XXXXXX 编辑】
                strBody = Regex.Replace(strBody, @"<i class=""pstatus"">.*?</i><br />", "");
                //去Html标签
                strBody = NoHTML(strBody);
                //保存楼层
                newfloor.text = strBody;
                book.floors.Add(newfloor);
                book.text += strBody;
                if (cb_saveHtml.Checked)
                    File.WriteAllText(book.path + book.floors.Count + "楼原始HTML.txt", divs[i].ToString(), Encoding.UTF8);
                //分楼层保存信息
                if (cb_saveByFloor.Checked)
                    File.WriteAllText(book.path + book.floors.Count + "楼.txt", strBody, Encoding.UTF8);
            }
            if (cb_saveHtml.Checked)
                File.WriteAllText(book.path + @"图片部分HTML.txt", strimg, Encoding.UTF8);
            //写最终结果
            File.WriteAllText(book.path + book.bookName + @".txt", book.text, Encoding.UTF8);
            //提取注释
            if (cb_noted.Checked)
            {
                GetNote();
            }
            //打开目标文件夹
            Thread.Sleep(500);
            OpenFolderAndSelectFile(book.path + book.bookName + @".txt");






            if (cb_downImgs.Checked)
            {
                StopDownLoad = false;
                lb_waitDown.Visible = true;
                lb_downInfo.Visible = true;
                //多线程检查更新,动态更新界面
                new Thread((ThreadStart)(delegate()
                {
                    gb_update.Invoke((MethodInvoker)delegate()
                    {
                        gb_control.Enabled = false;
                    });
                    gb_setting.Invoke((MethodInvoker)delegate()
                    {
                        gb_setting.Enabled = false;
                    });


                    int allCount = book.imgs.Count + book.imgs_O.Count;
                    int thisNum = 1;
                    for (int i = 0; i < book.imgs.Count; i++)
                    {
                        lb_downInfo.Invoke((MethodInvoker)delegate()
                        {
                            lb_downInfo.Text = "总共" + allCount + "张图片\r\n正在下载第" + thisNum + "张。";
                        });

                        if (book.imgs[i].hasDown)
                        {
                            continue;
                        }
                        if (StopDownLoad)
                        {
                            return;
                        }
                        string filepath = book.path + book.imgs[i].name;
                        book.imgs[i].path = filepath;
                        DownLoadImg(book.imgs[i].name, book.imgs[i].url, filepath);
                        book.imgs[i].hasDown = true;
                        thisNum++;
                    }
                    for (int i = 0; i < book.imgs_O.Count; i++)
                    {
                        lb_downInfo.Invoke((MethodInvoker)delegate()
                        {
                            lb_downInfo.Text = "总共" + allCount + "张图片\r\n正在下载第" + thisNum + "张。";
                        });
                        if (book.imgs_O[i].hasDown)
                        {
                            continue;
                        }
                        if (StopDownLoad)
                        {
                            return;
                        }
                        string filepath = book.path + book.imgs_O[i].name;
                        book.imgs_O[i].path = filepath;
                        DownLoadImg(book.imgs_O[i].name, book.imgs_O[i].url, filepath);
                        book.imgs_O[i].hasDown = true;
                        thisNum++;
                    }

                    gb_control.Invoke((MethodInvoker)delegate()
                    {
                        gb_control.Enabled = true;
                    });

                    gb_setting.Invoke((MethodInvoker)delegate()
                    {
                        gb_setting.Enabled = true;
                    });

                    lb_waitDown.Invoke((MethodInvoker)delegate()
                    {
                        lb_waitDown.Visible = false;
                    });

                    lb_downInfo.Invoke((MethodInvoker)delegate()
                    {
                        lb_downInfo.Visible = false;
                    });

                    MessageBox.Show("图片下载完成!");
                }))
                .Start();
            }
        }
        private void WenkuBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wbWebBrowser = (WebBrowser)sender;
            int cIndex = int.Parse(wbWebBrowser.Name.Trim());
            if (wbWebBrowser.ReadyState == WebBrowserReadyState.Complete && wbWebBrowser.IsBusy == false && book.chapters[cIndex].loaded == false)
            {
                book.chapters[cIndex].html = wbWebBrowser.DocumentText;
                book.chapters[cIndex].loaded = true;
                WenKuChapter++;
                if (WenKuChapter == book.chapters.Count) //当最后一张处理完成时，开始对文本进行处理
                {
                    workForlknovelProcess();
                }
            }
        }
        //当浏览器全部导航完毕，获得了html，则开始处理文本
        private void workForlknovelProcess()
        {
            String strimg = "";//图片部分html
            for (int i = 0; i < book.chapters.Count; i++)
            {
                //原始html
                String strBody = book.chapters[i].html;
                strBody = Regex.Match(strBody, @"<div id=""J_view"" class=""mt-20"">([\s\S]*?)<div class=""text-center mt-20"">").ToString();
                strBody = Regex.Replace(strBody, @"<h2([\s\S]*?)>([\s\S]*?)</h3>", "");
                //为使用标签换行的帖子添加换行
                strBody = Regex.Replace(strBody, "<br />", "\r\n");
                strBody = Regex.Replace(strBody, "</p>", "\r\n</p>");
                #region 提取LK文库内部图片
                //处理图片 对于上传至LK的
                #region 例子
                //"><a href="javascript:;" target="_blank" class="inline"><img src="/images/grey.gif?t=20130308.gif" class="J_lazy J_scoll_load" data-cover="/illustration/image/20120823/20120823164602_39072.jpg" style="min-width:128px; min-height:128px; background: #fff;" /></a></div><br />
                #endregion
                MatchCollection imgs_I = Regex.Matches(strBody, @"<div class=""lk-view-img"">([\s\S]*?)</div>");
                //regDivs.Matches(html);
                if (imgs_I.Count > 0)
                {
                    //去除图片的代码
                    strBody = Regex.Replace(strBody, @"<div class=""lk-view-img"">([\s\S]*?)</div>", "[shawn]插图[lk虫虫]");
                    for (int j = 0; j < imgs_I.Count; j++)
                    {
                        //插图数+1
                        IlluIndex_I++;
                        strimg += @"\r\n" + imgs_I[j].ToString();
                        Illu_Model nill = new Illu_Model(imgs_I[j].ToString());
                        //在文章中标记插图
                        int index = strBody.IndexOf("[shawn]插图[lk虫虫]") + 9; //[shawn]插图[lk虫虫]
                        //为文中插图编号[shawn]插图[lk虫虫]------[shawn]插图1[lk虫虫]
                        if (cb_downImgs.Checked)
                            strBody = strBody.Insert(index, IlluIndex_I.ToString());
                        //提取图片url
                        Match mat_url = Regex.Match(nill.html, @"data-cover=""(.*?)""");
                        //是否匹配成功
                        if (mat_url.Success)
                        {
                            string url = mat_url.ToString();
                            url = url.Substring(url.IndexOf('"') + 1);
                            url = url.Substring(0, url.IndexOf('"'));
                            //补全http
                            if (url.IndexOf("http") == -1)
                            {
                                url = "http://lknovel.lightnovel.cn/" + url;
                            }
                            nill.url = url;
                            nill.name = "[shawn]插图" + IlluIndex_I + "[lk虫虫]" + url.Substring(url.LastIndexOf("."));
                        }
                        else
                        {
                            nill.url = nill.name = "";
                        }
                        book.imgs.Add(nill);
                    }
                }

                #endregion
                //去Html标签
                strBody = NoHTML(strBody).Trim();
                strBody = strBody.Replace("\n", "");
                strBody += "\r\n\r\n";
                //分割处理，去掉段首尾空格
                string[] tmpStrings = Regex.Split(strBody, "\r\n", RegexOptions.IgnoreCase);
                strBody = book.chapters[i].title + "\r\n\r\n";//添加章节标题
                for (int j = 0; j < tmpStrings.Length; j++)
                {
                    strBody += tmpStrings[j] = tmpStrings[j].Replace("　", " ").Trim() + "\r\n";
                }
                book.chapters[i].text = strBody;
                book.text += strBody;
                if (cb_saveHtml.Checked)
                    File.WriteAllText(book.path + book.chapters[i].title + "原始HTML.txt", book.chapters[i].html,
                        Encoding.UTF8);
                //分章节保存信息
                if (cb_saveByFloor.Checked)
                    File.WriteAllText(book.path + book.chapters[i].title + ".txt", strBody, Encoding.UTF8);
            }
            if (cb_saveHtml.Checked)
                File.WriteAllText(book.path + @"图片部分HTML.txt", strimg, Encoding.UTF8);
            //写最终结果
            File.WriteAllText(book.path + book.bookName + @".txt", book.text, Encoding.UTF8);
            //提取注释
            if (cb_noted.Checked)
            {
                GetNote();
            }
            //打开目标文件夹
            Thread.Sleep(500);
            OpenFolderAndSelectFile(book.path + book.bookName + @".txt");

            gb_control.Enabled = true;
            gb_setting.Enabled = true;
            StartDownLoadImgs();
        }
        private void workForlknovel()
        {
            if (webBrowser1.Url.ToString().ToLower().IndexOf("main/book") > 0)
            {
                gb_control.Enabled = false;
                gb_setting.Enabled = false;
                lb_downInfo.Text = "正在从轻国轻小说文库下载小说，请稍后。";
            }
            else
            {
                MessageBox.Show("请输入该卷小说的主页地址！");
                return;
            }
            WenKuChapter = 0;
            LastUrl = tb_url.Text.Trim();
            string html = webBrowser1.DocumentText;
            //隐藏浏览器
            HideBroswer();
            //提取出目录
            Match div1 = Regex.Match(html, @"<ul class=""lk-chapter-list unstyled pt-10 pb-10 mt-20"">[\s\S]*?</ul>");
            //是否匹配成功
            if (!div1.Success)
            {
                MessageBox.Show("无匹配，可能是未加载完成，请重新加载帖子页面后再试。");
                return;
            }

            html = div1.ToString();
            //提取出每一章地址
            MatchCollection captures = Regex.Matches(html, @"<a\s?href=""(?<url>[\s\S]*?)""\s?>([\s\S]*?)<span\s?class=""lk-ellipsis"">(?<text>[\s\S]*?)</span>([\s\S]*?)</a>");//regDivs.Matches(html);
            book.chapters = new List<Chapter>();
            for (int i = 0; i < captures.Count; i++)
            {
                Chapter tmp = new Chapter();
                string a = captures[i].ToString();
                tmp.title = captures[i].Groups["text"].Value.Replace("\r\n", "").Replace("\n", " ").Replace("\t", " ").Replace("　", " ").Trim();
                while (tmp.title.IndexOf("  ") >= 0)
                {
                    tmp.title = tmp.title.Replace("  ", " ");
                }
                tmp.url = captures[i].Groups["url"].Value.Trim();
                //获得html
                WebBrowser w1 = new WebBrowser();
                w1.Name = i.ToString();
                w1.Navigated += new WebBrowserNavigatedEventHandler(wbWebBrowser_Navigated);
                w1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WenkuBrowser_DocumentCompleted);//通过网址获得html
                w1.Navigate(tmp.url);
                book.chapters.Add(tmp);
            }
        }

        #region 其他函数
        /// <summary>
        /// 开始下载插图
        /// </summary>
        public void StartDownLoadImgs()
        {
            if (cb_downImgs.Checked)
            {
                StopDownLoad = false;
                lb_waitDown.Visible = true;
                lb_downInfo.Visible = true;
                new Thread((ThreadStart)(delegate()
                {
                    gb_update.Invoke((MethodInvoker)delegate()
                    {
                        gb_control.Enabled = false;
                    });
                    gb_setting.Invoke((MethodInvoker)delegate()
                    {
                        gb_setting.Enabled = false;
                    });


                    int allCount = book.imgs.Count + book.imgs_O.Count;
                    int thisNum = 1;
                    for (int i = 0; i < book.imgs.Count; i++)
                    {
                        lb_downInfo.Invoke((MethodInvoker)delegate()
                        {
                            lb_downInfo.Text = "总共" + allCount + "张图片\r\n正在下载第" + thisNum + "张。";
                        });

                        if (book.imgs[i].hasDown)
                        {
                            continue;
                        }
                        if (StopDownLoad)
                        {
                            return;
                        }
                        string filepath = book.path + book.imgs[i].name;
                        book.imgs[i].path = filepath;
                        DownLoadImg(book.imgs[i].name, book.imgs[i].url, filepath);
                        book.imgs[i].hasDown = true;
                        thisNum++;
                    }
                    for (int i = 0; i < book.imgs_O.Count; i++)
                    {
                        lb_downInfo.Invoke((MethodInvoker)delegate()
                        {
                            lb_downInfo.Text = "总共" + allCount + "张图片\r\n正在下载第" + thisNum + "张。";
                        });
                        if (book.imgs_O[i].hasDown)
                        {
                            continue;
                        }
                        if (StopDownLoad)
                        {
                            return;
                        }
                        string filepath = book.path + book.imgs_O[i].name;
                        book.imgs_O[i].path = filepath;
                        DownLoadImg(book.imgs_O[i].name, book.imgs_O[i].url, filepath);
                        book.imgs_O[i].hasDown = true;
                        thisNum++;
                    }

                    gb_control.Invoke((MethodInvoker)delegate()
                    {
                        gb_control.Enabled = true;
                    });

                    gb_setting.Invoke((MethodInvoker)delegate()
                    {
                        gb_setting.Enabled = true;
                    });

                    lb_waitDown.Invoke((MethodInvoker)delegate()
                    {
                        lb_waitDown.Visible = false;
                    });

                    lb_downInfo.Invoke((MethodInvoker)delegate()
                    {
                        lb_downInfo.Visible = false;
                    });

                    MessageBox.Show("图片下载完成!");
                }))
                .Start();
            }
        }
        public static string NoHTML(string Htmlstring)
        {

            //Htmlstring = Regex.Replace(Htmlstring, @"<br\s*/>", "\r\n", RegexOptions.IgnoreCase);
            //删除脚本
            //Htmlstring = Regex.Replace(Htmlstring, @"<.*>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML

            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);


            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);



            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            //Htmlstring.Replace("<", "");

            //Htmlstring.Replace(">", "");

            //Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            //Htmlstring.Replace("\r\n", "");

            return Htmlstring;

        }
        public void DownLoadImg(string imgname, string imgurl, string filepath)
        {
            try
            {
                WebClient mywebclient = new WebClient();
                mywebclient.DownloadFile(imgurl, filepath);
                mywebclient.DownloadFile(imgurl, filepath);
            }
            catch (Exception)
            {
                MessageBox.Show("图片" + imgname + "   " + imgurl + "无法下载！");
            }

        }
        public void GetNote()
        {
            new Thread((ThreadStart)(delegate()
            {
                const int keyWordLength = 8;
                List<string> fastNote1 = new List<string>();//记录注释——注：
                List<string> fastNote2 = new List<string>();//记录注释——注\d

                Dictionary<int, FastNote2> fastNote2m = new Dictionary<int, FastNote2>();
                List<string> lines = new List<string>(book.text.Split((new string[] { "\r\n", "", "\r\n", "" }), StringSplitOptions.None));
                for (int i = 0; i < lines.Count; i++)
                {
                    //判断是否为注释：[\(|（|【](.*?(注).*?)[\)|）|】]
                    MatchCollection notes = Regex.Matches(lines[i], @"[\(|（|【](.*?(注[：|:]).*?)[\)|）|】]");
                    if (notes.Count > 0)
                    {
                        foreach (var note in notes)
                        {
                            int index = lines[i].IndexOf(note.ToString());      //获得注释位置

                            string tmpline = lines[i].Substring(0, index);
                            int ii = -1;
                            MatchCollection tmpma = Regex.Matches(tmpline, @"\)|）|】| |　| ");//查找前面的特殊符号      )ABC（注）时，关键词为ABC，因此需要定位上一个)的位置
                            if (tmpma.Count > 0)
                            {
                                ii = tmpma[tmpma.Count - 1].Index;
                            }
                            string nottext = Regex.Replace(note.ToString(), @"\(|\)|（|）|【|】", "").Trim();
                            string keyWord = "";

                            if (ii < 0)//注释前无特殊文字
                            {

                                if (index < keyWordLength)
                                {
                                    //若关键词太短，在关键词后添加“※”，index也向后推1
                                    lines[i] = lines[i].Insert(index, "※");
                                    index++;
                                    keyWord = lines[i].Substring(0, index);
                                }
                                else
                                {
                                    keyWord = lines[i].Substring(index - keyWordLength, keyWordLength);
                                }
                            }
                            else
                            {
                                if ((index - ii - 1) < keyWordLength)
                                {
                                    lines[i] = lines[i].Insert(index, "※");
                                    index++;
                                    keyWord = lines[i].Substring(ii + 1, index - ii - 1);
                                }
                                else
                                {
                                    keyWord = lines[i].Substring(index - keyWordLength, keyWordLength);
                                }
                            }
                            if (keyWord != "")
                            {
                                lines[i] = lines[i].Replace(note.ToString(), "");   //去除本次注释
                                fastNote1.Add(keyWord + "|||" + nottext);
                            }
                        }
                    }

                    //查找出 注1 注2 注3 在文章中的位置
                    notes = Regex.Matches(lines[i], @"[\(|（|【](.*?(注\d*).*?)[\)|）|】]");
                    if (notes.Count > 0)
                    {
                        foreach (var note in notes)
                        {
                            string nottext = Regex.Replace(note.ToString(), @"\(|\)|（|）|【|】", "").Trim();
                            //int index = lines[i].IndexOf(note.ToString());      //获得注释位置
                            string notei = Regex.Match(nottext, @"注\d*").ToString();
                            notei = notei.Replace("注", "");
                            try
                            {
                                int iiii = int.Parse(notei);
                                FastNote2 fn = new FastNote2();
                                fn.text = note.ToString();
                                fn.textLine = i;
                                //fn.textLineIndex = index;
                                fn.noteLine = 0;
                                fn.noteText = "";
                                fastNote2m.Add(iiii, fn);
                            }
                            catch
                            {

                            }
                        }
                        //lines[i] = Regex.Replace(lines[i], @"[\(|（|【](.*?(注\d*).*?)[\)|）|】]", "");
                    }
                    if (Regex.Match(lines[i].Trim().Replace("   ", "").Replace("　", ""), @"^注\d*").Success)
                    {
                        string nottext = lines[i].Trim().Replace("   ", "").Replace("　", "");
                        string notei = Regex.Match(nottext, @"注\d*").ToString();
                        notei = notei.Replace("注", "");
                        try
                        {
                            int iiii = int.Parse(notei);
                            if (fastNote2m.ContainsKey(iiii))
                            {
                                fastNote2m[iiii].noteLine = i;
                                fastNote2m[iiii].noteText = nottext;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                //开始处理fastnote2
                foreach (var fn in fastNote2m.Values)
                {
                    if (fn.noteLine > 0 && fn.textLine > 0)
                    {
                        int i = fn.textLine;
                        int index = fn.textLineIndex = lines[fn.textLine].IndexOf(fn.text);
                        lines[fn.noteLine] = "";
                        string line = lines[fn.textLine];
                        line = lines[fn.textLine] = lines[fn.textLine].Replace(fn.text, "");//去除本次注释
                        string tmpline = line.Substring(0, index);
                        int ii = -1;
                        MatchCollection tmpma = Regex.Matches(tmpline, @"\)|）|】| |　| ");//查找前面的特殊符号      )ABC（注）时，关键词为ABC，因此需要定位上一个)的位置
                        if (tmpma.Count > 0)
                        {
                            ii = tmpma[tmpma.Count - 1].Index;
                        }
                        string keyWord = "";

                        if (ii < 0)//注释前无特殊文字
                        {

                            if (fn.textLineIndex < keyWordLength)
                            {
                                //若关键词太短，在关键词后添加“※”，index也向后推1
                                lines[i] = lines[i].Insert(index, "※");
                                index++;
                                keyWord = lines[i].Substring(0, index);
                            }
                            else
                            {
                                keyWord = lines[i].Substring(index - keyWordLength, keyWordLength);
                            }
                        }
                        else
                        {
                            if ((index - ii - 1) < keyWordLength)
                            {
                                lines[i] = lines[i].Insert(index, "※");
                                index++;
                                keyWord = lines[i].Substring(ii + 1, index - ii - 1);
                            }
                            else
                            {
                                keyWord = lines[i].Substring(index - keyWordLength, keyWordLength);
                            }
                        }
                        if (keyWord != "")
                        {
                            fastNote2.Add(keyWord + "|||" + fn.noteText);
                        }
                    }
                }
                fastNote1.AddRange(fastNote2);
                StringBuilder sb = new StringBuilder();
                foreach (var line in fastNote1)
                {
                    sb.AppendLine(line);
                }
                File.WriteAllText(book.path + @"注释.txt", sb.ToString(), Encoding.UTF8);
                StringBuilder sb2 = new StringBuilder();
                foreach (var line in lines)
                {
                    sb2.AppendLine(line);
                }
                File.WriteAllText(book.path + book.bookName + @"[去注释].txt", sb2.ToString(), Encoding.UTF8);
            })).Start();
        }
        private void lb_download_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(LKGrubGrub.Version.GetDownload());
        }
        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            StopDownLoad = true;
            foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcesses())
            {
                if (thisproc.ProcessName.Equals("LKGrubGrub"))
                {
                    thisproc.Kill();
                }
            }
            Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://singlex.sinaapp.com/");
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://singlex.sinaapp.com/Lefe");
        }
        #endregion
    }
}