using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Interims_Data
{
    public partial class DisplayAllinterimsItems : Form
    {
        string Num;
        public static int ItemID;
        public DisplayAllinterimsItems(string interimNum)
        {
            InitializeComponent();
            Num = interimNum;
        }

        private void DisplayAllinterimsItems_Load(object sender, EventArgs e)
        {

            int InterimID = MasterData.Interim.InterimsHeadDataTable.FirstOrDefault(x => x.Number == Num).ID;

            var itemlist = MasterData.Interim.InterimsItemsDataTable.
                   Where(X => X.ID == InterimID).ToList();

            dataGridViewDisplayItems.Rows.Clear();
            foreach (var Item in itemlist) dataGridViewDisplayItems.Rows.Add(Item.ItemID, MasterData.assessments.AssItemsDataTable.FirstOrDefault(x => x.ID == Item.ID).Description);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDisplayItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDisplayItems.SelectedRows.Count > 0)
            {
                int selectedrowindex = dataGridViewDisplayItems.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridViewDisplayItems.Rows[selectedrowindex];
                ItemID = int.Parse(selectedRow.Cells[0].Value.ToString());
                Close();
            }
        }
    }
}
