using HORAS.Database;
using HORAS.Interims_Data;
using HORAS.Properties;
//using IronXL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS.Interims_Data
{
    public partial class ImportInterims : Form
    {
        List<Items> LoadedItemsList = new List<Items>();
        List<InterimsItemsRow> ListToSave = new List<InterimsItemsRow>();
        int ContractID = 0;

        InterimsItemsRow ItemRow;

        bool DataLoaded = false;
        bool General_Status = true;
        public ImportInterims()
        {
            InitializeComponent();
            DGV_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadContracts();
        }

        void LoadContracts()
        {
            CBContracts.Items.Clear();
            // Load Contracts
            List<string> Contracts = new List<string>();
            List<string> Contracts2 = new List<string>();
            foreach (var Cont in MasterData.Contracts.
                ContractDataTable.Where(X => X.Signed == true && !X.IsStartDateNull()))
                Contracts.Add(Cont.Number);
            foreach (string C in Contracts)
            {
                int ContractID = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == C).ID;
                var Result = MasterData.Interim.InterimsHeadDataTable.
                    FirstOrDefault(X => X.ContractID == ContractID && X.IsConfirm_DateNull());
                if (Result == null) Contracts2.Add(C);
            }
            foreach (string C in Contracts2) CBContracts.Items.Add(C);

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (CBContracts.SelectedIndex == -1)
            {
                setStatus("يجب إختيار التعاقد أولاً", 0);
                return;
            }

            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.InitialDirectory = Application.StartupPath;
            FileDialoge.Filter = "Database Files (*.xls , *.xlsx) | *.xls; *.xlsx";
            if (FileDialoge.ShowDialog() == DialogResult.OK)
            {
                TextBoxURL.Text = FileDialoge.FileName;
                WorkBook workBook = WorkBook.Load(FileDialoge.FileName);
                WorkSheet workSheet = workBook.WorkSheets.First();
                DGV_Data.Rows.Clear();
                float Total = 0;
                foreach (var cell in workSheet.Rows)
                {
                    if (cell.RowNumber < 2) continue;
                    Items NewItem = new Items();

                    NewItem.Number = cell.Columns[0].Value.ToString();
                    NewItem.Total_PRice = float.Parse(cell.Columns[1].Value.ToString());
                    NewItem.Qty = float.Parse(cell.Columns[2].Value.ToString());
                    LoadedItemsList.Add(NewItem);
                    DGV_Data.Rows.Add(NewItem.Number, NewItem.Total_PRice, NewItem.Qty,
                        NewItem.Type, (NewItem.Total_PRice * NewItem.Qty));
                    Total += (NewItem.Total_PRice * NewItem.Qty);
                }
                //labelTotal.Text = Total.ToString();
            }
            CheckItemsImport();
            DataLoaded = true;
            TotalAssessment();
        }

        void CheckItemQty(Items Item)
        {
            switch (Item.Type)
            {
                case Item_TYPE.Both:
                case Item_TYPE.Implementation_Installation:

                    if (LoadedItemsList.First(X => X.Number == Item.Number).Qty > 100)
                        Item.ImportStatus = ItemImportStatus.QtyExceed;
                    else
                    {
                        if (LoadedItemsList.First(X => X.Number == Item.Number).Qty + Item.PrevQty > 100)
                            Item.ImportStatus = ItemImportStatus.QtyExceed;
                    }
                    break;
                case Item_TYPE.Supply:
                    if (LoadedItemsList.First(X => X.Number == Item.Number).Qty + Item.PrevQty > Item.AssTotalQty)
                        Item.ImportStatus = ItemImportStatus.QtyExceed;
                    break;
            }
        }

        void CheckItemPrice(Items Item)
        {
            switch (Item.Type)
            {
                case Item_TYPE.Both:
                case Item_TYPE.Implementation_Installation:
                    if ((100 / Item.Ass_Price_Unit) <
                        LoadedItemsList.First(X => X.Number == Item.Number).Qty / LoadedItemsList.First(X => X.Number == Item.Number).Total_PRice)
                        Item.ImportStatus = ItemImportStatus.PriceExceed;
                    break;
                case Item_TYPE.Supply:
                    if ((Item.Ass_Price_Unit / Item.AssTotalQty) <
                        LoadedItemsList.First(X => X.Number == Item.Number).Qty / LoadedItemsList.First(X => X.Number == Item.Number).Total_PRice)
                        Item.ImportStatus = ItemImportStatus.PriceExceed;
                    break;
            }
        }

        void CheckItemsImport()
        {
            //LoadedItemsList.Clear();
            foreach (Items NewItem in LoadedItemsList)
            {
                //Items NewItem = new Items();
                string ItemNumber = NewItem.Number;
                //NewItem.Number = ItemNumber;
                //NewItem = LoadedItemsList.FirstOrDefault(X => X.Number == ItemNumber);

                if (LoadedItemsList.Count(X => X.Number == NewItem.Number) > 1)
                    NewItem.ImportStatus = ItemImportStatus.ItemDublicated;

                else if (MasterData.assessments.CheckItemExist(ContractID, ItemNumber))
                {
                    MasterData.assessments.GetItemData(ContractID, ItemNumber, NewItem);
                    NewItem.PrevQty = MasterData.Interim.getPrevData(ContractID, ItemNumber);

                    CheckItemQty(NewItem);
                    if (NewItem.ImportStatus == ItemImportStatus.NoImport)
                        CheckItemPrice(NewItem);

                    if (NewItem.ImportStatus == ItemImportStatus.NoImport)
                    {
                        NewItem.ImportStatus = ItemImportStatus.Success;
                        General_Status = true;
                    }
                }
                else
                { General_Status = false; NewItem.ImportStatus = ItemImportStatus.NotExist; }


                //LoadedItemsList.Add(NewItem);
            }
            if (General_Status) labelTotalStatus.Text = "جميع البنود صحيحة";
            else labelTotalStatus.Text = "هناك خطأ فى بعض البنود برجاء مرجعتها";
        }

        void LoadItems()
        {
            ListToSave.Clear();
            int StartItemIndex = 0;
            if (MasterData.Interim.InterimsItemsDataTable.Count > 0)
                StartItemIndex = MasterData.Interim.InterimsItemsDataTable.Max(X => X.ID) + 1;

            foreach (var Item in LoadedItemsList)
            {
                ItemRow = MasterData.Interim.InterimsItemsDataTable.NewInterimsItemsRow();
                ItemRow.ID = StartItemIndex;
                ItemRow.Number = Item.Number;
                ItemRow.HeadID = ContractID;
                ItemRow.Price_Unit = Item.Total_PRice;
                ItemRow.Qty = Item.Qty;
                ItemRow.IsBilled = false;
                ListToSave.Add(ItemRow);
                StartItemIndex++;
            }
        }

        void TotalAssessment()
        {
            float Total = 0;
            foreach (var Item in LoadedItemsList)
            {
                if (Item.ImportStatus != ItemImportStatus.NotExist && 
                    Item.ImportStatus != ItemImportStatus.ItemDublicated)
                {
                    if (Item.Type == Item_TYPE.Supply) Total += (Item.Qty * Item.Total_PRice);
                    else Total += Item.Total_PRice;
                }
            }
            labelTotal.Text = Total.ToString();
        }

        bool CheckData()
        {
            bool DataOk = true;
            if (textBoxNumber.Text == string.Empty) DataOk = false;
            if (CBContracts.SelectedIndex == -1) DataOk = false;
            if (DGV_Data.Rows.Count == 0) DataOk = false;

            foreach (Items Item in LoadedItemsList)
            {
                if (Item.ImportStatus == ItemImportStatus.NotExist) DataOk = false;
            }
            if (!DataOk)
                setStatus("لايمكن حفظ المستخلص لوجود أخطاء فى بعض البنود", 0);
            return DataOk;
        }

        void DataChanged(int SelectedRowIndex, int SelectedColumnIndex)
        {
            if (SelectedColumnIndex == 3 || SelectedColumnIndex == 4)
            {
                if (!float.TryParse(DGV_Data.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value.ToString(),
                    out float Value))
                {
                    MessageBox.Show("هذا الحقل لابد أن يكون رقمى وليس أحرف", "خطأ فى الادخال"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DGV_Data.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value = string.Empty;
                }
                else
                {
                    DGV_Data.Rows[SelectedRowIndex].Cells[5].Value =
                        float.Parse(DGV_Data.Rows[SelectedRowIndex].Cells[3].Value.ToString()) *
                        float.Parse(DGV_Data.Rows[SelectedRowIndex].Cells[4].Value.ToString());
                    TotalAssessment();
                }
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            bool Result = CheckData();
            if (Result)
            {
                MasterData.Interim.InterimsHeadRow = MasterData.Interim.InterimsHeadDataTable.NewInterimsHeadRow();
                MasterData.Interim.InterimsHeadRow.ContractID = ContractID;
                MasterData.Interim.InterimsHeadRow.In_Date = DateTime.Now;
                MasterData.Interim.InterimsHeadRow.Number = textBoxNumber.Text;
                MasterData.Interim.InterimsHeadRow.ID = -1;
                LoadItems();
                MasterData.Interim.AddNew(ListToSave);
                setStatus("تم حفظ بيانات المستخلص بنجاح", 1);
                Reset();
            }
            //else
            //    setStatus("برجاء إدخال البيانات", 0);
        }

        void Reset()
        {
            TextBoxURL.Text = string.Empty;
            DGV_Data.Rows.Clear();
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

        private void CBContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBContracts.SelectedIndex != -1)
            {
                DGV_Data.Rows.Clear();
                TextBoxURL.Text = string.Empty;
                string ContractNumber = CBContracts.SelectedItem.ToString();
                ContractID = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == ContractNumber).ID;
            }
        }

        private void DGV_Data_SelectionChanged(object sender, EventArgs e)
        {
            if (!DataLoaded || DGV_Data.SelectedRows.Count == 0) return;
            string Number = DGV_Data.SelectedRows[0].Cells[0].Value.ToString();
            Items SelectedItem = LoadedItemsList.FirstOrDefault(X => X.Number == Number);
            labelItemStatus.Text = SelectedItem.ImportStatus.ToString();
            if (SelectedItem.ImportStatus == ItemImportStatus.NotExist)
            { LabelItemDesc.Text = labelPrevQty.Text = labelTotalAss.Text = "غير معرف"; return; }
            LabelItemDesc.Text = SelectedItem.Dexcription;
            labelPrevQty.Text = SelectedItem.PrevQty.ToString();
            labelTotalAss.Text = SelectedItem.AssTotalQty.ToString();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBoxNumber.Text != string.Empty)
            {
               var Reulst = MasterData.Database.InterimsHead.FirstOrDefault(X => X.Number == textBoxNumber.Text);
                if (Reulst != null)
                {
                    textBoxNumber.Text = string.Empty;
                    setStatus("تم إستخدام هذا الرقم فى مستخلص آخر", 0);
                }
            }
        }
    }
}
