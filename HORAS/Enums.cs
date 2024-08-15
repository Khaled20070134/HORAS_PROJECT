using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORAS
{
    public class Enums
    {

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
            Collections = 'L'
        }
        public enum WizardMode
        {
            ContractConfirmations =0,
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
            ContractorContract = 1
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
    }
}
