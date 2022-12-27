using Project_final_2022_2023.Classes;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
        public Questions_layout_form(Info_form form)
        {
            InitializeComponent();
            form.Dispose();
        }



        private void Questions_layout_form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            int width = this.Width / 2 - background_panel.Width / 2;
            int height = this.Height / 2 - background_panel.Height / 2;
            background_panel.Location = new Point(width, height);

            panel1.Location = new Point(122,75);
            panel1.Size= new Size(1600,800);
        }
    }
}
