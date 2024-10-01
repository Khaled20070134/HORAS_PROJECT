using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Contracts
{
    public partial class NewCotractAttachment : Form
    {
        public NewCotractAttachment()
        {
            InitializeComponent();
        }

        void LoadOwnerContracts()
        {
            MasterData.Contracts.RefreshList();
            CBAssessmentContracts.Items.Clear();
            var OwnerContracts = MasterData.Contracts.
                ContractDataTable.Where(X => X.Signed == true && !X.IsStartDateNull() && !X.IM_Completed ).ToList();
            foreach (var Item in OwnerContracts)
                CBAssessmentContracts.Items.Add(Item.Number);
        }
        private void CBAssessmentContracts_DropDown(object sender, EventArgs e)
        {

        }
    }
}
