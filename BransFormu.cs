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
    public partial class BransFormu : Form
    {
        public BransFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SekreterDetayFormu frm = new SekreterDetayFormu();
            SqlCommand com = new SqlCommand("insert into tbl_branslar(BransId,bransad) values(@p1,@p2) ", bag.baglanti());
            com.Parameters.AddWithValue("@p1", comboBox1.Text);
            com.Parameters.AddWithValue("@p2", comboBox2.Text);
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("select * from tbl_branslar", bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            frm.dataGridView2.DataSource = dt;
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    ComboBox c;
                    c = (ComboBox)item;
                    c.Text = "";
                }
            }
            MessageBox.Show("Kayıt Başarıyla Eklendi");
        }
        private void BransFormu_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select BransId,bransad from tbl_branslar", bag.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "BransId";
            comboBox1.ValueMember = "BransId";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select BransId,bransad from tbl_branslar", bag.baglanti());
            com.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "bransad";
            comboBox2.ValueMember = "BransId";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SekreterDetayFormu frm = new SekreterDetayFormu();
            SqlCommand com = new SqlCommand("delete from tbl_branslar where BransId=@p1 ", bag.baglanti());
            com.Parameters.AddWithValue("@p1", comboBox1.Text);
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("select * from tbl_branslar", bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            frm.dataGridView2.DataSource = dt;
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    ComboBox c;
                    c = (ComboBox)item;
                    c.Text = "";
                }
            }    MessageBox.Show("Kayıt Başarıyla Silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SekreterDetayFormu frm = new SekreterDetayFormu();
            SqlCommand com = new SqlCommand("update tbl_branslar set bransad=@p1 where BransId=@p2  ", bag.baglanti());
            com.Parameters.AddWithValue("@p2", comboBox1.Text);
            com.Parameters.AddWithValue("@p1", comboBox2.Text);
            com.ExecuteNonQuery();

            SqlCommand com2 = new SqlCommand("select * from tbl_branslar", bag.baglanti());
            SqlDataReader dr = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            frm.dataGridView2.DataSource = dt;

            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    ComboBox c;
                    c = (ComboBox)item;

                    c.Text = "";

                }
            }

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
        }
    }
}
