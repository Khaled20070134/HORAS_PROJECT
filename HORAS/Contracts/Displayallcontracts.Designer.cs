namespace HORAS.Contracts
{
    partial class Displayallcontracts
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
            dataGridViewDisplayContracts = new DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            label8 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDisplayContracts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDisplayContracts
            // 
            dataGridViewDisplayContracts.AllowUserToAddRows = false;
            dataGridViewDisplayContracts.AllowUserToDeleteRows = false;
            dataGridViewDisplayContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDisplayContracts.Columns.AddRange(new DataGridViewColumn[] { Description, Number });
            dataGridViewDisplayContracts.Location = new Point(52, 69);
            dataGridViewDisplayContracts.MultiSelect = false;
            dataGridViewDisplayContracts.Name = "dataGridViewDisplayContracts";
            dataGridViewDisplayContracts.ReadOnly = true;
            dataGridViewDisplayContracts.RightToLeft = RightToLeft.Yes;
            dataGridViewDisplayContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDisplayContracts.Size = new Size(697, 307);
            dataGridViewDisplayContracts.TabIndex = 0;
            dataGridViewDisplayContracts.CellContentClick += dataGridViewDisplayContracts_CellContentClick;
            dataGridViewDisplayContracts.CellMouseDoubleClick += dataGridViewDisplayContracts_CellMouseDoubleClick;
            // 
            // Description
            // 
            Description.HeaderText = "وصف التعاقد";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 500;
            // 
            // Number
            // 
            Number.HeaderText = "رقم التعاقد";
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Width = 150;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(247, 21);
            label8.Name = "label8";
            label8.Size = new Size(301, 28);
            label8.TabIndex = 75;
            label8.Text = "بيانات التعاقدات المسجله والموقعه";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Image = Properties.Resources.Close_16;
            button1.Location = new Point(352, 393);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.No;
            button1.Size = new Size(110, 25);
            button1.TabIndex = 76;
            button1.Text = "الغاء";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Displayallcontracts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gr;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(dataGridViewDisplayContracts);
            ForeColor = Color.Snow;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Displayallcontracts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Displayallcontracts";
            Load += Displayallcontracts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDisplayContracts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewDisplayContracts;
        private Label label8;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Number;
        private Button button1;
    }
}