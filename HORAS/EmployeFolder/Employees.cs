using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS.EmployeFolder
{
    public class Employee
    {
        public EmployeesTableAdapter EmployeesTableAdapter = new EmployeesTableAdapter();
        public EmployeesDataTable EmployeesDataTable = new EmployeesDataTable();

        #region properties
        public string First_name { set; get; }
        public string Last_name { set; get; }
        public Gender Gender { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public int ID { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public Job_Roles Role { set; get; }
        public bool Blocked { set; get; } 
        #endregion


        public void AddNew(HorasDataSet.EmployeesRow Emp)
        {
            EmployeesTableAdapter.Connection.Open();
            MasterData.Database.Employees.Rows.Add(Emp.ItemArray);
            EmployeesTableAdapter.Update(MasterData.Database);
            EmployeesTableAdapter.Adapter.Update(MasterData.Database.Employees);
            MasterData.Database.Employees.AcceptChanges();
            MasterData.Database.AcceptChanges();
            EmployeesTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Employee : " + Emp.ID + " was created";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Create;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void Update(HorasDataSet.EmployeesRow Emp)
        {
            EmployeesTableAdapter.Connection.Open();
            var C = EmployeesDataTable.FindByID(Emp.ID);
            C.FirstName = Emp.FirstName;
            C.LastName = Emp.LastName;
            C.Password = Emp.Password;
            C.Email = Emp.Email;
            C.Phone = Emp.Phone;
            C.Role = Emp.Role;
            C.Blocked = Emp.Blocked;
            EmployeesTableAdapter.Update(MasterData.Database);
            EmployeesTableAdapter.Adapter.Update(EmployeesDataTable);
            EmployeesDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            EmployeesTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Employee : " + Emp.ID + " was Updated";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }

        public void Delete(int ID)
        {
            EmployeesTableAdapter.Connection.Open();
            var C = EmployeesDataTable.FindByID(ID);
            EmployeesDataTable.RemoveEmployeesRow(C);
            EmployeesTableAdapter.DeleteQuery(ID);
            EmployeesTableAdapter.Update(MasterData.Database);
            EmployeesTableAdapter.Adapter.Update(EmployeesDataTable);
            EmployeesDataTable.AcceptChanges();
            MasterData.Database.AcceptChanges();
            EmployeesTableAdapter.Connection.Close();

            // Insert Log Activity
            HorasDataSet.Log_TableRow Row = MasterData.LogActivity.LogDataTable.NewLog_TableRow();
            Row.Description = "Employee : " + ID + " was Deleted";
            Row.User_ID = MasterData.LoggedEmployee.ID;
            Row.Mode = (int)ActivityMode.Update;
            Row.ActivityDate = DateTime.Now;
            MasterData.LogActivity.AddNew(Row);
        }


        public void RefreshList()
        {
            EmployeesTableAdapter.Connection.Open();
            EmployeesTableAdapter.GetData();
            EmployeesTableAdapter.Fill(EmployeesDataTable);
            EmployeesTableAdapter.Connection.Close();
        }
    }
}
