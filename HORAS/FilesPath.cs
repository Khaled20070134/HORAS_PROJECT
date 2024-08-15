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
    public partial class FilesPath : Form
    {
        public FilesPath()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBoxFile.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxFile.Text == string.Empty)
            { MessageBox.Show("no Directory selected"); return; }

            Settings1.Default.DB_Files = textBoxFile.Text;
            Settings1.Default.Save();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
