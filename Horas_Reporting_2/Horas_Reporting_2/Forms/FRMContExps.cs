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
    public partial class FRMContExps : Form
    {
        public FRMContExps(DataTable Original,double Total,string Desc,string Number)
        {
            InitializeComponent();
            CR_EXP_CONT R = new CR_EXP_CONT();

            (R.ReportDefinition.ReportObjects["TextTotal"] as TextObject).Text = MasterData.NumericString(Total);
            (R.ReportDefinition.ReportObjects["TextContNum"] as TextObject).Text = Number;
            (R.ReportDefinition.ReportObjects["TextContDesc"] as TextObject).Text = Desc;

            R.Database.Tables["DT_EXPS"].SetDataSource(Original);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = R;
        }
    }
}
