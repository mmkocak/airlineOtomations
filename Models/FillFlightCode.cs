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
    internal class FillFlightCode
    {
            string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
            public void filFlightCodePopulate(ComboBox Fcode)
            {
                SqlConnection Con = new SqlConnection(con);
                Con.Open();
                SqlCommand comand = new SqlCommand("SELECT Fcode from FlightsTbl", Con);
                SqlDataReader rdr = comand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Fcode", typeof(string));
                dt.Load(rdr);
                Fcode.ValueMember = "Fcode";
                Fcode.DataSource = dt;


                Con.Close();
            }
    }
}
