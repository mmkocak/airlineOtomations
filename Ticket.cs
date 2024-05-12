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
        private void fetchPassenger()
        {
            string passId = PICb.SelectedValue.ToString();
            SqlConnection Con = new SqlConnection(con);
            
            Con.Open();
            String query = "SELECT * FROM PassengerTbl where PassId = @PassId";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            cmd.Parameters.AddWithValue("@PassId", passId);
            foreach (DataRow dr in dt.Rows)
            {

            }
            Con.Close();

        }
        private void PICb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(con);
            Con.Open();

            Con.Close();
        }
    }
}
