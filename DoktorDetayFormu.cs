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
    public partial class DoktorDetayFormu : Form
    {
        public DoktorDetayFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();
        public string tc;

        private void DoktorDetayFormu_Load(object sender, EventArgs e)
        {
            label6.Text = tc;
            SqlCommand com = new SqlCommand("select doktorad, doktorsoyad from tbl_doktorlar where doktortc=@p1", bag.baglanti());

            com.Parameters.AddWithValue("@p1", label6.Text);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr["doktorad"].ToString() + " " + dr["doktorsoyad"].ToString();
            }
            dr.Close();
            bag.baglanti().Close();

            SqlCommand com2 = new SqlCommand("select DoktorId from tbl_doktorlar where doktortc=@p2", bag.baglanti());
            com2.Parameters.AddWithValue("@p2", label6.Text);
            SqlDataReader dr2 = com2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);

            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "DoktorId";

            SqlCommand com3 = new SqlCommand("select * from tbl_randevu where DoktorId=@p3",bag.baglanti());
            com3.Parameters.AddWithValue("@p3", comboBox1.Text);
            SqlDataReader dr3 = com3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            
            dataGridView1.DataSource = dt3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorBilgiDuzenlemeFormu frm = new DoktorBilgiDuzenlemeFormu();
            frm.tc = label6.Text;
            frm.Show();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            DuyurularFormu frm = new DuyurularFormu();
            frm.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = (int)dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
        }
    }
}
