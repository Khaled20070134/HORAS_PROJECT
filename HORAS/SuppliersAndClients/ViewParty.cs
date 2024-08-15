using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.SuppliersAndClients
{
    public partial class ViewParty : Form
    {
        PartyTableAdapter partyAD = new PartyTableAdapter();
        HorasDataSet.PartyDataTable PartyDT = new HorasDataSet.PartyDataTable();
        public ViewParty()
        {
            InitializeComponent();

            MasterData.OwnersAndContractors.RefreshList();
            MasterData.styleGridView(ViewPartyDGV);
            ViewPartyDGV.DataSource = MasterData.OwnersAndContractors.PartyDataTable;
            






        }

        private void ViewPartyDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            PartyMain back = new PartyMain();
            back.Show();
        }

        private void ViewParty_Load(object sender, EventArgs e)
        {

        }
    }
}
