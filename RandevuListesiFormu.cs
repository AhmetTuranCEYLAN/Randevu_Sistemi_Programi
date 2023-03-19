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
    public partial class RandevuListesiFormu : Form
    {
        public RandevuListesiFormu()
        {
            InitializeComponent();
        }
        OrtakBaglanti bag = new OrtakBaglanti();

        private void RandevuListesiFormu_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from tbl_randevu",bag.baglanti());
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
