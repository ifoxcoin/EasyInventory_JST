namespace standard.report
{
    partial class frmAddressPrint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddressPrint));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkIsCoverPrint = new System.Windows.Forms.CheckBox();
            this.chkIsWithGst = new System.Windows.Forms.CheckBox();
            this.uspledgermasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.a1Paneltitle.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.a1Paneltitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1185, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // a1Paneltitle
            // 
            this.a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
            this.a1Paneltitle.Controls.Add(this.lbltitle);
            this.a1Paneltitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
            this.a1Paneltitle.Image = null;
            this.a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Paneltitle.Location = new System.Drawing.Point(3, 3);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1179, 37);
            this.a1Paneltitle.TabIndex = 2;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(29, 9);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(77, 18);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "REPORT";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnView, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPrint, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboCity, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1179, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "City";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnView.BackgroundImage")));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(819, 5);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(110, 37);
            this.btnView.TabIndex = 20;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cboName
            // 
            this.cboName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboName.DataSource = this.ledgermasterBindingSource;
            this.cboName.DisplayMember = "led_name";
            this.cboName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(586, 11);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(226, 26);
            this.cboName.TabIndex = 13;
            this.cboName.ValueMember = "led_id";
            this.cboName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboName_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(411, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Party Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(936, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(1053, 5);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 37);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboCity
            // 
            this.cboCity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.DataSource = this.ledgermasterCityBindingSource;
            this.cboCity.DisplayMember = "led_address2";
            this.cboCity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(178, 11);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(226, 26);
            this.cboCity.TabIndex = 13;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrint.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 154);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1179, 319);
            this.reportViewer1.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.chkIsCoverPrint, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkIsWithGst, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 100);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1179, 48);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // chkIsCoverPrint
            // 
            this.chkIsCoverPrint.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsCoverPrint.BackColor = System.Drawing.Color.Green;
            this.chkIsCoverPrint.Checked = true;
            this.chkIsCoverPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsCoverPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsCoverPrint.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkIsCoverPrint.Location = new System.Drawing.Point(3, 3);
            this.chkIsCoverPrint.Name = "chkIsCoverPrint";
            this.chkIsCoverPrint.Size = new System.Drawing.Size(149, 32);
            this.chkIsCoverPrint.TabIndex = 29;
            this.chkIsCoverPrint.Text = "Cover Print";
            this.chkIsCoverPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsCoverPrint.UseVisualStyleBackColor = false;
            this.chkIsCoverPrint.Visible = false;
            this.chkIsCoverPrint.CheckedChanged += new System.EventHandler(this.chkIsCoverPrint_CheckedChanged);
            // 
            // chkIsWithGst
            // 
            this.chkIsWithGst.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsWithGst.BackColor = System.Drawing.Color.Green;
            this.chkIsWithGst.Checked = true;
            this.chkIsWithGst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsWithGst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsWithGst.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkIsWithGst.Location = new System.Drawing.Point(178, 3);
            this.chkIsWithGst.Name = "chkIsWithGst";
            this.chkIsWithGst.Size = new System.Drawing.Size(149, 32);
            this.chkIsWithGst.TabIndex = 29;
            this.chkIsWithGst.Text = "With GST";
            this.chkIsWithGst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsWithGst.UseVisualStyleBackColor = false;
            this.chkIsWithGst.Visible = false;
            this.chkIsWithGst.CheckedChanged += new System.EventHandler(this.chkIsWithGst_CheckedChanged);
            // 
            // uspledgermasterSelectResultBindingSource
            // 
            this.uspledgermasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // frmAddressPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1185, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "frmAddressPrint";
            this.ShowIcon = false;
            this.Text = "ADDRESS PRINT";
            this.Load += new System.EventHandler(this.frmAddressPrint_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private mylib.a1panel a1Paneltitle;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboName;
        internal System.Windows.Forms.Button btnPrint;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource uspledgermasterSelectResultBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource ledgermasterCityBindingSource;
        private System.Windows.Forms.BindingSource ledgermasterBindingSource;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkIsWithGst;
        private System.Windows.Forms.CheckBox chkIsCoverPrint;
    }
}