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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            labelName.Text = MasterData.LoggedEmployee.First_name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MasterData.MainForm.Hide();
            MasterData.ContractsMainForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MasterData.MainForm.Hide();
            MasterData.EmployeesForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MasterData.MainForm.Hide();
            MasterData.PartyForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MasterData.MainForm.Hide();
            MasterData.AssMain.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MasterData.MainForm.Hide();
            MasterData.InterimsMain.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\Khaled\\Desktop\\May 2024\\Debug\\HorasReporting.exe");
        }
    }
}
