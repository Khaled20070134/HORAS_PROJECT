using Horas_Reporting_2.DataSet1TableAdapters;
using Horas_Reporting_2.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Horas_Reporting_2.DataSet1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Horas_Reporting_2
{
    public partial class Frm_Emp_Activity : Form
    {
        public Frm_Emp_Activity()
        {
            InitializeComponent();
            MasterData.RefreshEmployeeList();
            MasterData.RefreshActivitiesList();

            foreach (var Row in MasterData.EmployeesDataTable.ToList())
                comboBox1.Items.Add(Row.Username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;
            
            string Username = comboBox1.SelectedItem.ToString();
            int UserID = MasterData.EmployeesDataTable.FirstOrDefault(X => X.Username == Username).ID;

            var Data_ = MasterData.LogDataTable.
                Where(X => X.ActivityDate <= DTP_To.Value && X.User_ID == UserID &&
                X.ActivityDate >= DTP_From.Value).ToList();

            Log_TableDataTable DataToPass = new Log_TableDataTable();
            Log_TableRow Row;
            foreach (var R in Data_)
            {
                Row = MasterData.LogDataTable.NewLog_TableRow();
                Row.ActivityDate = R.ActivityDate;
                Row.Description = R.Description;
                DataToPass.Rows.Add(Row.ItemArray);
            }
            
            EmployeeActivity Form = new EmployeeActivity(DataToPass, DTP_From.Value, DTP_To.Value);
            Form.ShowDialog();
            Close();
        }
    }
}
