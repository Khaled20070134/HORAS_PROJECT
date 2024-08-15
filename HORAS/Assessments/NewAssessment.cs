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

namespace HORAS.Assessments
{
    public partial class NewAssessment : Form
    {
        List<Items> LoadedItemsList = new List<Items>();
        List<AssItemsRow> ListToSave = new List<AssItemsRow>();
        List<string> Serials = new List<string>();
        // HorasDataSet.AssessmentHeadRow SavedObject;
        AssItemsRow ItemRow;
        bool ready = false;
        public NewAssessment()
        {
            InitializeComponent();
            ready = true;
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
                ItemRow.Description = DGV_Data.Rows[i].Cells[1].Value.ToString();
                ItemRow.Item_Unit = DGV_Data.Rows[i].Cells[2].Value.ToString();
                ItemRow.Total_Price = float.Parse(DGV_Data.Rows[i].Cells[3].Value.ToString());
                ItemRow.Qty = float.Parse(DGV_Data.Rows[i].Cells[4].Value.ToString());
                ItemRow.Item_Type = ((int)(Item_TYPE)Enum.Parse(typeof(Item_TYPE), DGV_Data.Rows[i].Cells[5].Value.ToString()));
                ItemRow.Contract_ID = 0; // 0 refers that this Item not assigned to contract yet
                                         // ItemRow.AssID = AssID;
                ListToSave.Add(ItemRow);
            }
            TotalAssessment();
        }

        void TotalAssessment()
        {
            float Total = 0;
            for (int i = 0; i < DGV_Data.RowCount - 1; i++)
                Total += float.Parse(DGV_Data.Rows[i].Cells[6].Value.ToString());
            LabelTotal.Text = Total.ToString();
        }

        bool CheckData()
        {
            bool DataOk = true;
            for (int i = 0; i < DGV_Data.RowCount - 1; i++)
            {
                if (DGV_Data.Rows[i].Cells[0].Value.ToString() == string.Empty) return false;
                if (DGV_Data.Rows[i].Cells[1].Value.ToString() == string.Empty) return false;
                if (DGV_Data.Rows[i].Cells[2].Value.ToString() == string.Empty) return false;
                if (DGV_Data.Rows[i].Cells[4].Value.ToString() == string.Empty) return false;
            }
            if (TextBoxSubject.Text == string.Empty || TextBoxAbout.Text == string.Empty) DataOk = false;
            return DataOk;
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
                Reset();
                ResetItem();
            }
            else
                setStatus("برجاء إدخال البيانات", 0);
        }

        void Reset()
        {
            TextBoxAbout.Text = TextBoxSubject.Text = string.Empty;
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

        void ResetItem()
        {
            TextBoxSerial.Text = TextBoxUnit.Text = TextBoxDesc.Text = string.Empty;
            NUDPriceUnit.Value = 0; NUDQTY.Value = 0;
        }

        bool CheckItemData()
        {
            bool Result = true;
            if (TextBoxSerial.Text == string.Empty || TextBoxDesc.Text == string.Empty
                || TextBoxUnit.Text == string.Empty) return false;
            if (NUDPriceUnit.Value == 0 || NUDQTY.Value == 0) return false;
            if (comboBoxType.SelectedIndex == -1) return false;

            return Result;
        }
        void AddItem()
        {
            ItemRow = MasterData.assessments.AssItemsDataTable.NewAssItemsRow();
            string Type = string.Empty;

            ItemRow.Number = TextBoxSerial.Text;
            ItemRow.Item_Unit = TextBoxUnit.Text;
            ItemRow.Total_Price = (double)NUDPriceUnit.Value;
            ItemRow.Qty = (double)NUDQTY.Value;
            ItemRow.Description = TextBoxDesc.Text;

            switch (comboBoxType.SelectedIndex)
            {
                case 0: ItemRow.Item_Type = 0; Type = Item_TYPE.Supply.ToString(); break;
                case 1:
                    ItemRow.Item_Type = 1; Type = Item_TYPE.Implementation_Installation.ToString();
                    ItemRow.Qty = 100; break;
                case 2:
                    ItemRow.Item_Type = 2;
                    Type = Item_TYPE.Both.ToString(); ; ItemRow.Qty = 100; break;
            }

            DGV_Data.Rows.Add(ItemRow.Number, ItemRow.Description,
                        ItemRow.Item_Unit, ItemRow.Total_Price, ItemRow.Qty,
                        Type, (ItemRow.Total_Price * ItemRow.Qty));
            Serials.Add(ItemRow.Number);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckItemData())
            { setStatus("يجب إستكمال بيانات البند", 0); return; }
            if (Serials.Contains(TextBoxSerial.Text))
            { setStatus("تم إستخدام هذا المسلسل فى بند آخر", 0); return; }
            AddItem();
            setStatus("تم إضافة البند", 1);
            TotalAssessment();
            ResetItem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DeleteItem())
            { setStatus("تم مسح البند", 1); TotalAssessment(); }
            else setStatus("يجب إختيار البند أولاً", 0);
        }

        bool DeleteItem()
        {
            for (int i = 0; i < DGV_Data.Rows.Count; i++)
            {
                if (DGV_Data.Rows[i].Selected)
                {
                    Serials.Remove(DGV_Data.Rows[i].Cells[0].Value.ToString());
                    DGV_Data.Rows.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
