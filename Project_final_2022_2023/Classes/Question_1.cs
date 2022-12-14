using Project_final_2022_2023.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_final_2022_2023.Classes
{
    internal class Question_1 : Questions_layout_form
    {
        Form layout_form;

        public Question_1()
        {
            layout_form = new Questions_layout_form();
            layout_form.ShowDialog();
        }
    }
}
