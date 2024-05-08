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

        private void passengerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string pidtb = PidTb.Text;
            pidtb = passengerDGV.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
