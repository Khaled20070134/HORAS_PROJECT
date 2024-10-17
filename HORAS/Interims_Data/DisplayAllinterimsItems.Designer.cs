namespace HORAS.Interims_Data
{
    partial class DisplayAllinterimsItems
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
            dataGridViewDisplayItems = new DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDisplayItems).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDisplayItems
            // 
            dataGridViewDisplayItems.AllowUserToAddRows = false;
            dataGridViewDisplayItems.AllowUserToDeleteRows = false;
            dataGridViewDisplayItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDisplayItems.Columns.AddRange(new DataGridViewColumn[] { Description, Number });
            dataGridViewDisplayItems.Location = new Point(52, 59);
            dataGridViewDisplayItems.MultiSelect = false;
            dataGridViewDisplayItems.Name = "dataGridViewDisplayItems";
            dataGridViewDisplayItems.ReadOnly = true;
            dataGridViewDisplayItems.RightToLeft = RightToLeft.Yes;
            dataGridViewDisplayItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDisplayItems.Size = new Size(697, 307);
            dataGridViewDisplayItems.TabIndex = 78;
            dataGridViewDisplayItems.CellContentDoubleClick += dataGridViewDisplayItems_CellContentDoubleClick;
            // 
            // Description
            // 
            Description.HeaderText = "رقم البند";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 500;
            // 
            // Number
            // 
            Number.HeaderText = "وصف البند";
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Width = 150;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe Script", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Image = Properties.Resources.Close_16;
            button1.Location = new Point(329, 398);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.No;
            button1.Size = new Size(110, 25);
            button1.TabIndex = 80;
            button1.Text = "الغاء";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(381, 28);
            label8.Name = "label8";
            label8.Size = new Size(58, 28);
            label8.TabIndex = 79;
            label8.Text = "البنود";
            // 
            // DisplayAllinterimsItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewDisplayItems);
            Controls.Add(button1);
            Controls.Add(label8);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DisplayAllinterimsItems";
            Text = "DisplayAllinterimsItems";
            Load += DisplayAllinterimsItems_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDisplayItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewDisplayItems;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Number;
        private Button button1;
        private Label label8;
    }
}