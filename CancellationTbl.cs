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
using System.Windows.Forms.VisualStyles;
using airlineOtomations.Models.Cancellation;
using airlineOtomations.Models;
using System.Security.Cryptography;
namespace airlineOtomations
{
    public partial class CancellationTbl : Form
    {
        public CancellationTbl()
        {
            InitializeComponent();
        }
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
        private void CancellationTbl_Load(object sender, EventArgs e)
        {
            FillTicketCodeCan fillTicket = new FillTicketCodeCan();
            fillTicket.filTickedCodePopulate(TidCb);
            string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
            SelectPopulate selectPopulate = new SelectPopulate(connectionString);
            CancellDGV.DataSource = selectPopulate.GetDataTable("CancelTbl");
        }

        private void TidCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCodeCan fetchCode = new fetchCodeCan();
            fetchCode.FetchPopulateCode( FcodeTb, TidCb);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CanId.Text = "";
            FcodeTb.Text = "";
        }
        private void deleteTicket()
        {
            SqlConnection Con = new SqlConnection(con) ;
            string tId = TidCb.SelectedValue.ToString();
           
                try
                {
                    Con.Open();
                    string query = "DELETE FROM FlightsTbl where TId= @tId";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@tId", tId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ticket Deleted Successfully");
                    Con.Close();
                string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
                SelectPopulate selectPopulate = new SelectPopulate(connectionString);
                CancellDGV.DataSource = selectPopulate.GetDataTable("CancelTbl");
            }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string canId = CanId.Text;
            string Fcode = FcodeTb.Text;
            string tidCb = TidCb.SelectedValue.ToString();
            string cancDate = CancDate.Value.Date.ToString();

            if (canId == "" || Fcode == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(con))
                    {
                        conn.Open();
                        string query = "INSERT INTO CancelTbl (CancId, TicId, FlCode, CancDate)" +
                                       " VALUES(@canId, @tidCb, @Fcode, @cancDate)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@canId", canId);
                        cmd.Parameters.AddWithValue("@tidCb", tidCb);
                        cmd.Parameters.AddWithValue("@Fcode", Fcode);
                        cmd.Parameters.AddWithValue("@cancDate", cancDate);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successful");


                        conn.Close();
                        
                        string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
                        SelectPopulate selectPopulate = new SelectPopulate(connectionString);
                        CancellDGV.DataSource = selectPopulate.GetDataTable("CancelTbl");

                      deleteTicket();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
