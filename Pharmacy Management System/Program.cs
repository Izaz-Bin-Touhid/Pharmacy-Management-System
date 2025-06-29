using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Management_System.view;

namespace Pharmacy_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new LoginForm());

            //test
            //Application.Run(new EcCrude());
            //Application.Run(new productCrude());
          // Application.Run(new ExpireEmplo());
           Application.Run(new CustomerHomeFrame());
        }
    }
}
