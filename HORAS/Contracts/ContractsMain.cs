using HORAS.Contracts;
using Microsoft.VisualBasic;
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

namespace HORAS
{
    public partial class ContractsMain : Form
    {
        public ContractsMain()
        {
            InitializeComponent();
            MasterData.LoadMasterData();
        }

        public ContractsMain(WizardMode Mode)
        {
            InitializeComponent();
            MasterData.LoadMasterData();

            switch (Mode)
            {
                case WizardMode.ContractConfirmations:
                    StartContract newcontract = new StartContract();
                    LoadForm(newcontract);
                    break;
                case WizardMode.ExpansesConfirmations:
                    ContractExpanses contract = new ContractExpanses();

                    LoadForm(contract);
                    break;
            }



        }


        public void LoadForm(Form Frm)
        {
            //Formpanel.Hide();
            foreach (Control C in MasterPanel.Controls) C.Dispose();
            MasterPanel.Controls.Clear();
            this.IsMdiContainer = true;
            Frm.TopLevel = false;
            MasterPanel.Controls.Add(Frm);
            Frm.Dock = DockStyle.Fill;
            Frm.Show();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            // Check User Permissions
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.FIManager ||
                MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
            {
                MessageBox.Show("غير مسموح لك بتسجيل تعاقد على النظام", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewOwnerContract newcontract = new NewOwnerContract();
            LoadForm(newcontract);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            // Check User Permissions
            if (MasterData.LoggedEmployee.Role != Enums.Job_Roles.Manager)
            {
                MessageBox.Show("غير مسموح لك بتوقيع التعاقد أو بدء التنفيذ الفعلى للتعاقد", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StartContract newcontract = new StartContract();
            LoadForm(newcontract);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton2_Click_1(object sender, EventArgs e)
        {
            // Check User Permissions
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.ConManager ||
                MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
            {
                MessageBox.Show("غير مسموح لك بتسجيل مصروفات", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ContractExpanses newcontract = new ContractExpanses();
            LoadForm(newcontract);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            ContractFollowUp newcontract = new ContractFollowUp();
            LoadForm(newcontract);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            ContractDisplay newcontract = new ContractDisplay();
            LoadForm(newcontract);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

            // Check User Permissions
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.FIManager ||
                MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
            {
                MessageBox.Show("غير مسموح لك بتسجيل تعاقد على النظام", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            NewContractorContract newcontract = new NewContractorContract();
            LoadForm(newcontract);
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            NewBGL newcontract = new NewBGL();
            LoadForm(newcontract);
        }
    }


}
