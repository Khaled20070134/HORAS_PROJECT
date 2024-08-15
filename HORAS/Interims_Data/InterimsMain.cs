using HORAS.Contracts;
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

namespace HORAS.Interims_Data
{
    public partial class InterimsMain : Form
    {
        public InterimsMain()
        {
            InitializeComponent();
        }
        public InterimsMain(WizardMode Mode)
        {
            InitializeComponent();
            ConfirmInterims newForm = new ConfirmInterims();
            LoadForm(newForm);
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
            //ImportInterims newcontract = new ImportInterims();
            //LoadForm(newcontract);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (MasterData.LoggedEmployee.Role != Enums.Job_Roles.Manager)
            {
                MessageBox.Show("ليس لديك الصلاحية لتأكيد بيانات المستخلصات", "صلاحيات خاطئة",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ConfirmInterims newForm = new ConfirmInterims();
                LoadForm(newForm);
            }

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
            {
                MessageBox.Show(" ليس لديك الصلاحية لأدخال مستخلص", "صلاحيات خاطئة",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InterimsEntry newForm = new InterimsEntry();
            LoadForm(newForm);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.)
            //{
            //    MessageBox.Show(" ليس لديك الصلاحية لأدخال مستخلص", "صلاحيات خاطئة",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            DisplayInterim newForm = new DisplayInterim();
            LoadForm(newForm);
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            ExpsMasterData newForm = new ExpsMasterData();
            LoadForm(newForm);
        }
    }
}
