using HORAS.Contracts;
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

namespace HORAS.Collections
{
    public partial class NewCoolection : Form
    {
        public NewCoolection()
        {
            InitializeComponent();
            LoadContracts();
        }

        void Reset()
        {
            NUDAmount.Value = NUDTransferNum.Value = 0;
            textBoxBankName.Text = textBoxFile.Text = string.Empty;
        }

        void LoadContracts()
        {
            MasterData.Contracts.RefreshList();
            comboBoxContracts.Items.Clear();
            var OwnerContracts = MasterData.Contracts.ContractDataTable.Where(X => X.Signed == true && !X.FI_Completed).ToList();
            foreach (var Item in OwnerContracts)
                comboBoxContracts.Items.Add(Item.Number);
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

        bool CheckData()
        {
            if (textBoxBankName.Text == string.Empty) return false;
            if (textBoxFile.Text == string.Empty) return false;
            if (comboBoxContracts.SelectedIndex == -1) return false;
            if (NUDAmount.Value == 0 || NUDTransferNum.Value == 0) return false;
            return true;
        }

        private void comboBoxContracts_DropDown(object sender, EventArgs e)
        {
            LoadContracts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                setStatus("برجاء مراجعه جميع بيانات التحصيل", 0);
                return;
            }

            int ContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == comboBoxContracts.SelectedItem.ToString()).ID;

            HorasDataSet.CollectionsRow Col_row = MasterData.Collections.CollectionsDataTable.NewCollectionsRow();
            Col_row.Bank_Name = textBoxBankName.Text;
            Col_row.TransferNum = NUDTransferNum.Value.ToString();
            Col_row.Amount = (double)NUDAmount.Value;
            Col_row.Col_Date = dateTimePicker1.Value;
            Col_row.Contract_ID = ContractID;
            if (RBDownPay.Checked) Col_row.Col_Type = (int)Enums.CollectionType.DownPayment;
            else Col_row.Col_Type = (int)Enums.CollectionType.SalesInvoiceing;
            MasterData.Collections.AddNewCollection(Col_row);

            string FileName = (char)Enums.Document_Type.Collections + "_" + Col_row.TransferNum;
            MasterData.CopyFile(textBoxFile.Text, FileName);
            setStatus("تم إضافة التحصيل على التعاقد بنجاح", 1);
            Reset();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            textBoxFile.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "pdf files (*.pdf)|*.pdf";
            FileDialoge.InitialDirectory = Application.StartupPath;
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                textBoxFile.Text = FileDialoge.FileName;
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            comboBoxContracts.SelectedIndex = comboBoxContracts.FindStringExact(Displayallcontracts.ContractNumber);
        }
    }
}
