using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using HORAS.Properties;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HORAS.Database.HorasDataSet;
using HORAS.Contracts;

namespace HORAS.Interims_Data
{

    public partial class InterimsEntry : Form
    {
        int SelectedContrctID, SelectedItemID;
        List<InterimsItemsRow> ListToSave = new List<InterimsItemsRow>();
        List<Items> LoadedItemsList = new List<Items>();
        InterimsItemsRow ItemRow;
        public InterimsEntry()
        {
            InitializeComponent();
            LoadContracts();
        }
        void LoadContracts()
        {
            var LoadContracts = MasterData.Contracts.ContractDataTable.
                Where(X => X.IM_Completed == false && X.Signed && !X.IsStartedByNull()).ToList();
            foreach (var Con in LoadContracts)
                CBContracts.Items.Add(Con.Number);
        }

        void LoadItems()
        {
            ListToSave.Clear();
            int StartItemIndex = 0;
            if (MasterData.Interim.InterimsItemsDataTable.Count > 0)
                StartItemIndex = MasterData.Interim.InterimsItemsDataTable.Max(X => X.ID) + 1;

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                ItemRow = MasterData.Interim.InterimsItemsDataTable.NewInterimsItemsRow();
                ItemRow.ID = StartItemIndex;
                ItemRow.Number = DGV.Rows[i].Cells[0].Value.ToString();
                //ItemRow.HeadID = ContractID;
                ItemRow.Price_Unit = double.Parse(DGV.Rows[i].Cells[2].Value.ToString());
                ItemRow.Qty = double.Parse(DGV.Rows[i].Cells[1].Value.ToString());
                ItemRow.IsBilled = false;
                ListToSave.Add(ItemRow);
                StartItemIndex++;
            }
        }

        private void CBContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBContracts.SelectedIndex == -1) return;
            labelDesc.Text = MasterData.Contracts.ContractDataTable.
                 FirstOrDefault(x => x.Number == CBContracts.SelectedItem.ToString()).Short_Desc;

            SelectedContrctID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == CBContracts.SelectedItem.ToString()).ID;
            comboBoxItems.Items.Clear();
            var ItemsList = MasterData.assessments.AssItemsAdapter.GetContractItems(SelectedContrctID);
            foreach (var Item in ItemsList)
                comboBoxItems.Items.Add(Item.Number);
        }

        private void comboBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxItems.SelectedIndex == -1) return;
            I_Status Item_Status = MasterData.Interim.Get_Item_Status(CBContracts.SelectedItem.ToString(),
                comboBoxItems.SelectedItem.ToString());
            LoadData(Item_Status);

        }
        void LoadData(I_Status Item_Status)
        {
            labelTotalQty.Text = MasterData.NumericString(Item_Status.Total_QP);
            labelTotalValue.Text = MasterData.NumericString(Item_Status.Total_Value);
            labelTotalDeliveredQ.Text = MasterData.NumericString(Item_Status.Delivered_QP);
            labelTotalDeliveredValue.Text = MasterData.NumericString(Item_Status.Delivered_Value);
            labelTotalExps.Text = MasterData.NumericString((double)Item_Status.Total_Exps);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBoxInterimNumber.Text == string.Empty) return;
            var Check = MasterData.Interim.InterimsHeadDataTable.FirstOrDefault
                (x => x.Number == textBoxInterimNumber.Text);
            if (Check != null)
            {
                textBoxInterimNumber.Text = string.Empty;
                setStatus("هذا الرقم مستخدم من قبل", 0);
            }
        }

        void setStatus(string Description, int Status)
        {
            switch (Status)
            {
                case 0:
                    labelStatus.Text = Description;
                    labelStatus.ForeColor = Color.IndianRed;
                    pictureBoxStatus.Image = Resources.wrong_16;
                    break;
                case 1:
                    labelStatus.Text = Description;
                    labelStatus.ForeColor = Color.GreenYellow;
                    pictureBoxStatus.Image = Resources.correct_16;
                    break;
            }
        }
        bool CheckData()
        {
            if (CBContracts.SelectedIndex != -1
                && DGV.Rows.Count > 0 && textBoxInterimNumber.Text != string.Empty) return true;
            else return false;
        }
        void UpdateTotalGV()
        {
            double Sum = 0;
            for (int i = 0; i < DGV.Rows.Count; i++)
                Sum += double.Parse(DGV.Rows[i].Cells[2].Value.ToString());
            labelTotalGV.Text = MasterData.NumericString(Sum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // todo check inputs
            if (NUDQ.Value > 0 && NUDV.Value > 0 && comboBoxItems.SelectedIndex != -1)
            {
                if ((NUDV.Value + decimal.Parse(labelTotalDeliveredValue.Text)) > decimal.Parse(labelTotalExps.Text))
                {
                    setStatus("لايمكن أن تكون قيمة البند أعلى من مصروفاته", 0);
                    return;
                }
                DGV.Rows.Add(comboBoxItems.SelectedItem.ToString(), NUDQ.Value, NUDV.Value);
                UpdateTotalGV();
                setStatus("تمت الاضافة إلى بنود المستخلص", 1);
            }
            else setStatus("برجاء مراجعه بيانات الادخال", 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count == 0) return;
            DGV.Rows.Remove(DGV.SelectedRows[0]);
            UpdateTotalGV();
            setStatus("تم مسح البند", 1);
        }

        void Reset()
        {
            DGV.Rows.Clear();
            UpdateTotalGV();
            textBoxInterimNumber.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool Result = CheckData();
            if (Result)
            {
                MasterData.Interim.InterimsHeadRow = MasterData.Interim.InterimsHeadDataTable.NewInterimsHeadRow();
                MasterData.Interim.InterimsHeadRow.ContractID = SelectedContrctID;
                MasterData.Interim.InterimsHeadRow.In_Date = DateTime.Now;
                MasterData.Interim.InterimsHeadRow.Number = textBoxInterimNumber.Text;
                MasterData.Interim.InterimsHeadRow.ID = -1;
                LoadItems();
                MasterData.Interim.AddNew(ListToSave);
                setStatus("تم حفظ بيانات المستخلص بنجاح", 1);
                Reset();
            }
            else setStatus("برجاء مراجعة بيانات المستخلص قبل الخفظ", 0);

        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {

            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            CBContracts.SelectedIndex = CBContracts.FindStringExact(Displayallcontracts.ContractNumber);
            //if (CBContract.SelectedIndex != -1) LoadContractData();

        }
    }
}
