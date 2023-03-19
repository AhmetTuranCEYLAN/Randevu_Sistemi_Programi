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

namespace Randevu_Sistemi_Programi
{
    public partial class HastaFormu : Form
    {
        public HastaFormu()
        {
            InitializeComponent();
        }

        OrtakBaglanti bag = new OrtakBaglanti();
      

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayitFormu frm = new HastaKayitFormu();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand com = new SqlCommand("select hastatc,hastasifre from tbl_hasta where hastatc=@p1 and hastasifre=@p2", bag.baglanti());
            com.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = com.ExecuteReader();

         
            if (dr.Read())
              
            {
                HastaDetayFormu frm = new HastaDetayFormu();  
                frm.tc = maskedTextBox1.Text; 
                frm.Show();
                   
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı T.C. ve Şifre Girdiniz" + "\n" + "Hatalı T.C. veya Şifre Girdiniz");
            }

                



            dr.Close();
            bag.baglanti().Close();
        }
    }
}
