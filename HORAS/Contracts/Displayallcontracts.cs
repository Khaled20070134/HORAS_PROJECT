using HORAS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Contracts
{

    public partial class Displayallcontracts : Form
    {
        public static string ContractNumber;
        public int SelectedContractID = 0;
        bool IsSigned = false;
        Enums.ContractType Type;
        List<HorasDataSet.ContractRow> ContractList = new List<HorasDataSet.ContractRow>();
        public Displayallcontracts(Enums.ContractType C_Type, bool IsSigned)
        {
            InitializeComponent();
            this.IsSigned = IsSigned;
            Type = C_Type;
            LoadData_S();
            MasterData.styleGridView(dataGridViewDisplayContracts);
        }

        public Displayallcontracts(bool IsSigned)
        {
            InitializeComponent();
            this.IsSigned = IsSigned;
            LoadData();
            MasterData.styleGridView(dataGridViewDisplayContracts);
        }

        public Displayallcontracts(string OwnerContracts)
        {
            InitializeComponent();
            LoadContractors(OwnerContracts);
            MasterData.styleGridView(dataGridViewDisplayContracts);
        }

        void LoadAll()
        {
            ContractList = MasterData.Contracts.ContractDataTable.ToList();
        }

        public Displayallcontracts()
        {
            InitializeComponent();
            LoadAll();
            MasterData.styleGridView(dataGridViewDisplayContracts);
        }

        void LoadContractors(string O_Contract)
        {
            int C_ID = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == O_Contract).ID;
            ContractList.Clear();
            ContractList = MasterData.Contracts.ContractTableAdapter.GetOwnerContracts(C_ID).ToList();
        }

        void LoadData()
        {
            ContractList.Clear();
            ContractList = MasterData.Contracts.ContractDataTable.Where(X => X.Signed == IsSigned).ToList();

        }

        void LoadData_S()
        {
            ContractList.Clear();
            ContractList = MasterData.Contracts.ContractDataTable.
               Where(X => X.Signed == IsSigned && X.Contract_type == (int)Type).ToList();
        }

        private void Displayallcontracts_Load(object sender, EventArgs e)
        {
            dataGridViewDisplayContracts.Rows.Clear();
            foreach (var Con in ContractList) { dataGridViewDisplayContracts.Rows.Add(Con.Short_Desc, Con.Number); }
        }

        private void buttonSelectContract_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewDisplayContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewDisplayContracts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewDisplayContracts.SelectedRows.Count > 0)
            {
                int selectedrowindex = dataGridViewDisplayContracts.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataGridViewDisplayContracts.Rows[selectedrowindex];
                ContractNumber = selectedRow.Cells[1].Value.ToString();
                Close();
            }
        }
    }
}
