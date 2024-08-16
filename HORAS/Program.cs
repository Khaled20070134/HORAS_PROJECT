
using HORAS.Assessments;
using HORAS.Contracts;

namespace HORAS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

             MasterData.Initialize();
            MasterData.LoadMasterData();
            if (MasterData.DatabaseConnected) Application.Run(MasterData.LogForm);
            else
                Application.Run(MasterData.ConnectionData);
            // MasterData.Initialize();
            // Application.Run(new ConnectionData());
        }
    }
}