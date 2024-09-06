namespace HORAS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroLabel3 = new MetroFramework.Controls.MetroLabel();
            pictureBox2 = new PictureBox();
            labelDate = new Label();
            LabelTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            labelError = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(384, 310);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.CustomBackground = false;
            metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel2.Location = new Point(565, 149);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new Size(88, 19);
            metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel2.StyleManager = null;
            metroLabel2.TabIndex = 2;
            metroLabel2.Text = "إسم المتسخدم";
            metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel2.UseStyleColors = false;
            // 
            // metroLabel3
            // 
            metroLabel3.AutoSize = true;
            metroLabel3.CustomBackground = false;
            metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel3.Location = new Point(586, 179);
            metroLabel3.Name = "metroLabel3";
            metroLabel3.Size = new Size(67, 19);
            metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel3.StyleManager = null;
            metroLabel3.TabIndex = 2;
            metroLabel3.Text = "كلمة المرور";
            metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel3.UseStyleColors = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(488, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(96, 122);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(600, 282);
            labelDate.Name = "labelDate";
            labelDate.RightToLeft = RightToLeft.Yes;
            labelDate.Size = new Size(38, 15);
            labelDate.TabIndex = 5;
            labelDate.Text = "label1";
            // 
            // LabelTime
            // 
            LabelTime.AutoSize = true;
            LabelTime.Location = new Point(479, 282);
            LabelTime.Name = "LabelTime";
            LabelTime.RightToLeft = RightToLeft.Yes;
            LabelTime.Size = new Size(38, 15);
            LabelTime.TabIndex = 5;
            LabelTime.Text = "label1";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(545, 238);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.Yes;
            button1.Size = new Size(63, 25);
            button1.TabIndex = 6;
            button1.Text = "دخول";
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(431, 177);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.RightToLeft = RightToLeft.Yes;
            textBoxPassword.Size = new Size(124, 23);
            textBoxPassword.TabIndex = 7;
            textBoxPassword.Text = "20080134";
            textBoxPassword.TextAlign = HorizontalAlignment.Center;
            textBoxPassword.KeyPress += textBoxPassword_KeyPress;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(431, 147);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(124, 23);
            textBoxUsername.TabIndex = 7;
            textBoxUsername.Text = "Maro";
            textBoxUsername.TextAlign = HorizontalAlignment.Center;
            textBoxUsername.KeyPress += textBoxPassword_KeyPress;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.ForeColor = Color.Red;
            labelError.Location = new Point(451, 208);
            labelError.Name = "labelError";
            labelError.RightToLeft = RightToLeft.Yes;
            labelError.Size = new Size(174, 15);
            labelError.TabIndex = 8;
            labelError.Text = "خطأ فى كلمة المرور أو كلمة المرور";
            labelError.Visible = false;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(447, 238);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.Yes;
            button2.Size = new Size(72, 25);
            button2.TabIndex = 9;
            button2.Text = "خروج";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.TextImageRelation = TextImageRelation.TextBeforeImage;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(670, 310);
            Controls.Add(button2);
            Controls.Add(labelError);
            Controls.Add(textBoxUsername);
            Controls.Add(textBoxPassword);
            Controls.Add(button1);
            Controls.Add(LabelTime);
            Controls.Add(labelDate);
            Controls.Add(pictureBox2);
            Controls.Add(metroLabel3);
            Controls.Add(metroLabel2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private PictureBox pictureBox2;
        private Label labelDate;
        private Label LabelTime;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Label labelError;
        private Button button2;
    }
}