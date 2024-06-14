using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Blog
    {
        private List<Article> _articles;
        private Article selectedArticle;
        public Button deleteButton;
        public Button findButton;
        public Label label;
        public TextBox textBox;
        public Panel panel;
        public Button back;
        bool isFindButtonClicked = false;
        public static int x = 0;
        public static int y = 0; 
        public Blog(string name, Panel panel)
        {
            _articles = new List<Article>();
            this.panel = panel;
            deleteButton = new Button();
            findButton = new Button();
            label = new Label();
            textBox = new TextBox();
            back = new Button();
            createUI();
            back.Hide();
        }
        public int getPreviousArticleCommentCount()
        {
            if (_articles.Count > 0)
                return _articles[_articles.Count - 1].getCommentsCount();
            else
            {
                return 0;
            }
        }
        public void addArticle(string userName, string caption, string text)
        {
            _articles.Add(new Article(userName, getPreviousArticleCommentCount(), caption, text, panel, createArticleButton(panel, caption)));
        }  
        public Article getArticleById(int id)
        {
            return _articles.Find(article => article.GetId() == id);
        }
        public void deleteArticleById(int id)
        {
            getArticleById(id).getArticleButton().Hide();
            foreach (Article article in _articles)
            {
                if (article.GetId() > id)
                {
                    article.getArticleButton().Location = new Point(article.getArticleButton().Location.X - 160, article.getArticleButton().Location.Y);
                }
            }
            _articles.Remove(getArticleById(id));
        }
        public void hideAllButtons()
        {
            foreach(Article article in _articles)
            {
                article.getArticleButton().Hide();
            }
            back.Hide();
            textBox.Hide();
            findButton.Hide();
            deleteButton.Hide();
            label.Hide();
        }
        public void showAllButtons()
        {
            foreach (Article article in _articles)
            {
                article.getArticleButton().Show();
            }
            back.Show();
            textBox.Show();
            findButton.Show();
            deleteButton.Show();
            label.Show();
        }
        public Button createArticleButton(Panel panel, string name)
        {
            Button button = new Button();
            panel.Controls.Add(button);
            button.Anchor = AnchorStyles.Top;
            button.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            int buttonWidth = 150;
            int buttonHeight = 100;
            if ((buttonWidth + 10) * (x + 1) > panel.Width)
            {
                y++;
                x = 0;
            }
            button.Location = new Point(10 + (buttonWidth + 10) * x, 10 + (buttonHeight + 10) * y);
            button.Click += (sender, e) =>
            {
                hideAllButtons();
                back.Show();
                selectedArticle = getArticleByButton((Button)sender);
                selectedArticle.showArticle();
            };
            button.Size = new Size(buttonWidth, buttonHeight);
            button.TabIndex = 0;
            button.Text = name;
            button.UseVisualStyleBackColor = true;
            x++;
            return button;
        }
        public void createUI()
        {
            panel.Controls.Add(back);
            panel.Controls.Add(textBox);
            panel.Controls.Add(findButton);
            panel.Controls.Add(deleteButton);
            panel.Controls.Add(label);
            back.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            back.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            back.Text = "<";
            back.Location = new Point(20, 20);
            back.Click += (sender, e) =>
            {
                showAllButtons();
                back.Hide();
                selectedArticle.hideArticle();
            };
            back.Size = new Size(50, 50);
            back.TabIndex = 0;
            back.UseVisualStyleBackColor = true;

            textBox.Size = new Size(200, 20);
            textBox.Location = new Point(panel.Width - 220, 30);
            textBox.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox.Text = "";
            textBox.ForeColor = Color.Black;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            findButton.Size = new Size(100, 50);
            findButton.Location = new Point(panel.Width - 220, 70);
            findButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            findButton.Text = "Знайти";
            findButton.BackColor = Color.Blue;
            findButton.ForeColor = Color.White;
            findButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            label.Size = new Size(100, 20);
            label.Location = new Point(panel.Width - 220, 10);
            label.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label.Text = "Введіть ID кнопки:";
            label.ForeColor = Color.Black;
            label.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            deleteButton.Size = new Size(100, 50);
            deleteButton.Location = new Point(panel.Width - 120, 70);
            deleteButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            deleteButton.Text = "Видалити";
            deleteButton.BackColor = Color.Red;
            deleteButton.ForeColor = Color.White;
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            findButton.Click += (sender, e) =>
            {
                if (textBox.Text.Trim() != "")
                {
                    try
                    {
                        Button selectedButton = getArticleById(Convert.ToInt32(textBox.Text.Trim())).getArticleButton();
                        if (isFindButtonClicked == false)
                        {
                            selectedButton.BackColor = Color.Blue;
                            selectedButton.ForeColor = Color.White;
                            isFindButtonClicked = true;
                        }
                        else
                        {
                            selectedButton.BackColor = Color.White;
                            selectedButton.ForeColor = Color.Black;
                            isFindButtonClicked = false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Неправильний ID", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введіть ID", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            deleteButton.Click += (sender, e) =>
            {
                if (textBox.Text.Trim() != "")
                {
                    try 
                    {
                        deleteArticleById(Convert.ToInt32(textBox.Text.Trim()));
                    }
                    catch
                    {
                        MessageBox.Show("Неправильний ID", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введіть ID", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private Article getArticleByButton(Button button)
        {
            return _articles.Find(article => article.getArticleButton() == button);
        }
    }
}
