using HORAS.Database;
using HORAS.Database.HorasDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HORAS.Enums;
using static HORAS.Database.HorasDataSet;
using HORAS.Properties;

namespace HORAS.Interims_Data
{
    public partial class ExpsMasterData : Form
    {
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

        public ExpsMasterData()
        {

            InitializeComponent();
        }

        private void ExpsMasterData_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxExpsTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxExpsD.Items.Clear();

            MasterData.Contracts.RefreshList();

            int headID = MasterData.Contracts.JExpansesDateTable.FirstOrDefault(x => x.Title == comboBoxExpsTD.Text).ID;

            var list = MasterData.Contracts.IExpansesDateTable.Where(x => x.HeadID == headID).ToList();
            foreach (var x in list)
                comboBoxExpsD.Items.Add(x.Title);
            textBoxCatUD.Text = comboBoxExpsTD.SelectedItem.ToString();
        }


        private void comboBoxExpsTD_DropDown(object sender, EventArgs e)
        {
            comboBoxExpsTD.Items.Clear();
            MasterData.Contracts.RefreshList();

            var list = MasterData.Contracts.JExpansesDateTable.ToList();
            foreach (var x in list)
                comboBoxExpsTD.Items.Add(x.Title);
        }

        private void comboBoxExpsD_DropDown(object sender, EventArgs e)
        {
            if (comboBoxExpsTD.SelectedIndex == -1) return;
            comboBoxExpsD.Items.Clear();
            MasterData.Contracts.RefreshList();
            int headID = MasterData.Contracts.JExpansesDateTable.FirstOrDefault(x => x.Title == comboBoxExpsTD.Text).ID;
            var list = MasterData.Contracts.IExpansesDateTable.Where(x => x.HeadID == headID).ToList();
            foreach (var x in list)
                comboBoxExpsD.Items.Add(x.Title);
        }

        private void comboBoxExpsD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedminorID = MasterData.Contracts.IExpansesDateTable.FirstOrDefault(x => x.Title == comboBoxExpsD.Text).ID;

