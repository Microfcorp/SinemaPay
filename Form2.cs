using kassabilet.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kassabilet
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        virtual public void inst(string st, string mest, string date, string vrm, string film, string fio, Image img)
        {
            label3.Text = st + "p";
            label4.Text = mest;
            label7.Text = date;
            label9.Text = vrm;
            label11.Text = film;
            label13.Text = fio;
            pictureBox1.Image = img as Image;
        }
        virtual public void defoult()
        {
            label3.Text = "Нет";
            label4.Text = "Нет";
            label7.Text = "Нет";
            label9.Text = "Нет";
            label11.Text = "Нет";
            label13.Text = "Нет";
        }
        virtual public void status(string st)
        {
            label1.Text = st;
        }
        const int weight = 43;
        const int height = 39;
        Graphics pc = null;
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            pc = e.Graphics;
            Pen pen = new Pen(Color.Red, 3);
           // pc.DrawRectangle(pen, new Rectangle(310,205,weight,height));
           // pc.DrawRectangle(pen, new Rectangle(354, 246, weight, height));
           // pc.DrawRectangle(pen, new Rectangle(393, 246, weight, height));
            //pc.DrawRectangle(pen, new Rectangle(436, 246, weight, height));
            //pc.DrawRectangle(pen, new Rectangle(479, 245, weight, height));
            //pc.DrawRectangle(pen, new Rectangle(521, 246, weight, height));
            //pc.DrawRectangle(pen, new Rectangle(563, 204, weight, height));
            //pc.DrawRectangle(pen, new Rectangle(565, 53, weight, height));
            //pc.DrawRectangle(pen, new Rectangle(565, 89, weight, height));
        }

        virtual public void SelectMesto(int id)
        {          
            pc = pictureBox3.CreateGraphics();
            pc.Clear(Color.FromArgb(0,Color.Black));
            pc.DrawImage(Resources.Безымянный as Bitmap,0,0,pictureBox3.Size.Width, pictureBox3.Size.Height);

            Pen pen = new Pen(Color.Red, 3);
            if ((Room)id == Room.Ряд2Место1)
            {
                pc.DrawRectangle(pen, new Rectangle(565, 89, weight, height));
            }
            if ((Room)id == Room.Ряд1Место1)
            {
                pc.DrawRectangle(pen, new Rectangle(565, 53, weight, height));
            }
            if ((Room)id == Room.Ряд3Место2)
            {
                pc.DrawRectangle(pen, new Rectangle(563, 204, weight, height));
            }
            if ((Room)id == Room.Ряд3Место1)
            {
                pc.DrawRectangle(pen, new Rectangle(310, 205, weight, height));
            }
            if ((Room)id == Room.Ряд4Место1)
            {
                pc.DrawRectangle(pen, new Rectangle(354, 246, weight, height));
            }
            if ((Room)id == Room.Ряд4Место2)
            {
                pc.DrawRectangle(pen, new Rectangle(393, 246, weight, height));
            }
            if ((Room)id == Room.Ряд4Место3)
            {
                pc.DrawRectangle(pen, new Rectangle(436, 246, weight, height));
            }
            if ((Room)id == Room.Ряд4Место4)
            {
                pc.DrawRectangle(pen, new Rectangle(479, 245, weight, height));
            }
            if ((Room)id == Room.Ряд4Место5)
            {
                pc.DrawRectangle(pen, new Rectangle(521, 246, weight, height));
            }
        }

        public enum Room
        {
            Ряд1Место1 = 0,
            Ряд2Место1 = 1,
            Ряд3Место1 = 2,
            Ряд3Место2 = 3,
            Ряд4Место1 = 4,
            Ряд4Место2 = 5,
            Ряд4Место3 = 6,
            Ряд4Место4 = 7,
            Ряд4Место5 = 8,
        }

        virtual public void RezimRaboti(int status)
        {        
                if(1 == status) { panel1.Visible = true; }
                if (2 == status) { panel1.Visible = false ; }          
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("X= " + e.X.ToString() + " Y= " + e.Y.ToString());
        }
    }
}
