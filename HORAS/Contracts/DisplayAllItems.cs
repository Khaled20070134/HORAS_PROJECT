using HORAS.Interims_Data;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Contracts
{
    public partial class DisplayAllItems : Form
    {
        string conNum;
        public static int ItemID;
        public DisplayAllItems(string contractNum)
        {
            InitializeComponent();
            conNum = contractNum;
        }

        private void DisplayAllItems_Load(object sender, EventArgs e)
        {
            int contractID = MasterData.Contracts.ContractDataTable.FirstOrDefault(x => x.Number == conNum).ID;

            var itemlist = MasterData.assessments.AssItemsAdapter.NotNullContracts().
                   Where(X => X.Contract_ID == contractID).ToList();

            dataGridViewDisplayItems.Rows.Clear();
            foreach (var Item in itemlist) dataGridViewDisplayItems.Rows.Add(Item.ID,Item.Number, Item.Description);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDisplayItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDisplayItems.SelectedRows.Count > 0)
            {
                
                int selectedRowIndex = dataGridViewDisplayItems.SelectedRows[0].Index;
                ItemID =int.Parse(dataGridViewDisplayItems.Rows[selectedRowIndex].Cells[0].Value.ToString());
               
                Close();
            }
        }
    }
}
