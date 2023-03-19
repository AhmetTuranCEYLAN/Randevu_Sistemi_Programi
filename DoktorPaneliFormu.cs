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
    public partial class DoktorPaneliFormu : Form
    {
        public DoktorPaneliFormu()
        {
            InitializeComponent();
        }

        OrtakBaglanti bag = new OrtakBaglanti();

        private void DoktorPaneliFormu_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from tbl_doktorlar",bag.baglanti());
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            SqlCommand com2 = new SqlCommand("select doktorad from tbl_doktorlar", bag.baglanti());
            SqlDataReader dr2 = com2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "doktorad";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com2 = new SqlCommand("select doktorsoyad from tbl_doktorlar where doktorad=@p1", bag.baglanti());
            com2.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr2 = com2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "doktorsoyad";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com2 = new SqlCommand("select BransId from tbl_doktorlar where doktorsoyad=@p1", bag.baglanti());
            com2.Parameters.AddWithValue("@p1", comboBox2.Text);
            SqlDataReader dr2 = com2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "BransId";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int secilen = (int)dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SekreterDetayFormu frm = new SekreterDetayFormu();
            SqlCommand com = new SqlCommand("insert into tbl_doktorlar(doktorad,doktorsoyad,doktortc,doktorsifre,BransId)" +
                " values(@p1,@p2,@p3,@p4,@p5) ",bag.baglanti());
            com.Parameters.AddWithValue("@p1", comboBox1.Text);
            com.Parameters.AddWithValue("@p2", comboBox2.Text);
            com.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p4", textBox3.Text);
            com.Parameters.AddWithValue("@p5", comboBox3.Text);
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("select * from tbl_doktorlar",bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            frm.dataGridView2.DataSource = dt;
            MessageBox.Show("Doktor Başarıyla Eklendi");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SekreterDetayFormu frm = new SekreterDetayFormu();
            SqlCommand com = new SqlCommand("delete tbl_doktorlar where doktortc=@p1",bag.baglanti());
            com.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("select * from tbl_doktorlar", bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            frm.dataGridView2.DataSource = dt;
            MessageBox.Show("Kayıt Başarıyla Silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SekreterDetayFormu frm = new SekreterDetayFormu();
            SqlCommand com = new SqlCommand("update tbl_doktorlar set(doktorad=@p1,doktorsoyad=@p2,doktorsifre=@p3,BransId=@p4) " +
                "where doktortc=@p5", bag.baglanti());
            com.Parameters.AddWithValue("@p1", comboBox1.Text);
            com.Parameters.AddWithValue("@p2", comboBox2.Text);
            com.Parameters.AddWithValue("@p3", textBox3.Text);
            com.Parameters.AddWithValue("@p4", comboBox3.Text);
            com.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            com.ExecuteNonQuery();

            SqlCommand com2 = new SqlCommand("select * from tbl_doktorlar", bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            frm.dataGridView2.DataSource = dt;

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
        }
    }
}
