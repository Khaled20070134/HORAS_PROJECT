using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinanceSoftware.Profit;
using static FinanceSoftware.Taxes;

namespace FinanceSoftware
{
    class Connection
    {
        static SqlConnection connection =
            new SqlConnection(@"Data Source=Israa-PC;Initial Catalog=Finance System;Integrated Security=True");

        public Connection()
        {
        }

        public void ConnectDB()
        {
            try
            {
                connection.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Error !");
            }

            //MessageBox.Show((DateTime.Now.Month - 1).ToString());
        }

        public void DisConnectDB()
        {
            try
            {
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Problem in dis-conecting to the database", "Error !");
            }

            //MessageBox.Show((DateTime.Now.Month - 1).ToString());
        }

        public void ReConnectDB()
        {
            try
            {
                connection.Close();
                connection.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Error !");
            }

            //MessageBox.Show((DateTime.Now.Month - 1).ToString());
        }

        public void getMainData2()
        {
            SystemControl.employees.Clear();
            SqlCommand employeesCommand = new SqlCommand();
            employeesCommand.Connection = connection;
            employeesCommand.CommandText = "select * from Employee order by 'AIO_Code'";
            employeesCommand.CommandType = CommandType.Text;
            SqlDataReader employeesDataReader = employeesCommand.ExecuteReader();

            int i = 0;

            while (employeesDataReader.Read())
            {
                Employee E = new Employee();
                E.FullName = employeesDataReader["Full_Name"].ToString();
                E.AIOID = int.Parse(employeesDataReader["AIO_Code"].ToString());
                E.DateOfBirth = DateTime.Parse(employeesDataReader["Date_of_Birth"].ToString());
                E.HiringDate = (DateTime) employeesDataReader["Hiring_D"];
                E.TerminationDate = (DateTime) employeesDataReader["Termination_D"];
                E.CurrentDegree = (Degree) Enum.Parse(typeof(Degree), employeesDataReader["E_Degree"].ToString());
                E.EType = (EmploymentType) Enum.Parse(typeof(EmploymentType), employeesDataReader["E_Type"].ToString());
                E.Dept_ID = int.Parse(employeesDataReader["Depart_ID"].ToString());
                E.National_ID = employeesDataReader["N_ID"].ToString();

                if (employeesDataReader["Working_Type"].ToString() == "InDirect")
                    E.WType = WorkingType.InDirect;
                else if (employeesDataReader["Working_Type"].ToString() == "Direct    ")
                    E.WType = WorkingType.Direct;
                if (employeesDataReader["Contract_Type"].ToString() == "Temporary")
                    E.CType = ContractType.Temporary;
                else if (employeesDataReader["Contract_Type"].ToString() == "Permenant")
                    E.CType = ContractType.Permenant;
                SystemControl.employees.Add(E);
                i++;
            }

            employeesDataReader.Close();
            i = 0;
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            ////******************************************************************* THIS 8 IS NOT CONSTANT***************
            //salaryCommand.CommandText = "select * from salary where MONTH(Payment_D) = @date order by 'AIO_Code'";

            salaryCommand.CommandType = CommandType.Text;

            //SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
            //salaryDataReader.Read();
            foreach (Employee Emp in SystemControl.employees)
            {

                //******************************************************************* THIS 8 IS NOT CONSTANT***************
                salaryCommand.CommandText = "select * from salary where MONTH(Payment_D) = @date and AIO_Code = @ID";
                salaryCommand.Parameters.Clear();
                salaryCommand.Parameters.Add("@date", (DateTime.Now.Month));
                salaryCommand.Parameters.Add("@ID", (Emp.AIOID));

                int EmpIndex = SystemControl.employees.FindIndex(j => j.AIOID == Emp.AIOID);
                SetMinusesData2(EmpIndex, DateTime.Now);
                GetInstallsValue(Emp.AIOID, ref Emp.AlimonyMonthlyInstallment, ref Emp.Insurance_Policy_Release,
                    ref Emp.PreviousPeriodInstallments);

                SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
                while (salaryDataReader.Read())
                {
                    SystemControl.employees[EmpIndex].MainSalary =
                        float.Parse(salaryDataReader["Main_Salary"].ToString());

                    SystemControl.employees[EmpIndex].WorkEnvironmentAlt =
                        float.Parse(salaryDataReader["Work_Environment_Alternative"].ToString());

                    SystemControl.employees[EmpIndex].RepresentingAlt =
                        float.Parse(salaryDataReader["Representing_Alternative"].ToString());

                    SystemControl.employees[EmpIndex].SocialRaises =
                        float.Parse(salaryDataReader["Social_Raises"].ToString());

                    SystemControl.employees[EmpIndex].SocialRaisesRelease =
                        float.Parse(salaryDataReader["Social_Raises_Release"].ToString());

                    SystemControl.employees[EmpIndex].SocialRaisesReleaseAdj =
                        float.Parse(salaryDataReader["Social_Raises_Release_Adj"].ToString());

                    SystemControl.employees[EmpIndex].CooperativeBoxValue =
                        float.Parse(salaryDataReader["CooperativeBoxValue"].ToString());

                    SystemControl.employees[EmpIndex].CooperativeBoxValue_2 =
                        float.Parse(salaryDataReader["CooperativeBoxValue_2"].ToString());

                    SystemControl.employees[EmpIndex].NetTaxes = float.Parse(salaryDataReader["Net_Taxes"].ToString());

                    SystemControl.employees[EmpIndex].WorkingDays =
                        float.Parse(salaryDataReader["Working_Days"].ToString());

                    SystemControl.employees[EmpIndex].Adj_Total1 =
                        float.Parse(salaryDataReader["Total1_Adj"].ToString()); // New in Test

                    SystemControl.employees[EmpIndex].Total2 = float.Parse(salaryDataReader["Total2"].ToString());

                    SystemControl.employees[EmpIndex].Total1 = float.Parse(salaryDataReader["Total1"].ToString()); // New in Test
                    SystemControl.employees[EmpIndex].Total2 = float.Parse(salaryDataReader["Total2"].ToString());

                    SystemControl.employees[EmpIndex].Total3 = float.Parse(salaryDataReader["Total3"].ToString());
                    SystemControl.employees[EmpIndex].StaticContainer =
                        float.Parse(salaryDataReader["StaticContainer"].ToString());
                    SystemControl.employees[EmpIndex].DynamicContainer =
                        float.Parse(salaryDataReader["DynamicContainer"].ToString());
                    SystemControl.employees[EmpIndex].WorkersDay =
                        float.Parse(salaryDataReader["Workers_Day"].ToString());
                    SystemControl.employees[EmpIndex].WorkersDayAdj =
                        float.Parse(salaryDataReader["Workers_Day_Adj"].ToString());
                    SystemControl.employees[EmpIndex].Other = float.Parse(salaryDataReader["others"].ToString());
                }

                salaryDataReader.Close();


                // Get Giveaways data if exist
                salaryCommand.CommandText =
                    "select * from G_With_Salary where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID";
                salaryCommand.Parameters.Clear();
                salaryCommand.Parameters.Add("@ID", Emp.AIOID);
                salaryCommand.Parameters.Add("@Month", DateTime.Now.Month);
                salaryCommand.Parameters.Add("@Year", DateTime.Now.Year);
                salaryDataReader = salaryCommand.ExecuteReader();
                if (salaryDataReader.HasRows)
                    while (salaryDataReader.Read())
                        Emp.Giveaways = float.Parse(salaryDataReader["G_Value"].ToString());

                salaryDataReader.Close();
            }
        }

        public void getMainData()
        {
            SqlCommand employeesCommand = new SqlCommand();
            employeesCommand.Connection = connection;
            employeesCommand.CommandText = "select * from Employee order by 'AIO_Code'";
            employeesCommand.CommandType = CommandType.Text;
            SqlDataReader employeesDataReader = employeesCommand.ExecuteReader();

            int i = 0;

            while (employeesDataReader.Read())
            {
                Employee E = new Employee();
                E.FullName = employeesDataReader["Full_Name"].ToString();
                E.AIOID = int.Parse(employeesDataReader["AIO_Code"].ToString());
                E.DateOfBirth = DateTime.Parse(employeesDataReader["Date_of_Birth"].ToString());
                E.HiringDate = (DateTime) employeesDataReader["Hiring_D"];
                E.TerminationDate = (DateTime) employeesDataReader["Termination_D"];
                E.CurrentDegree = (Degree) Enum.Parse(typeof(Degree), employeesDataReader["E_Degree"].ToString());
                E.EType = (EmploymentType) Enum.Parse(typeof(EmploymentType), employeesDataReader["E_Type"].ToString());
                E.Dept_ID = int.Parse(employeesDataReader["Depart_ID"].ToString());
                E.National_ID = employeesDataReader["N_ID"].ToString();

                if (employeesDataReader["Working_Type"].ToString() == "InDirect")
                    E.WType = WorkingType.InDirect;
                else if (employeesDataReader["Working_Type"].ToString() == "Direct    ")
                    E.WType = WorkingType.Direct;
                if (employeesDataReader["Contract_Type"].ToString() == "Temporary")
                    E.CType = ContractType.Temporary;
                else if (employeesDataReader["Contract_Type"].ToString() == "Permenant")
                    E.CType = ContractType.Permenant;
                SystemControl.employees.Add(E);
                i++;
            }

            employeesDataReader.Close();
            i = 0;
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            ////******************************************************************* THIS 8 IS NOT CONSTANT***************
            //salaryCommand.CommandText = "select * from salary where MONTH(Payment_D) = @date order by 'AIO_Code'";

            salaryCommand.CommandType = CommandType.Text;

            //SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
            //salaryDataReader.Read();
            foreach (Employee Emp in SystemControl.employees)
            {

                //******************************************************************* THIS 8 IS NOT CONSTANT***************
                salaryCommand.CommandText = "select * from salary where MONTH(Payment_D) = @date and AIO_Code = @ID";
                salaryCommand.Parameters.Clear();
                salaryCommand.Parameters.Add("@date", (DateTime.Now.Month));
                salaryCommand.Parameters.Add("@ID", (Emp.AIOID));

                int EmpIndex = SystemControl.employees.FindIndex(j => j.AIOID == Emp.AIOID);
                SetMinusesData2(EmpIndex, DateTime.Now);
                GetInstallsValue(Emp.AIOID, ref Emp.AlimonyMonthlyInstallment, ref Emp.Insurance_Policy_Release,
                    ref Emp.PreviousPeriodInstallments);

                SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
                while (salaryDataReader.Read())
                {
                    SystemControl.employees[EmpIndex].MainSalary =
                        float.Parse(salaryDataReader["Main_Salary"].ToString());
                    SystemControl.employees[EmpIndex].WorkEnvironmentAlt =
                        float.Parse(salaryDataReader["Work_Environment_Alternative"].ToString());
                    SystemControl.employees[EmpIndex].RepresentingAlt =
                        float.Parse(salaryDataReader["Representing_Alternative"].ToString());
                    SystemControl.employees[EmpIndex].SocialRaises =
                        float.Parse(salaryDataReader["Social_Raises"].ToString());
                    SystemControl.employees[EmpIndex].CooperativeBoxValue =
                        float.Parse(salaryDataReader["CooperativeBoxValue"].ToString());
                    SystemControl.employees[EmpIndex].CooperativeBoxValue_2 =
                        float.Parse(salaryDataReader["CooperativeBoxValue_2"].ToString());
                    SystemControl.employees[EmpIndex].NetTaxes = float.Parse(salaryDataReader["Net_Taxes"].ToString());
                    SystemControl.employees[EmpIndex].WorkingDays =
                        float.Parse(salaryDataReader["Working_Days"].ToString());
                    SystemControl.employees[EmpIndex].Adj_Total1 =
                        float.Parse(salaryDataReader["Total1_Adj"].ToString()); // New in Test
                    SystemControl.employees[EmpIndex].Total1 =
                        float.Parse(salaryDataReader["Total1"].ToString()); // New in Test
                    SystemControl.employees[EmpIndex].Total2 = float.Parse(salaryDataReader["Total2"].ToString());
                    SystemControl.employees[EmpIndex].Total3 = float.Parse(salaryDataReader["Total3"].ToString());
                    SystemControl.employees[EmpIndex].NetSalary =
                        float.Parse(salaryDataReader["Net_Salary"].ToString());
                    SystemControl.employees[EmpIndex].TaxesApply =
                        bool.Parse(salaryDataReader["Taxes_Apply"].ToString());
                    SystemControl.employees[EmpIndex].InsuranceApply =
                        bool.Parse(salaryDataReader["Insurances_Apply"].ToString());

                    bool T = Boolean.Parse(salaryDataReader["I_Type"].ToString());
                    SystemControl.employees[EmpIndex].IType = T ? InsuranceType.Current : InsuranceType.New;

                    SystemControl.employees[EmpIndex].StaticCompanyInsurance =
                        float.Parse(salaryDataReader["Static_Company_Insurance"].ToString());
                    SystemControl.employees[EmpIndex].DynamicCompanyInsurance =
                        float.Parse(salaryDataReader["Dynamic_Company_Insurance"].ToString());
                    SystemControl.employees[EmpIndex].StaticEmployeeInsurance =
                        float.Parse(salaryDataReader["Static_Employee_Insurance"].ToString());
                    SystemControl.employees[EmpIndex].DynamicEmployeeInsurance =
                        float.Parse(salaryDataReader["Dynamic_Employee_Insurance"].ToString());
                    SystemControl.employees[EmpIndex].NetTaxAffectedValues =
                        float.Parse(salaryDataReader["Net_Tax_Affected_Value"].ToString());
                    SystemControl.employees[EmpIndex].TotalTaxAffectedValues =
                        float.Parse(salaryDataReader["Total_Tax_Affected_Value"].ToString());
                    SystemControl.employees[EmpIndex].StaticContainer =
                        float.Parse(salaryDataReader["StaticContainer"].ToString());
                    SystemControl.employees[EmpIndex].DynamicContainer =
                        float.Parse(salaryDataReader["DynamicContainer"].ToString());
                    SystemControl.employees[EmpIndex].WorkersDay =
                        float.Parse(salaryDataReader["Workers_Day"].ToString());
                    SystemControl.employees[EmpIndex].WorkersDayAdj =
                        float.Parse(salaryDataReader["Workers_Day_Adj"].ToString());
                    SystemControl.employees[EmpIndex].SocialRaisesRelease =
                        float.Parse(salaryDataReader["Social_Raises_Release"].ToString());
                    SystemControl.employees[EmpIndex].SocialRaisesReleaseAdj =
                        float.Parse(salaryDataReader["Social_Raises_Release_Adj"].ToString());
                    SystemControl.employees[EmpIndex].Other = float.Parse(salaryDataReader["Others"].ToString());
                }

                salaryDataReader.Close();
            }



            SqlCommand taxesCommand = new SqlCommand();
            taxesCommand.Connection = connection;
            //taxesCommand.CommandText = "select * from Taxes where YEAR(Tax_Setting_D) = @date";
            taxesCommand.CommandText = "select * from Taxes";
            taxesCommand.Parameters.Add("@date", DateTime.Now.Year);
            taxesCommand.CommandType = CommandType.Text;
            SqlDataReader taxesDataReader = taxesCommand.ExecuteReader();
            while (taxesDataReader.Read())
            {
                SystemControl._Taxes.CooperativeBoxPercentage =
                    float.Parse(taxesDataReader["Cooperative_Box_Percentage"].ToString());
                SystemControl._Taxes.TaxFreeMaximum = float.Parse(taxesDataReader["Tax_Free_Maximum"].ToString());
                SystemControl._Taxes.PersonalRelease = float.Parse(taxesDataReader["Personal_Release"].ToString());
                //SystemControl._Taxes.InsurancePolicyRelease = float.Parse(taxesDataReader["Social_Raises_Release"].ToString());
                SystemControl._Taxes.LastUpdatedDate = DateTime.Parse(taxesDataReader["Tax_Setting_D"].ToString());

                SystemControl._Taxes.AddTaxLevel(1, float.Parse(taxesDataReader["Value0"].ToString()),
                    float.Parse(taxesDataReader["Percentage0"].ToString()));
                SystemControl._Taxes.AddTaxLevel(2, float.Parse(taxesDataReader["Value1"].ToString()),
                    float.Parse(taxesDataReader["Percentage1"].ToString()));
                SystemControl._Taxes.AddTaxLevel(3, float.Parse(taxesDataReader["Value2"].ToString()),
                    float.Parse(taxesDataReader["Percentage2"].ToString()));
                SystemControl._Taxes.AddTaxLevel(4, float.Parse(taxesDataReader["Value3"].ToString()),
                    float.Parse(taxesDataReader["Percentage3"].ToString()));
                SystemControl._Taxes.AddTaxLevel(5, float.Parse(taxesDataReader["Value4"].ToString()),
                    float.Parse(taxesDataReader["Percentage4"].ToString()));

            }

            taxesDataReader.Close();

            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            //insuranceCommand.CommandText = "select * from Insurances where YEAR(Insurance_Setting_D) = @date";
            insuranceCommand.CommandText = "select * from Insurances";
            insuranceCommand.Parameters.Add("@date", DateTime.Now.Year);
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader insuranceDataReader = insuranceCommand.ExecuteReader();
            /* Static = new StaticInsurance();
             Dynamic = new DynamicInsurance();*/
            while (insuranceDataReader.Read())
            {
                SystemControl._Insurance.SetStaticInsuranceMaximum(
                    float.Parse(insuranceDataReader["Static_Insurance_Maximum"].ToString()),
                    float.Parse(insuranceDataReader["July_Static_Insurance_Maximum"].ToString()));
                SystemControl._Insurance.SetCompanyStaticPercentage(
                    float.Parse(insuranceDataReader["Company_Static_Percentage"].ToString()));
                SystemControl._Insurance.SetEmployeeStaticPercentage(
                    float.Parse(insuranceDataReader["Employee_Static_Percentage"].ToString()));

                SystemControl._Insurance.SetDynamicInsuranceMaximum(
                    float.Parse(insuranceDataReader["Dynamic_Insurance_Maximum"].ToString()),
                    float.Parse(insuranceDataReader["July_Dynamic_Insurance_Maximum"].ToString()));
                SystemControl._Insurance.SetCompanyDynamicPercentage(
                    float.Parse(insuranceDataReader["Company_Dynamic_Percentage"].ToString()));
                SystemControl._Insurance.SetEmployeeDynamicPercentage(
                    float.Parse(insuranceDataReader["Employee_Dynamic_Percentage"].ToString()));

                SystemControl._Insurance.LastUpdateDate =
                    DateTime.Parse(insuranceDataReader["Insurance_Setting_D"].ToString());
            }

            insuranceDataReader.Close();
        }

        public List<int> GetPensionList()
        {
            List<int> IDList = new List<int>();
            DataTable DT = new DataTable();
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "Select AIO_Code from Employee where E_Type = 1";
            employeeCommand.CommandType = CommandType.Text;
            IDataReader DR = employeeCommand.ExecuteReader();
            DT.Load(DR);
            for (int i = 0; i < DT.Rows.Count; i++)
                IDList.Add(int.Parse(DT.Rows[i].ItemArray[0].ToString()));
            return IDList;
        }

        public void GetMinusesData(int AIO, DateTime Dt, ref float OtherMinuses, ref float Treatment)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText =
                "select * from Minuses2 where AIO_Code = @Code and Month(Payment_D) = @M and Year(Payment_D) = @Y";
            insuranceCommand.Parameters.Add("@Y", Dt.Year);
            insuranceCommand.Parameters.Add("@M", Dt.Month);
            insuranceCommand.Parameters.Add("@Code", AIO);
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader insuranceDataReader = insuranceCommand.ExecuteReader();
            while (insuranceDataReader.Read())
            {
                OtherMinuses = float.Parse(insuranceDataReader["OtherMinuses"].ToString());
                Treatment = float.Parse(insuranceDataReader["Treatment"].ToString());
            }

            insuranceDataReader.Close();
        }

        void SetMinusesData1(ref Employee Emp, DateTime Dt)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText =
                "select * from Minuses2 where AIO_Code = @Code and Month(Payment_D) = @M and Year(Payment_D) = @Y";
            insuranceCommand.Parameters.Add("@Y", Dt.Year);
            insuranceCommand.Parameters.Add("@M", Dt.Month);
            insuranceCommand.Parameters.Add("@Code", Emp.AIOID);
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader insuranceDataReader = insuranceCommand.ExecuteReader();
            while (insuranceDataReader.Read())
            {
                Emp.OtherMinuses = float.Parse(insuranceDataReader["OtherMinuses"].ToString());
                Emp.TreatmentCost = float.Parse(insuranceDataReader["Treatment"].ToString());
            }

