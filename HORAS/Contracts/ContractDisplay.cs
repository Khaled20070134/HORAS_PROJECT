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

namespace HORAS.Contracts
{
    public partial class ContractDisplay : Form
    {
        public ContractDisplay()
        {
            InitializeComponent();

        }

        void LoadComboxContract()
        {
            comboBox1.Items.Clear();
            MasterData.Contracts.RefreshList();
            foreach (var Contract in MasterData.Contracts.ContractDataTable.ToList())
                comboBox1.Items.Add(Contract.Number);
        }

        public ContractDisplay(string contractNumber)
        {
            InitializeComponent();
            foreach (var Contract in MasterData.Contracts.ContractDataTable.ToList())
                comboBox1.Items.Add(Contract.Number);

            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(contractNumber);
            buttonClose.Visible = true;
            loadData();
        }

        void loadData()
        {
            if (comboBox1.SelectedIndex == -1) return;
            string Contract_Number = comboBox1.SelectedItem.ToString();
            HorasDataSet.ContractRow ContractRow = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == Contract_Number);

            if (ContractRow.Contract_type == 0)
            {
                labelOwner.Text = MasterData.OwnersAndContractors.PartyDataTable.FindByID(ContractRow.Party).Name;
                labelContractor.Text = "حــورس";
                linkLabel1.Visible = true;
            }
            else
            {
                labelOwner.Text = "حــورس";
                labelContractor.Text = MasterData.OwnersAndContractors.PartyDataTable.FindByID(ContractRow.Party).Name;
                linkLabel1.Visible = false;
            }

            labelDesc.Text = ContractRow.Short_Desc;
            labelAmount.Text = MasterData.NumericString(ContractRow.Total_Amount);
            labelDownPayment.Text = MasterData.NumericString(ContractRow.Total_Amount * ContractRow.DownpaymentP/100);
            labelProfit.Text = MasterData.NumericString(ContractRow.Total_Amount * ContractRow.ProfitPercentage / 100);
            labelDelay.Text = MasterData.NumericString(ContractRow.Total_Amount * ContractRow.DelayPenaltyP / 100);
            labelGurantee.Text = MasterData.NumericString(ContractRow.Total_Amount * ContractRow.BusinessInsuranceP / 100);
            labelCreationDate.Text = ContractRow.CreationDate.ToLongDateString();
            labelItemsCount.Text = MasterData.assessments.NotNullContracts.Where(X => X.Contract_ID == ContractRow.ID).Count().ToString();
            labelDuration.Text = ContractRow.Duration.ToString() + " أشهر ";

            labelAssessment.Text = MasterData.assessments.NotNullContracts.First(X => X.Contract_ID == ContractRow.ID).AssID.ToString();

            if (ContractRow.IsStartDateNull()) labelStartDate.Text = "لم يتم بدأ التنفيذ الفعلى";
            else labelStartDate.Text = ContractRow.StartDate.ToLongDateString();

            if (ContractRow.Signed) labelSignStatus.Text = "تم التوقيع";
            else labelSignStatus.Text = "لم يتم التوقيع";

            if (ContractRow.FI_Completed) labelFiStatus.Text = "تم الاغلاق";
            labelFiStatus.Text = "لم يتم الاغلاق";

            if (ContractRow.IM_Completed) labelIMStatus.Text = "تم الانتهاء";
            labelIMStatus.Text = "لم يتم الانتهاء";

            LoadItems(ContractRow.ID, int.Parse(labelAssessment.Text));

            setStatus("تم تحميل بيانات التعاقد", 1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        void LoadItems(int ContractID, int AssID)
        {
            DGVItems.Rows.Clear();
            var ItemsList = MasterData.assessments.AssItemsAdapter.NotNullContracts().Where(X => X.AssID == AssID
            && X.Contract_ID == ContractID).ToList();

            foreach (var Item in ItemsList)
            {
                string ItemType = MasterData.GetItemTypeString(Item.Item_Type);
                string LOL = MasterData.NumericString(Item.LOL) + " %";
                DGVItems.Rows.Add(Item.Number, Item.Description, MasterData.NumericString(Item.Total_Price), ItemType, LOL);
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            LoadComboxContract();
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            Displayallcontracts Form = new Displayallcontracts();
            Form.ShowDialog();
            LoadComboxContract();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Displayallcontracts.ContractNumber);
            loadData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                setStatus("يجب إختيار تعاقد مالك أولاً", 0);
                return;
            }
            Displayallcontracts Form = new Displayallcontracts(comboBox1.SelectedItem.ToString());
            Form.ShowDialog();
        }
    }
}
