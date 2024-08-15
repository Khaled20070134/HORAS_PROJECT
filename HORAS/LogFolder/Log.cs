using HORAS.Database.HorasDataSetTableAdapters;
using HORAS.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Enums;

namespace HORAS.LogFolder
{
    public class LogClass
    {
        #region Database
        public Log_TableTableAdapter LogTableAdapter = new Log_TableTableAdapter();
        public HorasDataSet.Log_TableDataTable LogDataTable = new HorasDataSet.Log_TableDataTable();
        #endregion

        #region Properties
        public const int ID = 0;
        public int User_ID { set; get; }
        public string Description { set; get; }
        public ActivityMode Mode { set; get; }
        public DateTime Date { set; get; } = DateTime.Now;
        #endregion

        #region Methods

        public void AddNew(HorasDataSet.Log_TableRow Log)
        {
            LogTableAdapter.Connection.Open();
            MasterData.Database.Log_Table.Rows.Add(Log.ItemArray);
            LogTableAdapter.Update(MasterData.Database);
            LogTableAdapter.Adapter.Update(MasterData.Database.Log_Table);
            MasterData.Database.Log_Table.AcceptChanges();
            MasterData.Database.AcceptChanges();
            LogTableAdapter.Connection.Close();
        }

        public void RefreshList()
        {
            LogTableAdapter.Connection.Open();
            LogTableAdapter.GetData();
            LogTableAdapter.Fill(LogDataTable);
            LogTableAdapter.Connection.Close();
        }
        #endregion
    }
}
