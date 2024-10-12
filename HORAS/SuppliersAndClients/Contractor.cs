using HORAS.Database.HorasDataSetTableAdapters;
using HORAS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS.SuppliersAndClients
{
    public class Contractor
    {
        public PartyTableAdapter PartyTableAdapter = new PartyTableAdapter();
        public PartyDataTable PartyDataTable = new PartyDataTable();
        #region properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string TaxDocument { set; get; }
        public string Address { get; set; }
        public string TaxRegNumber { get; set; }
        #endregion

        #region Methods

        public void AddNew(PartyRow Party)
        {
            PartyTableAdapter.Connection.Open();
            MasterData.Database.Party.Rows.Add(Party.ItemArray);
            PartyTableAdapter.Update(MasterData.Database);
            PartyTableAdapter.Adapter.Update(MasterData.Database.Party);
            MasterData.Database.Party.AcceptChanges();
            MasterData.Database.AcceptChanges();
            PartyTableAdapter.Connection.Close();

            // Insert Log Activity
            Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = @"تم انشاء مورد\عميل رقم" + Party.ID ;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void Update(PartyRow Party)
        {
            PartyTableAdapter.Connection.Open();
            var C = PartyDataTable.FindByID(Party.ID);
            C.Name = Party.Name;
            C.TaxRegNumber = Party.TaxRegNumber;
            C.Address = Party.Address;
            C.Phone = Party.Phone;
            C.TaxDocument = Party.TaxDocument;
            PartyTableAdapter.Update(MasterData.Database);
            PartyTableAdapter.Adapter.Update(PartyDataTable);
            PartyDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            PartyTableAdapter.Connection.Close();

            // Insert Log Activity
            Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "تم تحديث بيانات مورد/عميل رقم:  " + Party.ID ;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void Delete(int ID)
        {
            PartyTableAdapter.Connection.Open();
            var C = PartyDataTable.FindByID(ID);
            C.Delete();
            PartyDataTable.RemovePartyRow(C);
            PartyTableAdapter.Update(MasterData.Database);
            PartyTableAdapter.Adapter.Update(PartyDataTable);
            PartyDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            PartyTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "تم مسح مورد/ عميل رقم : " + ID ;
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void RefreshList()
        {
            PartyTableAdapter.Connection.Open();
            PartyTableAdapter.GetData();
            PartyTableAdapter.Fill(PartyDataTable);
            PartyTableAdapter.Connection.Close();
        }
        #endregion
    }
}
