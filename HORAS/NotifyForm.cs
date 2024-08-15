using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS
{
    public partial class NotifyForm : Form
    {
        public NotifyForm()
        {
            InitializeComponent();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Contract Sign Wizard
            MasterData.MainForm.Hide();
            MasterData.ContractsMainForm_ContractConf.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Assessments Confirmations Wizard
            MasterData.MainForm.Hide();
            MasterData.AssMainWizard.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Interims Confirmations Wizard
            MasterData.MainForm.Hide();
            MasterData.ContractsMainForm_ExpsConf.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Interims Confirmations Wizard
            MasterData.MainForm.Hide();
            MasterData.InterimsMainWizard.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelContracts.Text = MasterData.Contracts.ContractDataTable.Count(x => x.Signed == false).ToString();
            labelAss.Text = MasterData.assessments.AssessmentHeadDataTable.Count(x => x.Confirmed == false).ToString();
            labelExps.Text = MasterData.Contracts.ExpTrDataTable.Count(x => x.NeedConf == false).ToString();
            labelInt.Text = MasterData.Interim.InterimsHeadDataTable.Count(X => X.IsConfirm_DateNull()).ToString();
        }

        private void NotifyForm_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
