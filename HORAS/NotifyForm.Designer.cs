namespace HORAS
{
    partial class NotifyForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyForm));
            pictureBox11 = new PictureBox();
            label3 = new Label();
            labelContracts = new Label();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            labelAss = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            linkLabel3 = new LinkLabel();
            labelExps = new Label();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            linkLabel4 = new LinkLabel();
            labelInt = new Label();
            label7 = new Label();
            pictureBox3 = new PictureBox();
            metroButton7 = new MetroFramework.Controls.MetroButton();
            label8 = new Label();
            pictureBox4 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox11
            // 
            pictureBox11.BackColor = Color.Transparent;
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(427, 87);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(16, 18);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 27;
            pictureBox11.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaption;
            label3.Location = new Point(281, 89);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(143, 15);
            label3.TabIndex = 28;
            label3.Text = "عدد التعاقدات الغير موقعه :";
            label3.UseMnemonic = false;
            // 
            // labelContracts
            // 
            labelContracts.AutoSize = true;
            labelContracts.BackColor = Color.Transparent;
            labelContracts.Font = new Font("Segoe UI", 9F);
            labelContracts.ForeColor = Color.White;
            labelContracts.Location = new Point(231, 90);
            labelContracts.Name = "labelContracts";
            labelContracts.Size = new Size(13, 15);
            labelContracts.TabIndex = 29;
            labelContracts.Text = "0";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.LinkColor = Color.FromArgb(192, 192, 255);
            linkLabel1.Location = new Point(102, 87);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(84, 15);
            linkLabel1.TabIndex = 30;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "توقيع التعاقدات";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.BackColor = Color.Transparent;
            linkLabel2.LinkColor = Color.FromArgb(192, 192, 255);
            linkLabel2.Location = new Point(102, 121);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(84, 15);
            linkLabel2.TabIndex = 34;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "تأكيد المقايسات";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // labelAss
            // 
            labelAss.AutoSize = true;
            labelAss.BackColor = Color.Transparent;
            labelAss.Font = new Font("Segoe UI", 9F);
            labelAss.ForeColor = Color.White;
            labelAss.Location = new Point(231, 124);
            labelAss.Name = "labelAss";
            labelAss.Size = new Size(13, 15);
            labelAss.TabIndex = 33;
            labelAss.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaption;
            label2.Location = new Point(278, 123);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(146, 15);
            label2.TabIndex = 32;
            label2.Text = "عدد المقايسات الغير مؤكدة :";
            label2.UseMnemonic = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(427, 121);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 18);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.BackColor = Color.Transparent;
            linkLabel3.LinkColor = Color.FromArgb(192, 192, 255);
            linkLabel3.Location = new Point(98, 158);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(88, 15);
            linkLabel3.TabIndex = 38;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "تأكيد المصروفات";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // labelExps
            // 
            labelExps.AutoSize = true;
            labelExps.BackColor = Color.Transparent;
            labelExps.Font = new Font("Segoe UI", 9F);
            labelExps.ForeColor = Color.White;
            labelExps.Location = new Point(231, 161);
            labelExps.Name = "labelExps";
            labelExps.Size = new Size(13, 15);
            labelExps.TabIndex = 37;
            labelExps.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaption;
            label5.Location = new Point(274, 160);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(150, 15);
            label5.TabIndex = 36;
            label5.Text = "عدد المصروفات الغير مؤكدة :";
            label5.UseMnemonic = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(427, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(16, 18);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 35;
            pictureBox2.TabStop = false;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.BackColor = Color.Transparent;
            linkLabel4.LinkColor = Color.FromArgb(192, 192, 255);
            linkLabel4.Location = new Point(88, 196);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(98, 15);
            linkLabel4.TabIndex = 42;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "تأكيد المستخلصات";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // labelInt
            // 
            labelInt.AutoSize = true;
            labelInt.BackColor = Color.Transparent;
            labelInt.Font = new Font("Segoe UI", 9F);
            labelInt.ForeColor = Color.White;
            labelInt.Location = new Point(231, 199);
            labelInt.Name = "labelInt";
            labelInt.Size = new Size(13, 15);
            labelInt.TabIndex = 41;
            labelInt.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ActiveCaption;
            label7.Location = new Point(264, 198);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(160, 15);
            label7.TabIndex = 40;
            label7.Text = "عدد المستخلصات الغير مؤكدة :";
            label7.UseMnemonic = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(427, 196);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(16, 18);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 39;
            pictureBox3.TabStop = false;
            // 
            // metroButton7
            // 
            metroButton7.Highlight = true;
            metroButton7.Image = Properties.Resources.plus___480px;
            metroButton7.ImageAlign = ContentAlignment.MiddleRight;
            metroButton7.Location = new Point(189, 247);
            metroButton7.Name = "metroButton7";
            metroButton7.Size = new Size(164, 27);
            metroButton7.Style = MetroFramework.MetroColorStyle.Black;
            metroButton7.StyleManager = null;
            metroButton7.TabIndex = 43;
            metroButton7.Text = "إغـــــــــــــــــــــلاق";
            metroButton7.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton7.Click += metroButton7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ActiveCaption;
            label8.Location = new Point(314, 26);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.Yes;
            label8.Size = new Size(157, 28);
            label8.TabIndex = 44;
            label8.Text = "الإشعارات الإدارية";
            label8.UseMnemonic = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Image = Properties.Resources.Dashboard_32;
            pictureBox4.Location = new Point(477, 22);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(36, 37);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 45;
            pictureBox4.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 3000;
            timer1.Tick += timer1_Tick;
            // 
            // NotifyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(536, 297);
            Controls.Add(pictureBox4);
            Controls.Add(label8);
            Controls.Add(metroButton7);
            Controls.Add(linkLabel4);
            Controls.Add(labelInt);
            Controls.Add(label7);
            Controls.Add(pictureBox3);
            Controls.Add(linkLabel3);
            Controls.Add(labelExps);
            Controls.Add(label5);
            Controls.Add(pictureBox2);
            Controls.Add(linkLabel2);
            Controls.Add(labelAss);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel1);
            Controls.Add(labelContracts);
            Controls.Add(label3);
            Controls.Add(pictureBox11);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NotifyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NotifyForm";
            Shown += NotifyForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox11;
        private Label label3;
        private Label labelContracts;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Label labelAss;
        private Label label2;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel3;
        private Label labelExps;
        private Label label5;
        private PictureBox pictureBox2;
        private LinkLabel linkLabel4;
        private Label labelInt;
        private Label label7;
        private PictureBox pictureBox3;
        private MetroFramework.Controls.MetroButton metroButton7;
        private Label label8;
        private PictureBox pictureBox4;
        private System.Windows.Forms.Timer timer1;
    }
}