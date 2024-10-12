using Horas_Reporting_2.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Horas_Reporting_2.DataSet1;

namespace Horas_Reporting_2
{
    public static class MasterData
    {

        public static EmployeesTableAdapter EmployeesTableAdapter = new EmployeesTableAdapter();
        public static EmployeesDataTable EmployeesDataTable = new EmployeesDataTable();

        public static Log_TableTableAdapter LogTableAdapter = new Log_TableTableAdapter();
        public static Log_TableDataTable LogDataTable = new Log_TableDataTable();

        public static ContractTableAdapter ContractTableAdapter = new ContractTableAdapter();
        public static ContractDataTable ContractDataTable = new ContractDataTable();

        public static InterimsHeadDataTable InterimsHeadDataTable = new InterimsHeadDataTable();
        public static InterimsHeadTableAdapter InterimsHeadTableAdapter = new InterimsHeadTableAdapter();

        public static InterimsItemsDataTable InterimsItemsDataTable = new InterimsItemsDataTable();
        public static InterimsItemsTableAdapter InterimsItemsTableAdapter = new InterimsItemsTableAdapter();


        public static void RefreshInterimsList()
        {
            InterimsHeadTableAdapter.Connection.Open();
            InterimsHeadTableAdapter.GetData();
            InterimsHeadTableAdapter.Fill(InterimsHeadDataTable);
            InterimsHeadTableAdapter.Connection.Close();

            InterimsItemsTableAdapter.Connection.Open();
            InterimsItemsTableAdapter.GetData();
            InterimsItemsTableAdapter.Fill(InterimsItemsDataTable);
            InterimsItemsTableAdapter.Connection.Close();
        }

        public static string NumericString(double Num)
        {
            return Num.ToString("N", new CultureInfo("en-US"));
        }

        public static void RefreshContractsList()
        {
            //JExpansesAdapter.Connection.Open();
            //JExpansesAdapter.GetData();
            //JExpansesAdapter.Fill(JExpansesDateTable);
            //JExpansesAdapter.Connection.Close();

            //IExpansesAdapter.Connection.Open();
            //IExpansesAdapter.GetData();
            //IExpansesAdapter.Fill(IExpansesDateTable);
            //IExpansesAdapter.Connection.Close();

            ContractTableAdapter.Connection.Open();
            ContractTableAdapter.GetData();
            ContractTableAdapter.Fill(ContractDataTable);
            ContractTableAdapter.Connection.Close();

            //ExpTrAdapter.Connection.Open();
            //ExpTrAdapter.GetData();
            //ExpTrAdapter.Fill(ExpTrDataTable);
            //ExpTrAdapter.Connection.Close();

            //BGLAdapter.Connection.Open();
            //BGLAdapter.GetData();
            //BGLAdapter.Fill(BGLDataTable);
            //BGLAdapter.Connection.Close();

            //AttachContTableAdapter.Connection.Open();
            //AttachContTableAdapter.GetData();
            //AttachContTableAdapter.Fill(AttachContDataTable);
            //AttachContTableAdapter.Connection.Close();
        }

       
        public static void RefreshEmployeeList()
        {
            EmployeesTableAdapter.Connection.Open();
            EmployeesTableAdapter.GetData();
            EmployeesTableAdapter.Fill(EmployeesDataTable);
            EmployeesTableAdapter.Connection.Close();
        }
        public static void RefreshActivitiesList()
        {
            LogTableAdapter.Connection.Open();
            LogTableAdapter.GetData();
            LogTableAdapter.Fill(LogDataTable);
            LogTableAdapter.Connection.Close();
        }

        #region Enums
        public enum CollectionType
        {
            DownPayment = 0,
            SalesInvoiceing = 1
        }

        public enum ActivityMode
        {
            Create = 0,
            Update = 1,
            Delete = 2,
            Print = 3
        }

        public enum Document_Type
        {
            Invoice = 'I',
            Contract = 'C',
            Expanses = 'E',
            Assessment = 'A',
            BankGuranteeLetter = 'B',
            Collections = 'L',
            Interim = 'T'
        }
        public enum WizardMode
        {
            ContractConfirmations = 0,
            AssessmentsConfirmations = 1,
            InterimsConfirmations = 2,
            ExpansesConfirmations = 3
        }
        public enum Item_TYPE
        {
            Supply = 0,
            Implementation_Installation = 1,
            Both = 2
        }

        public enum Tax_Codes
        {
            Constructions = 5,
            Consulting = 10,
            GeneralService = 14,
            Importing = 14,
            ToolsAndEquipments = 5
        }

        public enum Gender
        {
            Male = 0,
            Female = 1
        }

        public enum Job_Roles
        {
            Manager = 0,
            FIManager = 1,
            ConManager = 2,
            DataEntry = 3
        }
        public enum Item_Status
        {
            NotStarted = 0,
            Running = 1,
            Finished = 2
        }

        public enum ItemImportStatus
        {
            NoImport = 0,
            Success = 1,
            NotExist = 2,
            QtyExceed = 3,
            PriceExceed = 4,
            ItemDublicated = 5
        }

        public enum ContractType
        {
            OwnerContract = 0,
            ContractorContract = 1,
            AttachedContract = 2
        }

        public enum BGLStatus
        {
            Active = 0,
            InActive = 1,
            Canceled = 2
        }

        public enum Expensdirect
        {
            direct = 1,
            In_Direct = 0
        }
        #endregion

    }
}
