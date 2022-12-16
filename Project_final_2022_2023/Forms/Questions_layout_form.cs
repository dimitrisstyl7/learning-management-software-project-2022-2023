using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        private info_form infoForm;
        public Questions_layout_form()
        {
            infoForm = new info_form();
            InitializeComponent();
        }

        public void getInfoForm(info_form infoForm)
        {
            this.infoForm = infoForm;
        }

        private void Questions_layout_form_MouseEnter(object sender, EventArgs e)
        {
            infoForm.Hide();
        }

        private void Questions_layout_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
