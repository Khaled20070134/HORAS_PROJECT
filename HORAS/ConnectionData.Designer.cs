namespace HORAS
{
    partial class ConnectionData
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
            label1 = new Label();
            textBoxServer = new TextBox();
            textBoxDB = new TextBox();
            label2 = new Label();
            textBoxLogin = new TextBox();
            label3 = new Label();
            textBoxPassword = new TextBox();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 105);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Server ID";
            // 
            // textBoxServer
            // 
            textBoxServer.Location = new Point(135, 97);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.Size = new Size(273, 23);
            textBoxServer.TabIndex = 1;
            // 
            // textBoxDB
            // 
            textBoxDB.Location = new Point(135, 130);
            textBoxDB.Name = "textBoxDB";
            textBoxDB.Size = new Size(273, 23);
            textBoxDB.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 138);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "DataBase";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(135, 167);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(273, 23);
            textBoxLogin.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 175);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 4;
            label3.Text = "Login ID";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(135, 204);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(273, 23);
            textBoxPassword.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 212);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // button1
            // 
            button1.Location = new Point(207, 250);
            button1.Name = "button1";
            button1.Size = new Size(129, 23);
            button1.TabIndex = 8;
            button1.Text = "Start Application";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label5.Location = new Point(55, 19);
            label5.Name = "label5";
            label5.Size = new Size(237, 28);
            label5.TabIndex = 9;
            label5.Text = "Database Configuration";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.databasesettings_32;
            pictureBox1.Location = new Point(12, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(81, 51);
            label6.Name = "label6";
            label6.Size = new Size(308, 15);
            label6.TabIndex = 11;
            label6.Text = "Enter Database Configuration data for testing connection";
            // 
            // button2
            // 
            button2.Location = new Point(123, 250);
            button2.Name = "button2";
            button2.Size = new Size(78, 23);
            button2.TabIndex = 12;
            button2.Text = "Defaults";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ConnectionData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 285);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(textBoxPassword);
            Controls.Add(label4);
            Controls.Add(textBoxLogin);
            Controls.Add(label3);
            Controls.Add(textBoxDB);
            Controls.Add(label2);
            Controls.Add(textBoxServer);
            Controls.Add(label1);
            Name = "ConnectionData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConnectionData";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxServer;
        private TextBox textBoxDB;
        private Label label2;
        private TextBox textBoxLogin;
        private Label label3;
        private TextBox textBoxPassword;
        private Label label4;
        private Button button1;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
        private Button button2;
    }
}