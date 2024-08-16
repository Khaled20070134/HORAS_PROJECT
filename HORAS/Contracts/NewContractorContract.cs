using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using HORAS.HorasDataSetTableAdapters;
using HORAS.Information;
using HORAS.Properties;
using HORAS.SuppliersAndClients;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HORAS.Contracts
{
    public partial class NewContractorContract : Form
    {
        Dictionary<string, string> desriptiondictionary = new Dictionary<string, string>();
        //Contractor SelectedContractor;
        Contractor SelectedOwner;
        assessment SelectedAssessment;
        Contract SelectedOwnerContract;
        HorasDataSet.ContractRow contract;
        AssItemsRow ItemRow;
        AssItemsDataTable ItemsList;
        List<AssItemsRow> ListToSave = new List<AssItemsRow>();
        //List<AssItemsRow> ItemsToSave = new List<AssItemsRow>();
        void getItemdata() 
        {
            ListToSave.Clear();
            for (int i=0; i< DGVContractItems.Rows.Count-1;i++)
            {
                ItemRow = MasterData.Database.AssItems.NewAssItemsRow();
                ItemRow.Number = DGVContractItems.Rows[i].Cells[0].Value.ToString();
                ItemRow.Qty = double.Parse(DGVContractItems.Rows[i].Cells[1].Value.ToString());
                ItemRow.Item_Unit = DGVContractItems.Rows[i].Cells[2].Value.ToString();
                ItemRow.Total_Price = double.Parse(DGVContractItems.Rows[i].Cells[3].Value.ToString());
                ItemRow.LOL = double.Parse(DGVContractItems.Rows[i].Cells[4].Value.ToString());
                ItemRow.Item_Type = (int)(Item_TYPE)Enum.Parse(typeof(Item_TYPE), DGVContractItems.Rows[i].Cells[5].Value.ToString());
                ItemRow.Description = desriptiondictionary[ItemRow.Number];
                ListToSave.Add(ItemRow);
            }

            
        }
        float TotalAssessment
        {
            get { return float.Parse(TotalvalueLBL.Text); }
            set
            {
                TotalvalueLBL.Text = value.ToString("N", new CultureInfo("en-US"));
            }
        }
        public NewContractorContract()
        {
            InitializeComponent();
            LoadOwnerContracts();
            ItemTypeCB.DataSource = Enum.GetValues(typeof(Enums.Item_TYPE));
        }

        void SetNewContractData()
        {
            contract = MasterData.Contracts.ContractDataTable.NewContractRow();
            contract.ID = int.MinValue;
            contract.Signed = false;
            contract.Short_Desc = TextBoxShortDesc.Text;
            contract.FI_Completed = false;
            contract.IM_Completed = false;
            contract.Party = SelectedOwner.ID;
            contract.DelayPenaltyP = (float)NUDDelayP.Value;
            contract.CreatedBy = MasterData.LoggedEmployee.ID;
            contract.CreationDate = DTPCreationDate.Value;
            contract.Duration = (int)NUDDuration.Value;
            contract.BusinessInsuranceP = (float)NUDGuranteeP.Value;
            contract.DownpaymentP = (float)NUDDownPaymentP.Value;
            contract.ProfitPercentage = (float)NUDLOL.Value;
            contract.Total_Amount = TotalAssessment;
            contract.Number = TextBoxNumber.Text;
            contract.StartedBy = -1;
            contract.Contract_type = (int)ContractType.ContractorContract;
            contract.OwnerContractID = SelectedOwnerContract.ID;
            if (TextBoxFile1.Text != string.Empty || TextBoxFile2.Text != string.Empty)
                CopyFiles();
        }

        void CopyFiles()
        {
            if (!Path.Exists(Settings1.Default.DB_Files))
            {
                FilesPath Filepath = new FilesPath();
                Filepath.ShowDialog();
            }
            if (TextBoxFile1.Text != string.Empty)
            {
                string File1Name = "C_" + contract.Number + "_1";
                MasterData.CopyFile(TextBoxFile1.Text, File1Name);
            }
            if (TextBoxFile2.Text != string.Empty)
            {
                string File1Name = "C_" + contract.Number + "_2";
                MasterData.CopyFile(TextBoxFile2.Text, File1Name);
            }
        }


        void LoadParties()
        {
            MasterData.LoadMasterData();
            ComboBoxOwner.Items.Clear();
            foreach (var C in MasterData.OwnersAndContractors.PartyDataTable)
                ComboBoxOwner.Items.Add(C.Name);
        }

        private void ComboBoxOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxOwner.SelectedIndex != -1)
            {
                SelectedOwner = new Contractor();
                var C = MasterData.OwnersAndContractors.PartyDataTable.FirstOrDefault(x => x.Name == ComboBoxOwner.SelectedItem.ToString());
                SelectedOwner.Address = C.Address;
                SelectedOwner.Name = C.Name;
                SelectedOwner.ID = C.ID;
                SelectedOwner.TaxRegNumber = C.TaxRegNumber;
            }
        }

        void LoadData()
        {
            if (CBAssessmentContracts.SelectedIndex != -1)
            {
                DGVContractItems.Rows.Clear();
                ListToSave.Clear();
                updateFIData();

                SelectedOwnerContract = new Contract();
                SelectedOwnerContract.Number = CBAssessmentContracts.SelectedItem.ToString();
                SelectedOwnerContract.ID = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == SelectedOwnerContract.Number).ID;

                var ItemsList = MasterData.assessments.AssItemsAdapter.NotNullContracts().Where(X => X.Contract_ID == SelectedOwnerContract.ID).ToList();

                SelectedAssessment = new assessment();
                SelectedAssessment.ID = ItemsList[0].AssID;
                LoadItemsData(SelectedOwnerContract.ID);
                SetItems();
                MasterData.styleGridView(DGVItems);
            }
        }
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBAssessmentContracts.SelectedIndex != -1)
                LoadData();
        }

        void LoadItemsData(int C_ID)
        {
            DGVItems.Rows.Clear();
            ItemsList =
                MasterData.assessments.AssItemsAdapter.GetContractItems(C_ID);
            string Type = string.Empty;

            foreach (var Item in ItemsList)
            {
                double Total = 0;
                switch (Item.Item_Type)
                {
                    case 0: Type = Item_TYPE.Supply.ToString(); Total = Item.Total_Price * Item.Qty; break;
                    case 1:
                        Type = Item_TYPE.Implementation_Installation.ToString();
                        Total = Item.Total_Price; break;
                    case 2: Type = Item_TYPE.Both.ToString(); Total = Item.Total_Price; break;
                }
                DGVItems.Rows.Add(Item.Number,
                        Item.Item_Unit, Item.Total_Price, Item.Qty, Item.LOL, Type, Total);
            }

            setStatus("تم تحميل بيانات المقايسة", 1);
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

        bool CheckContractData()
        {
            bool result = true;
            if (SelectedOwner == null)
            {
                setStatus("يجب إختيار المقاول", 0);
                return false;
            }

            if (DGVContractItems.RowCount == 0)
            {
                setStatus("يجب ادخال بنود التعاقد", 0);
                return false;
            }
            if (NUDDuration.Value == 0)
            {
                setStatus("يجب إدخال مدة التنفيذ", 0);
                return false;
            }

            if (TextBoxNumber.Text != string.Empty)
            {
                var Data = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == TextBoxNumber.Text);
                if (Data != null)
                {
                    setStatus("رقم التعاقد تم تسجيله مسبقاً", 0);
                    return false;
                }
            }

            if (TextBoxShortDesc.Text == string.Empty)
            {
                setStatus("يجب وضع وصف للتعاقد", 0);
                return false;
            }

            if (DGVContractItems.Rows.Count == 1)
            {
                setStatus("يجب تحديد بنود تعاقد المقاول", 0);
                return false;
            }

            return result;
        }

        void Reset()
        {
            TextBoxFile1.Text = TextBoxFile2.Text = TextBoxNumber.Text
                = TextBoxShortDesc.Text = string.Empty;
            NUDDelayP.Value = NUDDownPaymentP.Value = NUDDuration.Value = NUDGuranteeP.Value = 0;
            SelectedItems.Clear();
            DGVItems.Rows.Clear();
            DGVContractItems.Rows.Clear();
            ListToSave.Clear();
            updateFIData();
            DescTxt.Text = string.Empty;
            NUDItemQ.Value = PriceNUD.Value = 0;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            bool ContractOK = CheckContractData();
            if (ContractOK)
            {
                SetNewContractData();

                // Add Contract 
                int ContractID = MasterData.Contracts.AddNew(contract);

                // Add Assessment
                AddAssessment(ContractID);

                Reset();
                setStatus("تم تسجيل بيانات التعاقد بنجاح", 1);
                MasterData.LoadMasterData();
            }
        }

        int AddAssessment(int ContractID)
        {
            MasterData.assessments.AssessmentRow = MasterData.assessments.AssessmentHeadDataTable.NewAssessmentHeadRow();
            MasterData.assessments.AssessmentRow.Confirmed = true;
            MasterData.assessments.AssessmentRow.ConfirmedBy = MasterData.LoggedEmployee.ID;
            MasterData.assessments.AssessmentRow.ConfirmationDate = DateTime.Now;
            MasterData.assessments.AssessmentRow.Subject = TextBoxShortDesc.Text;
            MasterData.assessments.AssessmentRow.About = TextBoxShortDesc.Text;
            MasterData.assessments.AssessmentRow.ID = -1;
            getItemdata();
            SetItemsIDAndContract(ContractID);
            int AssHeadID = MasterData.assessments.AddNew(ListToSave);
            return AssHeadID;
        }

        void SetItemsIDAndContract(int ContractID)
        {
            int StartItemIndex = 0;
            if (MasterData.assessments.AssItemsDataTable.Count > 0)
                StartItemIndex = MasterData.assessments.AssItemsDataTable.Max(X => X.ID) + 1;

            for (int i = 0; i < ListToSave.Count; i++)
            { ListToSave[i].ID = StartItemIndex + i; ListToSave[i].Contract_ID = ContractID; }

        }

        private void NUDTotalAmountP_ValueChanged(object sender, EventArgs e)
        {
            //UpdateFIData();
            updateFIData();
        }

        List<AssItemsRow> SelectedItems = new List<AssItemsRow>();

        void SetItems()
        {
            SelectedItems.Clear();
            double Sum = 0;
            for (int i = 0; i < DGVItems.RowCount; i++)
            {
                ItemRow = MasterData.Database.AssItems.NewAssItemsRow();
                ItemRow.AssID = SelectedAssessment.ID;
                ItemRow.Number = DGVItems.Rows[i].Cells[0].Value.ToString();
                //ItemRow.Description = DGVItems.Rows[i].Cells[1].Value.ToString();
                ItemRow.Item_Unit = DGVItems.Rows[i].Cells[1].Value.ToString();
                ItemRow.Total_Price = double.Parse(DGVItems.Rows[i].Cells[2].Value.ToString());
                ItemRow.Qty = double.Parse(DGVItems.Rows[i].Cells[3].Value.ToString());
                ItemRow.Item_Type = (int)(Item_TYPE)Enum.Parse(typeof(Item_TYPE), DGVItems.Rows[i].Cells[5].Value.ToString());
                Sum += ItemRow.Total_Price;
                SelectedItems.Add(ItemRow);
            }
            labelItemTotal.Text = MasterData.NumericString(Sum);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TextBoxFile1.Text = string.Empty;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TextBoxFile2.Text = string.Empty;
        }

        void LoadOwnerContracts()
        {
            MasterData.Contracts.RefreshList();
            CBAssessmentContracts.Items.Clear();
            var OwnerContracts = MasterData.Contracts.ContractDataTable.Where(X => X.Signed == true && !X.IsStartDateNull() && !X.IM_Completed).ToList();
            foreach (var Item in OwnerContracts)
                CBAssessmentContracts.Items.Add(Item.Number);
        }

        private void CBAssessmentContracts_DropDown(object sender, EventArgs e)
        {

            LoadOwnerContracts();
            // LoadContracts();
        }

        private void DGVItems_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVItems.SelectedRows.Count == 0) return;
            int ContractID = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == SelectedOwnerContract.Number).ID;
            string itemno = DGVItems.SelectedRows[0].Cells[0].Value.ToString();
            DescTxt.Text = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault(
                x => x.Contract_ID == ContractID && x.AssID == SelectedAssessment.ID && x.Number == itemno).Description;

            NUDItemQ.Maximum = (decimal)MasterData.Contracts.GetRemainingItem(SelectedOwnerContract.Number, itemno);

            labelRemain.Text = NUDItemQ.Maximum.ToString();
        }

        private void DGVItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void ItemTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        AssItemsRow NewItem;
        List<AssItemsRow> NewList = new List<AssItemsRow>();

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (DGVItems.SelectedRows.Count == 0)
            {
                setStatus("يجب إختيار البند أولاً", 0);
                return;
            }



            double Ownertotalvalue = double.Parse(DGVItems.SelectedRows[0].Cells[2].Value.ToString());
            if (NUDItemQ.Value < 1) { setStatus("كميه او نسبة البند لا يمكن ان تكون صفر", 0); return; }
            if (PriceNUD.Value == 0)
            {
                setStatus("قيمة البند لا يجب ان تكون صفر", 0); return;
            }
            if (PriceNUD.Value > (decimal)Ownertotalvalue)
            {
                setStatus("قيمة البند يجب ان تكون اقل", 0); return;
            }

            MasterData.assessments.AssItemsRow = MasterData.assessments.AssItemsDataTable.NewAssItemsRow();
            //  NewItem = MasterData.assessments.AssItemsDataTable.NewAssItemsRow();

            MasterData.assessments.AssItemsRow.Number = DGVItems.SelectedRows[0].Cells[0].Value.ToString();
            MasterData.assessments.AssItemsRow.Qty = (double)NUDItemQ.Value;
            MasterData.assessments.AssItemsRow.Item_Type = (int)(Item_TYPE)Enum.Parse(typeof(Enums.Item_TYPE), ItemTypeCB.SelectedItem.ToString());
            MasterData.assessments.AssItemsRow.LOL = (double)DGVItems.SelectedRows[0].Cells[4].Value;
            MasterData.assessments.AssItemsRow.Total_Price = (double)PriceNUD.Value;
            MasterData.assessments.AssItemsRow.Description = DescTxt.Text;
            MasterData.assessments.AssItemsRow.Item_Unit = DGVItems.SelectedRows[0].Cells[1].Value.ToString();
            desriptiondictionary.Add(MasterData.assessments.AssItemsRow.Number, MasterData.assessments.AssItemsRow.Description);
            //ItemsToSave.Add(MasterData.assessments.AssItemsRow);
            NewList.Add(MasterData.assessments.AssItemsRow);
            DGVContractItems.Rows.Add(MasterData.assessments.AssItemsRow.Number,
                MasterData.assessments.AssItemsRow.Qty, MasterData.assessments.AssItemsRow.Item_Unit, MasterData.assessments.AssItemsRow.Total_Price,
                MasterData.assessments.AssItemsRow.LOL, ItemTypeCB.SelectedItem.ToString());



            //NewItem = MasterData.assessments.AssItemsDataTable.NewAssItemsRow();

            //NewItem.Number = DGVItems.SelectedRows[0].Cells[0].Value.ToString();
            //NewItem.Qty = (double)NUDItemQ.Value;
            //NewItem.Item_Type = (int)(Item_TYPE)Enum.Parse(typeof(Enums.Item_TYPE), ItemTypeCB.SelectedItem.ToString());
            //NewItem.LOL = (double)DGVItems.SelectedRows[0].Cells[4].Value;
            //NewItem.Total_Price = (double)PriceNUD.Value;
            //NewItem.Description = DescTxt.Text;
            //NewItem.Item_Unit = DGVItems.SelectedRows[0].Cells[1].Value.ToString();
            // ItemsToSave.Add(NewItem);
            // DGVContractItems.Rows.Add(NewItem.Number, NewItem.Qty, NewItem.Total_Price, NewItem.LOL, ItemTypeCB.SelectedItem.ToString());

            setStatus("تم اضافه البند بنجاح", 1);

            updateFIData();
            DGVItems.SelectedRows[0].Visible = false;
            DGVItems.SelectedRows[0].Selected = false;
            DescTxt.Text = string.Empty;
            NUDItemQ.Value = PriceNUD.Value = 0;
        }

        void updateFIData()
        {
            double totalvalue = 0;
            for (int i = 0; i < DGVContractItems.RowCount - 1; i++)
                totalvalue += double.Parse(DGVContractItems.Rows[i].Cells[3].Value.ToString());
            TotalvalueLBL.Text = MasterData.NumericString(totalvalue);

            LabelDelayP.Text = MasterData.NumericString((double)(NUDDelayP.Value / 100) * totalvalue);
            LabelDownPayment.Text = MasterData.NumericString((double)(NUDDownPaymentP.Value / 100) * totalvalue);
            LabelBusinessG.Text = MasterData.NumericString((double)(NUDGuranteeP.Value / 100) * totalvalue);
            LabelLOL.Text = MasterData.NumericString((double)(NUDLOL.Value / 100) * totalvalue);
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void DGVContractItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBoxOwner_DropDown(object sender, EventArgs e)
        {
            LoadParties();
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            CBAssessmentContracts.SelectedIndex = CBAssessmentContracts.FindStringExact(Displayallcontracts.ContractNumber);
            if (CBAssessmentContracts.SelectedIndex != -1) LoadData();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            NewParty Party = new NewParty(true);
            Party.ShowDialog();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (ComboBoxOwner.SelectedIndex != -1)
            {
                VendorData InfForm = new VendorData(SelectedOwner);
                InfForm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "pdf files (*.pdf)|*.pdf";
            FileDialoge.InitialDirectory = Application.StartupPath;
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                TextBoxFile1.Text = FileDialoge.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "pdf files (*.pdf)|*.pdf";
            FileDialoge.InitialDirectory = Application.StartupPath;
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                TextBoxFile2.Text = FileDialoge.FileName;
        }

        private void DGVItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
