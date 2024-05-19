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
using System.Runtime.CompilerServices;
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
    }
}