            insuranceDataReader.Close();
        }

        void SetMinusesData2(int EmpIndex, DateTime Dt)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText =
                "select * from Minuses2 where AIO_Code = @Code and Month(Payment_D) = @M and Year(Payment_D) = @Y";
            insuranceCommand.Parameters.Add("@Y", Dt.Year);
            insuranceCommand.Parameters.Add("@M", Dt.Month);
            insuranceCommand.Parameters.Add("@Code", SystemControl.employees[EmpIndex].AIOID);
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader insuranceDataReader = insuranceCommand.ExecuteReader();
            while (insuranceDataReader.Read())
            {
                SystemControl.employees[EmpIndex].OtherMinuses =
                    float.Parse(insuranceDataReader["OtherMinuses"].ToString());
                SystemControl.employees[EmpIndex].TreatmentCost =
                    float.Parse(insuranceDataReader["Treatment"].ToString());
            }

            insuranceDataReader.Close();
        }

        void UpdateMinusesData2(ref Employee Emp, DateTime Dt)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            SqlCommand insuranceCommand2 = new SqlCommand();
            insuranceCommand.Connection = insuranceCommand2.Connection = connection;
            insuranceCommand.CommandText =
                "select * from Minuses2 where AIO_Code = @Code and Month(Payment_D) = @M and Year(Payment_D) = @Y";

            insuranceCommand.Parameters.Add("@Y", Dt.Year);
            insuranceCommand.Parameters.Add("@M", Dt.Month);
            insuranceCommand.Parameters.Add("@Code", Emp.AIOID);

            insuranceCommand2.Parameters.Add("@D", Dt);
            insuranceCommand2.Parameters.Add("@Y", Dt.Year);
            insuranceCommand2.Parameters.Add("@M", Dt.Month);
            insuranceCommand2.Parameters.Add("@Code", Emp.AIOID);
            insuranceCommand2.Parameters.Add("@OM", Emp.OtherMinuses);
            insuranceCommand2.Parameters.Add("@TC", Emp.TreatmentCost);

            insuranceCommand.CommandType = CommandType.Text;
            insuranceCommand2.CommandType = CommandType.Text;
            SqlDataReader insuranceDataReader = insuranceCommand.ExecuteReader();
            if (insuranceDataReader.HasRows)
                insuranceCommand2.CommandText =
                    "update Minuses2 set OtherMinuses = @OM , Treatment = @TC where AIO_Code = @Code and Month(Payment_D) = @M and Year(Payment_D) = @Y";
            else
                insuranceCommand2.CommandText =
                    "insert into Minuses2 (AIO_Code , Payment_D , OtherMinuses , Treatment) values (@Code,@D,@OM,@TC)";

            insuranceDataReader.Close();
            SqlDataReader insuranceDataReader2 = insuranceCommand2.ExecuteReader();

            insuranceDataReader2.Close();
            ClearMinuses2();
        }

        public List<int> GetDeathList()
        {
            List<int> IDList = new List<int>();
            DataTable DT = new DataTable();
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "Select distinct AIO_Code from Death";
            employeeCommand.CommandType = CommandType.Text;
            IDataReader DR = employeeCommand.ExecuteReader();
            DT.Load(DR);
            for (int i = 0; i < DT.Rows.Count; i++)
                IDList.Add(int.Parse(DT.Rows[i].ItemArray[0].ToString()));
            return IDList;
        }

        public void updateTaxData(DateTime T)
        {
            SqlCommand taxCommand = new SqlCommand();
            taxCommand.Connection = connection;
            taxCommand.CommandText =
                "update Taxes set Tax_Free_Maximum =@TFM,Personal_Release =@PR,Cooperative_Box_Percentage =@CBP," +
                "Value1=@OneV,Value2=@TwoV,Value3=@ThreeV,Value4=@FourV,Percentage1=@OneP,Percentage2=@TwoP,Percentage3=@ThreeP,Percentage4=@FourP,Tax_Setting_D=@Date,Value0=@ZeroV,Percentage0=@ZeroP";
            taxCommand.Parameters.Add("@TFM", SystemControl._Taxes.TaxFreeMaximum);
            taxCommand.Parameters.Add("@PR", SystemControl._Taxes.PersonalRelease);
            taxCommand.Parameters.Add("@CBP", SystemControl._Taxes.CooperativeBoxPercentage);
            // taxCommand.Parameters.Add("@SRR", SystemControl._Taxes.InsurancePolicyRelease);
            taxCommand.Parameters.Add("@ZeroV", SystemControl._Taxes.TaxLevels[1].TaxValue);
            taxCommand.Parameters.Add("@ZeroP", SystemControl._Taxes.TaxLevels[1].TaxPercent * 100);
            taxCommand.Parameters.Add("@OneV", SystemControl._Taxes.TaxLevels[2].TaxValue);
            taxCommand.Parameters.Add("@OneP", SystemControl._Taxes.TaxLevels[2].TaxPercent * 100);
            taxCommand.Parameters.Add("@TwoV", SystemControl._Taxes.TaxLevels[3].TaxValue);
            taxCommand.Parameters.Add("@TwoP", SystemControl._Taxes.TaxLevels[3].TaxPercent * 100);
            taxCommand.Parameters.Add("@ThreeV", SystemControl._Taxes.TaxLevels[4].TaxValue);
            taxCommand.Parameters.Add("@ThreeP", SystemControl._Taxes.TaxLevels[4].TaxPercent * 100);
            taxCommand.Parameters.Add("@FourV", SystemControl._Taxes.TaxLevels[5].TaxValue);
            taxCommand.Parameters.Add("@FourP", SystemControl._Taxes.TaxLevels[5].TaxPercent * 100);
            taxCommand.Parameters.Add("@Date", T.ToShortDateString());
            taxCommand.CommandType = CommandType.Text;
            SqlDataReader X = taxCommand.ExecuteReader();
            X.Close();
        }

        public void updateInsuranceData(DateTime D)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText =
                "update Insurances set Static_Insurance_Maximum =@SIM, Dynamic_Insurance_Maximum=@DIM , Company_Static_Percentage =@CSP, Employee_Static_Percentage =@ESP," +
                " Company_Dynamic_Percentage =@CDP , Employee_Dynamic_Percentage=@EDP , Insurance_Setting_D = @Date ,July_Static_Insurance_Maximum =@JulySIM , July_Dynamic_Insurance_Maximum=@JulyDIM";
            insuranceCommand.Parameters.Add("@SIM", SystemControl._Insurance.StaticInsuranceMaximum);
            insuranceCommand.Parameters.Add("@JulySIM", SystemControl._Insurance.JulyStaticInsuranceMaximum);
            insuranceCommand.Parameters.Add("@DIM", SystemControl._Insurance.DynamicInsuranceMaximum);
            insuranceCommand.Parameters.Add("@JulyDIM", SystemControl._Insurance.JulyDynamicInsuranceMaximum);
            insuranceCommand.Parameters.Add("@CSP", SystemControl._Insurance.CompanyStaticPercentage);
            insuranceCommand.Parameters.Add("@ESP", SystemControl._Insurance.EmployeeStaticPercentage);
            insuranceCommand.Parameters.Add("@CDP", SystemControl._Insurance.CompanyDynamicPercentage);
            insuranceCommand.Parameters.Add("@EDP", SystemControl._Insurance.EmployeeDynamicPercentage);
            insuranceCommand.Parameters.Add("@Date", D.ToShortDateString());
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader X = insuranceCommand.ExecuteReader();
            X.Close();
        }  

        #region Annual Bonuses

        public DataTable GetSalaries(int month, int Year)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText =
                "Select AIO_Code,Net_Salary from Salary where Month(Payment_D) = @Mon and Year(Payment_D) = @Year order by 'AIO_Code'";
            insuranceCommand.Parameters.Add("@Mon", month);
            insuranceCommand.Parameters.Add("@Year", Year);
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = insuranceCommand.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(SalaryCommandWriter);
            SalaryCommandWriter.Close();
            return DT;
        }

        public List<int> GetEmps(int Month, int Year)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandType = CommandType.Text;
            DataTable DT = new DataTable();
            List<int> Emp_ID = new List<int>();
            ReConnectDB();
            insuranceCommand.CommandText =
                "Select AIO_Code from Salary where Month(Payment_D) = @Mon and Year(Payment_D) = @Year";
            insuranceCommand.Parameters.Add("@Mon", Month);
            insuranceCommand.Parameters.Add("@Year", Year);
            SqlDataReader SalaryCommandWriter = insuranceCommand.ExecuteReader();
            DT.Load(SalaryCommandWriter);
            Emp_ID.Clear();
            for (int i = 0; i < DT.Rows.Count; i++)
                Emp_ID.Add(int.Parse(DT.Rows[i].ItemArray[0].ToString()));

            SalaryCommandWriter.Close();

            return Emp_ID;
        }

        void SetEmpDate(ref Dictionary<int, Degree> DegreeDic, ref Dictionary<int, ContractType> ContractDic,
            ref List<int> Emp_ID)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            DataTable DT = new DataTable();
            insuranceCommand.CommandType = CommandType.Text;

            DegreeDic.Clear();
            ContractDic.Clear();
            insuranceCommand.Connection = connection;

            for (int i = 0; i < Emp_ID.Count; i++)
            {
                insuranceCommand.CommandText = "Select Contract_Type,E_Degree from Employee where AIO_Code = @ID ";
                insuranceCommand.Parameters.Clear();
                insuranceCommand.Parameters.Add("@ID", Emp_ID[i]);
                SqlDataReader SalaryCommandWriter = insuranceCommand.ExecuteReader();
                DT.Load(SalaryCommandWriter);
                SalaryCommandWriter.Close(); // New Test 4/11/2018
                DegreeDic.Add(Emp_ID[i], (Degree) Enum.Parse(typeof(Degree), DT.Rows[0].ItemArray[1].ToString()));
                ContractDic.Add(Emp_ID[i],
                    (ContractType) Enum.Parse(typeof(ContractType), DT.Rows[0].ItemArray[0].ToString()));
            }
        }

        void SetEmpType(ref Dictionary<int, EmploymentType> TypeDic, ref List<int> Emp_ID)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            DataTable DT = new DataTable();
            insuranceCommand.CommandType = CommandType.Text;

            TypeDic.Clear();
            insuranceCommand.Connection = connection;

            for (int i = 0; i < Emp_ID.Count; i++)
            {
                insuranceCommand.CommandText = "Select E_Type,E_Degree from Employee where AIO_Code = @ID";
                insuranceCommand.Parameters.Clear();
                insuranceCommand.Parameters.Add("@ID", Emp_ID[i]);

                SqlDataReader SalaryCommandWriter = insuranceCommand.ExecuteReader();
                DT.Load(SalaryCommandWriter);
                SalaryCommandWriter.Close(); // New Test 4/11/2018
                TypeDic.Add(Emp_ID[i], (EmploymentType)Enum.Parse(typeof(EmploymentType), DT.Rows[0].ItemArray[0].ToString()));
            }
        }

        public void UpdateTotal_1(float PensionPercentage)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandType = CommandType.Text;
            DataTable DT = new DataTable();
            List<int> Emp_ID = new List<int>();
            Dictionary<int, Degree> DegreeDic = new Dictionary<int, Degree>();
            Dictionary<int, ContractType> ContractDic = new Dictionary<int, ContractType>();
            Dictionary<int, EmploymentType> ETypeDic = new Dictionary<int, EmploymentType>();
            float PrimValue = 0, SocValue = 0;
            for (int i = 1; i < 13; i++)
            {
                // Get Employees in month of i
                Emp_ID = GetEmps(i, DateTime.Now.Year);

                // Set Contract Type and degree for each empolyee
                SetEmpDate(ref DegreeDic, ref ContractDic, ref Emp_ID);
                SetEmpType(ref ETypeDic, ref Emp_ID);
                // update Total1 for each employee
                for (int j = 0; j < Emp_ID.Count; j++)
                {
                    // Set Social and primary Extra value
                    if (ETypeDic[Emp_ID[j]] == EmploymentType.EmployeeType)
                    {
                        switch (DegreeDic[Emp_ID[j]])
                        {
                            case Degree.A:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.A_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.A_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.A_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.A_T_S];
                                }

                                break;
                            case Degree.B1:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.B1_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.B1_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.B1_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.B1_T_S];
                                }

                                break;
                            case Degree.B2:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.B2_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.B2_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.B2_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.B2_T_S];
                                }

                                break;
                            case Degree.C1:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.C1_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.C1_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.C1_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.C1_T_S];
                                }

                                break;
                            case Degree.C2:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.C2_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.C2_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.C2_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.C2_T_S];
                                }

                                break;
                            case Degree.C3:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.C3_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.C3_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.C3_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.C3_T_S];
                                }

                                break;
                            case Degree.D1:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D1_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D1_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D1_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D1_T_S];
                                }

                                break;

                            case Degree.D2:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D2_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D2_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D2_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D2_T_S];
                                }

                                break;

                            case Degree.D3:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D3_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D3_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D3_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D3_T_S];
                                }

                                break;

                            case Degree.D4:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D4_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D4_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D4_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D4_T_S];
                                }

                                break;

                            case Degree.D5:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D5_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D5_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D5_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D5_T_S];
                                }

                                break;
                            case Degree.D6:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D6_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D6_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.D6_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.D6_T_S];
                                }

                                break;
                            case Degree.E1:
                                if (ContractDic[Emp_ID[j]] == ContractType.Permenant)
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.E_P_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.E_P_S];
                                }
                                else
                                {
                                    PrimValue = SystemControl.AnnualRaises[Annual_Degree_List.E_T_P];
                                    SocValue = SystemControl.AnnualRaises[Annual_Degree_List.E_T_S];
                                }

                                break;
                        }
                        insuranceCommand.CommandText =
                            "update salary set Main_Salary = Main_Salary + @PrimValue ,Social_Raises = Social_Raises + @SocValue where MONTH(Payment_D) = @month and YEAR(Payment_D) = @Year and AIO_Code = @id";
                    }
                    else
                    {
                        float T1 = SystemControl.SalaryEmployeesList[SystemControl.SalaryEmployeesList.FindIndex(T => T.AIOID == Emp_ID[j])].Total1;
                        PrimValue = (T1 * PensionPercentage);
                        SocValue = 0;
                        insuranceCommand.CommandText =
                            "update salary set Total1 = Total1 + @PrimValue where MONTH(Payment_D) = @month and YEAR(Payment_D) = @Year and AIO_Code = @id";
                    }

                   
                    insuranceCommand.Parameters.Clear();
                    insuranceCommand.Parameters.Add("@PrimValue", PrimValue);
                    insuranceCommand.Parameters.Add("@SocValue", SocValue);
                    insuranceCommand.Parameters.Add("@month", i);
                    insuranceCommand.Parameters.Add("@id", Emp_ID[j]);
                    insuranceCommand.Parameters.Add("@Year", DateTime.Now.Year);
                    insuranceCommand.CommandType = CommandType.Text;
                    SqlDataReader netDaysReader = insuranceCommand.ExecuteReader();
                    netDaysReader.Close();
                }
            }

        }

        public void UpdateSalaryAfterTotal_1(int month, int year)
        {
            List<int> EmpID = GetEmps(month, year);
            Employee E = new Employee();
            for (int i = 0; i < EmpID.Count; i++)
            {
                E = GetEmpDate(EmpID[i], month, year);
                if (E.TerminationDate.Month == month && E.TerminationDate.Year == year) E.InsuranceApply = false;
                else E.InsuranceApply = true;

                E.ProcessEmployee();
                UpdateEmployee(E, month, year);
            }
        }

        public Dictionary<int, float> GetDifferences(DataTable DT, int Month, int year)
        {
            DataTable DT2 = GetSalaries(Month, year);
            Dictionary<int, float> DifferenceValue = new Dictionary<int, float>();
            for (int i = 0; i < DT2.Rows.Count; i++)
            {
                float DifValue = float.Parse(DT2.Rows[i].ItemArray[1].ToString()) -
                                 float.Parse(DT.Rows[i].ItemArray[1].ToString());
                DifferenceValue.Add(int.Parse(DT.Rows[i].ItemArray[0].ToString()), DifValue);
            }

            return DifferenceValue;
        }

        public void AddDifferences(Dictionary<int, float> DiffDic, int Month, int year)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            foreach (var Dif in DiffDic)
            {
                int ID = Dif.Key;
                float Value = Dif.Value;
                insuranceCommand.CommandText =
                    "update Salary set ADiff =@Value where AIO_Code = @ID and Month(Payment_D) = @Month and Year(Payment_D) = @Year ";
                insuranceCommand.Parameters.Clear();
                insuranceCommand.Parameters.Add("@ID", ID);
                insuranceCommand.Parameters.Add("@Month", Month);
                insuranceCommand.Parameters.Add("@Year", year);
                insuranceCommand.Parameters.Add("@Value", Value);
                insuranceCommand.CommandType = CommandType.Text;
                SqlDataReader XX = insuranceCommand.ExecuteReader();
                XX.Close();
            }
        }












        #endregion

        #region Special Annual Bonuses

        public DataTable GetSalaries(int month, int Year, int AIO_Code)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText =
                "Select AIO_Code,Net_Salary from Salary where Month(Payment_D) = @Mon and Year(Payment_D) = @Year and AIO_Code = @ID";
            insuranceCommand.Parameters.Add("@Mon", month);
            insuranceCommand.Parameters.Add("@Year", Year);
            insuranceCommand.Parameters.Add("@ID", AIO_Code);
            insuranceCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = insuranceCommand.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(SalaryCommandWriter);
            return DT;
        }

        void SetEmpDate(ref Degree DegreeDic, ref ContractType ContractDic, int Emp_ID)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            DataTable DT = new DataTable();
            insuranceCommand.CommandType = CommandType.Text;
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandText = "Select Contract_Type,E_Degree from Employee where AIO_Code = @ID ";
            insuranceCommand.Parameters.Clear();
            insuranceCommand.Parameters.Add("@ID", Emp_ID);
            SqlDataReader SalaryCommandWriter = insuranceCommand.ExecuteReader();
            DT.Load(SalaryCommandWriter);
            DegreeDic = (Degree) Enum.Parse(typeof(Degree), DT.Rows[0].ItemArray[1].ToString());
            ContractDic = (ContractType) Enum.Parse(typeof(ContractType), DT.Rows[0].ItemArray[0].ToString());

        }

        public void UpdateTotal_1(int Emp_ID, float _PrimValue, float _Socialvalue)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            insuranceCommand.CommandType = CommandType.Text;
            Degree DegreeDic = Degree.A;
            ContractType ContractDic = ContractType.Permenant;
            float PrimValue = _PrimValue, SocValue = _Socialvalue;
            for (int i = 1; i < 13; i++)
            {
                // Set Contract Type and degree for each empolyee
                SetEmpDate(ref DegreeDic, ref ContractDic, Emp_ID);
                insuranceCommand.CommandText =
                    "update salary set Main_Salary = Main_Salary + @PrimValue ,Social_Raises = Social_Raises + @SocValue where MONTH(Payment_D) = @month and YEAR(Payment_D) = @Year and AIO_Code = @id";
                insuranceCommand.Parameters.Clear();
                insuranceCommand.Parameters.Add("@PrimValue", PrimValue);
                insuranceCommand.Parameters.Add("@SocValue", SocValue);
                insuranceCommand.Parameters.Add("@month", i);
                insuranceCommand.Parameters.Add("@id", Emp_ID);
                insuranceCommand.Parameters.Add("@Year", DateTime.Now.Year);
                insuranceCommand.CommandType = CommandType.Text;
                SqlDataReader netDaysReader = insuranceCommand.ExecuteReader();
                netDaysReader.Close();
            }
        }

        public void UpdateSalaryAfterTotal_1(int month, int year, int EmpID)
        {
            Employee E = new Employee();
            E = GetEmpDate(EmpID, month, year);

            if (E.TerminationDate.Month == month && E.TerminationDate.Year == year)
                E.InsuranceApply = false; // New Commented for inssurance applying
            else E.InsuranceApply = true; // New Commented for inssurance applying

            //DateTime Min = new DateTime(year, 7, 1);
            //DateTime Max = new DateTime(year, 12, 31);
            //if (E.HiringDate >= Min && E.HiringDate <= Max) E.ApplyJulyInsurance = true;
            //else E.ApplyJulyInsurance = false;

            E.ProcessEmployee();
            UpdateEmployee(E, month, year);
        }

        public Dictionary<int, float> GetDifferences(DataTable DT, int Month, int year, int AIO_Code)
        {
            DataTable DT2 = GetSalaries(Month, year, AIO_Code);
            Dictionary<int, float> DifferenceValue = new Dictionary<int, float>();
            for (int i = 0; i < DT2.Rows.Count; i++)
            {
                float DifValue = float.Parse(DT2.Rows[i].ItemArray[1].ToString()) -
                                 float.Parse(DT.Rows[i].ItemArray[1].ToString());
                DifferenceValue.Add(int.Parse(DT.Rows[i].ItemArray[0].ToString()), DifValue);
            }

            return DifferenceValue;
        }

        public void AddDifferences(Dictionary<int, float> DiffDic, int Month, int year, int EmpID)
        {
            SqlCommand insuranceCommand = new SqlCommand();
            insuranceCommand.Connection = connection;
            foreach (var Dif in DiffDic)
            {
                float Value = Dif.Value;
                insuranceCommand.CommandText =
                    "update Salary set ADiff =@Value where AIO_Code = @ID and Month(Payment_D) = @Month and Year(Payment_D) = @Year ";
                insuranceCommand.Parameters.Clear();
                insuranceCommand.Parameters.Add("@ID", EmpID);
                insuranceCommand.Parameters.Add("@Month", Month);
                insuranceCommand.Parameters.Add("@Year", year);
                insuranceCommand.Parameters.Add("@Value", Value);
                insuranceCommand.CommandType = CommandType.Text;
                insuranceCommand.ExecuteReader();
            }
        }

        #endregion

        #region Employee Data

        Employee GetEmpDate(int AIOCode, int Month, int Year)
        {
            // Salary Data
            Employee E = new Employee();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.CommandType = CommandType.Text;
            salaryCommand.Connection = connection;



            salaryCommand.CommandText =
                "select * from Salary where AIO_Code = @ID and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            salaryCommand.Parameters.Add("@ID", AIOCode);
            salaryCommand.Parameters.Add("@Month", Month);
            salaryCommand.Parameters.Add("@Year", Year);

            SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
            while (salaryDataReader.Read())
            {
                E.MainSalary = float.Parse(salaryDataReader["Main_Salary"].ToString());
                E.WorkEnvironmentAlt = float.Parse(salaryDataReader["Work_Environment_Alternative"].ToString());
                E.RepresentingAlt = float.Parse(salaryDataReader["Representing_Alternative"].ToString());
                E.SocialRaises = float.Parse(salaryDataReader["Social_Raises"].ToString());
                E.CooperativeBoxValue = float.Parse(salaryDataReader["CooperativeBoxValue"].ToString());
                E.CooperativeBoxValue_2 = float.Parse(salaryDataReader["CooperativeBoxValue_2"].ToString());
                E.NetTaxes = float.Parse(salaryDataReader["Net_Taxes"].ToString());
                E.WorkingDays = float.Parse(salaryDataReader["Working_Days"].ToString());
                E.Adj_Total1 = float.Parse(salaryDataReader["Total1_Adj"].ToString()); // New in Test
                E.Total1 = float.Parse(salaryDataReader["Total1"].ToString()); // New in Test
                E.Total2 = float.Parse(salaryDataReader["Total2"].ToString());
                E.Total3 = float.Parse(salaryDataReader["Total3"].ToString());
                E.NetSalary = float.Parse(salaryDataReader["Net_Salary"].ToString());
                E.TaxesApply = bool.Parse(salaryDataReader["Taxes_Apply"].ToString());
                E.InsuranceApply = bool.Parse(salaryDataReader["Insurances_Apply"].ToString());
                E.StaticCompanyInsurance = float.Parse(salaryDataReader["Static_Company_Insurance"].ToString());
                E.DynamicCompanyInsurance = float.Parse(salaryDataReader["Dynamic_Company_Insurance"].ToString());
                E.StaticEmployeeInsurance = float.Parse(salaryDataReader["Static_Employee_Insurance"].ToString());
                E.DynamicEmployeeInsurance = float.Parse(salaryDataReader["Dynamic_Employee_Insurance"].ToString());
                E.NetTaxAffectedValues = float.Parse(salaryDataReader["Net_Tax_Affected_Value"].ToString());
                E.TotalTaxAffectedValues = float.Parse(salaryDataReader["Total_Tax_Affected_Value"].ToString());
                E.StaticContainer = float.Parse(salaryDataReader["StaticContainer"].ToString());
                E.DynamicContainer = float.Parse(salaryDataReader["DynamicContainer"].ToString());
                E.WorkersDay = float.Parse(salaryDataReader["Workers_Day"].ToString());
                E.WorkersDayAdj = float.Parse(salaryDataReader["Workers_Day_Adj"].ToString());
                E.SocialRaisesRelease = float.Parse(salaryDataReader["Social_Raises_Release"].ToString());
                E.SocialRaisesReleaseAdj = float.Parse(salaryDataReader["Social_Raises_Release_Adj"].ToString());
                E.Other = float.Parse(salaryDataReader["Others"].ToString());
                bool T = Boolean.Parse(salaryDataReader["I_Type"].ToString());
                E.IType = T ? InsuranceType.Current : InsuranceType.New;
            }

            salaryDataReader.Close();

            // Basic Data 
            salaryCommand.CommandText = "select * from Employee where AIO_Code = @ID";
            SqlDataReader salaryDataReader2 = salaryCommand.ExecuteReader();
            while (salaryDataReader2.Read())
            {
                E.AIOID = int.Parse(salaryDataReader2["AIO_Code"].ToString());
                E.FullName = salaryDataReader2["Full_Name"].ToString();
                E.DateOfBirth = DateTime.Parse(salaryDataReader2["Date_of_Birth"].ToString());
                E.HiringDate = DateTime.Parse(salaryDataReader2["Hiring_D"].ToString());
                E.TerminationDate = DateTime.Parse(salaryDataReader2["Termination_D"].ToString());
                E.CurrentDegree = (Degree) Enum.Parse(typeof(Degree), salaryDataReader2["E_Degree"].ToString());
                E.Dept_ID = int.Parse(salaryDataReader2["Depart_ID"].ToString());
                E.National_ID = salaryDataReader2["N_ID"].ToString();

                if (salaryDataReader2["Working_Type"].ToString() == "InDirect") E.WType = WorkingType.InDirect;
                else if (salaryDataReader2["Working_Type"].ToString() == "Direct    ") E.WType = WorkingType.Direct;
                if (salaryDataReader2["Contract_Type"].ToString() == "Temporary") E.CType = ContractType.Temporary;
                else if (salaryDataReader2["Contract_Type"].ToString() == "Permenant") E.CType = ContractType.Permenant;
            }

            salaryDataReader2.Close();
            // Minuses Data
            salaryCommand.CommandText =
                "select * from Minuses where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID";
            //ReConnectDB();
            SqlDataReader salaryDataReader3 = salaryCommand.ExecuteReader();
            while (salaryDataReader3.Read())
            {
                E.SicknessDays = float.Parse(salaryDataReader3["Sickness_Days"].ToString());
                E.AbsenceDays = float.Parse(salaryDataReader3["Abscence_Days"].ToString());
                E.Penalty = float.Parse(salaryDataReader3["Penalty_Days"].ToString());
            }

            salaryDataReader3.Close();
            // Bonuses Data 
            salaryCommand.CommandText =
                "select * from Bonuses where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID";
            //ReConnectDB();
            SqlDataReader salaryDataReader4 = salaryCommand.ExecuteReader();
            while (salaryDataReader4.Read())
            {
                E.MorningHrs = float.Parse(salaryDataReader4["Morning_Hours"].ToString());
                E.AfternoonHrs = float.Parse(salaryDataReader4["Afternoon_Hours"].ToString());
                E.NightHrs = float.Parse(salaryDataReader4["Night_Hours"].ToString());
                E.ExtraShifts = float.Parse(salaryDataReader4["Extra_Shifts_Days"].ToString());
                E.OfficialHolidays = float.Parse(salaryDataReader4["Official_Holidays"].ToString());
            }

            salaryDataReader4.Close();

            DateTime XC = new DateTime(Year, Month, 15);
            GetMinusesData(E.AIOID, XC, ref E.OtherMinuses, ref E.TreatmentCost);
            GetInstallsValue(E.AIOID, ref E.AlimonyMonthlyInstallment, ref E.Insurance_Policy_Release,
                ref E.PreviousPeriodInstallments);
            //ReConnectDB();

            return E;
        }

        List<Employee> GetEmpDate(int Month, int Year)
        {
            List<Employee> EmpList = new List<Employee>();
            List<int> EmpID = GetEmps(Month, Year);
            Employee E = new Employee();
            for (int i = 0; i < EmpID.Count; i++)
            {
                E = GetEmpDate(EmpID[i], Month, Year);
                EmpList.Add(E);
            }

            return EmpList;
        }

        void UpdateEmployee(Employee emp, int Month, int Year)
        {

            // Update Salary Table
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText =
                "update salary set CooperativeBoxValue = @COP , CooperativeBoxValue_2 = @COP2 , Main_Salary =@main,Work_Environment_Alternative =@WEA,Representing_Alternative=@RA," +
                "Social_Raises=@SR,Net_Salary =@NetSalary,Taxes_Apply =@TA, Insurances_Apply =@IA,Static_Company_Insurance =@SCI,Dynamic_Company_Insurance =@DCI, Static_Employee_Insurance =@SEI, Dynamic_Employee_Insurance =@DEI," +
                "Net_Tax_Affected_Value =@NTAV, Total_Tax_Affected_Value =@TTAV, Net_Taxes =@NT ,Total1 = @T1,Total1_Adj = @T1A ,Total2 = @T2 ,Total3 = @T3 , Social_Raises_Release_Adj = @SRRA, Social_Raises_Release = @SRR, " +
                "Working_Days = @WD,StaticContainer = @SC,DynamicContainer=@DC , Workers_Day = @WDS , Workers_Day_Adj = @WDSA , Others = @O ,I_Type = @IType " +
                "where AIO_Code =@id and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            salaryCommand.Parameters.Add("@main", emp.MainSalary);
            salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
            salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
            salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
            salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
            salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
            salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
            salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
            salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
            salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
            salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
            salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
            salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
            salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
            salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
            salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@id", emp.AIOID);
            salaryCommand.Parameters.Add("@Month", Month);
            salaryCommand.Parameters.Add("@Year", Year);
            salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
            salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
            salaryCommand.Parameters.Add("@T2", emp.Total2);
            salaryCommand.Parameters.Add("@T3", emp.Total3);
            // salaryCommand.Parameters.Add("@IPR", emp.Insurance_Policy_Release);
            salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
            salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
            salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
            salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
            salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
            salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
            salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
            salaryCommand.Parameters.Add("@O", emp.Other);
            salaryCommand.Parameters.Add("@IType", emp.IType);
            SqlDataReader XXX = salaryCommand.ExecuteReader();
            XXX.Close();
            ReConnectDB();

            // Update Minuses Table
            SqlCommand salaryCommand2 = new SqlCommand();
            salaryCommand2.Connection = connection;
            salaryCommand2.CommandText =
                "update Minuses set Sickness_Days = @Sickness_Days , Sickness_Minus_Value =@Sickness_Minus_Value,Abscence_Minus_Value =@Abscence_Minus_Value,Penalty_Days=@Penalty_Days," +
                "Penalty_Minus_Value =@Penalty_Minus_Value, Total_Minuses =@Total_Minuses where AIO_Code =@id and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            salaryCommand2.Parameters.Add("@Sickness_Days", emp.SicknessDays);
            salaryCommand2.Parameters.Add("@Sickness_Minus_Value", emp.SicknessValue);
            salaryCommand2.Parameters.Add("@Abscence_Days", emp.AbsenceDays);
            salaryCommand2.Parameters.Add("@Abscence_Minus_Value", emp.AbsenceValue);
            salaryCommand2.Parameters.Add("@Penalty_Days", emp.Penalty);
            salaryCommand2.Parameters.Add("@Penalty_Minus_Value", emp.PenaltyValue);
            salaryCommand2.Parameters.Add("@Total_Minuses", emp.TotalMinuses);
            salaryCommand2.Parameters.Add("@id", emp.AIOID);
            salaryCommand2.Parameters.Add("@Month", Month);
            salaryCommand2.Parameters.Add("@Year", Year);
            SqlDataReader salaryDataReader4 = salaryCommand2.ExecuteReader();
            salaryDataReader4.Close();
            DateTime XC = new DateTime(Year, Month, 15);
            UpdateMinusesData2(ref emp, XC);
            UpdateInstallsValue(emp.AIOID, ref emp.AlimonyMonthlyInstallment, ref emp.Insurance_Policy_Release,
                ref emp.PreviousPeriodInstallments);
            ReConnectDB();

            // Update Bonuses Table
            SqlCommand salaryCommand3 = new SqlCommand();
            salaryCommand3.Connection = connection;
            salaryCommand3.CommandText =
                "update Bonuses set Morning_Hours = @Morning_Hours , Afternoon_Hours =@Afternoon_Hours,Night_Hours =@Night_Hours," +
                "Extra_Shifts_Days=@Extra_Shifts_Days,Extra_Shifts_Bonus_Value =@Extra_Shifts_Bonus_Value,Official_Holidays =@Official_Holidays,Total_Bonuses =@Total_Bonuses" +
                " where AIO_Code =@id and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            salaryCommand3.Parameters.Add("@Morning_Hours", emp.MorningHrs);
            salaryCommand3.Parameters.Add("@Afternoon_Hours", emp.AfternoonHrs);
            salaryCommand3.Parameters.Add("@Night_Hours", emp.NightHrs);
            salaryCommand3.Parameters.Add("@Extra_Shifts_Days", emp.ExtraShifts);
            salaryCommand3.Parameters.Add("@Extra_Shifts_Bonus_Value", emp.ExtraShiftBonus);
            salaryCommand3.Parameters.Add("@Official_Holidays", emp.OfficialHolidays);
            salaryCommand3.Parameters.Add("@Total_Bonuses", emp.TotalBonuses);
            salaryCommand3.Parameters.Add("@id", emp.AIOID);
            salaryCommand3.Parameters.Add("@Month", Month);
            salaryCommand3.Parameters.Add("@Year", Year);
            XXX = salaryCommand3.ExecuteReader();
            XXX.Close();

            ReConnectDB();
            SetNetDays_30();
        }

        #endregion

        public void AddEmployee(Employee emp, int Startday, int WorkingMonths)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText =
                "INSERT INTO Employee (Full_Name,AIO_Code,Date_of_Birth,Hiring_D,Termination_D,Contract_Type,Working_Type,E_Degree,Depart_ID,N_ID,E_Type)" +
                " VALUES(@FN,@AIOID,@DOB,@HD,@TD,@CT,@WT,@ED,@Depart_ID,@NID,@Type);";
            employeeCommand.Parameters.Add("@FN", emp.FullName);
            employeeCommand.Parameters.Add("@AIOID", emp.AIOID);
            employeeCommand.Parameters.Add("@DOB", emp.DateOfBirth.Date);
            employeeCommand.Parameters.Add("@HD", emp.HiringDate.Date);
            employeeCommand.Parameters.Add("@TD", emp.TerminationDate.Date);
            employeeCommand.Parameters.Add("@ED", emp.CurrentDegree);
            employeeCommand.Parameters.Add("@NID", emp.National_ID);
            employeeCommand.Parameters.Add("@Depart_ID", emp.Dept_ID);
            if (emp.CType == ContractType.Temporary)
                employeeCommand.Parameters.Add("@CT", "Temporary");
            else if (emp.CType == ContractType.Permenant)
                employeeCommand.Parameters.Add("@CT", "Permenant");
            if (emp.WType == WorkingType.Direct)
                employeeCommand.Parameters.Add("@WT", "Direct");
            else if (emp.WType == WorkingType.InDirect)
                employeeCommand.Parameters.Add("@WT", "InDirect");

            

            if (emp.EType == EmploymentType.EmployeeType)
                employeeCommand.Parameters.Add("@Type", EmploymentType.EmployeeType);
            else if (emp.EType == EmploymentType.PensionType)
                employeeCommand.Parameters.Add("@Type", EmploymentType.PensionType);
            else employeeCommand.Parameters.Add("@Type", EmploymentType.Awarded);

            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            employeeCommandWriter.Close();

            //if (emp.TerminationDate < DateTime.Now) return;

            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "INSERT INTO Salary" +
                                        " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj" +
                                        ",Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
                                        " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,StaticContainer,DynamicContainer,Workers_Day,Workers_Day_Adj," +
                                        "Others,I_Type,Total1_Adj,CooperativeBoxValue_2)" +
                                        " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA," +
                                        "@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV" +
                                        ",@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@SC,@DC,@WDS,@WDSA,@O,@IType,@T1A,@COP2);";
            int Months = WorkingMonths;
            //Months = WorkingMonths;
            // if (DateTime.Now.Year == emp.HiringDate.Year) Months = Math.Min(WorkingMonths + 1, (13 - emp.HiringDate.Month));
            // else Months = WorkingMonths + 1;
            // Months = Math.Min(WorkingMonths + 1, (13 - emp.HiringDate.Month)); New Commented
            // Months = 13 - emp.HiringDate.Month;

            for (int x = 0; x < Months + 1; x++)
            {
                string EditableForamt = "";
                salaryCommand.Parameters.Clear();

                DateTime XX = emp.HiringDate.AddMonths(x);

                if (XX.Year > DateTime.Now.Year) break;

                //if (x == Months - 1) emp.WorkingDays = emp.TerminationDate.Day;
                if (XX.Month == emp.TerminationDate.Month && XX.Year == emp.TerminationDate.Year)
                    emp.WorkingDays = emp.TerminationDate.Day;
                else if (x == 0) emp.WorkingDays = Startday;
                else emp.WorkingDays = 30;

                // Last Month no Insurance Applied
                if (emp.TerminationDate.Month == XX.Month && emp.TerminationDate.Year == XX.Year)
                    emp.InsuranceApply = false;
                else emp.InsuranceApply = true;

                //DateTime Min = new DateTime(XX.Year, 7, 1);
                //DateTime Max = new DateTime(XX.Year, 12, 31);
                //if (emp.HiringDate >= Min && emp.HiringDate <= Max) emp.ApplyJulyInsurance = true;
                //else emp.ApplyJulyInsurance = false;


                

                emp.ProcessEmployee();
                if (emp.IType == InsuranceType.Current) salaryCommand.Parameters.Add("@IType", InsuranceType.Current);
                else salaryCommand.Parameters.Add("@IType", InsuranceType.New);

                salaryCommand.Parameters.Add("@main", emp.MainSalary);
                salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
                salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
                salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
                salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
                salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
                salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
                salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
                salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
                salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
                salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
                salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
                salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
                salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
                salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
                salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
                salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
                salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
                salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
                salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
                salaryCommand.Parameters.Add("@O", emp.Other);
                EditableForamt = new DateTime(XX.Year, XX.Month, 1)
                    .ToShortDateString();
                salaryCommand.Parameters.Add("@id", emp.AIOID);
                salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
                salaryCommand.Parameters.Add("@PY", EditableForamt);
                salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
                salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
                salaryCommand.Parameters.Add("@T2", emp.Total2);
                salaryCommand.Parameters.Add("@T3", emp.Total3);
                salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
                salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
                //salaryCommand.Parameters.Add("@IType", emp.IType);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();
                SetNetDays_30();
            }
        }

        public void updateNetDaysDB(float netDays, int month, int Year, int AIOID)
        {
            SqlCommand netDaysCommand = new SqlCommand();
            netDaysCommand.Connection = connection;
            netDaysCommand.CommandText =
                "update salary set Working_Days = @netDays where MONTH(Payment_D) = @month and YEAR(Payment_D) = @Year and AIO_Code = @id";
            netDaysCommand.Parameters.Add("@netDays", netDays);
            netDaysCommand.Parameters.Add("@month", month);
            netDaysCommand.Parameters.Add("@id", AIOID);
            netDaysCommand.Parameters.Add("@Year", Year);
            netDaysCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader = netDaysCommand.ExecuteReader();
            netDaysReader.Close();
            SetNetDays_30();
        }

        public void InsertCashLog(decimal CashValue, DateTime PaymentDate, int AIO_ID, DateTime InstallmentDate,int Type)
        {
            SqlCommand SalaryStatusCommand = new SqlCommand();
            SalaryStatusCommand.Connection = connection;
            string XX = InstallmentDate.ToShortDateString();
            SalaryStatusCommand.CommandText = "SELECT Installment_ID from Installments where AIO_Code = " + AIO_ID +
                                              " and Identity_Number = " + Type + " and Start_Payment = '" + XX + "'";
            SalaryStatusCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader2 = SalaryStatusCommand.ExecuteReader();
            DataTable T = new DataTable();
            T.Load(netDaysReader2);
            int installmentID = int.Parse(T.Rows[0].ItemArray[0].ToString());
            netDaysReader2.Close();

            SalaryStatusCommand = new SqlCommand();
            SalaryStatusCommand.Connection = connection;
            SalaryStatusCommand.CommandText =
                "insert into Cash_Log (Installment_ID,Cash_Value,Payment_Date) values(@ID,@Cash,@Date)";
            SalaryStatusCommand.Parameters.Add("@ID", installmentID);
            SalaryStatusCommand.Parameters.Add("@Cash", CashValue);
            SalaryStatusCommand.Parameters.Add("@Date", PaymentDate.ToShortDateString());
            SalaryStatusCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader3 = SalaryStatusCommand.ExecuteReader();
            netDaysReader3.Close();
        }

        public void NewInstallment(Installments I)
        {
            SqlCommand SalaryStatusCommand = new SqlCommand();
            SalaryStatusCommand.Connection = connection;
            SalaryStatusCommand.CommandText =
                "insert into Installments (AIO_Code,Identity_Number,Start_Payment,Totall_Value,Monthly_Value,Remain) values(@Code,@Identity,@Start,@Total,@MonthlyValue,@R)";
            SalaryStatusCommand.Parameters.Add("@Code", I.Empcode);
            SalaryStatusCommand.Parameters.Add("@Identity", I.Type);
            SalaryStatusCommand.Parameters.Add("@Start", I.Start);
            SalaryStatusCommand.Parameters.Add("@Total", I.Total);
            SalaryStatusCommand.Parameters.Add("@MonthlyValue", I.MonthlyValue);
            SalaryStatusCommand.Parameters.Add("@R", I.Total);
            SalaryStatusCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader2 = SalaryStatusCommand.ExecuteReader();
            netDaysReader2.Close();
        }

        public bool NewBankInstallment(Installments I)
        {
            SqlCommand SalaryStatusCommand = new SqlCommand();
            SalaryStatusCommand.Connection = connection;
            SalaryStatusCommand.CommandType = CommandType.Text;
            SalaryStatusCommand.CommandText =
                "select * from BankInstallments where AIO_Code = @Code and Bank_Name = @BankName";
            SalaryStatusCommand.Parameters.Add("@Code", I.Empcode);
            SalaryStatusCommand.Parameters.Add("@BankName", I.BankName);

            SqlDataReader netDaysReader2 = SalaryStatusCommand.ExecuteReader();
            netDaysReader2.Close();

            if (netDaysReader2.HasRows) return false;
            else
            {
                SalaryStatusCommand.CommandText =
                    "insert into BankInstallments (AIO_Code,Monthly_Value,Bank_Name) values(@Code,@MonthlyValue,@BankName)";
                SalaryStatusCommand.Parameters.Add("@Code", I.Empcode);
                SalaryStatusCommand.Parameters.Add("@MonthlyValue", I.MonthlyValue);
                SalaryStatusCommand.Parameters.Add("@BankName", I.BankName);
                SalaryStatusCommand.CommandType = CommandType.Text;
                netDaysReader2 = SalaryStatusCommand.ExecuteReader();
                netDaysReader2.Close();
                return true;
            }
        }

        public bool CheckBankExist(string BankName)
        {
            SqlCommand SalaryStatusCommand = new SqlCommand();
            SalaryStatusCommand.Connection = connection;
            SalaryStatusCommand.CommandText = "select Bank_Name from BankInstallments where Bank_Name = @Name";
            SalaryStatusCommand.Parameters.Add("@Name", BankName);
            SalaryStatusCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader2 = SalaryStatusCommand.ExecuteReader();
            netDaysReader2.Read();
            bool R = netDaysReader2.HasRows;
            netDaysReader2.Close();
            return R;
        }

        public List<String> GetBanksByEmpID(int EmpID)
        {
            SqlCommand SalaryStatusCommand = new SqlCommand();
            List<string> BanksList = new List<string>();
            SalaryStatusCommand.Connection = connection;
            SalaryStatusCommand.CommandText = "select Bank_Name from BankInstallments where AIO_Code = @EmpID ";
            SalaryStatusCommand.Parameters.Add("@EmpID", EmpID);
            SalaryStatusCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader2 = SalaryStatusCommand.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(netDaysReader2);
            netDaysReader2.Close();
            for (int i = 0; i < DT.Rows.Count; i++) BanksList.Add(DT.Rows[i].ItemArray[0].ToString());
            return BanksList;
        }

        public List<String> GetBanksDates(int EmpID, string BankName)
        {
            SqlCommand SalaryStatusCommand = new SqlCommand();
            List<string> DatesList = new List<string>();
            SalaryStatusCommand.Connection = connection;
            SalaryStatusCommand.CommandText =
                "select Start_Payment from BankInstallments where Remain > 0 and AIO_Code = @EmpID and Bank_Name = @BankName";
            SalaryStatusCommand.Parameters.Add("@EmpID", EmpID);
            SalaryStatusCommand.Parameters.Add("@BankName", BankName);
            SalaryStatusCommand.CommandType = CommandType.Text;
            SqlDataReader netDaysReader2 = SalaryStatusCommand.ExecuteReader();
            DataTable DT = new DataTable();
            DT.Load(netDaysReader2);
            for (int i = 0; i < DT.Rows.Count; i++)
                DatesList.Add(DateTime.Parse(DT.Rows[i].ItemArray[0].ToString()).ToShortDateString());
            return DatesList;
        }

        public void getTaxes(int month, int AIOID, ref float NetTaxes, ref float NetTaxAffectedValue)
        {
            SqlCommand taxCommand = new SqlCommand();
            taxCommand.Connection = connection;
            taxCommand.CommandText =
                "select Net_Tax_Affected_Value , Net_Taxes from salary where MONTH(Payment_D) = @month and AIO_Code = @id";
            taxCommand.Parameters.Add("@month", month);
            taxCommand.Parameters.Add("@id", AIOID);
            taxCommand.CommandType = CommandType.Text;
            SqlDataReader taxDataReader = taxCommand.ExecuteReader();
            taxDataReader.Read();
            NetTaxes = float.Parse(taxDataReader["Net_Taxes"].ToString());
            NetTaxAffectedValue = float.Parse(taxDataReader["Net_Tax_Affected_Value"].ToString());

        }

        public float GetNetDaysDB(int AIOID, int month, int year)
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText =
                "select Working_Days from Salary where MONTH(Payment_D) = @month and YEAR(Payment_D) = @year and AIO_Code = @id";
            salaryCommand.Parameters.Add("@month", month);
            salaryCommand.Parameters.Add("@year", year);
            salaryCommand.Parameters.Add("@id", AIOID);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
            salaryDataReader.Read();
            float NetDays;
            if (salaryDataReader.HasRows)
                NetDays = float.Parse(salaryDataReader["Working_Days"].ToString());
            else NetDays = -1;

            salaryDataReader.Close();
            return NetDays;
        }

        public void DeleteSalary(int AIOID, int month, int year)
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText =
                "delete from Salary where MONTH(Payment_D) = @month and YEAR(Payment_D) = @year and AIO_Code = @id";
            salaryCommand.Parameters.Add("@month", month);
            salaryCommand.Parameters.Add("@year", year);
            salaryCommand.Parameters.Add("@id", AIOID);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
            salaryDataReader.Close();
        }

        void SetNetDays_30()
        {
            SqlCommand employeesCommand = new SqlCommand();
            employeesCommand.Connection = connection;
            employeesCommand.CommandText = "update Salary Set Working_Days = 30 where Working_Days = 31";
            employeesCommand.CommandType = CommandType.Text;
            SqlDataReader X = employeesCommand.ExecuteReader();
            X.Close();
        }

        public bool CheckSalaryExist(DateTime D, int AIOID)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "Select * from Salary where AIO_Code = @ID and Month(Payment_D) = @M and Year(Payment_D) = @Y";
            employeeCommand.Parameters.Add("@ID", AIOID);
            employeeCommand.Parameters.Add("@M", D.Month);
            employeeCommand.Parameters.Add("@Y", D.Year);
            SqlDataReader EmpReader = employeeCommand.ExecuteReader();
            bool R = EmpReader.HasRows;
            EmpReader.Close();
            return R;
        }

        public void SetInsuranceSystem()
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "Update Salary Set I_Type = false where YEAR(Payment_D) = "+DateTime.Now.Year;
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();
            SystemControl._Insurance.AnnualReset();
            updateInsuranceData(DateTime.Now);
        }

        public void UpdateEmployee(int AIOID)
    {
        int Index = SystemControl.employees.FindIndex(Y => Y.AIOID == AIOID);
        Employee emp = SystemControl.employees[Index];
        SqlCommand employeeCommand = new SqlCommand();
        employeeCommand.Connection = connection;
        //  update salary set Working Days = :netDays where payment date.month = month and AIO_Code = :AIOID
        employeeCommand.CommandText = "update employee set Full_Name = @FN, Date_of_Birth =@DOB,Hiring_D =@hd, Termination_D =@TD, Contract_Type = @CT ," +
            " Working_Type = @WT , E_Degree = @ED , Depart_ID = @Depart_ID , N_ID = @N_ID , E_Type = @Type where AIO_Code = @id";
        employeeCommand.Parameters.Add("@FN", emp.FullName);
        employeeCommand.Parameters.Add("@DOB", emp.DateOfBirth);
        employeeCommand.Parameters.Add("@hd", emp.HiringDate);
        employeeCommand.Parameters.Add("@TD", emp.TerminationDate);
        employeeCommand.Parameters.Add("@ED", emp.CurrentDegree);
        employeeCommand.Parameters.Add("@Depart_ID", emp.Dept_ID);
        employeeCommand.Parameters.Add("@N_ID", emp.National_ID);

        if (emp.CType == ContractType.Temporary)
            employeeCommand.Parameters.Add("@CT", "Temporary");
        else if (emp.CType == ContractType.Permenant)
            employeeCommand.Parameters.Add("@CT", "Permenant");
        if (emp.WType == WorkingType.InDirect)
            employeeCommand.Parameters.Add("@WT", "InDirect");
        else if (emp.WType == WorkingType.Direct)
            employeeCommand.Parameters.Add("@WT", "Direct");

        if (emp.EType == EmploymentType.EmployeeType) employeeCommand.Parameters.Add("@Type", EmploymentType.EmployeeType);
        else if (emp.EType == EmploymentType.PensionType) employeeCommand.Parameters.Add("@Type", EmploymentType.PensionType);
        else employeeCommand.Parameters.Add("@Type", EmploymentType.Awarded);

        employeeCommand.Parameters.Add("@id", AIOID);
        employeeCommand.CommandType = CommandType.Text;
        SqlDataReader EmpReader = employeeCommand.ExecuteReader();
        EmpReader.Close();


        SqlCommand salaryCommand = new SqlCommand();
        salaryCommand.Connection = connection;
        salaryCommand.CommandText = "update salary set CooperativeBoxValue = @COP , CooperativeBoxValue_2 = @COP2 , Main_Salary =@main,Work_Environment_Alternative =@WEA,Representing_Alternative=@RA,Social_Raises=@SR,Others=@O," +
            "Net_Salary =@NetSalary,Taxes_Apply =@TA, Insurances_Apply =@IA,Static_Company_Insurance =@SCI,Dynamic_Company_Insurance =@DCI, Static_Employee_Insurance =@SEI,Dynamic_Employee_Insurance =@DEI,Net_Tax_Affected_Value =@NTAV,Social_Raises_Release=@SRR,Social_Raises_Release_Adj=@SRR*(Working_Days/30)" +
            ", Total_Tax_Affected_Value =@TTAV, Net_Taxes =@NT ,Total1 = @T1 ,Total1_Adj = @T1A, Total2 = @T2 , Total3 = @T3,StaticContainer = @SC,DynamicContainer=@DC,Workers_Day=@WDS,Workers_Day_Adj=@WDSA " +
            " , I_Type = @IType where AIO_Code =@id and Payment_D >= @D";

        if (emp.IType == InsuranceType.Current) salaryCommand.Parameters.Add("@IType", InsuranceType.Current);
        else salaryCommand.Parameters.Add("@IType", InsuranceType.New);

        salaryCommand.Parameters.Add("@main", emp.MainSalary);
        salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
        salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
        salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
        salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
        salaryCommand.Parameters.Add("@O", emp.Other);
        salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
        salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
        salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
        salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
        salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
        salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
        salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
        salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
        salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
        salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
        salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
        salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@id", emp.AIOID);
        //salaryCommand.Parameters.Add("@Month", DateTime.Now.Month);
        salaryCommand.Parameters.Add("@D", Program.OneNow);
        salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
        salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
            salaryCommand.Parameters.Add("@T2", emp.Total2);
        salaryCommand.Parameters.Add("@T3", emp.Total3);
        salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
        salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
        salaryCommand.Parameters.Add("WDS", emp.WorkersDay);
        salaryCommand.Parameters.Add("WDSA", emp.WorkersDayAdj);
        salaryCommand.CommandType = CommandType.Text;
        SqlDataReader SalaryReader = salaryCommand.ExecuteReader();
        SalaryReader.Close();
    }
        public void getProfitData(int Year)
        {
            SqlCommand profitCommand = new SqlCommand();
            int EMPID;
            profitCommand.Connection = connection;
            profitCommand.CommandText = "select * from profit where Profit_Year = @year and AIO_Code_2 is NULL";
            profitCommand.Parameters.Add("@year", Year);
            profitCommand.CommandType = CommandType.Text;
            SqlDataReader profitDataReader = profitCommand.ExecuteReader();
            Profit.DictTotal_4.Clear();
            while (profitDataReader.Read())
            {
                EMPID = int.Parse(profitDataReader["AIO_Code"].ToString());
                Profit.DictTotal_4.Add(EMPID, float.Parse(profitDataReader["Total_Value"].ToString()));
                int EmpIndex = SystemControl.employees.FindIndex(j => j.AIOID == EMPID);
                SystemControl.employees[EmpIndex].ProfitVarsObject.SpecialPenalty = float.Parse(profitDataReader["SpecialPenalty"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.SpecialBonuse = float.Parse(profitDataReader["SpecialBonuse"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.Penalties = float.Parse(profitDataReader["Penalty"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.LateMinutes = float.Parse(profitDataReader["LateMinutes"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.Investigations = float.Parse(profitDataReader["Investiagation"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.NewSickness = float.Parse(profitDataReader["Sickness"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.FakeSickness = float.Parse(profitDataReader["FakeSickness"].ToString());
                SystemControl.employees[EmpIndex].ProfitVarsObject.UnexcusedAbsence = float.Parse(profitDataReader["Absence"].ToString());
            }
            profitDataReader.Close();

            profitCommand.CommandText = "select * from profit where Profit_Year = @year and AIO_Code is NULL";
            profitDataReader = profitCommand.ExecuteReader();
            while (profitDataReader.Read())
            {
                EMPID = int.Parse(profitDataReader["AIO_Code_2"].ToString());
                DictTotal_4.Add(EMPID, float.Parse(profitDataReader["Total_Value"].ToString()));
                int EmpIndex = SystemControl.ProfitEmplList.FindIndex(j => j.AIOID == EMPID);
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.SpecialPenalty = float.Parse(profitDataReader["SpecialPenalty"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.SpecialBonuse = float.Parse(profitDataReader["SpecialBonuse"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.Penalties = float.Parse(profitDataReader["Penalty"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.LateMinutes = float.Parse(profitDataReader["LateMinutes"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.Investigations = float.Parse(profitDataReader["Investiagation"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.NewSickness = float.Parse(profitDataReader["Sickness"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.FakeSickness = float.Parse(profitDataReader["FakeSickness"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.UnexcusedAbsence = float.Parse(profitDataReader["Absence"].ToString());
                SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.NetProfit =
                    float.Parse(profitDataReader["Total_Value"].ToString());
            }










        }

        #region Profit Employee
            public void ProfitEmployeeMainData(ProfitEmp Emp,bool IsNew)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                if (IsNew) annualCommand.CommandText = "insert into ProfitEmps (AIO_Code,Name,Total1,Year_,Net_Days,N_ID) values (@ID,@Name,@T1,@Year,@ND,@NID)";
                else annualCommand.CommandText = "update ProfitEmps set Name = @Name , Total1 = @T1 , Net_Days = @ND , N_ID = @NID where AIO_Code = @ID and Year_ = @Year";
                annualCommand.Parameters.Add("@Name", Emp.Name);
                annualCommand.Parameters.Add("@T1", Emp.Total_1);
                annualCommand.Parameters.Add("@Year", Emp.ProfitYear);
                annualCommand.Parameters.Add("@ID", Emp.AIOID);
                annualCommand.Parameters.Add("@ND", Emp.NetDays);
                annualCommand.Parameters.Add("@NID", Emp.N_I);
                annualCommand.CommandType = CommandType.Text;
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                annualDataReader.Close();
            }
            public void GetEmployeeProfitData(int Year, ref List<ProfitEmp> EmpList)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandText = "SELECT dbo.Profit.Total_Worked_Days, dbo.Profit.Total_Value, dbo.Profit.LateMinutes, dbo.Profit.Absence, dbo.Profit.Sickness, dbo.Profit.FakeSickness, dbo.Profit.Investiagation, dbo.Profit.SpecialPenalty, "+
                "dbo.Profit.Penalty, dbo.Profit.SpecialBonuse, dbo.ProfitEmps.Name, dbo.ProfitEmps.Total1, dbo.ProfitEmps.AIO_Code"+
                    " FROM dbo.Profit INNER JOIN dbo.ProfitEmps ON dbo.Profit.AIO_Code_2 = dbo.ProfitEmps.AIO_Code WHERE dbo.ProfitEmps.Year_ = @Y";
                annualCommand.Parameters.Add("@Y", Year);
                annualCommand.CommandType = CommandType.Text;
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                EmpList.Clear();
                while (annualDataReader.Read())
                {
                    ProfitEmp E = new ProfitEmp();
                    E.ProfitVarsObject.NetDays = float.Parse(annualDataReader["Total_Worked_Days"].ToString());
                    E.ProfitVarsObject.NetProfit = float.Parse(annualDataReader["Total_Value"].ToString());
                    E.ProfitVarsObject.LateMinutes = float.Parse(annualDataReader["LateMinutes"].ToString());
                    E.ProfitVarsObject.UnexcusedAbsence = float.Parse(annualDataReader["Absence"].ToString());
                    E.ProfitVarsObject.NewSickness = float.Parse(annualDataReader["Sickness"].ToString());
                    E.ProfitVarsObject.FakeSickness = float.Parse(annualDataReader["FakeSickness"].ToString());
                    E.ProfitVarsObject.Investigations = float.Parse(annualDataReader["Investiagation"].ToString());
                    E.ProfitVarsObject.SpecialPenalty = float.Parse(annualDataReader["SpecialPenalty"].ToString());
                    E.ProfitVarsObject.Penalties = float.Parse(annualDataReader["Penalty"].ToString());
                    E.ProfitVarsObject.SpecialBonuse = float.Parse(annualDataReader["SpecialBonuse"].ToString());
                    E.Name = annualDataReader["Name"].ToString();
                    E.Total_1 = float.Parse(annualDataReader["Total1"].ToString());
                    E.AIOID = int.Parse(annualDataReader["AIO_Code"].ToString());
                    EmpList.Add(E);
                }
                annualDataReader.Close();
            }
            public void GetEmployeeProfitData2(int Year, ref List<ProfitEmp> EmpList)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandType = CommandType.Text;
            foreach (ProfitEmp Emp in SystemControl.ProfitEmplList)
            {
                annualCommand.CommandText =
                    "SELECT dbo.Profit.Total_Worked_Days, dbo.Profit.Total_Value, dbo.Profit.LateMinutes, dbo.Profit.Absence, dbo.Profit.Sickness, dbo.Profit.FakeSickness, dbo.Profit.Investiagation, dbo.Profit.SpecialPenalty, " +
                    "dbo.Profit.Penalty, dbo.Profit.SpecialBonuse, dbo.ProfitEmps.Name, dbo.ProfitEmps.Total1, dbo.ProfitEmps.AIO_Code" +
                    " FROM dbo.Profit INNER JOIN dbo.ProfitEmps ON dbo.Profit.AIO_Code_2 = dbo.ProfitEmps.AIO_Code WHERE dbo.ProfitEmps.Year_ = @Y and dbo.Profit.AIO_Code_2 = @ID";
                annualCommand.Parameters.Clear();
                annualCommand.Parameters.Add("@Y", Year);
                annualCommand.Parameters.Add("@ID", Emp.AIOID);
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                while (annualDataReader.Read())
                {
                    Emp.ProfitVarsObject.NetDays = float.Parse(annualDataReader["Total_Worked_Days"].ToString());
                    Emp.ProfitVarsObject.NetProfit = float.Parse(annualDataReader["Total_Value"].ToString());
                    Emp.ProfitVarsObject.LateMinutes = float.Parse(annualDataReader["LateMinutes"].ToString());
                    Emp.ProfitVarsObject.UnexcusedAbsence = float.Parse(annualDataReader["Absence"].ToString());
                    Emp.ProfitVarsObject.NewSickness = float.Parse(annualDataReader["Sickness"].ToString());
                    Emp.ProfitVarsObject.FakeSickness = float.Parse(annualDataReader["FakeSickness"].ToString());
                    Emp.ProfitVarsObject.Investigations = float.Parse(annualDataReader["Investiagation"].ToString());
                    Emp.ProfitVarsObject.SpecialPenalty = float.Parse(annualDataReader["SpecialPenalty"].ToString());
                    Emp.ProfitVarsObject.Penalties = float.Parse(annualDataReader["Penalty"].ToString());
                    Emp.ProfitVarsObject.SpecialBonuse = float.Parse(annualDataReader["SpecialBonuse"].ToString());
                }
                annualDataReader.Close();
            }
        }
            public void UpdateEmployeeProfitData(int Year, int EmpIndex)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandType = CommandType.Text;
              
                    annualCommand.CommandText = "update Profit set Total_Worked_Days = @NetDays , Total_Value = @NetProfit , LateMinutes = @LM , Absence = @Abs , Sickness = @Sick , FakeSickness = @FakeSick " +
                                                ", Investiagation = @Inv , SpecialPenalty = @SP , Penalty = @P , SpecialBonuse = @SB WHERE AIO_Code_2 = @ID and Profit_Year = @Y";
                    annualCommand.Parameters.Clear();
                    annualCommand.Parameters.Add("@Y", Year);
                    annualCommand.Parameters.Add("@ID", SystemControl.ProfitEmplList[EmpIndex].AIOID);
                    annualCommand.Parameters.Add("@NetDays", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.NetDays);
                    annualCommand.Parameters.Add("@NetProfit", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.NetProfit);
                    annualCommand.Parameters.Add("@LM", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.LateMinutes);
                    annualCommand.Parameters.Add("@Abs", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.UnexcusedAbsence);
                    annualCommand.Parameters.Add("@Sick", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.NewSickness);
                    annualCommand.Parameters.Add("@FakeSick", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.FakeSickness);
                    annualCommand.Parameters.Add("@Inv", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.Investigations);
                    annualCommand.Parameters.Add("@SP", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.SpecialPenalty);
                    annualCommand.Parameters.Add("@P", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.Penalties);
                    annualCommand.Parameters.Add("@SB", SystemControl.ProfitEmplList[EmpIndex].ProfitVarsObject.SpecialBonuse);
                    SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                    annualDataReader.Close();
                
            }
            public void InitializeEmployeeProfitData(int Year, ref List<ProfitEmp> EmpList)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandType = CommandType.Text;
                foreach (ProfitEmp Emp in EmpList)
                {
                    annualCommand.CommandText =
                        "insert into Profit (Total_Worked_Days,Total_Value,LateMinutes,Absence,Sickness,FakeSickness,Investiagation,SpecialPenalty,Penalty,SpecialBonuse,AIO_Code_2,Profit_Year) " +
                        " Values (0,0,0,0,0,0,0,0,0,0,@ID,@Y)  ";
                    annualCommand.Parameters.Clear();
                    annualCommand.Parameters.Add("@Y", Year);
                    annualCommand.Parameters.Add("@ID", Emp.AIOID);
                    SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                    annualDataReader.Close();
                }
            }

        public void InitializeEmployeeProfitDataSingle(int Year, ProfitEmp Emp)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandType = CommandType.Text;
                annualCommand.CommandText =
                    "insert into Profit (Total_Worked_Days,Total_Value,LateMinutes,Absence,Sickness,FakeSickness,Investiagation,SpecialPenalty,Penalty,SpecialBonuse,AIO_Code_2,Profit_Year) " +
                    " Values (0,0,0,0,0,0,0,0,0,0,@ID,@Y)  ";
                annualCommand.Parameters.Clear();
                annualCommand.Parameters.Add("@Y", Year);
                annualCommand.Parameters.Add("@ID", Emp.AIOID);
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                annualDataReader.Close();
        }

        public bool CheckEmployeeProft(int Year,int AIOID)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandText = "select * from Profit where AIO_Code_2=@id and Profit_Year =@Y";
                annualCommand.Parameters.Add("@id", AIOID);
                annualCommand.Parameters.Add("@Y", Year);
                annualCommand.CommandType = CommandType.Text;
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                bool Exist = annualDataReader.HasRows;
                annualDataReader.Close();
                return Exist;
            }

        public int GetCountProftEmployee(int Year)
        {
            DataTable DT = new DataTable();
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select count(AIO_Code_2) from Profit where Profit_Year = @Y";
            annualCommand.Parameters.Add("@Y", Year);
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DT.Load(annualDataReader);
            return DT.Rows.Count;
        }

        public void DeleteProfiEmployee(int Year, int AIOID)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandText = "Delete from Profit where AIO_Code_2=@id and Profit_Year =@Y";
            
                annualCommand.Parameters.Add("@id", AIOID);
                annualCommand.Parameters.Add("@Y", Year);
                annualCommand.CommandType = CommandType.Text;
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                annualDataReader.Close();

                annualCommand.CommandText = "Delete from ProfitEmps where AIO_Code=@id and Year_ =@Y";
                annualDataReader = annualCommand.ExecuteReader();
                annualDataReader.Close();
        }

            public void SetMainData(int Year)
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandText = "select * from ProfitEmps where Year_ = @Y";
                annualCommand.Parameters.Add("@Y", Year);
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                while (annualDataReader.Read())
                {
                    ProfitEmp E = new ProfitEmp();
                    E.AIOID = int.Parse(annualDataReader["AIO_Code"].ToString());
                    E.Name = annualDataReader["Name"].ToString();
                    E.Total_1 = float.Parse(annualDataReader["Total1"].ToString());
                    E.ProfitYear = int.Parse(annualDataReader["Year_"].ToString());
                    E.NetDays = int.Parse(annualDataReader["Net_Days"].ToString());
                    E.N_I = annualDataReader["N_ID"].ToString();
                SystemControl.ProfitEmplList.Add(E);
                }
                annualDataReader.Close();
            }
        #endregion

        public List<DateTime> GetListOfInstallments(int AIOID, InstallmentsTypes T)
        {
            List<DateTime> InstalmmentsList = new List<DateTime>();
            SqlCommand HireCommand = new SqlCommand();
            HireCommand.Connection = connection;
            HireCommand.CommandText = "select Start_Payment from Installments where AIO_Code = @ID and Identity_Number = @Identity and Remain > 0 ";
            HireCommand.Parameters.Add("@ID", AIOID);
            HireCommand.Parameters.Add("@Identity", T);
            HireCommand.CommandType = CommandType.Text;
            SqlDataReader profitDataReader = HireCommand.ExecuteReader();
            while (profitDataReader.Read())
                InstalmmentsList.Add((DateTime)profitDataReader["Start_Payment"]);
            profitDataReader.Close();
            return InstalmmentsList;
        }
        // Get Installment Data
        public Installments GetInstallmentsData(int AIO_Code, InstallmentsTypes T, DateTime StartPayment)
        {
            Installments I = new Installments();
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select * from Installments where AIO_Code=@id and Identity_Number =@InstallmentsT and Start_Payment =  @StartDate";
            annualCommand.Parameters.Add("@id", AIO_Code);
            annualCommand.Parameters.Add("@InstallmentsT", T);
            annualCommand.Parameters.Add("@StartDate", StartPayment);

            annualCommand.CommandType = CommandType.Text;
            ReConnectDB(); // Bug
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Read();

            I.Start = annualDataReader["Start_Payment"].ToString();
            I.Total = decimal.Parse(annualDataReader["Totall_Value"].ToString());
            I.MonthlyValue = decimal.Parse(annualDataReader["Monthly_Value"].ToString());
            I.Remain = decimal.Parse(annualDataReader["Remain"].ToString());

            return I;
        }
        // Get Bank Installment Data
        public float GetBankInstallmentsData(int AIO_Code)
        {
            DataTable I = new DataTable();
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select Sum(Monthly_value) from BankInstallments where AIO_Code=@id";
            annualCommand.Parameters.Add("@id", AIO_Code);
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();

            if (annualDataReader.HasRows)
            {
                I.Load(annualDataReader);
                try
                {
                    return float.Parse(I.Rows[0].ItemArray[0].ToString());
                }
                catch
                {
                    return 0;
                }
            }
            else return 0;
        }
        // Annual Increase // degree // Annual Increase percentage
        public void UpdateInstallment(int AIO_Code, DateTime Start, decimal Remain, decimal MonthlyValue, int Identity)
        {

            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            SqlDataReader annualDataReader4;
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Add("@D", DateTime.Now);
            annualCommand.Parameters.Add("@M", DateTime.Now.Month);
            annualCommand.Parameters.Add("@Y", DateTime.Now.Year);
            annualCommand.Parameters.Add("@MV", MonthlyValue);
            annualCommand.Parameters.Add("@Identity", Identity);
            annualCommand.Parameters.Add("@ID", AIO_Code);
            annualCommand.Parameters.Add("@Start", Start.ToShortDateString());
            annualCommand.Parameters.Add("@R", Remain);

            // check if this inslamment taken from current salary 
            if (Check_Installments_Status())
            {
                 annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandType = CommandType.Text;
               
                annualCommand.CommandText = "Update Installments set Monthly_Value = Monthly_Value + @MV where Identity_Number = @Identity and Start_Payment = @Start and AIO_Code = @ID";
                annualDataReader4 = annualCommand.ExecuteReader();
                annualDataReader4.Close();

                annualCommand.CommandText = "delete from Installment_Status where Month(Last_Update_Date) = @M and Year(Last_Update_Date) = @Y";
                annualDataReader4 = annualCommand.ExecuteReader();
                annualDataReader4.Close();
            }

            annualCommand.CommandText = "Update Installments set Remain = @R,Monthly_Value = @MV where AIO_Code = @ID and Start_Payment = @Start and Identity_Number = @Identity";
            annualDataReader4 = annualCommand.ExecuteReader();
            annualDataReader4.Close();
        }
        public float GetInstallmentValue_2(int AIO_Code, int Type)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "Select Monthly_Value From Installments where AIO_Code = @ID and Identity_Number = @Identity and Monthly_Value > 0 and" +
                " Start_Payment <= @D";
            annualCommand.Parameters.Add("@ID", AIO_Code);
            annualCommand.Parameters.Add("@Identity", Type);
            annualCommand.Parameters.Add("@D", DateTime.Now);
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            //annualDataReader.Read();
            DataTable DT = new DataTable();
            DT.Load(annualDataReader);
            annualDataReader.Close();
            if (DT.Rows.Count == 0) return 0;
            else return float.Parse(DT.Rows[0].ItemArray[0].ToString());
        }
        public void UpdateInstallments()
        {
            if (Check_Installments_Status())
            {
                SqlCommand annualCommand = new SqlCommand();
                annualCommand.Connection = connection;
                annualCommand.CommandType = CommandType.Text;
                annualCommand.Parameters.Add("@D", DateTime.Now);

                annualCommand.CommandText = "Update Installments set Monthly_Value = 0 , End_Payment = @D where Remain = 0 and Start_Payment < @D";
                SqlDataReader annualDataReader4 = annualCommand.ExecuteReader();
                annualDataReader4.Close();

                annualCommand.CommandText = "Update Installments set Remain = 0 ,Monthly_Value = Remain where Monthly_Value >= Remain and Start_Payment < @D";
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                annualDataReader.Close();

                annualCommand.CommandText = "Update Installments set Remain = Remain - Monthly_Value where Monthly_Value < Remain and Start_Payment < @D";
                SqlDataReader annualDataReader2 = annualCommand.ExecuteReader();
                annualDataReader2.Close();

                annualCommand.CommandText = "insert into Installment_Status(Last_Update_Date) values (@D) ";
                SqlDataReader annualDataReader3 = annualCommand.ExecuteReader();
                annualDataReader3.Close();
            }
        }
        public bool Check_Installments_Status()
        {
            ReConnectDB();
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "Select * From Installment_Status where Month(Last_Update_Date) = @M and Year(Last_Update_Date) = @Y";
            annualCommand.Parameters.Add("@M", DateTime.Now.Month);
            annualCommand.Parameters.Add("@Y", DateTime.Now.Year);
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            //annualDataReader.Read();
            DataTable DT = new DataTable();
            DT.Load(annualDataReader);
            if (DT.Rows.Count == 0) return true;
            else return false;
        }
        public void UpdateEmployeeInstallmentwithSalary(int AIO_Code)
        {
            SqlCommand annualCommand = new SqlCommand();
            DataTable DT = new DataTable();
            annualCommand.Connection = connection;
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader;
            ReConnectDB();

            // To loop all kinds of Installments Except Bank Installment
            for (int i = 0; i < 9; i++)
            {
                annualCommand.Parameters.Clear();
                DT = new DataTable();
                annualCommand.CommandText = "Select Remain,Monthly_Value,Installment_ID From Installments where AIO_Code = @ID and Identity_Number = @Identity and Remain > 0";
                annualCommand.Parameters.Add("@ID", AIO_Code);
                annualCommand.Parameters.Add("@Identity", i);
                annualDataReader = annualCommand.ExecuteReader();

                DT.Load(annualDataReader);
                annualDataReader.Close();

                // To modify all installments values from selected
                for (int j = 0; j < DT.Rows.Count; j++)
                {
                    annualCommand.Parameters.Clear();

                    decimal Remain = decimal.Parse(DT.Rows[j].ItemArray[0].ToString()) - decimal.Parse(DT.Rows[j].ItemArray[1].ToString());
                    DT.Rows[j].SetField(0, Remain);

                    decimal MV = 0;
                    if (decimal.Parse(DT.Rows[j].ItemArray[0].ToString()) >= decimal.Parse(DT.Rows[j].ItemArray[1].ToString()))
                        MV = decimal.Parse(DT.Rows[j].ItemArray[1].ToString());
                    else
                        MV = decimal.Parse(DT.Rows[j].ItemArray[0].ToString());

                    annualCommand.CommandText = "update Installments set Remain  = @Remain , Monthly_Value = @MV where Installment_ID = @ID";
                    annualCommand.Parameters.Add("@ID", DT.Rows[j].ItemArray[2].ToString());
                    annualCommand.Parameters.Add("@Remain", DT.Rows[j].ItemArray[0].ToString());
                    annualCommand.Parameters.Add("@MV", MV);
                    annualDataReader = annualCommand.ExecuteReader();
                    annualDataReader.Read();
                    annualDataReader.Close();
                }
            }
        }
        #region Salaries
        List<Employee> GetEmpDateSalary(int year, int month)
        {
            List<Employee> TempEmpList = new List<Employee>();
            List<string> TempIDList = new List<string>();
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            // DateTime DT = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            DateTime DT = new DateTime(year, month, 1);
            DateTime LastDTinYaer = new DateTime(year, 12, DateTime.DaysInMonth(year, 12));
            annualCommand.CommandText = "select AIO_Code from Employee where @DT <= Termination_D ";
            annualCommand.Parameters.Add("@DT", DT);
            annualCommand.Parameters.Add("@LDT", LastDTinYaer);

            annualCommand.CommandType = CommandType.Text;
            ReConnectDB(); // Connection Bug
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DataTable DTable = new DataTable();
            DTable.Load(annualDataReader);
            for (int i = 0; i < DTable.Rows.Count; i++)
                TempIDList.Add(DTable.Rows[i].ItemArray[0].ToString());

            foreach (string ID in TempIDList)
                TempEmpList.Add(GetEmpDate(int.Parse(ID), 12, year - 1));

            // Calculate Working Days
            foreach (Employee E in TempEmpList)
            {
                if (year == E.TerminationDate.Year && month == E.TerminationDate.Month)
                    E.WorkingDays = E.TerminationDate.Day;
                else if (year == E.HiringDate.Year && month == E.HiringDate.Month)
                    E.WorkingDays = (30 - E.HiringDate.Day) + 1;
                else E.WorkingDays = 30;
            }

            return TempEmpList;
        }
        List<int> GetListOfEmpInMonth(int Month, int Year)
        {
            SqlCommand annualCommand = new SqlCommand();
            List<int> EmpIDs = new List<int>();
            DataTable DT = new DataTable();

            annualCommand.Connection = connection;
            annualCommand.CommandText = "select distinct AIO_Code from Salary where Year(Payment_D) = " + Year.ToString() + " and Month(Payment_D) = " + Month.ToString();
            annualCommand.CommandType = CommandType.Text;
            ReConnectDB();
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DT.Load(annualDataReader);
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                int EmpID = int.Parse(DT.Rows[i].ItemArray[0].ToString());
                if (SystemControl.employees[SystemControl.employees.FindIndex( T => T.AIOID == EmpID)].EType != EmploymentType.Awarded)
                EmpIDs.Add(EmpID);
            }
            
            return EmpIDs;
        }
        public void GetSalaryMainData(DateTime DT)
        {
            int year = DT.Year, month = DT.Month;

            SystemControl.SalaryEmployeesList.Clear();
            SystemControl.SalaryEmployeesList_Specials.Clear();
            List<int> EmpIDs = new List<int>();
            Employee E = new Employee();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            EmpIDs = GetListOfEmpInMonth(month, year);
            foreach (int Id in EmpIDs)
            {
                // Get Salary Data
                int EmpIndex = SystemControl.employees.FindIndex(j => j.AIOID == Id);
                E = SystemControl.employees[EmpIndex];   // To get main Data (Name ,....)
                salaryCommand.CommandText = "select * from salary where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID ";
                salaryCommand.Parameters.Clear();
                salaryCommand.Parameters.Add("@Month", month);
                salaryCommand.Parameters.Add("@Year", year);
                salaryCommand.Parameters.Add("@ID", Id);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
                while (salaryDataReader.Read())
                {
                    E.MainSalary = float.Parse(salaryDataReader["Main_Salary"].ToString());
                    E.WorkEnvironmentAlt = float.Parse(salaryDataReader["Work_Environment_Alternative"].ToString());
                    E.RepresentingAlt = float.Parse(salaryDataReader["Representing_Alternative"].ToString());
                    E.SocialRaises = float.Parse(salaryDataReader["Social_Raises"].ToString());
                    E.SocialRaisesRelease = float.Parse(salaryDataReader["Social_Raises_Release"].ToString());
                    E.SocialRaisesReleaseAdj = float.Parse(salaryDataReader["Social_Raises_Release_Adj"].ToString());
                    E.CooperativeBoxValue = float.Parse(salaryDataReader["CooperativeBoxValue"].ToString());
                    E.CooperativeBoxValue_2 = float.Parse(salaryDataReader["CooperativeBoxValue_2"].ToString());
                    E.NetTaxes = float.Parse(salaryDataReader["Net_Taxes"].ToString());
                    E.WorkingDays = float.Parse(salaryDataReader["Working_Days"].ToString());
                    E.NetSalary = float.Parse(salaryDataReader["Net_Salary"].ToString());
                    E.StaticCompanyInsurance = float.Parse(salaryDataReader["Static_Company_Insurance"].ToString());
                    E.DynamicCompanyInsurance = float.Parse(salaryDataReader["Dynamic_Company_Insurance"].ToString());
                    E.StaticEmployeeInsurance = float.Parse(salaryDataReader["Static_Employee_Insurance"].ToString());
                    E.DynamicEmployeeInsurance = float.Parse(salaryDataReader["Dynamic_Employee_Insurance"].ToString());
                    E.NetTaxAffectedValues = float.Parse(salaryDataReader["Net_Tax_Affected_Value"].ToString());
                    E.TotalTaxAffectedValues = float.Parse(salaryDataReader["Total_Tax_Affected_Value"].ToString());
                    E.Other = float.Parse(salaryDataReader["ADiff"].ToString());
                    E.WorkingDays = float.Parse(salaryDataReader["Working_Days"].ToString());
                    E.Total1 = float.Parse(salaryDataReader["Total1"].ToString());
                    E.Adj_Total1 = float.Parse(salaryDataReader["Total1_Adj"].ToString());
                    E.Total2 = float.Parse(salaryDataReader["Total2"].ToString());
                    E.Total3 = float.Parse(salaryDataReader["Total3"].ToString());
                    E.StaticContainer = float.Parse(salaryDataReader["StaticContainer"].ToString());
                    E.DynamicContainer = float.Parse(salaryDataReader["DynamicContainer"].ToString());
                    E.WorkersDay = float.Parse(salaryDataReader["Workers_Day"].ToString());
                    E.WorkersDayAdj = float.Parse(salaryDataReader["Workers_Day_Adj"].ToString());
                    E.Other = float.Parse(salaryDataReader["Others"].ToString());
                    bool T = Boolean.Parse(salaryDataReader["I_Type"].ToString());
                    E.IType = T ? InsuranceType.Current : InsuranceType.New;
                    E.TaxesApply = Boolean.Parse(salaryDataReader["Taxes_Apply"].ToString());
                    E.InsuranceApply = Boolean.Parse(salaryDataReader["Insurances_Apply"].ToString());
                }
                salaryDataReader.Close();

                // Get Giveaways data if exist
                salaryCommand.CommandText = "select * from G_With_Salary where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID";
                salaryDataReader = salaryCommand.ExecuteReader();
                if (salaryDataReader.HasRows)
                    while (salaryDataReader.Read())
                        E.Giveaways = float.Parse(salaryDataReader["G_Value"].ToString());

                DateTime DX = DT;
                DX = DX.AddMonths(-1);
                int PrevMonth = DX.Month;
                salaryDataReader.Close();

                // Get Minsuses Data
                salaryCommand.Parameters.Clear();
                salaryCommand.CommandText = "select * from Minuses where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID ";
                salaryCommand.Parameters.Add("@Month", PrevMonth);
                salaryCommand.Parameters.Add("@Year", year);
                salaryCommand.Parameters.Add("@ID", Id);
                salaryCommand.CommandType = CommandType.Text;

                SqlDataReader salaryDataReader2 = salaryCommand.ExecuteReader();
                while (salaryDataReader2.Read())
                {
                    E.SicknessDays = float.Parse(salaryDataReader2["Sickness_Days"].ToString());
                    E.AbsenceDays = float.Parse(salaryDataReader2["Abscence_Days"].ToString());
                    E.Penalty = float.Parse(salaryDataReader2["Penalty_Days"].ToString());
                    E.Installments = float.Parse(salaryDataReader2["Installments"].ToString());
                }
                salaryDataReader2.Close();
                // Get Bonuses Data
                salaryCommand.Parameters.Clear();
                salaryCommand.CommandText = "select * from Bonuses where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID ";
                salaryCommand.Parameters.Add("@Month", PrevMonth);
                salaryCommand.Parameters.Add("@Year", year);
                salaryCommand.Parameters.Add("@ID", Id);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader salaryDataReader3 = salaryCommand.ExecuteReader();
                while (salaryDataReader3.Read())
                {
                    E.MorningHrs = float.Parse(salaryDataReader3["Morning_Hours"].ToString());
                    E.MorningHrsValue = float.Parse(salaryDataReader3["Morning_Hours_Bonus_Value"].ToString());
                    E.AfternoonHrs = float.Parse(salaryDataReader3["Afternoon_Hours"].ToString());
                    E.AfternoonHrsValue = float.Parse(salaryDataReader3["Afternoon_Hours_Bonus_Value"].ToString());
                    E.NightHrs = float.Parse(salaryDataReader3["Night_Hours"].ToString());
                    E.NightHrsValue = float.Parse(salaryDataReader3["Night_Hours_Bonus_Value"].ToString());
                    E.OfficialHolidays = float.Parse(salaryDataReader3["Official_Holidays"].ToString());
                    E.OfficialHolidaysValue = float.Parse(salaryDataReader3["Officail_Holidays_Bonus_Value"].ToString());
                    E.ExtraShifts = float.Parse(salaryDataReader3["Extra_Shifts_Days"].ToString());
                    E.ExtraShiftBonus = float.Parse(salaryDataReader3["Extra_Shifts_Bonus_Value"].ToString());
                    E.TotalBonuses = float.Parse(salaryDataReader3["Total_Bonuses"].ToString());
                }
                salaryDataReader3.Close();
                salaryDataReader.Close();

                GetMinusesData(E.AIOID, DT, ref E.OtherMinuses,ref E.TreatmentCost);
                GetInstallsValue(E.AIOID, ref E.AlimonyMonthlyInstallment, ref E.Insurance_Policy_Release, ref E.PreviousPeriodInstallments);

                SystemControl.SalaryEmployeesList.Add(E);
                E = new Employee();
            }
        }
        public void GetPrevTotal(DateTime DT)
        {
            SqlCommand salaryCommand = new SqlCommand();
            DataTable D = new DataTable();
            int ID;
            float Total1, Total2, MainSalary, WD, P, CompInsur;
            salaryCommand.Connection = connection;
            // Get Salary Data
            salaryCommand.CommandText = "select AIO_Code,Total1,Total2,Main_Salary,Working_Days,(Dynamic_Company_Insurance+Static_Company_Insurance) from salary " +
            "where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year ";
            salaryCommand.Parameters.Add("@Year", DT.Year);
            salaryCommand.Parameters.Add("@Month", DT.Month);
            SqlDataReader X = salaryCommand.ExecuteReader();
            D.Load(X);
            for (int i = 0; i < D.Rows.Count; i++)
            {
                ID = int.Parse(D.Rows[i].ItemArray[0].ToString());
                ID = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                if (ID >= 0)
                {
                    Total1 = float.Parse(D.Rows[i].ItemArray[1].ToString());
                    Total2 = float.Parse(D.Rows[i].ItemArray[2].ToString());
                    WD = float.Parse(D.Rows[i].ItemArray[4].ToString());
                    MainSalary = float.Parse(D.Rows[i].ItemArray[3].ToString());
                    CompInsur = float.Parse(D.Rows[i].ItemArray[5].ToString());
                    P = WD / 30;

                    SystemControl.SalaryEmployeesList[ID].Prev_Total1 = Total1; // New in Test
                    SystemControl.SalaryEmployeesList[ID].Prev_Total2 = Total1 + CompInsur;
                    SystemControl.SalaryEmployeesList[ID].PrevMainSalary = MainSalary * P;
                }
            }
        }

        public void UpdateEmpTypeStatus(int AIOCode,EmploymentType E)
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "";
            int Status=0;
            switch (E)
            {
                case EmploymentType.PensionType:Status = 1; break;
                case EmploymentType.EmployeeType: Status = 0; break;
                case EmploymentType.Awarded: Status = 2; break;
            }
            salaryCommand.Parameters.Add("@Code", AIOCode);
            salaryCommand.Parameters.Add("@T", Status);
            SqlDataReader annualDataReader = salaryCommand.ExecuteReader();
            annualDataReader.Close();
        }
        
        public void Salary_Year_Initialize(int Year)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select * from Salary where Year(Payment_D) = @Year";
            annualCommand.Parameters.Add("@Year", Year);
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            if (!annualDataReader.HasRows)
            {
                List<Employee> EmpList = new List<Employee>();
                for (int i = 1; i < 13; i++)
                {
                    EmpList = GetEmpDateSalary(Year, i);
                    foreach (Employee E in EmpList)
                    {
                        // Last Month no Insurance Applied
                        if (E.TerminationDate.Month == i && E.TerminationDate.Year == Year) E.InsuranceApply = false;
                        else E.InsuranceApply = true;

                        //DateTime Min = new DateTime(Year, 7, 1);
                        //DateTime Max = new DateTime(Year, 12, 31);
                        //if (E.HiringDate >= Min && E.HiringDate <= Max) E.ApplyJulyInsurance = true;
                        //else E.ApplyJulyInsurance = false;

                        E.ProcessEmployee();
                        Initalize_Employee_Salary(E, i, Year);
                    }
                }
            }
        }
        void Initalize_Employee_Salary(Employee emp, int month, int year)
        {
            // Insert Employee Data (Salary and Minuse and Bonuses
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "INSERT INTO Salary" +
           " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj" +
           ",Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
           " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,StaticContainer,DynamicContainer,Workers_Day,Workers_Day_Adj," +
           "Others,I_Type,Total1_Adj,CooperativeBoxValue_2)" +
           " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA," +
           "@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV" +
           ",@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@SC,@DC,@WDS,@WDSA,@O,@IType,@T1A,@COP2);";
            string EditableForamt = "";
            DateTime DT = new DateTime(year, month, 1);
            salaryCommand.Parameters.Clear();
            salaryCommand.Parameters.Add("@main", emp.MainSalary);
            salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
            salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
            salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
            salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
            salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
            salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
            salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
            salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
            salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
            salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
            salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
            salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
            salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
            salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
            salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
            EditableForamt = DT.ToShortDateString();
            salaryCommand.Parameters.Add("@id", emp.AIOID);
            salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
            salaryCommand.Parameters.Add("@PY", EditableForamt);
            salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
            salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
            salaryCommand.Parameters.Add("@T2", emp.Total2);
            salaryCommand.Parameters.Add("@T3", emp.Total3);
            salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
            salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
            salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
            salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
            salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
            salaryCommand.Parameters.Add("@O", emp.Other);
            salaryCommand.Parameters.Add("@IType", emp.IType);

            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();
            SetNetDays_30();
        }
        #endregion
        #region AnnualProfit
        // Get number of employees in Year
        public List<int> GetEmployees_Profit(int year)
        {
            SqlCommand annualCommand = new SqlCommand();
            List<int> EmpIDs = new List<int>();
            DataTable DT = new DataTable();

            annualCommand.Connection = connection;
            annualCommand.CommandText = "select distinct AIO_Code from Salary where Year(Payment_D) = " + year.ToString();
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DT.Load(annualDataReader);
            for (int i = 0; i < DT.Rows.Count; i++)
                EmpIDs.Add(int.Parse(DT.Rows[i].ItemArray[0].ToString()));

            return EmpIDs;
        }

        // Get Net Days in Year of employee
        public int GetEmployeesNetDays_Profit(int EmpID, int year)
        {
            SqlCommand annualCommand = new SqlCommand();
            DataTable DT = new DataTable();
            ReConnectDB();  // debug
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select sum(Working_Days) from Salary where Year(Payment_D) = @YearID and AIO_Code = @EMPID";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Add("@YearID", year);
            annualCommand.Parameters.Add("@EMPID", EmpID);
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DT.Load(annualDataReader);
            return int.Parse(DT.Rows[0].ItemArray[0].ToString());
        }

        // Check if Profit Calculations Started before
        public bool CheckProfitStarted_Profit(int year)
        {
            SqlCommand annualCommand = new SqlCommand();
            DataTable DT = new DataTable();

            annualCommand.Connection = connection;
            annualCommand.CommandText = "select * from Profit where Profit_Year = @YearID";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Add("@YearID", year);
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DT.Load(annualDataReader);
            bool X = DT.Rows.Count > 0;
            return X;
        }

        // Set States of Employees
        public void SetProfirStatus_Profit(List<int> EmpIDs, int year)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            foreach (int EmpID in EmpIDs)
            {
                annualCommand.CommandText = "select Data_Updated from Profit where Profit_Year = @YearID and AIO_Code = @ID";
                annualCommand.CommandType = CommandType.Text;
                annualCommand.Parameters.Clear();
                annualCommand.Parameters.Add("@YearID", year);
                annualCommand.Parameters.Add("@ID", EmpID);
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                if (annualDataReader.HasRows)
                {
                    DataTable DT = new DataTable();
                    DT.Load(annualDataReader);

                    // annualDataReader.Read();
                    int EmpIndex = SystemControl.employees.FindIndex(j => j.AIOID == EmpID);
                    SystemControl.employees[EmpIndex].DataUpdated = bool.Parse(DT.Rows[0].ItemArray[0].ToString());
                }
                annualDataReader.Close();
            }
        }

        // Set States of Employees
        public void StartProfitCalculations_Profit(List<int> EmpIDs, int year)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            foreach (int EmpID in EmpIDs)
            {
                annualCommand.CommandText = "insert into Profit (Data_Updated,Profit_Year,AIO_Code,Total_Worked_Days,Total_Value,LateMinutes,Absence,Sickness,FakeSickness,Investiagation," +
                    "SpecialPenalty,Penalty,SpecialBonuse) Values(0, @YearID , @ID,0,0,0,0,0,0,0,0,0,0)";
                annualCommand.CommandType = CommandType.Text;
                annualCommand.Parameters.Clear();
                annualCommand.Parameters.Add("@YearID", year);
                annualCommand.Parameters.Add("@ID", EmpID);
                SqlDataReader annualDataReader = annualCommand.ExecuteReader();
                annualDataReader.Close();
            }
            SetProfirStatus_Profit(EmpIDs, year);
        }

        // Update Profit Status
        public void UpdateProfirStatus_Profit(int EmpID, int year, float TotalValue, float TotalWorkedDays, ProfitVars PV)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;

            annualCommand.CommandText = "Update Profit Set Total_Value = @TValue , Total_Worked_Days = @TotalWorkedDays , Data_Updated = 1 ," +
                "LateMinutes = @LM , Absence = @Abs , Sickness = @Sick , FakeSickness = @FakeSick , Investiagation = @Invest , SpecialPenalty = @SP , " +
                "Penalty = @P , SpecialBonuse = @SB where AIO_Code = @ID and Profit_Year = @YearID";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Clear();
            annualCommand.Parameters.Add("@YearID", year);
            annualCommand.Parameters.Add("@ID", EmpID);
            annualCommand.Parameters.Add("@TValue", TotalValue);
            annualCommand.Parameters.Add("@TotalWorkedDays", TotalWorkedDays);
            annualCommand.Parameters.Add("@SP", PV.SpecialPenalty);
            annualCommand.Parameters.Add("@Sick", PV.NewSickness);
            annualCommand.Parameters.Add("@LM", PV.LateMinutes);
            annualCommand.Parameters.Add("@Abs", PV.UnexcusedAbsence);
            annualCommand.Parameters.Add("@FakeSick", PV.FakeSickness);
            annualCommand.Parameters.Add("@Invest", PV.Investigations);
            annualCommand.Parameters.Add("@SB", PV.SpecialBonuse);
            annualCommand.Parameters.Add("@P", PV.Penalties);

            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();
        }

        public float MaxTotal_1(int Year, int AIOID)
        {
            float Max = 0;

            SqlCommand annualCommand = new SqlCommand();
            DataTable DT = new DataTable();

            annualCommand.Connection = connection;
            annualCommand.CommandText = "select Total1 from salary where Payment_D = (select Max(Payment_D) from Salary where Year(Payment_D) = @YearID ) and AIO_Code = @AIOID";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Add("@YearID", Year);
            annualCommand.Parameters.Add("@AIOID", AIOID);
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DataTable X = new DataTable();
            //annualDataReader.Read();
            X.Load(annualDataReader);
            Max = float.Parse(X.Rows[0].ItemArray[0].ToString());
            return Max;
        }
        #endregion
        #region Co-operative Box
        public void CheckCOPUpdate_COP(int year)
        {
            SqlCommand annualCommand = new SqlCommand();
            DataTable DT = new DataTable();

            annualCommand.Connection = connection;
            annualCommand.CommandText = "select * from COP_Data where COP_Year = @YearID";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Add("@YearID", year);
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            DT.Load(annualDataReader);
            if (DT.Rows.Count == 0)
            {
                COP_Confirm FormObject = new COP_Confirm();
                FormObject.ShowDialog();
            }
        }
        public void InsertNewCOP_COP()
        {
            float Percentage = SystemControl._Taxes.CooperativeBoxPercentage;
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "insert into COP_Data (COP_Year,COP_Percentage) Values(@YearID , @P)";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Clear();
            annualCommand.Parameters.Add("@YearID", DateTime.Now.Year);
            annualCommand.Parameters.Add("@P", Percentage);

            ReConnectDB(); // debug

            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();

            UpdateCOPValue_COP(Percentage, DateTime.Now.Year);
        }
        public void UpdateCOPValue_COP(float Percentage, int Year)
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "Update Salary Set CooperativeBoxValue = CooperativeBoxValue + (CooperativeBoxValue*@New_Value) where Year(Payment_D) = @YearID";
            annualCommand.CommandType = CommandType.Text;
            annualCommand.Parameters.Clear();
            annualCommand.Parameters.Add("@YearID", Year);
            annualCommand.Parameters.Add("@New_Value", Percentage);
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();

            MessageBox.Show("تم زيادة قيمة صندوق التكافل لكل موظف بنسبة " + Percentage.ToString("N") + " لعـــام " + Year.ToString(), " تأكيد التغييرات", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        void UpdateMinuses_Salary(Employee emp, DateTime DT)
        {
            SqlCommand salaryCommand2 = new SqlCommand();
            salaryCommand2.Connection = connection;
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select * from Minuses where Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) = " + (DT.Month).ToString() + " and AIO_Code = " + emp.AIOID;
            annualCommand.CommandType = CommandType.Text;
            ReConnectDB();
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();

            if (annualDataReader.HasRows)
                // Update Minuses
                salaryCommand2.CommandText = "update Minuses set Sickness_Days = @Sickness_Days , Sickness_Minus_Value =@Sickness_Minus_Value,Abscence_Days = @Abscence_Days , Abscence_Minus_Value =@Abscence_Minus_Value,Penalty_Days=@Penalty_Days," +
                "Penalty_Minus_Value =@Penalty_Minus_Value, Total_Minuses =@Total_Minuses , Installments = @Installments" +
                " where AIO_Code =@id and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            else
                // Insert Minuses
                salaryCommand2.CommandText = "insert into Minuses (Sickness_Days,Sickness_Minus_Value,Abscence_Minus_Value , Penalty_Days, Penalty_Minus_Value,Total_Minuses" +
                    ",Payment_D ,AIO_Code,Abscence_Days,Installments) Values ( @Sickness_Days , @Sickness_Minus_Value, @Abscence_Minus_Value,@Penalty_Days, @Penalty_Minus_Value " +
                    ", @Total_Minuses ,@Date,@ID,@Abscence_Days,@Installments)";

            salaryCommand2.Parameters.Add("@Sickness_Days", emp.SicknessDays);
            salaryCommand2.Parameters.Add("@Sickness_Minus_Value", emp.SicknessValue);
            salaryCommand2.Parameters.Add("@Abscence_Days", emp.AbsenceDays);
            salaryCommand2.Parameters.Add("@Abscence_Minus_Value", emp.AbsenceValue);
            salaryCommand2.Parameters.Add("@Penalty_Days", emp.Penalty);
            salaryCommand2.Parameters.Add("@Penalty_Minus_Value", emp.PenaltyValue);
            salaryCommand2.Parameters.Add("@Total_Minuses", emp.TotalMinuses);
            salaryCommand2.Parameters.Add("@Date", DT);
            salaryCommand2.Parameters.Add("@Month", DT.Month);
            salaryCommand2.Parameters.Add("@Year", DT.Year);
            salaryCommand2.Parameters.Add("@ID", emp.AIOID);
            salaryCommand2.Parameters.Add("@Installments", emp.Installments);
            ReConnectDB();
            SqlDataReader annualDataReader2 = salaryCommand2.ExecuteReader();
            annualDataReader.Close();
            annualDataReader2.Close();

            DT = DT.AddMonths(1);
            UpdateMinusesData2(ref emp, DT);
            UpdateInstallsValue(emp.AIOID, ref emp.AlimonyMonthlyInstallment, ref emp.Insurance_Policy_Release, ref emp.PreviousPeriodInstallments);
            ClearMinuses();
        }
        void ClearMinuses()
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "delete from Minuses where Sickness_Days = 0 and Abscence_Days = 0 and Penalty_Days = 0";
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();
        }
        void ClearMinuses2()
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "delete from Minuses2 where OtherMinuses = 0 and Treatment = 0";
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();
        }
        void ClearBonuses()
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "delete from Bonuses where Morning_Hours = 0 and Afternoon_Hours = 0 and Night_Hours = 0 and Official_Holidays = 0 and Extra_Shifts_Days = 0";
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();
        }
        void ClearGiveaway()
        {
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "delete from G_With_Salary where G_Value = 0";
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            annualDataReader.Close();
        }
        public void Update_Giveaway(int EmpID , DateTime G_Date , float G_Value)
        {
            SqlCommand salaryCommand3 = new SqlCommand();
            salaryCommand3.Connection = connection;
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            DateTime X = new DateTime(G_Date.Year, G_Date.Month, DateTime.DaysInMonth(G_Date.Year, G_Date.Month));

            annualCommand.CommandText = "select * from G_With_Salary where Year(Payment_D) = @Year and Month(Payment_D) = @Month and AIO_Code = @ID ";
            annualCommand.Parameters.Add("@Year", G_Date.Year);
            annualCommand.Parameters.Add("@Month", G_Date.Month);
            annualCommand.Parameters.Add("@ID", EmpID);
            annualCommand.CommandType = CommandType.Text;
            SqlDataReader SQ = annualCommand.ExecuteReader();
            if (SQ.HasRows)
                salaryCommand3.CommandText = " Update G_With_Salary set G_Value = @Value where Year(Payment_D) = @Year and Month(Payment_D) = @Month and AIO_Code = @ID";
            else
                salaryCommand3.CommandText = "insert into G_With_Salary (AIO_Code,Payment_D,G_Value) values (@ID,@D,@Value)";

            SQ.Close();
            salaryCommand3.Parameters.Add("@D", X);
            salaryCommand3.Parameters.Add("@Year", G_Date.Year);
            salaryCommand3.Parameters.Add("@Month", G_Date.Month);
            salaryCommand3.Parameters.Add("@Value", G_Value);
            salaryCommand3.Parameters.Add("@ID", EmpID);
            SQ = salaryCommand3.ExecuteReader();
            SQ.Close();
            ClearGiveaway();
        }
        void UpdateBonuses_Salary(Employee emp, DateTime DT)
        {
            SqlCommand salaryCommand3 = new SqlCommand();
            salaryCommand3.Connection = connection;
            SqlCommand annualCommand = new SqlCommand();
            annualCommand.Connection = connection;
            annualCommand.CommandText = "select * from Bonuses where Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString() + " and AIO_Code = " + emp.AIOID;
            annualCommand.CommandType = CommandType.Text;
            ReConnectDB();
            SqlDataReader annualDataReader = annualCommand.ExecuteReader();
            if (annualDataReader.HasRows)
                // Update Bonuses
                salaryCommand3.CommandText = "update Bonuses set Morning_Hours = @Morning_Hours , Afternoon_Hours =@Afternoon_Hours,Night_Hours =@Night_Hours," +
                "Extra_Shifts_Days=@Extra_Shifts_Days,Extra_Shifts_Bonus_Value =@Extra_Shifts_Bonus_Value,Official_Holidays =@Official_Holidays,Total_Bonuses =@Total_Bonuses " +
                ", Morning_Hours_Bonus_Value = @Morning_Hours_Bonus_Value , Afternoon_Hours_Bonus_Value = @Afternoon_Hours_Bonus_Value , Night_Hours_Bonus_Value = @Night_Hours_Bonus_Value ,  " +
                " Officail_Holidays_Bonus_Value = @Officail_Holidays_Bonus_Value where AIO_Code =@id and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            else
                // Insert Bonuses
                salaryCommand3.CommandText = "insert into Bonuses ( Morning_Hours,Afternoon_Hours,Night_Hours, " +
                    "Extra_Shifts_Days,Extra_Shifts_Bonus_Value,Official_Holidays,Total_Bonuses,Payment_D,AIO_Code," +
                    " Morning_Hours_Bonus_Value,Afternoon_Hours_Bonus_Value,Night_Hours_Bonus_Value,Officail_Holidays_Bonus_Value) values (" +
                    " @Morning_Hours , @Afternoon_Hours, @Night_Hours, @Extra_Shifts_Days, @Extra_Shifts_Bonus_Value, @Official_Holidays, @Total_Bonuses," +
                    "@Date,@ID,@Morning_Hours_Bonus_Value,@Afternoon_Hours_Bonus_Value,@Night_Hours_Bonus_Value,@Officail_Holidays_Bonus_Value)";

            salaryCommand3.Parameters.Add("@Morning_Hours", emp.MorningHrs);
            salaryCommand3.Parameters.Add("@Morning_Hours_Bonus_Value", emp.MorningHrsValue);
            salaryCommand3.Parameters.Add("@Afternoon_Hours", emp.AfternoonHrs);
            salaryCommand3.Parameters.Add("@Afternoon_Hours_Bonus_Value", emp.AfternoonHrsValue);
            salaryCommand3.Parameters.Add("@Night_Hours", emp.NightHrs);
            salaryCommand3.Parameters.Add("@Night_Hours_Bonus_Value", emp.NightHrsValue);
            //salaryCommand3.Parameters.Add("@Workers_Day", emp.WorkersDay);
            salaryCommand3.Parameters.Add("@Extra_Shifts_Days", emp.ExtraShifts);
            salaryCommand3.Parameters.Add("@Extra_Shifts_Bonus_Value", emp.ExtraShiftBonus);
            salaryCommand3.Parameters.Add("@Official_Holidays", emp.OfficialHolidays);
            salaryCommand3.Parameters.Add("@Officail_Holidays_Bonus_Value", emp.OfficialHolidaysValue);
            //salaryCommand3.Parameters.Add("@Give_Away_Bonus_Value", emp.Giveaways);
            salaryCommand3.Parameters.Add("@Total_Bonuses", emp.TotalBonuses);
            salaryCommand3.Parameters.Add("@Month", DT.Month);
            salaryCommand3.Parameters.Add("@Year", DT.Year);
            salaryCommand3.Parameters.Add("@Date", DT);
            salaryCommand3.Parameters.Add("@ID", emp.AIOID);
            ReConnectDB();
            SqlDataReader annualDataReader2 = salaryCommand3.ExecuteReader();
             annualDataReader.Close();
            annualDataReader2.Close();
            ClearBonuses();
            }
         public void Update_Salary(Employee emp, DateTime DT)
        {
            // Update Salary
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "update salary set CooperativeBoxValue = @COP , CooperativeBoxValue_2 = @COP2 , Main_Salary =@main,Main_Salary_Adj = @mainA,Work_Environment_Alternative =@WEA,Work_Environment_Alternative_Adj =@WEAA,Representing_Alternative=@RA," +
            "Representing_Alternative_Adj=@RAA,Social_Raises=@SR,Social_Raises_Adj=@SRA,Net_Salary =@NetSalary,Taxes_Apply =@TA, Insurances_Apply =@IA,Static_Company_Insurance =@SCI,Dynamic_Company_Insurance =@DCI, Static_Employee_Insurance =@SEI,Dynamic_Employee_Insurance =@DEI," +
            "Net_Tax_Affected_Value =@NTAV, Total_Tax_Affected_Value =@TTAV, Net_Taxes =@NT ,Total1 = @T1 ,Total1_Adj = @T1A, Total2 = @T2 ,Total3 = @T3 ,Social_Raises_Release = @SRR,Social_Raises_Release_Adj = @SRRA,StaticContainer = @SC,DynamicContainer=@DC" +
            " , Others = @O , I_Type = @IType where AIO_Code =@id and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
            salaryCommand.Parameters.Add("@main", emp.MainSalary);
            salaryCommand.Parameters.Add("@mainA", emp.MainSalaryAdj);
            salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
            salaryCommand.Parameters.Add("@WEAA", emp.WorkEnvironmentAltAdj);
            salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
            salaryCommand.Parameters.Add("@RAA", emp.RepresentingAltAdj);
            salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
            salaryCommand.Parameters.Add("@SRA", emp.SocialRaisesAdj);
            salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
            salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
            salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
            salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
            salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
            salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
            salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
            salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
            salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
            salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
            salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
            salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
            salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
            salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@id", emp.AIOID);
            salaryCommand.Parameters.Add("@Month", DT.Month);
            salaryCommand.Parameters.Add("@Year", DT.Year);
            salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
            salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
            salaryCommand.Parameters.Add("@T2", emp.Total2);
            salaryCommand.Parameters.Add("@T3", emp.Total3);
            salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
            salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
            salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
            salaryCommand.Parameters.Add("@O", emp.Other);
            salaryCommand.Parameters.Add("@IType", emp.IType);
            salaryCommand.ExecuteReader();

            DT = DT.AddMonths(-1);

            // Update Minuses
            UpdateMinuses_Salary(emp, DT);
            // Update Bonuses
            UpdateBonuses_Salary(emp, DT);
        }
        #region Sickness in Salary
        public DataTable LoadSickness(DateTime DT )
        {
            DataTable Data = new DataTable();
            SqlCommand sicknessCommand = new SqlCommand();
            sicknessCommand.Connection = connection;
            sicknessCommand.CommandText = "select Sickness_Days,AIO_Code from Minuses where Sickness_Days > 0 and Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString();
            sicknessCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = sicknessCommand.ExecuteReader();
            Data.Load(annualDataReader);
            return Data;
        }
        public void UpdateSickness(DateTime DT,List<int>IDS)
        {
            DT = DT.AddMonths(-1);
            foreach (int ID in IDS)
            {
                int Emp = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                UpdateMinuses_Salary(SystemControl.SalaryEmployeesList[Emp], DT);
            }
            ClearMinuses();
        }
        #endregion
        #region Absence and Penalties
        public DataTable LoadAbsAndPenalty(DateTime DT)
        {
            DataTable Data = new DataTable();
            SqlCommand sicknessCommand = new SqlCommand();
            sicknessCommand.Connection = connection;
            sicknessCommand.CommandText = "select Abscence_Days,Penalty_Days,AIO_Code from Minuses where (Abscence_Days>0 Or Penalty_Days>0) and Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString();
            sicknessCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = sicknessCommand.ExecuteReader();
            Data.Load(annualDataReader);
            return Data;
        }
        public void UpdateAbsenceAndPenalty(DateTime DT, List<int> IDS)
        {
            DT = DT.AddMonths(-1);
            foreach (int ID in IDS)
            {
                int Emp = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                UpdateMinuses_Salary(SystemControl.SalaryEmployeesList[Emp], DT);
            }
            ClearMinuses();
        }
        #endregion
        #region Other Minuses
            public DataTable LoadOtherMinuses(DateTime DT)
            {
                DataTable Data = new DataTable();
                SqlCommand sicknessCommand = new SqlCommand();
                sicknessCommand.Connection = connection;
                sicknessCommand.CommandText = "select OtherMinuses,AIO_Code from Minuses2 where OtherMinuses > 0 and Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString();
                sicknessCommand.CommandType = CommandType.Text;
                SqlDataReader annualDataReader = sicknessCommand.ExecuteReader();
                Data.Load(annualDataReader);
                return Data;
            }
            public void UpdateOtherMinuses(DateTime DT, List<int> IDS)
            {
                    DT = DT.AddMonths(-1);
                    foreach (int ID in IDS)
                {
                    int Emp = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                    UpdateMinuses_Salary(SystemControl.SalaryEmployeesList[Emp], DT);
                }
            }
        #endregion
        #region Extra Shifts
        public DataTable LoadExtraShifts(DateTime DT)
        {
            DataTable Data = new DataTable();
            SqlCommand sicknessCommand = new SqlCommand();
            sicknessCommand.Connection = connection;
            sicknessCommand.CommandText = "select Extra_Shifts_Days,AIO_Code from Bonuses where Extra_Shifts_Days > 0 and Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString();
            sicknessCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = sicknessCommand.ExecuteReader();
            Data.Load(annualDataReader);
            return Data;
        }
        public void UpdateExtraShifts(DateTime DT, List<int> IDS)
        {
            DT = DT.AddMonths(-1);
            foreach (int ID in IDS)
            {
                int Emp = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                UpdateBonuses_Salary(SystemControl.SalaryEmployeesList[Emp], DT);
            }
            ClearBonuses();
        }
        #endregion
        #region EXTRA
        public DataTable LoadShifts(DateTime DT)
        {
            DataTable Data = new DataTable();
            SqlCommand sicknessCommand = new SqlCommand();
            sicknessCommand.Connection = connection;
            sicknessCommand.CommandText = "select Morning_Hours,Afternoon_Hours,Night_Hours,Official_Holidays,AIO_Code from Bonuses " +
                "where (Morning_Hours>0 Or Afternoon_Hours>0 Or Night_Hours>0 Or Official_Holidays>0) and Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString();
            sicknessCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = sicknessCommand.ExecuteReader();
            Data.Load(annualDataReader);
            return Data;
        }
        public void UpdateShifts(DateTime DT, List<int> IDS)
        {
            DT = DT.AddMonths(-1);
            foreach (int ID in IDS)
            {
                int Emp = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                UpdateBonuses_Salary(SystemControl.SalaryEmployeesList[Emp], DT);
            }
            ClearBonuses();
        }
        #endregion
        #region Treatment
        public DataTable LoadTreatments(DateTime DT)
        {
            DataTable Data = new DataTable();
            SqlCommand sicknessCommand = new SqlCommand();
            sicknessCommand.Connection = connection;
            sicknessCommand.CommandText = "select Treatment,AIO_Code from Minuses2 " +
                "where Treatment>0 and Year(Payment_D) = " + DT.Year.ToString() + " and Month(Payment_D) =" + (DT.Month).ToString();
            sicknessCommand.CommandType = CommandType.Text;
            SqlDataReader annualDataReader = sicknessCommand.ExecuteReader();
            Data.Load(annualDataReader);
            return Data;
        }
        public void UpdateTreatments(DateTime DT, List<int> IDS)
        {
            DT = DT.AddMonths(-1);
            foreach (int ID in IDS)
            {
                int Emp = SystemControl.SalaryEmployeesList.FindIndex(j => j.AIOID == ID);
                UpdateMinuses_Salary(SystemControl.SalaryEmployeesList[Emp], DT);
            }
        }
        #endregion
        #region Giveaways
            public void AddGivwaway(Employee E)
            {
                SqlCommand GiveawayCommand = new SqlCommand();
                GiveawayCommand.Connection = connection;
                GiveawayCommand.CommandText = "select * from Giveaways where Month(Payment_D) = @M and Year(Payment_D) = @Y and AIO_Code = @ID and With_Tax = @HT";
                GiveawayCommand.Parameters.Add("@M", DateTime.Now.Month);
                GiveawayCommand.Parameters.Add("@Y", DateTime.Now.Year);
                GiveawayCommand.Parameters.Add("@ID", E.AIOID);
            GiveawayCommand.Parameters.Add("@HT", E.giveawayObject.HasTax);
            SqlDataReader Y = GiveawayCommand.ExecuteReader();
                bool HasRows = Y.HasRows;
                Y.Close();
                if (HasRows) UpdateGivwaway(E);
                else
                {
                    GiveawayCommand.CommandText = "insert into Giveaways (AIO_Code,Total_G,G_Tax,Net_G,Payment_D,DP,DM,IP,IM,With_Tax) Values (@ID,@Total,@Tax,@Net,@Date,@DP,@DM,@IP,@IM,@HT)";
                    GiveawayCommand.Parameters.Add("@Total", E.giveawayObject.Total_G);
                    GiveawayCommand.Parameters.Add("@Tax", E.giveawayObject.Tax);
                    GiveawayCommand.Parameters.Add("@Net", E.giveawayObject.Net_G);
                    GiveawayCommand.Parameters.Add("@Date", E.giveawayObject.Payment);
                    GiveawayCommand.Parameters.Add("@DP", E.giveawayObject.DP);
                    GiveawayCommand.Parameters.Add("@DM", E.giveawayObject.DM);
                    GiveawayCommand.Parameters.Add("@IP", E.giveawayObject.IP);
                    GiveawayCommand.Parameters.Add("@IM", E.giveawayObject.IM);
                    GiveawayCommand.Parameters.Add("@HasTax", E.giveawayObject.IM);
                    //GiveawayCommand.Parameters.Add("@HT", E.giveawayObject.HasTax);
                    SqlDataReader X = GiveawayCommand.ExecuteReader();
                    X.Close();
                }
            }
            public void UpdateGivwaway(Employee E)
            {
                SqlCommand GiveawayCommand = new SqlCommand();
                GiveawayCommand.Connection = connection;
                GiveawayCommand.CommandText = "update Giveaways set Total_G = @Total , G_Tax = @Tax , Net_G = @Net , DP = @DP , DM = @DM , IM = @IM , IP = @IP" +
                " where Month(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID and With_Tax = @HT";
                GiveawayCommand.Parameters.Add("@ID", E.AIOID);
                GiveawayCommand.Parameters.Add("@Total", E.giveawayObject.Total_G);
                GiveawayCommand.Parameters.Add("@Tax", E.giveawayObject.Tax);
                GiveawayCommand.Parameters.Add("@Net", E.giveawayObject.Net_G);
                GiveawayCommand.Parameters.Add("@Month", E.giveawayObject.Payment.Month);
                GiveawayCommand.Parameters.Add("@Year", E.giveawayObject.Payment.Year);
                GiveawayCommand.Parameters.Add("@DP", E.giveawayObject.DP);
            GiveawayCommand.Parameters.Add("@DM", E.giveawayObject.DM);
            GiveawayCommand.Parameters.Add("@IP", E.giveawayObject.IP);
            GiveawayCommand.Parameters.Add("@IM", E.giveawayObject.IM);
            GiveawayCommand.Parameters.Add("@HT", E.giveawayObject.HasTax);
            SqlDataReader X = GiveawayCommand.ExecuteReader();
                X.Close();
            }
            public DataTable SelectGiveaway(DateTime DT,int HasTax)
        {
            SqlCommand GiveawayCommand = new SqlCommand();
            GiveawayCommand.Connection = connection;
            GiveawayCommand.CommandText = "SELECT dbo.Employee.Full_Name, dbo.Employee.AIO_Code, dbo.Employee.N_ID, dbo.Giveaways.Net_G "+
                            "FROM dbo.Giveaways INNER JOIN dbo.Employee ON dbo.Giveaways.AIO_Code = dbo.Employee.AIO_Code where " +
                            "Month(dbo.Giveaways.Payment_D) = @M and Year(dbo.Giveaways.Payment_D) = @Y and dbo.Giveaways.With_Tax = @HT";
            GiveawayCommand.Parameters.Add("@M", DT.Month);
            GiveawayCommand.Parameters.Add("@Y", DT.Year);
            GiveawayCommand.Parameters.Add("@HT", HasTax);
            SqlDataReader X = GiveawayCommand.ExecuteReader();
            DataTable Data = new DataTable();
            Data.Load(X);
            X.Close();
            return Data;
        }
            public void CancelGivwaway(DateTime DT,int HasTax)
            {
                SqlCommand GiveawayCommand = new SqlCommand();
                GiveawayCommand.Connection = connection;
                GiveawayCommand.CommandText = "Delete from Giveaways where Month(Payment_D) = @Month and Year(Payment_D) = @Year and With_Tax = @HT";
                GiveawayCommand.Parameters.Add("@Month", DT.Month);
                GiveawayCommand.Parameters.Add("@Year", DT.Year);
                GiveawayCommand.Parameters.Add("@HT", HasTax);
                SqlDataReader DR = GiveawayCommand.ExecuteReader();
                DR.Close();
            }
            public DataTable SelectGivwaway(DateTime G,int HasTax)
            {
                SqlCommand GiveawayCommand = new SqlCommand();
                GiveawayCommand.Connection = connection;
                //GiveawayCommand.CommandText = "Select * from Giveaways where Month(Payment_D) = @Month and Year(Payment_D) = @Year and With_Tax = @HT";
            GiveawayCommand.CommandText = "Select AIO_Code as 'كود الموظف' , Total_G as 'الاجمالى' , G_Tax as 'الضريبة' ,Net_G as 'الصافى' , Payment_D as 'التاريخ' , DP as 'نسبة الخصم' , IP as 'نسبة الزيادة' , DM as 'مبلغ الخصم' , IM as 'مبلغ الزيادة' , With_Tax as 'خضوع الضريبة' from Giveaways where Month(Payment_D) = @Month and Year(Payment_D) = @Year and With_Tax = @HT";
            GiveawayCommand.Parameters.Add("@Month", G.Month);
                GiveawayCommand.Parameters.Add("@Year", G.Year);
                GiveawayCommand.Parameters.Add("@HT", HasTax);
                SqlDataReader DR = GiveawayCommand.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(DR);
                return DT;
            }
        #endregion
        public Employee GetSalaryMainData(DateTime DT, int AIO)
        {
            int year = DT.Year, month = DT.Month;
            Employee E = new Employee();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;

            // Get Salary Data

            int X = SystemControl.employees.FindIndex(j => j.AIOID == AIO);
            E = SystemControl.employees[X];   // To get main Data (Name ,....)

            salaryCommand.CommandText = "select * from salary where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID ";
            salaryCommand.Parameters.Clear();
            salaryCommand.Parameters.Add("@Month", month);
            salaryCommand.Parameters.Add("@Year", year);
            salaryCommand.Parameters.Add("@ID", AIO);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader salaryDataReader = salaryCommand.ExecuteReader();
            while (salaryDataReader.Read())
            {
                E.MainSalary = float.Parse(salaryDataReader["Main_Salary"].ToString());
                E.WorkEnvironmentAlt = float.Parse(salaryDataReader["Work_Environment_Alternative"].ToString());
                E.RepresentingAlt = float.Parse(salaryDataReader["Representing_Alternative"].ToString());
                E.SocialRaises = float.Parse(salaryDataReader["Social_Raises"].ToString());
                E.SocialRaisesRelease = float.Parse(salaryDataReader["Social_Raises_Release"].ToString());
                E.SocialRaisesReleaseAdj = float.Parse(salaryDataReader["Social_Raises_Release_Adj"].ToString());
                E.CooperativeBoxValue = float.Parse(salaryDataReader["CooperativeBoxValue"].ToString());
                E.CooperativeBoxValue_2 = float.Parse(salaryDataReader["CooperativeBoxValue_2"].ToString());
                E.NetTaxes = float.Parse(salaryDataReader["Net_Taxes"].ToString());
                E.WorkingDays = float.Parse(salaryDataReader["Working_Days"].ToString());
                E.NetSalary = float.Parse(salaryDataReader["Net_Salary"].ToString());
                E.StaticCompanyInsurance = float.Parse(salaryDataReader["Static_Company_Insurance"].ToString());
                E.DynamicCompanyInsurance = float.Parse(salaryDataReader["Dynamic_Company_Insurance"].ToString());
                E.StaticEmployeeInsurance = float.Parse(salaryDataReader["Static_Employee_Insurance"].ToString());
                E.DynamicEmployeeInsurance = float.Parse(salaryDataReader["Dynamic_Employee_Insurance"].ToString());
                E.NetTaxAffectedValues = float.Parse(salaryDataReader["Net_Tax_Affected_Value"].ToString());
                E.TotalTaxAffectedValues = float.Parse(salaryDataReader["Total_Tax_Affected_Value"].ToString());
                E.Other = float.Parse(salaryDataReader["ADiff"].ToString());
                E.WorkingDays = float.Parse(salaryDataReader["Working_Days"].ToString());
                E.Total1 = float.Parse(salaryDataReader["Total1"].ToString());
                E.Adj_Total1 = float.Parse(salaryDataReader["Total1_Adj"].ToString());
                E.Total2 = float.Parse(salaryDataReader["Total2"].ToString());
                E.Total3 = float.Parse(salaryDataReader["Total3"].ToString());
                E.StaticContainer = float.Parse(salaryDataReader["StaticContainer"].ToString());
                E.DynamicContainer = float.Parse(salaryDataReader["DynamicContainer"].ToString());
                E.WorkersDay = float.Parse(salaryDataReader["Workers_Day"].ToString());
                E.WorkersDayAdj = float.Parse(salaryDataReader["Workers_Day_Adj"].ToString());
                E.Other += float.Parse(salaryDataReader["Others"].ToString());
                bool T = Boolean.Parse(salaryDataReader["I_Type"].ToString());
                E.IType = T ? InsuranceType.Current : InsuranceType.New;
            }
            salaryDataReader.Close();

            // Get Giveaways data if exist
            salaryCommand.CommandText = "select * from G_With_Salary where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID";
            salaryDataReader = salaryCommand.ExecuteReader();
            if (salaryDataReader.HasRows)
                while (salaryDataReader.Read())
                    E.Giveaways = float.Parse(salaryDataReader["G_Value"].ToString());

            salaryDataReader.Close();

            DateTime DX = DT;
            DX = DX.AddMonths(-1);
            int PrevMonth = DX.Month;

            // Get Minsuses Data
            salaryCommand.Parameters.Clear();
            salaryCommand.CommandText = "select * from Minuses where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID ";
            salaryCommand.Parameters.Add("@Month", PrevMonth);
            salaryCommand.Parameters.Add("@Year", year);
            salaryCommand.Parameters.Add("@ID", AIO);
            salaryCommand.CommandType = CommandType.Text;

            SqlDataReader salaryDataReader2 = salaryCommand.ExecuteReader();
            while (salaryDataReader2.Read())
            {
                E.SicknessDays = float.Parse(salaryDataReader2["Sickness_Days"].ToString());
                E.AbsenceDays = float.Parse(salaryDataReader2["Abscence_Days"].ToString());
                E.Penalty = float.Parse(salaryDataReader2["Penalty_Days"].ToString());
                E.Installments = float.Parse(salaryDataReader2["Installments"].ToString());
            }
            salaryDataReader2.Close();
            // Get Bonuses Data
            salaryCommand.Parameters.Clear();
            salaryCommand.CommandText = "select * from Bonuses where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID ";
            salaryCommand.Parameters.Add("@Month", PrevMonth);
            salaryCommand.Parameters.Add("@Year", year);
            salaryCommand.Parameters.Add("@ID", AIO);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader salaryDataReader3 = salaryCommand.ExecuteReader();
            while (salaryDataReader3.Read())
            {
                E.MorningHrs = float.Parse(salaryDataReader3["Morning_Hours"].ToString());
                E.MorningHrsValue = float.Parse(salaryDataReader3["Morning_Hours_Bonus_Value"].ToString());
                E.AfternoonHrs = float.Parse(salaryDataReader3["Afternoon_Hours"].ToString());
                E.AfternoonHrsValue = float.Parse(salaryDataReader3["Afternoon_Hours_Bonus_Value"].ToString());
                E.NightHrs = float.Parse(salaryDataReader3["Night_Hours"].ToString());
                E.NightHrsValue = float.Parse(salaryDataReader3["Night_Hours_Bonus_Value"].ToString());
                E.OfficialHolidays = float.Parse(salaryDataReader3["Official_Holidays"].ToString());
                E.OfficialHolidaysValue = float.Parse(salaryDataReader3["Officail_Holidays_Bonus_Value"].ToString());
                E.ExtraShifts = float.Parse(salaryDataReader3["Extra_Shifts_Days"].ToString());
                E.ExtraShiftBonus = float.Parse(salaryDataReader3["Extra_Shifts_Bonus_Value"].ToString());
                E.TotalBonuses = float.Parse(salaryDataReader3["Total_Bonuses"].ToString());
            }
            salaryDataReader3.Close();

            DateTime XC = new DateTime(DT.Year, DT.Month, 15);
            GetMinusesData(E.AIOID, XC, ref E.OtherMinuses, ref E.TreatmentCost);
            GetInstallsValue(E.AIOID, ref E.AlimonyMonthlyInstallment, ref E.Insurance_Policy_Release, ref E.PreviousPeriodInstallments);
            return E;
        }
        public DataTable GetDepts()
        {
            DataTable DT = new DataTable();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "select * from Departments";
            SqlDataReader X = salaryCommand.ExecuteReader();
            DT.Load(X);
            X.Close();
            return DT;
        }
        public DataTable SelectSalaryToSave()
        {
            DataTable DT = new DataTable();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "SELECT dbo.Employee.Full_Name,dbo.Employee.AIO_Code, dbo.Employee.N_ID, dbo.Salary.Net_Salary " +
                                "FROM dbo.Employee INNER JOIN dbo.Salary ON dbo.Employee.AIO_Code = dbo.Salary.AIO_Code where Month(dbo.Salary.Payment_D) = @M and Year(dbo.Salary.Payment_D) = @Y";
            salaryCommand.Parameters.Add("@M", DateTime.Now.Month);
            salaryCommand.Parameters.Add("@Y", DateTime.Now.Year);
            SqlDataReader X = salaryCommand.ExecuteReader();
            DT.Load(X);
            X.Close();
            return DT;
        }
        public DataTable SelectProfitToSave()
        {
            DataTable DT = new DataTable();
            DataTable DT2 = new DataTable();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "SELECT dbo.Employee.Full_Name,dbo.Employee.AIO_Code, dbo.Employee.N_ID, dbo.Profit.Total_Value " +
                                "FROM dbo.Employee INNER JOIN dbo.Profit ON dbo.Employee.AIO_Code = dbo.Profit.AIO_Code where dbo.Profit.Profit_Year = @Y";
            salaryCommand.Parameters.Add("@Y", DateTime.Now.Year-1);
            SqlDataReader X = salaryCommand.ExecuteReader();
            DT.Load(X);
            X.Close();

            salaryCommand.CommandText = "SELECT dbo.ProfitEmps.Name, dbo.ProfitEmps.AIO_Code, dbo.ProfitEmps.N_ID, dbo.Profit.Total_Value" +
                                        " FROM dbo.Profit INNER JOIN dbo.ProfitEmps ON dbo.Profit.AIO_Code_2 = dbo.ProfitEmps.AIO_Code WHERE dbo.ProfitEmps.Year_ = @Y";
            //salaryCommand.Parameters.Add("@Y", DateTime.Now.Year - 1);
            X = salaryCommand.ExecuteReader();
            DT2.Load(X);
            X.Close();

            foreach (DataRow Dr in DT2.Rows) DT.Rows.Add(Dr.ItemArray);

            return DT;
        }

        public void AddEmployee_Excel(Employee emp, int Startday, int WorkingMonths)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "INSERT INTO Employee (Full_Name,AIO_Code,Date_of_Birth,Hiring_D,Termination_D,Contract_Type,Working_Type,E_Degree,Depart_ID,N_ID)" +
            " VALUES(@FN,@AIOID,@DOB,@HD,@TD,@CT,@WT,@ED,@Depart_ID,@N_ID);";
            employeeCommand.Parameters.Add("@FN", emp.FullName);
            employeeCommand.Parameters.Add("@AIOID", emp.AIOID);
            employeeCommand.Parameters.Add("@DOB", emp.DateOfBirth.Date);
            employeeCommand.Parameters.Add("@HD", emp.HiringDate.Date);
            employeeCommand.Parameters.Add("@TD", emp.TerminationDate.Date);
            employeeCommand.Parameters.Add("@ED", emp.CurrentDegree);
            employeeCommand.Parameters.Add("@Depart_ID", emp.Dept_ID);
            employeeCommand.Parameters.Add("@N_ID", emp.National_ID);
            if (emp.CType == ContractType.Temporary)
            {
                employeeCommand.Parameters.Add("@CT", "Temporary");
            }
            else if (emp.CType == ContractType.Permenant)
            {
                employeeCommand.Parameters.Add("@CT", "Permenant");
            }
            if (emp.WType == WorkingType.Direct)
            {
                employeeCommand.Parameters.Add("@WT", "Direct");
            }
            else if (emp.WType == WorkingType.InDirect)
            {
                employeeCommand.Parameters.Add("@WT", "InDirect");
            }

            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            employeeCommandWriter.Close();

            //if (emp.TerminationDate < DateTime.Now) return;

            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "INSERT INTO Salary" +
           " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj," +
           ",Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
           " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,StaticContainer,DynamicContainer,Workers_Day,Workers_Day_Adj," +
                                        "Others,I_Type,Total1_Adj,CooperativeBoxValue_2)" +
           " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA," +
           "@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV" +
           ",@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@SC,@DC,@WDS,@WDSA,@O,@IType,@T1A,@COP2);";
            int Months = WorkingMonths;
            for (int x = 0; x < Months + 1; x++)
            {
                string EditableForamt = "";
                salaryCommand.Parameters.Clear();

                DateTime XX = emp.HiringDate.AddMonths(x);

                if (XX.Year > DateTime.Now.Year) break;
                if (XX.Month == emp.TerminationDate.Month && XX.Year == emp.TerminationDate.Year) emp.WorkingDays = emp.TerminationDate.Day;
                else if (x == 0) emp.WorkingDays = Startday;
                else emp.WorkingDays = 30;

                // Last Month no Insurance Applied
                if (emp.TerminationDate.Month == XX.Month && emp.TerminationDate.Year == XX.Year) emp.InsuranceApply = false;
                else emp.InsuranceApply = true;

                //DateTime Min = new DateTime(XX.Year, 7, 1);
                //DateTime Max = new DateTime(XX.Year, 12, 31);
                //if (emp.HiringDate >= Min && emp.HiringDate <= Max) emp.ApplyJulyInsurance = true;
                //else emp.ApplyJulyInsurance = false;

                GetPrevTotal(XX, ref emp);
                emp.ProcessEmployee();

                salaryCommand.Parameters.Add("@main", emp.MainSalary);
                salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
                salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
                salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
                salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
                salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
                salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
                salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
                salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
                salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
                salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
                salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
                salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
                salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
                salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
                salaryCommand.Parameters.Add("@NT", emp.NetTaxes);

                EditableForamt = new DateTime(XX.Year, XX.Month, DateTime.DaysInMonth(XX.Year, XX.Month)).ToShortDateString();
                salaryCommand.Parameters.Add("@id", emp.AIOID);
                salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
                salaryCommand.Parameters.Add("@PY", EditableForamt);
                salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
                salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
                salaryCommand.Parameters.Add("@T2", emp.Total2);
                salaryCommand.Parameters.Add("@T3", emp.Total3);
                salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
                salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
                salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
                salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
                salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
                salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
                salaryCommand.Parameters.Add("@O", emp.Other);
                salaryCommand.Parameters.Add("@IType", emp.IType);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();
                SetNetDays_30();

                XX = XX.AddMonths(-1);  // Save in prevoise Month
                if (emp.SicknessValue > 0 || emp.AbsenceValue > 0 || emp.PenaltyValue > 0) UpdateMinuses_Salary(emp, new DateTime(XX.Year, XX.Month, DateTime.DaysInMonth(XX.Year, XX.Month)));
                if (emp.MorningHrsValue > 0 || emp.AfternoonHrsValue > 0 || emp.NightHrsValue > 0 || emp.OfficialHolidaysValue > 0 || emp.ExtraShifts > 0) UpdateBonuses_Salary(emp, new DateTime(XX.Year, XX.Month, DateTime.DaysInMonth(XX.Year, XX.Month)));
            }
        }
        public void GetPrevTotal(DateTime DT, ref Employee Emp)
        {
            DT = DT.AddMonths(-1);
            SqlCommand salaryCommand = new SqlCommand();
            DataTable D = new DataTable();
            float Total1, Total2, MainSalary, WD, P, CompInsur;
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "select AIO_Code,Total1,Total2,Main_Salary,Working_Days,(Dynamic_Company_Insurance+Static_Company_Insurance) from salary " +
            "where MONTH(Payment_D) = @Month and Year(Payment_D) = @Year and AIO_Code = @ID";
            salaryCommand.Parameters.Add("@Year", DT.Year);
            salaryCommand.Parameters.Add("@Month", DT.Month);
            salaryCommand.Parameters.Add("@ID", Emp.AIOID);
            SqlDataReader X = salaryCommand.ExecuteReader();
            D.Load(X);
            if (D.Rows.Count > 0)
            {
                Total1 = float.Parse(D.Rows[0].ItemArray[1].ToString());
                Total2 = float.Parse(D.Rows[0].ItemArray[2].ToString());
                WD = float.Parse(D.Rows[0].ItemArray[4].ToString());
                MainSalary = float.Parse(D.Rows[0].ItemArray[3].ToString());
                CompInsur = float.Parse(D.Rows[0].ItemArray[5].ToString());
                P = WD / 30;
                //Emp.Prev_Total1 = Total1 * P;
                Emp.Prev_Total1 = Total1; // New in Test
                Emp.Prev_Total2 = Total1 + CompInsur;
                Emp.PrevMainSalary = MainSalary * P;

            }
            else
                Emp.Prev_Total1 = Emp.Prev_Total2 = Emp.PrevMainSalary = 0;

            X.Close();
        }
        public void AddEmployee_Main(Employee emp)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "INSERT INTO Employee (Full_Name,AIO_Code,Date_of_Birth,Hiring_D,Termination_D,Contract_Type,Working_Type,E_Degree,Depart_ID,N_ID)" +
            " VALUES(@FN,@AIOID,@DOB,@HD,@TD,@CT,@WT,@ED,@Depart_ID,@N_ID);";
            employeeCommand.Parameters.Add("@FN", emp.FullName);
            employeeCommand.Parameters.Add("@AIOID", emp.AIOID);
            employeeCommand.Parameters.Add("@DOB", emp.DateOfBirth.Date);
            employeeCommand.Parameters.Add("@HD", emp.HiringDate.Date);
            employeeCommand.Parameters.Add("@TD", emp.TerminationDate.Date);
            employeeCommand.Parameters.Add("@ED", emp.CurrentDegree);
            employeeCommand.Parameters.Add("@Depart_ID", emp.Dept_ID);
            employeeCommand.Parameters.Add("@N_ID", emp.National_ID);
            if (emp.CType == ContractType.Temporary)
                employeeCommand.Parameters.Add("@CT", "Temporary");
            else if (emp.CType == ContractType.Permenant)
                employeeCommand.Parameters.Add("@CT", "Permenant");
            if (emp.WType == WorkingType.Direct)
                employeeCommand.Parameters.Add("@WT", "Direct");
            else if (emp.WType == WorkingType.InDirect)
                employeeCommand.Parameters.Add("@WT", "InDirect");

            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            employeeCommandWriter.Close();
        }
        public void AddEmployee_Salary(Employee emp)
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "INSERT INTO Salary" +
           " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj," +
           ",Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
           " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,StaticContainer,DynamicContainer,Workers_Day,Workers_Day_Adj," +
           "Others,I_Type,Total1_Adj,CooperativeBoxValue_2)" +
           " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA," +
           "@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV" +
           ",@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@SC,@DC,@WDS,@WDSA,@O,@IType,@T1A,@COP2);";
                salaryCommand.Parameters.Clear();
                DateTime XX = emp.PaymentDate;

                if (XX.Month == emp.TerminationDate.Month && XX.Year == emp.TerminationDate.Year) emp.WorkingDays = emp.TerminationDate.Day;
                else if (XX.Month == emp.HiringDate.Month && XX.Year == emp.HiringDate.Year) emp.WorkingDays = (30 - emp.HiringDate.Day)+1;
                else emp.WorkingDays = 30;

                // Last Month no Insurance Applied
                if (emp.TerminationDate.Month == XX.Month && emp.TerminationDate.Year == XX.Year) emp.InsuranceApply = false;

                salaryCommand.Parameters.Add("@main", emp.MainSalary);
                salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
                salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
                salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
                salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
                salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
                salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
                salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
                salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
                salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
                salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
                salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
                salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
                salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
                salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
                salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
                salaryCommand.Parameters.Add("@id", emp.AIOID);
                salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
                salaryCommand.Parameters.Add("@PY", emp.PaymentDate);
                salaryCommand.Parameters.Add("@T1", emp.Total1); // New in test
                salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in test
                salaryCommand.Parameters.Add("@T2", emp.Total2);
                salaryCommand.Parameters.Add("@T3", emp.Total3);
                salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
            salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
                salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
                salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
                salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
                salaryCommand.Parameters.Add("@O", emp.Other);
                salaryCommand.Parameters.Add("@IType", emp.IType);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();
                SetNetDays_30();

                XX = XX.AddMonths(-1);  // Save in prevoise Month
                if (emp.SicknessValue > 0 || emp.AbsenceValue > 0 || emp.PenaltyValue > 0)
                    UpdateMinuses_Salary(emp, new DateTime(XX.Year, XX.Month, DateTime.DaysInMonth(XX.Year, XX.Month)));
                if (emp.MorningHrsValue > 0 || emp.AfternoonHrsValue > 0 || emp.NightHrsValue > 0 || emp.OfficialHolidaysValue > 0 || emp.ExtraShifts > 0)
                    UpdateBonuses_Salary(emp, new DateTime(XX.Year, XX.Month, DateTime.DaysInMonth(XX.Year, XX.Month)));
            
        }
        /// <summary>
        /// Cont. installments are set once and will be add automatically to minuses each month 
        /// Each one of those three (Inurance Policy release , Alimony , Others Value)
        /// Inurance Police Release : 1
        /// Alimony : 2
        /// Others Value : 3
        /// </summary>
        /// <returns></returns>
        void ClearOtherInstallments()
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "delete from Cont_Install where Install_Value = 0";
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();
        }
        public void GetInstallsValue(int AIO , ref float Alimony,ref float IPR,ref float Prev)
            {
                // Get Insurance Policy release : 1
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "select Install_Value from Cont_Install where Install_Type = 1 and AIO_Code = @ID";
                salaryCommand.Parameters.Add("@ID", AIO);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            if (SalaryCommandWriter.HasRows)
                while (SalaryCommandWriter.Read()) IPR = float.Parse(SalaryCommandWriter["Install_Value"].ToString());
                SalaryCommandWriter.Close();

                // Get Alimony : 2
                salaryCommand.CommandText = "select Install_Value from Cont_Install where Install_Type = 2 and AIO_Code = @ID";
                SalaryCommandWriter = salaryCommand.ExecuteReader();
                if (SalaryCommandWriter.HasRows) while (SalaryCommandWriter.Read()) Alimony = float.Parse(SalaryCommandWriter["Install_Value"].ToString());
                SalaryCommandWriter.Close();

                // Get Prev : 3
                salaryCommand.CommandText = "select Install_Value from Cont_Install where Install_Type = 3 and AIO_Code = @ID";
                SalaryCommandWriter = salaryCommand.ExecuteReader();
                if (SalaryCommandWriter.HasRows) while (SalaryCommandWriter.Read()) Prev = float.Parse(SalaryCommandWriter["Install_Value"].ToString());
                SalaryCommandWriter.Close();
            }
        public void UpdateInstallsValue(int AIO, ref float Alimony, ref float IPR, ref float Prev)
        {
            // Update Insurance Policy release
            SqlCommand salaryCommand = new SqlCommand();
            bool HasRows = false;
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "select Install_Value from Cont_Install where Install_Type = 1 and AIO_Code = @ID";
            salaryCommand.Parameters.Add("@ID", AIO);
            salaryCommand.Parameters.Add("@IPR", IPR);
            salaryCommand.Parameters.Add("@Al", Alimony);
            salaryCommand.Parameters.Add("@Prev", Prev);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            if (SalaryCommandWriter.HasRows) HasRows = true;
            else HasRows = false;
            SalaryCommandWriter.Close();

            if (HasRows) salaryCommand.CommandText = "update Cont_Install  set Install_Value  = @IPR where Install_Type = 1 and AIO_Code = @ID";
            else salaryCommand.CommandText = "insert into Cont_Install (AIO_Code,Install_Type,Install_Value) values (@ID,1,@IPR)";

            SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();

            // Update Alimony
            HasRows = false;
            salaryCommand.CommandText = "select Install_Value from Cont_Install where Install_Type = 2 and AIO_Code = @ID";
            SalaryCommandWriter = salaryCommand.ExecuteReader();
            if (SalaryCommandWriter.HasRows) HasRows = true;
            else HasRows = false;
            SalaryCommandWriter.Close();

            if (HasRows) salaryCommand.CommandText = "update Cont_Install  set Install_Value  = @Al where Install_Type = 2 and AIO_Code = @ID";
            else salaryCommand.CommandText = "insert into Cont_Install (AIO_Code,Install_Type,Install_Value) values (@ID,2,@Al)";

            SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();

            // Update Prev
            HasRows = false;
            salaryCommand.CommandText = "select Install_Value from Cont_Install where Install_Type = 3 and AIO_Code = @ID";
            SalaryCommandWriter = salaryCommand.ExecuteReader();
            if (SalaryCommandWriter.HasRows) HasRows = true;
            else HasRows = false;
            SalaryCommandWriter.Close();

            if (HasRows) salaryCommand.CommandText = "update Cont_Install  set Install_Value  = @Prev where Install_Type = 3 and AIO_Code = @ID";
            else
                salaryCommand.CommandText = "insert into Cont_Install (AIO_Code,Install_Type,Install_Value) values (@ID,3,@Prev)";

            SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();

            ClearOtherInstallments();
        }

        public void Add_AnnualIncrease()
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "INSERT INTO Annual_Increase (Last_Inc_Date) VALUES(@date);";
            employeeCommand.Parameters.Add("@date", DateTime.Now);
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            employeeCommandWriter.Close();
        }

        public bool Check_AnnualIncrease()
        {
            bool Hasrows;
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "Select * from Annual_Increase where Year(Last_Inc_Date) = Year(@Date)";
            employeeCommand.Parameters.Add("@Date", DateTime.Now);
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            Hasrows = employeeCommandWriter.HasRows;
            employeeCommandWriter.Close();
            return Hasrows;
        }

        #region notifications
        public List<int> RenewList()
            {
                List<int> EmpIDs = new List<int>();
                DataTable DTable = new DataTable();
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "select AIO_Code from Employee where  2 >= (SELECT DATEDIFF(MONTH,@DateNow, Termination_D )) and Contract_Type = 'Temporary' and Termination_D > @DateNow";
                salaryCommand.Parameters.Add("@DateNow",DateTime.Now);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                DTable.Load(SalaryCommandWriter);
                foreach (DataRow DR in DTable.Rows) EmpIDs.Add(int.Parse(DR.ItemArray[0].ToString()));
                SalaryCommandWriter.Close();

                return EmpIDs;
            }
            public List<int> PensionRenewList()
            {
                List<int> EmpIDs = new List<int>();
                DataTable DTable = new DataTable();
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "select AIO_Code from Employee where Contract_Type = 'Permenant' and 3 >= (SELECT DATEDIFF(MONTH,@DateNow, DATEADD(YEAR,60, Date_of_Birth)))";
                salaryCommand.Parameters.Add("@DateNow", DateTime.Now);
                salaryCommand.CommandType = CommandType.Text;
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                DTable.Load(SalaryCommandWriter);
                foreach (DataRow DR in DTable.Rows) EmpIDs.Add(int.Parse(DR.ItemArray[0].ToString()));
                SalaryCommandWriter.Close();

                return EmpIDs;
            }

            public void Renew(DateTime Start,DateTime End,int ID,float NetDays,int RenewType)
            {
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "INSERT INTO Renews (AIOID,Start_D,End_D,RenewType) values (@ID,@Start,@End,@Type)";
                salaryCommand.CommandType = CommandType.Text;
                salaryCommand.Parameters.Add("@ID", ID);
                salaryCommand.Parameters.Add("@Start", Start);
                salaryCommand.Parameters.Add("@End", End);
            salaryCommand.Parameters.Add("@Type", RenewType);
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();

                //if (NetDays > 0)
                //{
                //    salaryCommand.CommandText = "update Salary Set Working_Days = Working_Days + @Days where AIO_Code = @ID and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
                //    salaryCommand.Parameters.Add("@Days", NetDays);
                //    salaryCommand.Parameters.Add("@Month", Start.Month);
                //    salaryCommand.Parameters.Add("@Year", Start.Year);
                //    SalaryCommandWriter = salaryCommand.ExecuteReader();
                //    salaryCommand.Parameters.Clear();
                //    SalaryCommandWriter.Close();
                //}
            }
            public void UpdateTermination(DateTime Term_D, int ID)
            {
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "update Employee set Termination_D = @Date where AIO_Code = @ID";
                salaryCommand.CommandType = CommandType.Text;
                salaryCommand.Parameters.Add("@ID", ID);
                salaryCommand.Parameters.Add("@Date", Term_D);
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();
            }
            
            
            
            public void DeleteSalaryAfterDeath(DateTime Death_D, int ID)
            {
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "delete from Salary where Payment_D > @Date and AIO_Code = @ID";
                salaryCommand.CommandType = CommandType.Text;
                salaryCommand.Parameters.Add("@ID", ID);
                salaryCommand.Parameters.Add("@Date", Death_D);
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();

            salaryCommand.CommandText = "update Renews set End_D = @Date where AIOID = @ID and End_D = (select MAX(End_D) from Renews where AIOID = @ID)";
            SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();
        }
            public void Emp_Death(DateTime Death_D, int ID)
            {
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "insert into Death (Death_D,AIO_Code) values (@Date,@ID) ";
                salaryCommand.CommandType = CommandType.Text;
                salaryCommand.Parameters.Add("@ID", ID);
                salaryCommand.Parameters.Add("@Date", Death_D);
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();
            }

            public DataTable LastPensionPeriod(int EmpID)
        {
            DataTable DTable = new DataTable();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "select Start_D , End_D from Renews where AIOID = @ID and RenewType = 1 and End_D = (select Max(End_D) from Renews where AIOID = @ID and RenewType = 1)";
            salaryCommand.Parameters.Add("@ID", EmpID);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            DTable.Load(SalaryCommandWriter);
            SalaryCommandWriter.Close();
            return DTable;
        }

            public void RenewEmployeeSalary(Employee emp, DateTime StartDate, int WorkingMonths , float OldDays)
            {
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "INSERT INTO Salary" +
               " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj," +
               "Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
               " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,Workers_Day,Workers_Day_Adj,StaticContainer,DynamicContainer,@Total1_Adj,CooperativeBoxValue_2)" +
               " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA,@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV,@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@WDS,@WDSA,@SC,@DC,@T1A,@COP2);";
            //int Months = Math.Min(WorkingMonths , (12 - StartDate.Month));
                int Months = WorkingMonths;
                for (int x = 0; x < Months; x++)
                {
                    string EditableForamt = "";
                    salaryCommand.Parameters.Clear();
                    DateTime XX = StartDate.AddMonths(x);

                    if (XX.Month == emp.TerminationDate.Month && XX.Year == emp.TerminationDate.Year)
                    {
                        emp.WorkingDays = emp.TerminationDate.Day;
                        emp.InsuranceApply = false;
                    }
                    else if (XX.Month == StartDate.Month && XX.Year == StartDate.Year) emp.WorkingDays = (30 - StartDate.Day + 1) + OldDays;

                    else emp.WorkingDays = 30;

                    //DateTime Min = new DateTime(XX.Year, 7, 1);
                    //DateTime Max = new DateTime(XX.Year, 12, 31);
                    //if (emp.HiringDate >= Min && emp.HiringDate <= Max) emp.ApplyJulyInsurance = true;
                    //else emp.ApplyJulyInsurance = false;

                    emp.ProcessEmployee();

                    salaryCommand.Parameters.Add("@main", emp.MainSalary);
                    salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
                    salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
                    salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
                    salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
                    salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
                    salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
                    salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
                    salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
                    salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
                    salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
                    salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
                    salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
                    salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
                    salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
                    salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
                    EditableForamt = new DateTime(XX.Year, XX.Month, DateTime.DaysInMonth(XX.Year, XX.Month)).ToShortDateString();
                    salaryCommand.Parameters.Add("@id", emp.AIOID);
                    salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
                    salaryCommand.Parameters.Add("@PY", EditableForamt);
                    salaryCommand.Parameters.Add("@T1", emp.Total1); // New in test
                    salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in test
                salaryCommand.Parameters.Add("@T2", emp.Total2);
                    salaryCommand.Parameters.Add("@T3", emp.Total3);
                    salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
                    salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
                salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
                    salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
                    salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
                    salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
                    salaryCommand.CommandType = CommandType.Text;
                    SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                    SalaryCommandWriter.Close();
                    SetNetDays_30();
                }
            }
            public void RenewPension(DateTime Start, DateTime End, int ID, float NetDays)
            {
                SqlCommand salaryCommand = new SqlCommand();
                salaryCommand.Connection = connection;
                salaryCommand.CommandText = "INSERT INTO Renews (AIOID,Start_D,End_D,RenewType) values (@ID,@Start,@End,1)";
                salaryCommand.CommandType = CommandType.Text;
                salaryCommand.Parameters.Add("@ID", ID);
                salaryCommand.Parameters.Add("@Start", Start);
                salaryCommand.Parameters.Add("@End", End);
                SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();

                if (NetDays > 0)
                {
                    salaryCommand.CommandText = "update Salary Set Working_Days = Working_Days + @Days where AIO_Code = @ID and Month(Payment_D) = @Month and Year(Payment_D) = @Year";
                    salaryCommand.Parameters.Add("@Days", NetDays);
                    salaryCommand.Parameters.Add("@Month", Start.Month);
                    salaryCommand.Parameters.Add("@Year", Start.Year);
                    SalaryCommandWriter = salaryCommand.ExecuteReader();
                    salaryCommand.Parameters.Clear();
                    SalaryCommandWriter.Close();
                }
            }

        public List<int> ResignList()
        {
            List<int> EmpIDs = new List<int>();
            DataTable DTable = new DataTable();
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "select AIO_Code from Employee where  Termination_D > @DateNow";
            salaryCommand.Parameters.Add("@DateNow", DateTime.Now);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            DTable.Load(SalaryCommandWriter);
            foreach (DataRow DR in DTable.Rows) EmpIDs.Add(int.Parse(DR.ItemArray[0].ToString()));
            SalaryCommandWriter.Close();

            return EmpIDs;
        }
        #endregion
        #region Reports
        public DataTable ShiftsReport(int Year , int Month, string Wt , string DeptName )
        {
            int DeptID = SystemControl.GetDeptID(DeptName);
            SqlCommand salaryCommand = new SqlCommand();
            DataTable D = new DataTable();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "SELECT dbo.Employee.Full_Name, dbo.Employee.AIO_Code, dbo.Bonuses.Morning_Hours, dbo.Bonuses.Afternoon_Hours, dbo.Bonuses.Night_Hours, dbo.Bonuses.Extra_Shifts_Days, dbo.Bonuses.Official_Holidays, "+
             "dbo.Bonuses.Total_Bonuses, dbo.Salary.Total1 FROM dbo.Bonuses INNER JOIN "+
             "dbo.Employee ON dbo.Bonuses.AIO_Code = dbo.Employee.AIO_Code INNER JOIN dbo.Salary ON dbo.Employee.AIO_Code = dbo.Salary.AIO_Code  INNER JOIN dbo.Departments ON dbo.Employee.Depart_ID = dbo.Departments.Department_Number "+
             "where Month(dbo.Salary.Payment_D) = @M and Year(dbo.Salary.Payment_D) = @Y and Month(dbo.Bonuses.Payment_D) = @M and Year(dbo.Bonuses.Payment_D) = @Y and "+
             "dbo.Departments.Department_Number = @DN and dbo.Employee.Working_Type = @WT and dbo.Bonuses.Total_Bonuses > 0";
            salaryCommand.Parameters.Add("@Y", Year);
            salaryCommand.Parameters.Add("@M", Month);
            salaryCommand.Parameters.Add("@WT", Wt.ToString());
            salaryCommand.Parameters.Add("@DN", DeptID);
            SqlDataReader X = salaryCommand.ExecuteReader();
            D.Load(X);
            X.Close();
            return D;
        }
        public DataTable MinusesReport(int Year, int Month, string Wt, string DeptName)
        {
            int DeptID = SystemControl.GetDeptID(DeptName);
            SqlCommand salaryCommand = new SqlCommand();
            DataTable D = new DataTable();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "SELECT dbo.Employee.Full_Name,dbo.Employee.AIO_Code, dbo.Minuses.Sickness_Days, dbo.Minuses.Abscence_Days, dbo.Minuses.Penalty_Days, dbo.Salary.Main_Salary, dbo.Salary.Total1, dbo.Salary.Total2, dbo.Minuses.Total_Minuses " +
            "FROM dbo.Minuses INNER JOIN dbo.Employee ON dbo.Minuses.AIO_Code = dbo.Employee.AIO_Code INNER JOIN " +
            "dbo.Departments ON dbo.Employee.Depart_ID = dbo.Departments.Department_Number INNER JOIN "+
            "dbo.Salary ON dbo.Employee.AIO_Code = dbo.Salary.AIO_Code "+
             "where Month(dbo.Salary.Payment_D) = @M and Year(dbo.Salary.Payment_D) = @Y and Month(dbo.Minuses.Payment_D) = @M and Year(dbo.Minuses.Payment_D) = @Y and " +
             "dbo.Departments.Department_Number = @DN and dbo.Employee.Working_Type = @WT and dbo.Minuses.Total_Minuses > 0";
            salaryCommand.Parameters.Add("@Y", Year);
            salaryCommand.Parameters.Add("@M", Month);
            salaryCommand.Parameters.Add("@WT", Wt.ToString());
            salaryCommand.Parameters.Add("@DN", DeptID);
            SqlDataReader X = salaryCommand.ExecuteReader();
            D.Load(X);
            X.Close();

            

            return D;
        }
        public DataTable Insu_1(int Year, int Month, string Wt, string DeptName)
        {
            int DeptID = SystemControl.GetDeptID(DeptName);
            SqlCommand salaryCommand = new SqlCommand();
            DataTable D = new DataTable();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "SELECT dbo.Employee.AIO_Code, dbo.Employee.Full_Name, dbo.Salary.Static_Company_Insurance, dbo.Salary.Dynamic_Company_Insurance, dbo.Salary.Static_Employee_Insurance, dbo.Salary.Dynamic_Employee_Insurance, "+
             "dbo.Salary.StaticContainer, dbo.Salary.DynamicContainer ,(dbo.Salary.Static_Company_Insurance + dbo.Salary.Dynamic_Company_Insurance + dbo.Salary.Static_Employee_Insurance + dbo.Salary.Dynamic_Employee_Insurance) "+
             "FROM dbo.Salary INNER JOIN "+
             "dbo.Employee ON dbo.Salary.AIO_Code = dbo.Employee.AIO_Code INNER JOIN dbo.Departments ON dbo.Employee.Depart_ID = dbo.Departments.Department_Number " +
             "where Month(dbo.Salary.Payment_D) = @M and Year(dbo.Salary.Payment_D) = @Y and dbo.Departments.Department_Number = @DN and dbo.Employee.Working_Type = @WT";
            salaryCommand.Parameters.Add("@Y", Year);
            salaryCommand.Parameters.Add("@M", Month);
            salaryCommand.Parameters.Add("@WT", Wt.ToString());
            salaryCommand.Parameters.Add("@DN", DeptID);
            SqlDataReader X = salaryCommand.ExecuteReader();
            D.Load(X);
            X.Close();
            return D;
        }
        #endregion


        public void AddSpecialEmployee(Employee emp,DateTime Payment_D)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText = "INSERT INTO Employee (Full_Name,AIO_Code,Date_of_Birth,Hiring_D,Termination_D,Contract_Type,Working_Type,E_Degree,Depart_ID,N_ID,E_Type)" +
            " VALUES(@FN,@AIOID,@DOB,@HD,@TD,@CT,@WT,@ED,@Depart_ID,@NID,2);";
            employeeCommand.Parameters.Add("@FN", emp.FullName);
            employeeCommand.Parameters.Add("@AIOID", emp.AIOID);
            //employeeCommand.Parameters.Add("@DOB", emp.DateOfBirth.Date);
            employeeCommand.Parameters.Add("@HD", emp.HiringDate.Date);
            employeeCommand.Parameters.Add("@TD", emp.TerminationDate.Date);
            employeeCommand.Parameters.Add("@ED", emp.CurrentDegree);
            //employeeCommand.Parameters.Add("@NID", emp.National_ID);
            employeeCommand.Parameters.Add("@Depart_ID", emp.Dept_ID);
            employeeCommand.Parameters.Add("@CT", "Temporary");
            employeeCommand.Parameters.Add("@WT", "Direct");

            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            employeeCommandWriter.Close();

            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "INSERT INTO Salary" +
           " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj" +
           ",Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
           " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,StaticContainer,DynamicContainer,Workers_Day,Workers_Day_Adj,Others," +
           "I_Type,@Total1_Adj,CooperativeBoxValue_2)" +
           " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA," +
           "@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV" +
           ",@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@SC,@DC,@WDS,@WDSA,@O,@IType,@T1A,@COP2);";

            salaryCommand.Parameters.Clear();
            emp.ProcessEmployee();

            salaryCommand.Parameters.Add("@main", emp.MainSalary);
            salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
            salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
            salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
            salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
            salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
            salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
            salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
            salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
            salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
            salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
            salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
            salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
            salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
            salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
            salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
            salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
            salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
            salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
            salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
            salaryCommand.Parameters.Add("@O", emp.Other);
            salaryCommand.Parameters.Add("@id", emp.AIOID);
            salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
            salaryCommand.Parameters.Add("@PY", Payment_D.ToShortDateString());
            salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
            salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
            salaryCommand.Parameters.Add("@T2", emp.Total2);
            salaryCommand.Parameters.Add("@T3", emp.Total3);
            salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
            salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@IType", emp.IType);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();
            SetNetDays_30();
        }

        public void AddSalary(Employee emp, DateTime D)
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandText = "INSERT INTO Salary" +
           " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Social_Raises_Release,Social_Raises_Release_Adj" +
           ",Net_Salary,Taxes_Apply,Insurances_Apply,Static_Company_Insurance,Dynamic_Company_Insurance,Static_Employee_Insurance,Dynamic_Employee_Insurance,Net_Tax_Affected_Value" +
           " ,Total_Tax_Affected_Value,Net_Taxes,Payment_D,AIO_Code,Working_Days,Total1,Total2,Total3,CooperativeBoxValue,ADiff,StaticContainer,DynamicContainer,Workers_Day,Workers_Day_Adj,Others," +
                                        "I_Type,Total1_Adj,CooperativeBoxValue_2)" +
           " VALUES (@main ,@WEA,@RA,@SR,@SRR,@SRRA," +
           "@NetSalary,@TA,@IA,@SCI,@DCI,@SEI,@DEI,@NTAV" +
           ",@TTAV,@NT,@PY,@id,@WD,@T1,@T2,@T3,@COP,0,@SC,@DC,@WDS,@WDSA,@O,@IType,@T1A,@COP2);";
            salaryCommand.Parameters.Add("@main", emp.MainSalary);
            salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
            salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
            salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
            salaryCommand.Parameters.Add("@SRR", emp.SocialRaisesRelease);
            salaryCommand.Parameters.Add("@SRRA", emp.SocialRaisesReleaseAdj);
            salaryCommand.Parameters.Add("@NetSalary", emp.NetSalary);
            salaryCommand.Parameters.Add("@TA", emp.TaxesApply);
            salaryCommand.Parameters.Add("@IA", emp.InsuranceApply);
            salaryCommand.Parameters.Add("@SCI", emp.StaticCompanyInsurance);
            salaryCommand.Parameters.Add("@DCI", emp.DynamicCompanyInsurance);
            salaryCommand.Parameters.Add("@SEI", emp.StaticEmployeeInsurance);
            salaryCommand.Parameters.Add("@DEI", emp.DynamicEmployeeInsurance);
            salaryCommand.Parameters.Add("@NTAV", emp.NetTaxAffectedValues);
            salaryCommand.Parameters.Add("@TTAV", emp.TotalTaxAffectedValues);
            salaryCommand.Parameters.Add("@NT", emp.NetTaxes);
            salaryCommand.Parameters.Add("@SC", emp.StaticContainer);
            salaryCommand.Parameters.Add("@DC", emp.DynamicContainer);
            salaryCommand.Parameters.Add("@WDS", emp.WorkersDay);
            salaryCommand.Parameters.Add("@WDSA", emp.WorkersDayAdj);
            salaryCommand.Parameters.Add("@O", emp.Other);
            salaryCommand.Parameters.Add("@id", emp.AIOID);
            salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
            salaryCommand.Parameters.Add("@PY", D.ToShortDateString());
            salaryCommand.Parameters.Add("@T1", emp.Total1); // New in Test
            salaryCommand.Parameters.Add("@T1A", emp.Adj_Total1); // New in Test
            salaryCommand.Parameters.Add("@T2", emp.Total2);
            salaryCommand.Parameters.Add("@T3", emp.Total3);
            salaryCommand.Parameters.Add("@COP", emp.CooperativeBoxValue);
            salaryCommand.Parameters.Add("@COP2", emp.CooperativeBoxValue_2);
            salaryCommand.Parameters.Add("@IType", emp.IType);
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter = salaryCommand.ExecuteReader();
            SalaryCommandWriter.Close();
        }

        public void insertPrevMain(List<Employee> Emps)
        {
            SqlCommand salaryCommand = new SqlCommand();
            salaryCommand.Connection = connection;
            salaryCommand.CommandType = CommandType.Text;
            SqlDataReader SalaryCommandWriter;

            foreach (Employee emp in Emps)
            {
                salaryCommand.CommandText = "INSERT INTO Salary" +
                                            " (Main_Salary,Work_Environment_Alternative,Representing_Alternative,Social_Raises,Payment_D,AIO_Code,Working_Days,Total1)" +
                                            " VALUES (@main ,@WEA,@RA,@SR,@PY,@id,@WD,@T1);";
                salaryCommand.Parameters.Clear();
                salaryCommand.Parameters.Add("@main", emp.MainSalary);
                salaryCommand.Parameters.Add("@WEA", emp.WorkEnvironmentAlt);
                salaryCommand.Parameters.Add("@RA", emp.RepresentingAlt);
                salaryCommand.Parameters.Add("@SR", emp.SocialRaises);
                salaryCommand.Parameters.Add("@PY", emp.PaymentDate);
                salaryCommand.Parameters.Add("@id", emp.AIOID);
                salaryCommand.Parameters.Add("@WD", emp.WorkingDays);
                salaryCommand.Parameters.Add("@T1", emp.Total1);
                SalaryCommandWriter = salaryCommand.ExecuteReader();
                SalaryCommandWriter.Close();
            }
        }





        public void AddEmployee(Employee emp)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            employeeCommand.CommandText =
                "INSERT INTO Employee (Full_Name,AIO_Code,Date_of_Birth,Hiring_D,Termination_D,Contract_Type,Working_Type,E_Degree,Depart_ID,N_ID,E_Type)" +
                " VALUES(@FN,@AIOID,@DOB,@HD,@TD,@CT,@WT,@ED,@Depart_ID,@NID,@Type);";
            employeeCommand.Parameters.Add("@FN", emp.FullName);
            employeeCommand.Parameters.Add("@AIOID", emp.AIOID);
            employeeCommand.Parameters.Add("@DOB", emp.DateOfBirth.Date);
            employeeCommand.Parameters.Add("@HD", emp.HiringDate.Date);
            employeeCommand.Parameters.Add("@TD", emp.TerminationDate.Date);
            employeeCommand.Parameters.Add("@ED", emp.CurrentDegree);
            
            employeeCommand.Parameters.Add("@Depart_ID", emp.Dept_ID);
            if (emp.CType == ContractType.Temporary)
                employeeCommand.Parameters.Add("@CT", "Temporary");
            else if (emp.CType == ContractType.Permenant)
                employeeCommand.Parameters.Add("@CT", "Permenant");
            if (emp.WType == WorkingType.Direct)
                employeeCommand.Parameters.Add("@WT", "Direct");
            else if (emp.WType == WorkingType.InDirect)
                employeeCommand.Parameters.Add("@WT", "InDirect");
            if (emp.EType == EmploymentType.EmployeeType)
                employeeCommand.Parameters.Add("@Type", EmploymentType.EmployeeType);
            else if (emp.EType == EmploymentType.PensionType)
                employeeCommand.Parameters.Add("@Type", EmploymentType.PensionType);
            else employeeCommand.Parameters.Add("@Type", EmploymentType.Awarded);

            if (emp.National_ID != null)
            employeeCommand.Parameters.Add("@NID", emp.National_ID);
            else
            {
                emp.National_ID = 28701290100551.ToString();
                employeeCommand.Parameters.Add("@NID", emp.National_ID);
            }

            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            employeeCommandWriter.Close();
        }



























        #region Salary Reports Specified
            public DataTable Sum1(DateTime D,EmploymentType EType,WorkingType WT)
            {
                SqlCommand employeeCommand = new SqlCommand();
                employeeCommand.Connection = connection;
                DataTable DT = new DataTable();
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Salary.Main_Salary_Adj), "+
                    "SUM(dbo.Salary.Work_Environment_Alternative_Adj), "+
                    "SUM(dbo.Salary.Representing_Alternative_Adj), " +
                    "SUM(dbo.Salary.Social_Raises_Adj), " +
                    "SUM(dbo.Salary.Workers_Day_Adj), " +
                    "SUM(dbo.Salary.Static_Company_Insurance), " +
                    "SUM(dbo.Salary.Dynamic_Company_Insurance)," +
                    "SUM(dbo.Salary.CooperativeBoxValue + dbo.Salary.CooperativeBoxValue_2)," +
                    "SUM(dbo.Salary.Net_Taxes)," +
                    "SUM(dbo.Salary.Dynamic_Employee_Insurance)," +
                    "SUM(dbo.Salary.Static_Employee_Insurance) " +
                    "FROM dbo.Employee INNER JOIN dbo.Salary ON dbo.Employee.AIO_Code = dbo.Salary.AIO_Code " +
                    "where MONTH(dbo.Salary.Payment_D) = @Month and " +
                    "YEAR(dbo.Salary.Payment_D) = @Year and dbo.Employee.E_Type = @Type and dbo.Employee.Working_Type = @WType";
                employeeCommand.Parameters.Add("@Month", D.Month);
                employeeCommand.Parameters.Add("@Year", D.Year);
                switch (EType)
                {
                    case EmploymentType.EmployeeType:
                        employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString()));
                        break;
                        
                    case EmploymentType.PensionType:
                        employeeCommand.Parameters.Add("@Type", 1);
                        break;
                    case EmploymentType.Awarded:
                        employeeCommand.Parameters.Add("@Type", 2);
                        break;
                }
                switch (WT)
                {
                    case WorkingType.Direct: employeeCommand.Parameters.Add("@WType", "Direct    "); break;
                    case WorkingType.InDirect: employeeCommand.Parameters.Add("@WType", "InDirect  "); break;
                }
                SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                DT.Load(employeeCommandWriter);
                employeeCommandWriter.Close();
                return DT;
            }
            public DataTable Sum2(DateTime D, EmploymentType EType, WorkingType WT)
            {
                SqlCommand employeeCommand = new SqlCommand();
                employeeCommand.Connection = connection;
                DataTable DT = new DataTable();
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Bonuses.Morning_Hours_Bonus_Value), " +
                    "SUM(dbo.Bonuses.Afternoon_Hours_Bonus_Value), " +
                    "SUM(dbo.Bonuses.Night_Hours_Bonus_Value), " +
                    "SUM(dbo.Bonuses.Extra_Shifts_Bonus_Value) " +
                    "FROM dbo.Employee INNER JOIN dbo.Bonuses ON dbo.Employee.AIO_Code = dbo.Bonuses.AIO_Code " +
                    "where MONTH(dbo.Bonuses.Payment_D) = @Month and " +
                    "YEAR(dbo.Bonuses.Payment_D) = @Year and dbo.Employee.E_Type = @Type and dbo.Employee.Working_Type = @WType";
                employeeCommand.Parameters.Add("@Month", D.Month);
                employeeCommand.Parameters.Add("@Year", D.Year);
                switch (EType)
                {
                    case EmploymentType.EmployeeType:
                        employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString()));
                        break;
                    case EmploymentType.PensionType:
                        employeeCommand.Parameters.Add("@Type", 1);
                        break;
                    case EmploymentType.Awarded:
                        employeeCommand.Parameters.Add("@Type", 2);
                        break;
                }
                switch (WT)
                {
                    case WorkingType.Direct: employeeCommand.Parameters.Add("@WType", "Direct    "); break;
                    case WorkingType.InDirect: employeeCommand.Parameters.Add("@WType", "InDirect  "); break;
                }
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                DT.Load(employeeCommandWriter);
                employeeCommandWriter.Close();
                return DT;
            }
            public DataTable Sum3(DateTime D, EmploymentType EType, WorkingType WT)
            {
                SqlCommand employeeCommand = new SqlCommand();
                employeeCommand.Connection = connection;
                DataTable DT = new DataTable();
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Minuses.Sickness_Minus_Value), " +
                    "SUM(dbo.Minuses.Abscence_Minus_Value), " +
                    "SUM(dbo.Minuses.Penalty_Minus_Value) " +
                    "FROM dbo.Employee INNER JOIN dbo.Minuses ON dbo.Employee.AIO_Code = dbo.Minuses.AIO_Code " +
                    "where MONTH(dbo.Minuses.Payment_D) = @Month and " +
                    "YEAR(dbo.Minuses.Payment_D) = @Year and dbo.Employee.E_Type = @Type and dbo.Employee.Working_Type = @WType";
                employeeCommand.Parameters.Add("@Month", D.Month);
                employeeCommand.Parameters.Add("@Year", D.Year);
                switch (EType)
                {
                    case EmploymentType.EmployeeType:
                        employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString()));
                        break;

                    case EmploymentType.PensionType:
                        employeeCommand.Parameters.Add("@Type", 1);
                        break;
                    case EmploymentType.Awarded:
                        employeeCommand.Parameters.Add("@Type", 2);
                        break;
                }
                switch (WT)
                {
                    case WorkingType.Direct: employeeCommand.Parameters.Add("@WType", "Direct    "); break;
                    case WorkingType.InDirect: employeeCommand.Parameters.Add("@WType", "InDirect  "); break;
                }
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                DT.Load(employeeCommandWriter);
                employeeCommandWriter.Close();
                return DT;
            }
            public DataTable Sum4(DateTime D, EmploymentType EType, InstallmentsTypes IType, WorkingType WT)
                {
                    SqlCommand employeeCommand = new SqlCommand();
                    employeeCommand.Connection = connection;
                    DataTable DT = new DataTable();
                    employeeCommand.CommandText =
                        "SELECT SUM(dbo.Installments.Monthly_Value) "+
                        "FROM dbo.Employee INNER JOIN dbo.Installments ON dbo.Employee.AIO_Code = dbo.Installments.AIO_Code " +
                        "where MONTH(dbo.Installments.Start_Payment) = @Month and YEAR(dbo.Installments.Start_Payment) = @Year and " +
                        "dbo.Employee.E_Type = @Type2 and dbo.Installments.Identity_Number = @Type and dbo.Employee.Working_Type = @WType";

                    employeeCommand.Parameters.Add("@Month", D.Month);
                    employeeCommand.Parameters.Add("@Year", D.Year);
                    switch (IType)
                    {
                        case InstallmentsTypes.CompanyLoan:employeeCommand.Parameters.Add("@Type", 6); break;
                        case InstallmentsTypes.Computer: employeeCommand.Parameters.Add("@Type", 3); break;
                        case InstallmentsTypes.Devices: employeeCommand.Parameters.Add("@Type", 4); break;
                        case InstallmentsTypes.Hajj: employeeCommand.Parameters.Add("@Type", 0); break;
                        case InstallmentsTypes.Omra: employeeCommand.Parameters.Add("@Type", 1); break;
                        case InstallmentsTypes.Trip: employeeCommand.Parameters.Add("@Type", 2); break;
                        case InstallmentsTypes.Residence: employeeCommand.Parameters.Add("@Type", 7); break;
                    }
                    switch (EType)
                    {
                        case EmploymentType.EmployeeType:
                            employeeCommand.Parameters.Add("@Type2", int.Parse(0.ToString()));
                            break;

                        case EmploymentType.PensionType:
                            employeeCommand.Parameters.Add("@Type2", 1);
                            break;
                        case EmploymentType.Awarded:
                            employeeCommand.Parameters.Add("@Type2", 2);
                            break;
                    }
                    switch (WT)
                    {
                        case WorkingType.Direct: employeeCommand.Parameters.Add("@WType", "Direct    "); break;
                        case WorkingType.InDirect: employeeCommand.Parameters.Add("@WType", "InDirect  "); break;
                    }
                SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                    DT.Load(employeeCommandWriter);
                    employeeCommandWriter.Close();
                    return DT;
                }
        #endregion



        #region Salary Reports Total
            public DataTable Sum1(DateTime D, EmploymentType EType)
            {
                SqlCommand employeeCommand = new SqlCommand();
                employeeCommand.Connection = connection;
                DataTable DT = new DataTable();
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Salary.Main_Salary_Adj), " +
                    "SUM(dbo.Salary.Work_Environment_Alternative_Adj), " +
                    "SUM(dbo.Salary.Representing_Alternative_Adj), " +
                    "SUM(dbo.Salary.Social_Raises_Adj), " +
                    "SUM(dbo.Salary.Workers_Day_Adj), " +
                    "SUM(dbo.Salary.Static_Company_Insurance), " +
                    "SUM(dbo.Salary.Dynamic_Company_Insurance)," +
                    "SUM(dbo.Salary.CooperativeBoxValue + dbo.Salary.CooperativeBoxValue_2)," +
                    "SUM(dbo.Salary.Net_Taxes)," +
                    "SUM(dbo.Salary.Dynamic_Employee_Insurance)," +
                    "SUM(dbo.Salary.Static_Employee_Insurance) " +
                    "FROM dbo.Employee INNER JOIN dbo.Salary ON dbo.Employee.AIO_Code = dbo.Salary.AIO_Code " +
                    "where MONTH(dbo.Salary.Payment_D) = @Month and " +
                    "YEAR(dbo.Salary.Payment_D) = @Year and dbo.Employee.E_Type = @Type";
                employeeCommand.Parameters.Add("@Month", D.Month);
                employeeCommand.Parameters.Add("@Year", D.Year);
                switch (EType)
                {
                    case EmploymentType.EmployeeType:
                        employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString()));
                        break;

                    case EmploymentType.PensionType:
                        employeeCommand.Parameters.Add("@Type", 1);
                        break;
                    case EmploymentType.Awarded:
                        employeeCommand.Parameters.Add("@Type", 2);
                        break;
                }
                SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                DT.Load(employeeCommandWriter);
                employeeCommandWriter.Close();
                return DT;
            }
            public DataTable Sum2(DateTime D, EmploymentType EType)
            {
                SqlCommand employeeCommand = new SqlCommand();
                employeeCommand.Connection = connection;
                DataTable DT = new DataTable();
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Bonuses.Morning_Hours_Bonus_Value), " +
                    "SUM(dbo.Bonuses.Afternoon_Hours_Bonus_Value), " +
                    "SUM(dbo.Bonuses.Night_Hours_Bonus_Value), " +
                    "SUM(dbo.Bonuses.Extra_Shifts_Bonus_Value) " +
                    "FROM dbo.Employee INNER JOIN dbo.Bonuses ON dbo.Employee.AIO_Code = dbo.Bonuses.AIO_Code " +
                    "where MONTH(dbo.Bonuses.Payment_D) = @Month and " +
                    "YEAR(dbo.Bonuses.Payment_D) = @Year and dbo.Employee.E_Type = @Type";
                employeeCommand.Parameters.Add("@Month", D.Month);
                employeeCommand.Parameters.Add("@Year", D.Year);
                switch (EType)
                {
                    case EmploymentType.EmployeeType:
                        employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString()));
                        break;

                    case EmploymentType.PensionType:
                        employeeCommand.Parameters.Add("@Type", 1);
                        break;
                    case EmploymentType.Awarded:
                        employeeCommand.Parameters.Add("@Type", 2);
                        break;
                }
                SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                DT.Load(employeeCommandWriter);
                employeeCommandWriter.Close();
                return DT;
            }
            public DataTable Sum3(DateTime D, EmploymentType EType)
            {
                SqlCommand employeeCommand = new SqlCommand();
                employeeCommand.Connection = connection;
                DataTable DT = new DataTable();
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Minuses.Sickness_Minus_Value), " +
                    "SUM(dbo.Minuses.Abscence_Minus_Value), " +
                    "SUM(dbo.Minuses.Penalty_Minus_Value) " +
                    "FROM dbo.Employee INNER JOIN dbo.Minuses ON dbo.Employee.AIO_Code = dbo.Minuses.AIO_Code " +
                    "where MONTH(dbo.Minuses.Payment_D) = @Month and " +
                    "YEAR(dbo.Minuses.Payment_D) = @Year and dbo.Employee.E_Type = @Type";
                employeeCommand.Parameters.Add("@Month", D.Month);
                employeeCommand.Parameters.Add("@Year", D.Year);
                switch (EType)
                {
                    case EmploymentType.EmployeeType:
                        employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString()));
                        break;

                    case EmploymentType.PensionType:
                        employeeCommand.Parameters.Add("@Type", 1);
                        break;
                    case EmploymentType.Awarded:
                        employeeCommand.Parameters.Add("@Type", 2);
                        break;
                }
                SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                DT.Load(employeeCommandWriter);
                employeeCommandWriter.Close();
                return DT;
            }
            public DataTable Sum4(DateTime D, EmploymentType EType, InstallmentsTypes IType)
                {
                    SqlCommand employeeCommand = new SqlCommand();
                    employeeCommand.Connection = connection;
                    DataTable DT = new DataTable();
                    employeeCommand.CommandText =
                        "SELECT SUM(dbo.Installments.Monthly_Value) " +
                        "FROM dbo.Employee INNER JOIN dbo.Installments ON dbo.Employee.AIO_Code = dbo.Installments.AIO_Code " +
                        "where MONTH(dbo.Installments.Start_Payment) = @Month and YEAR(dbo.Installments.Start_Payment) = @Year and " +
                        "dbo.Employee.E_Type = @Type2 and dbo.Installments.Identity_Number = @Type";

                    employeeCommand.Parameters.Add("@Month", D.Month);
                    employeeCommand.Parameters.Add("@Year", D.Year);
                    switch (IType)
                    {
                        case InstallmentsTypes.CompanyLoan: employeeCommand.Parameters.Add("@Type", 6); break;
                        case InstallmentsTypes.Computer: employeeCommand.Parameters.Add("@Type", 3); break;
                        case InstallmentsTypes.Devices: employeeCommand.Parameters.Add("@Type", 4); break;
                        case InstallmentsTypes.Hajj: employeeCommand.Parameters.Add("@Type", int.Parse(0.ToString())); break;
                        case InstallmentsTypes.Omra: employeeCommand.Parameters.Add("@Type", 1); break;
                        case InstallmentsTypes.Trip: employeeCommand.Parameters.Add("@Type", 2); break;
                        case InstallmentsTypes.Residence: employeeCommand.Parameters.Add("@Type", 7); break;
                    }
                    switch (EType)
                    {
                        case EmploymentType.EmployeeType:
                            employeeCommand.Parameters.Add("@Type2", int.Parse(0.ToString()));
                            break;

                        case EmploymentType.PensionType:
                            employeeCommand.Parameters.Add("@Type2", 1);
                            break;
                        case EmploymentType.Awarded:
                            employeeCommand.Parameters.Add("@Type2", 2);
                            break;
                    }
                    SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
                    DT.Load(employeeCommandWriter);
                    employeeCommandWriter.Close();
                    return DT;
                }
        #endregion

        #region Installments Data

        public float InstalmmentsValue(int InstID,int Year)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            DataTable DT = new DataTable();
            employeeCommand.CommandText =
                "SELECT SUM(Monthly_Value) FROM dbo.Installments where Identity_Number = @ID and YEAR(Start_Payment) = @YEAR";
            employeeCommand.Parameters.Add("@ID", InstID);
            employeeCommand.Parameters.Add("@YEAR", Year);
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            DT.Load(employeeCommandWriter);
            employeeCommandWriter.Close();
            var Value_ = DT.Rows[0].ItemArray[0].ToString();
            if (Value_ != string.Empty)
                return float.Parse(Value_.ToString());
            else return 0;
        }

        public float ContInstalmmentsValue(int InstID, string WT,EmploymentType ET)
        {
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            DataTable DT = new DataTable();

            if (WT == "All")
                employeeCommand.CommandText =
                "SELECT SUM(dbo.Cont_Install.Install_Value) FROM dbo.Cont_Install INNER JOIN" +
                    " dbo.Employee ON dbo.Cont_Install.AIO_Code = dbo.Employee.AIO_Code where dbo.Cont_Install.Install_Type = @T" +
                    " and dbo.Employee.E_Type = @ET";
            else
                employeeCommand.CommandText =
                    "SELECT SUM(dbo.Cont_Install.Install_Value) FROM dbo.Cont_Install INNER JOIN" +
                    " dbo.Employee ON dbo.Cont_Install.AIO_Code = dbo.Employee.AIO_Code where dbo.Cont_Install.Install_Type = @T" +
                    " and dbo.Employee.E_Type = @ET and dbo.Employee.Working_Type = @WT";

            employeeCommand.Parameters.Add("@T", InstID);
            employeeCommand.Parameters.Add("@ET", (int)ET);
            employeeCommand.Parameters.Add("@WT", WT);
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            DT.Load(employeeCommandWriter);
            employeeCommandWriter.Close();
            var Value_ = DT.Rows[0].ItemArray[0].ToString();
            if (Value_ != string.Empty)
                return float.Parse(Value_.ToString());
            else return 0;
        }
        #endregion

        public int intheckTwoSalaries(int AIOCode,int RenewType)
        {
            DateTime DNow = DateTime.Now;
            SqlCommand employeeCommand = new SqlCommand();
            employeeCommand.Connection = connection;
            DataTable DT = new DataTable();
            employeeCommand.CommandText =
                "SELECT Start_D from Renews where AIOID = @Code and MONTH(Start_D) = @Month and YEAR(Start_D) = @Year and RenewType = @Type";
            employeeCommand.Parameters.Add("@Month", DateTime.Now.Month);
            employeeCommand.Parameters.Add("@Year", DateTime.Now.Year);
            employeeCommand.Parameters.Add("@Code", AIOCode);
            employeeCommand.Parameters.Add("@Type", RenewType);
            SqlDataReader employeeCommandWriter = employeeCommand.ExecuteReader();
            if (!employeeCommandWriter.HasRows)
                return (-1);
            else
                return DateTime.Parse(employeeCommandWriter["Start_D"].ToString()).Day;
        }
    }
}