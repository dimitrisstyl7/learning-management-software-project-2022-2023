using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_final_2022_2023
{
    public partial class info_form : Form
    {
        public info_form()
        {
            InitializeComponent();
        }

        private void info_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            int info_panel_x = this.Width / 2 + this.Width / 4;
            int info_panel_y = this.Height / 2 + this.Width / 4;

            //info_panel.Size = new Size(info_panel_width, info_panel_height);
            info_panel.Location = new Point(this.Width / 2 - info_panel.Width/2, this.Height / 2 - info_panel.Height/2);
            //info_richTextBox.Size = new Size(info_panel_width / 2, info_panel_height);
            //info_richTextBox.Location = new Point(info_panel_width / 2, 0);
            //start_pictureBox.BringToFront();
        }

        private void cancel_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void cancel_pictureBox_MouseHover(object sender, EventArgs e)
        {
            cancel_pictureBox.Cursor = Cursors.Hand;
            
        }

        private void start_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //////////////////////
        }

        private void start_pictureBox_MouseHover(object sender, EventArgs e)
        {
            start_pictureBox.Cursor = Cursors.Hand;
        }
    }
}
