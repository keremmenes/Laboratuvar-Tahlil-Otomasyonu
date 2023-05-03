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
using System.Data.Sql;

namespace LaboratuvarTahlilSonucOtomasyonu
{
    public partial class TeknisBilgi : Form
    {
        public TeknisBilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=KEREM\\SQLEXPRESS;Initial Catalog=LaboratuvarOtomasyon;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }
        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TeknisyenTablo", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["TekTC"].ToString();
                ekle.SubItems.Add(oku["Tekad"].ToString());
                ekle.SubItems.Add(oku["TekParola"].ToString());
                ekle.SubItems.Add(oku["TekGorev"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }
        long id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = long.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TeknisyenTablo (TekTC,Tekad,TekParola,TekGorev) values(@TekTC,@Tekad,@TekParola,@TekGorev)", baglanti);
            komut.Parameters.AddWithValue("@TekTC",textBox1.Text);
            komut.Parameters.AddWithValue("@Tekad", textBox2.Text);
            komut.Parameters.AddWithValue("@TekParola", textBox3.Text);
            komut.Parameters.AddWithValue("@TekGorev", textBox4.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni Teknisyen eklendi");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TeknisyenTablo where TekTC like'%" + textBox1.Text + "%'and TEKad like '%" + textBox2.Text + "%'and TekParola like '%" + textBox3.Text + "%'and TekGorev like '%" + textBox4.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["TekTC"].ToString();
                ekle.SubItems.Add(oku["Tekad"].ToString());
                ekle.SubItems.Add(oku["TekParola"].ToString());
                ekle.SubItems.Add(oku["TekGorev"].ToString());

                
                listView1.Items.Add(ekle);
                
            }
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("uptade * from TeknisyenTablo set TekTC = '"+ textBox1.Text + "'Tekad ='"+ textBox2.Text + "'TekParola ='" + textBox3.Text + "'TekGorev ='" + textBox4.Text + "", baglanti);
        }
    }
}
