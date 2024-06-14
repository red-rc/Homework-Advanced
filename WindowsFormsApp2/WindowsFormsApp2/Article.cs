using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Article
    {
        public TextBox nameBox;
        public TextBox captionBox;
        public TextBox textBox;
        public Label userNameLabel;
        public Label emailLabel;
        public Label passwordLabel;
        public Label commentLabel;
        public Label ratingLabel;
        public TextBox userNameTextBox;
        public TextBox emailTextBox;
        public TextBox passwordTextBox;
        public TextBox commentTextBox;
        public TextBox ratingTextBox;
        public Button submitButton;
        public Panel panel;
        public GroupBox commentFormPanel;
        public VScrollBar scrollBar;
        public int PreviousCommentsCount;
        public List<Comment> comments;
        public Button button;
        public static int increment = 1;
        private int id = 0;

        public Article(string userName, int PreviousCommentsCount, string caption, string text, Panel panel, Button button)
        {
            id = increment++;
            nameBox = new TextBox();
            captionBox = new TextBox();
            textBox = new TextBox();
            userNameLabel = new Label();
            emailLabel = new Label();
            passwordLabel = new Label();
            commentLabel = new Label();
            ratingLabel = new Label();
            userNameTextBox = new TextBox();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            commentTextBox = new TextBox();
            ratingTextBox = new TextBox();
            userNameLabel = new Label();
            this.PreviousCommentsCount = PreviousCommentsCount;
            commentFormPanel = new GroupBox();
            scrollBar = new VScrollBar();
            submitButton = new Button();

            this.panel = panel;
            comments = new List<Comment>();
            this.button = button;

            nameBox.Text = userName;
            captionBox.Text = caption;
            textBox.Text = text;

            createUI();
            hideArticle();
        }
        public int GetId() { return id; }
        public int getCommentsCount()
        {
            return comments.Count;
        }
        public void addComment(User user, string text, int rating)
        {
            comments.Add(new Comment(user, PreviousCommentsCount, rating, text, panel));
        }
        public void showArticle()
        {
            showComments();
            commentFormPanel.Show();
            nameBox.Show();
            captionBox.Show();
            textBox.Show();
            scrollBar.Show();
        }
        public void showComments()
        {
            if (comments != null)
            {
                foreach (Comment comment in comments)
                {
                    comment.showComment();
                }
            }
        }
        public void hideArticle()
        {
            if (comments != null)
            {
                foreach (Comment comment in comments)
                {
                    comment.hideComment();
                }
            }
            commentFormPanel.Hide();
            nameBox.Hide();
            captionBox.Hide();
            textBox.Hide();
            scrollBar.Hide();
        }
        public Button getArticleButton()
        {
            return button;
        }

        public void createUI()
        {
            panel.Controls.Add(nameBox);
            panel.Controls.Add(captionBox);
            panel.Controls.Add(textBox);
            panel.Controls.Add(scrollBar);

            nameBox.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nameBox.BorderStyle = BorderStyle.None;
            nameBox.Location = new Point(panel.Width / 2 - 70, 10);
            nameBox.Size = new Size(200, 20);
            nameBox.Anchor = AnchorStyles.Top;
            nameBox.TabIndex = 0;

            captionBox.Font = new Font("Microsoft Sans Serif", 24.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            captionBox.BorderStyle = BorderStyle.None;
            captionBox.Location = new Point(panel.Width / 2 - 100, 50);
            captionBox.Size = new Size(200, 50);
            captionBox.Anchor = AnchorStyles.Top;
            captionBox.TabIndex = 0;

            textBox.BorderStyle = BorderStyle.None;
            textBox.Location = new Point(50, 100);
            textBox.Size = new Size(panel.Width - 100, 400);
            textBox.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox.Multiline = true;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox.TabIndex = 0;

            panel.Controls.Add(commentFormPanel);
            commentFormPanel.Location = new Point(panel.Width / 2 - 225, 500);
            commentFormPanel.Size = new Size(400, 225);
            commentFormPanel.Anchor = AnchorStyles.Top;

            commentFormPanel.Controls.Add(userNameLabel);
            commentFormPanel.Controls.Add(userNameTextBox);
            commentFormPanel.Controls.Add(passwordLabel);
            commentFormPanel.Controls.Add(passwordTextBox);
            commentFormPanel.Controls.Add(commentLabel);
            commentFormPanel.Controls.Add(commentTextBox);
            commentFormPanel.Controls.Add(submitButton);
            commentFormPanel.Controls.Add(emailLabel);
            commentFormPanel.Controls.Add(emailTextBox);
            commentFormPanel.Controls.Add(ratingLabel);
            commentFormPanel.Controls.Add(ratingTextBox);
            
            userNameLabel.Text = "Ім'я:";
            userNameLabel.Location = new Point(10, 10);
            userNameLabel.AutoSize = true;
            
            userNameTextBox.Location = new Point(75, 10);
            userNameTextBox.Size = new Size(150, 20);
            
            emailLabel.Text = "Ел. адреса:";
            emailLabel.Location = new Point(10, userNameTextBox.Bottom + 10);
            emailLabel.AutoSize = true;
            
            emailTextBox.Location = new Point(75, userNameTextBox.Bottom + 10);
            emailTextBox.Size = new Size(150, 20);
            
            passwordLabel.Text = "Пароль:";
            passwordLabel.Location = new Point(10, emailTextBox.Bottom + 10);
            passwordLabel.AutoSize = true;
            
            passwordTextBox.Location = new Point(75, emailTextBox.Bottom + 10);
            passwordTextBox.Size = new Size(150, 20);
            
            commentLabel.Text = "Коментар:";
            commentLabel.Location = new Point(10, passwordTextBox.Bottom + 10);
            commentLabel.AutoSize = true;
            
            commentTextBox.Location = new Point(75, passwordTextBox.Bottom + 10);
            commentTextBox.Size = new Size(180, 50);
            commentTextBox.Multiline = true;
            
            ratingLabel.Text = "Рейтинг:";
            ratingLabel.Location = new Point(10, commentTextBox.Bottom + 10);
            ratingLabel.AutoSize = true;
            
            ratingTextBox.Location = new Point(75, commentTextBox.Bottom + 10);
            ratingTextBox.Size = new Size(20, 20);
            
            submitButton.Text = "Відправити";
            submitButton.Location = new Point(10, ratingTextBox.Bottom + 10);
            submitButton.Size = new Size(100, 30);
            submitButton.Click += (sender, e) =>
            {
                if (userNameTextBox.Text.Trim() != "" && emailTextBox.Text.Trim() != "" && passwordTextBox.Text.Trim().Length >= 8 && commentTextBox.Text.Trim() != "" && ratingTextBox.Text.Trim() != "")
                {
                    int rating = 0;
                    try
                    {
                        rating = Convert.ToInt32(ratingTextBox.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("Неправильний рейтинг", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (rating > 0 && rating <= 5)
                    {
                        addComment(new User(userNameTextBox.Text.Trim(), emailTextBox.Text.Trim(), passwordTextBox.Text.Trim()), commentTextBox.Text.Trim(), rating);
                        showComments();
                    }
                    else
                        MessageBox.Show("Неправильний рейтинг", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Неправильні аргументи", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            int NameBoxY = nameBox.Location.Y;
            int CaptionBoxY = captionBox.Location.Y;
            int TextBoxY = textBox.Location.Y;
            int CommentFormPanelY = commentFormPanel.Location.Y;

            scrollBar.Location = new Point(panel.Width - 20, 0);
            scrollBar.Size = new Size(20, panel.Height);
            scrollBar.Dock = DockStyle.Right;

            scrollBar.Scroll += (sender, e) =>
            {
                nameBox.Location = new Point(nameBox.Location.X, NameBoxY - (scrollBar.Value * 10));
                captionBox.Location = new Point(captionBox.Location.X, CaptionBoxY - (scrollBar.Value * 10));
                textBox.Location = new Point(textBox.Location.X, TextBoxY - (scrollBar.Value * 10));
                commentFormPanel.Location = new Point(commentFormPanel.Location.X, CommentFormPanelY - (scrollBar.Value * 10));

                foreach (Comment comment in comments)
                {
                    comment.scroll(scrollBar.Value * 10);
                }
            };

            scrollBar.TabIndex = 0;
        }
    }
}
