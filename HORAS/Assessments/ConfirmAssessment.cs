using HORAS.Database;
using HORAS.Interims_Data;
using HORAS.Properties;
using Microsoft.Office.Interop.Excel;

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

namespace HORAS.Assessments
{
    public partial class ConfirmAssessment : Form
    {
        List<AssItemsRow> LoadedItemsList = new List<AssItemsRow>();
        List<Items> itemlist = new List<Items>();
        int SelectedAssID = -1;
        // HorasDataSet.AssessmentHeadRow SavedObject;
        AssItemsRow ItemRow;
        float Total = 0;
        bool DataLoaded = false;
        public ConfirmAssessment()
        {
            InitializeComponent();
            DGV_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // LoadAssessments();


        }

        void LoadAssessments()
        {
            ComboAssIDS.Items.Clear();
            MasterData.assessments.RefreshList();
            foreach (var ass in MasterData.assessments.AssessmentHeadDataTable)
            { if (!ass.Confirmed) ComboAssIDS.Items.Add(ass.ID); }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            // FileDialoge.InitialDirectory = Application.StartupPath;
            FileDialoge.Filter = "Database Files (*.xls , *.xlsx) | *.xls; *.xlsx";
            if (FileDialoge.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application xlapp =
                    new Microsoft.Office.Interop.Excel.Application();

                //  TextBoxURL.Text = FileDialoge.FileName;
                Microsoft.Office.Interop.Excel.Workbook workBook = xlapp.Workbooks.Open(FileDialoge.FileName);
                Microsoft.Office.Interop.Excel._Worksheet workSheet = (_Worksheet)workBook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range Range = workSheet.UsedRange;

                DGV_Data.Rows.Clear();
                float Total = 0;

                for (int i = 6; i < Range.Rows.Count; i++)
                {
                    Items NewItem = new Items();
                    NewItem.Number = Range.Cells[i, 0].ToString();
                    NewItem.Dexcription = Range.Cells[i, 1].ToString();
                    NewItem.Item_Unit = Range.Cells[i, 2].ToString();
                    NewItem.Total_PRice = float.Parse(Range.Cells[i, 3].ToString());
                    NewItem.Qty = float.Parse(Range.Cells[i, 4].ToString());
                    NewItem.Type = ((Item_TYPE)int.Parse(Range.Cells[i, 5].ToString()));
                    DGV_Data.Rows.Add(NewItem.Number,
                        NewItem.Item_Unit, NewItem.Total_PRice, NewItem.Qty,
                        NewItem.Type, (NewItem.Total_PRice * NewItem.Qty));
                    Total += (NewItem.Total_PRice * NewItem.Qty);
                }


                LabelTotal.Text = Total.ToString();
            }
        }


        void Reset()
        {
            richTextBox1.Text = labelAbout.Text = labelSubject.Text = string.Empty;
            SelectedAssID = -1;
            DataLoaded = false;
            ComboAssIDS.Items.Clear();
            foreach (var ass in MasterData.assessments.AssessmentHeadDataTable)
            { if (!ass.Confirmed) ComboAssIDS.Items.Add(ass.ID); }
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

        private void ComboAssIDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboAssIDS.SelectedIndex != null)
            {

                //DGV_Data.Rows.Clear();
                SelectedAssID = int.Parse(ComboAssIDS.SelectedItem.ToString());

                var Assessment = MasterData.assessments.AssessmentHeadDataTable.FirstOrDefault(X => X.ID == SelectedAssID);
                labelAbout.Text = Assessment.About;
                labelSubject.Text = Assessment.Subject;

                // Load Assessment Items
                LoadedItemsList = MasterData.assessments.AssItemsDataTable.Where(X => X.AssID == SelectedAssID).ToList();



                // itemlist.Clear();
                DataLoaded = false;
                DGV_Data.Rows.Clear();


                foreach (var Item in LoadedItemsList)
                {
                    Items NewItem = new Items();
                    NewItem.Number = Item.Number;
                    NewItem.Dexcription = Item.Description;
                    NewItem.Item_Unit = Item.Item_Unit;
                    NewItem.Total_PRice = (float)Item.Total_Price;
                    NewItem.Qty = (float)Item.Qty;
                    NewItem.Type = (Item_TYPE)Item.Item_Type;

                    string Total_ = MasterData.NumericString(NewItem.Total_PRice * NewItem.Qty);

                    DGV_Data.Rows.Add(NewItem.Number,
                        NewItem.Item_Unit, NewItem.Total_PRice, NewItem.Qty,
                        NewItem.Type, Total_);
                    Total += NewItem.Total_PRice * NewItem.Qty;
                    itemlist.Add(NewItem);
                }
                LabelTotal.Text = MasterData.NumericString(Total);
                DataLoaded = true;
                MasterData.styleGridView(DGV_Data);
            }
        }

        private void ConfirmAssessment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedAssID == -1)
                setStatus("يجب إختيار المقايسة أولاً", 0);
            else
            {
                MasterData.assessments.Confirm(SelectedAssID);
                setStatus("تم تأكيد بيانات المقايسة", 1);
                Reset();
            }
        }

        private void DGV_Data_SelectionChanged(object sender, EventArgs e)
        {
            if (DataLoaded == false) return;
            string itemnum = DGV_Data.SelectedRows[0].Cells[0].Value.ToString();
            richTextBox1.Text = itemlist.FirstOrDefault(x => x.Number == itemnum).Dexcription;
        }

        private void ComboAssIDS_DropDown(object sender, EventArgs e)
        {
            LoadAssessments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (ComboAssIDS.SelectedIndex == -1)
            {
                setStatus("يجب إختيار رقم المقايسة أولاً", 0);
                return;
            }

            string FileName = (char)Document_Type.Assessment + "_" + ComboAssIDS.SelectedItem.ToString();
            string Output = MasterData.GetFile(FileName);
            if (Output == string.Empty)
            {
                setStatus("لا يوجد ملف محفوظ للمقايسة", 0);
                return;
            }
            else
            {
                MasterData.OpenFile(Output);
            }

        }
    }
}