            int direct = MasterData.Contracts.IExpansesDateTable.FirstOrDefault(x => x.ID == selectedminorID).Direct_InDirect;
            textBoxExpsUD.Text = comboBoxExpsD.SelectedItem.ToString();
            switch (direct)
            {
                case 1:
                    radioButtonDirectUD.Checked = true;
                    break;
                case 0:
                    radioButtonIndirectUD.Checked = true;
                    break;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            HorasDataSet.ExpansesMajorRow exp = MasterData.Contracts.JExpansesDateTable.NewExpansesMajorRow();

            if (textBoxExptitle.Text == string.Empty)
            {
                setStatus("ادخل فئة المصروف اولا", 0);
                return;
            }
            if (MasterData.Contracts.JExpansesDateTable.Where(x => x.Title == textBoxExptitle.Text).Count() > 0)
            {
                setStatus("يوجد فئة مصروف بهذا الاسم", 0);
                textBoxExptitle.Text = string.Empty;
                return;
            }
            else
            {
                exp.Title = textBoxExptitle.Text;
                exp.ID = 0;
                MasterData.Contracts.AddExpsCategory(exp);
                textBoxExptitle.Text = string.Empty;
                setStatus("تم تسجيل فئة المصروف", 1);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            HorasDataSet.ExpansesMinorRow expI = MasterData.Contracts.IExpansesDateTable.NewExpansesMinorRow();
            int selectedheadid = 0;
            if (comboBox1.SelectedIndex == -1)
            {
                setStatus("ادخل فئة المصروف اولا", 0);
                return;
            }
            if (textBoxExptitleD.Text == string.Empty)
            {
                setStatus("ادخل المصروف اولا", 0);
                textBoxExptitle.Text = string.Empty;
                return;
            }

            int ID = MasterData.Contracts.JExpansesDateTable.FirstOrDefault(X => X.Title == comboBox1.SelectedItem.ToString()).ID;

            if (MasterData.Contracts.IExpansesDateTable.Where(x => x.Title == textBoxExptitleD.Text && x.HeadID == ID).Count() > 0)
            {
                setStatus("يوجد مصروف بهذا الاسم على تلك الفئة", 0);
                textBoxExptitleD.Text = string.Empty;
                return;
            }
            else
            {
                expI.Title = textBoxExptitleD.Text;
                expI.HeadID = ID;
                expI.ID = 0;
                if (radioButtonDirect.Checked) expI.Direct_InDirect = (int)Expensdirect.direct;
                else expI.Direct_InDirect = (int)Expensdirect.In_Direct;
                MasterData.Contracts.AddExpsTitle(expI);
                textBoxExptitleD.Text = string.Empty;
                setStatus("تم تسجيل المصروف", 1);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            MasterData.Contracts.RefreshList();

            var list = MasterData.Contracts.JExpansesDateTable.ToList();
            foreach (var x in list)
                comboBox1.Items.Add(x.Title);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (comboBoxExpsTD.SelectedIndex == -1)
            {
                setStatus("يجب إختيار فئة مصروف لتعديلها", 0);
                return;
            }
            if (textBoxCatUD.Text == string.Empty)
            {
                setStatus("لا يمكن وضع فئة مصروف فارغة", 0);
                return;
            }

            if (MasterData.Contracts.JExpansesDateTable.Where(x => x.Title == textBoxCatUD.Text).Count() > 0)
            {
                setStatus("يوجد فئة مصروف بهذا الاسم", 0);
                return;
            }

            var ExpCatRow = MasterData.Contracts.JExpansesDateTable.FirstOrDefault(X => X.Title == comboBoxExpsTD.SelectedItem.ToString());
            ExpCatRow.Title = textBoxCatUD.Text;
            MasterData.Contracts.UpdateExpsCategory(ExpCatRow);
            comboBoxExpsTD.Text = textBoxCatUD.Text;
            setStatus("تم تعديل فئة المصروف", 1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (comboBoxExpsTD.SelectedIndex == -1)
            {
                setStatus("يجب إختيار فئة مصروف ", 0);
                return;
            }

            int CatID = MasterData.Contracts.JExpansesDateTable.FirstOrDefault(X => X.Title == comboBoxExpsTD.SelectedItem.ToString()).ID;
            var ExpsTitles = MasterData.Contracts.IExpansesDateTable.Where(X => X.HeadID == CatID).ToList();

            bool Found = false;

            //to make sure no expanses related to this category exist before delete
            foreach (var Exps in ExpsTitles)
            {
                int Num = MasterData.Contracts.ExpTrDataTable.Count(X => X.ExpID == Exps.ID);
                if (Num > 0)
                {
                    Found = true;
                    break;
                }
            }

            if (Found)
            {
                setStatus("تم إضافة مصروفات تعاقدات على هذه الفئة ولا يمكن مسحها ", 0);
                return;
            }

            MasterData.Contracts.JExpansesAdapter.DeleteExpsCategory(CatID);
            textBoxCatUD.Text = string.Empty;
            comboBoxExpsTD.Items.RemoveAt(comboBoxExpsTD.SelectedIndex);
            comboBoxExpsTD.SelectedText = string.Empty;
            setStatus("تم مسح فئة المصروف ", 1);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (comboBoxExpsD.SelectedIndex == -1)
            {
                setStatus("يجب إختيار فئة مصروف ", 0);
                return;
            }

            int CatID = MasterData.Contracts.JExpansesDateTable.FirstOrDefault
                (X => X.Title == comboBoxExpsTD.SelectedItem.ToString()).ID;

            int ID = MasterData.Contracts.IExpansesDateTable.FirstOrDefault
               (X => X.Title == comboBoxExpsTD.SelectedItem.ToString() && X.HeadID == CatID).ID;
          
            if ( MasterData.Contracts.ExpTrDataTable.Count(X => X.ExpID == ID) > 0)
            {
                setStatus("تم إضافة مصروفات تعاقدات على هذا المصروف ولا يمكن مسحه ", 0);
                return;
            }

            MasterData.Contracts.IExpansesAdapter.DeleteExps(ID);
            textBoxExpsUD.Text = string.Empty;
            comboBoxExpsD.Items.RemoveAt(comboBoxExpsD.SelectedIndex);
            comboBoxExpsD.SelectedText = string.Empty;
            setStatus("تم مسح المصروف ", 1);
        }
    }













}


