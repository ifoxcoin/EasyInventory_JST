namespace standard.report
{
    partial class frmStockRpt
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tablelist = new System.Windows.Forms.TableLayoutPanel();
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblcat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboItemName = new System.Windows.Forms.ComboBox();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkIsWithRate = new System.Windows.Forms.CheckBox();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tableLayoutPanel1.SuspendLayout();
            this.tablelist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.a1Paneltitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tablelist, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.a1Paneltitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.reportViewer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tablelist
            // 
            this.tablelist.ColumnCount = 8;
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tablelist.Controls.Add(this.cmdList, 6, 0);
            this.tablelist.Controls.Add(this.cmdexit, 7, 0);
            this.tablelist.Controls.Add(this.cboCategory, 1, 0);
            this.tablelist.Controls.Add(this.lblcat, 0, 0);
            this.tablelist.Controls.Add(this.label3, 2, 0);
            this.tablelist.Controls.Add(this.cboItemName, 3, 0);
            this.tablelist.Controls.Add(this.chkIsWithRate, 4, 0);
            this.tablelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelist.Location = new System.Drawing.Point(5, 47);
            this.tablelist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tablelist.Name = "tablelist";
            this.tablelist.RowCount = 1;
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelist.Size = new System.Drawing.Size(1221, 40);
            this.tablelist.TabIndex = 4;
            // 
            // cmdList
            // 
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(988, 1);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(114, 36);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // cmdexit
            // 
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(1105, 1);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(114, 36);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategory.DataSource = this.categoryBindingSource;
            this.cboCategory.DisplayMember = "cat_name";
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(122, 4);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(223, 26);
            this.cboCategory.TabIndex = 25;
            this.cboCategory.ValueMember = "cat_id";
            this.cboCategory.SelectedValueChanged += new System.EventHandler(this.cboCategory_SelectedValueChanged);
            this.cboCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCategory_KeyDown);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(standard.classes.category);
            // 
            // lblcat
            // 
            this.lblcat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblcat.AutoSize = true;
            this.lblcat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblcat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblcat.Location = new System.Drawing.Point(5, 11);
            this.lblcat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblcat.Name = "lblcat";
            this.lblcat.Size = new System.Drawing.Size(76, 18);
            this.lblcat.TabIndex = 24;
            this.lblcat.Text = "Category";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(355, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Item Name";
            // 
            // cboItemName
            // 
            this.cboItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemName.DataSource = this.itemBindingSource;
            this.cboItemName.DisplayMember = "item_name";
            this.cboItemName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboItemName.FormattingEnabled = true;
            this.cboItemName.Location = new System.Drawing.Point(472, 4);
            this.cboItemName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboItemName.Name = "cboItemName";
            this.cboItemName.Size = new System.Drawing.Size(223, 26);
            this.cboItemName.TabIndex = 26;
            this.cboItemName.ValueMember = "item_id";
            this.cboItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboItemName_KeyDown);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(standard.classes.item);
            // 
            // chkIsWithRate
            // 
            this.chkIsWithRate.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsWithRate.BackColor = System.Drawing.Color.Green;
            this.chkIsWithRate.Checked = true;
            this.chkIsWithRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tablelist.SetColumnSpan(this.chkIsWithRate, 2);
            this.chkIsWithRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsWithRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkIsWithRate.Location = new System.Drawing.Point(716, 3);
            this.chkIsWithRate.Name = "chkIsWithRate";
            this.chkIsWithRate.Size = new System.Drawing.Size(149, 32);
            this.chkIsWithRate.TabIndex = 28;
            this.chkIsWithRate.Text = "With Rate";
            this.chkIsWithRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsWithRate.UseVisualStyleBackColor = false;
            this.chkIsWithRate.Visible = false;
            this.chkIsWithRate.CheckedChanged += new System.EventHandler(this.chkIsWithRate_CheckedChanged);
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
            this.a1Paneltitle.Size = new System.Drawing.Size(1225, 37);
            this.a1Paneltitle.TabIndex = 2;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(6, 6);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(137, 19);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "STOCK REPORT";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrint.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 94);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1225, 379);
            this.reportViewer1.TabIndex = 3;
            // 
            // frmStockRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1231, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "frmStockRpt";
            this.ShowIcon = false;
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.frmAddressPrint_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tablelist.ResumeLayout(false);
            this.tablelist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private mylib.a1panel a1Paneltitle;
        private System.Windows.Forms.Label lbltitle;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TableLayoutPanel tablelist;
        private mylib.lightbutton cmdList;
        private mylib.lightbutton cmdexit;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblcat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboItemName;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.CheckBox chkIsWithRate;
    }
}