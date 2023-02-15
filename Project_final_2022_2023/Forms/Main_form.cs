namespace Project_final_2022_2023
{
    public partial class Main_form : Form
    {
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            new Info_form().ShowDialog();
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

        private void customButton1_Click(object sender, EventArgs e)
        {
            new Info_form().ShowDialog();
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}