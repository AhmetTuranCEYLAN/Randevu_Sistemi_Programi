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
    public partial class SekreterDetayFormu : Form
    {
        public SekreterDetayFormu()
        {
            InitializeComponent();
        }
        public string tc;
        OrtakBaglanti bag = new OrtakBaglanti();
        
        private void SekreterDetayFormu_Load(object sender, EventArgs e)
        {
            label6.Text = tc;
            SqlCommand com = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc=@p1", bag.baglanti());
            com.Parameters.AddWithValue("@p1", label6.Text);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr["sekreteradsoyad"].ToString();
            }

            SqlCommand com2 = new SqlCommand("select * from tbl_branslar",bag.baglanti());
            SqlDataReader dr2 = com2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr2);
            dataGridView1.DataSource = dt;

            SqlCommand com3 = new SqlCommand("select * from tbl_doktorlar", bag.baglanti());
            SqlDataReader dr3 = com3.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr3);
            dataGridView2.DataSource = dt2; 

            SqlCommand com4 = new SqlCommand("select * from tbl_hasta", bag.baglanti());
            SqlDataReader dr4 = com4.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr4);
            dataGridView3.DataSource = dt3;
            
            SqlDataAdapter da1 = new SqlDataAdapter("select BransId from tbl_branslar",bag.baglanti());
            DataTable tablo1 = new DataTable();
            da1.Fill(tablo1);
            comboBox1.DataSource = tablo1;
            comboBox1.DisplayMember = "BransId";

            SqlDataAdapter da2 = new SqlDataAdapter("select DoktorId from tbl_doktorlar",bag.baglanti());
            
            DataTable tablo2 = new DataTable();
            da2.Fill(tablo2);
            comboBox2.DataSource = tablo2;
            comboBox2.DisplayMember = "DoktorId";

            SqlDataAdapter da4 = new SqlDataAdapter("select SekreterId from tbl_sekreter", bag.baglanti());

            DataTable tablo4 = new DataTable();
            da4.Fill(tablo4);
            comboBox4.DataSource = tablo4;
            comboBox4.DisplayMember = "SekreterId";

            dr.Close();
            bag.baglanti().Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("insert into tbl_randevu(RandevuId,RandevuTarih,RandevuSaat,BransId,DoktorId,SekreterId)" +
                " values(@p1,@p2,@p3,@p4,@p5,@p6)",bag.baglanti());
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            com.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            com.Parameters.AddWithValue("@p4", comboBox1.Text);
            com.Parameters.AddWithValue("@p5", comboBox2.Text);
            com.Parameters.AddWithValue("@p6", comboBox4.Text);
            com.ExecuteNonQuery();

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t;
                    t = (TextBox)item;
                    t.Text = "";
                }
                else if (item is MaskedTextBox)
                {
                    MaskedTextBox m = (MaskedTextBox)item;
                    m.Text = "";
                }
                else if (item is ComboBox)
                {
                    ComboBox c = (ComboBox)item;
                    c.Text = "";
                }
            }
            MessageBox.Show("Randevunuz Alınmıştır");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoktorPaneliFormu frm = new DoktorPaneliFormu();
            frm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            BransFormu frm = new BransFormu();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("update tbl_randevu set=RandevuTarih=@p1,RandevuSaat=@p2,BransId=@p3,DoktorId=@p4 " +
                "where RandevuId=@p5", bag.baglanti());
            com.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            com.Parameters.AddWithValue("@p2", maskedTextBox2.Text);
            com.Parameters.AddWithValue("@p3", comboBox1.Text);
            com.Parameters.AddWithValue("@p4", comboBox2.Text);
            com.Parameters.AddWithValue("@p5", textBox1.Text);
            com.ExecuteNonQuery();

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t;
                    t = (TextBox)item;
                    t.Text = "";

                }
                else if (item is MaskedTextBox)
                {
                    MaskedTextBox m = (MaskedTextBox)item;
                    m.Text = "";
                }
                else if (item is ComboBox)
                {
                    ComboBox c = (ComboBox)item;
                    c.Text = "";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RandevuListesiFormu frm = new RandevuListesiFormu();
            frm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("insert into tbl_duyurular(Duyuru,SekreterId) values(@p1,@p2)", bag.baglanti());
            com.Parameters.AddWithValue("@p1", richTextBox1.Text);
            com.Parameters.AddWithValue("@p2", comboBox4.Text);
            com.ExecuteNonQuery();
            foreach (Control item in this.Controls)
            {
                if (item is RichTextBox)
                {
                    RichTextBox r= (RichTextBox)item;
                    r.Text = "";
                }
                else if (item is ComboBox)
                {
                    ComboBox c = (ComboBox)item;
                    c.Text = "";
                }
            }
            MessageBox.Show("Kayıt Başarıyla Oluşturuldu");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DuyurularFormu frm = new DuyurularFormu();
            frm.Show();
        }
    }
}
