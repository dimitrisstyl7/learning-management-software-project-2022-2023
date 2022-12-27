using Project_final_2022_2023.Classes;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        public Questions_layout_form(Info_form form)
        {
            InitializeComponent();
            form.Dispose();
        }



        private void Questions_layout_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            int width = this.Width / 2 - background_panel.Width / 2;
            int height = this.Height / 2 - background_panel.Height / 2;
            background_panel.Location = new Point(width, height);
            // set the size of the backround panel
            //background_panel.Size = new Size(this.Width, this.Height - 2*left_arrow_pictureBox.Height);

            //set the position of the panel
            /*background_panel.Location = new Point(this.Width / 2 - info_panel.Width / 2, this.Height / 2 - info_panel.Height / 2);*/

            refresh_pictureBox.Location = new Point(left_arrow_pictureBox.Width * 2, this.Height);












            /*StringBuilder s = new();
            var q = ImportData.finalQuestions[4];
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

            foreach (Question x in ImportData.finalQuestions)
                s.Append(Environment.NewLine + "Question time : " + x.QTime);
            s.Append(Environment.NewLine + Question.QTotalTime);

            richTextBox1.Text = s.ToString();*/
        }
    }
}
