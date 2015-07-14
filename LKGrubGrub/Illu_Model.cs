using System;
using System.Collections.Generic;
using System.Text;

namespace LKGrubGrub
{
    class Illu_Model
    {
        public Illu_Model()
        {
            hasDown = false;
        }
        public Illu_Model(string _html)
        {
            html = _html;
            hasDown = false;
            hasList = false;
        }
        /// <summary>
        /// 图片下载后保存名称
        /// </summary>
        public string name;
        /// <summary>
        /// 图片url
        /// </summary>
        public string url;
        /// <summary>
        /// 图片的html
        /// </summary>
        public string html;
        /// <summary>
        /// 已经下载？
        /// </summary>
        public bool hasDown;
        public bool hasList;
        public string path;
    }

    class FastNote2
    {
        /// <summary>
        /// 注释关键词所在行
        /// </summary>
        public int textLine;
        /// <summary>
        /// 注释关键词后的 (注d)
        /// </summary>
        public string text;
        /// <summary>
        /// 注释关键词在行中(注d)的index
        /// </summary>
        public int textLineIndex;
        /// <summary>
        /// 注释本体
        /// </summary>
        public string noteText;
        /// <summary>
        /// 注释本体所在行
        /// </summary>
        public int noteLine;
    }
    class Floor
    {
        public string html;
        public string text;
    }

    class Chapter
    {
        public string title;
        public string url;
        public string html;
        public string text;
        public bool loaded = false;//浏览器已经加载完毕标志
    }
    class Book_Model
    {
        public Book_Model()
        {

        }
        public Book_Model(string _bookName)
        {
            bookName = _bookName;
        }
        public string bookName;
        public string url;
        public List<Illu_Model> imgs;
        public List<Illu_Model> imgs_O;//外链图片
        public List<Floor> floors;
        public List<Chapter> chapters;
        public string html;
        public string text;
        public string path;
    }
}
