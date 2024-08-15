using HORAS.Contracts;
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
    public partial class CollectionsMain : Form
    {
        public CollectionsMain()
        {
            InitializeComponent();
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
            if (MasterData.LoggedEmployee.Role != Enums.Job_Roles.FIManager &&
                MasterData.LoggedEmployee.Role != Enums.Job_Roles.Manager)
            {
                MessageBox.Show("غير مسموح لك بتسجيل تحصيل على النظام", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NewCoolection newcontract = new NewCoolection();
            LoadForm(newcontract);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            ContractCollections newcontract = new ContractCollections();
            LoadForm(newcontract);
        }
    }
}
