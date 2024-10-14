using HORAS.Contracts;
using HORAS.Database;
using HORAS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.AI.MachineLearning.Preview;
using static HORAS.Enums;

namespace HORAS.Interims_Data
{
    public partial class DisplayInterim : Form
    {


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
        public DisplayInterim()
        {
            InitializeComponent();
            var List = MasterData.Interim.InterimsHeadDataTable.ToList();
            foreach (var item in List)
            {
                comboBoxIntNum.Items.Add(item.Number);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Load Header Data
            labelInDate.Text =
                MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(x => x.Number == comboBoxIntNum.SelectedItem.ToString()).In_Date.ToLongDateString();

            int ContractID = MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(x => x.Number == comboBoxIntNum.SelectedItem.ToString()).ContractID;

            LinkContract.Text = MasterData.Contracts.ContractDataTable.FindByID(ContractID).Number;

            if (MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(x => x.Number == comboBoxIntNum.SelectedItem.ToString()).IsConfirm_DateNull())
                labelConfirmDate.Text = "لم يتم تأكيد المستخلص";
            else
                labelConfirmDate.Text =
                    MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(x => x.Number == comboBoxIntNum.SelectedItem.ToString()).Confirm_Date.ToLongDateString();



            // Load Items Data
            int ID = MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(x => x.Number == comboBoxIntNum.SelectedItem.ToString()).ID;
            var ItemsList = MasterData.Interim.InterimsItemsDataTable.Where(X => X.HeadID == ID).ToList();

            DGVItems.Rows.Clear();

            foreach (var Item in ItemsList)
            {
                HorasDataSet.AssItemsRow HeadData = MasterData.assessments.AssItemsAdapter.NotNullContracts().
                    FirstOrDefault(X => X.ID == Item.ID && X.Contract_ID == ContractID);
                string ItemType = MasterData.GetItemTypeString(HeadData.Item_Type);
                string LOL = MasterData.NumericString(HeadData.LOL) + " %";
                DGVItems.Rows.Add(Item.ID, HeadData.Description, MasterData.NumericString(Item.Price_Unit), ItemType, LOL);
            }

        }

        private void DGVItems_SelectionChanged(object sender, EventArgs e)
        {
            int SelectedItemID = int.Parse(DGVItems.SelectedRows[0].Cells[0].Value);
            string SelectedContractNumber = LinkContract.Text;
            int SelectedInterimID = MasterData.Interim.InterimsHeadDataTable.
                FirstOrDefault(x => x.Number == comboBoxIntNum.SelectedItem.ToString()).ID;

            double Qty;
            Qty = MasterData.Interim.InterimsItemsDataTable.
                FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ID == SelectedItemID).Qty;

            Item_TYPE ITpe = MasterData.GetItemType(SelectedContractNumber, SelectedItemID);
            int Typeint = (int)ITpe;

            // Load Qty
            labelQTy.Text = MasterData.NumericString(Qty);
            //switch (Typeint)
            //{
            //    case 0:
            //        labelQTy.Text = MasterData.NumericString(Qty);
            //        break;
            //    default:
            //        Qty = MasterData.Interim.InterimsItemsDataTable.
            //             FirstOrDefault(X => X.HeadID == SelectedInterimID && X.Number == SelectedItemNumber).Qty;
            //        labelQTy.Text = MasterData.NumericString(Qty / 100);
            //        break;
            //}

            // Load Price from Interim
            double Price, PriceUnit = 0;
            Price = MasterData.Interim.InterimsItemsDataTable.
                 FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ID == SelectedItemID).Price_Unit;
            labelPriceInter.Text = MasterData.NumericString(Price);

            //switch (Typeint)
            //{
            //    case 0:
            //        double Price, PriceUnit = 0;
            //        Price = MasterData.Interim.InterimsItemsDataTable.
            //            FirstOrDefault(X => X.HeadID == SelectedInterimID && X.Number == SelectedItemNumber).Price_Unit;
            //        labelPriceInter.Text = MasterData.NumericString(Qty / Price);
            //        break;
            //    default:
            //        Price = MasterData.Interim.InterimsItemsDataTable.
            //           FirstOrDefault(X => X.HeadID == SelectedInterimID && X.Number == SelectedItemNumber).Price_Unit;
            //        labelPriceInter.Text = MasterData.NumericString(Price);
            //        break;
            //}
            ///////////////////////////////////////////////////////////////////////////////
            I_Status Status = MasterData.Interim.Get_Item_Status(SelectedContractNumber, SelectedItemID);
            labelPOC.Text = ((Status.Delivered_QP / Status.Total_QP) * 100).ToString() + " %";
            labelPriceAss.Text = MasterData.NumericString(Status.Total_Value);
            labelRemain.Text = (Status.Total_QP - Status.Delivered_QP).ToString();

        }

        private void LinkContract_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (comboBoxIntNum.SelectedIndex == -1)
                setStatus("برجاء ادخال رقم المستخلص", 0);

            else
            {
                ContractDisplay Form = new ContractDisplay();
                Form.ShowDialog();
            }


        }

        private void DisplayInterim_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxIntNum.SelectedIndex == -1)
            {
                setStatus("يجب إختيار رقم المستخلص أولاً", 0);
                return;
            }

            string FileName = (char)Document_Type.Interim + "_" + comboBoxIntNum.SelectedItem.ToString();
            string Output = MasterData.GetFile(FileName);
            if (Output == string.Empty)
            {
                setStatus("لا يوجد ملف محفوظ للمستخلص", 0);
                return;
            }
            else
            {
                MasterData.OpenFile(Output);
            }
        }
    }
}
