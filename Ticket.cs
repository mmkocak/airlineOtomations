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
using System.Runtime.CompilerServices;

namespace airlineOtomations
{
    public partial class Ticket : Form
    {
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
        
        private void fillPassenger()
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
        public Ticket()
        {
            InitializeComponent();
           
        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            fillPassenger();
            
        }
        string pname, ppass, pnat, pgend;
       
        private void fetchPassenger()
        {

            string passId = PICb.SelectedValue.ToString();
           

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

                    foreach (DataRow dr in dt.Rows)
                    {
                        pname = dr["PassName"].ToString();
                        ppass = dr["Passport"].ToString();
                        pnat = dr["PassNat"].ToString();
                        pgend = dr["PassGend"].ToString();
                       PnameTb.Text = pname;
                        PPassTb.Text = ppass;
                        PNatTb.Text = pnat;
                    }
                }
            }

        }
        private void PICb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchPassenger();
        }
    }
}
