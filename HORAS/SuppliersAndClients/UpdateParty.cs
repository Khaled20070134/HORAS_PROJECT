using HORAS.Database;
using HORAS.EmployeFolder;
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

namespace HORAS.SuppliersAndClients
{
    public partial class UpdateParty : Form
    {
        HorasDataSet.PartyRow Party;
        public UpdateParty()
        {
            InitializeComponent();
            //UpdatePartyNameCB.Refresh();
            //MasterData.OwnersAndContractors.RefreshList();
            //foreach (var PA in MasterData.OwnersAndContractors.PartyDataTable)
            //    UpdatePartyNameCB.Items.Add(PA.Name);
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
            //textBoxName.Text = textBoxAddress.Text = labelDoc.Text =
            TextboxPhone.Text = labeltax.Text = string.Empty;
        }
        void LoadData()
        {
            textBoxName.Text = Party.Name;
            textBoxAddress.Text = Party.Address;
            TextboxPhone.Text = Party.Phone;
            labeltax.Text = Party.TaxRegNumber;
            labelDoc.Text = Party.TaxDocument;
        }

        void SetData()
        {
            Party.Name = textBoxName.Text;
            Party.Address = textBoxAddress.Text;
            Party.Phone = TextboxPhone.Text;
        }
        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && textBoxSearch.Text != string.Empty)
            {
                Party = MasterData.OwnersAndContractors.PartyDataTable.
                    FirstOrDefault(X => X.TaxRegNumber == textBoxSearch.Text);
                if (Party == null)
                { setStatus("إسم المستخدم ليس مسجل", 0); textBoxSearch.Text = string.Empty; }
                else { Reset(); LoadData(); setStatus("تم تحميل البيانات", 1); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == string.Empty)
            {
                setStatus("يجب إدخال الرقم التعريفى أولاً", 0);
                return;
            }

            if (textBoxName.Text == string.Empty)
            {
                setStatus("يجب إدخال إسم", 0);
                return;
            }

            SetData();
            MasterData.OwnersAndContractors.Update(Party);
            Reset();
            textBoxSearch.Text = string.Empty;
            setStatus("تم تعديل البيانات", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == string.Empty)
            {
                setStatus("يجب إدخال الرقم الضريبي أولاً", 0);
                return;
            }
            //int ID = int.Parse(textBoxSearch.Text);
            string taxnum = textBoxSearch.Text;
            var Pa = MasterData.OwnersAndContractors.PartyDataTable.FirstOrDefault(x=> x.TaxRegNumber == taxnum);
            int ID = Pa.ID;
            var Result = MasterData.Contracts.ContractDataTable.
                   FirstOrDefault(X => X.Party == ID);
            if (Result != null)
            {
                setStatus("لا يمكن مسح البيانات نظرا لوجود تعاقدات على هذه الجهه", 0);
                return;
            }
            // todo Check Invoices also
            MasterData.OwnersAndContractors.Delete(ID);
            Reset();
            textBoxSearch.Text = string.Empty;
            setStatus("تم مسح البيانات", 1);
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    var PA = MasterData.OwnersAndContractors.PartyDataTable.FirstOrDefault
        //        (x => x.Name == UpdatePartyNameCB.SelectedItem.ToString());

        //    textBoxSearch.Text = (PA.ID).ToString();
        //    textBoxAddress.Text = PA.Address;  
        //    TextboxPhone .Text = PA.Phone;
        //    labeltax.Text = PA.TaxRegNumber.ToString(); 
        //    labelDoc.Text = PA.TaxDocument.ToString();
            
        //}

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
