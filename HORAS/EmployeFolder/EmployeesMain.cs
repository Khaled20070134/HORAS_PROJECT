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

namespace HORAS.EmployeFolder.Employees
{
    public partial class EmployeesMain : Form
    {
        public EmployeesMain()
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
            NewEmployee newcontract = new NewEmployee();
            LoadForm(newcontract);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            UpdateEmployee newcontract = new UpdateEmployee();
            LoadForm(newcontract);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            ActivityEmployee newcontract = new ActivityEmployee();
            LoadForm(newcontract);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
          //  Form1 newcontract = new Form1();
            //LoadForm(newcontract);
        }
    }
}
