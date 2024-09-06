using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Enums;
using static HORAS.Database.HorasDataSet;
using HORAS.Database.HorasDataSetTableAdapters;
using System.Data;
using HORAS.Database;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace HORAS.Interims_Data
{

    //public InterimsHead InterimsHeadDataTable

    public class Items
    {
        #region Properties
        public string Number { set; get; }
        public string Dexcription { set; get; }
        public Item_TYPE Type { set; get; }
        public float Qty { set; get; }
        public float Total_PRice { set; get; }
        public string Item_Unit { set; get; }
        public bool AssignedToContract { set; get; } = false;
        public int ContractID { set; get; }
        public float LOL { set; get; }
        public Tax_Codes TaxCode { set; get; } = 0;
        public double SpecialDiscount { set; get; }
        public Item_Status Status { set; get; } = Item_Status.NotStarted;
        public ItemImportStatus ImportStatus { set; get; } = ItemImportStatus.NoImport;
        public double PrevQty { set; get; } = 0;
        public double AssTotalQty { set; get; } = 0;
        public float Ass_Price_Unit { set; get; } = 0;
        public struct ImportData
        {
            float Price { set; get; }
            float Qty { set; get; }
            string Number;
        }
        public ImportData ImportItemData;

        public struct AssessmentData
        {
            float Price { set; get; }
            float Qty { set; get; }
            string Number;
        }
        public ImportData AssessmentItemData;
        #endregion
    }

    public struct I_Status
    {
        public double LOL { set; get; }
        public double Total_QP { set; get; }
        public double Delivered_QP { set; get; }
        public double Remain_QP { set; get; }
        public double Total_Value { set; get; }
        public double Remain_Value { set; get; }
        public double Delivered_Value { set; get; }
        public double Total_Exps { set; get; }
        public decimal Remain_Exps { set; get; }
    }



    public enum Billing_Status
    {
        NotBilled = 0,
        Billed = 1,
        BilledAndCollected = 2
    }

    public class Interims
    {
        public InterimsHeadDataTable InterimsHeadDataTable = new InterimsHeadDataTable();
        public InterimsHeadTableAdapter InterimsHeadTableAdapter = new InterimsHeadTableAdapter();
        public InterimsHeadRow InterimsHeadRow;

        public InterimsItemsDataTable InterimsItemsDataTable = new InterimsItemsDataTable();
        public InterimsItemsTableAdapter InterimsItemsTableAdapter = new InterimsItemsTableAdapter();
        public InterimsItemsRow InterimsItemRow;
        public I_Status i_Status;

        public Billing_Status billing_Status { set; get; }
        public bool Confirmed { set; get; } = false;
        public bool Billed { set; get; } = false;
        public DateTime CreationDate { set; get; }
        public DateTime ConfirmationDate { set; get; }
        public int CreatedBy { set; get; }
        public int ConfirmedBy { set; get; }
        public int BilledBy { set; get; }
        public List<Items> Contract_Items = new List<Items>();
        public string Number { set; get; }

        public I_Status Get_Item_Status(string SelectedContractNumber, string SelectedItemNumber)
        {
            I_Status i_Status = new I_Status();

            // Load Item Type
            Item_TYPE ITpe = MasterData.GetItemType(SelectedContractNumber, SelectedItemNumber);
            int Typeint = (int)ITpe;

            int SelectedContrctID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == SelectedContractNumber).ID;

            int ItemID = MasterData.assessments.AssItemsAdapter.NotNullContracts().
                FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.Number == SelectedItemNumber).ID;

            i_Status.Total_QP = MasterData.assessments.AssItemsDataTable.
    FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.Number == SelectedItemNumber).Qty;

            i_Status.Total_Value = MasterData.assessments.AssItemsDataTable.
                FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.Number == SelectedItemNumber).Total_Price * i_Status.Total_QP;



            i_Status.LOL = MasterData.assessments.AssItemsDataTable.
                FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.Number == SelectedItemNumber).LOL;

            List<InterimsHeadRow> ListOfInterims = MasterData.Interim.InterimsHeadDataTable.
                Where(X => X.ContractID == SelectedContrctID && !X.IsConfirm_DateNull()).ToList();

            foreach (InterimsHeadRow Interim in ListOfInterims)
            {
                // Set Delivered Total Value
                i_Status.Delivered_Value +=
                MasterData.Interim.InterimsItemsDataTable.
                Where(X => X.HeadID == Interim.ID && X.Number == SelectedItemNumber).Sum(Y => Y.Price_Unit * Y.Qty);

                // Set Delivered Quantity or Percentage
                i_Status.Delivered_QP +=
                MasterData.Interim.InterimsItemsDataTable.
                Where(X => X.HeadID == Interim.ID && X.Number == SelectedItemNumber).Sum(Y => Y.Qty);
            }

            // Set Remain Data of Item
            i_Status.Remain_Value = i_Status.Total_Value - i_Status.Delivered_Value;
            i_Status.Remain_QP = i_Status.Total_QP - i_Status.Delivered_QP;

            // Set Expanses
            i_Status.Total_Exps = MasterData.Contracts.ExpTrDataTable.
                Where(X => X.ContractID == SelectedContrctID && X.ItemNo == ItemID && !X.NeedConf).Sum(Y => Y.Amount);


            i_Status.Remain_Exps = (decimal)(i_Status.LOL * i_Status.Total_Value - (double)i_Status.Total_Exps);



            return i_Status;
        }
        public double getPrevData(int contractID, string ItemNumber)
        {
            List<int> Interims = new List<int>();
            var List = InterimsHeadDataTable.Where(X => X.ContractID == contractID && !X.IsContractIDNull());
            double QtySum = 0;
            foreach (var Row in List)
            {
                var Check = InterimsItemsDataTable.FirstOrDefault(X => X.HeadID == Row.ID && X.Number == ItemNumber);
                if (Check != null)
                {
                    QtySum += InterimsItemsDataTable.FirstOrDefault(X => X.HeadID == Row.ID && X.Number == ItemNumber).Qty;
                }
            }


            return QtySum;
        }

        public void AddNew(List<InterimsItemsRow> InterimsList)
        {
            // Add Assessment Head
            InterimsHeadTableAdapter.Connection.Open();
            MasterData.Database.InterimsHead.Rows.Add(InterimsHeadRow.ItemArray);
            InterimsHeadTableAdapter.Update(MasterData.Database);
            InterimsHeadTableAdapter.Adapter.Update(MasterData.Database.InterimsHead);
            MasterData.Database.InterimsHead.AcceptChanges();
            InterimsHeadTableAdapter.GetData();
            InterimsHeadTableAdapter.Connection.Close();

            // Add Assessment Items
            InterimsItemsTableAdapter.Connection.Open();
            // Get Assessment ID
            int ID = MasterData.Database.InterimsHead.
                Where(r => r.ContractID == InterimsHeadRow.ContractID).Max(r => r.ID);
            foreach (var Item in InterimsList)
            {
                Item.HeadID = ID;
                MasterData.Database.InterimsItems.Rows.Add(Item.ItemArray);
            }
            InterimsItemsTableAdapter.Update(MasterData.Database);
            InterimsItemsTableAdapter.Adapter.Update(MasterData.Database.InterimsItems);
            MasterData.Database.InterimsItems.AcceptChanges();
            MasterData.Database.AcceptChanges();
            InterimsItemsTableAdapter.Connection.Close();

            // Insert Log Activity
            Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Interims ID : " + ID + " was created";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);

            // refresh Data List
            RefreshList();
        }

        public void RefreshList()
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

        public void Confirm(int IntermID)
        {
            InterimsHeadTableAdapter.Connection.Open();
            var C = InterimsHeadDataTable.FindByID(IntermID);
            C.Confirm_Date = DateTime.Now;
            InterimsHeadTableAdapter.Update(MasterData.Database);
            InterimsHeadTableAdapter.Adapter.Update(InterimsHeadDataTable);
            InterimsHeadDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            InterimsHeadTableAdapter.Connection.Close();

            // Insert Log Activity
            Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Interim : " + IntermID + " was Confirmed";
            Row.ActivityDate = DateTime.Now;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            MasterData.LogActivity.AddNew(Row);
        }

    }
}
