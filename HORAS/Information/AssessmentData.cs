using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Information
{
    public partial class AssessmentData : Form
    {
        public AssessmentData(assessment Object,string From,string To)
        {
            InitializeComponent();
            LoadData(Object,From,To);
        }

        #region Methods
        void LoadData(assessment Object, string From, string To)
        {
            // Load Head Data
            LabelSubject.Text = Object.Subject;
            LabelAbout.Text = Object.About;
            LabelFrom.Text = From;
            LabelTo.Text = To;

            float Total = 0;
            // Load Items Total
            foreach (var Item in Object.Items)
            {
                DGV_Data.Rows.Add(Item.Number, Item.Dexcription, Item.Item_Unit,
                    Item.Qty, Item.Total_PRice, (Item.Qty * Item.Total_PRice));
                Total += (Item.Qty * Item.Total_PRice);
            }
            LabelTotal.Text = Total.ToString();
        }
        #endregion

        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
