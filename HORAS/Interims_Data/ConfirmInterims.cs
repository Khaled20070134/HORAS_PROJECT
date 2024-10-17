using HORAS.Contracts;
using HORAS.Database;
using HORAS.HorasDataSetTableAdapters;
using HORAS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HORAS.Enums;

namespace HORAS.Interims_Data
{
    public partial class ConfirmInterims : Form
    {
        HorasDataSet.InterimsItemsDataTable ItemsDataTable;
        int SelectedContrctID, SelectedInterimID, SelectedItemID;
        public ConfirmInterims()
        {
            InitializeComponent();
            LoadData();
            LoadContractData();

        }

        public static int SelectedITemID = 0;

        void LoadItemData(I_Status status) 
        {
             
            //int slectedItemID = 
            string SelectedContractNumber = comboBoxContracts.SelectedItem.ToString();

            // Load Description
            labelDescription.Text =
            MasterData.assessments.NotNullContracts.
            FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.ID == DisplayAllinterimsItems.ItemID).Description;

            // Load Item Type
            Item_TYPE ITpe = MasterData.GetItemType(SelectedContractNumber, DisplayAllinterimsItems.ItemID);
            labelItemType.Text = ITpe.ToString();
            int Typeint = (int)ITpe;
            //FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.Number == SelectedItemNumber).Item_Type;
            //labelItemType.Text = ((Item_TYPE)Typeint).ToString();

             
            double Qty = MasterData.Interim.InterimsItemsDataTable.
                FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ItemID == DisplayAllinterimsItems.ItemID).Qty;
            labelQTy.Text = MasterData.NumericString(Qty);
            // Load Qty
            //switch (Typeint)
            //{
            //    case 0:
            //        labelQTy.Text = MasterData.NumericString(Qty);
            //        break;
            //    default:
            //        Qty = MasterData.Interim.InterimsItemsDataTable.
            //             FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ID == slectedItemID).Qty;
            //        labelQTy.Text = MasterData.NumericString(Qty);
            //        break;
            //}

