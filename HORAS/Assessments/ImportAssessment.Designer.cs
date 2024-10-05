namespace HORAS.Assessments
{
    partial class ImportAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportAssessment));
            TextBoxURL = new MetroFramework.Controls.MetroTextBox();
            DGV_Data = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            LOL = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            TextBoxSubject = new MetroFramework.Controls.MetroTextBox();
            TextBoxAbout = new MetroFramework.Controls.MetroTextBox();
            LabelDate = new MetroFramework.Controls.MetroLabel();
            LabelTotal = new MetroFramework.Controls.MetroLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxStatus = new PictureBox();
            labelStatus = new Label();
            pictureBox7 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            label9 = new Label();
            TextBoxOrigAssFile = new MetroFramework.Controls.MetroTextBox();
            pictureBox9 = new PictureBox();
            pictureBox12 = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Data).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            SuspendLayout();
            // 
            // TextBoxURL
            // 
            TextBoxURL.BackColor = Color.White;
            TextBoxURL.Enabled = false;
            TextBoxURL.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxURL.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxURL.Location = new Point(234, 59);
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
            TextBoxURL.Click += TextBoxURL_Click;
            // 
            // DGV_Data
            // 
            DGV_Data.AllowUserToAddRows = false;
            DGV_Data.AllowUserToDeleteRows = false;
            DGV_Data.BorderStyle = BorderStyle.None;
            DGV_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Data.Columns.AddRange(new DataGridViewColumn[] { Column1, Column3, Column4, Column5, Column7, LOL, Column6 });
            DGV_Data.EditMode = DataGridViewEditMode.EditProgrammatically;
            DGV_Data.Location = new Point(12, 299);
            DGV_Data.MultiSelect = false;
            DGV_Data.Name = "DGV_Data";
            DGV_Data.RightToLeft = RightToLeft.Yes;
            DGV_Data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_Data.Size = new Size(650, 130);
            DGV_Data.TabIndex = 3;
            DGV_Data.SelectionChanged += DGV_Data_SelectionChanged;
            // 
            // Column1
            // 
            Column1.FillWeight = 50F;
            Column1.Frozen = true;
            Column1.HeaderText = "مسلسل";
            Column1.Name = "Column1";
            // 
            // Column3
            // 
            Column3.FillWeight = 50F;
            Column3.Frozen = true;
            Column3.HeaderText = "الوحدة";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.Frozen = true;
            Column4.HeaderText = "سعر الوحدة";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.Frozen = true;
            Column5.HeaderText = "الكمية";
            Column5.Name = "Column5";
            // 
            // Column7
            // 
            Column7.Frozen = true;
            Column7.HeaderText = "نوع البند";
            Column7.Name = "Column7";
            // 
            // LOL
            // 
            LOL.Frozen = true;
            LOL.HeaderText = "حد الإلتزام";
            LOL.Name = "LOL";
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
            TextBoxSubject.Location = new Point(262, 163);
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
            TextBoxAbout.Location = new Point(12, 191);
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
            // LabelDate
            // 
            LabelDate.AutoSize = true;
            LabelDate.BackColor = Color.Transparent;
            LabelDate.CustomBackground = true;
            LabelDate.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelDate.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelDate.ForeColor = Color.White;
            LabelDate.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelDate.Location = new Point(490, 221);
            LabelDate.Name = "LabelDate";
            LabelDate.Size = new Size(62, 19);
            LabelDate.Style = MetroFramework.MetroColorStyle.White;
            LabelDate.StyleManager = null;
            LabelDate.TabIndex = 7;
            LabelDate.Text = "تاريخ اليوم";
            LabelDate.Theme = MetroFramework.MetroThemeStyle.Dark;
            LabelDate.UseStyleColors = true;
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
            LabelTotal.Location = new Point(171, 222);
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
            tableLayoutPanel1.Location = new Point(0, 553);
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
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(633, 61);
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
            label2.Location = new Point(466, 259);
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
            pictureBox1.Location = new Point(631, 256);
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
            label1.Location = new Point(531, 124);
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
            pictureBox2.Location = new Point(631, 121);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 31);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 30;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(563, 63);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 34;
            label5.Text = "إسم الملف";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(571, 167);
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
            label4.Location = new Point(571, 195);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 36;
            label4.Text = "بخصوص";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(629, 165);
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
            pictureBox4.Location = new Point(629, 193);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(16, 18);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 38;
            pictureBox4.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(555, 223);
            label6.Name = "label6";
            label6.Size = new Size(68, 15);
            label6.TabIndex = 39;
            label6.Text = "تاريخ الإدخال";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(271, 224);
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
            label8.Size = new Size(259, 28);
            label8.TabIndex = 41;
            label8.Text = "إستيراد مقايسة من ملف إكسل";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(629, 222);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(16, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 42;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(364, 222);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(16, 18);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 43;
            pictureBox6.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(16, 461);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.No;
            button1.Size = new Size(99, 30);
            button1.TabIndex = 75;
            button1.Text = "حفظ المقايسة";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += metroButton4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(117, 58);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.No;
            button2.Size = new Size(99, 27);
            button2.TabIndex = 75;
            button2.Text = "إختيار الملف";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += metroButton1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(142, 435);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.RightToLeft = RightToLeft.Yes;
            richTextBox1.Size = new Size(525, 96);
            richTextBox1.TabIndex = 76;
            richTextBox1.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Black;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(547, 95);
            label9.Name = "label9";
            label9.Size = new Size(76, 15);
            label9.TabIndex = 78;
            label9.Text = "اصل المقايسة";
            // 
            // TextBoxOrigAssFile
            // 
            TextBoxOrigAssFile.Enabled = false;
            TextBoxOrigAssFile.FontSize = MetroFramework.MetroTextBoxSize.Small;
            TextBoxOrigAssFile.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            TextBoxOrigAssFile.Location = new Point(234, 91);
            TextBoxOrigAssFile.Multiline = false;
            TextBoxOrigAssFile.Name = "TextBoxOrigAssFile";
            TextBoxOrigAssFile.SelectedText = "";
            TextBoxOrigAssFile.Size = new Size(291, 23);
            TextBoxOrigAssFile.Style = MetroFramework.MetroColorStyle.Blue;
            TextBoxOrigAssFile.StyleManager = null;
            TextBoxOrigAssFile.TabIndex = 79;
            TextBoxOrigAssFile.Theme = MetroFramework.MetroThemeStyle.Light;
            TextBoxOrigAssFile.UseStyleColors = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Transparent;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(633, 93);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(16, 18);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.TabIndex = 83;
            pictureBox9.TabStop = false;
            // 
            // pictureBox12
            // 
            pictureBox12.BackColor = Color.Transparent;
            pictureBox12.Image = Properties.Resources.Close_16;
            pictureBox12.Location = new Point(147, 92);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(20, 20);
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.TabIndex = 85;
            pictureBox12.TabStop = false;
            pictureBox12.Click += pictureBox12_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(172, 89);
            button3.Name = "button3";
            button3.RightToLeft = RightToLeft.No;
            button3.Size = new Size(27, 27);
            button3.TabIndex = 84;
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click_2;
            // 
            // ImportAssessment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(679, 580);
            Controls.Add(pictureBox12);
            Controls.Add(button3);
            Controls.Add(pictureBox9);
            Controls.Add(label9);
            Controls.Add(TextBoxOrigAssFile);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox7);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(LabelTotal);
            Controls.Add(LabelDate);
            Controls.Add(TextBoxAbout);
            Controls.Add(TextBoxSubject);
            Controls.Add(DGV_Data);
            Controls.Add(TextBoxURL);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImportAssessment";
            Text = "ImportAssessment";
            ((System.ComponentModel.ISupportInitialize)DGV_Data).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TextBoxURL;
        private DataGridView DGV_Data;
        private MetroFramework.Controls.MetroTextBox TextBoxSubject;
        private MetroFramework.Controls.MetroTextBox TextBoxAbout;
        private MetroFramework.Controls.MetroLabel LabelDate;
        private MetroFramework.Controls.MetroLabel LabelTotal;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxStatus;
        private Label labelStatus;
        private PictureBox pictureBox7;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label5;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label6;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn LOL;
        private DataGridViewTextBoxColumn Column6;
        private Label label9;
        private MetroFramework.Controls.MetroTextBox TextBoxOrigAssFile;
        private PictureBox pictureBox9;
        private PictureBox pictureBox12;
        private Button button3;
    }
}