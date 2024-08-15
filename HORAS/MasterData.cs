using System;
using System.Collections.Generic;
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
using Microsoft.VisualBasic.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static HORAS.Enums;

namespace HORAS
{
    public static class MasterData
    {
        public static Contractor OwnersAndContractors = new Contractor();
        public static Contract Contracts = new Contract();
        public static Employee employees = new Employee();
        public static assessment assessments = new assessment();
        public static Interims Interim = new Interims();
        public static Employee LoggedEmployee = new Employee();
        public static LogClass LogActivity = new LogClass();
        public static DateTime LoginTime = new DateTime();
        public static CollectionModel Collections = new CollectionModel();
        

        public static HorasDataSet Database = new HorasDataSet();
        public static DataBase Con = new DataBase();
        public static List<HorasDataSet.ContractRow> contracts = new List<HorasDataSet.ContractRow>();
        public static List<HorasDataSet.AssessmentHeadRow> Assessments = new List<HorasDataSet.AssessmentHeadRow>();
        public static List<HorasDataSet.AssItemsRow> AssessmentsItems = new List<HorasDataSet.AssItemsRow>();

        public static Login LogForm = new Login();
        public static Start MainForm = new Start();
        public static PartyMain PartyForm = new PartyMain();
        public static ContractsMain ContractsMainForm = new ContractsMain();
        public static ContractsMain ContractsMainForm_ContractConf = new ContractsMain(WizardMode.ContractConfirmations);
        public static ContractsMain ContractsMainForm_ExpsConf = new ContractsMain(WizardMode.ExpansesConfirmations);
        public static AssessmentMain AssMain = new AssessmentMain();
        public static AssessmentMain AssMainWizard = new AssessmentMain(WizardMode.AssessmentsConfirmations);
        public static EmployeesMain EmployeesForm = new EmployeesMain();
        public static InterimsMain InterimsMain = new InterimsMain();
        public static InterimsMain InterimsMainWizard = new InterimsMain(WizardMode.InterimsConfirmations);

        public static ConnectionData ConnectionData = new ConnectionData();
        public static string ConnectionString;

        public static bool DatabaseConnected = true;
        public static void LoadMasterData()
        {
            try
            {
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
            catch (Exception)
            {

                DatabaseConnected = false;
            }
        }



        static void SetConnectionString()
        {
            //Settings1.Default.Reload();

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

        public static int GetcontractNum(Form sender) {

            int contractNum = 0;

           //Displayallcontracts newform = new Displayallcontracts(); 
           // newform.ShowDialog();

           // //newform.Show();

           // contractNum = newform.SelectedContractID;

           return contractNum;
        }
    }
}
