using HORAS.EmployeFolder;
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

namespace HORAS.Assessments
{
    public partial class AssessmentMain : Form
    {
        public AssessmentMain()
        {
            InitializeComponent();
        }

        public AssessmentMain(WizardMode Mode)
        {
            InitializeComponent();
            ConfirmAssessment NewAss = new ConfirmAssessment();
            LoadForm(NewAss);
        }

        public void LoadForm(Form Frm)
        {
            foreach (Control C in MasterPanel.Controls) C.Dispose();
            MasterPanel.Controls.Clear();
            this.IsMdiContainer = true;
            Frm.TopLevel = false;
            MasterPanel.Controls.Add(Frm);
            Frm.Dock = DockStyle.Fill;
            Frm.Show();

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Check User Permissions
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.FIManager ||
                MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
            {
                MessageBox.Show("غير مسموح لك بإدخال مقايسة على النظام", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ImportAssessment NewAss = new ImportAssessment();
            LoadForm(NewAss);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (MasterData.LoggedEmployee.Role != Enums.Job_Roles.Manager)
            {
                MessageBox.Show("ليس لديك الصلاحية لتأكيد بيانات المقايسة", "صلاحيات خاطئة",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ConfirmAssessment NewAss = new ConfirmAssessment();
            LoadForm(NewAss);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            NewAssessment NewAss = new NewAssessment();
            LoadForm(NewAss);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            UpdateAssessment NewAss = new UpdateAssessment();
            LoadForm(NewAss);
        }
    }
}
