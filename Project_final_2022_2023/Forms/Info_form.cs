using Project_final_2022_2023.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

            //set the position of the panel
            info_panel.Location = new Point(this.Width / 2 - info_panel.Width/2, this.Height / 2 - info_panel.Height/2);
        }

        private void cancel_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        private void cancel_pictureBox_MouseHover(object sender, EventArgs e)
        {
            cancel_pictureBox.Cursor = Cursors.Hand;
            
        }

        private void start_pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void start_pictureBox_MouseHover(object sender, EventArgs e)
        {
            start_pictureBox.Cursor = Cursors.Hand;
        }

        public void closeForm()
        {
            this.Close();
        }
    }
}
