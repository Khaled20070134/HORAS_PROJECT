namespace HORAS.Collections
{
    partial class ContractCollections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractCollections));
            label8 = new Label();
            buttonchosecontract = new Button();
            comboBoxContracts = new ComboBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            listBoxdownpayment = new ListBox();
            listBoxSalesInv = new ListBox();
            label2 = new Label();
            label3 = new Label();
            labelDPAmount = new Label();
            label30 = new Label();
            pictureBox16 = new PictureBox();
            labeDPBank = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            labelDPcolDate = new Label();
            label7 = new Label();
            pictureBox3 = new PictureBox();
            labelDPcolNum = new Label();
            label10 = new Label();
            pictureBox4 = new PictureBox();
            labelTotalPaymentsAmount = new Label();
            label6 = new Label();
            pictureBox5 = new PictureBox();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxStatus = new PictureBox();
            labelStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(237, 29);
            label8.Name = "label8";
            label8.Size = new Size(226, 28);
            label8.TabIndex = 45;
            label8.Text = "بيانات تحصيلات التعاقدات";
            // 
            // buttonchosecontract
            // 
            buttonchosecontract.Location = new Point(185, 93);
            buttonchosecontract.Name = "buttonchosecontract";
            buttonchosecontract.Size = new Size(75, 23);
            buttonchosecontract.TabIndex = 223;
            buttonchosecontract.Text = "اختيار عقد";
            buttonchosecontract.UseVisualStyleBackColor = true;
            buttonchosecontract.Click += buttonchosecontract_Click;
            // 
            // comboBoxContracts
            // 
            comboBoxContracts.FormattingEnabled = true;
            comboBoxContracts.Location = new Point(266, 92);
            comboBoxContracts.Name = "comboBoxContracts";
            comboBoxContracts.Size = new Size(214, 23);
            comboBoxContracts.TabIndex = 222;
            comboBoxContracts.DropDown += comboBoxContracts_DropDown;
            comboBoxContracts.SelectedIndexChanged += comboBoxContracts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(528, 93);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 221;
            label1.Text = "رقم التعاقد";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(617, 94);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(16, 18);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 220;
            pictureBox2.TabStop = false;
            // 
            // listBoxdownpayment
            // 
            listBoxdownpayment.FormattingEnabled = true;
            listBoxdownpayment.ItemHeight = 15;
            listBoxdownpayment.Location = new Point(504, 204);
            listBoxdownpayment.Name = "listBoxdownpayment";
            listBoxdownpayment.Size = new Size(131, 154);
            listBoxdownpayment.TabIndex = 224;
            listBoxdownpayment.SelectedIndexChanged += listBoxdownpayment_SelectedIndexChanged;
            // 
            // listBoxSalesInv
            // 
            listBoxSalesInv.FormattingEnabled = true;
            listBoxSalesInv.ItemHeight = 15;
            listBoxSalesInv.Location = new Point(140, 204);
            listBoxSalesInv.Name = "listBoxSalesInv";
            listBoxSalesInv.Size = new Size(143, 154);
            listBoxSalesInv.TabIndex = 225;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(504, 148);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 226;
            label2.Text = "الدفعات المقدمة";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(185, 148);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 227;
            label3.Text = "الفواتير";
            // 
            // labelDPAmount
            // 
            labelDPAmount.AutoSize = true;
            labelDPAmount.BackColor = Color.Transparent;
            labelDPAmount.ForeColor = Color.White;
            labelDPAmount.Location = new Point(407, 414);
            labelDPAmount.Name = "labelDPAmount";
            labelDPAmount.Size = new Size(13, 15);
            labelDPAmount.TabIndex = 230;
            labelDPAmount.Text = "0";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = Color.Transparent;
            label30.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label30.ForeColor = SystemColors.ActiveCaption;
            label30.Location = new Point(504, 414);
            label30.Name = "label30";
            label30.Size = new Size(102, 15);
            label30.TabIndex = 229;
            label30.Text = "اجمالي قيمة الدفعه";
            // 
            // pictureBox16
            // 
            pictureBox16.BackColor = Color.Transparent;
            pictureBox16.Image = (Image)resources.GetObject("pictureBox16.Image");
            pictureBox16.Location = new Point(612, 412);
            pictureBox16.Name = "pictureBox16";
            pictureBox16.Size = new Size(16, 18);
            pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox16.TabIndex = 228;
            pictureBox16.TabStop = false;
            // 
            // labeDPBank
            // 
            labeDPBank.AutoSize = true;
            labeDPBank.BackColor = Color.Transparent;
            labeDPBank.ForeColor = Color.White;
            labeDPBank.Location = new Point(408, 366);
            labeDPBank.Name = "labeDPBank";
            labeDPBank.Size = new Size(13, 15);
            labeDPBank.TabIndex = 233;
            labeDPBank.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(575, 364);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 232;
            label5.Text = "البنك";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(613, 364);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 18);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 231;
            pictureBox1.TabStop = false;
            // 
            // labelDPcolDate
            // 
            labelDPcolDate.AutoSize = true;
            labelDPcolDate.BackColor = Color.Transparent;
            labelDPcolDate.ForeColor = Color.White;
            labelDPcolDate.Location = new Point(407, 440);
            labelDPcolDate.Name = "labelDPcolDate";
            labelDPcolDate.Size = new Size(13, 15);
            labelDPcolDate.TabIndex = 236;
            labelDPcolDate.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(547, 438);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 235;
            label7.Text = "تاريخ الدفع";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(612, 438);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(16, 18);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 234;
            pictureBox3.TabStop = false;
            // 
            // labelDPcolNum
            // 
            labelDPcolNum.AutoSize = true;
            labelDPcolNum.BackColor = Color.Transparent;
            labelDPcolNum.ForeColor = Color.White;
            labelDPcolNum.Location = new Point(407, 389);
            labelDPcolNum.Name = "labelDPcolNum";
            labelDPcolNum.Size = new Size(13, 15);
            labelDPcolNum.TabIndex = 239;
            labelDPcolNum.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.ForeColor = SystemColors.ActiveCaption;
            label10.Location = new Point(542, 389);
            label10.Name = "label10";
            label10.Size = new Size(64, 15);
            label10.TabIndex = 238;
            label10.Text = "رقم التحويل";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(612, 387);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(16, 18);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 237;
            pictureBox4.TabStop = false;
            // 
            // labelTotalPaymentsAmount
            // 
            labelTotalPaymentsAmount.AutoSize = true;
            labelTotalPaymentsAmount.BackColor = Color.Transparent;
            labelTotalPaymentsAmount.ForeColor = Color.White;
            labelTotalPaymentsAmount.Location = new Point(408, 187);
            labelTotalPaymentsAmount.Name = "labelTotalPaymentsAmount";
            labelTotalPaymentsAmount.Size = new Size(13, 15);
            labelTotalPaymentsAmount.TabIndex = 242;
            labelTotalPaymentsAmount.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(509, 186);
            label6.Name = "label6";
            label6.Size = new Size(126, 15);
            label6.TabIndex = 241;
            label6.Text = "اجمالي الدفعات المقدمة";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(617, 184);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(16, 18);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 240;
            pictureBox5.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline);
            label4.ForeColor = SystemColors.ActiveCaption;
            label4.Location = new Point(537, 467);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 244;
            label4.Text = "عرض المرفق";
            label4.Click += label4_Click;
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
            tableLayoutPanel1.Location = new Point(0, 496);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(665, 27);
            tableLayoutPanel1.TabIndex = 245;
            // 
            // pictureBoxStatus
            // 
            pictureBoxStatus.Dock = DockStyle.Fill;
            pictureBoxStatus.Location = new Point(637, 3);
            pictureBoxStatus.Name = "pictureBoxStatus";
            pictureBoxStatus.Size = new Size(25, 21);
            pictureBoxStatus.TabIndex = 0;
            pictureBoxStatus.TabStop = false;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Dock = DockStyle.Right;
            labelStatus.ForeColor = Color.White;
            labelStatus.ImageAlign = ContentAlignment.MiddleLeft;
            labelStatus.Location = new Point(621, 0);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(10, 27);
            labelStatus.TabIndex = 1;
            labelStatus.Text = ".";
            labelStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ContractCollections
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(665, 523);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(label4);
            Controls.Add(labelTotalPaymentsAmount);
            Controls.Add(label6);
            Controls.Add(pictureBox5);
            Controls.Add(labelDPcolNum);
            Controls.Add(label10);
            Controls.Add(pictureBox4);
            Controls.Add(labelDPcolDate);
            Controls.Add(label7);
            Controls.Add(pictureBox3);
            Controls.Add(labeDPBank);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(labelDPAmount);
            Controls.Add(label30);
            Controls.Add(pictureBox16);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBoxSalesInv);
            Controls.Add(listBoxdownpayment);
            Controls.Add(buttonchosecontract);
            Controls.Add(comboBoxContracts);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ContractCollections";
            Text = "ContractCollections";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox16).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private Button buttonchosecontract;
        private ComboBox comboBoxContracts;
        private Label label1;
        private PictureBox pictureBox2;
        private ListBox listBoxdownpayment;
        private ListBox listBoxSalesInv;
        private Label label2;
        private Label label3;
        private Label labelDPAmount;
        private Label label30;
        private PictureBox pictureBox16;
        private Label labeDPBank;
        private Label label5;
        private PictureBox pictureBox1;
        private Label labelDPcolDate;
        private Label label7;
        private PictureBox pictureBox3;
        private Label labelDPcolNum;
        private Label label10;
        private PictureBox pictureBox4;
        private Label labelTotalPaymentsAmount;
        private Label label6;
        private PictureBox pictureBox5;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxStatus;
        private Label labelStatus;
    }
}