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
    public partial class InterimWithContract : Form
    {
        DataTable Original = new DataTable();
        public InterimWithContract()
        {
            InitializeComponent();
            MasterData.RefreshContractsList();
            MasterData.RefreshInterimsList();

            Original.Columns.Add("Number_", typeof(string));
            Original.Columns.Add("Date_", typeof(string));
            Original.Columns.Add("Items_Num", typeof(string));
            Original.Columns.Add("Total", typeof(string));


            MasterData.RefreshContractsList();
            foreach (var Row in MasterData.ContractDataTable.ToList())
            {
                if (Row.Signed) comboBox1.Items.Add(Row.Number);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            string ContNumber = comboBox1.SelectedItem as string;
            int ContID = MasterData.ContractDataTable.FirstOrDefault(X => X.Number == ContNumber).ID;

            string ConDesc = MasterData.ContractDataTable.FindByID(ContID).Short_Desc;

                var Q = from ContTable in MasterData.ContractDataTable
                    join IntTable in MasterData.InterimsHeadDataTable
                    on ContTable.ID equals IntTable.ContractID
                    where IntTable.ContractID == ContID && !IntTable.IsConfirm_DateNull()
                    select new
                    {  IntTable.Number, IntTable.ID, IntTable.In_Date };


            foreach (var W in Q.ToList())
            {
                double Total = MasterData.InterimsItemsDataTable.Where(X => X.HeadID == W.ID).Sum(Y => Y.Qty * Y.Price_Unit);
                double Count = MasterData.InterimsItemsDataTable.Where(X => X.HeadID == W.ID).Count();
                Original.Rows.Add( W.Number, W.In_Date.ToShortDateString(), Count, MasterData.NumericString(Total));
            }

            FRMInterimContract Form = new FRMInterimContract(Original,ContNumber, ConDesc);
            Form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
