using HORAS.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS
{
    public partial class Start : Form
    {
        string Reporting_URL = string.Empty;
        public Start()
        {
            InitializeComponent();
            Reporting_URL = AppDomain.CurrentDomain.BaseDirectory;

        }

        void Reset()
        {
            labelContract2.ForeColor = labelContract.ForeColor = labelAss1.ForeColor =
                labelOwners.ForeColor = labelEmps.ForeColor = labelContract3.ForeColor =
                 labelInterim1.ForeColor = labelInvoice.ForeColor = labelCollect.ForeColor =
                labelAss2.ForeColor = Color.White;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // MasterData.MainForm.Hide();
            MasterData.ContractsMainForm.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // MasterData.MainForm.Hide();
            MasterData.AssMain.ShowDialog();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            // MasterData.MainForm.Hide();
            MasterData.PartyForm.ShowDialog();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            //MasterData.MainForm.Hide();
            MasterData.InterimsMain.ShowDialog();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            // MasterData.MainForm.Hide();
            MasterData.EmployeesForm.ShowDialog();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Start_Shown(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToLongDateString();
            labelName.Text = MasterData.LoggedEmployee.First_name + " " + MasterData.LoggedEmployee.Last_name;
            switch (MasterData.LoggedEmployee.Role)
            {
                case Enums.Job_Roles.Manager: labelPer.Text = "جميع الصلاحيات"; break;
                case Enums.Job_Roles.FIManager: labelPer.Text = "مدير حسابات"; break;
                case Enums.Job_Roles.ConManager: labelPer.Text = "مدير مكتب فنى"; break;
                case Enums.Job_Roles.DataEntry: labelPer.Text = "مدخل بيانات"; break;
            }
            int NumberOfNotsignedC = MasterData.Contracts.ContractDataTable.Count(x => x.Signed == false);
            int NumberOfNotconfirmedassesments = MasterData.assessments.AssessmentHeadDataTable.Count(x => x.Confirmed == false);
            int NumberOfNotconfirmedexp = MasterData.Contracts.ExpTrDataTable.Count(x => x.NeedConf == false);
            int numberofnotconfirmedinte = MasterData.Interim.InterimsHeadDataTable.Count(X => X.IsConfirm_DateNull());
            int NumberOfNotifications = numberofnotconfirmedinte + NumberOfNotconfirmedexp +
                NumberOfNotconfirmedassesments + NumberOfNotsignedC;
            if (NumberOfNotifications > 0)
                ManagerNotification.Style = MetroFramework.MetroColorStyle.Red;
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.Manager)
                ManagerNotification.Visible = true;
            ManagerNotification.Text = "(" + NumberOfNotifications + ")    " + ManagerNotification.Text;
        }

        private void metroButton1_MouseHover(object sender, EventArgs e)
        {
            Reset();
            labelContract.ForeColor = labelContract2.ForeColor = labelContract3.ForeColor = Color.LightSkyBlue;
        }

        private void metroButton1_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void metroButton2_MouseHover(object sender, EventArgs e)
        {
            Reset();
            labelAss1.ForeColor = labelAss2.ForeColor = Color.LightSkyBlue;
        }

        private void metroButton2_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void metroButton7_MouseHover(object sender, EventArgs e)
        {
            Reset();
            labelOwners.ForeColor = Color.LightSkyBlue;
        }

        private void metroButton7_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void labelEmps_MouseHover(object sender, EventArgs e)
        {
            Reset();
            labelEmps.ForeColor = Color.LightSkyBlue;
        }

        private void labelEmps_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ManagerNotification_Click(object sender, EventArgs e)
        {
            NotifyForm NForm = new NotifyForm();
            NForm.ShowDialog();
        }

        private void metroButton4_MouseHover(object sender, EventArgs e)
        {
            Reset();
            labelInterim1.ForeColor = Color.LightSkyBlue;
        }

        private void metroButton4_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void labelInvoice_MouseHover(object sender, EventArgs e)
        {

        }

        private void metroButton3_MouseHover(object sender, EventArgs e)
        {
            Reset();
            labelInvoice.ForeColor = labelCollect.ForeColor = Color.LightSkyBlue;
        }

        private void metroButton3_MouseLeave(object sender, EventArgs e)
        {
            Reset();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            CollectionsMain NForm = new CollectionsMain();
            NForm.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (Settings1.Default.Reporting_URL == string.Empty)
            {
                FilePath_R Form = new FilePath_R();
                Form.Show();
                if (Settings1.Default.Reporting_URL != string.Empty)
                    MasterData.OpenFile(Settings1.Default.Reporting_URL);
                else
                    MessageBox.Show("No File Selected");
            }
            else MasterData.OpenFile(Settings1.Default.Reporting_URL);

        }
    }
}
