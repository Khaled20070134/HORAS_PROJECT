using HORAS.Database;
using HORAS.Information;
using HORAS.Properties;
using HORAS.SuppliersAndClients;
using System.Data;
using System.Globalization;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS.Contracts
{
    public partial class NewOwnerContract : Form
    {
        //Contractor SelectedContractor;
        Contractor SelectedOwner;
        assessment SelectedAssessment;
        HorasDataSet.ContractRow contract;
        AssItemsRow ItemRow;
        AssItemsDataTable ItemsList;
        bool dataloaded = false;
        float TotalAssessment
        {
            get { return float.Parse(labelItemTotal.Text); }
            set
            {
                labelItemTotal.Text = value.ToString("N", new CultureInfo("en-US"));
            }
        }
        public NewOwnerContract()
        {
            InitializeComponent();
            //LoadData();

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
            contract.DelayPenaltyP = (double)NUDDelayP.Value /100;
            contract.CreatedBy = MasterData.LoggedEmployee.ID;
            contract.CreationDate = DTPCreationDate.Value;
            contract.Duration = (int)NUDDuration.Value;
            contract.BusinessInsuranceP = (double)NUDGuranteeP.Value / 100;
            contract.DownpaymentP = (double)NUDDownPaymentP.Value / 100;
            contract.ProfitPercentage = (double)NUDLOL.Value / 100;
            contract.Total_Amount = TotalAssessment;
            contract.Number = TextBoxNumber.Text;
            contract.StartedBy = -1;
            contract.Contract_type = (int)ContractType.OwnerContract;
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
        void UpdateFIData()
        {
            LabelLOL.Text = ((decimal)TotalAssessment * NUDLOL.Value /100).ToString("N", new CultureInfo("en-US"));
            LabelDownPayment.Text = ((decimal)TotalAssessment * NUDDownPaymentP.Value / 100).ToString("N", new CultureInfo("en-US"));
            LabelBusinessG.Text = ((decimal)TotalAssessment * NUDGuranteeP.Value / 100).ToString("N", new CultureInfo("en-US"));
            LabelDelayP.Text = ((decimal)TotalAssessment * NUDDelayP.Value / 100).ToString("N", new CultureInfo("en-US"));
        }

        void LoadContractors()
        {
            MasterData.LoadMasterData();
            ComboBoxOwner.Items.Clear();
            // Load Contractor and Owners
            foreach (var C in MasterData.OwnersAndContractors.PartyDataTable)
                ComboBoxOwner.Items.Add(C.Name);
        }

        void LoadAsses()
        {
            MasterData.LoadMasterData();
            CBAssessment.Items.Clear();
            // Load Assessments

            var ASSLIST = from Head in MasterData.assessments.AssessmentHeadDataTable
                          join
                          Items in MasterData.assessments.AssItemsDataTable on Head.ID equals Items.AssID
                          where Items.IsContract_IDNull()
                          where Head.Confirmed = true
                          select  Head.About;

            var ASSLIST2 = ASSLIST.Distinct();

            foreach (var ass in ASSLIST2)
                CBAssessment.Items.Add(ass);
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

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBAssessment.SelectedIndex != -1)
            {
                SelectedAssessment = new assessment();
                var C = MasterData.assessments.AssessmentHeadDataTable.FirstOrDefault(x => x.About == CBAssessment.SelectedItem.ToString());
                SelectedAssessment.ID = C.ID;
                LoadItemsData(SelectedAssessment.ID);
                SetItems();
                MasterData.styleGridView(DGVItems);
                dataloaded = true;
            }
        }

        void LoadItemsData(int AssID)
        {
            dataloaded = false;
            DGVItems.Rows.Clear();
            ItemsList =
                MasterData.assessments.AssItemsAdapter.GetNotAssignedItems(AssID);

            if (ItemsList.Count == 0)
            {
                setStatus("لا يوجد بنود لم يتم تعيينها فى تلك المقايسة", 0);
                return;
            }



            string Type = string.Empty;

            foreach (var Item in ItemsList)
            {

                double Total = 0;
                Total = Item.Total_Price * Item.Qty;
                switch (Item.Item_Type)
                {
                    case 0: Type = Item_TYPE.Supply.ToString(); break;
                    case 1:
                        Type = Item_TYPE.Implementation_Installation.ToString();
                        break;
                    case 2: Type = Item_TYPE.Both.ToString(); break;
                }
                DGVItems.Rows.Add(Item.Number,
                        Item.Item_Unit, Item.Total_Price, Item.Qty, Type, MasterData.NumericString(Total));
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
                setStatus("يجب إختيار المالك والمقاول", 0);
                return false;
            }

            if (CBAssessment.SelectedIndex == -1)
            {
                setStatus("يجب إختيار مقايسة المشروع", 0);
                return false;
            }
            if (TotalAssessment == 0 || NUDDuration.Value == 0)
            {
                setStatus("يجب إدخال مبلغ التعاقد ومدة التنفيذ", 0);
                return false;
            }
            if (NUDDuration.Value == 0)
            {
                setStatus("يجب أن تكون نسبة الربح أكبر من صفر", 0);
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


            if (SelectedItems.Count == 0)
            {
                setStatus("يجب إختيار بنداً واحدة عالأقل", 0);
                return false;
            }

            return result;
        }

        void Reset()
        {
            TextBoxFile1.Text = TextBoxFile2.Text = TextBoxNumber.Text
                = TextBoxShortDesc.Text = string.Empty;
            NUDDelayP.Value = NUDDownPaymentP.Value = NUDDuration.Value = NUDGuranteeP.Value = 0;
            dataloaded = false;
            SelectedItems.Clear();
            DGVItems.Rows.Clear();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            bool ContractOK = CheckContractData();
            if (ContractOK)
            {
                SetNewContractData();
                MasterData.Contracts.AddNew(contract, SelectedItems);
                Reset();
                setStatus("تم تسجيل بيانات التعاقد بنجاح", 1);
            }

        }

        private void NUDTotalAmountP_ValueChanged(object sender, EventArgs e)
        {
            UpdateFIData();
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
                ItemRow.Item_Unit = DGVItems.Rows[i].Cells[1].Value.ToString();
                ItemRow.Total_Price = double.Parse(DGVItems.Rows[i].Cells[2].Value.ToString());
                ItemRow.Qty = double.Parse(DGVItems.Rows[i].Cells[3].Value.ToString());
                ItemRow.Item_Type = (int)(Item_TYPE)Enum.Parse(typeof(Item_TYPE), DGVItems.Rows[i].Cells[4].Value.ToString());
                Sum += ItemRow.Total_Price * ItemRow.Qty;
                SelectedItems.Add(ItemRow);

            }
            labelItemCount.Text = SelectedItems.Count.ToString();
            labelItemTotal.Text = MasterData.NumericString(Sum);
            UpdateFIData();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TextBoxFile1.Text = string.Empty;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TextBoxFile2.Text = string.Empty;
        }

        private void ComboBoxOwner_DropDown(object sender, EventArgs e)
        {
            LoadContractors();
        }

        private void CBAssessment_DropDown(object sender, EventArgs e)
        {
            LoadAsses();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (ComboBoxOwner.SelectedIndex != -1)
            {
                VendorData InfForm = new VendorData(SelectedOwner);
                InfForm.ShowDialog();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            NewParty Party = new NewParty(true);
            Party.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "pdf files (*.pdf)|*.pdf";
            FileDialoge.InitialDirectory = Application.StartupPath;
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                TextBoxFile1.Text = FileDialoge.FileName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "pdf files (*.pdf)|*.pdf";
            FileDialoge.InitialDirectory = Application.StartupPath;
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                TextBoxFile2.Text = FileDialoge.FileName;
        }

        private void DGVItems_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void DGVItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!dataloaded) return;
            if (DGVItems.SelectedRows.Count == 0) return;
            if (CBAssessment.SelectedIndex == -1) return;

            if (DGVItems.SelectedRows[0].Cells[0].Value == null) return;

            int AssID = MasterData.assessments.AssessmentHeadDataTable.
                FirstOrDefault(X => X.About == CBAssessment.SelectedItem.ToString()).ID;

            string ItemNum = DGVItems.SelectedRows[0].Cells[0].Value.ToString();

            richTextBox1.Text = MasterData.assessments.AssItemsDataTable.
                FirstOrDefault(X => X.Number == ItemNum && X.AssID == AssID).Description;
        }
    }
}
