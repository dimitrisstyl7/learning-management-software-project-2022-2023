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

namespace Project_final_2022_2023.Forms
{
    public partial class Results_form : Form
    {
        public Results_form(Questions_form form)
        {
            InitializeComponent();
            form.Dispose();
        }

        private void Results_form_Load(object sender, EventArgs e)
        {
            MessageBox.Show("" + Question.QTotalMarks);
        }
    }
}
