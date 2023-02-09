using Project_final_2022_2023.Classes;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        private int qNumber; //it keeps the question that is running right now
        private int tm, ts; //totalTimer -> tm = minutes and ts = seconds
        private int qm, qs; //questionTimer -> qm = minutes and qs = seconds
        private Panel currentPanel;
        public Questions_layout_form(Info_form form)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            form.Dispose();
            qNumber = 1; //start from question1
            currentPanel = panel1;
        }

        private void Questions_layout_form_Load(object sender, EventArgs e)
        {
            //center the panel
            this.FormBorderStyle = FormBorderStyle.None;
            int width = this.Width / 2 - background_panel.Width / 2;
            int height = this.Height / 2 - background_panel.Height / 2;
            background_panel.Location = new Point(width, height);
            FillData(); // Fill panels data
        }

        private void CreateTotalTimer()
        {
            int totalTime = 0;
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
            if (qTimeRemaining != 0)
            {
                qm = qTimeRemaining / 60;  //minutes
                qs = qTimeRemaining % 60;  //seconds
                //start question Timer
                questionTimer.Interval = 1000; //1s timer -> 1000ms = 1s
                questionTimer.Enabled = true;
                questionTimer.Start();// move it somewhere else
            }
        }

        private void Left_arrow_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 2:
                    panel2.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel1.Visible = true;
                    currentPanel = panel1;
                    left_arrow_pictureBox.Visible = false;
                    qNumber = 1;
                    CreateQuestionTimer();
                    break;
                case 3:
                    panel3.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel2.Visible = true;
                    currentPanel = panel2;
                    qNumber = 2;
                    CreateQuestionTimer();
                    break;
                case 4:
                    panel4.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel3.Visible = true;
                    currentPanel = panel3;
                    qNumber = 3;
                    CreateQuestionTimer();
                    break;
                case 5:
                    panel5.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel4.Visible = true;
                    currentPanel = panel4;
                    qNumber = 4;
                    CreateQuestionTimer();
                    break;
                case 6:
                    panel6.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel5.Visible = true;
                    currentPanel = panel5;
                    qNumber = 5;
                    CreateQuestionTimer();
                    break;
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
                    currentPanel = panel2;
                    qNumber = 2;
                    left_arrow_pictureBox.Visible = true;
                    CreateQuestionTimer();
                    break;
                case 2:
                    panel2.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel3.Visible = true;
                    currentPanel = panel3;
                    qNumber = 3;
                    CreateQuestionTimer();
                    break;
                case 3:
                    panel3.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel4.Visible = true;
                    currentPanel = panel4;
                    qNumber = 4;
                    CreateQuestionTimer();
                    break;
                case 4:
                    panel4.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel5.Visible = true;
                    currentPanel = panel5;
                    qNumber = 5;
                    CreateQuestionTimer();
                    break;
                case 5:
                    panel5.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    panel6.Visible = true;
                    currentPanel = panel6;
                    qNumber = 6;
                    CreateQuestionTimer();
                    break;
                case 6:
                    panel6.Visible = false;
                    ImportData.finalQuestions[qNumber - 1].QTimeRemaining = qm * 60 + qs;
                    HidePanelButtons();
                    FillStatusColumn();
                    q_panel.Visible = true;
                    questionTimer.Enabled = false;
                    questionTime_label.Visible = false;
                    questionTimeTimer_Label.Visible = false;
                    break;
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
            QEnableButtons(5);
            q5_label4.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);

        }

        private void Q5_label5_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(5);
            DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q5_label6_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(5);
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
            QDisableButtons(5);
        }

        private void DropButtton2_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(5);
        }

        private void DropButtton3_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(5);
        }

        private void TotalTimer_Tick(object sender, EventArgs e)
        {
            if (ts != 0)
            {
                ts -= 1;
                totalTimeTimer_label.Text = string.Format("{0}:{1}", tm.ToString().PadLeft(2, '0'), ts.ToString().PadLeft(2, '0'));// if ts = 5, then {0} = 05.
            }
            else if (tm != 0) //ts == 0 & tm != 0
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
            else if (qm != 0) //qs == 0 & qm != 0
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

        private void Q6_label14_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label14.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label12_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label12.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label13_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label13.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label15_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label15.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_button1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button6_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button7_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
        }

        private void Q6_button1_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_button2_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_button3_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_button4_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_button5_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_button6_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_button7_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)sender).Text = e.Data.GetData(DataFormats.Text).ToString();
            QDisableButtons(6);
        }

        private void Q6_label1_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label1.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label2_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label2.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label3_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label3.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label4_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label4.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label9_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label9.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label10_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label10.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Q6_label11_MouseDown(object sender, MouseEventArgs e)
        {
            QEnableButtons(6);
            q6_label11.DoDragDrop(((Label)sender).Text, DragDropEffects.Copy);
        }

        private void Refresh_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 1:
                    radio_button_trash.Checked = true;
                    break;
                case 2:
                    q2_answer1.Checked = false;
                    q2_answer2.Checked = false;
                    q2_answer3.Checked = false;
                    q2_answer4.Checked = false;
                    break;
                case 3:
                    q3_answer1.Checked = false;
                    q3_answer2.Checked = false;
                    q3_answer3.Checked = false;
                    q3_answer4.Checked = false;
                    break;
                case 4:
                    q4_textBox1.Text = String.Empty;
                    q4_textBox2.Text = String.Empty;
                    q4_textBox3.Text = String.Empty;
                    q4_textBox4.Text = String.Empty;
                    break;
                case 5:
                    q5_button1.Text = String.Empty;
                    q5_button2.Text = String.Empty;
                    q5_button3.Text = String.Empty;
                    break;
                case 6:
                    q6_button1.Text = String.Empty;
                    q6_button2.Text = String.Empty;
                    q6_button3.Text = String.Empty;
                    q6_button4.Text = String.Empty;
                    q6_button5.Text = String.Empty;
                    q6_button6.Text = String.Empty;
                    q6_button7.Text = String.Empty;
                    break;
            }
        }

        private void QEnableButtons(int question)
        {
            if (question == 5)
            {
                q5_button1.Enabled = true;
                q5_button2.Enabled = true;
                q5_button3.Enabled = true;
            }
            else
            {
                q6_button1.Enabled = true;
                q6_button2.Enabled = true;
                q6_button3.Enabled = true;
                q6_button4.Enabled = true;
                q6_button5.Enabled = true;
                q6_button6.Enabled = true;
                q6_button7.Enabled = true;
            }
        }

        private void QDisableButtons(int question)
        {
            if (question == 5)
            {
                q5_button1.Enabled = false;
                q5_button2.Enabled = false;
                q5_button3.Enabled = false;
            }
            else
            {
                q6_button1.Enabled = false;
                q6_button2.Enabled = false;
                q6_button3.Enabled = false;
                q6_button4.Enabled = false;
                q6_button5.Enabled = false;
                q6_button6.Enabled = false;
                q6_button7.Enabled = false;
            }
        }
    
        private void FillData()
        {
            radio_button_trash.Checked = true;
            panel1.Visible = true;

            //disable the left arrow
            left_arrow_pictureBox.Visible = false;

            CreateTotalTimer();
            CreateQuestionTimer();

            //align q_panel to center, change size
            q_panel.Location = new Point(122, 75);
            q_panel.Size = new Size(1600, 800);

            //align panel 1 to center, change size
            panel1.Location = new Point(122, 75);
            panel1.Size = new Size(1600, 800);
            question1Text_richTextBox.Text = ImportData.finalQuestions[0].QText;

            //align panel2 to center, change size
            panel2.Location = new Point(122, 75);
            panel2.Size = new Size(1600, 800);
            //import data
            question2Text_richTextBox.Text = ImportData.finalQuestions[1].QText;
            var x = ImportData.finalQuestions[1].QAnswers[0];
            q2_answer1.Text = x[0];
            q2_answer2.Text = x[1];
            q2_answer3.Text = x[2];
            q2_answer4.Text = x[3];

            //align panel3 to center, change size
            panel3.Location = new Point(122, 75);
            panel3.Size = new Size(1600, 800);
            //import data
            question3_richTextBox.Text = ImportData.finalQuestions[2].QText;
            var y = ImportData.finalQuestions[2].QAnswers[0];
            q3_answer1.Text = y[0];
            q3_answer2.Text = y[1];
            q3_answer3.Text = y[2];
            q3_answer4.Text = y[3];

            //align panel4 to center, change size
            panel4.Location = new Point(122, 75);
            panel4.Size = new Size(1600, 800);
            //import data
            question4_richTextBox.Text = ImportData.finalQuestions[3].QText;
            var z = ImportData.finalQuestions[3].QAnswers[0];
            q4_label1.Text = z[0];
            q4_label2.Text = z[1];
            q4_label3.Text = z[2];
            q4_label4.Text = z[3];

            //align panel5 to center, change size
            panel5.Location = new Point(122, 75);
            panel5.Size = new Size(1600, 800);
            //import data
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

            //align panel6 to center, change size
            panel6.Location = new Point(122, 75);
            panel6.Size = new Size(1600, 800);
            //import data
            question6_richTextBox.Text = ImportData.finalQuestions[5].QText;
            colA = ImportData.finalQuestions[5].QAnswers[0];

            q6_label1.Text = colA[0].Split('#')[0];
            q6_label2.Text = colA[1].Split('#')[0];
            q6_label3.Text = colA[2].Split('#')[0];
            q6_label4.Text = colA[3].Split('#')[0];

            try
            {
                var colC = ImportData.finalQuestions[5].QAnswers[1];
                q6_label12.Text = colC[0];
                q6_label13.Text = colC[1];
                q6_label12.Visible = true;
                q6_label13.Visible = true;

                if (colC.Length == 4)
                {
                    q6_label14.Text = colC[2];
                    q6_label15.Text = colC[3];
                    q6_label14.Visible = true;
                    q6_label15.Visible = true;
                }

                q6_label5.Text = colA[0].Split('#')[1];
                q6_label6.Text = colA[1].Split('#')[1];
                q6_label7.Text = colA[2].Split('#')[1];
                q6_label8.Text = colA[3].Split('#')[1];
                q6_label5.Visible = true;
                q6_label6.Visible = true;
                q6_label7.Visible = true;
                q6_label8.Visible = true;

                q6_label1.MouseDown -= new MouseEventHandler(Q6_label1_MouseDown);
                q6_label2.MouseDown -= new MouseEventHandler(Q6_label2_MouseDown);
                q6_label3.MouseDown -= new MouseEventHandler(Q6_label3_MouseDown);
                q6_label4.MouseDown -= new MouseEventHandler(Q6_label4_MouseDown);
            }
            catch
            {
                q6_label9.Text = colA[4].Split('#')[0];
                q6_label10.Text = colA[5].Split('#')[0];
                q6_label11.Text = colA[6].Split('#')[0];
                q6_label9.Visible = true;
                q6_label10.Visible = true;
                q6_label11.Visible = true;
                q6_button5.Visible = true;
                q6_button6.Visible = true;
                q6_button7.Visible = true;
            }
        }

        private void HidePanelButtons()
        {
            left_arrow_pictureBox.Visible = false;
            right_arrow_pictureBox.Visible = false;
            tip_pictureBox.Visible = false;
            refresh_pictureBox.Visible = false;
        }

        private void UnhidePanelButtons()
        {
            left_arrow_pictureBox.Visible = true;
            right_arrow_pictureBox.Visible = true;
            tip_pictureBox.Visible = true;
            refresh_pictureBox.Visible = true;
        }

        private void FillStatusColumn()
        {
            if (q1_true.Checked || q1_false.Checked)
            {
                status1_label.Text = "Απαντήθηκε";
                status1_label.ForeColor = Color.Green;
            }
            else if (ImportData.finalQuestions[0].QTimeRemaining == 0)
            {
                status1_label.Text = "Τέλος χρόνου";
                status1_label.ForeColor = Color.Gray;
            }
            else
            {
                status1_label.Text = "Δεν απαντήθηκε";
                status1_label.ForeColor = Color.Red;
            }

            if (q2_answer1.Checked || q2_answer2.Checked || q2_answer3.Checked || q2_answer4.Checked)
            {
                status2_label.Text = "Απαντήθηκε";
                status2_label.ForeColor = Color.Green;
            }
            else if (ImportData.finalQuestions[1].QTimeRemaining == 0)
            {
                status2_label.Text = "Τέλος χρόνου";
                status2_label.ForeColor = Color.Gray;
            }
            else
            {
                status2_label.Text = "Δεν απαντήθηκε";
                status2_label.ForeColor = Color.Red;
            }

            if (q3_answer1.Checked || q3_answer2.Checked || q3_answer3.Checked || q3_answer4.Checked)
            {
                status3_label.Text = "Απαντήθηκε";
                status3_label.ForeColor = Color.Green;
            }
            else if (ImportData.finalQuestions[2].QTimeRemaining == 0)
            {
                status3_label.Text = "Τέλος χρόνου";
                status3_label.ForeColor = Color.Gray;
            }
            else
            {
                status3_label.Text = "Δεν απαντήθηκε";
                status3_label.ForeColor = Color.Red;
            }

            if (!String.IsNullOrEmpty(q4_textBox1.Text) || !String.IsNullOrEmpty(q4_textBox2.Text) ||
                !String.IsNullOrEmpty(q4_textBox3.Text) || !String.IsNullOrEmpty(q4_textBox4.Text))
            {
                status4_label.Text = "Απαντήθηκε";
                status4_label.ForeColor = Color.Green;
            }
            else if (ImportData.finalQuestions[3].QTimeRemaining == 0)
            {
                status4_label.Text = "Τέλος χρόνου";
                status4_label.ForeColor = Color.Gray;
            }
            else
            {
                status4_label.Text = "Δεν απαντήθηκε";
                status4_label.ForeColor = Color.Red;
            }
            
            if (!String.IsNullOrEmpty(q5_button1.Text) || !String.IsNullOrEmpty(q5_button2.Text) || !String.IsNullOrEmpty(q5_button3.Text))
            {
                status5_label.Text = "Απαντήθηκε";
                status5_label.ForeColor = Color.Green;
            }
            else if (ImportData.finalQuestions[4].QTimeRemaining == 0)
            {
                status5_label.Text = "Τέλος χρόνου";
                status5_label.ForeColor = Color.Gray;
            }
            else
            {
                status5_label.Text = "Δεν απαντήθηκε";
                status5_label.ForeColor = Color.Red;
            }

            if (!String.IsNullOrEmpty(q6_button1.Text) || !String.IsNullOrEmpty(q6_button2.Text) ||
                !String.IsNullOrEmpty(q6_button3.Text) || !String.IsNullOrEmpty(q6_button4.Text) ||
                !String.IsNullOrEmpty(q6_button5.Text) || !String.IsNullOrEmpty(q6_button6.Text) ||
                !String.IsNullOrEmpty(q6_button7.Text))
            {
                status6_label.Text = "Απαντήθηκε";
                status6_label.ForeColor = Color.Green;
            }
            else if (ImportData.finalQuestions[5].QTimeRemaining == 0)
            {
                status6_label.Text = "Τέλος χρόνου";
                status6_label.ForeColor = Color.Gray;
            }
            else
            {
                status6_label.Text = "Δεν απαντήθηκε";
                status6_label.ForeColor = Color.Red;
            }
        }
    }
}
