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
    public partial class DoktorGirisFormu : Form
    {
        public DoktorGirisFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from tbl_doktorlar where doktortc=@p1 and doktorsifre=@p2", bag.baglanti());
            com.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p2",textBox1.Text);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetayFormu frm = new DoktorDetayFormu();
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
