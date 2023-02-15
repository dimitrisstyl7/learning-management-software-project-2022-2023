using Project_final_2022_2023.Classes;
using Project_final_2022_2023.Forms;
using System.Text;

namespace Project_final_2022_2023
{
    public partial class Info_form : Form
    {
        private readonly Button main_start_button;

        public Info_form(Button button)
        {
            main_start_button = button;
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

        private void Start_pictureBox_MouseHover(object sender, EventArgs e)
        {
            start_pictureBox.Cursor = Cursors.Hand;
        }

        private void Start_pictureBox_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var _ = ImportData.finalQuestions;
            main_start_button.Visible = false;
            new Questions_form(this).ShowDialog();
        }
    }
}
