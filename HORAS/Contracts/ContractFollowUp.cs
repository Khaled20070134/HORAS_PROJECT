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
    public partial class ContractFollowUp : Form
    {
        int SelectedContractID;
        public ContractFollowUp()
        {
            InitializeComponent();
            MasterData.LoadMasterData();
            LoadComboxContract();
        }


        void LoadComboxContract()
        {
            CBContract.Items.Clear();
            MasterData.LoadMasterData();
            foreach (var Contract in MasterData.Contracts.ContractDataTable.Where(x=> x.Signed==true).ToList())
                CBContract.Items.Add(Contract.Number);
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
            if (CBContract.SelectedIndex == -1) return;
            SelectedContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == CBContract.SelectedItem.ToString()).ID;

            HorasDataSet.ContractRow SelectedContract = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.ID == SelectedContractID);

            labelDesc.Text = SelectedContract.Short_Desc;

            labelItemsCount.Text = MasterData.assessments.AssItemsAdapter.NotNullContracts().
                Where(X => X.Contract_ID == SelectedContractID).Count().ToString();

            labelTotalValue.Text = MasterData.NumericString(SelectedContract.Total_Amount);
            labelProfit.Text = MasterData.NumericString(SelectedContract.Total_Amount * SelectedContract.ProfitPercentage);
            int Temp = (int)(SelectedContract.BusinessInsuranceP * 100);
            labelInsurance.Text = Temp.ToString() + " %";
            labelDownPayment.Text = MasterData.NumericString(SelectedContract.DownpaymentP * SelectedContract.Total_Amount);
            labelDelayPenalty.Text = MasterData.NumericString(SelectedContract.DelayPenaltyP * SelectedContract.Total_Amount);
            labelInterimsCount.Text = MasterData.Interim.InterimsHeadDataTable.Where(X => X.ContractID == SelectedContractID).Count().ToString();
            labelInterimsValue.Text = MasterData.NumericString(MasterData.Contracts.TotalInterimsValue(CBContract.SelectedItem.ToString()));
            labelConfirmedExps.Text = MasterData.NumericString((double)
                MasterData.Contracts.ExpTrDataTable.Where(X => X.ContractID == SelectedContractID && !X.NeedConf).Sum(Y => Y.Amount));
            labelNotConfirmedExps.Text = MasterData.NumericString((double)
                MasterData.Contracts.ExpTrDataTable.Where(X => X.ContractID == SelectedContractID && X.NeedConf).Sum(Y => Y.Amount));

            List<double> Percentages = new List<double>();

            var ContractItems = MasterData.assessments.AssItemsAdapter.NotNullContracts().Where(X => X.Contract_ID == SelectedContractID);
            foreach (var ContractItem in ContractItems)
            {
                double DeliveredSum = 0;
                // GetList of Interims according to this contract
                var Interims = MasterData.Interim.InterimsHeadDataTable.Where(X => X.ContractID == SelectedContractID && !X.IsConfirm_DateNull());
                foreach (var interim in Interims)
                {
                    DeliveredSum += MasterData.Interim.InterimsItemsDataTable.
                        Where(X => X.HeadID == interim.ID && X.Number == ContractItem.Number).Sum(Y => Y.Qty);
                }

                if (DeliveredSum > ContractItem.Qty) DeliveredSum = ContractItem.Qty;

                Percentages.Add(DeliveredSum / ContractItem.Qty);
                DeliveredSum = 0;
            }
            labelCollections.Text = MasterData.NumericString(MasterData.Collections.GetTotalCollections(CBContract.SelectedItem.ToString()));
            Temp = (int)((Percentages.Sum() / Percentages.Count) * 100);
            labePercentage.Text = Temp.ToString() + "%";
            setStatus("تم تحميل بيانات التعاقد", 1);
        }

        private void CBContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContractData();
        }

        private void CBContract_DropDown(object sender, EventArgs e)
        {
            LoadComboxContract();
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            CBContract.SelectedIndex = CBContract.FindStringExact(Displayallcontracts.ContractNumber);
            if (CBContract.SelectedIndex != -1) LoadContractData();
        }
    }
}
