namespace Project_final_2022_2023
{
    public partial class main_form : Form
    {
        private static int max_width, max_height;

        public main_form()
        {
            InitializeComponent();
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            max_width = this.Width;
            max_height = this.Height;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public static int getWidth
        {
            get { return max_width; }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            new Info().ShowDialog();
        }

        public static int getHeight
        {
            get { return max_height; }
        }
    }
}