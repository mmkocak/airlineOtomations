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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string con = "Server=DESKTOP-I3I4IR2\\SQLEXPRESS; Database=AirlinesDb; Trusted_Connection=True;";

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            UidTb.Text = "";
            Pasword.Text = "";
        }
        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM [usTbl] WHERE uad = @username AND upass = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string username = UidTb.Text;
            string password = Pasword.Text;

            if (CheckLogin(username, password))
            {
                MessageBox.Show("Login Successful!");
                Home homePage = new Home(); 
                homePage.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Username or password is wrong");
            }

        }
    }
}
