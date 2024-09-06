using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using HORAS.SuppliersAndClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;
using Windows.Gaming.Input.ForceFeedback;

namespace HORAS.Contracts
{
    public class Contract
    {

        public ContractTableAdapter ContractTableAdapter = new ContractTableAdapter();
        public HorasDataSet.ContractDataTable ContractDataTable = new HorasDataSet.ContractDataTable();

        public ExpansesMajorTableAdapter JExpansesAdapter = new ExpansesMajorTableAdapter();
        public ExpansesMajorDataTable JExpansesDateTable = new ExpansesMajorDataTable();

        public ExpansesMinorTableAdapter IExpansesAdapter = new ExpansesMinorTableAdapter();
        public ExpansesMinorDataTable IExpansesDateTable = new ExpansesMinorDataTable();

        public ExpTransTableAdapter ExpTrAdapter = new ExpTransTableAdapter();
        public ExpTransDataTable ExpTrDataTable = new ExpTransDataTable();

        public BGLTableAdapter BGLAdapter = new BGLTableAdapter();
        public BGLDataTable BGLDataTable = new BGLDataTable();

        #region properties
        public int ID { get; set; }
        //public assessment assessment { get; set; } = new assessment();
        public int Duration { set; get; } // in Months
        public float DelaypenaltyP { set; get; } // Percentage
        public double Totall_Amount { set; get; }
        public int FirstParty { set; get; }
       // public int SecondParty { set; get; }
        public DateTime CreationDate { set; get; }
        public DateTime StartDate { set; get; }
        public int StartedBy { set; get; }
        public int CreatedBy { set; get; }
        public float DownpaymentP { set; get; } // Percentage
        public float BusinessInsuranceP { set; get; } // Percentage
        public float InterimsPeriod { set; get; }  // weakly
        public string ContractAttach_1 { set; get; }
        public string ContractAttach_2 { set; get; }
        public string Number { set; get; }
        public string S_Desc { set; get; }
        public string L_Desc { set; get; }
        public bool Signed { set; get; } = false;
        #endregion

        #region Methods

