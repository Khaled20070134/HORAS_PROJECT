namespace HORAS.EmployeFolder
{
    partial class ActivityEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityEmployee));
            label1 = new Label();
            textBoxUserName = new TextBox();
            label8 = new Label();
            pictureBox6 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            DTPFrom = new DateTimePicker();
            DTPTo = new DateTimePicker();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxStatus = new PictureBox();
            labelStatus = new Label();
            Activity_Description = new DataGridViewTextBoxColumn();
            Activity_Desc = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(202, 9);
            label1.Name = "label1";
            label1.Size = new Size(252, 28);
            label1.TabIndex = 1;
            label1.Text = "عرض النشاط الخاص بموظف";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(390, 61);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(100, 23);
            textBoxUserName.TabIndex = 66;
            textBoxUserName.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.ForeColor = Color.White;
            label8.Location = new Point(497, 65);
            label8.Name = "label8";
            label8.Size = new Size(78, 15);
            label8.TabIndex = 65;
            label8.Text = "إسم المستخدم";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(578, 63);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(16, 18);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 64;
            pictureBox6.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(506, 103);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 68;
            label2.Text = "الفترة الزمنية";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(578, 101);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 18);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 67;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.White;
            label3.Location = new Point(468, 104);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 69;
            label3.Text = "من";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Location = new Point(466, 138);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 70;
            label4.Text = "إلى";
            // 
            // DTPFrom
            // 
            DTPFrom.Location = new Point(233, 100);
            DTPFrom.Name = "DTPFrom";
            DTPFrom.Size = new Size(200, 23);
            DTPFrom.TabIndex = 71;
            DTPFrom.ValueChanged += DTPFrom_ValueChanged;
            // 
            // DTPTo
            // 
            DTPTo.Location = new Point(233, 134);
            DTPTo.Name = "DTPTo";
            DTPTo.Size = new Size(200, 23);
            DTPTo.TabIndex = 72;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Image = Properties.Resources.Info_16;
            button2.Location = new Point(49, 132);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.No;
            button2.Size = new Size(110, 25);
            button2.TabIndex = 73;
            button2.Text = "عرض البيانات";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Activity_Description, Activity_Desc });
            dataGridView1.GridColor = Color.FromArgb(64, 0, 0);
            dataGridView1.Location = new Point(12, 178);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(599, 237);
            dataGridView1.TabIndex = 74;
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
            tableLayoutPanel1.Location = new Point(0, 423);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(623, 27);
            tableLayoutPanel1.TabIndex = 75;
            // 
            // pictureBoxStatus
            // 
            pictureBoxStatus.Dock = DockStyle.Fill;
            pictureBoxStatus.Location = new Point(597, 3);
            pictureBoxStatus.Name = "pictureBoxStatus";
            pictureBoxStatus.Size = new Size(23, 21);
            pictureBoxStatus.TabIndex = 0;
            pictureBoxStatus.TabStop = false;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Dock = DockStyle.Right;
            labelStatus.ForeColor = Color.White;
            labelStatus.ImageAlign = ContentAlignment.MiddleLeft;
            labelStatus.Location = new Point(581, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(10, 27);
            labelStatus.TabIndex = 1;
            labelStatus.Text = ".";
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Activity_Description
            // 
            Activity_Description.HeaderText = "Date";
            Activity_Description.Name = "Activity_Description";
            Activity_Description.ReadOnly = true;
            // 
            // Activity_Desc
            // 
            Activity_Desc.HeaderText = "Description";
            Activity_Desc.Name = "Activity_Desc";
            Activity_Desc.ReadOnly = true;
            Activity_Desc.Width = 300;
            // 
            // ActivityEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(623, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(DTPTo);
            Controls.Add(DTPFrom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxUserName);
            Controls.Add(label8);
            Controls.Add(pictureBox6);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ActivityEmployee";
            Text = "ActivityEmployee";
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxUserName;
        private Label label8;
        private PictureBox pictureBox6;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private DateTimePicker DTPFrom;
        private DateTimePicker DTPTo;
        private Button button2;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxStatus;
        private Label labelStatus;
        private DataGridViewTextBoxColumn Activity_Description;
        private DataGridViewTextBoxColumn Activity_Desc;
    }
}