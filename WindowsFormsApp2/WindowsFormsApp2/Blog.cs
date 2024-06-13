using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Blog
    {
        private List<Article> _articles;
        private string blogName = "";
        public static int increment = 0;
        private int blogId = 0;

        public Blog(string name)
        {
            _articles = new List<Article>();
            blogName = name;
            blogId = increment++;
        }
        public int getBlogId() { return blogId; }
        public string getBlogName() { return blogName; }
        public List<Article> getAllArticles()
        {
            return _articles;
        }
        public Article getArticleById(int id)
        {
            return _articles.Find(article => article.GetId() == id);
        }
        public void deleteArticleById(int id)
        {
            _articles.Remove(getArticleById(id));
        }
    }
}
