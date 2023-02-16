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
            this.title_label = new System.Windows.Forms.Label();
            this.start_button = new Project_final_2022_2023.CustomControls.CustomButton();
            this.exit_button = new Project_final_2022_2023.CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.BackColor = System.Drawing.Color.Transparent;
            this.title_label.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.title_label.ForeColor = System.Drawing.Color.White;
            this.title_label.Location = new System.Drawing.Point(91, 66);
            this.title_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(935, 90);
            this.title_label.TabIndex = 2;
            this.title_label.Text = "Ερωτηματολόγιο Μαθηματικών";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.ForestGreen;
            this.start_button.CornerRadius = 60;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.start_button.ForeColor = System.Drawing.Color.White;
            this.start_button.Location = new System.Drawing.Point(370, 201);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(155, 60);
            this.start_button.TabIndex = 3;
            this.start_button.Text = "Έναρξη";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.OrangeRed;
            this.exit_button.CornerRadius = 60;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exit_button.ForeColor = System.Drawing.Color.White;
            this.exit_button.Location = new System.Drawing.Point(568, 201);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(155, 60);
            this.exit_button.TabIndex = 4;
            this.exit_button.Text = "Έξοδος";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(95)))), ((int)(((byte)(131)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 419);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.title_label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ερωτηματολόγιο Μαθηματικών";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label title_label;
        private CustomControls.CustomButton start_button;
        private CustomControls.CustomButton exit_button;
    }
}