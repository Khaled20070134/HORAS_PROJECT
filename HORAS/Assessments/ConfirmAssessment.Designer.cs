namespace HORAS.Assessments
{
    partial class ConfirmAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmAssessment));
            DGV_Data = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
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
            label7 = new Label();
            label8 = new Label();
            pictureBox6 = new PictureBox();
            ComboAssIDS = new MetroFramework.Controls.MetroComboBox();
            labelSubject = new Label();
            labelAbout = new Label();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Data).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // DGV_Data
            // 
            DGV_Data.AllowUserToAddRows = false;
            DGV_Data.AllowUserToDeleteRows = false;
            DGV_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Data.Columns.AddRange(new DataGridViewColumn[] { Column1, Column3, Column4, Column5, Column7, Column6 });
            DGV_Data.EditMode = DataGridViewEditMode.EditOnEnter;
            DGV_Data.Location = new Point(17, 268);
            DGV_Data.MultiSelect = false;
            DGV_Data.Name = "DGV_Data";
            DGV_Data.ReadOnly = true;
            DGV_Data.RightToLeft = RightToLeft.Yes;
            DGV_Data.Size = new Size(650, 138);
            DGV_Data.TabIndex = 3;
            DGV_Data.SelectionChanged += DGV_Data_SelectionChanged;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "مسلسل";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "الوحدة";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
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
            // LabelTotal
            // 
            LabelTotal.AutoSize = true;
            LabelTotal.BackColor = Color.Transparent;
            LabelTotal.CustomBackground = true;
            LabelTotal.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelTotal.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelTotal.ForeColor = Color.White;
            LabelTotal.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelTotal.Location = new Point(105, 61);
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
            tableLayoutPanel1.Location = new Point(0, 527);
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
            label2.Location = new Point(471, 234);
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
            pictureBox1.Location = new Point(636, 231);
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
            label1.Location = new Point(536, 134);
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
            pictureBox2.Location = new Point(636, 131);
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
            label5.ForeColor = Color.White;
            label5.Location = new Point(567, 63);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 34;
            label5.Text = "رقم المقايسة";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Location = new Point(576, 168);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 35;
            label3.Text = "الموضوع";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Location = new Point(576, 196);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 36;
            label4.Text = "بخصوص";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(634, 166);
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
            pictureBox4.Location = new Point(634, 194);
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
            label7.ForeColor = Color.White;
            label7.Location = new Point(197, 63);
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
            label8.Location = new Point(269, 4);
            label8.Name = "label8";
            label8.Size = new Size(183, 28);
            label8.TabIndex = 41;
            label8.Text = "تأكيد بيانات المقايسة";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(290, 61);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(16, 18);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 43;
            pictureBox6.TabStop = false;
            // 
            // ComboAssIDS
            // 
            ComboAssIDS.DrawMode = DrawMode.OwnerDrawFixed;
            ComboAssIDS.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboAssIDS.FontSize = MetroFramework.MetroLinkSize.Medium;
            ComboAssIDS.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            ComboAssIDS.FormattingEnabled = true;
            ComboAssIDS.ItemHeight = 23;
            ComboAssIDS.Location = new Point(368, 56);
            ComboAssIDS.Name = "ComboAssIDS";
            ComboAssIDS.Size = new Size(172, 29);
            ComboAssIDS.Style = MetroFramework.MetroColorStyle.Blue;
            ComboAssIDS.StyleManager = null;
            ComboAssIDS.TabIndex = 44;
            ComboAssIDS.Theme = MetroFramework.MetroThemeStyle.Light;
            ComboAssIDS.DropDown += ComboAssIDS_DropDown;
            ComboAssIDS.SelectedIndexChanged += ComboAssIDS_SelectedIndexChanged;
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.BackColor = Color.Transparent;
            labelSubject.ForeColor = Color.White;
            labelSubject.Location = new Point(489, 169);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(52, 15);
            labelSubject.TabIndex = 45;
            labelSubject.Text = "الموضوع";
            // 
            // labelAbout
            // 
            labelAbout.AutoSize = true;
            labelAbout.BackColor = Color.Transparent;
            labelAbout.ForeColor = Color.White;
            labelAbout.Location = new Point(489, 197);
            labelAbout.Name = "labelAbout";
            labelAbout.Size = new Size(52, 15);
            labelAbout.TabIndex = 46;
            labelAbout.Text = "بخصوص";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Image = Properties.Resources.Confirm_16;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(26, 446);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 47;
            button1.Text = "تأكيد";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(134, 418);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.RightToLeft = RightToLeft.Yes;
            richTextBox1.Size = new Size(525, 96);
            richTextBox1.TabIndex = 77;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(105, 109);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.No;
            button2.Size = new Size(152, 27);
            button2.TabIndex = 78;
            button2.Text = "أصل المقايسه";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // ConfirmAssessment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(679, 554);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(labelAbout);
            Controls.Add(labelSubject);
            Controls.Add(ComboAssIDS);
            Controls.Add(pictureBox6);
            Controls.Add(label8);
            Controls.Add(label7);
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
            Controls.Add(DGV_Data);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConfirmAssessment";
            Text = "ImportAssessment";
            Load += ConfirmAssessment_Load;
            ((System.ComponentModel.ISupportInitialize)DGV_Data).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DGV_Data;
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
        private Label label7;
        private Label label8;
        private PictureBox pictureBox6;
        private MetroFramework.Controls.MetroComboBox ComboAssIDS;
        private Label labelSubject;
        private Label labelAbout;
        private Button button1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column6;
        private RichTextBox richTextBox1;
        private Button button2;
    }
}