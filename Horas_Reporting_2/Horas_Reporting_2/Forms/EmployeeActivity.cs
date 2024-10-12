using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Horas_Reporting_2.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static Horas_Reporting_2.DataSet1;

namespace Horas_Reporting_2.Forms
{
    public partial class EmployeeActivity : Form
    {
        public EmployeeActivity(Log_TableDataTable Data, DateTime From,DateTime To)
        {
            InitializeComponent();
            CREmpActivity R = new CREmpActivity();

            DataTable Original = new DataTable();
            Original.Columns.Add("Activity_Description", typeof(string));
            Original.Columns.Add("Activity_Date", typeof(string));

            foreach (Log_TableRow Row in Data)
                Original.Rows.Add(Row.Description, Row.ActivityDate.ToShortDateString());

            R.Database.Tables["DT_EmpActivity"].SetDataSource(Original);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = R;


            (R.ReportDefinition.ReportObjects["TextFrom"] as TextObject).Text = From.ToShortDateString();
            (R.ReportDefinition.ReportObjects["TextTo"] as TextObject).Text = To.ToShortDateString();
        }
    }
}
