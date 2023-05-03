using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace LaboratuvarTahlilSonucOtomasyonu
{
    public partial class Sonuclar : Form
    {
        SqlConnection coo = new SqlConnection("Data Source=KEREM\\SQLEXPRESS;Initial Catalog=LaboratuvarOtomasyon;Integrated Security=True");
        //SqlCommandBuilder kom;
        //SqlDataAdapter dat;
        //DataTable tbl = new DataTable();
        
        //public HastaBilgi hasta
        public Sonuclar()
        {
            InitializeComponent();
            
        }

        //DataTable Getlist()
        //{
            //dat = new SqlDataAdapter("Select * from SonucTablo",coo);
            //dat.Fill(tbl);
            //dataGridView1.DataSource = tbl;
            //return tbl;

        //}

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Sonuclar_Load(object sender, EventArgs e)
        {
            textBox1.Text = HastaBilgi.GidenBilgi.ToString();
            label2.Text = HastaBilgi.GidenBilgi2.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            coo.Open();
            SqlCommand kom = new SqlCommand("Select * from SonucTablo where HASTASONUCNO like '%" + textBox1.Text + "%'", coo);
            SqlDataAdapter ada = new SqlDataAdapter(kom);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            coo.Close();
            
            /*if (coo.State == ConnectionState.Open)
            {
                coo.Close();
            }
            coo.Open();
            SqlCommand cek = new SqlCommand("Select * from SonucTablo where HASTASONUCNO like'%" + textBox1.Text + "%'", coo);
            SqlDataReader oku = cek.ExecuteReader();

            while (oku.Read())
            {
                glukoz = Convert.ToInt16(oku["Glukoz"]);
                ure = Convert.ToInt16(oku["Ure"]);
                kreatinin = Convert.ToInt16(oku["Kreatinin"]);
                protein = Convert.ToInt16(oku["Protein"]);
                kalsiyum = Convert.ToInt16(oku["Kalsiyum"]);
                na = Convert.ToInt16(oku["Na(Sodyum)"]);
                k = Convert.ToInt16(oku["K(Potasyum)"]);
                fe = Convert.ToInt16(oku["Fe(Demir)"]);
                cl = Convert.ToInt16(oku["Cl(Klor)"]);
                ggt = Convert.ToInt16(oku["GGT"]);
                ldh = Convert.ToInt16(oku["LDH"]);
                kolesterol = Convert.ToInt16(oku["Kolesterol"]);
                hdlkoles = Convert.ToInt16(oku["HDL Kolesterol"]);
                ldlkoles = Convert.ToInt16(oku["LDL Kolesterol"]);
                vldlkoles = Convert.ToInt16(oku["VLDL Kolesterol"]);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        double glukoz = 0;
        double ure = 0;
        double kreatinin = 0;
        double protein = 0;
        double kalsiyum = 0;
        double na = 0;
        double k = 0;
        double fe = 0;
        double cl = 0;
        double ggt = 0;
        double ldh = 0;
        double kolesterol = 0;
        double hdlkoles = 0;
        double ldlkoles = 0;
        double vldlkoles = 0;
        String glu = "";
        String ur = "";
        String krea = "";
        String pro = "";
        String kalsi = "";
        String NA = "";
        String K = "";
        String FE = "";
        String CL = "";
        String GGT = "";
        String LDH = "";
        String koles = "";
        String HDLKOLES = "";
        String LDLKOLES = "";
        String VLDLKOLES = "";
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            if (coo.State == ConnectionState.Open)
            {
                coo.Close();
            }
            coo.Open();
            SqlCommand cek = new SqlCommand("Select * from SonucTablo where HASTASONUCNO like'%" + textBox1.Text + "%'", coo);
            SqlDataReader oku = cek.ExecuteReader();

            while (oku.Read())
            {
                glukoz = Convert.ToDouble(oku["Glukoz"]);
                ure = Convert.ToDouble(oku["Ure"]);
                kreatinin = Convert.ToDouble(oku["Kreatinin"]);
                protein = Convert.ToDouble(oku["Protein"]);
                kalsiyum = Convert.ToDouble(oku["Kalsiyum"]);
                na = Convert.ToDouble(oku["Na(Sodyum)"]);
                k = Convert.ToDouble(oku["K(Potasyum)"]);
                fe = Convert.ToDouble(oku["Fe(Demir)"]);
                cl = Convert.ToDouble(oku["Cl(Klor)"]);
                ggt = Convert.ToDouble(oku["GGT"]);
                ldh = Convert.ToDouble(oku["LDH"]);
                kolesterol = Convert.ToDouble(oku["Kolesterol"]);
                hdlkoles = Convert.ToDouble(oku["HDL Kolesterol"]);
                ldlkoles = Convert.ToDouble(oku["LDL Kolesterol"]);
                vldlkoles = Convert.ToDouble(oku["VLDL Kolesterol"]);
            }
            if (glukoz > 105)
                glu = "yüksek";
            else if (glukoz < 70)
                glu = "düşük";
            
            if (ure > 45)
                ur = "yüksek";
            else if (ure < 15)
                ur = "düşük";
            
            if (kreatinin > 0.1)
                krea = "yüksek";
            else if (kreatinin < 0.5)
                krea = "düşük";
            
            if (protein > 8.5)
                pro = "yüksek";
            else if (protein < 6.4)
                pro = "düşük";
            
            if (kalsiyum > 10.6)
                kalsi = "yüksek";
            else if (kalsiyum < 8.5)
                kalsi = "düşük";
            
            if (na > 148)
                NA = "yüksek";
            else if (na < 136)
                NA = "düşük"; 
            
            if (k > 5.2)
                K = "yüksek";
            else if (k < 3.5)
                K = "düşük"; 
            
            if (fe > 180)
                FE = "yüksek";
            else if (fe < 60)
                FE = "düşük"; 
            
            if (cl > 112)
                CL = "yüksek";
            else if (cl < 98)
                CL = "düşük";

            if (ggt > 36)
                GGT = "yüksek";
            else if (ggt < 9)
                GGT = "düşük";

            if (ldh > 90)
                LDH = "yüksek";
            else if (ldh < 250)
                LDH = "düşük";

            if (kolesterol > 200)
                koles = "yüksek";
            else if (kolesterol < 0)
                koles = "düşük";

            if (hdlkoles > 300)
                HDLKOLES = "yüksek";
            else if (hdlkoles < -300)
                HDLKOLES = "düşük";

            if (ldlkoles > 130)
                LDLKOLES = "yüksek";
            else if (ldlkoles < 0)
                LDLKOLES = "düşük";

            if (vldlkoles > 30)
                VLDLKOLES = "yüksek";
            else if (vldlkoles < 0)
                VLDLKOLES = "düşük";


            try
                {
                    Font font = new Font("Arial", 14);
                    SolidBrush firca = new SolidBrush(Color.Black);
                    Pen kalem = new Pen(Color.Black);
                    //e.Graphics.

                    font = new Font("Arial", 20, FontStyle.Bold);
                    e.Graphics.DrawString("TIBBI LABORAVUVAR TEKNİK SONUÇ RAPORU", font, firca, 70, 60);
                //e.Graphics.DrawString("**************************", font, firca, 370, 50);
                e.Graphics.DrawLine(kalem, 30, 40, 780, 40);
                e.Graphics.DrawLine(kalem, 30, 100, 780, 100);
                e.Graphics.DrawLine(kalem, 30, 40, 30, 100);
                e.Graphics.DrawLine(kalem, 780, 40, 780, 100);

                


                font = new Font("Arial",15, FontStyle.Bold);
                    e.Graphics.DrawString("Hastanın Adı,Soyadı : ", font, firca, 60, 140);
                    e.Graphics.DrawString("T.C. Kimlik No : ", font, firca, 60, 180);
                    e.Graphics.DrawString("Sonuç No : ", font, firca, 60, 220);
                e.Graphics.DrawString(HastaBilgi.GidenBilgi3.ToString(), font, firca, 375, 180);
                e.Graphics.DrawString(HastaBilgi.GidenBilgi5.ToString(), font, firca, 375, 140);
                e.Graphics.DrawString(HastaBilgi.GidenBilgi.ToString(), font, firca, 375, 220);

                e.Graphics.DrawLine(kalem, 30, 130, 780, 130);
                e.Graphics.DrawLine(kalem, 30, 245, 780, 245);
                e.Graphics.DrawLine(kalem, 30, 130, 30, 245);
                e.Graphics.DrawLine(kalem, 780, 130, 780, 245);

                e.Graphics.DrawLine(kalem, 30, 255, 780, 255);
                e.Graphics.DrawLine(kalem, 30, 290, 780, 290);
                e.Graphics.DrawLine(kalem, 30, 255, 30, 715);
                e.Graphics.DrawLine(kalem, 780, 255, 780, 715);
                //e.Graphics.DrawLine(kalem, 30, 720, 780, 720);

                e.Graphics.DrawLine(kalem, 30, 325, 780, 325);
                e.Graphics.DrawLine(kalem, 30, 355, 780, 355);
                e.Graphics.DrawLine(kalem, 30, 385, 780, 385);
                e.Graphics.DrawLine(kalem, 30, 415, 780, 415);
                e.Graphics.DrawLine(kalem, 30, 445, 780, 445);
                e.Graphics.DrawLine(kalem, 30, 475, 780, 475);
                e.Graphics.DrawLine(kalem, 30, 505, 780, 505);
                e.Graphics.DrawLine(kalem, 30, 535, 780, 535);
                e.Graphics.DrawLine(kalem, 30, 565, 780, 565);
                e.Graphics.DrawLine(kalem, 30, 595, 780, 595);
                e.Graphics.DrawLine(kalem, 30, 625, 780, 625);
                e.Graphics.DrawLine(kalem, 30, 655, 780, 655);
                e.Graphics.DrawLine(kalem, 30, 685, 780, 685);
                e.Graphics.DrawLine(kalem, 30, 715, 780, 715);

                //e.Graphics.DrawString(HastaBilgi.GidenBilgi5.ToString(), font, firca, 130, 140);


                font = new Font("Arial", 14, FontStyle.Bold);
                e.Graphics.DrawString("Tetkik Adı", font, firca, 60, 260);
                e.Graphics.DrawString("Sonuç", font, firca, 250, 260);
                e.Graphics.DrawString("Durum", font, firca, 375, 260);
                e.Graphics.DrawString("Birimi", font, firca, 500, 260);
                e.Graphics.DrawString("Referans Aralığı", font, firca, 610, 260);

                font = new Font("Arial", 12, FontStyle.Regular);

                e.Graphics.DrawString(HastaBilgi.GidenBilgi4.ToString(), font, firca, 30, 10);

                e.Graphics.DrawString("Glukoz", font, firca, 60, 300);
                e.Graphics.DrawString("Ure", font, firca, 60, 330);
                e.Graphics.DrawString("Kreatinin", font, firca, 60, 360);
                e.Graphics.DrawString("Protein", font, firca, 60, 390);
                e.Graphics.DrawString("Na(Sodyum)", font, firca, 60, 420);
                e.Graphics.DrawString("K(Potasyum)", font, firca, 60, 450);
                e.Graphics.DrawString("Fe(Demir)", font, firca, 60, 480);
                e.Graphics.DrawString("Cl(Klor)", font, firca, 60, 510);
                e.Graphics.DrawString("GGT", font, firca, 60, 540);
                e.Graphics.DrawString("LDH", font, firca, 60, 570);
                e.Graphics.DrawString("Kolesterol", font, firca, 60, 600);
                e.Graphics.DrawString("HDL Kolesterol", font, firca, 60, 630);
                e.Graphics.DrawString("LDL Kolesterol", font, firca, 60, 660);
                e.Graphics.DrawString("VLDL Kolesterol", font, firca, 60, 690);

                e.Graphics.DrawString(glukoz.ToString("0.0"), font, firca, 250, 300);
                e.Graphics.DrawString(ure.ToString("0.00"), font, firca, 250, 330);
                e.Graphics.DrawString(kreatinin.ToString("0.00"), font, firca, 250, 360);
                e.Graphics.DrawString(protein.ToString("0.00"), font, firca, 250, 390);
                e.Graphics.DrawString(na.ToString("0.0"), font, firca, 250, 420);
                e.Graphics.DrawString(k.ToString("0.00"), font, firca, 250, 450);
                e.Graphics.DrawString(fe.ToString(), font, firca, 250, 480);
                e.Graphics.DrawString(cl.ToString("0.0"), font, firca, 250, 510);
                e.Graphics.DrawString(ggt.ToString(), font, firca, 250, 540);
                e.Graphics.DrawString(ldh.ToString(), font, firca, 250, 570);
                e.Graphics.DrawString(kolesterol.ToString(), font, firca, 250, 600);
                e.Graphics.DrawString(hdlkoles.ToString(), font, firca, 250, 630);
                e.Graphics.DrawString(ldlkoles.ToString("0.0"), font, firca, 250, 660);
                e.Graphics.DrawString(vldlkoles.ToString("0.0"), font, firca, 250, 690);

                e.Graphics.DrawString(glu, font, firca, 375, 300);
                e.Graphics.DrawString(ur, font, firca, 375, 330);
                e.Graphics.DrawString(krea, font, firca, 375, 360);
                e.Graphics.DrawString(pro, font, firca, 375, 390);
                e.Graphics.DrawString(NA, font, firca, 375, 420);
                e.Graphics.DrawString(K, font, firca, 375, 450);
                e.Graphics.DrawString(FE, font, firca, 375, 480);
                e.Graphics.DrawString(CL, font, firca, 375, 510);
                e.Graphics.DrawString(GGT, font, firca, 375, 540);
                e.Graphics.DrawString(LDH, font, firca, 375, 570);
                e.Graphics.DrawString(koles, font, firca, 375, 600);
                e.Graphics.DrawString(HDLKOLES, font, firca, 375, 630);
                e.Graphics.DrawString(LDLKOLES, font, firca, 375, 660);
                e.Graphics.DrawString(VLDLKOLES, font, firca, 375, 690);

                e.Graphics.DrawString("mg/dL", font, firca, 500, 300);
                e.Graphics.DrawString("mg/dL", font, firca, 500, 330);
                e.Graphics.DrawString("mg/dL", font, firca, 500, 360);
                e.Graphics.DrawString("g/dL", font, firca, 500, 390);
                e.Graphics.DrawString("mmol/L", font, firca, 500, 420);
                e.Graphics.DrawString("mmol/L", font, firca, 500, 450);
                e.Graphics.DrawString("ug/dL", font, firca, 500, 480);
                e.Graphics.DrawString("mmol/L", font, firca, 500, 510);
                e.Graphics.DrawString("U/L", font, firca, 500, 540);
                e.Graphics.DrawString("U/L", font, firca, 500, 570);
                e.Graphics.DrawString("mg/dL", font, firca, 500, 600);
                e.Graphics.DrawString("mg/dL", font, firca, 500, 630);
                e.Graphics.DrawString("mg/dL", font, firca, 500, 660);
                e.Graphics.DrawString("mg/dL", font, firca, 500, 690);

                e.Graphics.DrawString("70-105", font, firca, 660, 300);
                e.Graphics.DrawString("15-45", font, firca, 660, 330);
                e.Graphics.DrawString("0,5-1,1", font, firca, 660, 360);
                e.Graphics.DrawString("6,4-8,5", font, firca, 660, 390);
                e.Graphics.DrawString("136-148", font, firca, 660, 420);
                e.Graphics.DrawString("3,5-5,2", font, firca, 660, 450);
                e.Graphics.DrawString("60-180", font, firca, 660, 480);
                e.Graphics.DrawString("98-112", font, firca, 660, 510);
                e.Graphics.DrawString("9-36", font, firca, 660, 540);
                e.Graphics.DrawString("90-250", font, firca, 660, 570);
                e.Graphics.DrawString("0-200", font, firca, 660, 600);
                e.Graphics.DrawString("-65", font, firca, 660, 630);
                e.Graphics.DrawString("0-130", font, firca, 660, 660);
                e.Graphics.DrawString("0-30", font, firca, 660, 690);




                //e.Graphics.DrawString(cl.ToString(), font, firca, 60, 240);


            }
                catch { }
            
        }
    }
}
