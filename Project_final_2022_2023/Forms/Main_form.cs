using Project_final_2022_2023.Classes;

namespace Project_final_2022_2023
{
    public partial class Main_form : Form
    {
        bool alreadyShowedOnce = false;

        public Main_form()
        {
            InitializeComponent();
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            AlignButtons();
            AlignTitle();
        }

        private void AlignButtons()
        {
            int X = this.Width / 2 - start_button.Width / 2;
            int Y = this.Height / 2 - start_button.Height / 2;
            start_button.Location = new Point(X-100, Y);
            exit_button.Location = new Point(X+100, Y);
        }

        private void AlignTitle()
        {
            int X = this.Width / 2 - title_label.Width / 2;
            title_label.Location = new Point(X, 400);
        }

        private void CustomButton1_Click(object sender, EventArgs e)
        {
            new Info_form(start_button, exit_button, this).ShowDialog();
        }

        private void CustomButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_form_VisibleChanged(object sender, EventArgs e)
        {
            if (alreadyShowedOnce && this.Visible)
            {
                double temp_result = Question.QTotalMarks;
                int result = temp_result == 12 ? 100 : (int)(Math.Round(Question.QTotalMarks) * 25 / 3);
                result_label.Text = "Αποτέλεσμα: " + result + " %";
                result_label.Location = new Point(exit_button.Location.X - 100, exit_button.Location.Y + 100);
                result_label.Visible = true;
            }
            alreadyShowedOnce = true;
        }
    }
}