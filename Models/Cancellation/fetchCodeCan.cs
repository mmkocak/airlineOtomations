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
    internal class fetchCodeCan
    {
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";

        public void FetchPopulateCode(TextBox FcodeTb, ComboBox TidCb)
        {
            string  fcodeTb;
            string tidCb = TidCb.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(tidCb))
            {
                MessageBox.Show("Please select a passenger.");
                return;
            }

            using (SqlConnection Con = new SqlConnection(con))
            {
                Con.Open();
                string query = "SELECT * FROM TicketTbl WHERE TId = @TidCb";

                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@TidCb", tidCb);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        fcodeTb = dr["Fcode"].ToString();
                        FcodeTb.Text = fcodeTb;
                       
                    }
                    else
                    {
                        MessageBox.Show("Passenger not found.");
                    }
                }
            }
        }
    }
}
