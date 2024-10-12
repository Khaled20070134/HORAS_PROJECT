using HORAS.Database;
using HORAS.Interims_Data;
using HORAS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HORAS.Contracts
{
    public partial class ContractExpanses : Form
    {
        int SelectedContractID = 0;
        bool selectedExpsConfirmStatus = false;
        List<HorasDataSet.AssItemsRow> ContractItems = new List<HorasDataSet.AssItemsRow>();
        bool TransNeedConfirm = false;
        decimal OldUpdateAmount = 0;

        List<HorasDataSet.ExpTransRow> LoadedExpanses = new List<HorasDataSet.ExpTransRow>();
        List<HorasDataSet.ExpTransRow> DisplayExpanses = new List<HorasDataSet.ExpTransRow>();

        public ContractExpanses()
        {
            InitializeComponent();

            // Load Contracts
            var ContractsList = MasterData.Contracts.ContractDataTable.Where(X => X.FI_Completed == false
            && X.Signed && !X.IsStartDateNull()).ToList();
            foreach (var Cont in ContractsList)
                CBContract.Items.Add(Cont.Number);

            // Load Titles
            foreach (var ExpJ in MasterData.Contracts.JExpansesDateTable.ToList())
            {
                CBExpMajor.Items.Add(ExpJ.Title);
                CBMajorU.Items.Add(ExpJ.Title);
            }

            // Load Start Date
            labelUserName.Text = MasterData.LoggedEmployee.First_name;
            labelDate.Text = DateTime.Now.ToLongDateString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.InitialDirectory = Application.StartupPath;
            FileDialoge.Filter = "pdf files (*.pdf;*.png;*.jpg;)|*.pdf;*.png;*.jpg;*.jpeg;";
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                textBoxFile.Text = FileDialoge.FileName;
        }

        bool NewExpansesOK()
        {
            if (NUDAmount.Value == 0) return false;
            if (CBExpMajor.SelectedIndex == -1 || CBContract.SelectedIndex == -1
                || CBExpMinor.SelectedIndex == -1) return false;
            if (textBoxFile.Text == string.Empty) return false;
            return true;
        }

        bool checkItemLOL(string ItemNumber, decimal Amount)
        {
            return
                 MasterData.Contracts.LOLCheckOK((double)Amount,
                 CBContract.SelectedItem.ToString(), ItemNumber);
        }



        int AddExps(string ItemNumber, decimal Amount, bool NC)
        {
            int ID = 0;
            HorasDataSet.ExpTransRow NewExpRow = MasterData.Contracts.ExpTrDataTable.NewExpTransRow();
            int EXPID = MasterData.Contracts.IExpansesDateTable.
                FirstOrDefault(X => X.Title == CBExpMinor.SelectedItem.ToString()).ID;

            int ItemID = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault
                (X => X.Contract_ID == SelectedContractID && X.Number == ItemNumber).ID;

            NewExpRow.ID = 0;
            NewExpRow.ExpID = EXPID;
            NewExpRow.ItemNo = ItemID;
            NewExpRow.Tr_Date = DateTime.Now;
            NewExpRow.Amount = (double)Amount;
            NewExpRow.ContractID = SelectedContractID;
            NewExpRow.CreatedBy = MasterData.LoggedEmployee.ID;
            NewExpRow.Description = textBoxDesc.Text;
            NewExpRow.AttachFile = textBoxFile.Text;
            NewExpRow.NeedConf = NC;
            ID = MasterData.Contracts.AddExp(NewExpRow, CBContract.SelectedItem.ToString());
            MasterData.Contracts.RefreshList();
            UpdateTotalExps();
            return ID;
        }


        void CopyFiles(int ID)
        {
            if (!Path.Exists(Settings1.Default.DB_Files))
            {
                FilesPath Filepath = new FilesPath();
                Filepath.ShowDialog();
            }
            if (textBoxFile.Text != string.Empty)
            {
                string File1Name = "E_" + ID.ToString();
                MasterData.CopyFile(textBoxFile.Text, File1Name);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (NewExpansesOK())
            {
                if (checkBox.Checked)
                {
                    decimal Amount = NUDAmount.Value;
                    TransNeedConfirm = checkItemLOL(CBItems.SelectedItem.ToString(), Amount);
                    int ExpID = AddExps(CBItems.SelectedItem.ToString(), NUDAmount.Value, TransNeedConfirm);
                    CopyFiles(ExpID);
                }
                else
                {
                    decimal Amount = NUDAmount.Value / ContractItems.Count;
                    foreach (var Item in ContractItems)
                    {
                        TransNeedConfirm = checkItemLOL(Item.Number, Amount);
                        int ExpID = AddExps(Item.Number, Amount, TransNeedConfirm);
                        CopyFiles(ExpID);
                    }
                }
                setStatus("تم إضافة المصروف", 1);
                LoadExpanses();
            }
            else
                setStatus("برجاء مراجعه بيانات المصروف", 0);
        }

        private void CBExpMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBExpMajor.SelectedIndex == -1) return;

            MasterData.Contracts.RefreshList();
            int HeadID = MasterData.Contracts.JExpansesDateTable.
                FirstOrDefault(X => X.Title == CBExpMajor.SelectedItem.ToString()).ID;

            CBExpMinor.Items.Clear();

            foreach (var Exp in MasterData.Contracts.IExpansesDateTable.Where(X => X.HeadID == HeadID).ToList())
                CBExpMinor.Items.Add(Exp.Title);
        }

        void LoadContractData()
        {
            SelectedContractID = MasterData.Contracts.ContractDataTable.
              FirstOrDefault(X => X.Number == CBContract.SelectedItem.ToString()).ID;

            UpdateTotalExps();

            labelConPer.Text = (MasterData.Contracts.ContractDataTable.FirstOrDefault
                (X=>X.ID == SelectedContractID).ProfitPercentage * 100) .ToString() + " %";

            ContractItems.Clear();

            CBItems.Items.Clear();
            CBConfirm.Items.Clear();
            CBItemsdisplay.Items.Clear();

            ContractItems = MasterData.assessments.AssItemsAdapter.NotNullContracts().
                Where(X => X.Contract_ID == SelectedContractID).ToList();
            foreach (var Item in ContractItems)
            {
                CBItems.Items.Add(Item.Number);
                CBConfirm.Items.Add(Item.Number);
                CBItemsdisplay.Items.Add(Item.Number);
            }
        }

        private void CBContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContractData();

        }

        void UpdateTotalExps()
        {
            double Sum = MasterData.Contracts.ExpTrDataTable.
                Where(X => X.ContractID == SelectedContractID).Sum(Y => Y.Amount);
            labelTotalC.Text = Sum.ToString();
        }






        private void CBMinorU_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CBMinorU.SelectedIndex != -1)
            //{

            //    int SelectedExpID = MasterData.Contracts.IExpansesDateTable.
            //        FirstOrDefault(X => X.Title == CBMinorU.SelectedItem.ToString()).ID;

            //    var TransactionsList = MasterData.Contracts.ExpTrDataTable.
            //        Where(X => X.ContractID == SelectedContractID && X.ExpID == SelectedExpID).ToList();

            //    foreach (var Tr in TransactionsList)
            //        listBoxItemsU.Items.Add(Tr.ID);
            //}
        }

        private void listBoxItemsU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItemsU.SelectedIndex == -1) return;
            int SelectedTrID = int.Parse(listBoxItemsU.SelectedItem.ToString());

            HorasDataSet.ExpTransRow SelectedExps = DisplayExpanses.
               FirstOrDefault(X => X.ID == SelectedTrID);


            int HeadID = MasterData.Contracts.IExpansesDateTable.
              FindByID(SelectedExps.ExpID).HeadID;
            string Text1 = MasterData.Contracts.JExpansesDateTable.FindByID(HeadID).Title;
            string Text2 =
                MasterData.Contracts.IExpansesDateTable.FirstOrDefault
                (X => X.ID == SelectedExps.ExpID).Title;

            CBMajorU.SelectedIndex = CBMajorU.Items.IndexOf(Text1);
            CBMinorU.SelectedIndex = CBMinorU.Items.IndexOf(Text2);

            textBoxDescU.Text = SelectedExps.Description;
            labelDateU.Text = SelectedExps.Tr_Date.ToLongDateString();
            labelCreatedU.Text = MasterData.employees.EmployeesDataTable.FindByID(SelectedExps.CreatedBy).FirstName;
            NUDAmountU.Value = OldUpdateAmount = (decimal)SelectedExps.Amount;




        }

        private void CBMajorU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMajorU.SelectedIndex == -1) return;

            int HeadID = MasterData.Contracts.JExpansesDateTable.
                FirstOrDefault(X => X.Title == CBMajorU.SelectedItem.ToString()).ID;

            CBMinorU.Items.Clear();

            foreach (var Exp in MasterData.Contracts.IExpansesDateTable.Where(X => X.HeadID == HeadID).ToList())
                CBMinorU.Items.Add(Exp.Title);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBoxItemsU.SelectedIndex != -1)
            {
                if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
                {
                    setStatus("ليس لديك الصلاحية لمسح المصروف", 0);
                    return;
                }

                DialogResult D = MessageBox.Show("هل أنت متأكد من مسح المصروف ؟", "تأكيد للمسح",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (D == DialogResult.Yes)
                {
                    int SelectedTrID = int.Parse(listBoxItemsU.SelectedItem.ToString());
                    MasterData.DeleteFile(MasterData.GetFile("E_" + SelectedTrID.ToString()));

                    int ID = int.Parse(listBoxItemsU.SelectedItem.ToString());
                    MasterData.Contracts.DeleteExp(ID, CBContract.SelectedItem.ToString());
                    setStatus("تم مسح المصروف", 1);
                    MasterData.Contracts.RefreshList();
                    listBoxItemsU.Items.RemoveAt(listBoxItemsU.SelectedIndex);
                    UpdateTotalExps();
                    NUDAmountU.Value = 0;
                    textBoxDescU.Text = string.Empty;
                }
            }
        }

        bool CheckUpdate()
        {
            if (CBContract.SelectedIndex == -1) return false;
            if (listBoxItemsU.SelectedIndex == -1) return false;
            if (NUDAmountU.Value == 0) return false;
            if (CBMajorU.SelectedIndex == -1) return false;
            if (CBMinorU.SelectedIndex == -1) return false;
            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MasterData.LoggedEmployee.Role == Enums.Job_Roles.DataEntry)
            {
                setStatus("ليس لديك الصلاحية لمسح المصروف", 0);
                return;
            }


            if (CheckUpdate())
            {
                int TrID = int.Parse(listBoxItemsU.SelectedItem.ToString());
                var TrRow = MasterData.Contracts.ExpTrDataTable.FindByID(TrID);
                TrRow.Amount = (double)NUDAmountU.Value;
                TrRow.Description = textBoxDescU.Text;
                TrRow.ExpID = MasterData.Contracts.IExpansesDateTable.
                    FirstOrDefault(X => X.Title == CBMinorU.SelectedItem.ToString()).ID;

                double Dif = ((double)OldUpdateAmount - TrRow.Amount);

                TrRow.NeedConf =
                    !MasterData.Contracts.LOLCheckOK(Dif, CBContract.
                    SelectedItem.ToString(), CBItemsdisplay.SelectedItem.ToString());


                MasterData.Contracts.UpdateExps(TrRow, CBContract.SelectedItem.ToString());
                setStatus("تم تعديل المصروف", 1);
                MasterData.Contracts.RefreshList();
                OldUpdateAmount = NUDAmountU.Value;


                // check if file updated
                if (textBoxFileUpdate.Text != string.Empty)
                {
                    int SelectedTrID = int.Parse(listBoxItemsU.SelectedItem.ToString());
                    string PathToDelete = MasterData.GetFile("E_" + SelectedTrID.ToString());

                    MasterData.DeleteFile(PathToDelete);
                    string File1Name = "E_" + SelectedTrID.ToString();
                    MasterData.CopyFile(textBoxFileUpdate.Text, File1Name);
                }

            }
            else setStatus("برجاء مراجعه بيانات المصروف قبل التعديل", 0);
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CBItems.Enabled = checkBox.Checked;
        }

        private void CBConfirm_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadExpanses();
            if (CBConfirm.SelectedIndex != -1 && CBContract.SelectedIndex != -1)
            {
                string ItemNum = CBConfirm.SelectedItem.ToString();
                string ContractNum = CBContract.SelectedItem.ToString();

                labelconfirmremainexp.Text =
                    MasterData.NumericString((double)MasterData.Interim.Get_Item_Status(ContractNum, ItemNum).Remain_Exps);
            }
        }

        private void listBoxExps_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedExpsID = int.Parse(listBoxExps.SelectedItem.ToString());
            HorasDataSet.ExpTransRow E = LoadedExpanses.FirstOrDefault(X => X.ID == SelectedExpsID);
            labelAmountC.Text = MasterData.NumericString((double)E.Amount);
            labelDescC.Text = E.Description;
            labelDateC.Text = E.Tr_Date.ToLongDateString();
            int HeadID = MasterData.Contracts.IExpansesDateTable.
                FindByID(E.ExpID).HeadID;
            labelExps1C.Text = MasterData.Contracts.JExpansesDateTable.FindByID(HeadID).Title;
            labelExps2C.Text =
                MasterData.Contracts.IExpansesDateTable.FirstOrDefault
                (X => X.ID == E.ExpID).Title;
            labelCreatedByC.Text = MasterData.employees.EmployeesDataTable.FindByID(E.CreatedBy).FirstName;
            switch (E.NeedConf)
            {
                case false:
                    LabelCStatus.Text = "تم تأكيد المصروف";
                    selectedExpsConfirmStatus = true; break;
                case true:
                    LabelCStatus.Text = "لم يتم تأكيد المصروف";
                    selectedExpsConfirmStatus = false; break;
            }
        }
        void DisplayExps()
        {
            if (CBItemsdisplay.SelectedIndex == -1) return;
            listBoxItemsU.Items.Clear();
            int ItemID = MasterData.assessments.AssItemsDataTable.FirstOrDefault
                (X => X.Contract_ID == SelectedContractID &&
                X.Number == CBItemsdisplay.SelectedItem.ToString()).ID;
            DisplayExpanses = MasterData.Contracts.ExpTrDataTable.Where
                 (Temp => Temp.ContractID == SelectedContractID && Temp.ItemNo == ItemID).
                 ToList();

            if (DisplayExpanses.Count == 0)
                setStatus("لا يوجد مصاريف على هذا البند", 0);
            else setStatus("تم تحميل المصروفات", 1);

            for (int i = 0; i < DisplayExpanses.Count; i++)

                listBoxItemsU.Items.Add(DisplayExpanses[i].ID);



        }


        void LoadExpanses()
        {
            if (CBConfirm.SelectedIndex == -1) return;

            listBoxExps.Items.Clear();
            LoadedExpanses.Clear();
            int ItemID = MasterData.assessments.AssItemsAdapter.NotNullContracts().FirstOrDefault
                (X => X.Contract_ID == SelectedContractID &&
                X.Number == CBConfirm.SelectedItem.ToString()).ID;
            LoadedExpanses = MasterData.Contracts.ExpTrDataTable.Where
                 (X => X.ContractID == SelectedContractID && X.ItemNo == ItemID).ToList();

            labelLOLC.Text = MasterData.NumericString(
               MasterData.assessments.GetItemLOLValue(CBContract.SelectedItem.ToString(),
               CBConfirm.SelectedItem.ToString()));

            labelTotalC.Text = MasterData.NumericString((double)MasterData.Contracts.ExpTrDataTable.Where
                (X => X.ContractID == SelectedContractID &&
                !X.NeedConf && X.ItemNo == ItemID).Sum(Y => Y.Amount));

            if (LoadedExpanses.Count > 0)
            {
                foreach (var Exps in LoadedExpanses)
                    listBoxExps.Items.Add(Exps.ID);
                setStatus("تم تحميل المصروفات المعلقة على هذا البند", 1);
            }
            else setStatus("لا يوجد مصروفات معلقه على هذا البند", 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {




            if (listBoxExps.SelectedIndex == -1)
            {
                setStatus("يجب إختيار مصروف لتأكيده", 0);
                return;
            }
            if (selectedExpsConfirmStatus)
            {
                setStatus("تم تأكيد المصروف بالفعل", 0);
                return;
            }

            // Check User Permissions
            if (MasterData.LoggedEmployee.Role != Enums.Job_Roles.Manager)
            {
                MessageBox.Show("غير مسموح لك بتأكيد مصروف زائد عن حد الالتزام الخاص بالبند", "صلاحيات غير مؤكدة"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int ID = int.Parse(listBoxExps.SelectedItem.ToString());
            MasterData.Contracts.ConfirmExps(ID);
            setStatus("تم تأكيد المصروف", 1);
            LabelCStatus.Text = "تم تأكيد المصروف";
            MasterData.Contracts.RefreshList();
            LoadExpanses();
        }



        private void CBItemsdisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayExps();
            if (CBItemsdisplay.SelectedIndex != -1 && CBContract.SelectedIndex != -1)
            {
                string ItemNum = CBItemsdisplay.SelectedItem.ToString();
                string ContractNum = CBContract.SelectedItem.ToString();

                labelRemainexpDisplay.Text =
                    MasterData.NumericString((double)MasterData.Interim.Get_Item_Status(ContractNum, ItemNum).Remain_Exps);
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            textBoxFile.Text = string.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBoxExps.SelectedIndex == -1)
            {
                setStatus("يجب إختيار مصروف أولاً", 0); return;
            }

            string SelectedExpsID = listBoxExps.SelectedItem.ToString();
            string FileOutput = MasterData.GetFile("E_" + SelectedExpsID);
            if (FileOutput == string.Empty)
            {
                setStatus("لا يوجد ملف محفوظ يخص هذا المصروف", 0); return;
            }
            MasterData.OpenFile(FileOutput);
            setStatus("تم تحميل ملف المصروف", 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBoxItemsU.SelectedIndex == -1)
            {
                setStatus("يجب إختيار مصروف أولاً", 0); return;
            }
            // Get Expanses File Path
            int SelectedTrID = int.Parse(listBoxItemsU.SelectedItem.ToString());
            MasterData.OpenFile(MasterData.GetFile("E_" + SelectedTrID.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog FileDialoge = new OpenFileDialog();
            FileDialoge.InitialDirectory = Application.StartupPath;
            FileDialoge.Filter = "pdf files (*.pdf;*.png;*.jpg;)|*.pdf;*.png;*.jpg;*.jpeg;";
            if (FileDialoge.ShowDialog() == DialogResult.OK)
                textBoxFileUpdate.Text = FileDialoge.FileName;
        }

        private void buttonchosecontract_Click(object sender, EventArgs e)
        {
            this.Name = "form";
            Form f = this;
            CBContract.SelectedItem = MasterData.GetcontractNum(f);
        }

        private void buttonchosecontract_Click_1(object sender, EventArgs e)
        {
            Displayallcontracts Con = new Displayallcontracts(true);
            Con.ShowDialog();
            CBContract.SelectedIndex = CBContract.FindStringExact(Displayallcontracts.ContractNumber);
            if (CBContract.SelectedIndex != -1) LoadContractData();
        }

        private void CBExpMajor_DropDown(object sender, EventArgs e)
        {
            CBExpMajor.Items.Clear();
            foreach (var x in MasterData.Contracts.JExpansesDateTable.ToList())
                CBExpMajor.Items.Add(x.Title);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void CBItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBItems.SelectedIndex != -1 && CBContract.SelectedIndex != -1)
            {
                string ItemNum = CBItems.SelectedItem.ToString();
                string ContractNum = CBContract.SelectedItem.ToString();

                labelRemainExp.Text =
                    MasterData.NumericString((double)MasterData.Interim.Get_Item_Status(ContractNum, ItemNum).Remain_Exps);
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
