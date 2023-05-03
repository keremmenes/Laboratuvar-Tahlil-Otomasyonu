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
using System.Data.Sql;
using System.Data.SqlClient;

namespace LaboratuvarTahlilSonucOtomasyonu
{
    public partial class ParolaSıfırla : Form
    {
        String TEKMAIL = ParolamıUnuttum.to;

        public ParolaSıfırla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=KEREM\\SQLEXPRESS;Initial Catalog=LaboratuvarOtomasyon;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[TeknisyenTablo] SET [TekParola] = '" + textBox2.Text + "' WHERE Tekmail = '" + TEKMAIL + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Parola sıfırlama başarılı");
            }
            else
            {
                MessageBox.Show("Yeni parola oluşturulamadı");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();

        }

        private void ParolaSıfırla_Load(object sender, EventArgs e)
        {

        }
    }
}
