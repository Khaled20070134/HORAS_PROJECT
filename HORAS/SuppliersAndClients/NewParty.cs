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

namespace HORAS.SuppliersAndClients
{
    public partial class NewParty : Form
    {
        HorasDataSet.PartyRow Party;
        public NewParty()
        {
            InitializeComponent();
        }

        public NewParty(bool Close)
        {
            InitializeComponent();
            pictureBox4.Visible = Close;

        }

        void SetData()
        {
            Party = MasterData.OwnersAndContractors.PartyDataTable.NewPartyRow();
            Party.Address = textBoxAddress.Text;
            Party.Phone = TextboxPhone.Text;
            Party.Name = textBoxName.Text;
            Party.TaxRegNumber = maskedTaxReg.Text;
            Party.TaxDocument = textBoxTaxDoc.Text;
            Party.ID = 500;
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


        bool Check_Data()
        {
            bool Result = true;
            if (textBoxName.Text == string.Empty || textBoxAddress.Text == string.Empty
                || maskedTaxReg.Text == string.Empty || textBoxTaxDoc.Text == string.Empty)
            {
                Result = false;
                return Result;
            }

            return Result;
        }
        void Reset()
        {
            textBoxName.Text = textBoxAddress.Text = TextboxPhone.Text =
                maskedTaxReg.Text = textBoxTaxDoc.Text = string.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Check_Data())
                setStatus("يجب إدخال جميع البيانات", 0);
            else
            {
                SetData();
                MasterData.OwnersAndContractors.AddNew(Party);
                setStatus("تم حفظ البيانات", 1);
                Reset();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
