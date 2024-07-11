using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airlineOtomations
{
    public partial class ViewPassenger : Form
    {

        private string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";
        public ViewPassenger()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection ("Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;");
        
        // Değişkenler
       
        private void populate()
        {
            Con.Open ();
            string query = "SELECT * FROM PassengerTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder (adapter);
            var ds = new DataSet();
            adapter.Fill (ds);
            passengerDGV.DataSource = ds.Tables[0];

            Con.Close ();
        }
        private void ViewPassenger_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPassanger addPass = new AddPassanger();
            addPass.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string psidTb = PidTb.Text;
            if (psidTb == "")
            {
                MessageBox.Show("Enter The Passenger to delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM PassengerTbl where PassId= @psidTb";
                    SqlCommand cmd = new SqlCommand (query, Con);
                    cmd.Parameters.AddWithValue("@psidTb", psidTb);
                    cmd.ExecuteNonQuery ();
                    MessageBox.Show("Passenger Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch(Exception Ex) 
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void passengerDGV_RowHeaderMouseClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PidTb.Text = "";
            PphoneTb.Text = "";
            PpassTb.Text = "";
            PaddTb.Text = "";
            PnameTb.Text = "";
            NatCb.SelectedItem = "";
            GendCb.SelectedItem = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pidTb = PidTb.Text;
            string ppAd = PaddTb.Text;
            string passTb = PpassTb.Text;
            string pnameTb = PnameTb.Text;
            string passPhone = PphoneTb.Text;
            string passNat = NatCb.SelectedItem?.ToString();  
            string passGend = GendCb.SelectedItem?.ToString();

            if (pidTb == "" || ppAd == "" || passTb == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    using (SqlConnection Con = new SqlConnection(con)) // SqlConnection nesnesini using bloğu içine aldım
                    {
                        Con.Open();
                        string query = "UPDATE PassengerTbl SET PassName = @pnameTb, Passport = @passTb, PassAd = @ppAd, PassNat = @passNat, PassGend = @passGend, PassPhone = @passPhone WHERE PassId = @pidTb";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.Parameters.AddWithValue("@pnameTb", pnameTb);
                        cmd.Parameters.AddWithValue("@passTb", passTb);
                        cmd.Parameters.AddWithValue("@ppAd", ppAd);
                        cmd.Parameters.AddWithValue("@passNat", passNat);
                        cmd.Parameters.AddWithValue("@passGend", passGend);
                        cmd.Parameters.AddWithValue("@passPhone", passPhone);
                        cmd.Parameters.AddWithValue("@pidTb", pidTb);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Passenger Updated Successfully");
                        Con.Close();
                        populate(); // populate() metodunu çağırdım veya veri tabanınızı güncellemeniz gereken başka bir metodu çağırın.
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void passengerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçildiğinden emin olun
            {
                DataGridViewRow row = passengerDGV.Rows[e.RowIndex];
                PidTb.Text = row.Cells["PassId"].Value.ToString();
                PnameTb.Text = row.Cells["PassName"].Value.ToString();
                PpassTb.Text = row.Cells["Passport"].Value.ToString();
                PaddTb.Text = row.Cells["PassAd"].Value.ToString();
                PphoneTb.Text = row.Cells["PassPhone"].Value.ToString();
                NatCb.SelectedItem = row.Cells["PassNat"].Value.ToString();
                GendCb.SelectedItem = row.Cells["PassGend"].Value.ToString();
            }
        }
    }
}
