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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            int main_form_width = main_form.getWidth;
            int main_form_height = main_form.getHeight;

            this.Size = new Size(main_form_width-200, main_form_height-200);
        }
    }
}
