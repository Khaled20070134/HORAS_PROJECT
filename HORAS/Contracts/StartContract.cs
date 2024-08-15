using HORAS.Database;
using HORAS.Information;
using HORAS.Properties;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HORAS.Database.HorasDataSet;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HORAS.Contracts
{
    public partial class StartContract : Form
    {

       
        Contract Selected_Contract;
        public StartContract()
        {
            InitializeComponent();
            MasterData.Contracts.RefreshList();
            // Load unsigned Contracts Number
            //MasterData.Contracts.ContractDataTable.SignedColumn.AllowDBNull = true;
            foreach (var C in MasterData.Contracts.ContractDataTable.ToList())
            {
                if (C.Signed == false)
                    CBNumber.Items.Add(C.Number);
            }
        }

        private void CBNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadContractData()
        {
            
            //LabelAssNumber.Text = Selected_Contract.assessment.ID.ToString();
            LabelContractDate.Text = Selected_Contract.CreationDate.ToShortDateString();
            DTPStartDate.MinDate = Selected_Contract.CreationDate;
            //LabelOwnerName.Text =
            //    MasterData.OwnersAndContractors.PartyDataTable.FirstOrDefault(X => X.ID == Selected_Contract.FirstParty).Name;
            LabelDuration.Text = Selected_Contract.Duration.ToString();
            LabelShortDesc.Text = Selected_Contract.S_Desc;
            LabelFinishDate.Text = DateTime.Now.AddMonths(Selected_Contract.Duration).ToShortDateString();
            TotalAmount();
        }

        private void DTPStartDate_ValueChanged(object sender, EventArgs e)
        {
            LabelFinishDate.Text = DTPStartDate.Value.AddDays(Selected_Contract.Duration * 7).ToShortDateString();
        }

        double Sum = 0;

        void LoadData()
        {

            if (CBNumber.SelectedIndex != -1)
            {
                string TempNum = CBNumber.SelectedItem.ToString();
                var Object =
                  MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == TempNum);
                Selected_Contract = new Contract();
                Selected_Contract.ID = Object.ID;
                Selected_Contract.Duration = Object.Duration;
                //Selected_Contract.assessment.ID = Object.ID_Assessment;
                Selected_Contract.FirstParty = Object.Party;
                Selected_Contract.Totall_Amount = Object.Total_Amount;
                Selected_Contract.S_Desc = Object.Short_Desc;
                Selected_Contract.CreationDate = Object.CreationDate;
                // Selected_Contract.Signed = Object.Signed;

                if (Object.Contract_type == 0)
                {
                    LabelOwnerName.Text = MasterData.OwnersAndContractors.PartyDataTable.FindByID(Object.Party).Name;
                    LabelContractor.Text = "حــورس جــروب";
                }
                else
                {
                    LabelOwnerName.Text = "حــورس جــروب";
                    LabelContractor.Text = MasterData.OwnersAndContractors.PartyDataTable.FindByID(Object.Party).Name;
                }
                LoadContractData();
            }
        }
        void TotalAmount()
        {
            Sum = 0;
            var List = MasterData.assessments.AssItemsAdapter.GetContractItems(Selected_Contract.ID);
            foreach (var Item in List)
            {
                //if (Item.Item_Type == 0)
                //    Sum += (Item.Total_Price * Item.Qty);
                //else
                Sum += Item.Total_Price;
            }
            LabelTotal.Text = Sum.ToString("N", new CultureInfo("en-US"));
        }

        void Start()
        {
            HorasDataSet.ContractRow Contract = MasterData.Contracts.ContractDataTable.NewContractRow();
            Contract.ID = Selected_Contract.ID;
            Contract.StartDate = DTPStartDate.Value;
            Contract.StartedBy = MasterData.LoggedEmployee.ID;
            MasterData.Contracts.Start(Contract);
        }

        void Sign()
        {
            HorasDataSet.ContractRow Contract = MasterData.Contracts.ContractDataTable.NewContractRow();
            Contract.ID = Selected_Contract.ID;
            Contract.Signed = true;
            MasterData.Contracts.Sign(Contract.ID);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CBNumber.SelectedIndex != -1)
            {
                Contracts_FI_Data Form = new Contracts_FI_Data(Selected_Contract.ID, Sum);
                Form.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CBNumber.SelectedIndex == -1)
            {
                setStatus("يجب إختيار التعاقد أولاً", 0);
                return;
            }
            Start();
            setStatus("تم بدء التنفيذ الفعلى للتعاقد", 1);
            Reset();
            CBNumber.Items.Remove(CBNumber.SelectedItem.ToString());
        }

        private void RBSign_CheckedChanged(object sender, EventArgs e)
        {
            if (RBSign.Checked)
            {
                buttonSign.Visible = true;
                groupBoxStart.Visible = false;
                CBNumber.Items.Clear();
                // Load unsigned Contracts Number
                foreach (var C in MasterData.Contracts.ContractDataTable)
                {
                    if (C.Signed == false)
                        CBNumber.Items.Add(C.Number);
                }

            }
            if (RBStart.Checked)
            {
                buttonSign.Visible = false;
                groupBoxStart.Visible = true;
                CBNumber.Items.Clear();
                // Load not started Contracts Number
                foreach (var C in MasterData.Contracts.ContractTableAdapter.GetNotStartedContracts())
                    CBNumber.Items.Add(C.Number);

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

        void Reset()
        {
            LabelContractDate.Text = LabelContractor.Text = LabelDuration.Text = LabelOwnerName.Text =
                LabelFinishDate.Text = LabelShortDesc.Text = LabelTotal.Text = string.Empty;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            if (CBNumber.SelectedIndex == -1)
            {
                setStatus("يجب إختيار التعاقد أولاً", 0);
                return;
            }
            Sign();
            setStatus("تم إمضاء وحفظ التعاقد", 1);
            Reset();
            CBNumber.Items.Remove(CBNumber.SelectedItem.ToString());
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            if (RBSign.Checked)
            {
                Displayallcontracts Con = new Displayallcontracts(false);
                Con.ShowDialog();
                CBNumber.SelectedIndex = CBNumber.FindStringExact(Displayallcontracts.ContractNumber);
                if (CBNumber.SelectedIndex != -1) LoadData();
            }
            else if (RBStart.Checked)
            {

                Displayallcontracts Con2 = new Displayallcontracts(true);
                Con2.ShowDialog();
                if (MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == Displayallcontracts.ContractNumber).IsStartDateNull() == false)
                { setStatus("هذا العقد تم بدءه بالفعل", 0); }
                else { 
                CBNumber.SelectedIndex = CBNumber.FindStringExact(Displayallcontracts.ContractNumber);
                if (CBNumber.SelectedIndex != -1) LoadData();
            }
            }


        }
    }
}
