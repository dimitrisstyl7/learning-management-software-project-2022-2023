using Project_final_2022_2023.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_final_2022_2023.Classes
{
    internal class Question_1 : Questions_layout_form
    {
        private Questions_layout_form layout_form;

        public Question_1(info_form infoForm)
        {
            layout_form = new Questions_layout_form();
            layout_form.getInfoForm(infoForm);
            layout_form.ShowDialog();
        }
    }
}
