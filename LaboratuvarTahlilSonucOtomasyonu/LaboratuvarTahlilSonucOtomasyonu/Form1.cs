using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LaboratuvarTahlilSonucOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParolamıUnuttum sc = new ParolamıUnuttum();
            this.Hide();
            sc.Show();

           
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KEREM\\SQLEXPRESS;Initial Catalog=LaboratuvarOtomasyon;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from TeknisyenTablo where TekTC='"+textBox1.Text+ "'and TekParola='"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                // SqlDataAdapter sda = new SqlDataAdapter("select * from TeknisyenTablo where TEKTC='" + textBox1.Text + "'and TEKPAROLA='" + textBox2.Text + "'", con);
                //MessageBox.Show("Giriş başarlı");
                HastaBilgi hb = new HastaBilgi();
                this.Hide();
                hb.Show();
            }
            else
            {
                MessageBox.Show("Giriş başarısız");
            }

            /*HastaBilgi hb = new HastaBilgi();
            this.Hide();
            hb.Show();*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if(checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
