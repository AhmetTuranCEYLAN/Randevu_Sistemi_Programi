using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Randevu_Sistemi_Programi
{
    class OrtakBaglanti
    {

        public SqlConnection baglanti()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LVD48KT;Initial Catalog=HastaneProje;Integrated Security=True");
            con.Open();
            return con;
        }

    }
}
