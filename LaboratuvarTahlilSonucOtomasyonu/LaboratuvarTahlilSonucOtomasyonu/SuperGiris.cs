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
    public partial class SuperGiris : Form
    {
        public SuperGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=KEREM\\SQLEXPRESS;Initial Catalog=LaboratuvarOtomasyon;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from SupervisorTablo where SupTC='" + textBox1.Text + "'and SupParola='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                TeknisBilgi tb = new TeknisBilgi();
                this.Hide();
                tb.Show();
            }
            else
            {
                MessageBox.Show("Giriş başarısız");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParolamıUnuttum sc = new ParolamıUnuttum();
            this.Hide();
            sc.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox1.Text = "Gizle";
            }
            else if (checkBox1.CheckState == CheckState.Unchecked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Göster";
            }
        }
    }
}
