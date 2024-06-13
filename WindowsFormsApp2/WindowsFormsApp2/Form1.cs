using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createBlogButton(int i, string name)
        {
            Button button = new Button();
            panel2.Controls.Add(button);
            button.Anchor = AnchorStyles.Top;
            button.Font = new Font("Calibri", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
            int buttonWidth = 150;
            int buttonHeight = 100;
            int y = 1;
            int x = 1;
            if ((buttonWidth + 50) * x > panel2.Width)
            {
                y++;
                x = 1;
                button.Location = new Point((buttonWidth + 50) * x, (buttonHeight + 50) * y);
            }
            else
            {
                x++;
                button.Location = new Point((buttonWidth + 50) * x, (buttonHeight + 50) * y);
            }  

            button.Size = new Size(buttonWidth, buttonHeight);
            button.TabIndex = 0;
            button.Text = name;
            button.UseVisualStyleBackColor = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Blog> blogs = new List<Blog>();
            blogs.Add(new Blog("Новий блог"));
            blogs.Add(new Blog("Новий блог"));
            blogs.Add(new Blog("Новий блог"));
            blogs.Add(new Blog("Новий блог"));
            blogs.Add(new Blog("Новий блог"));

            for (int i = 0; i < blogs.Count; i++) {
                createBlogButton(i, blogs[i].getBlogName());
            }
        }
    }
}
