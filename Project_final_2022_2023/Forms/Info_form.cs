using Project_final_2022_2023.Classes;
using Project_final_2022_2023.Forms;
using System.Text;

namespace Project_final_2022_2023
{
    public partial class Info_form : Form
    {
        private readonly Button main_start_button, main_exit_button;

        public Info_form(Button b1, Button b2)
        {
            main_start_button = b1;
            main_exit_button = b2;
            InitializeComponent();
        }

        private void Info_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //set the position of the panel
            info_panel.Location = new Point(this.Width / 2 - info_panel.Width/2, this.Height / 2 - info_panel.Height/2);
            info_panel.Visible = true;
        }

        private void Cancel_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        private void Cancel_pictureBox_MouseHover(object sender, EventArgs e)
        {
            cancel_pictureBox.Cursor = Cursors.Hand;
        }

        private void Start_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var _ = ImportData.finalQuestions;
            new Questions_form(this).ShowDialog();
        }

        private void Start_pictureBox_MouseHover(object sender, EventArgs e)
        {
            start_pictureBox.Cursor = Cursors.Hand;
        }

        private void Start_pictureBox_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var _ = ImportData.finalQuestions;
            main_start_button.Visible = false;
            main_exit_button.Location = new Point(this.Width/2 - main_exit_button.Width/2, main_exit_button.Location.Y);
            new Questions_form(this).ShowDialog();
        }
    }
}
