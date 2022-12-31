using Project_final_2022_2023.Classes;
using System.Net.Http.Headers;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        private int qNumber;


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

            qNumber = 1;

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            //panel4.Visible = false;
            //panel5.Visible = false;
            //panel6.Visible = false;

            left_arrow_pictureBox.Visible = false;

            //to work on your question set the visibility to true

            panel1.Location = new Point(122,75);
            panel1.Size= new Size(1600,800);
            question1Text_richTextBox.Text = ImportData.finalQuestions[0].QText;

            panel2.Location = new Point(122, 75);
            panel2.Size = new Size(1600, 800);
            question2Text_richTextBox.Text = ImportData.finalQuestions[1].QText;
            var x = ImportData.finalQuestions[1].QAnswers[0];
            q2_answer1.Text = x[0];
            q2_answer2.Text = x[1];
            q2_answer3.Text = x[2];
            q2_answer4.Text = x[3];
            


            
            panel3.Location = new Point(122, 75);
            panel3.Size = new Size(1600, 800);
            question3_richTextBox.Text = ImportData.finalQuestions[2].QText;
            var y = ImportData.finalQuestions[2].QAnswers[0];
            q3_answer1.Text = y[0];
            q3_answer2.Text = y[1];
            q3_answer3.Text = y[2];
            q3_answer4.Text = y[3];

            /*
            panel4.Location = new Point(122, 75);
            panel4.Size = new Size(1600, 800);
            

            panel5.Location = new Point(122, 75);
            panel5.Size = new Size(1600, 800);
            

            panel6.Location = new Point(122, 75);
            panel6.Size = new Size(1600, 800);
            */
        }

        private void left_arrow_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 2:
                    panel2.Visible = false;
                    panel1.Visible = true;
                    qNumber = 1;
                    break;
                case 3:
                    panel3.Visible = false;
                    panel2.Visible = true;
                    qNumber = 2;
                    break;
                    /*
                    case 4:
                        panel4.Visible = false;
                        panel3.Visible = true;
                        qNumber = 3;    
                        break;
                    case 5:
                        panel5.Visible = false;
                        panel4.Visible = true;
                        qNumber = 4;
                        break;
                    case 6:
                        panel6.Visible = false;
                        panel5.Visible = true;
                        qNumber = 5;
                        break;
                    */
            }
        }

        private void right_arrow_pictureBox_Click(object sender, EventArgs e)
        {
            switch(qNumber)
            {
                case 1:
                    panel1.Visible = false;
                    panel2.Visible = true;
                    qNumber = 2;
                    left_arrow_pictureBox.Visible = true;
                    break;
                case 2:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    qNumber = 3;
                    break;
                    /*case 3:
                        panel3.Visible = false;
                        panel4.Visible = true;
                        qNumber = 4;
                        break;
                    case 4:
                        panel4.Visible = false;
                        panel5.Visible = true;
                        qNumber = 5;
                        break;
                    case 5:
                        panel5.Visible = false;
                        panel6.Visible = true;
                        qNumber = 6;
                        break;
                    case 6:
                        //make showdialog to final form
                        break;
                */
            }
        }

        private void Left_arrow_pictureBox_MouseHover(object sender, EventArgs e)
        {
            left_arrow_pictureBox.Cursor = Cursors.Hand;
        }

        private void Right_arrow_pictureBox_MouseHover(object sender, EventArgs e)
        {
            right_arrow_pictureBox.Cursor = Cursors.Hand;
        }

        private void Refresh_pictureBox_MouseHover(object sender, EventArgs e)
        {
            refresh_pictureBox.Cursor = Cursors.Hand;
        }

        private void Tip_pictureBox_MouseHover(object sender, EventArgs e)
        {
            tip_pictureBox.Cursor = Cursors.Hand;
        }
    }
}
