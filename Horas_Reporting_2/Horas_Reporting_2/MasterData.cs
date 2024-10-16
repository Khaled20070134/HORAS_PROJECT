﻿using Horas_Reporting_2.DataSet1TableAdapters;
using Horas_Reporting_2.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Horas_Reporting_2.DataSet1;

namespace Horas_Reporting_2
{
    public static class MasterData
    {
        public static ExpansesMajorTableAdapter JExpansesAdapter = new ExpansesMajorTableAdapter();
        public static ExpansesMajorDataTable JExpansesDateTable = new ExpansesMajorDataTable();

        public static ExpansesMinorTableAdapter IExpansesAdapter = new ExpansesMinorTableAdapter();
        public static ExpansesMinorDataTable IExpansesDateTable = new ExpansesMinorDataTable();

        public static ExpTransTableAdapter ExpTrAdapter = new ExpTransTableAdapter();
        public static ExpTransDataTable ExpTrDataTable = new ExpTransDataTable();

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


        public static AssessmentHeadTableAdapter AssessmentHeadTableAdapter = new AssessmentHeadTableAdapter();
        public static AssessmentHeadDataTable AssessmentHeadDataTable = new AssessmentHeadDataTable();

        public static AssItemsTableAdapter AssItemsAdapter = new AssItemsTableAdapter();
        public static AssItemsDataTable AssItemsDataTable = new AssItemsDataTable();

        public static PartyTableAdapter PartyTableAdapter = new PartyTableAdapter();
        public static PartyDataTable PartyDataTable = new PartyDataTable();

        public static bool DatabaseConnected = false;
        public static string ConnectionString;

        static void SetConnectionString()
        {
            //Settings1.Default.Reload();

            try
            {
                ContractTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                ExpTrAdapter.Connection.ConnectionString = Settings1.Default.CS;
                IExpansesAdapter.Connection.ConnectionString = Settings1.Default.CS;
                JExpansesAdapter.Connection.ConnectionString = Settings1.Default.CS;
                //BGLAdapter.Connection.ConnectionString = Settings1.Default.CS;
                //CollectionAdapter.Connection.ConnectionString = Settings1.Default.CS;
                EmployeesTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                AssessmentHeadTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                AssItemsAdapter.Connection.ConnectionString = Settings1.Default.CS;
                PartyTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                InterimsHeadTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                InterimsItemsTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
                LogTableAdapter.Connection.ConnectionString = Settings1.Default.CS;
            }
            catch (InvalidOperationException Ex)
            {

                DatabaseConnected = false;
                return;
            }
            // Settings1.Default.Save();
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

        public static void LoadMasterData()
        {
            try
            {
                //DatabaseConnected = CheckConnectionString();
                if (!CheckConnectionString()) return;
                SetConnectionString();
             RefreshContractsList();
                RefreshAssList();
                RefreshEmployeeList();
                RefreshPartyList();
                RefreshActivitiesList();
                RefreshInterimsList();
                //Collections.RefreshList();

                DatabaseConnected = true;
            }
            catch (InvalidOperationException Ex)
            {

                DatabaseConnected = false;
                return;
            }
        }

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
            JExpansesAdapter.Connection.Open();
            JExpansesAdapter.GetData();
            JExpansesAdapter.Fill(JExpansesDateTable);
            JExpansesAdapter.Connection.Close();

            IExpansesAdapter.Connection.Open();
            IExpansesAdapter.GetData();
            IExpansesAdapter.Fill(IExpansesDateTable);
            IExpansesAdapter.Connection.Close();

            ContractTableAdapter.Connection.Open();
            ContractTableAdapter.GetData();
            ContractTableAdapter.Fill(ContractDataTable);
            ContractTableAdapter.Connection.Close();

            ExpTrAdapter.Connection.Open();
            ExpTrAdapter.GetData();
            ExpTrAdapter.Fill(ExpTrDataTable);
            ExpTrAdapter.Connection.Close();

            //BGLAdapter.Connection.Open();
            //BGLAdapter.GetData();
            //BGLAdapter.Fill(BGLDataTable);
            //BGLAdapter.Connection.Close();
        }

        public static void RefreshPartyList()
        {
            PartyTableAdapter.Connection.Open();
            PartyTableAdapter.GetData();
            PartyTableAdapter.Fill(PartyDataTable);
            PartyTableAdapter.Connection.Close();
        }

        public static void RefreshAssList()
        {
            AssessmentHeadTableAdapter.Connection.Open();
            AssessmentHeadTableAdapter.GetData();
            AssessmentHeadTableAdapter.Fill(AssessmentHeadDataTable);
            AssessmentHeadTableAdapter.Connection.Close();

            AssItemsAdapter.Connection.Open();
            AssItemsAdapter.GetData();
            AssItemsAdapter.Fill(AssItemsDataTable);
            AssItemsAdapter.Connection.Close();
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
