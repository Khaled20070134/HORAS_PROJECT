using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Horas_Reporting_2
{
    public partial class ConnectionData : Form
    {
        public ConnectionData()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Server = textBoxServer.Text;
            string Database = textBoxDB.Text;
            string UID = textBoxLogin.Text;
            string Password = textBoxPassword.Text;

            MasterData.ConnectionString = "Data Source=" + Server + ";" +
                  "Initial Catalog=" + Database + ";" +
                  "User ID=" + UID + ";PASSWORD=" + Password + ";Encrypt = False ;TrustServerCertificate=True  ";


            Settings1.Default.CS = MasterData.ConnectionString;
            Settings1.Default.Save();
            MasterData.LoadMasterData();
            if (MasterData.DatabaseConnected)
            {
                Settings1.Default.DataBaseName = Database;
                Settings1.Default.Server = Server;
                Settings1.Default.LoginID = UID;
                Settings1.Default.Password = Password;
                Settings1.Default.CS = MasterData.ConnectionString;
                Settings1.Default.Save();

                Startup Form = new Startup();
                Form.Show();
                Hide();
            }
            else
                MessageBox.Show("Database Configuration parameters error", "Parameters Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxServer.Text = "192.168.8.148";
            textBoxDB.Text = "HORAS";
            textBoxLogin.Text = "HorasLogin";
            textBoxPassword.Text = "20080134";
        }
    }
}
