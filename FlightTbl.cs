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
    public partial class FlightTbl : Form
    {
        public FlightTbl()
        {
            InitializeComponent();
        }
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
        private void record_Click(object sender, EventArgs e)
        {
            string fcodeTb = FcodeTb.Text;
            string fsrc = Fsrc.Text;
            string fdest = FDest.Text;
            string fdate = FDate.Text;
            string seatNum = SeatNum.Text;
            if (fcodeTb == "" || fsrc == "" || fdest == "" || fdate == "" || seatNum == "")
            {
                MessageBox.Show("Missing İnformation");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(con))
                {


                    try
                    {
                        conn.Open();
                        // Veri tabanını bağladık
                        string query = "INSERT INTO FlightsTbl (Fcode,Fsrc, FDest, FDate,FCap)" +
                                " VALUES( @Fcode,@Fsrc, @Fdest ,@FDate , @SeatNum )";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Fcode", fcodeTb);
                        cmd.Parameters.AddWithValue("@Fsrc",Fsrc.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Fdest", FDest.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FDate", FDate.Value.ToString());
                        cmd.Parameters.AddWithValue("@SeatNum", seatNum);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Flight Recorded Succesful");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FcodeTb.Text = "";
            SeatNum.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewFlights viewFlights = new ViewFlights();
            viewFlights.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
