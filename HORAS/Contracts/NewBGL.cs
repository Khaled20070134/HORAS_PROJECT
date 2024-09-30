using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
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
using static HORAS.Database.HorasDataSet;
using static HORAS.Enums;

namespace HORAS.Contracts
{
    public partial class NewBGL : Form
    {

        DateTime EndDate = DateTime.Now;

        public NewBGL()
        {
            InitializeComponent();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        void LoadData()
        {
            ContractNoLBL.Items.Clear();
            ContractNoVLBL.Items.Clear();

            MasterData.Contracts.RefreshList();

            var contratclist = MasterData.Contracts.ContractDataTable.Where(X => X.Signed == true
            && !X.FI_Completed &&  X.Contract_type == (int)ContractType.OwnerContract).ToList();

            foreach (var x in contratclist)
            {
                int ContractID = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == x.Number).ID;
                if (MasterData.Contracts.BGLDataTable.Count(X => X.ContractID == ContractID) == 0)
                    ContractNoLBL.Items.Add(x.Number);
                if (MasterData.Contracts.BGLDataTable.Count(X => X.ContractID == ContractID) == 1)
                    ContractNoVLBL.Items.Add(x.Number);
            }
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

        private void BGLSerial_Leave(object sender, EventArgs e)
        {
            if (BGLSerial.Text == string.Empty) return;
            var R = MasterData.Contracts.BGLDataTable.FirstOrDefault(X => X.Serial == BGLSerial.Text);
            if (R != null)
            {
                setStatus("هذا المسلسل تم إستخدامه من قبل", 0);
                BGLSerial.Text = string.Empty;
            }
        }

        private void ContractNoLBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContractNoLBL.SelectedIndex == -1) return;
            string ContractNumber = ContractNoLBL.SelectedItem.ToString();
            int ID = MasterData.Contracts.ContractDataTable.FirstOrDefault(X => X.Number == ContractNumber).ID;
            DateTime ContractEndDate = MasterData.Contracts.ContractDataTable.FindByID(ID).CreationDate;
            int Duration = MasterData.Contracts.ContractDataTable.FindByID(ID).Duration;
            EndDate = ContractEndDate.AddMonths(Duration);
            //labelEndDate.Text = EndDate.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (ContractNoLBL.SelectedIndex == -1)
            {
                setStatus("يجب إختيار تعاقد مالك أولاً", 0);
                return;
            }
            if (BGLSerial.Text == string.Empty)
            {
                setStatus("يجب تسجيل رقم خطاب الضمان", 0);
                return;
            }

            if (NUDBGLAmount.Value == 0)
            {
                setStatus("يجب أن تكون قيمة خطاب الضمان أكبر من صفر", 0);
                return;
            }

            var NewBGL = MasterData.Contracts.BGLDataTable.NewBGLRow();
            NewBGL.ID = 0;
            NewBGL.Amount = (double)NUDBGLAmount.Value;
            NewBGL.Serial = BGLSerial.Text;
            NewBGL.Status = (int)Enums.BGLStatus.Active;
            NewBGL.EndDate = DTPEnd.Value;
            NewBGL.ContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == ContractNoLBL.SelectedItem.ToString()).ID;

            MasterData.Contracts.AddNewBGL(NewBGL);

            if (textBoxBGLFile.Text != string.Empty)
            {
                string FileName = (char)Document_Type.BankGuranteeLetter + "_" + NewBGL.Serial;
                MasterData.CopyFile(textBoxBGLFile.Text, FileName);
            }
            setStatus("تم ستجيل خطاب الضمان", 1);
            BGLSerial.Text = textBoxBGLFile.Text = string.Empty;
            NUDBGLAmount.Value = 0;
            ContractNoLBL.SelectedItem = string.Empty;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.Filter = "pdf files (*.pdf)|*.pdf";
            FileDialoge.InitialDirectory = Application.StartupPath;
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                textBoxBGLFile.Text = FileDialoge.FileName;
        }

        private void ContractNoVLBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContractNoVLBL.SelectedIndex == -1) return;
            int ContractID = MasterData.Contracts.ContractDataTable.
                FirstOrDefault(X => X.Number == ContractNoVLBL.SelectedItem.ToString()).ID;
            var ContractData = MasterData.Contracts.BGLDataTable.FirstOrDefault(X => X.ContractID == ContractID);

            labelDateU.Text = ContractData.EndDate.ToShortDateString();
            labelSerialU.Text = ContractData.Serial;
            labelAmountU.Text = MasterData.NumericString(ContractData.Amount);
            switch (ContractData.Status)
            {
                case 0: labelStatusU.Text = "سارى"; break;
                case 1: labelStatusU.Text = "غير سارى"; break;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            textBoxBGLFile.Text = string.Empty;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (ContractNoVLBL.SelectedIndex == -1) { setStatus("يجب إختيار التعاقد أولاً", 0); return; }
            string FilePath = MasterData.GetFile((char)Document_Type.BankGuranteeLetter + "_" + labelSerialU.Text);
            if (FilePath == string.Empty)
                setStatus("لا يوجد ملف محفظ لهذا الخطاب", 0);
            else MasterData.OpenFile(FilePath);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (ContractNoVLBL.SelectedIndex == -1) { setStatus("يجب إختيار التعاقد أولاً", 0); return; }
            int ID = MasterData.Contracts.BGLDataTable.FirstOrDefault(X => X.Serial == labelSerialU.Text).ID;
            MasterData.Contracts.DeleteBGL(ID);
            setStatus("تم مسح خطاب الضمان", 1);
            labelStatusU.Text = labelSerialU.Text = labelDateU.Text = labelAmountU.Text = string.Empty;
        }

        private void ContractNoLBL_DropDown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ContractNoVLBL_DropDown(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
