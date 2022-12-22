using Project_final_2022_2023.Classes;
using System.Text;

namespace Project_final_2022_2023
{
    public partial class info_form : Form
    {
        public info_form()
        {
            InitializeComponent();
        }

        private void Info_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            //set the position of the panel
            info_panel.Location = new Point(this.Width / 2 - info_panel.Width/2, this.Height / 2 - info_panel.Height/2);
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
            StringBuilder s = new();
            var q = ImportData.Questions[ImportData.Questions.Count-3];
            s.Append("Ekfwnhsh : " + q.QText + Environment.NewLine + "Eidos erwthshs : " + q.QType + Environment.NewLine + "Answers : " + Environment.NewLine);

            foreach (var x in q.QAnswers)
            {
                s.Append("Column : ");
                foreach (var y in x)
                    s.Append(y + " , ");
                s.Append(Environment.NewLine);
            }

            s.Append("Correct Answers : ");
            foreach (var x in q.QCorrectAns)
                s.Append(x + " , ");

            info_richTextBox.Text = s.ToString();
        }

        private void Start_pictureBox_MouseHover(object sender, EventArgs e)
        {
            start_pictureBox.Cursor = Cursors.Hand;
        }
    }
}
