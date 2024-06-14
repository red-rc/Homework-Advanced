using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class Comment
    {
        private User user;
        public Panel commentPanel;
        public Label userNameLabel;
        public Label ratingLabel;
        public TextBox textBox;
        public Panel panel;
        public static int increment = 0;
        private int id = 0;
        private int PreviousCommentsCount;
        public int commentPanelY;
        public Comment(User user, int PreviousCommentsCount, int rating, string text, Panel panel) 
        {
            id = increment++;
            this.PreviousCommentsCount = PreviousCommentsCount;
            commentPanel = new Panel();
            userNameLabel = new Label();
            ratingLabel = new Label();
            textBox = new TextBox();
            userNameLabel.Text = user.getName();
            ratingLabel.Text = "Рейтинг: " + rating.ToString();
            textBox.Text = text;
            this.user = user;
            this.panel = panel;

            createUI();
            hideComment();
            commentPanelY = commentPanel.Location.Y;
        }
        public void showComment()
        {
            commentPanel.Show();
        }
        public void hideComment()
        {
            commentPanel.Hide();
        }
        public void scroll(int x)
        {
            commentPanel.Location = new Point(commentPanel.Location.X, commentPanelY - x);
        }
        public void createUI()
        {
            panel.Controls.Add(commentPanel);
            commentPanel.Location = new Point(10, 800 + (id - PreviousCommentsCount) * 220);
            commentPanel.Size = new Size(panel.Width - 10, 200);
            commentPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            commentPanel.BackColor = Color.FromArgb(250, 250, 250);

            commentPanel.Controls.Add(userNameLabel);
            commentPanel.Controls.Add(ratingLabel);
            commentPanel.Controls.Add(textBox);

            userNameLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            userNameLabel.ForeColor = Color.Gray;
            ratingLabel.Font = new Font("Microsoft Sans Serif", 12.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);

            userNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            ratingLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            textBox.BackColor = Color.FromArgb(250, 250, 250);

            userNameLabel.AutoSize = true;
            ratingLabel.AutoSize = true;
            textBox.Multiline = true;

            userNameLabel.Location = new Point(10, 10);
            userNameLabel.Size = new Size(100, 20);
            ratingLabel.Location = new Point(10, 30);
            ratingLabel.Size = new Size(100, 20);
            textBox.Location = new Point(10, 70);
            textBox.Size = new Size(300, 100);
            textBox.BorderStyle = BorderStyle.None;
        }
    }
}
