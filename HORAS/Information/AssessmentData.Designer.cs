namespace HORAS.Information
{
    partial class AssessmentData
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
            metroLabel1 = new MetroFramework.Controls.MetroLabel();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroLabel3 = new MetroFramework.Controls.MetroLabel();
            metroLabel4 = new MetroFramework.Controls.MetroLabel();
            metroLabel5 = new MetroFramework.Controls.MetroLabel();
            DGV_Data = new DataGridView();
            metroLabel6 = new MetroFramework.Controls.MetroLabel();
            button1 = new Button();
            LabelFrom = new MetroFramework.Controls.MetroLabel();
            LabelTo = new MetroFramework.Controls.MetroLabel();
            LabelSubject = new MetroFramework.Controls.MetroLabel();
            LabelAbout = new MetroFramework.Controls.MetroLabel();
            LabelTotal = new MetroFramework.Controls.MetroLabel();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DGV_Data).BeginInit();
            SuspendLayout();
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.CustomBackground = false;
            metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel1.Location = new Point(255, 9);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new Size(89, 19);
            metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel1.StyleManager = null;
            metroLabel1.TabIndex = 0;
            metroLabel1.Text = "بيانات المقايسة";
            metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel1.UseStyleColors = false;
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.CustomBackground = false;
            metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel2.Location = new Point(522, 42);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.RightToLeft = RightToLeft.Yes;
            metroLabel2.Size = new Size(67, 19);
            metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel2.StyleManager = null;
            metroLabel2.TabIndex = 0;
            metroLabel2.Text = ": مرسل من";
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
            metroLabel3.Location = new Point(519, 72);
            metroLabel3.Name = "metroLabel3";
            metroLabel3.RightToLeft = RightToLeft.Yes;
            metroLabel3.Size = new Size(70, 19);
            metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel3.StyleManager = null;
            metroLabel3.TabIndex = 0;
            metroLabel3.Text = ": مرسل إلى";
            metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel3.UseStyleColors = false;
            // 
            // metroLabel4
            // 
            metroLabel4.AutoSize = true;
            metroLabel4.CustomBackground = false;
            metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel4.Location = new Point(525, 104);
            metroLabel4.Name = "metroLabel4";
            metroLabel4.RightToLeft = RightToLeft.Yes;
            metroLabel4.Size = new Size(64, 19);
            metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel4.StyleManager = null;
            metroLabel4.TabIndex = 0;
            metroLabel4.Text = ": الموضوع";
            metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel4.UseStyleColors = false;
            // 
            // metroLabel5
            // 
            metroLabel5.AutoSize = true;
            metroLabel5.CustomBackground = false;
            metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel5.Location = new Point(525, 135);
            metroLabel5.Name = "metroLabel5";
            metroLabel5.RightToLeft = RightToLeft.Yes;
            metroLabel5.Size = new Size(64, 19);
            metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel5.StyleManager = null;
            metroLabel5.TabIndex = 0;
            metroLabel5.Text = ": بخصوص";
            metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel5.UseStyleColors = false;
            // 
            // DGV_Data
            // 
            DGV_Data.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Data.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            DGV_Data.Location = new Point(12, 202);
            DGV_Data.Name = "DGV_Data";
            DGV_Data.RightToLeft = RightToLeft.Yes;
            DGV_Data.Size = new Size(577, 188);
            DGV_Data.TabIndex = 1;
            // 
            // metroLabel6
            // 
            metroLabel6.AutoSize = true;
            metroLabel6.CustomBackground = false;
            metroLabel6.FontSize = MetroFramework.MetroLabelSize.Medium;
            metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Light;
            metroLabel6.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            metroLabel6.Location = new Point(457, 167);
            metroLabel6.Name = "metroLabel6";
            metroLabel6.RightToLeft = RightToLeft.Yes;
            metroLabel6.Size = new Size(132, 19);
            metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            metroLabel6.StyleManager = null;
            metroLabel6.TabIndex = 0;
            metroLabel6.Text = ": إجمالى قيمة المقايسة";
            metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            metroLabel6.UseStyleColors = false;
            // 
            // button1
            // 
            button1.Location = new Point(262, 399);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "إغلاق";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LabelFrom
            // 
            LabelFrom.AutoSize = true;
            LabelFrom.CustomBackground = false;
            LabelFrom.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelFrom.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelFrom.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelFrom.Location = new Point(437, 42);
            LabelFrom.Name = "LabelFrom";
            LabelFrom.RightToLeft = RightToLeft.Yes;
            LabelFrom.Size = new Size(67, 19);
            LabelFrom.Style = MetroFramework.MetroColorStyle.Blue;
            LabelFrom.StyleManager = null;
            LabelFrom.TabIndex = 0;
            LabelFrom.Text = ": مرسل من";
            LabelFrom.Theme = MetroFramework.MetroThemeStyle.Light;
            LabelFrom.UseStyleColors = false;
            // 
            // LabelTo
            // 
            LabelTo.AutoSize = true;
            LabelTo.CustomBackground = false;
            LabelTo.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelTo.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelTo.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelTo.Location = new Point(434, 72);
            LabelTo.Name = "LabelTo";
            LabelTo.RightToLeft = RightToLeft.Yes;
            LabelTo.Size = new Size(70, 19);
            LabelTo.Style = MetroFramework.MetroColorStyle.Blue;
            LabelTo.StyleManager = null;
            LabelTo.TabIndex = 0;
            LabelTo.Text = ": مرسل إلى";
            LabelTo.Theme = MetroFramework.MetroThemeStyle.Light;
            LabelTo.UseStyleColors = false;
            // 
            // LabelSubject
            // 
            LabelSubject.AutoSize = true;
            LabelSubject.CustomBackground = false;
            LabelSubject.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelSubject.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelSubject.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelSubject.Location = new Point(440, 104);
            LabelSubject.Name = "LabelSubject";
            LabelSubject.RightToLeft = RightToLeft.Yes;
            LabelSubject.Size = new Size(64, 19);
            LabelSubject.Style = MetroFramework.MetroColorStyle.Blue;
            LabelSubject.StyleManager = null;
            LabelSubject.TabIndex = 0;
            LabelSubject.Text = ": الموضوع";
            LabelSubject.Theme = MetroFramework.MetroThemeStyle.Light;
            LabelSubject.UseStyleColors = false;
            // 
            // LabelAbout
            // 
            LabelAbout.AutoSize = true;
            LabelAbout.CustomBackground = false;
            LabelAbout.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelAbout.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelAbout.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelAbout.Location = new Point(440, 135);
            LabelAbout.Name = "LabelAbout";
            LabelAbout.RightToLeft = RightToLeft.Yes;
            LabelAbout.Size = new Size(64, 19);
            LabelAbout.Style = MetroFramework.MetroColorStyle.Blue;
            LabelAbout.StyleManager = null;
            LabelAbout.TabIndex = 0;
            LabelAbout.Text = ": بخصوص";
            LabelAbout.Theme = MetroFramework.MetroThemeStyle.Light;
            LabelAbout.UseStyleColors = false;
            // 
            // LabelTotal
            // 
            LabelTotal.AutoSize = true;
            LabelTotal.CustomBackground = false;
            LabelTotal.FontSize = MetroFramework.MetroLabelSize.Medium;
            LabelTotal.FontWeight = MetroFramework.MetroLabelWeight.Light;
            LabelTotal.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            LabelTotal.Location = new Point(319, 167);
            LabelTotal.Name = "LabelTotal";
            LabelTotal.RightToLeft = RightToLeft.Yes;
            LabelTotal.Size = new Size(132, 19);
            LabelTotal.Style = MetroFramework.MetroColorStyle.Blue;
            LabelTotal.StyleManager = null;
            LabelTotal.TabIndex = 0;
            LabelTotal.Text = ": إجمالى قيمة المقايسة";
            LabelTotal.Theme = MetroFramework.MetroThemeStyle.Light;
            LabelTotal.UseStyleColors = false;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "مسلسل";
            Column1.MaxInputLength = 1000;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 50;
            // 
            // Column2
            // 
            Column2.HeaderText = "وصف البند";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "الوحدة";
            Column3.Name = "Column3";
            Column3.Width = 50;
            // 
            // Column4
            // 
            Column4.HeaderText = "الكمية";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "الفئة";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "الإجمالى";
            Column6.Name = "Column6";
            // 
            // AssessmentData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 434);
            Controls.Add(button1);
            Controls.Add(DGV_Data);
            Controls.Add(LabelTotal);
            Controls.Add(metroLabel6);
            Controls.Add(LabelAbout);
            Controls.Add(metroLabel5);
            Controls.Add(LabelSubject);
            Controls.Add(metroLabel4);
            Controls.Add(LabelTo);
            Controls.Add(metroLabel3);
            Controls.Add(LabelFrom);
            Controls.Add(metroLabel2);
            Controls.Add(metroLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AssessmentData";
            Text = "AssessmentData";
            ((System.ComponentModel.ISupportInitialize)DGV_Data).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private DataGridView DGV_Data;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private Button button1;
        private MetroFramework.Controls.MetroLabel LabelFrom;
        private MetroFramework.Controls.MetroLabel LabelTo;
        private MetroFramework.Controls.MetroLabel LabelSubject;
        private MetroFramework.Controls.MetroLabel LabelAbout;
        private MetroFramework.Controls.MetroLabel LabelTotal;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
    }
}