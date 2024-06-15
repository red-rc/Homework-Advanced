using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {
            createBlog();
        }
        public void createBlog()
        {
            Blog blog = new Blog("Новий блог", panel2);
            blog.addArticle("Користувач 1", "Заголовок 1", "Текст");
            User user1 = new User("Користувач 1", "user1@gmail.com", "11111111");
            User user2 = new User("Користувач 2", "user2@gmail.com", "12345678");
            User user3 = new User("Користувач 2", "user3@gmail.com", "123456789");
            blog.getArticleById(1).addComment(user1, "Гарна стаття", 5);
            blog.getArticleById(1).addComment(user2, "Мені не сподобалось", 2);
            blog.getArticleById(1).addComment(user3, "Хороша стаття", 4);

            blog.addArticle("Користувач 2", "Заголовок 2", "Текст");
            blog.getArticleById(2).addComment(user1, "Гарна стаття", 5);
            blog.getArticleById(2).addComment(user2, "Мені не сподобалось", 2);
            blog.getArticleById(2).addComment(user3, "Хороша стаття", 4);

            blog.addArticle("Користувач 3", "Заголовок 3", "Текст");
            blog.getArticleById(3).addComment(user1, "Гарна стаття", 5);
            blog.getArticleById(3).addComment(user2, "Мені не сподобалось", 2);
            blog.getArticleById(3).addComment(user3, "Хороша стаття", 4);
        }
    }
}
