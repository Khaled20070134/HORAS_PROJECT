using HORAS.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            timer1.Start();
            labelDate.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LabelTime.Text = DateTime.Now.ToLongTimeString();
        }

        void Log()
        {
            if (textBoxUsername.Text == string.Empty || textBoxPassword.Text == string.Empty)
            {
                labelError.Text = "برجاء إدخال إسم المستخدم وكلمة المرور";
                labelError.Visible = true;
            }
            else
            {
                MasterData.employees.RefreshList();
                var Emp = MasterData.employees.EmployeesDataTable.
                     FirstOrDefault(X => X.Username == textBoxUsername.Text && X.Password == textBoxPassword.Text);
                if (Emp == null)
                {
                    labelError.Text = "خطأ فى إسم المستخدم أو كلمة المرور";
                    labelError.Visible = true;
                }
                else
                {

                    if (Emp.Blocked)
                    {
                        labelError.Text = "تم حظر هذا المستخدم";
                        labelError.Visible = true;
                        return;
                    }


                    SetEmployee(Emp);
                    MasterData.LoginTime = DateTime.Now;
                    MasterData.MainForm.Show();
                    MasterData.LogForm.Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log();
        }

        void SetEmployee(HorasDataSet.EmployeesRow Row)
        {
            // Set Only Required Data
            MasterData.LoggedEmployee.ID = Row.ID;
            MasterData.LoggedEmployee.Gender = (Enums.Gender)Row.Gender;
            MasterData.LoggedEmployee.Role = (Enums.Job_Roles)Row.Role;
            MasterData.LoggedEmployee.First_name = Row.FirstName;
            MasterData.LoggedEmployee.Last_name = Row.LastName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                Log();
            }
        }

       
    }
}
