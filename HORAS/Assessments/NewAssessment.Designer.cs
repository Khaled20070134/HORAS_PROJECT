namespace HORAS.Assessments
{
    partial class NewAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAssessment));
            DGV_Data = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            TextBoxSubject = new MetroFramework.Controls.MetroTextBox();
            TextBoxAbout = new MetroFramework.Controls.MetroTextBox();
            metroButton4 = new MetroFramework.Controls.MetroButton();
            LabelTotal = new MetroFramework.Controls.MetroLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxStatus = new PictureBox();
            labelStatus = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox5 = new PictureBox();
            label5 = new Label();
            TextBoxDesc = new MetroFramework.Controls.MetroTextBox();
            pictureBox7 = new PictureBox();
            label6 = new Label();
            TextBoxSerial = new MetroFramework.Controls.MetroTextBox();
            label9 = new Label();
            pictureBox8 = new PictureBox();
            NUDPriceUnit = new NumericUpDown();
            label10 = new Label();
            pictureBox9 = new PictureBox();
            NUDQTY = new NumericUpDown();
            TextBoxUnit = new MetroFramework.Controls.MetroTextBox();
            pictureBox10 = new PictureBox();
            label11 = new Label();
            label12 = new Label();
            pictureBox11 = new PictureBox();
            comboBoxType = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Data).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDPriceUnit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDQTY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            SuspendLayout();
            // 
            // DGV_Data
            // 
            DGV_Data.AllowUserToAddRows = false;
            DGV_Data.AllowUserToDeleteRows = false;
            DGV_Data.AllowUserToOrderColumns = true;
            DGV_Data.BorderStyle = BorderStyle.None;
            DGV_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Data.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column7, Column6 });
            DGV_Data.EditMode = DataGridViewEditMode.EditOnEnter;
            DGV_Data.Enabled = false;
            DGV_Data.ImeMode = ImeMode.On;
            DGV_Data.Location = new Point(16, 311);
            DGV_Data.MultiSelect = false;
            DGV_Data.Name = "DGV_Data";
            DGV_Data.RightToLeft = RightToLeft.Yes;
            DGV_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Data.Size = new Size(650, 141);
            DGV_Data.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "مسلسل";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.Frozen = true;
            Column2.HeaderText = "وصف البند";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "الوحدة";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "سعر الوحدة";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "الكمية";
            Column5.Name = "Column5";
            // 
            // Column7
            // 
            Column7.HeaderText = "نوع البند";
            Column7.Name = "Column7";
            Column7.Resizable = DataGridViewTriState.True;
            // 
            // Column6
            // 
            Column6.HeaderText = "الاجمالى";
            Column6.Name = "Column6";
            // 
            // TextBoxSubject
            // 
            TextBoxSubject.BackColor = Color.White;
            TextBoxSubject.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxSubject.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxSubject.Location = new Point(277, 85);
            TextBoxSubject.Multiline = false;
            TextBoxSubject.Name = "TextBoxSubject";
            TextBoxSubject.RightToLeft = RightToLeft.Yes;
            TextBoxSubject.SelectedText = "";
            TextBoxSubject.Size = new Size(291, 23);
            TextBoxSubject.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxSubject.StyleManager = null;
            TextBoxSubject.TabIndex = 6;
            TextBoxSubject.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxSubject.UseStyleColors = false;
            // 
            // TextBoxAbout
            // 
            TextBoxAbout.BackColor = Color.White;
            TextBoxAbout.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxAbout.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxAbout.Location = new Point(27, 113);
            TextBoxAbout.Multiline = false;
            TextBoxAbout.Name = "TextBoxAbout";
            TextBoxAbout.RightToLeft = RightToLeft.Yes;
            TextBoxAbout.SelectedText = "";
            TextBoxAbout.Size = new Size(541, 23);
            TextBoxAbout.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxAbout.StyleManager = null;
            TextBoxAbout.TabIndex = 6;
            TextBoxAbout.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxAbout.UseStyleColors = false;
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
            // LabelTotal
            // 
            LabelTotal.AutoSize = true;
            LabelTotal.BackColor = Color.Transparent;
            LabelTotal.CustomBackground = true;
            LabelTotal.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelTotal.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelTotal.ForeColor = Color.White;
            LabelTotal.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelTotal.Location = new Point(492, 469);
            LabelTotal.Name = "LabelTotal";
            LabelTotal.Size = new Size(21, 19);
            LabelTotal.Style = MetroFramework.MetroColorStyle.White;
            LabelTotal.StyleManager = null;
            LabelTotal.TabIndex = 7;
            LabelTotal.Text = "....";
            LabelTotal.Theme = MetroFramework.MetroThemeStyle.Dark;
            LabelTotal.UseStyleColors = true;
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
            tableLayoutPanel1.Size = new Size(679, 27);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // pictureBoxStatus
            // 
            pictureBoxStatus.Dock = DockStyle.Fill;
            pictureBoxStatus.Location = new Point(650, 3);
            pictureBoxStatus.Name = "pictureBoxStatus";
            pictureBoxStatus.Size = new Size(26, 21);
            pictureBoxStatus.TabIndex = 0;
            pictureBoxStatus.TabStop = false;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Dock = DockStyle.Right;
            labelStatus.ForeColor = Color.White;
            labelStatus.ImageAlign = ContentAlignment.MiddleLeft;
            labelStatus.Location = new Point(634, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(10, 27);
            labelStatus.TabIndex = 1;
            labelStatus.Text = ".";
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.SkyBlue;
            label2.Location = new Point(481, 163);
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
            pictureBox1.Location = new Point(646, 160);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.SkyBlue;
            label1.Location = new Point(546, 46);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 31;
            label1.Text = "بيانات عامة";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.leftArrow2_32;
            pictureBox2.Location = new Point(646, 43);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 30;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(586, 89);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 35;
            label3.Text = "الموضوع";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(586, 117);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 36;
            label4.Text = "بخصوص";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(644, 87);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(16, 18);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 37;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(644, 115);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(16, 18);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 38;
            pictureBox4.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(557, 471);
            label7.Name = "label7";
            label7.Size = new Size(87, 15);
            label7.TabIndex = 40;
            label7.Text = "إجمالى المقايسة";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(222, 4);
            label8.Name = "label8";
            label8.Size = new Size(231, 28);
            label8.TabIndex = 41;
            label8.Text = "إدخال بيانات مقايسة جديدة";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(650, 469);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(16, 18);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 43;
            pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(644, 205);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(16, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 45;
            pictureBox5.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(577, 207);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 44;
            label5.Text = "وصف البند";
            // 
            // TextBoxDesc
            // 
            TextBoxDesc.BackColor = Color.White;
            TextBoxDesc.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxDesc.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxDesc.Location = new Point(30, 203);
            TextBoxDesc.Multiline = false;
            TextBoxDesc.Name = "TextBoxDesc";
            TextBoxDesc.RightToLeft = RightToLeft.Yes;
            TextBoxDesc.SelectedText = "";
            TextBoxDesc.Size = new Size(541, 23);
            TextBoxDesc.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxDesc.StyleManager = null;
            TextBoxDesc.TabIndex = 6;
            TextBoxDesc.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxDesc.UseStyleColors = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(644, 232);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(16, 18);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 47;
            pictureBox7.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(590, 234);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 46;
            label6.Text = "رقم البند";
            // 
            // TextBoxSerial
            // 
            TextBoxSerial.BackColor = Color.White;
            TextBoxSerial.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxSerial.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxSerial.Location = new Point(492, 230);
            TextBoxSerial.Multiline = false;
            TextBoxSerial.Name = "TextBoxSerial";
            TextBoxSerial.RightToLeft = RightToLeft.Yes;
            TextBoxSerial.SelectedText = "";
            TextBoxSerial.Size = new Size(79, 23);
            TextBoxSerial.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxSerial.StyleManager = null;
            TextBoxSerial.TabIndex = 48;
            TextBoxSerial.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxSerial.UseStyleColors = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(366, 234);
            label9.Name = "label9";
            label9.Size = new Size(64, 15);
            label9.TabIndex = 46;
            label9.Text = "سعر الوحدة";
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(430, 232);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(16, 18);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 47;
            pictureBox8.TabStop = false;
            // 
            // NUDPriceUnit
            // 
            NUDPriceUnit.DecimalPlaces = 2;
            NUDPriceUnit.Location = new Point(279, 230);
            NUDPriceUnit.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            NUDPriceUnit.Name = "NUDPriceUnit";
            NUDPriceUnit.Size = new Size(83, 23);
            NUDPriceUnit.TabIndex = 49;
            NUDPriceUnit.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.ForeColor = Color.White;
            label10.Location = new Point(158, 234);
            label10.Name = "label10";
            label10.Size = new Size(37, 15);
            label10.TabIndex = 46;
            label10.Text = "الكمية";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(197, 232);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(16, 18);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 47;
            pictureBox9.TabStop = false;
            // 
            // NUDQTY
            // 
            NUDQTY.DecimalPlaces = 2;
            NUDQTY.Location = new Point(67, 230);
            NUDQTY.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            NUDQTY.Name = "NUDQTY";
            NUDQTY.Size = new Size(83, 23);
            NUDQTY.TabIndex = 49;
            NUDQTY.TextAlign = HorizontalAlignment.Center;
            // 
            // TextBoxUnit
            // 
            TextBoxUnit.BackColor = Color.White;
            TextBoxUnit.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxUnit.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxUnit.Location = new Point(279, 257);
            TextBoxUnit.Multiline = false;
            TextBoxUnit.Name = "TextBoxUnit";
            TextBoxUnit.RightToLeft = RightToLeft.Yes;
            TextBoxUnit.SelectedText = "";
            TextBoxUnit.Size = new Size(83, 23);
            TextBoxUnit.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxUnit.StyleManager = null;
            TextBoxUnit.TabIndex = 52;
            TextBoxUnit.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxUnit.UseStyleColors = false;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.Transparent;
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(430, 259);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(16, 18);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.TabIndex = 51;
            pictureBox10.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(373, 261);
            label11.Name = "label11";
            label11.Size = new Size(56, 15);
            label11.TabIndex = 50;
            label11.Text = "وحدة البند";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.ForeColor = Color.White;
            label12.Location = new Point(590, 261);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 46;
            label12.Text = "نوع البند";
            // 
            // pictureBox11
            // 
            pictureBox11.BackColor = Color.Transparent;
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(644, 259);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(16, 18);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 47;
            pictureBox11.TabStop = false;
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "توريد", "تركيب", "توريدوتركيب" });
            comboBoxType.Location = new Point(492, 257);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(81, 23);
            comboBoxType.TabIndex = 53;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.plus_321;
            button1.Location = new Point(79, 268);
            button1.Name = "button1";
            button1.Size = new Size(40, 34);
            button1.TabIndex = 54;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources.minus_32;
            button2.Location = new Point(31, 268);
            button2.Name = "button2";
            button2.Size = new Size(40, 34);
            button2.TabIndex = 54;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // NewAssessment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(679, 527);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBoxType);
            Controls.Add(TextBoxUnit);
            Controls.Add(pictureBox10);
            Controls.Add(label11);
            Controls.Add(NUDQTY);
            Controls.Add(NUDPriceUnit);
            Controls.Add(pictureBox9);
            Controls.Add(TextBoxSerial);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox11);
            Controls.Add(label10);
            Controls.Add(pictureBox7);
            Controls.Add(label12);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(pictureBox5);
            Controls.Add(label5);
            Controls.Add(pictureBox6);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(LabelTotal);
            Controls.Add(TextBoxDesc);
            Controls.Add(TextBoxAbout);
            Controls.Add(TextBoxSubject);
            Controls.Add(metroButton4);
            Controls.Add(DGV_Data);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewAssessment";
            Text = "ImportAssessment";
            ((System.ComponentModel.ISupportInitialize)DGV_Data).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDPriceUnit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDQTY).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DGV_Data;
        private MetroFramework.Controls.MetroTextBox TextBoxSubject;
        private MetroFramework.Controls.MetroTextBox TextBoxAbout;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroLabel LabelTotal;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxStatus;
        private Label labelStatus;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private Label label5;
        private MetroFramework.Controls.MetroTextBox TextBoxDesc;
        private PictureBox pictureBox7;
        private Label label6;
        private MetroFramework.Controls.MetroTextBox TextBoxSerial;
        private Label label9;
        private PictureBox pictureBox8;
        private NumericUpDown NUDPriceUnit;
        private Label label10;
        private PictureBox pictureBox9;
        private NumericUpDown NUDQTY;
        private MetroFramework.Controls.MetroTextBox TextBoxUnit;
        private PictureBox pictureBox10;
        private Label label11;
        private Label label12;
        private PictureBox pictureBox11;
        private ComboBox comboBoxType;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column6;
    }
}