using Horas_Reporting_2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas_Reporting_2.Interims
{
    public partial class InterimWithDate : Form
    {
        DataTable Original = new DataTable();
        public InterimWithDate()
        {
            InitializeComponent();
            MasterData.RefreshContractsList();
            MasterData.RefreshInterimsList();
            
            Original.Columns.Add("Contract_Number", typeof(string));
            Original.Columns.Add("Number_", typeof(string));
            Original.Columns.Add("Date_", typeof(string));
            Original.Columns.Add("Items_Num", typeof(string));
            Original.Columns.Add("Total", typeof(string));

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var Q = from ContTable in MasterData.ContractDataTable
                    join IntTable in MasterData.InterimsHeadDataTable
                    on ContTable.ID equals IntTable.ContractID
                    where IntTable.In_Date >= DTP_From.Value &&
                    IntTable.In_Date <= DTP_To.Value && !IntTable.IsConfirm_DateNull()
                    select new 
                    {Contract = ContTable.Number ,Int = IntTable.Number , IntTable.ID , IntTable.In_Date } ;

            foreach (var W in Q.ToList())
            {
                double Total = MasterData.InterimsItemsDataTable.Where(X => X.HeadID == W.ID).Sum(Y => Y.Qty * Y.Price_Unit);
                double Count = MasterData.InterimsItemsDataTable.Where(X => X.HeadID == W.ID).Count();
                Original.Rows.Add(W.Contract,W.Int,W.In_Date.ToShortDateString(),Count,MasterData.NumericString(Total));
            }

            FRMInterim Form = new FRMInterim(Original, DTP_From.Value, DTP_To.Value);
            Form.ShowDialog();

        }
    }
}
