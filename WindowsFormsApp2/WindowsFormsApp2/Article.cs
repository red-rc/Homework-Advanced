using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Article
    {
        private string userName = "";
        private string caption = "";
        private string text = "";
        public static int increment = 0;
        private int id = 0;

        public Article(string userName, string caption, string text)
        {
            this.userName = userName;
            this.caption = caption;
            this.text = text;
            id = increment++;
        }
        public string GetUserName() { return userName; }
        public string GetCaption() { return caption; }
        public string GetText() { return text; }
        public int GetId() { return id; }
        public void setCaption(string caption) { this.caption = caption; }
        public void setText(string text) { this.text = text; }
    }
}
