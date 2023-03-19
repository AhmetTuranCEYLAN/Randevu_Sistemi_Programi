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
    public partial class DoktorBilgiDuzenlemeFormu : Form
    {
        public DoktorBilgiDuzenlemeFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();
        public string tc;

        private void DoktorBilgiDuzenlemeFormu_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tc;
            
            SqlCommand com = new SqlCommand("select bransad from tbl_branslar", bag.baglanti());
            //com.Parameters.AddWithValue("@p1", comboBox2.Text);

            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "bransad";

            SqlCommand com2 = new SqlCommand("select doktorad, doktorsoyad,doktorsifre from tbl_doktorlar where doktortc=@p1",bag.baglanti());
            com2.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            SqlDataReader dr2 = com2.ExecuteReader();

            while (dr2.Read())
            {
                textBox1.Text = dr2["doktorad"].ToString();
                textBox2.Text = dr2["doktorsoyad"].ToString();
                textBox3.Text = dr2["doktorsifre"].ToString();
            }

            dr2.Close();
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("update tbl_doktorlar set doktorad=@p1,doktorsoyad=@p2, doktorsifre=@p3,BransId=@p4 where doktortc=@p5",bag.baglanti());
            com.Parameters.AddWithValue("@p1",textBox1.Text);
            com.Parameters.AddWithValue("@p2", textBox2.Text);
            com.Parameters.AddWithValue("@p3", textBox3.Text);
            com.Parameters.AddWithValue("@p4", comboBox2.Text);
            com.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            com.ExecuteNonQuery();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellenmiştir");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select BransId from tbl_branslar where bransad=@p1", bag.baglanti());
            com.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "BransId";
        }

        
    }
}
