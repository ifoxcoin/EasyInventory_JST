namespace standard.report
{
    partial class frmNewTransactionRpt
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
            this.lblReference = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCityNames = new System.Windows.Forms.RichTextBox();
            this.lblCityName = new System.Windows.Forms.Label();
            this.cboCityName = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSend = new mylib.lightbutton();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.lblLedger = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.routeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblfdate = new System.Windows.Forms.Label();
            this.btnClear = new mylib.lightbutton();
            this.btnAddSearch = new mylib.lightbutton();
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usprouteSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspledgermasterSelectResultBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uspledgermasterCustomerSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspledgermasterCustomerCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspledgermasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspgetCutomerByRouteResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspcompanySelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tablelist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).BeginInit();
            this.a1Paneltitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usprouteSelectResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterCustomerSelectResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterCustomerCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspgetCutomerByRouteResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspcompanySelectResultBindingSource)).BeginInit();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1497, 503);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tablelist
            // 
            this.tablelist.ColumnCount = 11;
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablelist.Controls.Add(this.lblReference, 4, 2);
            this.tablelist.Controls.Add(this.lblCity, 3, 0);
            this.tablelist.Controls.Add(this.txtCityNames, 4, 1);
            this.tablelist.Controls.Add(this.lblCityName, 2, 1);
            this.tablelist.Controls.Add(this.cboCityName, 3, 1);
            this.tablelist.Controls.Add(this.btnSend, 9, 2);
            this.tablelist.Controls.Add(this.cboName, 10, 0);
            this.tablelist.Controls.Add(this.lblLedger, 9, 0);
            this.tablelist.Controls.Add(this.cboCity, 8, 0);
            this.tablelist.Controls.Add(this.dtpfdate, 2, 0);
            this.tablelist.Controls.Add(this.cboRoute, 5, 0);
            this.tablelist.Controls.Add(this.lblfdate, 1, 0);
            this.tablelist.Controls.Add(this.btnClear, 8, 2);
            this.tablelist.Controls.Add(this.btnAddSearch, 7, 2);
            this.tablelist.Controls.Add(this.cmdList, 7, 1);
            this.tablelist.Controls.Add(this.cmdexit, 8, 1);
            this.tablelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelist.Location = new System.Drawing.Point(5, 47);
            this.tablelist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tablelist.Name = "tablelist";
            this.tablelist.RowCount = 3;
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.Size = new System.Drawing.Size(1487, 130);
            this.tablelist.TabIndex = 4;
            // 
            // lblReference
            // 
            this.lblReference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblReference.Location = new System.Drawing.Point(525, 94);
            this.lblReference.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(131, 28);
            this.lblReference.TabIndex = 24;
            this.lblReference.Text = "Reference";
            this.lblReference.Visible = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.tablelist.SetColumnSpan(this.lblCity, 2);
            this.lblCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCity.Location = new System.Drawing.Point(375, 0);
            this.lblCity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(310, 43);
            this.lblCity.TabIndex = 24;
            this.lblCity.Text = "Search By Route";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCityNames
            // 
            this.tablelist.SetColumnSpan(this.txtCityNames, 2);
            this.txtCityNames.Location = new System.Drawing.Point(523, 46);
            this.txtCityNames.Name = "txtCityNames";
            this.txtCityNames.Size = new System.Drawing.Size(264, 37);
            this.txtCityNames.TabIndex = 36;
            this.txtCityNames.Text = "";
            this.txtCityNames.Visible = false;
            // 
            // lblCityName
            // 
            this.lblCityName.AutoSize = true;
            this.lblCityName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCityName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCityName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCityName.Location = new System.Drawing.Point(243, 43);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(124, 43);
            this.lblCityName.TabIndex = 41;
            this.lblCityName.Text = "Customer City ";
            this.lblCityName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCityName.Visible = false;
            // 
            // cboCityName
            // 
            this.cboCityName.DataSource = this.ledgermasterCityBindingSource;
            this.cboCityName.DisplayMember = "led_address2";
            this.cboCityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCityName.FormattingEnabled = true;
            this.cboCityName.Location = new System.Drawing.Point(373, 46);
            this.cboCityName.Name = "cboCityName";
            this.cboCityName.Size = new System.Drawing.Size(144, 30);
            this.cboCityName.TabIndex = 42;
            this.cboCityName.ValueMember = "led_id";
            this.cboCityName.Visible = false;
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSend.Location = new System.Drawing.Point(1226, 87);
            this.btnSend.Margin = new System.Windows.Forms.Padding(1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 36);
            this.btnSend.TabIndex = 43;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cboName
            // 
            this.cboName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(1360, 4);
            this.cboName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(114, 36);
            this.cboName.TabIndex = 25;
            this.cboName.Visible = false;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            this.cboName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboName_KeyDown);
            // 
            // lblLedger
            // 
            this.lblLedger.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLedger.AutoSize = true;
            this.lblLedger.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblLedger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblLedger.Location = new System.Drawing.Point(1230, 7);
            this.lblLedger.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLedger.Name = "lblLedger";
            this.lblLedger.Size = new System.Drawing.Size(91, 28);
            this.lblLedger.TabIndex = 24;
            this.lblLedger.Text = "Ledger";
            this.lblLedger.Visible = false;
            // 
            // cboCity
            // 
            this.cboCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.DataSource = this.ledgermasterCityBindingSource;
            this.cboCity.DisplayMember = "led_address2";
            this.cboCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(1100, 4);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(111, 36);
            this.cboCity.TabIndex = 25;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.Visible = false;
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged_1);
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // dtpfdate
            // 
            this.dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(225, 5);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(132, 35);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // cboRoute
            // 
            this.tablelist.SetColumnSpan(this.cboRoute, 2);
            this.cboRoute.DataSource = this.routeBindingSource;
            this.cboRoute.DisplayMember = "rt_name";
            this.cboRoute.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboRoute.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(693, 3);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(234, 36);
            this.cboRoute.TabIndex = 44;
            this.cboRoute.ValueMember = "rt_id";
            this.cboRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRoute_KeyDown);
            // 
            // routeBindingSource
            // 
            this.routeBindingSource.DataSource = typeof(standard.classes.route);
            // 
            // lblfdate
            // 
            this.lblfdate.AutoSize = true;
            this.lblfdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(148, 0);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(67, 43);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            this.lblfdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClear.Location = new System.Drawing.Point(1096, 87);
            this.btnClear.Margin = new System.Windows.Forms.Padding(1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 36);
            this.btnClear.TabIndex = 39;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddSearch
            // 
            this.btnAddSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.btnAddSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnAddSearch.Location = new System.Drawing.Point(966, 87);
            this.btnAddSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddSearch.Name = "btnAddSearch";
            this.btnAddSearch.Size = new System.Drawing.Size(98, 36);
            this.btnAddSearch.TabIndex = 40;
            this.btnAddSearch.Text = "+ Add Search";
            this.btnAddSearch.UseVisualStyleBackColor = false;
            this.btnAddSearch.Visible = false;
            this.btnAddSearch.Click += new System.EventHandler(this.btnAddSearch_Click);
            // 
            // cmdList
            // 
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(966, 44);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(98, 36);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            this.cmdList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmdList_KeyDown);
            // 
            // cmdexit
            // 
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(1096, 44);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(98, 36);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
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
            this.a1Paneltitle.Size = new System.Drawing.Size(1491, 37);
            this.a1Paneltitle.TabIndex = 2;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(10, 6);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(206, 29);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "LOAD WAY BILL";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrint.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 184);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1491, 316);
            this.reportViewer1.TabIndex = 3;
            // 
            // usprouteSelectResultBindingSource
            // 
            this.usprouteSelectResultBindingSource.DataSource = typeof(standard.classes.usp_routeSelectResult);
            // 
            // uspledgermasterSelectResultBindingSource1
            // 
            this.uspledgermasterSelectResultBindingSource1.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // uspledgermasterCustomerSelectResultBindingSource
            // 
            this.uspledgermasterCustomerSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // uspledgermasterCustomerCityBindingSource
            // 
            this.uspledgermasterCustomerCityBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // uspledgermasterSelectResultBindingSource
            // 
            this.uspledgermasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // uspgetCutomerByRouteResultBindingSource
            // 
            this.uspgetCutomerByRouteResultBindingSource.DataSource = typeof(standard.classes.usp_getCutomerByRouteResult);
            // 
            // uspcompanySelectResultBindingSource
            // 
            this.uspcompanySelectResultBindingSource.DataSource = typeof(standard.classes.usp_companySelectResult);
            // 
            // frmNewTransactionRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1497, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "frmNewTransactionRpt";
            this.ShowIcon = false;
            this.Text = " PRINT";
            this.Load += new System.EventHandler(this.frmAddressPrint_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tablelist.ResumeLayout(false);
            this.tablelist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).EndInit();
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usprouteSelectResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterCustomerSelectResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterCustomerCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspgetCutomerByRouteResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspcompanySelectResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private mylib.a1panel a1Paneltitle;
        private System.Windows.Forms.Label lbltitle;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uspledgermasterSelectResultBindingSource;
        private System.Windows.Forms.BindingSource ledgermasterCityBindingSource;
        private System.Windows.Forms.BindingSource ledgermasterBindingSource;
        private System.Windows.Forms.TableLayoutPanel tablelist;
        private mylib.lightbutton cmdList;
        private mylib.lightbutton cmdexit;
        private System.Windows.Forms.DateTimePicker dtpfdate;
        private System.Windows.Forms.Label lblfdate;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label lblLedger;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.BindingSource uspledgermasterSelectResultBindingSource1;
        private System.Windows.Forms.BindingSource uspledgermasterCustomerCityBindingSource;
        private System.Windows.Forms.BindingSource uspledgermasterCustomerSelectResultBindingSource;
        private System.Windows.Forms.RichTextBox txtCityNames;
        private mylib.lightbutton btnClear;
        private mylib.lightbutton btnAddSearch;
        private System.Windows.Forms.Label lblCityName;
        private System.Windows.Forms.ComboBox cboCityName;
        private mylib.lightbutton btnSend;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.BindingSource usprouteSelectResultBindingSource;
        private System.Windows.Forms.BindingSource uspgetCutomerByRouteResultBindingSource;
        private System.Windows.Forms.BindingSource uspcompanySelectResultBindingSource;
        private System.Windows.Forms.BindingSource routeBindingSource;
    }
}