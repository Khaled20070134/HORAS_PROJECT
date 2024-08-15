namespace HORAS.EmployeFolder.Employees
{
    partial class EmployeesMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesMain));
            panel1 = new Panel();
            metroButton8 = new MetroFramework.Controls.MetroButton();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            metroButton7 = new MetroFramework.Controls.MetroButton();
            metroButton4 = new MetroFramework.Controls.MetroButton();
            metroButton5 = new MetroFramework.Controls.MetroButton();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            MasterPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(metroButton8);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(metroButton7);
            panel1.Controls.Add(metroButton4);
            panel1.Controls.Add(metroButton5);
            panel1.Controls.Add(metroButton1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(633, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(167, 450);
            panel1.TabIndex = 7;
            // 
            // metroButton8
            // 
            metroButton8.Highlight = true;
            metroButton8.Image = Properties.Resources.plus___480px;
            metroButton8.ImageAlign = ContentAlignment.MiddleRight;
            metroButton8.Location = new Point(1, 177);
            metroButton8.Name = "metroButton8";
            metroButton8.Size = new Size(164, 27);
            metroButton8.Style = MetroFramework.MetroColorStyle.Black;
            metroButton8.StyleManager = null;
            metroButton8.TabIndex = 6;
            metroButton8.Text = "تغيير/ مسج بيانات موظف";
            metroButton8.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton8.Click += metroButton8_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 11;
            label1.Text = "إدارة بيانات الموظفين";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(64, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 42);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // metroButton7
            // 
            metroButton7.Highlight = true;
            metroButton7.Image = Properties.Resources.plus___480px;
            metroButton7.ImageAlign = ContentAlignment.MiddleRight;
            metroButton7.Location = new Point(1, 227);
            metroButton7.Name = "metroButton7";
            metroButton7.Size = new Size(164, 27);
            metroButton7.Style = MetroFramework.MetroColorStyle.Black;
            metroButton7.StyleManager = null;
            metroButton7.TabIndex = 9;
            metroButton7.Text = "عرض أنشطة الموظفين";
            metroButton7.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton7.Click += metroButton7_Click;
            // 
            // metroButton4
            // 
            metroButton4.Highlight = true;
            metroButton4.Image = Properties.Resources.plus___480px;
            metroButton4.ImageAlign = ContentAlignment.MiddleRight;
            metroButton4.Location = new Point(6, 417);
            metroButton4.Name = "metroButton4";
            metroButton4.Size = new Size(159, 27);
            metroButton4.Style = MetroFramework.MetroColorStyle.Black;
            metroButton4.StyleManager = null;
            metroButton4.TabIndex = 7;
            metroButton4.Text = "الرجوع للقائمة الرئيسية";
            metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton4.Click += metroButton4_Click;
            // 
            // metroButton5
            // 
            metroButton5.Highlight = true;
            metroButton5.Image = Properties.Resources.plus___480px;
            metroButton5.ImageAlign = ContentAlignment.MiddleRight;
            metroButton5.Location = new Point(1, 202);
            metroButton5.Name = "metroButton5";
            metroButton5.Size = new Size(164, 27);
            metroButton5.Style = MetroFramework.MetroColorStyle.Black;
            metroButton5.StyleManager = null;
            metroButton5.TabIndex = 5;
            metroButton5.Text = "عرض بيانات الموظفين";
            metroButton5.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton5.Click += metroButton5_Click;
            // 
            // metroButton1
            // 
            metroButton1.Highlight = true;
            metroButton1.Image = Properties.Resources.plus___480px;
            metroButton1.ImageAlign = ContentAlignment.MiddleRight;
            metroButton1.Location = new Point(1, 152);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new Size(164, 27);
            metroButton1.Style = MetroFramework.MetroColorStyle.Black;
            metroButton1.StyleManager = null;
            metroButton1.TabIndex = 4;
            metroButton1.Text = "إدخال موظف جديد";
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton1.Click += metroButton1_Click;
            // 
            // MasterPanel
            // 
            MasterPanel.BackgroundImage = (Image)resources.GetObject("MasterPanel.BackgroundImage");
            MasterPanel.BackgroundImageLayout = ImageLayout.Stretch;
            MasterPanel.Dock = DockStyle.Left;
            MasterPanel.Location = new Point(0, 0);
            MasterPanel.Name = "MasterPanel";
            MasterPanel.Size = new Size(633, 450);
            MasterPanel.TabIndex = 8;
            // 
            // EmployeesMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(MasterPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeesMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeesMain";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private MetroFramework.Controls.MetroButton metroButton8;
        private Label label1;
        private PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton1;
        private Panel MasterPanel;
    }
}