using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace airlineOtomations.Models
{
    internal class FetchPassenger
    {
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";

        public void FetchAndPopulatePassenger(TextBox PnameTb, TextBox PPassTb, TextBox PNatTb, ComboBox PICb)
        {
            string pname, ppass, pnat, pgend;
            string passId = PICb.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(passId))
            {
                MessageBox.Show("Please select a passenger.");
                return;
            }

            using (SqlConnection Con = new SqlConnection(con))
            {
                Con.Open();
                string query = "SELECT * FROM PassengerTbl WHERE PassId = @PassId";

                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@PassId", passId);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        pname = dr["PassName"].ToString();
                        ppass = dr["Passport"].ToString();
                        pnat = dr["PassNat"].ToString();
                        pgend = dr["PassGend"].ToString();
                        PnameTb.Text = pname;
                        PPassTb.Text = ppass;
                        PNatTb.Text = pnat;
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
