using Project_final_2022_2023.Classes;
using System.Net.Http.Headers;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        private int qNumber; //it keeps the question that is running right now
        private int totalTime = 0;
        int tm, ts; //totalTimer -> minutes and seconds
        int qm, qs; //questionTimer -> minutes and seconds

        public Questions_layout_form(Info_form form)
        {
            InitializeComponent();
            form.Dispose();
        }

        private void Questions_layout_form_Load(object sender, EventArgs e)
        {
            //center the test panel
            this.FormBorderStyle = FormBorderStyle.None;
            int width = this.Width / 2 - background_panel.Width / 2;
            int height = this.Height / 2 - background_panel.Height / 2;
            background_panel.Location = new Point(width, height);

            //start from question1
            qNumber = 1;

            //make all panel, except question1, invisible
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            //panel4.Visible = false;
            //panel5.Visible = false;
            //panel6.Visible = false;

            //disable the left arrow
            left_arrow_pictureBox.Visible = false;

            createTotalTimer();

            createQuestionTimer();

            //create question 1 panel
            panel1.Location = new Point(122,75);
            panel1.Size= new Size(1600,800);
            question1Text_richTextBox.Text = ImportData.finalQuestions[0].QText;

            //create question 2 panel
            panel2.Location = new Point(122, 75);
            panel2.Size = new Size(1600, 800);
            question2Text_richTextBox.Text = ImportData.finalQuestions[1].QText;
            var x = ImportData.finalQuestions[1].QAnswers[0];
            q2_answer1.Text = x[0];
            q2_answer2.Text = x[1];
            q2_answer3.Text = x[2];
            q2_answer4.Text = x[3];
            
            //create question 3 panel
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

        private void createTotalTimer()
        {
            //count total minutes for all 6 final questions
            foreach (Question i in ImportData.finalQuestions)
            {
                totalTime += i.QTime;
            }
            int timese = totalTime / 60; //δεν παίρνω τα δεκαδικά
            tm = timese;

            //start total Timer 
            totalTimer.Interval = 1000; //1s timer
            totalTimer.Enabled = true;
            totalTimer.Start();
        }

        private void createQuestionTimer()
        {
            int i = ImportData.finalQuestions[qNumber].QTime;
            int y = ImportData.finalQuestions[qNumber].QTimeRemaining;
            if ( i > y)
            {
                qm = i / 60;  //δεν παίρνω τα δεκαδικά
            }
            else
            {
                qm = y / 60; //δεν παίρνω τα δεκαδικά
            }

            //start question Timer
            questionTimer.Interval = 1000; //1s timer
            questionTimer.Enabled = true;
            questionTimer.Start();
        }

        private void left_arrow_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 2:
                    panel2.Visible = false;
                    panel1.Visible = true;
                    qNumber = 1;
                    createQuestionTimer();
                    break;
                case 3:
                    panel3.Visible = false;
                    panel2.Visible = true;
                    qNumber = 2;
                    createQuestionTimer();
                    break;
                    /*
                    case 4:
                        panel4.Visible = false;
                        panel3.Visible = true;
                        qNumber = 3;
                        createQuestionTimer();
                        break;
                    case 5:
                        panel5.Visible = false;
                        panel4.Visible = true;
                        qNumber = 4;
                        createQuestionTimer();
                        break;
                    case 6:
                        panel6.Visible = false;
                        panel5.Visible = true;
                        qNumber = 5;
                        createQuestionTimer();
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
                    createQuestionTimer();
                    break;
                case 2:
                    panel2.Visible = false;
                    panel3.Visible = true;
                    qNumber = 3;
                    createQuestionTimer();
                    break;
                    /*case 3:
                        panel3.Visible = false;
                        panel4.Visible = true;
                        qNumber = 4;
                        createQuestionTimer();
                        break;
                    case 4:
                        panel4.Visible = false;
                        panel5.Visible = true;
                        qNumber = 5;
                        createQuestionTimer();
                        break;
                    case 5:
                        panel5.Visible = false;
                        panel6.Visible = true;
                        qNumber = 6;
                        createQuestionTimer();
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

        private void totalTimer_Tick(object sender, EventArgs e)
        {
            if (ts != 0) 
            {
                ts -= 1;
                totalTimeTimer_label.Text = string.Format("{0}:{1}", tm.ToString().PadLeft(2, '0'), ts.ToString().PadLeft(2, '0'));
            }
            else if (ts == 00 & tm != 00)
            {
                ts = 59;
                tm -= 1;
                totalTimeTimer_label.Text = string.Format("{0}:{1}", tm.ToString().PadLeft(2, '0'), ts.ToString().PadLeft(2, '0'));
            }
            else
            {
                totalTimer.Stop();
                totalTimeTimer_label.Text = "Τέλος Χρόνου";
            }
        }

        private void questionTimer_Tick(object sender, EventArgs e)
        {
            //is NOT ready
            
            if (qs != 0)
            {
                qs -= 1;
                questionTimeTimer_Label.Text = string.Format("{0}:{1}", qm.ToString().PadLeft(2, '0'), qs.ToString().PadLeft(2, '0'));
            }
            else if (qs == 00 & qm != 00)
            {
                qs = 59;
                qm -= 1;
                questionTimeTimer_Label.Text = string.Format("{0}:{1}", qm.ToString().PadLeft(2, '0'), qs.ToString().PadLeft(2, '0'));
            }
            else
            {
                questionTimer.Stop();
                questionTimeTimer_Label.Text = "Τέλος Χρόνου";
            }                    
        }
    }
}
