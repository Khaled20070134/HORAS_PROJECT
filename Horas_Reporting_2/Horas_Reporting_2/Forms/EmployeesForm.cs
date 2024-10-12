using Horas_Reporting_2.Reports;
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
using static Horas_Reporting_2.MasterData;

namespace Horas_Reporting_2.Forms
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();


            MasterData.RefreshEmployeeList();

            EmployeesDataTable DT = MasterData.EmployeesDataTable;

            CREmp R = new CREmp();
            DataTable Original = new DataTable();
            Original.Columns.Add("FirstName", typeof(string));
            Original.Columns.Add("LastName", typeof(string));
            Original.Columns.Add("Username", typeof(string));
            Original.Columns.Add("Phone", typeof(string));
            Original.Columns.Add("Role", typeof(string));
            Original.Columns.Add("Status", typeof(string));

            for (int i = 0; i < DT.Rows.Count; i++)
            {

                string Role = string.Empty;
                int RoleNum = int.Parse(DT.Rows[i].ItemArray[8].ToString());
                switch (RoleNum)
                {
                    case (int)Job_Roles.Manager: Role = "مدير إدارة"; break;
                    case (int)Job_Roles.DataEntry: Role = "مدخل بيانات"; break;
                    case (int)Job_Roles.ConManager: Role = "مدير مكتب فنى"; break;
                    case (int)Job_Roles.FIManager: Role = "مدير حسابات"; break;
                }

                string Status = string.Empty;
                bool Status_Bool = bool.Parse(DT.Rows[i].ItemArray[10].ToString());

                if (Status_Bool == false) Status = "متاح";
                else Status = "محظور";

                Original.Rows.Add(DT.Rows[i].ItemArray[1].ToString(),
                    DT.Rows[i].ItemArray[2].ToString(),
                    DT.Rows[i].ItemArray[3].ToString(),
                    DT.Rows[i].ItemArray[9].ToString(),
                    Role, Status );
            }

            R.Database.Tables["DTEmp"].SetDataSource(Original);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = R;

        }
    }
}
