using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HORAS.SuppliersAndClients;

namespace HORAS.Information
{
    public partial class VendorData : Form
    {
        public VendorData(Contractor C)
        {
            InitializeComponent();
            LabelAddress.Text = C.Address;
            labelID.Text = C.ID.ToString();
            LabelName.Text = C.Name;
            LabelTaxNum.Text = C.TaxRegNumber;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
