using Horas_Reporting_2.Datasets;
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
using static Horas_Reporting_2.DataSet1;

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
            MasterData.RefreshAssList();
            MasterData.RefreshPartyList();

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
                    { IntTable.Number, IntTable.ID, IntTable.In_Date };


            foreach (var W in Q.ToList())
            {
                double Total = MasterData.InterimsItemsDataTable.Where(X => X.HeadID == W.ID).Sum(Y => Y.Qty * Y.Price_Unit);
                double Count = MasterData.InterimsItemsDataTable.Where(X => X.HeadID == W.ID).Count();
                Original.Rows.Add(W.Number, W.In_Date.ToShortDateString(), Count, MasterData.NumericString(Total));
            }

            FRMInterimContract Form = new FRMInterimContract(Original, ContNumber, ConDesc);
            Form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;
            string Cont_Number = comboBox1.SelectedItem.ToString();
            int Cont_ID = MasterData.ContractDataTable.FirstOrDefault(X => X.Number == Cont_Number).ID;
            ContractRow ContractObject =
                MasterData.ContractDataTable.FirstOrDefault(X => X.Number == Cont_Number);
            List<AssItemsRow> ItemDataTabble =
                MasterData.AssItemsDataTable.Where(X => !X.IsContract_IDNull() && X.Contract_ID == Cont_ID).ToList();

            FRMContract Form = new FRMContract(ContractObject, ItemDataTabble);
            Form.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;
            string Cont_Number = comboBox1.SelectedItem.ToString();
            int Cont_ID = MasterData.ContractDataTable.FirstOrDefault(X => X.Number == Cont_Number).ID;

            var Q = from ExpTable in MasterData.ExpTrDataTable
                    join ConTable in MasterData.ContractDataTable on ExpTable.ContractID equals ConTable.ID
                    join SecExpTable in MasterData.IExpansesDateTable on ExpTable.ExpID equals SecExpTable.ID
                    join PRExpsTable in MasterData.JExpansesDateTable on SecExpTable.HeadID equals PRExpsTable.ID
                    join ItemTable in MasterData.AssItemsDataTable on ExpTable.ItemNo equals ItemTable.ID
                    where ConTable.ID == Cont_ID && ExpTable.NeedConf == false
                    select new
                    {
                        ExpTable.Amount,
                        ExpTable.Description,
                        MinorEx = SecExpTable.Title,
                        PRExpsTable.Title,
                        ExpTable.Tr_Date,
                        IT_Desc = ItemTable.Description,
                        ItemTable.Number
                    };

            DS_EXPS.DT_EXPSDataTable Data_ = new DS_EXPS.DT_EXPSDataTable();
            DataTable DATA = new DataTable();
            foreach (var column in Data_.Columns)
                DATA.Columns.Add(column.ToString(), typeof(string));

            double Sum = 0;

            foreach (var Row in Q.ToList())
            {
                DATA.Rows.Add(MasterData.NumericString(Row.Amount), Row.Description, Row.Tr_Date.ToShortDateString()
                , string.Empty, Row.Number, Row.Title, Row.MinorEx);
                Sum += Row.Amount;
            }
            string Desc = MasterData.ContractDataTable.FirstOrDefault(X => X.Number == Cont_Number).Short_Desc;
            FRMContExps Form = new FRMContExps(DATA, Sum, Desc, Cont_Number);
            Form.ShowDialog();

        }
    }
}
