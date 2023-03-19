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
    public partial class HastaKayitFormu : Form
    {
        public HastaKayitFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();

        private void HastaKayitFormu_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("insert into tbl_hasta(hastaad,hastasoyad,hastatc,hastatelefon,hastasifre,hastacinsiyet) " +
                "values(@p1,@p2,@p3,@p4,@p5,@p6)", bag.baglanti());
            com.Parameters.AddWithValue("@p1",textBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox2.Text);
            com.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            com.Parameters.AddWithValue("@p5", textBox3.Text);
            com.Parameters.AddWithValue("@p6", comboBox1.Text);
           
            com.ExecuteNonQuery();
            bag.baglanti().Close();
            MessageBox.Show("Kaydınız Başarıyla Gerçekleşmiştir"+"\n"+"Şifreniz:"+textBox3.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            

        }
    }
}
