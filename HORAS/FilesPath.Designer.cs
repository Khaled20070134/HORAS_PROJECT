namespace HORAS
{
    partial class FilesPath
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
            textBoxFile = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBoxFile
            // 
            textBoxFile.Enabled = false;
            textBoxFile.Location = new Point(169, 54);
            textBoxFile.Name = "textBoxFile";
            textBoxFile.Size = new Size(330, 23);
            textBoxFile.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 58);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "File Directory";
            // 
            // button1
            // 
            button1.Location = new Point(525, 54);
            button1.Name = "button1";
            button1.Size = new Size(107, 23);
            button1.TabIndex = 2;
            button1.Text = "Select Path";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(526, 83);
            button2.Name = "button2";
            button2.Size = new Size(107, 23);
            button2.TabIndex = 2;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(53, 22);
            label2.Name = "label2";
            label2.Size = new Size(350, 20);
            label2.TabIndex = 1;
            label2.Text = "Set Or Change Server Path to Save Database files";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.Files_32;
            pictureBox1.Location = new Point(9, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(413, 83);
            button3.Name = "button3";
            button3.Size = new Size(107, 23);
            button3.TabIndex = 2;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FilesPath
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 125);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxFile);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FilesPath";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FilesPath";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFile;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button3;
    }
}