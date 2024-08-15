using HORAS.Database;
using HORAS.Interims_Data;
using HORAS.Properties;
//using IronXL;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Lights;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS.Assessments
{
    public partial class ImportAssessment : Form
    {
        List<Items> itemlist = new List<Items>();
        List<Items> LoadedItemsList = new List<Items>();
        List<AssItemsRow> ListToSave = new List<AssItemsRow>();
        // HorasDataSet.AssessmentHeadRow SavedObject;
        AssItemsRow ItemRow;
        bool DataLoaded = false;
        public ImportAssessment()
        {
            InitializeComponent();
            DGV_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LabelDate.Text = DateTime.Now.ToShortDateString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            //FileDialoge.InitialDirectory = Application.StartupPath;
            FileDialoge.Filter = "Database Files (*.xls , *.xlsx) | *.xls; *.xlsx";
            if (FileDialoge.ShowDialog() == DialogResult.OK)
            {
                //clear the prev data
                LoadedItemsList.Clear();
                DGV_Data.Rows.Clear();

                TextBoxURL.Text = FileDialoge.FileName;

                Microsoft.Office.Interop.Excel.Application xlapp;
                Microsoft.Office.Interop.Excel.Workbook workBook;
                Microsoft.Office.Interop.Excel.Worksheet workSheet;
                Microsoft.Office.Interop.Excel.Range Range;
                try
                {
                    xlapp = new Microsoft.Office.Interop.Excel.Application();
                    workBook = xlapp.Workbooks.Open(FileDialoge.FileName);
                    workSheet = (Worksheet)workBook.Sheets[1];
                    Range = workSheet.UsedRange;


                    DGV_Data.Rows.Clear();
                    float Total = 0;



                    for (int i = 6; i <= Range.Rows.Count; i++)
                    {
                        Items NewItem = new Items();
                        NewItem.Number = Range.Cells[i, 1].Value.ToString();
                        NewItem.Dexcription = Range.Cells[i, 2].Value.ToString();
                        NewItem.Item_Unit = Range.Cells[i, 3].Value.ToString();
                        NewItem.Total_PRice = float.Parse(Range.Cells[i, 4].Value.ToString());
                        NewItem.Qty = float.Parse(Range.Cells[i, 5].Value.ToString());
                        NewItem.Type = ((Item_TYPE)int.Parse(Range.Cells[i, 6].Value.ToString()));
                        NewItem.LOL = float.Parse(Range.Cells[i, 7].Value.ToString()) / 100;
                        //  LoadedItemsList.Add(NewItem);
                        DGV_Data.Rows.Add(NewItem.Number,
                            NewItem.Item_Unit, NewItem.Total_PRice, NewItem.Qty,
                            NewItem.Type, NewItem.LOL, (NewItem.Total_PRice * NewItem.Qty));
                        Total += NewItem.Total_PRice;
                        itemlist.Add(NewItem);

                    }
                    LabelTotal.Text = Total.ToString();

                    Marshal.ReleaseComObject(Range);
                    Marshal.ReleaseComObject(workSheet);
                    workBook.Close();
                    Marshal.ReleaseComObject(workBook);
                    xlapp.Quit();
                    Marshal.ReleaseComObject(xlapp);
                    DataLoaded = true;
                }
                catch (Exception E)
                {
                    setStatus(E.Message, 0);
                }










                //WorkBook workBook = WorkBook.Load(FileDialoge.FileName);
                //WorkSheet workSheet = workBook.WorkSheets.First();
                //Items NewItem;
                //double Total = 0;
                //foreach (var cell in workSheet.Rows)
                //{
                //    if (cell.RowNumber < 5) continue;
                //    NewItem = new Items();
                //    NewItem.Number = cell.Columns[0].Value.ToString();
                //    NewItem.Dexcription = cell.Columns[1].Value.ToString();
                //    NewItem.Item_Unit = cell.Columns[2].Value.ToString();
                //    NewItem.Total_PRice = float.Parse(cell.Columns[3].Value.ToString());
                //    NewItem.Qty = float.Parse(cell.Columns[4].Value.ToString());
                //    NewItem.Type = ((Item_TYPE)int.Parse(cell.Columns[5].Value.ToString()));
                //    NewItem.LOL = float.Parse(cell.Columns[6].Value.ToString());
                //    LoadedItemsList.Add(NewItem);

                //    //double TotalItem = 0; 
                //    //switch(NewItem.Type)
                //    //{
                //    //    case Item_TYPE.Supply: TotalItem = NewItem.Total_PRice * NewItem.Qty;  break;
                //    //    default: TotalItem = NewItem.Total_PRice; break;
                //    //}

                //    DGV_Data.Rows.Add(NewItem.Number, NewItem.Dexcription,
                //        NewItem.Item_Unit, NewItem.Total_PRice, NewItem.Qty,
                //        NewItem.Type, NewItem.LOL, NewItem.Total_PRice);
                //    Total += NewItem.Total_PRice;
                //}

            }
        }

        void LoadItems()
        {
            ListToSave.Clear();
            int StartItemIndex = 0;
            if (MasterData.assessments.AssItemsDataTable.Count > 0)
                StartItemIndex = MasterData.assessments.AssItemsDataTable.Max(X => X.ID) + 1;

            for (int i = 0; i < DGV_Data.RowCount; i++)
            {
                ItemRow = MasterData.assessments.AssItemsDataTable.NewAssItemsRow();
                ItemRow.ID = StartItemIndex + i;
                ItemRow.Number = DGV_Data.Rows[i].Cells[0].Value.ToString();
                ItemRow.Description = itemlist.FirstOrDefault(X => X.Number == ItemRow.Number).Dexcription;
                ItemRow.Item_Unit = DGV_Data.Rows[i].Cells[1].Value.ToString();
                ItemRow.Total_Price = float.Parse(DGV_Data.Rows[i].Cells[2].Value.ToString());
                ItemRow.LOL = float.Parse(DGV_Data.Rows[i].Cells[5].Value.ToString());
                ItemRow.Item_Type = ((int)(Item_TYPE)Enum.Parse(typeof(Item_TYPE), DGV_Data.Rows[i].Cells[4].Value.ToString()));
                ItemRow.Qty = float.Parse(DGV_Data.Rows[i].Cells[3].Value.ToString());
                if (ItemRow.Item_Type == 1 || ItemRow.Item_Type == 2) ItemRow.Qty = 100;
                ListToSave.Add(ItemRow);
            }
            TotalAssessment();
        }

        void TotalAssessment()
        {
            float Total = 0;
            for (int i = 0; i < DGV_Data.RowCount; i++)
                Total += float.Parse(DGV_Data.Rows[i].Cells[5].Value.ToString());
            LabelTotal.Text = Total.ToString();
        }

        bool CheckData()
        {
            bool DataOk = true;
            for (int i = 0; i < DGV_Data.RowCount; i++)
            {
                if (DGV_Data.Rows[i].Cells[0].Value.ToString() == string.Empty) return false;
                if (DGV_Data.Rows[i].Cells[1].Value.ToString() == string.Empty) return false;
                if (DGV_Data.Rows[i].Cells[2].Value.ToString() == string.Empty) return false;
                if (DGV_Data.Rows[i].Cells[4].Value.ToString() == string.Empty) return false;
            }
            if (TextBoxSubject.Text == string.Empty || TextBoxAbout.Text == string.Empty) DataOk = false;
            return DataOk;
        }

        

        void ResetSave()
        {
            DataLoaded = false;
            DGV_Data.Rows.Clear();
            LabelTotal.Text = MasterData.NumericString(0);
            TextBoxURL.Text = TextBoxSubject.Text = TextBoxAbout.Text = string.Empty;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            bool Result = CheckData();
            if (Result)
            {
                MasterData.assessments.AssessmentRow = MasterData.assessments.AssessmentHeadDataTable.NewAssessmentHeadRow();
                MasterData.assessments.AssessmentRow.Confirmed = false;
                MasterData.assessments.AssessmentRow.Subject = TextBoxSubject.Text;
                MasterData.assessments.AssessmentRow.About = TextBoxAbout.Text;
                MasterData.assessments.AssessmentRow.ID = -1;
                LoadItems();
                MasterData.assessments.AddNew(ListToSave);
                setStatus("تم حفظ بيانات المقايسة بنجاح", 1);
                ResetSave();

            }
            else
                setStatus("برجاء إدخال البيانات", 0);
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxURL_Click(object sender, EventArgs e)
        {

        }

      

        private void DGV_Data_SelectionChanged(object sender, EventArgs e)
        { if (DataLoaded == false) return;
            string ItemNo = DGV_Data.SelectedRows[0].Cells[0].Value.ToString();
            richTextBox1.Text = itemlist.FirstOrDefault(X => X.Number == ItemNo).Dexcription;
        }
    }
}
