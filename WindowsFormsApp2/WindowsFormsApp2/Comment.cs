using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Comment
    {
        private string userName = "";
        private int rating = 0;
        private string text = "";
        public static int increment = 0;
        private int id = 0;

        public Comment(string userName, int rating, string caption, string text) 
        { 
            this.userName = userName;
            this.rating = rating;
            this.text = text;
            id = increment++;
        }
        public string GetUserName() { return userName; }
        public int GetRating() { return rating; }
        public string GetText() { return text; }
        public int GetId() { return id; }
    }
}
