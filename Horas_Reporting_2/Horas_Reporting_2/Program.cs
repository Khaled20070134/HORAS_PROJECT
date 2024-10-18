using Horas_Reporting_2.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas_Reporting_2
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

            MasterData.LoadMasterData();
            if (MasterData.DatabaseConnected) Application.Run(new Startup());
            else
                Application.Run(new ConnectionData());


          //  Application.Run(new Startup());
        }
    }
}
