namespace HORAS.SuppliersAndClients
{
    partial class ViewParty
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
            ViewPartyDGV = new DataGridView();
            PartyHeadLBL = new Label();
            ((System.ComponentModel.ISupportInitialize)ViewPartyDGV).BeginInit();
            SuspendLayout();
            // 
            // ViewPartyDGV
            // 
            ViewPartyDGV.AllowUserToAddRows = false;
            ViewPartyDGV.BackgroundColor = SystemColors.ActiveBorder;
            ViewPartyDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ViewPartyDGV.Location = new Point(27, 90);
            ViewPartyDGV.Name = "ViewPartyDGV";
            ViewPartyDGV.Size = new Size(570, 269);
            ViewPartyDGV.TabIndex = 0;
            ViewPartyDGV.CellContentClick += ViewPartyDGV_CellContentClick;
            // 
            // PartyHeadLBL
            // 
            PartyHeadLBL.AutoSize = true;
            PartyHeadLBL.BackColor = Color.Transparent;
            PartyHeadLBL.Font = new Font("Segoe UI", 15F);
            PartyHeadLBL.ForeColor = Color.White;
            PartyHeadLBL.Location = new Point(178, 30);
            PartyHeadLBL.Name = "PartyHeadLBL";
            PartyHeadLBL.Size = new Size(262, 28);
            PartyHeadLBL.TabIndex = 2;
            PartyHeadLBL.Text = "عرض بيانات العملاء و الموردين";
            // 
            // ViewParty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(617, 411);
            Controls.Add(PartyHeadLBL);
            Controls.Add(ViewPartyDGV);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewParty";
            Text = "ViewParty";
            Load += ViewParty_Load;
            ((System.ComponentModel.ISupportInitialize)ViewPartyDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ViewPartyDGV;
        private Label PartyHeadLBL;
    }
}