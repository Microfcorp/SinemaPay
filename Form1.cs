using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace kassabilet
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        string date;
        string vrema;
        string film;
        string fio;
        int id = 0;
        int prodaza;

        string decod;

        string[] values;

        Random rnd = new Random();
        byte[] bytes1 = new byte[100];
        Form2 frm = new Form2();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frm.status("Синема паак приветствует Вас!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date = textBox1.Text;
            vrema = maskedTextBox1.Text;
            film = textBox2.Text;
            fio = textBox3.Text;
            id = id + 1;
            rnd.NextBytes(bytes1);
            prodaza += 50;
            int zagadk = bytes1.GetLowerBound(0);
            int poluz = zagadk + 5 - 3 * 2;
            values = new string[] { zagadk.ToString(), " ", poluz.ToString(), "  ", date, "  ", vrema, "  ", film, "  ", fio, "  ", id.ToString() };
            peredatdan();
            frm.status("Спасибо за сеанс");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           // monthCalendar1.Visible = true;
           // monthCalendar1.Show();
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.TodayDate.ToShortDateString().ToString();
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString().ToString();            
            //monthCalendar1.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(String.Join("", values)); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            pictureBox1.Image = qrcode as Image;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя, место, в которое он захочет сохранить файл. 
            save.Filter = "PNG|*.png"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
            save.FileName = id.ToString();
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //если пользователь нажимает в обозревателе кнопку "Сохранить".
            {
                pictureBox1.Image.Save(save.FileName); //изображение из pictureBox'a сохраняется под именем, которое введёт пользователь
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void проверкаБилетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void продажаБилетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog(); //  load будет запрашивать у пользователя место, из которого он хочет загрузить файл.
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK) // //если пользователь нажимает в обозревателе кнопку "Открыть".
            {
                pictureBox2.ImageLocation = load.FileName; // в pictureBox'e открывается файл, который был по пути, запрошенном пользователем.
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder(); // создаём "раскодирование изображения"
            decod = decoder.decode(new QRCodeBitmapImage(pictureBox2.Image as Bitmap));
            label8.Text = decod;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int pre = Convert.ToInt32(maskedTextBox2.Text);
            int vtor = Convert.ToInt32(maskedTextBox3.Text);
            if (pre + 5 - 3 * 2 == vtor) {
                label11.Text = "Билет Подлиный";
            }
            else { label11.Text = "Билет поддельный!!!!!!!"; }
        }

        private void итогиЗаСеансToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label13.Text = prodaza.ToString();
            panel3.Visible = !panel3.Visible;
        }

        private void запуститьИнфометрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.Show();
        }

        public void peredatdan()
        {
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(String.Join("", values)); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            frm.inst("50", "1", date, vrema, film, fio, qrcode);
        }

        private void кассаСвободнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.status("Касса свободна");
        }

        private void кассаНеРаботаетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.status("Касса не работает");
        }

        private void следующийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.status("Следующий");
        }

        private void продажаБилетовЗавершенаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.status("Продажа билетов завершена");
        }

        private void занятоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm.status("Занято");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frm.status("Следующий");
            textBox1.Text = "";
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            frm.inst("", "", "", "", "", "", null);
        }

        private void текстовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void картаЗалаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void картаЗалаToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
