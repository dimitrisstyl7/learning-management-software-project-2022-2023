using Microsoft.Office.Interop.Excel;
using Project_final_2022_2023.Classes;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using Point = System.Drawing.Point;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_form : Form
    {
        private int qNumber; //it keeps the question that is running right now
        private int tm, ts; //totalTimer -> tm = minutes and ts = seconds
        private int qm, qs; //questionTimer -> qm = minutes and qs = seconds
        private Panel currentPanel;
        private bool[] gotHelp;
        public Questions_form(Info_form form)
        {
            InitializeComponent();
            form.Dispose();
            qNumber = 1; //start from question1
            gotHelp = new bool[] { false, false, false, false, false, false }; // true if question[i] got help.
            currentPanel = panel1;
        }

        private void Questions_layout_form_Load(object sender, EventArgs e)
        {
            //center the panel
            this.FormBorderStyle = FormBorderStyle.None;
            int width = this.Width / 2 - background_panel.Width / 2;
            int height = this.Height / 2 - background_panel.Height / 2;
            background_panel.Location = new Point(width, height);
            backgroundFormDesign.Location = new Point(width - 50, height - 50);
            backgroundQuestionDesign.Size = new Size(1650, 820);
            backgroundQuestionDesign.Location = new Point(122 - 20, 75 - 10);
            FillData(); //Fill panels data
            CreateTotalTimer();
            CreateQuestionTimer();
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
            totalTimer.Start();
        }

        private void CreateQuestionTimer()
        {
            int qTimeRemaining = ImportData.finalQuestions[qNumber - 1].QTimeRemaining;
            if (qTimeRemaining != 0)
            {
                qm = qTimeRemaining / 60;  //minutes
                qs = qTimeRemaining % 60;  //seconds
                questionTimer.Enabled = true;
            }
            else
            {
                questionTimer.Enabled = false;
                questionTimeTimer_Label.Text = "-";
                qm = 0;
                qs = 0;
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

        private void Q1_appear_label_Click(object sender, EventArgs e)
        {
            questionTime_label.Visible = true;
            questionTimeTimer_Label.Visible = true;
            questionTimer.Enabled = true;
            panel1.Visible = true;
            q_panel.Visible = false;
            qNumber = 1;
            UnhidePanelButtons();
        }

        private void Q2_appear_label_Click(object sender, EventArgs e)
        {
            questionTime_label.Visible = true;
            questionTimeTimer_Label.Visible = true;
            questionTimer.Enabled = true;
            panel2.Visible = true;
            q_panel.Visible = false;
            qNumber = 2;
            UnhidePanelButtons();
        }

        private void Q3_appear_label_Click(object sender, EventArgs e)
        {
            questionTime_label.Visible = true;
            questionTimeTimer_Label.Visible = true;
            questionTimer.Enabled = true;
            panel3.Visible = true;
            q_panel.Visible = false;
            qNumber = 3;
            UnhidePanelButtons();
        }

        private void Q4_appear_label_Click(object sender, EventArgs e)
        {
            questionTime_label.Visible = true;
            questionTimeTimer_Label.Visible = true;
            questionTimer.Enabled = true;
            panel4.Visible = true;
            q_panel.Visible = false;
            qNumber = 4;
            UnhidePanelButtons();
        }

        private void Q5_appear_label_Click(object sender, EventArgs e)
        {
            questionTime_label.Visible = true;
            questionTimeTimer_Label.Visible = true;
            questionTimer.Enabled = true;
            panel5.Visible = true;
            q_panel.Visible = false;
            qNumber = 5;
            UnhidePanelButtons();
        }

        private void Q6_appear_label_Click(object sender, EventArgs e)
        {
            questionTime_label.Visible = true;
            questionTimeTimer_Label.Visible = true;
            questionTimer.Enabled = true;
            panel6.Visible = true;
            q_panel.Visible = false;
            qNumber = 6;
            UnhidePanelButtons();
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
                questionTimer.Stop();
                totalTimeTimer_label.Text = "Τέλος Χρόνου";
                //ADD CODE HERE
            }
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
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
                questionTimer.Enabled = false;
                questionTimeTimer_Label.Text = "Τέλος Χρόνου";
                currentPanel.Enabled = false; //Disable the current panel.
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

            //align q_panel to center, change size
            q_panel.Location = new Point(122, 75);
            q_panel.Size = new Size(1600, 800);

            //align panel 1 to center, change size
            panel1.Location = new Point(122, 75);
            panel1.Size = new Size(1600, 800);
            question1Text_richTextBox.Text = ImportData.finalQuestions[0].QText;
            q1_QTip_RichTextBox.Text = ImportData.finalQuestions[0].QTip;

            //align panel2 to center, change size
            panel2.Location = new Point(122, 75);
            panel2.Size = new Size(1600, 800);

            //import data
            question2Text_richTextBox.Text = ImportData.finalQuestions[1].QText;
            var data1 = ImportData.finalQuestions[1].QAnswers[0];
            q2_answer1.Text = data1[0];
            q2_answer2.Text = data1[1];
            q2_answer3.Text = data1[2];
            q2_answer4.Text = data1[3];

            //align panel3 to center, change size
            panel3.Location = new Point(122, 75);
            panel3.Size = new Size(1600, 800);

            //import data
            question3_richTextBox.Text = ImportData.finalQuestions[2].QText;
            var data2 = ImportData.finalQuestions[2].QAnswers[0];
            q3_answer1.Text = data2[0];
            q3_answer2.Text = data2[1];
            q3_answer3.Text = data2[2];
            q3_answer4.Text = data2[3];

            //align panel4 to center, change size
            panel4.Location = new Point(122, 75);
            panel4.Size = new Size(1600, 800);

            //import data
            question4_richTextBox.Text = ImportData.finalQuestions[3].QText;
            var data3 = ImportData.finalQuestions[3].QAnswers[0];
            q4_label1.Text = data3[0];
            q4_label2.Text = data3[1];
            q4_label3.Text = data3[2];
            q4_label4.Text = data3[3];
            string q4_QTip = ImportData.finalQuestions[3].QTip;

            if (q4_QTip.EndsWith("path"))
            {
                q4_QTip_RichTextBox.Visible = false;
                q4_QTip_RichTextBox.Text = String.Empty;
                if (q4_QTip.StartsWith("example1"))
                    q4_QTip_PictureBox.Image = Image.FromFile(@"pictures\example1.png");
                else // q4_QTip.StartsWith("example2")
                    q4_QTip_PictureBox.Image = Image.FromFile(@"pictures\example2.png");
            }
            else
                q4_QTip_RichTextBox.Text = q4_QTip;

            //align panel5 to center, change size
            panel5.Location = new Point(122, 75);
            panel5.Size = new Size(1600, 800);

            //import data
            question5_richTextBox.Text = ImportData.finalQuestions[4].QText;
            var colA = ImportData.finalQuestions[4].QAnswers[0];
            var colB = ImportData.finalQuestions[4].QAnswers[1];
            q5_QTip_RichTextBox.Text = ImportData.finalQuestions[4].QTip;

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
            q6_QTip_RichTextBox.Text = ImportData.finalQuestions[5].QTip;

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
                q6_label1.Cursor = Cursors.SizeAll;
                q6_label2.Cursor = Cursors.SizeAll;
                q6_label3.Cursor = Cursors.SizeAll;
                q6_label4.Cursor = Cursors.SizeAll;
                q6_label9.Cursor = Cursors.SizeAll;
                q6_label10.Cursor = Cursors.SizeAll;
                q6_label11.Cursor = Cursors.SizeAll;
            }
        }

        private void HidePanelButtons()
        {
            left_arrow_pictureBox.Visible = false;
            right_arrow_pictureBox.Visible = false;
            tip_pictureBox.Visible = false;
            refresh_pictureBox.Visible = false;
        }

        private void Tip_pictureBox_Click(object sender, EventArgs e)
        {
            switch (qNumber)
            {
                case 1:
                    gotHelp[0] = true;
                    q1_QTip_RichTextBox.Visible = true;
                    break;
                case 2:
                    gotHelp[1] = true;
                    HideAvailableChoiceQ2(ImportData.finalQuestions[1].QTip);
                    break;
                case 3:
                    gotHelp[2] = true;
                    HideAvailableChoiceQ3(ImportData.finalQuestions[2].QTip);
                    break;
                case 4:
                    gotHelp[3] = true;
                    if (String.IsNullOrEmpty(q4_QTip_RichTextBox.Text))
                        q4_QTip_PictureBox.Visible = true;
                    else
                        q4_QTip_RichTextBox.Visible = true;
                    break;
                case 5:
                    gotHelp[4] = true;
                    if (q5_QTip_RichTextBox.Text.Equals("Μέτρησε τις γωνιές."))
                        q5_QTip_RichTextBox.Visible = true;
                    else if (q5_QTip_RichTextBox.Text.Equals("Θεώρημα"))
                        q5_button1.Text = q5_QTip_RichTextBox.Text;
                    else // q5_QTip_RichTextBox.Text.Equals("15 + 12")
                        q5_button3.Text = q5_QTip_RichTextBox.Text;
                    break;
                case 6:
                    gotHelp[5] = true;
                    if (q6_QTip_RichTextBox.Text.Equals("x"))
                        q6_button1.Text = q6_QTip_RichTextBox.Text;
                    else
                        q6_QTip_RichTextBox.Visible = true;
                    break;

            }
        }

        private void HideAvailableChoiceQ2(string hideAnswer)
        {
            switch (hideAnswer)
            {
                case "2":
                    q2_answer2.Visible = false;
                    break;
                case "3":
                    q2_answer3.Visible = false;
                    break;
                case "4":
                    q2_answer4.Visible = false;
                    break;
            }
        }

        private void HideAvailableChoiceQ3(string hideAnswer)
        {
            switch (hideAnswer)
            {
                case "2":
                    q3_answer2.Visible = false;
                    break;
                case "3":
                    q3_answer3.Visible = false;
                    break;
                case "4":
                    q3_answer4.Visible = false;
                    break;
            }
        }

        private void Results_pictureBox_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CalculateResults();//calculate results
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

        private void CalculateResults()
        {
            int panel_no = 1; //start panel, increase by one in each loop.
            Question.QTotalMarks = 0;
            foreach (var x in ImportData.finalQuestions)
            {
                var QCorrectAns = x.QCorrectAns;
                string student_choice = "-1";
                int counter = 0;
                switch (panel_no++)
                {
                    case 1:
                        if (q1_true.Checked) student_choice = "1";
                        else if (q1_false.Checked) student_choice = "2";

                        if (student_choice.Equals(x.QCorrectAns[0]))
                            if (gotHelp[0])
                                Question.QTotalMarks += 1.0;
                            else
                                Question.QTotalMarks += 2.0;
                        break;

                    case 2:
                        if (q2_answer1.Checked) student_choice = "1";
                        else if (q2_answer2.Checked) student_choice = "2";
                        else if (q2_answer3.Checked) student_choice = "3";
                        else if (q2_answer4.Checked) student_choice = "4";

                        if (student_choice.Equals(x.QCorrectAns[0]))
                            if (gotHelp[1])
                                Question.QTotalMarks += 1.5;
                            else
                                Question.QTotalMarks += 2.0;
                        break;

                    case 3:
                        bool[] choice = new bool[] { q3_answer1.Checked, q3_answer1.Checked,
                                                     q3_answer3.Checked, q3_answer4.Checked};

                        bool matching_one = false, matching_two = false;
                        for (int i = 0; i < choice.Length; i++)
                        {
                            for (int j = i + 1; j < choice.Length; j++)
                            {
                                matching_two = choice[i] && x.QCorrectAns[0].Equals((i + 1).ToString())
                                               && choice[j] && x.QCorrectAns[1].Equals((j + 1).ToString());

                                if (
                                    choice[i] && x.QCorrectAns[0].Equals((i + 1).ToString()) 
                                    || choice[j] && x.QCorrectAns[1].Equals((j + 1).ToString())
                                    )
                                    matching_one = true;
                            }
                            if (matching_two) break;
                        }

                        if (matching_two || matching_one)
                            if (gotHelp[2])
                                if (matching_two)
                                    Question.QTotalMarks += 1.5;
                                else // matching_one with tip
                                    Question.QTotalMarks += 0.5;
                            else if (matching_two)
                                Question.QTotalMarks += 2.0;
                            else // matching one without tip
                                Question.QTotalMarks += 1.0;
                        break;

                    case 4:
                        string[] inputs = new string[] { q4_textBox1.Text, q4_textBox2.Text,
                                                         q4_textBox3.Text, q4_textBox4.Text };

                        for (int i = 0; i < inputs.Length; i++) counter += inputs[i].Equals(x.QCorrectAns[i]) ? 1 : 0;

                        if (counter > 0)
                            if (gotHelp[3])
                                if (counter == 2) Question.QTotalMarks += 0.5;
                                else if (counter == 3) Question.QTotalMarks += 1;
                                else if (counter == 4) Question.QTotalMarks += 1.5;
                                else Question.QTotalMarks += 0.0; // if counter == 1
                            else if (counter == 1) Question.QTotalMarks += 0.5;
                            else if (counter == 2) Question.QTotalMarks += 1.0;
                            else if (counter == 3) Question.QTotalMarks += 1.5;
                            else Question.QTotalMarks += 2.0; // if counter == 4
                        break;

                    case 5:
                        string[] buttons_text1 = new string[] { q5_button1.Text, q5_button2.Text, q5_button3.Text };
                        
                        bool[] choice_is_correct = new bool[] { buttons_text1[0].Equals(q5_label5.Text),
                                                                buttons_text1[1].Equals(q5_label6.Text),
                                                                buttons_text1[2].Equals(q5_label4.Text) };

                        foreach (var b in choice_is_correct) counter += b ? 1 : 0; // count the correct answers.

                        if (counter > 0)
                            if (gotHelp[4])
                                if (counter == 1) Question.QTotalMarks += 0.2;
                                else if (counter == 2) Question.QTotalMarks += 0.9;
                                else Question.QTotalMarks += 1.5;
                            else if (counter == 1) Question.QTotalMarks += 0.7;
                            else if (counter == 2) Question.QTotalMarks += 1.4;
                            else Question.QTotalMarks += 2.0;
                        break;

                    case 6:
                        if (q6_label12.Text.Equals("[Γ]")) // 3rd question of type 6.
                        {
                            string[] buttons_text2 = new string[] { q6_button1.Text, q6_button2.Text, q6_button3.Text, q6_button4.Text,
                                                          q6_button5.Text, q6_button6.Text, q6_button7.Text };
                            for (int i = 0; i < buttons_text2.Length; i++) 
                                counter += buttons_text2[i].Equals(x.QCorrectAns[i]) ? 1 : 0; // count the correct answers.
                        }
                        else if (q6_label15.Text.Equals("[Γ]")) // 2nd question of type 6.
                        {   // count the correct answers
                            counter += q6_button1.Text.Equals(q6_label12.Text) ? 1 : 0; // if button text == '<'.
                            counter += q6_button2.Text.Equals(q6_label13.Text) ? 1 : 0; // if button text == '>'.
                            counter += q6_button3.Text.Equals(q6_label12.Text) ? 1 : 0; // if button text == '<'.
                            counter += q6_button4.Text.Equals(q6_label13.Text) ? 1 : 0; // if button text == '>'.
                        }
                        else // 1st question of type 6.
                        {   // count the correct answers
                            counter += q6_button3.Text.Equals(q6_label15.Text) ? 1 : 0; // if button text == '/'.
                            counter += q6_button1.Text.Equals(q6_label14.Text) ? 1 : 0; // if button text == 'x'.
                            counter += q6_button4.Text.Equals(q6_label13.Text) ? 1 : 0; // if button text == '-'.
                            counter += q6_button2.Text.Equals(q6_label12.Text) ? 1 : 0; // if button text == '+'.
                        }

                        if (counter > 0)
                            if (gotHelp[5])
                                if (q6_label12.Text.Equals("[Γ]")) // 3rd question of type 6, with tip.
                                    if (counter == 2) Question.QTotalMarks += 0.1;
                                    else if (counter == 3) Question.QTotalMarks += 0.4;
                                    else if (counter == 4) Question.QTotalMarks += 0.7;
                                    else if (counter == 5) Question.QTotalMarks += 1.0;
                                    else if (counter == 6) Question.QTotalMarks += 1.3;
                                    else if (counter == 7) Question.QTotalMarks += 1.5;
                                    else Question.QTotalMarks += 0.0; // if counter < 2
                                else // 1st or 2nd question of type 6, with tip.
                                    if (counter == 2) Question.QTotalMarks += 0.5;
                                    else if (counter == 3) Question.QTotalMarks += 1.0;
                                    else if (counter == 4) Question.QTotalMarks += 1.5;
                                    else Question.QTotalMarks += 0.0; // if counter == 1
                            else if (q6_label12.Text.Equals("[Γ]")) // 3rd question of type 6, without tip.
                                if (counter == 1) Question.QTotalMarks += 0.3;
                                else if (counter == 2) Question.QTotalMarks += 0.6;
                                else if (counter == 3) Question.QTotalMarks += 0.9;
                                else if (counter == 4) Question.QTotalMarks += 1.2;
                                else if (counter == 5) Question.QTotalMarks += 1.5;
                                else if (counter == 6) Question.QTotalMarks += 1.8;
                                else Question.QTotalMarks += 2.0; // if counter == 7
                            else // 1st or 2nd question of type 6, without tip.
                                if (counter == 1) Question.QTotalMarks += 0.5;
                                else if (counter == 2) Question.QTotalMarks += 1.0;
                                else if (counter == 3) Question.QTotalMarks += 1.5;
                                else Question.QTotalMarks += 2.0; // if counter == 4
                        break;
                }
            }
        }
    }
}
