using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airlineOtomations
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Splash screen
            Splash splashForm = new Splash();
            splashForm.Show();
            Application.DoEvents();

            // Pause for 3 seconds
            Thread.Sleep(3000);

            // Close splash screen
            splashForm.Close();

            // Show login form
            
            Application.Run(new Login());
        }
    }
}
