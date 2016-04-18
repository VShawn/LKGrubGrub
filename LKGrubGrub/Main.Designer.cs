namespace LKGrubGrub
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_work = new System.Windows.Forms.Button();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_saveByFloor = new System.Windows.Forms.CheckBox();
            this.cb_saveHtml = new System.Windows.Forms.CheckBox();
            this.cb_downImgs = new System.Windows.Forms.CheckBox();
            this.btn_setting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_setting = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_noted = new System.Windows.Forms.CheckBox();
            this.lb_waitDown = new System.Windows.Forms.Label();
            this.lb_download = new System.Windows.Forms.LinkLabel();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_info = new System.Windows.Forms.Label();
            this.lb_version = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gb_update = new System.Windows.Forms.GroupBox();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_downInfo = new System.Windows.Forms.Label();
            this.gb_control = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb_setting.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gb_update.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_control.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 101);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1084, 388);
            this.webBrowser1.TabIndex = 13;
            // 
            // btn_work
            // 
            this.btn_work.Location = new System.Drawing.Point(629, 14);
            this.btn_work.Name = "btn_work";
            this.btn_work.Size = new System.Drawing.Size(75, 23);
            this.btn_work.TabIndex = 15;
            this.btn_work.Text = "新爬虫";
            this.btn_work.UseVisualStyleBackColor = true;
            this.btn_work.Click += new System.EventHandler(this.btn_work_Click);
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(159, 15);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(381, 21);
            this.tb_url.TabIndex = 9;
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(548, 14);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 7;
            this.btn_load.Text = "加载";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_add
            // 
            this.btn_add.Enabled = false;
            this.btn_add.Location = new System.Drawing.Point(796, 14);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 16;
            this.btn_add.Text = "追加爬虫";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "帖子/文库地址：";
            // 
            // cb_saveByFloor
            // 
            this.cb_saveByFloor.AutoSize = true;
            this.cb_saveByFloor.Checked = true;
            this.cb_saveByFloor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_saveByFloor.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cb_saveByFloor.Location = new System.Drawing.Point(6, 0);
            this.cb_saveByFloor.Name = "cb_saveByFloor";
            this.cb_saveByFloor.Size = new System.Drawing.Size(103, 23);
            this.cb_saveByFloor.TabIndex = 18;
            this.cb_saveByFloor.Text = "分楼层保存";
            this.cb_saveByFloor.UseVisualStyleBackColor = true;
            // 
            // cb_saveHtml
            // 
            this.cb_saveHtml.AutoSize = true;
            this.cb_saveHtml.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cb_saveHtml.Location = new System.Drawing.Point(6, 0);
            this.cb_saveHtml.Name = "cb_saveHtml";
            this.cb_saveHtml.Size = new System.Drawing.Size(123, 23);
            this.cb_saveHtml.TabIndex = 19;
            this.cb_saveHtml.Text = "保存原始html";
            this.cb_saveHtml.UseVisualStyleBackColor = true;
            // 
            // cb_downImgs
            // 
            this.cb_downImgs.AutoSize = true;
            this.cb_downImgs.Checked = true;
            this.cb_downImgs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_downImgs.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cb_downImgs.Location = new System.Drawing.Point(6, 0);
            this.cb_downImgs.Name = "cb_downImgs";
            this.cb_downImgs.Size = new System.Drawing.Size(118, 23);
            this.cb_downImgs.TabIndex = 20;
            this.cb_downImgs.Text = "同时下载图片";
            this.cb_downImgs.UseVisualStyleBackColor = true;
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(715, 14);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(75, 23);
            this.btn_setting.TabIndex = 21;
            this.btn_setting.Text = "设置虫虫";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_saveByFloor);
            this.groupBox1.Location = new System.Drawing.Point(10, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 55);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(20, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 30);
            this.label2.TabIndex = 19;
            this.label2.Text = "勾选后，每一层楼都会\r\n保存一份txt";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cb_saveHtml);
            this.groupBox2.Location = new System.Drawing.Point(10, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 55);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(20, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 30);
            this.label3.TabIndex = 19;
            this.label3.Text = "勾选后，html也将保存一份\r\ntxt";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cb_downImgs);
            this.groupBox3.Location = new System.Drawing.Point(10, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 55);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(20, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "勾选后，会自动下载帖中插图";
            // 
            // gb_setting
            // 
            this.gb_setting.Controls.Add(this.groupBox4);
            this.gb_setting.Controls.Add(this.groupBox1);
            this.gb_setting.Controls.Add(this.groupBox2);
            this.gb_setting.Controls.Add(this.groupBox3);
            this.gb_setting.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.gb_setting.ForeColor = System.Drawing.Color.Coral;
            this.gb_setting.Location = new System.Drawing.Point(27, 133);
            this.gb_setting.Name = "gb_setting";
            this.gb_setting.Size = new System.Drawing.Size(244, 344);
            this.gb_setting.TabIndex = 25;
            this.gb_setting.TabStop = false;
            this.gb_setting.Text = "我是虫虫设置";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.cb_noted);
            this.groupBox4.Location = new System.Drawing.Point(10, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 127);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 11F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(11, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 90);
            this.label7.TabIndex = 19;
            this.label7.Text = "勾选后，会自动识别注释\r\n并保存一份提取注释的副本。\r\n\r\n对这类的注释支持好：\r\n(注1)\r\n注1这是推荐的注释\r\n";
            // 
            // cb_noted
            // 
            this.cb_noted.AutoSize = true;
            this.cb_noted.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cb_noted.Location = new System.Drawing.Point(6, 0);
            this.cb_noted.Name = "cb_noted";
            this.cb_noted.Size = new System.Drawing.Size(148, 23);
            this.cb_noted.TabIndex = 20;
            this.cb_noted.Text = "注释识别（测试）";
            this.cb_noted.UseVisualStyleBackColor = true;
            // 
            // lb_waitDown
            // 
            this.lb_waitDown.AutoSize = true;
            this.lb_waitDown.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_waitDown.ForeColor = System.Drawing.Color.Red;
            this.lb_waitDown.Location = new System.Drawing.Point(277, 133);
            this.lb_waitDown.Name = "lb_waitDown";
            this.lb_waitDown.Size = new System.Drawing.Size(414, 88);
            this.lb_waitDown.TabIndex = 26;
            this.lb_waitDown.Text = "图片下载中……\r\n期间请勿执行其他操作……";
            this.lb_waitDown.Visible = false;
            // 
            // lb_download
            // 
            this.lb_download.AutoSize = true;
            this.lb_download.Font = new System.Drawing.Font("黑体", 16F);
            this.lb_download.Location = new System.Drawing.Point(252, 26);
            this.lb_download.Name = "lb_download";
            this.lb_download.Size = new System.Drawing.Size(98, 22);
            this.lb_download.TabIndex = 31;
            this.lb_download.TabStop = true;
            this.lb_download.Text = "点击下载";
            this.lb_download.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_download_LinkClicked);
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_date.Location = new System.Drawing.Point(15, 101);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(88, 16);
            this.lb_date.TabIndex = 30;
            this.lb_date.Text = "更新时间：";
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_info.Location = new System.Drawing.Point(15, 138);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(88, 16);
            this.lb_info.TabIndex = 29;
            this.lb_info.Text = "更新内容：";
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_version.Location = new System.Drawing.Point(15, 68);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(72, 16);
            this.lb_version.TabIndex = 28;
            this.lb_version.Text = "版本号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 13F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(15, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "发现了新版本的虫虫！";
            // 
            // gb_update
            // 
            this.gb_update.Controls.Add(this.label5);
            this.gb_update.Controls.Add(this.lb_download);
            this.gb_update.Controls.Add(this.lb_version);
            this.gb_update.Controls.Add(this.lb_date);
            this.gb_update.Controls.Add(this.lb_info);
            this.gb_update.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_update.Location = new System.Drawing.Point(699, 133);
            this.gb_update.Name = "gb_update";
            this.gb_update.Size = new System.Drawing.Size(356, 338);
            this.gb_update.TabIndex = 32;
            this.gb_update.TabStop = false;
            this.gb_update.Text = "检查更新";
            this.gb_update.Visible = false;
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_EXIT.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.btn_EXIT.ForeColor = System.Drawing.Color.Red;
            this.btn_EXIT.Location = new System.Drawing.Point(1041, 12);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(31, 32);
            this.btn_EXIT.TabIndex = 34;
            this.btn_EXIT.Text = "X";
            this.btn_EXIT.UseVisualStyleBackColor = false;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(65, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 36);
            this.label6.TabIndex = 36;
            this.label6.Text = "LK虫虫0.0.3——爬过轻国";
            // 
            // lb_downInfo
            // 
            this.lb_downInfo.AutoSize = true;
            this.lb_downInfo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_downInfo.Location = new System.Drawing.Point(293, 254);
            this.lb_downInfo.Name = "lb_downInfo";
            this.lb_downInfo.Size = new System.Drawing.Size(341, 52);
            this.lb_downInfo.TabIndex = 37;
            this.lb_downInfo.Text = "总共\" + book.imgs.Count + \"张图片\r\n正在下载第\" + (i + 1) + \"张……";
            this.lb_downInfo.Visible = false;
            // 
            // gb_control
            // 
            this.gb_control.Controls.Add(this.label1);
            this.gb_control.Controls.Add(this.btn_load);
            this.gb_control.Controls.Add(this.btn_work);
            this.gb_control.Controls.Add(this.btn_add);
            this.gb_control.Controls.Add(this.tb_url);
            this.gb_control.Controls.Add(this.btn_setting);
            this.gb_control.Location = new System.Drawing.Point(12, 52);
            this.gb_control.Name = "gb_control";
            this.gb_control.Size = new System.Drawing.Size(1060, 43);
            this.gb_control.TabIndex = 38;
            this.gb_control.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pictureBox3);
            this.groupBox5.Controls.Add(this.pictureBox4);
            this.groupBox5.Controls.Add(this.pictureBox2);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(698, 133);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(356, 338);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "About";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(18, 169);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(323, 156);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(134, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(207, 114);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 114);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(315, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 31);
            this.label8.TabIndex = 26;
            this.label8.Text = " ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 489);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gb_control);
            this.Controls.Add(this.lb_downInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.gb_update);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lb_waitDown);
            this.Controls.Add(this.gb_setting);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LK虫虫";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gb_setting.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gb_update.ResumeLayout(false);
            this.gb_update.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_control.ResumeLayout(false);
            this.gb_control.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_work;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_saveByFloor;
        private System.Windows.Forms.CheckBox cb_saveHtml;
        private System.Windows.Forms.CheckBox cb_downImgs;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_setting;
        private System.Windows.Forms.Label lb_waitDown;
        public System.Windows.Forms.LinkLabel lb_download;
        public System.Windows.Forms.Label lb_date;
        public System.Windows.Forms.Label lb_info;
        public System.Windows.Forms.Label lb_version;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.GroupBox gb_update;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_downInfo;
        private System.Windows.Forms.GroupBox gb_control;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_noted;
        public System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
    }
}

