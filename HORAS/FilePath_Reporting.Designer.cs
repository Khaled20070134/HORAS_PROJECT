namespace HORAS
{
    partial class FilePath_Reporting
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
            pictureBox1 = new PictureBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            textBoxFile = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.Files_32;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(409, 87);
            button3.Name = "button3";
            button3.Size = new Size(107, 23);
            button3.TabIndex = 7;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(522, 87);
            button2.Name = "button2";
            button2.Size = new Size(107, 23);
            button2.TabIndex = 8;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(521, 58);
            button1.Name = "button1";
            button1.Size = new Size(107, 23);
            button1.TabIndex = 9;
            button1.Text = "Select Path";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(56, 26);
            label2.Name = "label2";
            label2.Size = new Size(244, 20);
            label2.TabIndex = 5;
            label2.Text = "Set Path of Reporting Application";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 62);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 6;
            label1.Text = "File Directory";
            // 
            // textBoxFile
            // 
            textBoxFile.Enabled = false;
            textBoxFile.Location = new Point(165, 58);
            textBoxFile.Name = "textBoxFile";
            textBoxFile.Size = new Size(330, 23);
            textBoxFile.TabIndex = 4;
            // 
            // FilePath_Reporting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 133);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxFile);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FilePath_Reporting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FilePath_Reporting";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBoxFile;
    }
}