        public void AddNew(HorasDataSet.ContractRow Contract,List<AssItemsRow> ItemList)
        {
            ContractTableAdapter.Connection.Open();
            MasterData.Database.Contract.Rows.Add(Contract.ItemArray);
            ContractTableAdapter.Update(MasterData.Database);
            ContractTableAdapter.Adapter.Update(MasterData.Database.Contract);
            MasterData.Database.Contract.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ContractTableAdapter.Connection.Close();
            int ContractID = MasterData.Database.Contract.Select(i => i.ID).Max();
            MasterData.assessments.AssignItemsToContract(ContractID, ItemList);

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Contract : " + Contract.Number + " was created";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public int AddNew(HorasDataSet.ContractRow Contract)
        {
            ContractTableAdapter.Connection.Open();
            MasterData.Database.Contract.Rows.Add(Contract.ItemArray);
            ContractTableAdapter.Update(MasterData.Database);
            ContractTableAdapter.Adapter.Update(MasterData.Database.Contract);
            MasterData.Database.Contract.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ContractTableAdapter.Connection.Close();
            int ContractID = MasterData.Database.Contract.Select(i => i.ID).Max();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Contract : " + Contract.Number + " was created";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);

            return ContractID;
        }

        public void Start(HorasDataSet.ContractRow Contract)
        {
            ContractTableAdapter.Connection.Open();
            var C = ContractDataTable.FindByID(Contract.ID);
            C.StartDate = Contract.StartDate;
            C.StartedBy = Contract.StartedBy;
            ContractTableAdapter.Update(MasterData.Database);
            ContractTableAdapter.Adapter.Update(ContractDataTable);
            ContractDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ContractTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Contract : " + Contract.ID + " was Started Implementation";
            Row.ActivityDate = DateTime.Now;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            MasterData.LogActivity.AddNew(Row);
        }

        public void Sign(int ContractID)
        {
            ContractTableAdapter.Connection.Open();
            var C = ContractDataTable.FindByID(ContractID);
            C.Signed = true;
            ContractTableAdapter.Update(MasterData.Database);
            ContractTableAdapter.Adapter.Update(ContractDataTable);
            ContractDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ContractTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Contract : " + ContractID + " was Signed";
            Row.ActivityDate = DateTime.Now;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            MasterData.LogActivity.AddNew(Row);
        }

        public void CLose_FU(int ContractID)
        {
            ContractTableAdapter.Connection.Open();
            var C = ContractDataTable.FindByID(ContractID);
            C.FI_Completed = true;
            ContractTableAdapter.Update(MasterData.Database);
            ContractTableAdapter.Adapter.Update(ContractDataTable);
            ContractDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ContractTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Contract : " + ContractID + " was Financialy Closed";
            Row.ActivityDate = DateTime.Now;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            MasterData.LogActivity.AddNew(Row);
        }

        public void CLose_Technical(int ContractID)
        {
            ContractTableAdapter.Connection.Open();
            var C = ContractDataTable.FindByID(ContractID);
            C.IM_Completed = true;
            ContractTableAdapter.Update(MasterData.Database);
            ContractTableAdapter.Adapter.Update(ContractDataTable);
            ContractDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ContractTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Contract : " + ContractID + " implementation finished";
            Row.ActivityDate = DateTime.Now;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            MasterData.LogActivity.AddNew(Row);
        }

        public int AddExp(HorasDataSet.ExpTransRow Exp,string ContractNumber)
        {
            ExpTrAdapter.Connection.Open();
            MasterData.Database.ExpTrans.Rows.Add(Exp.ItemArray);
            ExpTrAdapter.Update(MasterData.Database);
            ExpTrAdapter.Adapter.Update(MasterData.Database.ExpTrans);
            MasterData.Database.ExpTrans.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ExpTrAdapter.Connection.Close();

            ExpTrAdapter.Connection.Open();
            ExpTrAdapter.GetData();
            ExpTrAdapter.Fill(ExpTrDataTable);
            ExpTrAdapter.Connection.Close();


            int ExpsID = MasterData.Contracts.ExpTrDataTable.Max(X => X.ID);
            

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses for contract : " + ContractNumber + " was created";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
            return ExpsID;
        }

        public void DeleteExp(int ID,string ContratNumber)
        {
            ExpTrAdapter.Connection.Open();
            var C = ExpTrDataTable.FindByID(ID);
            ExpTrDataTable.RemoveExpTransRow(C);
            ExpTrAdapter.DeleteExps(ID);
            ExpTrAdapter.Update(MasterData.Database);
            ExpTrAdapter.Adapter.Update(ExpTrDataTable);
            ExpTrDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ExpTrAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses related to contract : " + ContratNumber + " was Deleted";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void UpdateExps(HorasDataSet.ExpTransRow Exp,string ContractNumber)
        {
            ExpTrAdapter.Connection.Open();
            var C = ExpTrDataTable.FindByID(Exp.ID);
            C.Amount = Exp.Amount;
            C.Description = Exp.Description;
            C.ExpID = Exp.ExpID;
            C.NeedConf = Exp.NeedConf;
            ExpTrAdapter.Update(MasterData.Database);
            ExpTrAdapter.Adapter.Update(ExpTrDataTable);
            ExpTrDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ExpTrAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses related to Contract : " + ContractNumber + " was Updated";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void ConfirmExps(int ExpID)
        {
            ExpTrAdapter.Connection.Open();
            var C = ExpTrDataTable.FindByID(ExpID);
            C.NeedConf = false;
            ExpTrAdapter.Update(MasterData.Database);
            ExpTrAdapter.Adapter.Update(ExpTrDataTable);
            ExpTrDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            ExpTrAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses with ID"+ ExpID + " was Confirmed";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public bool LOLCheckOK(double Amount, string ContractNumber , string ItemNumber)
        {
            int ContractID = ContractDataTable.FirstOrDefault(X => X.Number == ContractNumber).ID;
            int ItemID = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault
               (X => X.Contract_ID == ContractID && X.Number == ItemNumber).ID;

            AssItemsRow ItemData = MasterData.assessments.AssItemsAdapter.NotNullContracts().
                FirstOrDefault(X => X.Contract_ID == ContractID && X.ID == ItemID);

            double MaximumAllowed = ItemData.LOL * ItemData.Total_Price * ItemData.Qty; 

            double TotalExps = (double)MasterData.Contracts.ExpTrDataTable.
                            Where(X => X.ContractID == ContractID 
                            && X.ItemNo == ItemID && !X.NeedConf).Sum(Y => Y.Amount);

            if ((Amount + TotalExps) > MaximumAllowed) return true;
            else
                return false;

        }

        public double TotalInterimsValue(string ContractNumber)
        {
            int SelectedContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == ContractNumber).ID;

            double Sum = 0;

            var InterimsList = MasterData.Interim.InterimsHeadDataTable.Where(X => X.ContractID == SelectedContractID && !X.IsConfirm_DateNull());
            foreach (var Interim in InterimsList)
                Sum += MasterData.Interim.InterimsItemsDataTable.Where(X => X.HeadID == Interim.ID).Sum(Y => Y.Price_Unit * Y.Qty);
            return Sum;
        }


        public double GetRemainingItem(string OwnerContractNumber ,string ItemNumber)
        {
            // Get Total Qty in Owner Assessment
            int OwnerContractID = MasterData.Contracts.ContractDataTable.First(X => X.Number == OwnerContractNumber).ID;
            double ItemTotalQty = MasterData.assessments.AssItemsDataTable.FirstOrDefault(X => X.Number == ItemNumber && X.Contract_ID == OwnerContractID).Qty;

            var ContractsList = MasterData.Contracts.ContractTableAdapter.GetOwnerContractors(OwnerContractID);

            double Sum = 0;

            foreach (var Cont in ContractsList)
            {
                var Item = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault(X => X.Number == ItemNumber && X.Contract_ID == Cont.ID);
                if (Item != null)
                    Sum += Item.Qty;

            }
             //   Sum += MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault(X => X.Number == ItemNumber && X.Contract_ID == Cont.ID).Qty;

            //foreach (var Cont in ContractsList)
            //    Sum += MasterData.assessments.AssItemsDataTable.FirstOrDefault(X => X.Number == ItemNumber && X.Contract_ID == Cont.ID).Qty;

            return (ItemTotalQty - Sum);

        }

        public void AddNewBGL(HorasDataSet.BGLRow BGL_Contract)
        {
            BGLAdapter.Connection.Open();
            MasterData.Database.BGL.Rows.Add(BGL_Contract.ItemArray);
            BGLAdapter.Update(MasterData.Database);
            BGLAdapter.Adapter.Update(MasterData.Database.BGL);
            MasterData.Database.BGL.AcceptChanges();
            MasterData.Database.AcceptChanges();
            BGLAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Bank Gurantee Letter : " + BGL_Contract.Serial + " was created";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void DeleteBGL(int ID)
        {
            BGLAdapter.Connection.Open();
            var C = BGLDataTable.FindByID(ID);

            string FilePath = MasterData.GetFile((char)Document_Type.BankGuranteeLetter + "_" + C.Serial);
            if (FilePath != string.Empty)
                File.Delete(FilePath);

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Bank Gurantee Letter : " + C.Serial + " was Deleted";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);

            BGLDataTable.RemoveBGLRow(C);
            BGLAdapter.DeleteBGL(ID);
            BGLAdapter.Update(MasterData.Database);
            BGLAdapter.Adapter.Update(BGLDataTable);
            BGLDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            BGLAdapter.Connection.Close();
        }

        public void AddExpsCategory(HorasDataSet.ExpansesMajorRow MajorRow)
        {
            MasterData.Contracts.JExpansesAdapter.Connection.Open();
            MasterData.Database.ExpansesMajor.Rows.Add(MajorRow.ItemArray);
            MasterData.Contracts.JExpansesAdapter.Update(MasterData.Database);
            MasterData.Contracts.JExpansesAdapter.Adapter.Update(MasterData.Database.ExpansesMajor);
            MasterData.Database.ExpansesMajor.AcceptChanges();
            MasterData.Database.AcceptChanges();
            MasterData.Contracts.JExpansesAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses Category : " + MajorRow.Title + " was Added";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void UpdateExpsCategory(HorasDataSet.ExpansesMajorRow MajorRow)
        {
            JExpansesAdapter.Connection.Open();
            var C = JExpansesDateTable.FindByID(MajorRow.ID);
            C.Title = MajorRow.Title;
            JExpansesAdapter.Update(MasterData.Database);
            JExpansesAdapter.Adapter.Update(JExpansesDateTable);
            JExpansesDateTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            JExpansesAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses Category was Updated";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void UpdateExpsTitle(HorasDataSet.ExpansesMinorRow MaiorRow)
        {
            IExpansesAdapter.Connection.Open();
            var C = IExpansesDateTable.FindByID(MaiorRow.ID);
            C.Title = MaiorRow.Title;
            C.Direct_InDirect = MaiorRow.Direct_InDirect;
            IExpansesAdapter.Update(MasterData.Database);
            IExpansesAdapter.Adapter.Update(IExpansesDateTable);
            IExpansesDateTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            IExpansesAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses Title was Updated";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void AddExpsTitle(HorasDataSet.ExpansesMinorRow MinorRow)
        {
            MasterData.Contracts.IExpansesAdapter.Connection.Open();
            MasterData.Database.ExpansesMinor.Rows.Add(MinorRow.ItemArray);
            MasterData.Contracts.IExpansesAdapter.Update(MasterData.Database);
            MasterData.Contracts.IExpansesAdapter.Adapter.Update(MasterData.Database.ExpansesMinor);
            MasterData.Database.ExpansesMinor.AcceptChanges();
            MasterData.Database.AcceptChanges();
            MasterData.Contracts.IExpansesAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Expanses Title : " + MinorRow.Title + " was Added";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }


        public void RefreshList()
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

            BGLAdapter.Connection.Open();
            BGLAdapter.GetData();
            BGLAdapter.Fill(BGLDataTable);
            BGLAdapter.Connection.Close();
        }
        #endregion
    }
}
