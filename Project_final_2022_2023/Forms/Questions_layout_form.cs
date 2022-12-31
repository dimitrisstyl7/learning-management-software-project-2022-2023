using Project_final_2022_2023.Classes;
using System.Net.Http.Headers;
using System.Text;

namespace Project_final_2022_2023.Forms
{
    public partial class Questions_layout_form : Form
    {
       // public static List<Question> questionList = new();


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


            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;



            //to work on your question set the visibility to true

            panel1.Location = new Point(122,75);
            panel1.Size= new Size(1600,800);
            question1Text_richTextBox.Text = ImportData.finalQuestions[0].QText;

            panel2.Location = new Point(122, 75);
            panel2.Size = new Size(1600, 800);
            
            panel3.Location = new Point(122, 75);
            panel3.Size = new Size(1600, 800);
            

            panel4.Location = new Point(122, 75);
            panel4.Size = new Size(1600, 800);
            

            panel5.Location = new Point(122, 75);
            panel5.Size = new Size(1600, 800);
            

            panel6.Location = new Point(122, 75);
            panel6.Size = new Size(1600, 800);
            
        }
    }
}
