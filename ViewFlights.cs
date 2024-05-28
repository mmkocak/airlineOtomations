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
    public partial class ViewFlights : Form
    {
        public ViewFlights()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;");

        
        private void populate()
        {
            Con.Open();
            string query = "SELECT * FROM FlightsTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            flightDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void ViewFlights_Load(object sender, EventArgs e)
        {
            populate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FlightTbl addflght = new FlightTbl();
            addflght.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fcode.Text = "";
            SeatNum.Text = "";
        }

        private void flightDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçildiğinden emin olun
            {
                DataGridViewRow row = flightDGV.Rows[e.RowIndex];
                Fcode.Text = row.Cells["Fcode"].Value.ToString();
                Fsrc.SelectedItem = row.Cells["Fsrc"].Value.ToString();
                FDest.SelectedItem = row.Cells["FDest"].Value.ToString();
                SeatNum.Text = row.Cells["FCap"].Value.ToString();
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fcodeTb = Fcode.Text;
            if (fcodeTb == "")
            {
                MessageBox.Show("Enter The Flight to delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM FlightsTbl where Fcode= @fcodeTb";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@fcodeTb", fcodeTb);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fcode = Fcode.Text;
            string fcap = SeatNum.Text;
            string fsrc = Fsrc.SelectedItem.ToString();
            string fdest = FDest.SelectedItem.ToString();
            string fdate = FDate.Value.Date.ToString();
            


            if (fcode == "" || fcap == "")
            {
                MessageBox.Show("Missing İnformation");
            }
            else
            {
                try
                {
                    Con.Open();
string query = "UPDATE FlightsTbl set Fsrc = @fsrc, FDest = @fdest, FDate = @fdate, FCap = @fCap WHERE FCode = @fcode";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@fsrc", fsrc);
                    cmd.Parameters.AddWithValue("@fdest", fdest);
                    cmd.Parameters.AddWithValue("@fdate", fdate);
                    cmd.Parameters.AddWithValue("@fCap", fcap);

                    cmd.Parameters.AddWithValue("@fcode", fcode);
                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Flight Updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        
    
}

        private void Fsrc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
