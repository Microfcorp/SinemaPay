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
    }
}
