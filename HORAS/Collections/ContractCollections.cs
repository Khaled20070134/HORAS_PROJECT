using HORAS.Contracts;
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
using static HORAS.Enums;

namespace HORAS.Collections
{
    public partial class ContractCollections : Form
    {
        public ContractCollections()
        {
            InitializeComponent();
            loadContracts();
        }

        public void loadContracts()
        {
            comboBoxContracts.Items.Clear();
            var contracts = MasterData.Contracts.ContractDataTable.Where(x => x.Signed == true).ToList();
            foreach (var x in contracts)
                comboBoxContracts.Items.Add(x.Number);
        }
        private void comboBoxContracts_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadContractData();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBoxdownpayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int collectionID = int.Parse(listBoxdownpayment.SelectedItem.ToString());

            labeDPBank.Text = MasterData.Collections.CollectionsDataTable.FirstOrDefault(x => x.ID == collectionID).Bank_Name;
            labelDPAmount.Text = MasterData.NumericString(MasterData.Collections.CollectionsDataTable.FirstOrDefault(x => x.ID == collectionID).Amount);
            labelDPcolDate.Text = MasterData.Collections.CollectionsDataTable.FirstOrDefault(x => x.ID == collectionID).Col_Date.ToShortDateString();
            labelDPcolNum.Text = MasterData.Collections.CollectionsDataTable.FirstOrDefault(x => x.ID == collectionID).TransferNum;

        }

        private void comboBoxContracts_DropDown(object sender, EventArgs e)
        {
            loadContracts();
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            comboBoxContracts.SelectedIndex = comboBoxContracts.FindStringExact(Displayallcontracts.ContractNumber);
            if (comboBoxContracts.SelectedIndex != -1) LoadContractData();
        }

        void LoadContractData()
        {
            MasterData.Collections.RefreshList();
            listBoxdownpayment.Items.Clear();
            MasterData.Contracts.RefreshList();
            MasterData.Collections.RefreshList();
            int id = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == (comboBoxContracts.SelectedItem).ToString()).ID;
            var DPlist = MasterData.Collections.CollectionsDataTable.Where(x => x.Contract_ID == id && x.Col_Type == (int)CollectionType.DownPayment).ToList();
            foreach (var X in DPlist)
                listBoxdownpayment.Items.Add(X.ID);
            labelTotalPaymentsAmount.Text = MasterData.NumericString(MasterData.Collections.GetTotalDownPayment(comboBoxContracts.SelectedItem.ToString()));
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

        private void label4_Click(object sender, EventArgs e)
        {
            if (listBoxdownpayment.SelectedIndex == -1)
            {
                setStatus("يجب إختيار تحصيل أولاً", 0);
                return;
            }
            string CollectionID = listBoxdownpayment.SelectedItem.ToString();
            MasterData.OpenFile(MasterData.GetFile( (char)Document_Type.Collections +"_" + labelDPcolNum.Text));
            setStatus("تم عرض الملف", 1);
        }
    }
}