            // Load Price from Interim
            double Price, PriceUnit = 0;
            Price = MasterData.Interim.InterimsItemsDataTable.
FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ItemID == DisplayAllinterimsItems.ItemID).Price_Unit;
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
            I_Status Status = MasterData.Interim.Get_Item_Status(SelectedContractNumber, DisplayAllinterimsItems.ItemID);
            labelPOC.Text = ((Status.Delivered_QP / Status.Total_QP) * 100).ToString() + " %";
            labelPriceAss.Text = Status.Total_Value.ToString();
            labelRemain.Text = (Status.Total_QP - Status.Delivered_QP).ToString();


        }
        void LoadData()
        {
            var Results = MasterData.Contracts.ContractTableAdapter.ContractsAndInterimsConfirm();
            foreach (var Con in Results)
                comboBoxContracts.Items.Add(Con.Number);
        }

        private void LIstboxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void listBoxInterims_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (listBoxInterims.SelectedIndex != -1)
        //    {
        //        listBoxItems.Items.Clear();
        //        string InteNumber = listBoxInterims.SelectedItem.ToString();
        //        SelectedInterimID = MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(X => X.Number == InteNumber).ID;
        //        ItemsDataTable =
        //            MasterData.Interim.InterimsItemsTableAdapter.GetItemsOfInte(SelectedInterimID);
        //        LoadGeneral();

        //        foreach (var Item in ItemsDataTable)
        //            listBoxItems.Items.Add(Item.ID);
        //    }
        //}

        void LoadGeneral()
        {
            labelNoItems.Text = ItemsDataTable.Rows.Count.ToString();
            labelEntryDate.Text =
                MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(X => X.ID == SelectedInterimID)
                .In_Date.ToShortDateString();
            double Sum = 0;
            foreach (var Item in ItemsDataTable)
            {
                Item_TYPE Type;
                Type = MasterData.GetItemType(comboBoxContracts.SelectedItem.ToString(), Item.ID);
                Sum += (Item.Price_Unit * Item.Qty);
                //switch (Type)
                //{
                //    case Item_TYPE.Supply:
                //        break;
                //    default:
                //        Sum += Item.Price_Unit; break;
                //}
            }
            labelTotalItems.Text = MasterData.NumericString(Sum);
        }

        private void ConfirmInterims_Load(object sender, EventArgs e)
        {

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
        void LoadContractData()
        {
            if (comboBoxContracts.SelectedIndex != -1)
            {
                listBoxInterims.Items.Clear();
                string ContractNumber = comboBoxContracts.SelectedItem.ToString();
                SelectedContrctID =
                    MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == ContractNumber).ID;

                var Result = MasterData.Interim.InterimsHeadTableAdapter.GetDataBy(SelectedContrctID);
                foreach (var Inte in Result)
                    listBoxInterims.Items.Add(Inte.Number);
            }
        }

        void Reset()
        {
            comboBoxContracts.Items.Clear();
            //listBoxItems.Items.Clear();
            listBoxInterims.Items.Clear();
            labelNoItems.Text = labelTotalItems.Text = labelDescription.Text =
                labelPriceAss.Text = labelQTy.Text = labelEntryDate.Text =
                labelPriceInter.Text = labelItemType.Text = labelRemain.Text = labelPOC.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxInterims.SelectedIndex == -1)
            {
                setStatus("يجب إختيار مستخلص لتأكيده", 0);
                return;
            }
            string InterimNumber = listBoxInterims.SelectedItem.ToString();
            int InterimID =
                MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(X => X.Number == InterimNumber).ID;
            MasterData.Interim.Confirm(InterimID);
            Reset();
            setStatus("تم تأكيد بيانات المستخلص", 1);
        }

   //     private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
   //     {
   //         if (listBoxItems.SelectedIndex != -1)
   //         {
   //             int slectedItemID = int.Parse(listBoxItems.SelectedItem.ToString());
   //             string SelectedContractNumber = comboBoxContracts.SelectedItem.ToString();

   //             // Load Description
   //             labelDescription.Text =
   //             MasterData.assessments.NotNullContracts.
   //             FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.ID == slectedItemID).Description;

   //             // Load Item Type
   //             Item_TYPE ITpe = MasterData.GetItemType(SelectedContractNumber, slectedItemID);
   //             labelItemType.Text = ITpe.ToString();
   //             int Typeint = (int)ITpe;
   //             //FirstOrDefault(X => X.Contract_ID == SelectedContrctID && X.Number == SelectedItemNumber).Item_Type;
   //             //labelItemType.Text = ((Item_TYPE)Typeint).ToString();

   //             double Qty;
   //             Qty = MasterData.Interim.InterimsItemsDataTable.
   //                 FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ID == slectedItemID).Qty;

   //             // Load Qty
   //             switch (Typeint)
   //             {
   //                 case 0:
   //                     labelQTy.Text = MasterData.NumericString(Qty);
   //                     break;
   //                 default:
   //                     Qty = MasterData.Interim.InterimsItemsDataTable.
   //                          FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ID == slectedItemID).Qty;
   //                     labelQTy.Text = MasterData.NumericString(Qty);
   //                     break;
   //             }

   //             // Load Price from Interim
   //             double Price, PriceUnit = 0;
   //             Price = MasterData.Interim.InterimsItemsDataTable.
   //FirstOrDefault(X => X.HeadID == SelectedInterimID && X.ID == slectedItemID).Price_Unit;
   //             labelPriceInter.Text = MasterData.NumericString(Price);
   //             //switch (Typeint)
   //             //{
   //             //    case 0:
   //             //        double Price, PriceUnit = 0;
   //             //        Price = MasterData.Interim.InterimsItemsDataTable.
   //             //            FirstOrDefault(X => X.HeadID == SelectedInterimID && X.Number == SelectedItemNumber).Price_Unit;
   //             //        labelPriceInter.Text = MasterData.NumericString(Qty / Price);
   //             //        break;
   //             //    default:
   //             //        Price = MasterData.Interim.InterimsItemsDataTable.
   //             //           FirstOrDefault(X => X.HeadID == SelectedInterimID && X.Number == SelectedItemNumber).Price_Unit;
   //             //        labelPriceInter.Text = MasterData.NumericString(Price);
   //             //        break;
   //             //}
   //             ///////////////////////////////////////////////////////////////////////////////
   //             I_Status Status = MasterData.Interim.Get_Item_Status(SelectedContractNumber, slectedItemID);
   //             labelPOC.Text = ((Status.Delivered_QP / Status.Total_QP) * 100).ToString() + " %";
   //             labelPriceAss.Text = Status.Total_Value.ToString();
   //             labelRemain.Text = (Status.Total_QP - Status.Delivered_QP).ToString();

   //         }
   //     }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            int contractid = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == Displayallcontracts.ContractNumber).ID;
            if (MasterData.Interim.InterimsHeadDataTable.Where(x => x.ID == contractid && x.IsConfirm_DateNull()).Count() == 0)
            {
                setStatus("العقد المختار ليس له مستخلصات غير مؤكدة", 0);
            }
            else
                comboBoxContracts.SelectedIndex = comboBoxContracts.FindStringExact(Displayallcontracts.ContractNumber);
            if (comboBoxContracts.SelectedIndex != -1) LoadContractData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContractData();
            buttonSelecteItem.Visible = true;
            labelItemselected.Visible = true;   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBoxInterims.SelectedIndex == -1)
            {
                setStatus("يجب إختيار رقم المستخلص أولاً", 0);
                return;
            }

            string FileName = (char)Document_Type.Interim + "_" + listBoxInterims.SelectedItem.ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBoxContracts.SelectedIndex == -1) return;
            DisplayAllinterimsItems Con = new DisplayAllinterimsItems(listBoxInterims.SelectedItem.ToString());
            Con.ShowDialog();
            SelectedItemID = DisplayAllinterimsItems.ItemID;
            labelItemselected.Text = SelectedItemID.ToString();

            I_Status Item_Status = MasterData.Interim.Get_Item_Status(comboBoxContracts.SelectedItem.ToString(),
                SelectedItemID);
            LoadItemData(Item_Status);
        }
    }
}
