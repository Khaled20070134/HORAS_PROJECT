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
    public partial class FRMInterim : Form
    {
        public FRMInterim(DataTable Original, DateTime From,DateTime To)
        {
            InitializeComponent();
            CR_INT_DATE R = new CR_INT_DATE();

            R.Database.Tables["DT_Int_Date"].SetDataSource(Original);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = R;


            (R.ReportDefinition.ReportObjects["TextFrom"] as TextObject).Text = From.ToShortDateString();
            (R.ReportDefinition.ReportObjects["TextTo"] as TextObject).Text = To.ToShortDateString();

        }
    }
}
