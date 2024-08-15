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

namespace HORAS.SuppliersAndClients
{
    public partial class PartyMain : Form
    {
        public PartyMain()
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

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            NewParty newParty = new NewParty();
            LoadForm(newParty);
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            UpdateParty UpdateParty = new UpdateParty();
            LoadForm(UpdateParty);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            LoadForm(new ViewParty());
        }
    }
}
