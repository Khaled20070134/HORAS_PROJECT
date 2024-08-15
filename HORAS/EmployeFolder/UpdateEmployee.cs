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
    public partial class UpdateEmployee : Form
    {
        HorasDataSet.EmployeesRow Employee;
        public UpdateEmployee()
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

        void LoadData()
        {
            try
            {
                if (Employee.Email != null) textBoxEmail.Text = Employee.Email;
                textBoxFirstName.Text = Employee.FirstName;
                textBoxLastName.Text = Employee.LastName;
                textBoxPassword.Text = Employee.Password;
                TextboxPhone.Text = Employee.Phone;
                CheckBlock.Checked = Employee.Blocked;
                switch (Employee.Role)
                {
                    case 0: radioButtonAdmin.Checked = true; break;
                    case 1: radioButtonFIManager.Checked = true; break;
                    case 2: radioButtonConManager.Checked = true; break;
                    case 3: radioButtonEmp.Checked = true; break;
                }
            }
            catch
            {
                // continue;

            }
        }

        void Reset()
        {
            textBoxLastName.Text = textBoxEmail.Text =
            textBoxFirstName.Text = textBoxPassword.Text = TextboxPhone.Text = string.Empty;
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && textBoxSearch.Text != string.Empty)
            {
                Employee = MasterData.employees.EmployeesDataTable.
                    FirstOrDefault(X => X.Username == textBoxSearch.Text);
                if (Employee == null)
                { setStatus("إسم المستخدم ليس مسجل", 0); textBoxSearch.Text = string.Empty; }
                else
                {
                    if (MasterData.LoggedEmployee.Username != textBoxSearch.Text &&
                        MasterData.LoggedEmployee.Role != Enums.Job_Roles.Manager)
                    {
                        setStatus("ليس لديك الصلاحية لتعديل بيانات موظف آخر", 0);
                        return;
                    }
                    Reset(); 
                    LoadData(); 
                    setStatus("تم تحميل البيانات", 1);
                }
            }
        }

        void SetData()
        {
            // Employee = MasterData.employees.EmployeesDataTable.NewEmployeesRow();
            Employee.FirstName = textBoxFirstName.Text;
            Employee.LastName = textBoxLastName.Text;
            Employee.Email = textBoxEmail.Text;
            Employee.Password = textBoxPassword.Text;
            Employee.Phone = TextboxPhone.Text;
            Employee.Blocked = CheckBlock.Checked;
            if (radioButtonAdmin.Checked) Employee.Role = 0;
            if (radioButtonFIManager.Checked) Employee.Role = 1;
            if (radioButtonConManager.Checked) Employee.Role = 2;
            if (radioButtonEmp.Checked) Employee.Role = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == string.Empty)
            {
                setStatus("يجب تحميل بيانات الموظف أولاً", 0);
                return;
            }
            SetData();
            MasterData.employees.Update(Employee);
            setStatus("تم تعديل البيانات", 1);
            Reset();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == string.Empty)
            {
                setStatus("يجب تحميل بيانات الموظف أولاً", 0);
                return;
            }

            var Data = MasterData.LogActivity.LogDataTable.FirstOrDefault(X => X.User_ID == Employee.ID);
            if (Data != null)
            {
                setStatus("لا يمكن مسح هذا الموظف لوجود أنشطة مسجله عليه", 0);
                return;
            }
            MasterData.employees.Delete(Employee.ID);
            MasterData.employees.RefreshList();
            setStatus("تم مسح الموظف من البيانات", 1);
            Reset();
        }
    }
}
