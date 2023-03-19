using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Randevu_Sistemi_Programi
{
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HastaFormu frm = new HastaFormu();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorGirisFormu frm = new DoktorGirisFormu();
            frm.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SekreterGirisFormu frm = new SekreterGirisFormu();
            frm.Show();
            this.Hide();
        }
    }
}
