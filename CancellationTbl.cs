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
        }

        private void TidCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCodeCan fetchCode = new fetchCodeCan();
            fetchCode.FetchPopulateCode( FcodeTb, TidCb);
        }
    }
}
