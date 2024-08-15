using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Information
{
    public partial class Contracts_FI_Data : Form
    {
        public Contracts_FI_Data(int C_ID, double Total)
        {
            InitializeComponent();

            var Object = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.ID == C_ID);
            LabelTotal.Text = Total.ToString("N", new CultureInfo("en-US"));
            LabelD.Text = Object.DownpaymentP.ToString("N", new CultureInfo("en-US"));
            LabelG.Text = Object.BusinessInsuranceP.ToString("N", new CultureInfo("en-US"));
            LabelPenalty.Text = Object.DelayPenaltyP.ToString("N", new CultureInfo("en-US"));
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
