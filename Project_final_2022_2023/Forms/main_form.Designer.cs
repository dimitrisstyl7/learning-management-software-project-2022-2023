namespace Project_final_2022_2023
{
    partial class Main_form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));
            this.start_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start_button.Location = new System.Drawing.Point(818, 341);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(120, 45);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Έναρξη";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // exit_button
            // 
            this.exit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_button.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exit_button.Location = new System.Drawing.Point(818, 419);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(120, 45);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Έξοδος";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.BackColor = System.Drawing.Color.Transparent;
            this.title_label.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title_label.Location = new System.Drawing.Point(494, 165);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(1371, 135);
            this.title_label.TabIndex = 2;
            this.title_label.Text = "Ερωτηματολόγιο Μαθηματικών";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1776, 887);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.start_button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ερωτηματολόγιο Μαθηματικών";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button start_button;
        private Button exit_button;
        private Label title_label;
    }
}