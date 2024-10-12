using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using HORAS.Interims_Data;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS
{
    public class assessment
    {
        public AssessmentHeadTableAdapter AssessmentHeadTableAdapter = new AssessmentHeadTableAdapter();
        public AssessmentHeadDataTable AssessmentHeadDataTable = new AssessmentHeadDataTable();
        public AssessmentHeadRow AssessmentRow;
        public AssItemsRow AssItemsRow;

        public AssItemsTableAdapter AssItemsAdapter = new AssItemsTableAdapter();
        public AssItemsDataTable AssItemsDataTable = new AssItemsDataTable();
        public AssItemsDataTable NotNullContracts = new AssItemsDataTable();
        public int ID { get; set; }
        public List<Interims> Interims { get; set; }
        public List<Items> Items { get; set; }
        public bool Confirmed { get; set; } = false;
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public int ConfirmedBy { set; get; }
        public string Subject { set; get; }
        public string About { set; get; }
        public bool Assigned { set; get; }

        #region Methods

        public int AddNew(List<AssItemsRow> ItemsList)
        {
            // Add Assessment Head
            AssessmentHeadTableAdapter.Connection.Open();
            MasterData.Database.AssessmentHead.Rows.Add(AssessmentRow.ItemArray);
            AssessmentHeadTableAdapter.Update(MasterData.Database);
            AssessmentHeadTableAdapter.Adapter.Update(MasterData.Database.AssessmentHead);
            MasterData.Database.AssessmentHead.AcceptChanges();
            AssessmentHeadTableAdapter.Connection.Close();

            // Add Assessment Items
            AssItemsAdapter.Connection.Open();
            // Get Assessment ID
            int ID = MasterData.Database.AssessmentHead.FirstOrDefault
                (X => X.Subject == AssessmentRow.ItemArray[4].ToString()
                && X.About == AssessmentRow.ItemArray[5].ToString()).ID;
            foreach (var Item in ItemsList)
            {
                Item.AssID = ID;
                MasterData.Database.AssItems.Rows.Add(Item.ItemArray);
            }
            AssItemsAdapter.Update(MasterData.Database);
            AssItemsAdapter.Adapter.Update(MasterData.Database.AssItems);
            MasterData.Database.AssItems.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssItemsAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "تم انشاء مقايسة رقم: " + ID ;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);

            // Return Ass Head ID
            return ID;
        }

        // Update Items of Assessments to set LOL Percentage foreach item
        public void UpdateItems(int AssID, List<AssItemsRow> Items)
        {
            AssItemsAdapter.Connection.Open();
            List<AssItemsRow> List = AssItemsDataTable.Where(X => X.AssID == AssID).ToList();
            foreach (var Item in Items)
            {
                AssItemsDataTable.Rows.Remove(AssItemsDataTable.FirstOrDefault(x => x.AssID == AssID));
                AssItemsAdapter.DeleteItem(AssID);
            }
            foreach (var Item in Items)
                AssItemsDataTable.Rows.Add(Item.ItemArray);



            AssItemsAdapter.Update(MasterData.Database);
            AssItemsAdapter.Adapter.Update(AssItemsDataTable);
            AssItemsDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssItemsAdapter.Connection.Close();
            AssItemsAdapter.DeleteItem(6);
        }

        void Update(AssessmentHeadRow Assessment)
        {
            AssessmentHeadTableAdapter.Connection.Open();
            AssessmentHeadTableAdapter.GetData();

            var C = MasterData.Database.AssessmentHead.FindByID(Assessment.ID);
            C = Assessment;
            AssessmentHeadTableAdapter.Update(MasterData.Database);
            AssessmentHeadTableAdapter.Adapter.Update(MasterData.Database.AssessmentHead);
            MasterData.Database.AssessmentHead.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssessmentHeadTableAdapter.Connection.Close();
        }

        public void Delete_Ass(int AssID)
        {
            // Delete Ass. Items First

            AssItemsAdapter.Connection.Open();
            AssItemsAdapter.DeleteAssItems(AssID);
            AssItemsAdapter.Update(MasterData.Database);
            AssItemsAdapter.Adapter.Update(MasterData.assessments.AssItemsDataTable);
            AssItemsDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssItemsAdapter.Connection.Close();

            AssessmentHeadTableAdapter.Connection.Open();
            AssessmentHeadTableAdapter.Delete_Ass_Head(AssID);
            AssessmentHeadTableAdapter.Update(MasterData.Database);
            AssessmentHeadTableAdapter.Adapter.Update(MasterData.assessments.AssessmentHeadDataTable);
            AssessmentHeadDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssessmentHeadTableAdapter.Connection.Close();
        }

        public Items GetItemData(int ContractID, string ItemNumber, Items NewItem)
        {
            //Items NewItem = new Items();
            NewItem.ContractID = ContractID;
            NewItem.Number = ItemNumber;
            //var Item = MasterData.assessments.AssItemsDataTable.
            //    FirstOrDefault(X => X.Contract_ID == ContractID && X.Number == ItemNumber);


            var Result = AssItemsDataTable.Where(X => !X.IsContract_IDNull() && X.Number == ItemNumber).ToList();
            foreach (var Item_ in Result)
            {
                if (Item_.Contract_ID == NewItem.ContractID)
                {
                    NewItem.AssTotalQty = Item_.Qty;
                    NewItem.Dexcription = Item_.Description;
                    NewItem.Type = (Item_TYPE)Item_.Item_Type;
                    NewItem.Item_Unit = Item_.Item_Unit;
                    NewItem.Ass_Price_Unit = (float)Item_.Total_Price;
                }

            }



            return NewItem;

        }

        public void RefreshList()
        {
            AssessmentHeadTableAdapter.Connection.Open();
            AssessmentHeadTableAdapter.GetData();
            AssessmentHeadTableAdapter.Fill(AssessmentHeadDataTable);
            AssessmentHeadTableAdapter.Connection.Close();

            AssItemsAdapter.Connection.Open();
            AssItemsAdapter.GetData();
            AssItemsAdapter.Fill(AssItemsDataTable);
            AssItemsAdapter.Connection.Close();

            NotNullContracts = AssItemsAdapter.NotNullContracts();
        }

        public void AssignItemsToContract(int ContractID, List<AssItemsRow> ItemList)
        {
            AssItemsAdapter.Connection.Open();
            AssItemsAdapter.GetData();
            foreach (AssItemsRow ItemRow in ItemList)
            {
                var List = AssItemsDataTable.
                    Where(x => x.AssID == ItemRow.AssID && x.Number == ItemRow.Number).ToList();

                foreach (var item in List)
                    item.Contract_ID = ContractID;
            }

            AssItemsAdapter.Update(MasterData.Database);
            AssItemsAdapter.Adapter.Update(AssItemsDataTable);
            MasterData.Database.AssItems.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssItemsAdapter.Connection.Close();

        }

        public void Reset_AssItems(int ContractID)
        {
            MasterData.assessments.AssItemsAdapter.Connection.Open();
            MasterData.assessments.AssItemsAdapter.Reset_Items(ContractID);
            MasterData.assessments.AssItemsAdapter.Update(MasterData.Database);
            MasterData.assessments.AssItemsAdapter.Adapter.Update(MasterData.assessments.AssItemsDataTable);
            MasterData.assessments.AssItemsDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            MasterData.assessments.AssItemsAdapter.Connection.Close();
        }





        public void Confirm(int ID)
        {
            AssessmentHeadTableAdapter.Connection.Open();
            AssessmentHeadTableAdapter.GetData();

            var C = AssessmentHeadDataTable.FindByID(ID);
            C.Confirmed = true;
            C.ConfirmedBy = MasterData.LoggedEmployee.ID;
            AssessmentHeadTableAdapter.Update(MasterData.Database);
            AssessmentHeadTableAdapter.Adapter.Update(AssessmentHeadDataTable);
            AssessmentHeadDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            AssessmentHeadTableAdapter.Connection.Close();

            // Insert Log Activity
            Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "تم تأكيد مقايسة رقم" + ID ;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public double GetItemLOLValue(string ContractNumber, string ItemNumber)
        {
            double Value = 0;
            int ContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == ContractNumber).ID;

            int ItemID = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault
                (X => X.Contract_ID == ContractID && X.Number == ItemNumber).ID;

            AssItemsRow ItemRow = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault
                (X => X.Contract_ID == ContractID && X.ID == ItemID);

            return (ItemRow.Qty * ItemRow.Total_Price * ItemRow.LOL);
        }

        public double GetItemLOLPer(string ContractNumber, string ItemNumber)
        {
            double Value = 0;
            int ContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == ContractNumber).ID;

            int ItemID = MasterData.assessments.AssItemsDataTable.FirstOrDefault
                (X => X.Contract_ID == ContractID && X.Number == ItemNumber).ID;

            return MasterData.assessments.AssItemsDataTable.FirstOrDefault
                 (X => X.Contract_ID == ContractID && X.ID == ItemID).LOL;
        }
        #endregion
    }
}