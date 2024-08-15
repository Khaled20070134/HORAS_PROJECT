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
    public partial class NewEmployee : Form
    {
        HorasDataSet.EmployeesRow Employee;
        public NewEmployee()
        {
            InitializeComponent();
        }

        string Check_Data()
        {
            string Result = string.Empty;
            if (textBoxFirstName.Text == string.Empty || textBoxUserName.Text == string.Empty
                || textBoxPassword.Text == string.Empty)
            {
                Result = "برجاء إدخال البيانات الضرورية";
                return Result;
            }

            var Emp = MasterData.employees.EmployeesDataTable.
                FirstOrDefault(X => X.Username == textBoxUserName.Text);
            if (Emp != null)
            {
                Result = "إسم المستخدم موجود مسبقاً";
                return Result;
            }

            if (!MasterData.CheckMail(textBoxEmail.Text))
            {
                Result = "خطأ فى صياغة الايميل";
                return Result;
            }

            return Result;
        }

        void SetData()
        {
            Employee = MasterData.employees.EmployeesDataTable.NewEmployeesRow();
            Employee.FirstName = textBoxFirstName.Text;
            Employee.ID = 50;
            Employee.LastName = textBoxLastName.Text;
            Employee.Email = textBoxEmail.Text;
            Employee.DateOfBirth = DTBirth.Value;
            Employee.Username = textBoxUserName.Text;
            Employee.Password = textBoxPassword.Text;
            Employee.Blocked = false;
            int Len = TextboxPhone.Text.Length;
            Employee.Phone = TextboxPhone.Text;
            if (radioButtonMale.Checked) Employee.Gender = 0;
            if (radioButtonFemale.Checked) Employee.Gender = 1;
            if (radioButtonAdmin.Checked) Employee.Role = 0;
            if (radioButtonFIManager.Checked) Employee.Role = 1;
            if (radioButtonConManager.Checked) Employee.Role = 2;
            if (radioButtonEmp.Checked) Employee.Role = 3;
        }

        void Reset()
        {
            textBoxLastName.Text = textBoxEmail.Text =
            textBoxUserName.Text = textBoxFirstName.Text =
            textBoxPassword.Text = TextboxPhone.Text = string.Empty;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string R = Check_Data();
            if (R != string.Empty) setStatus(R, 0);
            else
            {
                SetData();
                MasterData.employees.AddNew(Employee);
                Reset();
                setStatus("تم حفظ بيانات الموظف بنجاح", 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
