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
using System.Web.Security;

namespace airlineOtomations
{
    public partial class AddPassanger : Form
    {
        public AddPassanger()
        {
            InitializeComponent();
        }
        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";

        private void AddPassanger_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passid = passId.Text;
            string passname = passName.Text;
            string passport = passportTb.Text;
            string passad = passAd.Text;
            string phonetb = phoneTb.Text;
            if (passid == "" || passad == "" || passname == "" || passport == "" || phonetb == "")
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
                        string query = "INSERT INTO PassengerTbl (PassId,PassName, Passport, PassAd,PassNat, PassGend, PassPhone )" +
                                " VALUES( @passId,@passname, @passport ,@passad , @passnat , @passgend, @phonetb)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@passId", passid);
                        cmd.Parameters.AddWithValue("@passname", passname);
                        cmd.Parameters.AddWithValue("@passport", passport);
                        cmd.Parameters.AddWithValue("@passad", passad);
                        cmd.Parameters.AddWithValue("@passnat", nationalityCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@passgend", genderCb.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@phonetb", phonetb);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Passenger Recorded Succesful");
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }


        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            ViewPassenger viewPass = new ViewPassenger();
            viewPass.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home(); 
            home.Show();
            this.Hide();
        }
    }
}
