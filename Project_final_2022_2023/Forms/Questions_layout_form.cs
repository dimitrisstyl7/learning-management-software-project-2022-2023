using Project_final_2022_2023.Classes;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        private int qNumber; //it keeps the question that is running right now
        private int totalTime = 0;
        private int tm, ts; //totalTimer -> tm = minutes and ts = seconds
        private int qm, qs; //questionTimer -> qm = minutes and qs = seconds
        private Panel currentPanel;
        
        public Questions_layout_form(Info_form form)
        {
            InitializeComponent();
            form.Dispose();
            currentPanel = panel1;
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
            panel4.Visible = false;
            panel5.Visible = false;
            //panel6.Visible = false;

            //disable the left arrow
            left_arrow_pictureBox.Visible = false;

            CreateTotalTimer();
            CreateQuestionTimer();

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

            //create question 4 panel
            panel4.Location = new Point(122, 75);
            panel4.Size = new Size(1600, 800);
            question4_richTextBox.Text = ImportData.finalQuestions[3].QText;
            var z = ImportData.finalQuestions[3].QAnswers[0];
            q4_label1.Text = z[0];
            q4_label2.Text = z[1];
            q4_label3.Text = z[2];
            q4_label4.Text = z[3];

            //create question 5 panel
            panel5.Location = new Point(122, 75);
            panel5.Size = new Size(1600, 800);
            question5_richTextBox.Text = ImportData.finalQuestions[4].QText;
            var colA = ImportData.finalQuestions[4].QAnswers[0];
            var colB = ImportData.finalQuestions[4].QAnswers[1];
            if (colA[0].EndsWith("path"))
            {
                q5_pentagon_pictureBox.Visible = true;
                q5_triangle_pictureBox.Visible = true;
                q5_square_pictureBox.Visible = true;
            }
            else
            {
                q5_label1.Text = colA[0];
                q5_label2.Text = colA[1];
                q5_label3.Text = colA[2];
                q5_label1.Visible = true;
                q5_label2.Visible = true;
                q5_label3.Visible = true;
            }
            q5_label4.Text = colB[0];
            q5_label5.Text = colB[1];
            q5_label6.Text = colB[2];

            /*
            panel6.Location = new Point(122, 75);
            panel6.Size = new Size(1600, 800);
            */
        }

        private void CreateTotalTimer()
        {
            //count total minutes for all 6 final questions
            foreach (Question q in ImportData.finalQuestions)
            {
                totalTime += q.QTime;
            }
            tm = totalTime / 60; //minutes
            ts = totalTime % 60; //seconds

            //start total Timer 
            totalTimer.Interval = 1000; //1s timer -> 1000ms = 1s
            totalTimer.Enabled = true;
            totalTimer.Start();
        }

        private void CreateQuestionTimer()
        {
            int qTimeRemaining = ImportData.finalQuestions[qNumber - 1].QTimeRemaining;
            if ( qTimeRemaining != 0)
            {
                qm = qTimeRemaining / 60;  //minutes
                qs = qTimeRemaining % 60;  //seconds
            }

            //start question Timer
            questionTimer.Interval = 1000; //1s timer -> 1000ms = 1s
            questionTimer.Enabled = true;
            questionTimer.Start();
        }

        private void Left_arrow_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 2:
                    panel2.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel1.Visible = true;
                    left_arrow_pictureBox.Visible = false;
                    qNumber = 1;
                    CreateQuestionTimer();
                    currentPanel = panel1;
                    break;
                case 3:
                    panel3.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel2.Visible = true;
                    qNumber = 2;
                    CreateQuestionTimer();
                    currentPanel = panel2;
                    break;
                case 4:
                    panel4.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel3.Visible = true;
                    qNumber = 3;
                    CreateQuestionTimer();
                    break;
                case 5:
                    panel5.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel4.Visible = true;
                    qNumber = 4;
                    CreateQuestionTimer();
                    break;
                    /*case 6:
                        panel6.Visible = false;
                        ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                        panel5.Visible = true;
                        qNumber = 5;
                        createQuestionTimer();
                        break;
                    */
            }
        }

        private void Right_arrow_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 1:
                    panel1.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel2.Visible = true;
                    qNumber = 2;
                    left_arrow_pictureBox.Visible = true;
                    CreateQuestionTimer();
                    currentPanel = panel2;
                    break;
                case 2:
                    panel2.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel3.Visible = true;
                    qNumber = 3;
                    CreateQuestionTimer();
                    currentPanel = panel3;
                    break;
                case 3:
                    panel3.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel4.Visible = true;
                    qNumber = 4;
                    CreateQuestionTimer();
                    break;
                case 4:
                    panel4.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel5.Visible = true;
                    qNumber = 5;
                    CreateQuestionTimer();
                    break;
                    /*case 5:
                        panel5.Visible = false;
                        ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
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

        private void Q5_label4_MouseDown(object sender, MouseEventArgs e)
        {
            EnableButtons();
            q5_label4.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);

        }

        private void Q5_label5_MouseDown(object sender, MouseEventArgs e)
        {
            EnableButtons();
            DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q5_label6_MouseDown(object sender, MouseEventArgs e)
        {
            EnableButtons();
            q5_label6.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void DropButtton1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropButtton2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropButtton3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropButtton1_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            DisableButtons();
        }


        private void DropButtton2_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            DisableButtons();
        }

        private void DropButtton3_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            DisableButtons();
        }

        private void TotalTimer_Tick(object sender, EventArgs e)
        {
            if (ts != 0)
            {
                ts -= 1;
                totalTimeTimer_label.Text = string.Format("{0}:{1}", tm.ToString().PadLeft(2, '0'), ts.ToString().PadLeft(2, '0'));// if ts = 5, then {0} = 05.
            }
            else if (tm != 00) //ts == 00 & tm != 00
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

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            //is NOT ready
            
            if (qs != 0)
            {
                qs -= 1;
                questionTimeTimer_Label.Text = string.Format("{0}:{1}", qm.ToString().PadLeft(2, '0'), qs.ToString().PadLeft(2, '0'));
            }
            else if (qm != 00) //qs == 00 & qm != 00
            {
                qs = 59;
                qm -= 1;
                questionTimeTimer_Label.Text = string.Format("{0}:{1}", qm.ToString().PadLeft(2, '0'), qs.ToString().PadLeft(2, '0'));
            }
            else
            {
                questionTimer.Stop();
                questionTimeTimer_Label.Text = "Τέλος Χρόνου";
                currentPanel.Enabled = false;
            }
        }

        private void EnableButtons()
        {
            dropButton1.Enabled = true;
            dropButton2.Enabled = true;
            dropButton3.Enabled = true;
        }

        private void DisableButtons()
        {
            dropButton1.Enabled = false;
            dropButton2.Enabled = false;
            dropButton3.Enabled = false;
        }
    }
}
