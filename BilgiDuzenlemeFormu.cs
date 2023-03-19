using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randevu_Sistemi_Programi
{
    public partial class BilgiDuzenlemeFormu : Form
    {
        public BilgiDuzenlemeFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();
        private void BilgiDuzenlemeFormu_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from tbl_hasta", bag.baglanti());
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            
            dr.Close();
            bag.baglanti().Close();
            MessageBox.Show("T.C.Kimlik Numarası Değiştirilemez! Güncelleme işleminde kayıtlarda" +
                " hata olmaması adına şart olarak T.C. Kimlik Numarasını kullanarak istediğiniz bilgileri güncelleyebilirsiniz.");
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("update tbl_hasta set hastaad=@p1,hastasoyad=@p2,hastatelefon=@p3,hastasifre=@p4," +
                "hastacinsiyet=@p5 where hastatc=@p6",bag.baglanti());
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox2.Text);
            com.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            com.Parameters.AddWithValue("@p4", textBox3.Text);
            com.Parameters.AddWithValue("@p5", comboBox1.Text);
            com.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
         
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("select * from tbl_hasta",bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            bag.baglanti().Close();
            
        }
    }
}
