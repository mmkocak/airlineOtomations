using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airlineOtomations.Models.Cancellation
{
    internal class FillTicketCodeCan
    {
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
        public void filTickedCodePopulate(ComboBox TId)
        {
            SqlConnection Con = new SqlConnection(con);
            Con.Open();
            SqlCommand comand = new SqlCommand("SELECT TId from TicketTbl", Con);
            SqlDataReader rdr = comand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TId", typeof(string));
            dt.Load(rdr);
            TId.ValueMember = "TId";
            TId.DataSource = dt;


            Con.Close();
        }
    }
}
