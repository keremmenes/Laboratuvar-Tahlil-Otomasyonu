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
    public partial class HastaBilgi : Form
    {
        public static String GidenBilgi = "";
        public static String GidenBilgi2 = "";
        public static String GidenBilgi3 = "";
        public static String GidenBilgi4 = "";
        public static String GidenBilgi5 = "";
        public HastaBilgi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=KEREM\\SQLEXPRESS;Initial Catalog=LaboratuvarOtomasyon;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from HastaTablo", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["HASTASONUCNO"].ToString();
                ekle.SubItems.Add(oku["HASTAAD"].ToString());
                ekle.SubItems.Add(oku["HASTATC"].ToString());
                ekle.SubItems.Add(oku["HASTATARIH"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }
        /*private void sonuclarıgoster()
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from SonucTablo", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["HASTATC"].ToString();
                ekle.SubItems.Add(oku["Glukoz"].ToString());
                ekle.SubItems.Add(oku["Ure"].ToString());
                ekle.SubItems.Add(oku["Kreatinin"].ToString());
                ekle.SubItems.Add(oku["Protein"].ToString());
                ekle.SubItems.Add(oku["Kalsiyum"].ToString());
                ekle.SubItems.Add(oku["Na(Sodyum)"].ToString());
                ekle.SubItems.Add(oku["K(Potasyum)"].ToString());
                ekle.SubItems.Add(oku["Cl(Klor)"].ToString());
                ekle.SubItems.Add(oku["GGT"].ToString());
                ekle.SubItems.Add(oku["LDH"].ToString());
                ekle.SubItems.Add(oku["Kolesterol"].ToString());
                ekle.SubItems.Add(oku["HDL Kolesterol"].ToString());
                ekle.SubItems.Add(oku["LDL Kolesterol"].ToString());
                ekle.SubItems.Add(oku["VLDL Kolesterol"].ToString());

                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }*/
        private void HastaBilgi_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verilerigoster();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }
        int id = 0;
        private void Hastabilgi_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from HastaTablo where HASTASONUCNO like'%" + textBox1.Text + "%'and HASTAAD like '%" + textBox2.Text + "%'and HASTATC like '%" + textBox3.Text + "%'and HASTATARIH like '%" + textBox4.Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["HASTASONUCNO"].ToString();
                ekle.SubItems.Add(oku["HASTAAD"].ToString());
                ekle.SubItems.Add(oku["HASTATC"].ToString());
                ekle.SubItems.Add(oku["HASTATARIH"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        { 
            GidenBilgi = textBox1.Text;
            GidenBilgi2 = textBox2.Text + " " + textBox4.Text + " Tarihli sonucu";
            GidenBilgi3 = textBox3.Text;
            GidenBilgi4 = textBox4.Text;
            GidenBilgi5 = textBox2.Text;
        Sonuclar son = new Sonuclar();
            this.Hide();
            son.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
