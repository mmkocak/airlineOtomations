using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airlineOtomations.Models
{

    internal class fillPassenger
    {
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
        public void fillPassengerPopulate(ComboBox PICb)
        {
            SqlConnection Con = new SqlConnection(con);
            Con.Open();
            SqlCommand comand = new SqlCommand("SELECT PassId from PassengerTbl", Con);
            SqlDataReader rdr = comand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PassId", typeof(int));
            dt.Load(rdr);
            PICb.ValueMember = "PassId";
            PICb.DataSource = dt;


            Con.Close();
        }

    }
}
