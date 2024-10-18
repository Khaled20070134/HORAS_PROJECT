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
    public partial class FilePath_R : Form
    {
        public FilePath_R()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxFile.Text == string.Empty)
            { MessageBox.Show("no file selected"); return; }

            Settings1.Default.Reporting_URL = textBoxFile.Text;
            Settings1.Default.Save();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "Database Files (*.exe) | *.exe;";
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                textBoxFile.Text = FileDialoge.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
