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
    public partial class DuyurularFormu : Form
    {
        public DuyurularFormu()
        {
            InitializeComponent();
        }

        OrtakBaglanti bag = new OrtakBaglanti();

        private void DuyurularFormu_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from tbl_duyurular", bag.baglanti());
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }
    }
}
