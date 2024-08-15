using HORAS.Database;
using HORAS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.EmployeFolder
{
    public partial class ActivityEmployee : Form
    {
        BindingSource SBind = new BindingSource();

        public ActivityEmployee()
        {
            InitializeComponent();
        }

        void setStatus(string Description, int Status)
        {
            switch (Status)
            {
                case 0:
                    labelStatus.Text = Description;
                    labelStatus.ForeColor = Color.IndianRed;
                    pictureBoxStatus.Image = Resources.wrong_16;
                    break;
                case 1:
                    labelStatus.Text = Description;
                    labelStatus.ForeColor = Color.GreenYellow;
                    pictureBoxStatus.Image = Resources.correct_16;
                    break;
            }
        }

        private void DTPFrom_ValueChanged(object sender, EventArgs e)
        {
            DTPTo.MinDate = DTPFrom.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == string.Empty)
            {
                setStatus("يجب إدخال إسم المستخدم", 0);
                return;
            }

            var Emp = MasterData.employees.EmployeesDataTable.
                   FirstOrDefault(X => X.Username == textBoxUserName.Text);

            if (Emp == null)
            {
                setStatus("إسم المستخدم غير صحيح", 0);
                return;
            }

            Load_Date(Emp.ID);
            if (dataGridView1.Rows.Count > 1) setStatus("تم تحميل الأنئشطة بنجاح", 1);
            if (dataGridView1.Rows.Count == 0) setStatus("لا يوجد أنشطة لهذا المستخدم فى هذه الفترة", 0);
        }

        void Load_Date(int ID)
        {
            var Data = MasterData.LogActivity.LogDataTable.Where(X => X.User_ID == ID 
            && X.ActivityDate >= DTPFrom.Value && X.ActivityDate <= DTPTo.Value);
            SBind.DataSource = Data;

            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.Columns.Clear();
            //DataGridViewColumn Col = new DataGridViewColumn();
            //Col.HeaderText = "Activity Date";
            //Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns.Add(Col);

            //Col = new DataGridViewColumn();
            //Col.HeaderText = "Activity Description";
            //Col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns.Add(Col);

            foreach (var Item in Data.ToList())
            {
                //HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
                //Row.ActivityDate = Item.ActivityDate;
                //Row.Description = Item.Description;
                dataGridView1.Rows.Add(Item.ActivityDate.ToShortDateString(),Item.Description);
            }
                
            dataGridView1.Refresh();
        }

    }
}
