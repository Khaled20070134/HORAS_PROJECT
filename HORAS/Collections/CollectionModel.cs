using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Enums;

namespace HORAS.Collections
{
    public class CollectionModel
    {
        public CollectionsTableAdapter CollectionAdapter = new CollectionsTableAdapter();
        public HorasDataSet.CollectionsDataTable CollectionsDataTable = new HorasDataSet.CollectionsDataTable();

       public double GetTotalDownPayment(string contractNum)
        {
            int id = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == contractNum).ID;

            double Amount = MasterData.Collections.CollectionsDataTable.
                Where(x => x.Contract_ID == id && x.Col_Type == (int)CollectionType.DownPayment).Sum(Y=>Y.Amount);

            return Amount;
        }
        public double GetTotalInvCollections(string contractNum)
        {
            int id = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == contractNum).ID;

            double Amount = MasterData.Collections.CollectionsDataTable.
                Where(x => x.Contract_ID == id && x.Col_Type == (int)CollectionType.SalesInvoiceing).Sum(Y => Y.Amount);

            return Amount;
        }

        public double GetTotalCollections(string ContractNum)
        {
            return (GetTotalInvCollections(ContractNum) + GetTotalDownPayment(ContractNum));
        }

        public void RefreshList()
        {
            CollectionAdapter.Connection.Open();
            CollectionAdapter.GetData();
            CollectionAdapter.Fill(CollectionsDataTable);
            CollectionAdapter.Connection.Close();
        }

        public void AddNewCollection(HorasDataSet.CollectionsRow Collection)
        {
            CollectionAdapter.Connection.Open();
            MasterData.Database.Collections.Rows.Add(Collection.ItemArray);
            CollectionAdapter.Update(MasterData.Database);
            CollectionAdapter.Adapter.Update(MasterData.Database.Collections);
            MasterData.Database.Collections.AcceptChanges();
            MasterData.Database.AcceptChanges();
            CollectionAdapter.Connection.Close();

            string ContractNumber = MasterData.Contracts.ContractDataTable.FindByID(Collection.Contract_ID).Number;

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Collection to Contract : " + ContractNumber + " was Added";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }
    }
}
