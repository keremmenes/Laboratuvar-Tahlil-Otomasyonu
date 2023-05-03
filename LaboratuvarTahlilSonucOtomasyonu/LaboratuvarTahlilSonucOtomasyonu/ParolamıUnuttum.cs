using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace LaboratuvarTahlilSonucOtomasyonu
{
    public partial class ParolamıUnuttum : Form
    {
        String randomCode;
        public static String to;

        public ParolamıUnuttum()
        {
            InitializeComponent();
        }

        private void ParolamıUnuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(9999)).ToString();
            MailMessage message = new MailMessage();
            to = (textBox2.Text).ToString();
            from = "keremeneskaradas@gmail.com";
            pass = "44Kerem06";
            messageBody = "sıfırlama kodunuz " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "şifre sıfırlama kodu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Gönderim başarılı");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
           /* sqlbaglanti bgln = new sqlbaglanti();
            SqlCommand komut = new SqlCommand("Select * From TeknisyenTablo Where TEKTC='" + textBox1.Text.ToString()
                +"'and TEKMAIL='" + textBox2.Text.ToString()+"'",bgln.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresin = ("keremeneskaradas@gmail.com");
                    String sifre = ("44Kerem06");
                    String smptsrvr = "smpt@gmail.com";
                    String kime = (oku["TEKMAIL"].ToString());
                    String konu = ("Şifre Hatırlatma Maili");
                    String yaz = ("Sayın," + oku["TEKAD"].ToString() + "\n" + tarih + "tarihinde parolama" +
                        "sıfırlama talep etttiniz " + "\n" + oku["TEKPAROLA"].ToString());
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Parolanız mail adresinize gönderilmiştir");
                    this.Hide();


                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Mail gönderme hatası",Hata.Message);
                }
                
            }*/
         }

        private void button2_Click(object sender, EventArgs e)
        {
            if (randomCode == (textBox1.Text).ToString())
            {
                to = textBox2.Text;
                ParolaSıfırla rp = new ParolaSıfırla();
                this.Hide();
                rp.Show();

            }
            else
            {
                MessageBox.Show("Girilen kod yanlış");
            }
        }
    }
}
