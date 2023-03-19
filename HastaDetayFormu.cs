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
    public partial class HastaDetayFormu : Form
    {
        public HastaDetayFormu()
        {
            InitializeComponent();
        }
        public string tc;
        OrtakBaglanti bag = new OrtakBaglanti();

        private void HastaDetayFormu_Load(object sender, EventArgs e)
        {
            label6.Text = tc;
            SqlCommand com3 = new SqlCommand("select HastaId from tbl_hasta where hastatc=@p1",bag.baglanti());
            com3.Parameters.AddWithValue("@p1",label6.Text);
            SqlDataReader dr3 = com3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            comboBox4.DataSource = dt3;
            comboBox4.DisplayMember = "HastaId";

            SqlCommand com = new SqlCommand("select hastaad, hastasoyad from tbl_hasta where hastatc=@p1",bag.baglanti());
            com.Parameters.AddWithValue("@p1", label6.Text);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr["hastaad"].ToString() +" "+ dr["hastasoyad"].ToString();
            }
            dr.Close();
            bag.baglanti().Close();

            SqlDataAdapter da;
            da=new SqlDataAdapter("select * from tbl_randevu where randevudurum=1 and HastaId=(select HastaId from tbl_hasta where hastatc=" + tc + ")", bag.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand com2 = new SqlCommand("select BransId,bransad from tbl_branslar",bag.baglanti());
            SqlDataReader dr2 = com2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "bransad";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            da= new SqlDataAdapter("select * from tbl_randevu where BransId=(select BransId from tbl_branslar where bransad='" + comboBox1.Text + "')", bag.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            SqlDataAdapter da2 = new SqlDataAdapter("select DoktorId from tbl_doktorlar where doktorad='"+comboBox2.Text+"'", bag.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox5.DataSource = dt2;
            comboBox5.DisplayMember = "DoktorId";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select doktorad from tbl_doktorlar  where BransId=(select BransId from tbl_branslar where bransad=@p1)", bag.baglanti());
            com.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "doktorad";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BilgiDuzenlemeFormu frm = new BilgiDuzenlemeFormu();
            frm.Show();
            this.Hide();
        }

        

        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = (int)dataGridView2.SelectedCells[0].RowIndex;
            comboBox3.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("update tbl_randevu set randevudurum=1, HastaId=@p1, hasta_sikayet=@p2 where RandevuId=@p3 ", bag.baglanti());
            com.Parameters.AddWithValue("@p1",comboBox4.Text);
            com.Parameters.AddWithValue("@p2",richTextBox1.Text);
            com.Parameters.AddWithValue("@p3",comboBox3.Text);
            com.ExecuteNonQuery();

            SqlCommand com2 = new SqlCommand("select * from tbl_randevu",bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;


        }

       
    }
}
