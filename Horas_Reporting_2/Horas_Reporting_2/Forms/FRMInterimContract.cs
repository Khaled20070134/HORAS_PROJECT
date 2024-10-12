using CrystalDecisions.CrystalReports.Engine;
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

namespace Horas_Reporting_2.Forms
{
    public partial class FRMInterimContract : Form
    {
        public FRMInterimContract(DataTable Original,string ContNumber,string ContDesc)
        {
            InitializeComponent();

            CR_INT_CONTRACT R = new CR_INT_CONTRACT();

            R.Database.Tables["DT_Int_Date"].SetDataSource(Original);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = R;


            (R.ReportDefinition.ReportObjects["TextContNumber"] as TextObject).Text = ContNumber;
            (R.ReportDefinition.ReportObjects["TextContDesc"] as TextObject).Text = ContDesc;

        }
    }
}
