using Horas_Reporting_2.Forms;
using Horas_Reporting_2.Interims;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas_Reporting_2
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            EmployeesForm form = new EmployeesForm();
            form.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Frm_Emp_Activity form = new Frm_Emp_Activity();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            InterimWithDate Form = new InterimWithDate();
            Form.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

            InterimWithContract Form = new InterimWithContract();
            Form.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
