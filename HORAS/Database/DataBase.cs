using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORAS.Database
{
    public class DataBase
    {
        static SqlConnection connection =
           new SqlConnection(@"Data Source=DESKTOP-P3USC9V;Initial Catalog=HORAS;Persist Security Info=True;User ID=HID;Password=20080134;Encrypt=False;TrustServerCertificate=True");

       


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


        public void LoadContractorsAndOwners()
        {
            //SqlCommand insuranceCommand = new SqlCommand();
            //insuranceCommand.Connection = connection;
            //insuranceCommand.CommandText =
            //    "select * from Party";
            //insuranceCommand.CommandType = CommandType.Text;
            //SqlDataReader DataReader = insuranceCommand.ExecuteReader();
            //while (DataReader.Read())
            //{
            //    Contractor NewC = new Contractor();
            //    NewC.ID = int.Parse(DataReader["ID"].ToString());
            //    NewC.Name = DataReader["Name"].ToString();
            //    NewC.Address = DataReader["Address"].ToString();
            //    NewC.TaxRegNumber = DataReader["TaxRegNumber"].ToString();
            //    MasterData.OwnersAndContractors.Add(NewC);
            //}

            //DataReader.Close();
        }

    }
}
