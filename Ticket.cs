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
using System.Text.RegularExpressions;
using airlineOtomations.Models;

namespace airlineOtomations
{
    public partial class Ticket : Form
    {
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";


        public Ticket()
        {
            InitializeComponent();

        }

        private void Ticket_Load(object sender, EventArgs e)
        {
            fillPassenger fillPassenger = new fillPassenger();
            fillPassenger.fillPassengerPopulate(PICb);
            FillFlightCode fillFlightCode = new FillFlightCode();
            fillFlightCode.filFlightCodePopulate(FCode);
            // Ticket Populate
            string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
            SelectPopulate selectPopulate = new SelectPopulate(connectionString);
            TicketDGV.DataSource = selectPopulate.GetDataTable("TicketTbl");

        }


        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void PICb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FetchPassenger fetchPasssenger = new FetchPassenger();
            fetchPasssenger.FetchAndPopulatePassenger(PnameTb, PPassTb, PNatTb, PICb);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string tId = tid.Text;
            string pnametb = PnameTb.Text;
            string Fcode = FCode.SelectedValue.ToString(); 
            string pIcb = PICb.SelectedValue.ToString(); 
            string fPasstb = PPassTb.Text;
            string pNattb = PNatTb.Text;
            string pAmttb = PAmtTb.Text;

            if (pnametb == "" || tId == "")
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
                        string query = "INSERT INTO TicketTbl (TId, Fcode, PId, PName, PPass, PNation, Amt)" +
                                       " VALUES(@tId, @Fcode, @pIcb, @pnametb, @fPasstb, @pNattb, @pAmttb)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@tId", tId);
                        cmd.Parameters.AddWithValue("@Fcode", Fcode);
                        cmd.Parameters.AddWithValue("@pIcb", pIcb);
                        cmd.Parameters.AddWithValue("@pnametb", pnametb);
                        cmd.Parameters.AddWithValue("@fPasstb", fPasstb);
                        cmd.Parameters.AddWithValue("@pNattb", pNattb);
                        cmd.Parameters.AddWithValue("@pAmttb", pAmttb);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket Booked Successful");


                        conn.Close();

                        string connectionString = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
                        SelectPopulate selectPopulate = new SelectPopulate(connectionString);
                        TicketDGV.DataSource = selectPopulate.GetDataTable("TicketTbl");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void FCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pnametb = PnameTb.Text = "", fPasstb = PPassTb.Text = "", pNattb = PNatTb.Text = "", pAmttb = PAmtTb.Text = "",  tId = tid.Text = ""; 
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}