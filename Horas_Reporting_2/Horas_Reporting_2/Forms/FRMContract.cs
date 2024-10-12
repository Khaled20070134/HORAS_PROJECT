using CrystalDecisions.CrystalReports.Engine;
using Horas_Reporting_2.Datasets;
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
    public partial class FRMContract : Form
    {
        public FRMContract(DataSet1.ContractRow RowObject, List<AssItemsRow> Original)
        {
            InitializeComponent();

            CR_Contract R = new CR_Contract();
            DataTable Original_ = new DataTable();
            DS_Items.DT_ItemsDataTable DT = new DS_Items.DT_ItemsDataTable();
            foreach (var Column in DT.Columns)
                Original_.Columns.Add(Column.ToString(),typeof(string));

            foreach (AssItemsRow Item in Original)
            {
                string Type = string.Empty;
                switch(Item.Item_Type)
                {
                    case (int)Item_TYPE.Implementation_Installation: Type = "خدمات وتنفيذ"; break;
                    case (int)Item_TYPE.Supply: Type = "توريد"; break;
                    case (int)Item_TYPE.Both: Type = "توريد و تنفيذ"; break;
                }
                Original_.Rows.Add(Item.Number, Item.Description, Item.Item_Unit, Item.Qty,
                    MasterData.NumericString(Item.Total_Price), Item.LOL + " %", Type);
            }

            R.Database.Tables["DT_Items"].SetDataSource(Original_);
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.ReportSource = R;

            (R.ReportDefinition.ReportObjects["TextDesc"] as TextObject).Text = RowObject.Short_Desc;
            (R.ReportDefinition.ReportObjects["TextNumber"] as TextObject).Text = RowObject.Number;
            (R.ReportDefinition.ReportObjects["TextDate"] as TextObject).Text = RowObject.CreationDate.ToShortDateString();
            (R.ReportDefinition.ReportObjects["TextTotal"] as TextObject).Text = MasterData.NumericString(RowObject.Total_Amount);
            (R.ReportDefinition.ReportObjects["TextDuration"] as TextObject).Text = RowObject.Duration.ToString();
            (R.ReportDefinition.ReportObjects["TextDP"] as TextObject).Text = (RowObject.DownpaymentP*100).ToString() + "%";
            (R.ReportDefinition.ReportObjects["TextPN"] as TextObject).Text = (RowObject.DelayPenaltyP * 100).ToString() + "%";
            (R.ReportDefinition.ReportObjects["TextPF"] as TextObject).Text = (RowObject.ProfitPercentage * 100).ToString() + "%";
            (R.ReportDefinition.ReportObjects["TextBI"] as TextObject).Text = (RowObject.BusinessInsuranceP * 100).ToString() + "%";
            (R.ReportDefinition.ReportObjects["TextPN"] as TextObject).Text = (RowObject.DelayPenaltyP * 100).ToString() + "%";

            string Party = MasterData.PartyDataTable.FindByID(RowObject.Party).Name;

            if (RowObject.IsOwnerContractIDNull())
            {
                (R.ReportDefinition.ReportObjects["TextType"] as TextObject).Text = "تعاقد مالك";
                (R.ReportDefinition.ReportObjects["TextOwner"] as TextObject).Text = Party;
                (R.ReportDefinition.ReportObjects["TextContractor"] as TextObject).Text = "حــــورس";
            }
            else
            {
                (R.ReportDefinition.ReportObjects["TextType"] as TextObject).Text = "تعاقد مقاول";
                (R.ReportDefinition.ReportObjects["TextOwner"] as TextObject).Text = "حــــورس";
                (R.ReportDefinition.ReportObjects["TextContractor"] as TextObject).Text = Party;
            }


        }
    }
}
