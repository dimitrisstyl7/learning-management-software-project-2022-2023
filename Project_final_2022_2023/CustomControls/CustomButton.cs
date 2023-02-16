using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Dimitris Stylianou P20004, Theodoros Koxanoglou P20094, Panagiota Nicolaou P20009, Rafaela Karapetsa-Lazaridou P20078, Sotiris Chatzikyriakou P20011

namespace Project_final_2022_2023.CustomControls
{
    public partial class CustomButton : Button
    {

        private int cornerRadius = 20;

        public CustomButton()
        {
            InitializeComponent();
        }
        

        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                Invalidate(); // Force the button to be repainted
            }
        }
        //Dimitris Stylianou P20004, Theodoros Koxanoglou P20094, Panagiota Nicolaou P20009, Rafaela Karapetsa-Lazaridou P20078, Sotiris Chatzikyriakou P20011

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            graphicsPath.AddArc(rectangle.X + rectangle.Width - cornerRadius, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            graphicsPath.CloseFigure();

            Region = new Region(graphicsPath);
            base.OnPaint(e);
        }
    }
}
