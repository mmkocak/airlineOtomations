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
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\airline-mangament-system\airline-managament-system-c-\airlineOtomations\database\Airline.db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        private void AddPassanger_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Con.Open(); 

            Con.Close();
        }
    }
}
