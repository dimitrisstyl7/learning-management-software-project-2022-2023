namespace Project_final_2022_2023.Forms
{
    partial class Questions_layout_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Questions_layout_form));
            this.left_arrow_pictureBox = new System.Windows.Forms.PictureBox();
            this.refresh_pictureBox = new System.Windows.Forms.PictureBox();
            this.right_arrow_pictureBox = new System.Windows.Forms.PictureBox();
            this.tip_pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.background_panel = new System.Windows.Forms.Panel();
            this.total_time_label = new System.Windows.Forms.Label();
            this.question_time_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.left_arrow_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refresh_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_arrow_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip_pictureBox)).BeginInit();
            this.background_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // left_arrow_pictureBox
            // 
            this.left_arrow_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.left_arrow_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.left_arrow_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("left_arrow_pictureBox.Image")));
            this.left_arrow_pictureBox.Location = new System.Drawing.Point(11, 762);
            this.left_arrow_pictureBox.Name = "left_arrow_pictureBox";
            this.left_arrow_pictureBox.Size = new System.Drawing.Size(94, 87);
            this.left_arrow_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_arrow_pictureBox.TabIndex = 15;
            this.left_arrow_pictureBox.TabStop = false;
            // 
            // refresh_pictureBox
            // 
            this.refresh_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.refresh_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.refresh_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("refresh_pictureBox.Image")));
            this.refresh_pictureBox.Location = new System.Drawing.Point(658, 762);
            this.refresh_pictureBox.Name = "refresh_pictureBox";
            this.refresh_pictureBox.Size = new System.Drawing.Size(94, 87);
            this.refresh_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.refresh_pictureBox.TabIndex = 18;
            this.refresh_pictureBox.TabStop = false;
            // 
            // right_arrow_pictureBox
            // 
            this.right_arrow_pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.right_arrow_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.right_arrow_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("right_arrow_pictureBox.Image")));
            this.right_arrow_pictureBox.Location = new System.Drawing.Point(1737, 762);
            this.right_arrow_pictureBox.Name = "right_arrow_pictureBox";
            this.right_arrow_pictureBox.Size = new System.Drawing.Size(94, 87);
            this.right_arrow_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_arrow_pictureBox.TabIndex = 16;
            this.right_arrow_pictureBox.TabStop = false;
            // 
            // tip_pictureBox
            // 
            this.tip_pictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tip_pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.tip_pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tip_pictureBox.Image")));
            this.tip_pictureBox.Location = new System.Drawing.Point(1154, 762);
            this.tip_pictureBox.Name = "tip_pictureBox";
            this.tip_pictureBox.Size = new System.Drawing.Size(94, 87);
            this.tip_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tip_pictureBox.TabIndex = 17;
            this.tip_pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 31);
            this.label1.TabIndex = 19;
            this.label1.Text = "Συνολικός χρόνος:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 31);
            this.label2.TabIndex = 20;
            this.label2.Text = "Διαθέσιμος χρόνος ερώτησης:";
            // 
            // background_panel
            // 
            this.background_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.background_panel.Controls.Add(this.total_time_label);
            this.background_panel.Controls.Add(this.label1);
            this.background_panel.Controls.Add(this.question_time_label);
            this.background_panel.Controls.Add(this.label2);
            this.background_panel.Location = new System.Drawing.Point(0, 0);
            this.background_panel.Name = "background_panel";
            this.background_panel.Size = new System.Drawing.Size(1843, 663);
            this.background_panel.TabIndex = 21;
            // 
            // total_time_label
            // 
            this.total_time_label.AutoSize = true;
            this.total_time_label.BackColor = System.Drawing.Color.Transparent;
            this.total_time_label.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.total_time_label.Location = new System.Drawing.Point(329, 31);
            this.total_time_label.Name = "total_time_label";
            this.total_time_label.Size = new System.Drawing.Size(62, 31);
            this.total_time_label.TabIndex = 21;
            this.total_time_label.Text = "gfgb";
            // 
            // question_time_label
            // 
            this.question_time_label.AutoSize = true;
            this.question_time_label.BackColor = System.Drawing.Color.Transparent;
            this.question_time_label.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.question_time_label.Location = new System.Drawing.Point(329, 0);
            this.question_time_label.Name = "question_time_label";
            this.question_time_label.Size = new System.Drawing.Size(80, 31);
            this.question_time_label.TabIndex = 21;
            this.question_time_label.Text = "gtfgtf";
            // 
            // Questions_layout_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1843, 860);
            this.Controls.Add(this.background_panel);
            this.Controls.Add(this.left_arrow_pictureBox);
            this.Controls.Add(this.refresh_pictureBox);
            this.Controls.Add(this.right_arrow_pictureBox);
            this.Controls.Add(this.tip_pictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Questions_layout_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ερωτηματολόγιο";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Questions_layout_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.left_arrow_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refresh_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_arrow_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tip_pictureBox)).EndInit();
            this.background_panel.ResumeLayout(false);
            this.background_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox left_arrow_pictureBox;
        private PictureBox refresh_pictureBox;
        private PictureBox right_arrow_pictureBox;
        private PictureBox tip_pictureBox;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Panel background_panel;
        private Label question_time_label;
        private Label total_time_label;
    }
}