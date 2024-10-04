using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HORAS.Assessments;
using HORAS.Collections;
using HORAS.Contracts;
using HORAS.Database;
using HORAS.EmployeFolder;
using HORAS.EmployeFolder.Employees;
using HORAS.Interims_Data;
using HORAS.LogFolder;
using HORAS.SuppliersAndClients;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static HORAS.Enums;

namespace HORAS
{
    public static class MasterData
    {
        public static Contractor OwnersAndContractors;
        public static Contract Contracts;
        public static Employee employees;
        public static assessment assessments;
        public static Interims Interim;
        public static Employee LoggedEmployee;
        public static LogClass LogActivity;
        public static DateTime LoginTime;
        public static CollectionModel Collections;


        public static HorasDataSet Database;
        public static DataBase Con;
        public static List<HorasDataSet.ContractRow> contracts;
        public static List<HorasDataSet.AssessmentHeadRow> Assessments;
        public static List<HorasDataSet.AssItemsRow> AssessmentsItems;

        public static Login LogForm;
        public static Start MainForm;
        public static PartyMain PartyForm;
        public static ContractsMain ContractsMainForm;
        public static ContractsMain ContractsMainForm_ContractConf;
        public static ContractsMain ContractsMainForm_ExpsConf;
        public static AssessmentMain AssMain;
        public static AssessmentMain AssMainWizard;
        public static EmployeesMain EmployeesForm;
        public static InterimsMain InterimsMain;
        public static InterimsMain InterimsMainWizard;

        public static ConnectionData ConnectionData;
        public static string ConnectionString;

        public static bool DatabaseConnected = false;

        public static void Initialize()
        {

            OwnersAndContractors = new Contractor();
            Contracts = new Contract();
            employees = new Employee();
            assessments = new assessment();
            Interim = new Interims();
            LoggedEmployee = new Employee();
            LogActivity = new LogClass();
            LoginTime = new DateTime();
            Collections = new CollectionModel();


            Database = new HorasDataSet();
            Con = new DataBase();
            contracts = new List<HorasDataSet.ContractRow>();
            Assessments = new List<HorasDataSet.AssessmentHeadRow>();
            AssessmentsItems = new List<HorasDataSet.AssItemsRow>();

            LogForm = new Login();
            MainForm = new Start();
            PartyForm = new PartyMain();
            ContractsMainForm = new ContractsMain();
            ContractsMainForm_ContractConf = new ContractsMain(WizardMode.ContractConfirmations);
            ContractsMainForm_ExpsConf = new ContractsMain(WizardMode.ExpansesConfirmations);
            AssMain = new AssessmentMain();
            AssMainWizard = new AssessmentMain(WizardMode.AssessmentsConfirmations);
            EmployeesForm = new EmployeesMain();
            InterimsMain = new InterimsMain();
            InterimsMainWizard = new InterimsMain(WizardMode.InterimsConfirmations);

            ConnectionData = new ConnectionData();
            ConnectionString = string.Empty;

            DatabaseConnected = false;
        }

        public static void LoadMasterData()
        {
            try
            {
                //DatabaseConnected = CheckConnectionString();
                if (!CheckConnectionString()) return;
                SetConnectionString();
                Contracts.RefreshList();
                assessments.RefreshList();
                employees.RefreshList();
                OwnersAndContractors.RefreshList();
                LogActivity.RefreshList();
                Interim.RefreshList();
                Collections.RefreshList();

                DatabaseConnected = true;
            }
            catch (InvalidOperationException Ex)
            {

                DatabaseConnected = false;
                return;
            }
        }

        static bool CheckConnectionString()
        {
            if (Settings1.Default.CS == string.Empty) return false;
            try
            {
                var conn = new SqlConnection(Settings1.Default.CS);
                conn.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        static void SetConnectionString()
        {
            //Settings1.Default.Reload();

            try
            {
                Contracts.ContractTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Contracts.ExpTrAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Contracts.IExpansesAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Contracts.JExpansesAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Contracts.BGLAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Collections.CollectionAdapter.Connection.ConnectionString = Settings1.Default.CS;
                employees.EmployeesTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                assessments.AssessmentHeadTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                assessments.AssItemsAdapter.Connection.ConnectionString = Settings1.Default.CS;
                OwnersAndContractors.PartyTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Interim.InterimsHeadTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                Interim.InterimsItemsTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                LogActivity.LogTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
            }
            catch (InvalidOperationException Ex)
            {

                DatabaseConnected = false;
                return;
            }
            // Settings1.Default.Save();
        }

        public static bool CheckMail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static string NumericString(double Num)
        {
            return Num.ToString("N", new CultureInfo("en-US"));
        }
        public static Item_TYPE GetItemType(string ContractNumber, string ItemNumber)
        {
            int ContractID = Contracts.ContractDataTable.FirstOrDefault(X => X.Number == ContractNumber).ID;

            Item_TYPE Type;
            var Result = assessments.AssItemsAdapter.GetItemType(ContractID, ItemNumber);
            Type = (Item_TYPE)Result[0].Item_Type;
            return Type;
        }

        public static string GetItemTypeString(int Typeint)
        {
            Item_TYPE Type = (Item_TYPE)Typeint;
            string TypeReturn = string.Empty;
            switch (Type)
            {
                case Item_TYPE.Supply: TypeReturn = "توريد"; break;
                case Item_TYPE.Implementation_Installation: TypeReturn = "تنفيذ"; break;
                case Item_TYPE.Both: TypeReturn = "تنفيذ و توريد"; break;
            }
            return TypeReturn;
        }

        // Copy saved filefrom client to server
        public static void CopyFile(string FileName, string Name)
        {
            File.Copy(FileName, Settings1.Default.DB_Files + @"\\" + Name + Path.GetExtension(FileName));
        }

        // Seach for file and return its path in case found
        public static string GetFile(string FileName)
        {
            string FoundFile = string.Empty;

            if (!Directory.Exists(Settings1.Default.DB_Files))
                return FoundFile;

            string[] Files = Directory.GetFiles(Settings1.Default.DB_Files, FileName + ".pdf");
            if (Files.Count() > 0) FoundFile = Files[0];

            return FoundFile;
        }

        public static void DeleteFile(string FileName)
        {
            File.Delete(FileName);
        }

        public static void OpenFile(string FilePath)
        {
            var P = new Process();
            P.StartInfo = new ProcessStartInfo(FilePath) { UseShellExecute = true };
            P.Start();
        }
        public static void styleGridView(DataGridView MyGrid)
        {
            MyGrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#eeeff9");
            MyGrid.BorderStyle = BorderStyle.None;
            MyGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            MyGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("20,25,70");
            MyGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            MyGrid.DefaultCellStyle.SelectionBackColor = Color.ForestGreen;
            MyGrid.EnableHeadersVisualStyles = false;
            MyGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
            MyGrid.ForeColor = Color.Black;
        }

        public static int GetcontractNum(Form sender)
        {

            int contractNum = 0;

            //Displayallcontracts newform = new Displayallcontracts(); 
            // newform.ShowDialog();

            // //newform.Show();

            // contractNum = newform.SelectedContractID;

            return contractNum;
        }
    }
}
