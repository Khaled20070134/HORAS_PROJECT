namespace HORAS.Interims_Data
{
    partial class ImportInterims
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportInterims));
            TextBoxURL = new MetroFramework.Controls.MetroTextBox();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            DGV_Data = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            metroButton4 = new MetroFramework.Controls.MetroButton();
            metroButton5 = new MetroFramework.Controls.MetroButton();
            LabelItemDesc = new MetroFramework.Controls.MetroLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxStatus = new PictureBox();
            labelStatus = new Label();
            pictureBox7 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            pictureBox6 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            CBContracts = new ComboBox();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            labelItemStatus = new Label();
            pictureBox4 = new PictureBox();
            label6 = new Label();
            labelPrevQty = new Label();
            labelTotalAss = new Label();
            pictureBox5 = new PictureBox();
            label10 = new Label();
            labelTotalStatus = new Label();
            label12 = new Label();
            pictureBox8 = new PictureBox();
            label11 = new Label();
            metroButton2 = new MetroFramework.Controls.MetroButton();
            labelTotal = new Label();
            pictureBox9 = new PictureBox();
            label13 = new Label();
            textBoxNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGV_Data).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // TextBoxURL
            // 
            TextBoxURL.BackColor = Color.White;
            TextBoxURL.Enabled = false;
            TextBoxURL.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxURL.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxURL.Location = new Point(139, 56);
            TextBoxURL.Multiline = false;
            TextBoxURL.Name = "TextBoxURL";
            TextBoxURL.RightToLeft = RightToLeft.Yes;
            TextBoxURL.SelectedText = "";
            TextBoxURL.Size = new Size(291, 23);
            TextBoxURL.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxURL.StyleManager = null;
            TextBoxURL.TabIndex = 0;
            TextBoxURL.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxURL.UseStyleColors = false;
            // 
            // metroButton1
            // 
            metroButton1.Highlight = false;
            metroButton1.Location = new Point(50, 56);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(83, 23);
            metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton1.StyleManager = null;
            metroButton1.TabIndex = 1;
            metroButton1.Text = "إختيار الملف";
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroButton1.Click += metroButton1_Click;
            // 
            // DGV_Data
            // 
            DGV_Data.AllowUserToAddRows = false;
            DGV_Data.AllowUserToDeleteRows = false;
            DGV_Data.BorderStyle = BorderStyle.None;
            DGV_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Data.Columns.AddRange(new DataGridViewColumn[] { Column1, Column4, Column5, Column7, Column6 });
            DGV_Data.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGV_Data.Location = new Point(319, 147);
            DGV_Data.MultiSelect = false;
            DGV_Data.Name = "DGV_Data";
            DGV_Data.ReadOnly = true;
            DGV_Data.RightToLeft = RightToLeft.Yes;
            DGV_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Data.Size = new Size(536, 163);
            DGV_Data.TabIndex = 3;
            DGV_Data.SelectionChanged += DGV_Data_SelectionChanged;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "مسلسل";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 50;
            // 
            // Column4
            // 
            Column4.HeaderText = "سعر الوحدة";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "الكمية";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "نوع البند";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "الاجمالى";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // metroButton4
            // 
            metroButton4.Highlight = false;
            metroButton4.Location = new Point(16, 471);
            metroButton4.Name = "metroButton4";
            metroButton4.Size = new Size(103, 23);
            metroButton4.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton4.StyleManager = null;
            metroButton4.TabIndex = 4;
            metroButton4.Text = "حفظ";
            metroButton4.Theme = MetroFramework.MetroThemeStyle.Light;
            metroButton4.Click += metroButton4_Click;
            // 
            // metroButton5
            // 
            metroButton5.Highlight = false;
            metroButton5.Location = new Point(125, 471);
            metroButton5.Name = "metroButton5";
            metroButton5.Size = new Size(135, 23);
            metroButton5.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton5.StyleManager = null;
            metroButton5.TabIndex = 1;
            metroButton5.Text = "إعادة تحميل الملف";
            metroButton5.Theme = MetroFramework.MetroThemeStyle.Light;
            metroButton5.Click += metroButton1_Click;
            // 
            // LabelItemDesc
            // 
            LabelItemDesc.AutoSize = true;
            LabelItemDesc.BackColor = Color.Transparent;
            LabelItemDesc.CustomBackground = true;
            LabelItemDesc.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelItemDesc.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelItemDesc.ForeColor = Color.White;
            LabelItemDesc.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelItemDesc.Location = new Point(574, 365);
            LabelItemDesc.Name = "LabelItemDesc";
            LabelItemDesc.Size = new Size(21, 19);
            LabelItemDesc.Style = MetroFramework.MetroColorStyle.White;
            LabelItemDesc.StyleManager = null;
            LabelItemDesc.TabIndex = 7;
            LabelItemDesc.Text = "....";
            LabelItemDesc.Theme = MetroFramework.MetroThemeStyle.Dark;
            LabelItemDesc.UseStyleColors = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95.34511F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.654896F));
            tableLayoutPanel1.Controls.Add(pictureBoxStatus, 1, 0);
            tableLayoutPanel1.Controls.Add(labelStatus, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 500);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(907, 27);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // pictureBoxStatus
            // 
            pictureBoxStatus.Dock = DockStyle.Fill;
            pictureBoxStatus.Location = new Point(867, 3);
            pictureBoxStatus.Name = "pictureBoxStatus";
            pictureBoxStatus.Size = new Size(37, 21);
            pictureBoxStatus.TabIndex = 0;
            pictureBoxStatus.TabStop = false;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Dock = DockStyle.Right;
            labelStatus.ForeColor = Color.White;
            labelStatus.ImageAlign = ContentAlignment.MiddleLeft;
            labelStatus.Location = new Point(851, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(10, 27);
            labelStatus.TabIndex = 1;
            labelStatus.Text = ".";
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(506, 58);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(16, 18);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 27;
            pictureBox7.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.SkyBlue;
            label2.Location = new Point(692, 103);
            label2.Name = "label2";
            label2.Size = new Size(163, 25);
            label2.TabIndex = 29;
            label2.Text = "بيانات بنود المقايسة";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.leftArrow2_32;
            pictureBox1.Location = new Point(857, 100);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.White;
            label5.Location = new Point(440, 60);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 34;
            label5.Text = "إسم الملف";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.White;
            label7.Location = new Point(764, 367);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 40;
            label7.Text = "وصف البند";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(319, 9);
            label8.Name = "label8";
            label8.Size = new Size(280, 28);
            label8.TabIndex = 41;
            label8.Text = "إستيراد مستخلص من ملف إكسل";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(831, 365);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(16, 18);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 43;
            pictureBox6.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(795, 60);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 45;
            label1.Text = "رقم التعاقد";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(861, 58);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(16, 18);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 44;
            pictureBox2.TabStop = false;
            // 
            // CBContracts
            // 
            CBContracts.FormattingEnabled = true;
            CBContracts.Location = new Point(604, 56);
            CBContracts.Name = "CBContracts";
            CBContracts.Size = new Size(181, 23);
            CBContracts.TabIndex = 46;
            CBContracts.SelectedIndexChanged += CBContracts_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.SkyBlue;
            label3.Location = new Point(664, 329);
            label3.Name = "label3";
            label3.Size = new Size(191, 25);
            label3.TabIndex = 48;
            label3.Text = "بيانات على مستوى البند";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Image = Properties.Resources.leftArrow2_32;
            pictureBox3.Location = new Point(857, 326);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 31);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 47;
            pictureBox3.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.SkyBlue;
            label4.Location = new Point(50, 263);
            label4.Name = "label4";
            label4.Size = new Size(194, 25);
            label4.TabIndex = 49;
            label4.Text = "حاله إستيراد البند المختار";
            // 
            // labelItemStatus
            // 
            labelItemStatus.AutoSize = true;
            labelItemStatus.BackColor = Color.Transparent;
            labelItemStatus.ForeColor = Color.White;
            labelItemStatus.Location = new Point(126, 297);
            labelItemStatus.Name = "labelItemStatus";
            labelItemStatus.Size = new Size(51, 15);
            labelItemStatus.TabIndex = 50;
            labelItemStatus.Text = "حالة البند";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(831, 391);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(16, 18);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 53;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.White;
            label6.Location = new Point(703, 393);
            label6.Name = "label6";
            label6.Size = new Size(122, 15);
            label6.TabIndex = 52;
            label6.Text = "الكمية أو النسبة السابقة";
            // 
            // labelPrevQty
            // 
            labelPrevQty.AutoSize = true;
            labelPrevQty.BackColor = Color.Transparent;
            labelPrevQty.ForeColor = Color.White;
            labelPrevQty.Location = new Point(574, 394);
            labelPrevQty.Name = "labelPrevQty";
            labelPrevQty.Size = new Size(122, 15);
            labelPrevQty.TabIndex = 54;
            labelPrevQty.Text = "الكمية أو النسبة السابقة";
            // 
            // labelTotalAss
            // 
            labelTotalAss.AutoSize = true;
            labelTotalAss.BackColor = Color.Transparent;
            labelTotalAss.ForeColor = Color.White;
            labelTotalAss.Location = new Point(538, 420);
            labelTotalAss.Name = "labelTotalAss";
            labelTotalAss.Size = new Size(122, 15);
            labelTotalAss.TabIndex = 57;
            labelTotalAss.Text = "الكمية أو النسبة السابقة";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(831, 417);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(16, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 56;
            pictureBox5.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.ForeColor = Color.White;
            label10.Location = new Point(673, 419);
            label10.Name = "label10";
            label10.Size = new Size(152, 15);
            label10.TabIndex = 55;
            label10.Text = "إجمالى كمية أو نسبة المقايسة";
            // 
            // labelTotalStatus
            // 
            labelTotalStatus.AutoSize = true;
            labelTotalStatus.BackColor = Color.Transparent;
            labelTotalStatus.ForeColor = Color.White;
            labelTotalStatus.Location = new Point(125, 240);
            labelTotalStatus.Name = "labelTotalStatus";
            labelTotalStatus.RightToLeft = RightToLeft.Yes;
            labelTotalStatus.Size = new Size(51, 15);
            labelTotalStatus.TabIndex = 59;
            labelTotalStatus.Text = "حالة البند";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label12.ForeColor = Color.SkyBlue;
            label12.Location = new Point(50, 202);
            label12.Name = "label12";
            label12.Size = new Size(202, 25);
            label12.TabIndex = 58;
            label12.Text = "الحالة العامة لجميع البنود";
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(601, 332);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(16, 18);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 62;
            pictureBox8.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.ForeColor = Color.White;
            label11.Location = new Point(473, 334);
            label11.Name = "label11";
            label11.RightToLeft = RightToLeft.Yes;
            label11.Size = new Size(122, 15);
            label11.TabIndex = 61;
            label11.Text = "إجمالى مستخلص البند :";
            // 
            // metroButton2
            // 
            metroButton2.Highlight = false;
            metroButton2.Location = new Point(-214, 438);
            metroButton2.Name = "metroButton2";
            metroButton2.Size = new Size(103, 23);
            metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
            metroButton2.StyleManager = null;
            metroButton2.TabIndex = 60;
            metroButton2.Text = "حفظ";
            metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.BackColor = Color.Transparent;
            labelTotal.ForeColor = Color.White;
            labelTotal.Location = new Point(398, 334);
            labelTotal.Name = "labelTotal";
            labelTotal.RightToLeft = RightToLeft.Yes;
            labelTotal.Size = new Size(22, 15);
            labelTotal.TabIndex = 63;
            labelTotal.Text = "0.0";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(266, 158);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(16, 18);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 65;
            pictureBox9.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.ForeColor = Color.White;
            label13.Location = new Point(183, 160);
            label13.Name = "label13";
            label13.RightToLeft = RightToLeft.Yes;
            label13.Size = new Size(82, 15);
            label13.TabIndex = 64;
            label13.Text = "رقم المستخلص";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(60, 157);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(116, 23);
            textBoxNumber.TabIndex = 66;
            textBoxNumber.Leave += textBox1_Leave;
            // 
            // ImportInterims
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(907, 527);
            Controls.Add(textBoxNumber);
            Controls.Add(pictureBox9);
            Controls.Add(label13);
            Controls.Add(labelTotal);
            Controls.Add(pictureBox8);
            Controls.Add(label11);
            Controls.Add(metroButton2);
            Controls.Add(labelTotalStatus);
            Controls.Add(label12);
            Controls.Add(labelTotalAss);
            Controls.Add(pictureBox5);
            Controls.Add(label10);
            Controls.Add(labelPrevQty);
            Controls.Add(pictureBox4);
            Controls.Add(label6);
            Controls.Add(labelItemStatus);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(CBContracts);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox7);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(LabelItemDesc);
            Controls.Add(metroButton4);
            Controls.Add(DGV_Data);
            Controls.Add(metroButton5);
            Controls.Add(metroButton1);
            Controls.Add(TextBoxURL);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImportInterims";
            Text = "ImportAssessment";
            ((System.ComponentModel.ISupportInitialize)DGV_Data).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TextBoxURL;
        private MetroFramework.Controls.MetroButton metroButton1;
        private DataGridView DGV_Data;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroLabel LabelItemDesc;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxStatus;
        private Label labelStatus;
        private PictureBox pictureBox7;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox6;
        private Label label1;
        private PictureBox pictureBox2;
        private ComboBox CBContracts;
        private Label label3;
        private PictureBox pictureBox3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column6;
        private Label label4;
        private Label labelItemStatus;
        private PictureBox pictureBox4;
        private Label label6;
        private Label labelPrevQty;
        private Label labelTotalAss;
        private PictureBox pictureBox5;
        private Label label10;
        private Label labelTotalStatus;
        private Label label12;
        private PictureBox pictureBox8;
        private Label label11;
        private MetroFramework.Controls.MetroButton metroButton2;
        private Label labelTotal;
        private PictureBox pictureBox9;
        private Label label13;
        private TextBox textBoxNumber;
    }
}