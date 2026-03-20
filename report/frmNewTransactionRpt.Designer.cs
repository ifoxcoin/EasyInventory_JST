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
            this.chkTotal = new System.Windows.Forms.CheckBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.btnSend = new mylib.lightbutton();
            this.btnClear = new mylib.lightbutton();
            this.btnAddSearch = new mylib.lightbutton();
            this.lblfdate = new System.Windows.Forms.Label();
            this.chkIsSummary = new System.Windows.Forms.CheckBox();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.lblLedger = new System.Windows.Forms.Label();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboCityName = new System.Windows.Forms.ComboBox();
            this.lblCityName = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.routeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtCityNames = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.chkLorryBill = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 503);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tablelist
            // 
            this.tablelist.ColumnCount = 11;
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.7551F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.57143F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.Controls.Add(this.chkTotal, 6, 0);
            this.tablelist.Controls.Add(this.lblReference, 4, 2);
            this.tablelist.Controls.Add(this.btnSend, 9, 2);
            this.tablelist.Controls.Add(this.btnClear, 8, 2);
            this.tablelist.Controls.Add(this.btnAddSearch, 7, 2);
            this.tablelist.Controls.Add(this.lblfdate, 0, 0);
            this.tablelist.Controls.Add(this.chkIsSummary, 0, 1);
            this.tablelist.Controls.Add(this.dtpfdate, 1, 0);
            this.tablelist.Controls.Add(this.lblLedger, 9, 0);
            this.tablelist.Controls.Add(this.cboName, 10, 0);
            this.tablelist.Controls.Add(this.cboCity, 10, 2);
            this.tablelist.Controls.Add(this.cboCityName, 3, 2);
            this.tablelist.Controls.Add(this.lblCityName, 2, 2);
            this.tablelist.Controls.Add(this.lblCity, 0, 2);
            this.tablelist.Controls.Add(this.cboRoute, 1, 2);
            this.tablelist.Controls.Add(this.label1, 2, 0);
            this.tablelist.Controls.Add(this.cboVehicleNo, 4, 0);
            this.tablelist.Controls.Add(this.txtCityNames, 5, 2);
            this.tablelist.Controls.Add(this.tableLayoutPanel2, 4, 1);
            this.tablelist.Controls.Add(this.chkLorryBill, 1, 1);
            this.tablelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelist.Location = new System.Drawing.Point(5, 47);
            this.tablelist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tablelist.Name = "tablelist";
            this.tablelist.RowCount = 3;
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablelist.Size = new System.Drawing.Size(1274, 130);
            this.tablelist.TabIndex = 4;
            // 
            // chkTotal
            // 
            this.chkTotal.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTotal.BackColor = System.Drawing.Color.Red;
            this.chkTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkTotal.Location = new System.Drawing.Point(746, 3);
            this.chkTotal.Name = "chkTotal";
            this.chkTotal.Size = new System.Drawing.Size(148, 37);
            this.chkTotal.TabIndex = 50;
            this.chkTotal.Text = "Total Items";
            this.chkTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTotal.UseVisualStyleBackColor = false;
            this.chkTotal.CheckedChanged += new System.EventHandler(this.chkTotal_CheckedChanged);
            // 
            // lblReference
            // 
            this.lblReference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblReference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblReference.Location = new System.Drawing.Point(524, 96);
            this.lblReference.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(105, 23);
            this.lblReference.TabIndex = 24;
            this.lblReference.Text = "Reference";
            this.lblReference.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSend.Location = new System.Drawing.Point(1145, 87);
            this.btnSend.Margin = new System.Windows.Forms.Padding(1);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 36);
            this.btnSend.TabIndex = 43;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClear.Location = new System.Drawing.Point(1127, 87);
            this.btnClear.Margin = new System.Windows.Forms.Padding(1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(16, 36);
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
            this.btnAddSearch.Location = new System.Drawing.Point(916, 87);
            this.btnAddSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnAddSearch.Name = "btnAddSearch";
            this.btnAddSearch.Size = new System.Drawing.Size(98, 36);
            this.btnAddSearch.TabIndex = 40;
            this.btnAddSearch.Text = "+ Add Search";
            this.btnAddSearch.UseVisualStyleBackColor = false;
            this.btnAddSearch.Visible = false;
            this.btnAddSearch.Click += new System.EventHandler(this.btnAddSearch_Click);
            // 
            // lblfdate
            // 
            this.lblfdate.AutoSize = true;
            this.lblfdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(5, 0);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(144, 43);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            this.lblfdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkIsSummary
            // 
            this.chkIsSummary.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsSummary.BackColor = System.Drawing.Color.Red;
            this.chkIsSummary.Checked = true;
            this.chkIsSummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsSummary.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkIsSummary.Location = new System.Drawing.Point(3, 46);
            this.chkIsSummary.Name = "chkIsSummary";
            this.chkIsSummary.Size = new System.Drawing.Size(148, 37);
            this.chkIsSummary.TabIndex = 45;
            this.chkIsSummary.Text = "LOADWAY";
            this.chkIsSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsSummary.UseVisualStyleBackColor = false;
            this.chkIsSummary.CheckedChanged += new System.EventHandler(this.chkIsSummary_CheckedChanged);
            // 
            // dtpfdate
            // 
            this.dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(159, 6);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(132, 30);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // lblLedger
            // 
            this.lblLedger.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLedger.AutoSize = true;
            this.lblLedger.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblLedger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblLedger.Location = new System.Drawing.Point(1149, 0);
            this.lblLedger.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLedger.Name = "lblLedger";
            this.lblLedger.Size = new System.Drawing.Size(67, 43);
            this.lblLedger.TabIndex = 24;
            this.lblLedger.Text = "Ledger";
            this.lblLedger.Visible = false;
            // 
            // cboName
            // 
            this.cboName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(1228, 6);
            this.cboName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(41, 31);
            this.cboName.TabIndex = 25;
            this.cboName.Visible = false;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            this.cboName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboName_KeyDown);
            // 
            // cboCity
            // 
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.DataSource = this.ledgermasterCityBindingSource;
            this.cboCity.DisplayMember = "led_address2";
            this.cboCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(1228, 90);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(41, 31);
            this.cboCity.TabIndex = 25;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.Visible = false;
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged_1);
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // cboCityName
            // 
            this.cboCityName.DataSource = this.ledgermasterCityBindingSource;
            this.cboCityName.DisplayMember = "led_address2";
            this.cboCityName.FormattingEnabled = true;
            this.cboCityName.Location = new System.Drawing.Point(373, 89);
            this.cboCityName.Name = "cboCityName";
            this.cboCityName.Size = new System.Drawing.Size(143, 26);
            this.cboCityName.TabIndex = 42;
            this.cboCityName.ValueMember = "led_id";
            this.cboCityName.Visible = false;
            // 
            // lblCityName
            // 
            this.lblCityName.AutoSize = true;
            this.lblCityName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCityName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCityName.Location = new System.Drawing.Point(304, 86);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(59, 44);
            this.lblCityName.TabIndex = 41;
            this.lblCityName.Text = "Customer City ";
            this.lblCityName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCityName.Visible = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCity.Location = new System.Drawing.Point(5, 86);
            this.lblCity.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(104, 44);
            this.lblCity.TabIndex = 24;
            this.lblCity.Text = "Search By Route";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCity.Visible = false;
            // 
            // cboRoute
            // 
            this.cboRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRoute.DataSource = this.routeBindingSource;
            this.cboRoute.DisplayMember = "rt_name";
            this.cboRoute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboRoute.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(157, 89);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(141, 31);
            this.cboRoute.TabIndex = 44;
            this.cboRoute.ValueMember = "rt_id";
            this.cboRoute.Visible = false;
            this.cboRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboRoute_KeyDown);
            // 
            // routeBindingSource
            // 
            this.routeBindingSource.DataSource = typeof(standard.classes.route);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tablelist.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(306, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 43);
            this.label1.TabIndex = 46;
            this.label1.Text = "Vehicle No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tablelist.SetColumnSpan(this.cboVehicleNo, 2);
            this.cboVehicleNo.DataSource = this.vehicleBindingSource;
            this.cboVehicleNo.DisplayMember = "vh_number";
            this.cboVehicleNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboVehicleNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboVehicleNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(524, 4);
            this.cboVehicleNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(214, 31);
            this.cboVehicleNo.TabIndex = 48;
            this.cboVehicleNo.ValueMember = "vh_id";
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataSource = typeof(standard.classes.vehicle);
            // 
            // txtCityNames
            // 
            this.txtCityNames.Location = new System.Drawing.Point(693, 89);
            this.txtCityNames.Name = "txtCityNames";
            this.txtCityNames.Size = new System.Drawing.Size(47, 37);
            this.txtCityNames.TabIndex = 36;
            this.txtCityNames.Text = "";
            this.txtCityNames.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tablelist.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cmdList, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdexit, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(522, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(218, 37);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // cmdList
            // 
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(1, 1);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(98, 35);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // cmdexit
            // 
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(119, 1);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(98, 35);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // chkLorryBill
            // 
            this.chkLorryBill.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLorryBill.BackColor = System.Drawing.Color.Red;
            this.chkLorryBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLorryBill.Checked = true;
            this.chkLorryBill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tablelist.SetColumnSpan(this.chkLorryBill, 3);
            this.chkLorryBill.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkLorryBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLorryBill.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.chkLorryBill.Location = new System.Drawing.Point(157, 46);
            this.chkLorryBill.Name = "chkLorryBill";
            this.chkLorryBill.Size = new System.Drawing.Size(212, 37);
            this.chkLorryBill.TabIndex = 49;
            this.chkLorryBill.Text = "WithOut Rate";
            this.chkLorryBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLorryBill.UseVisualStyleBackColor = false;
            this.chkLorryBill.CheckedChanged += new System.EventHandler(this.chkLorryBill_CheckedChanged);
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
            this.a1Paneltitle.Size = new System.Drawing.Size(1278, 37);
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
            this.lbltitle.Size = new System.Drawing.Size(171, 24);
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
            this.reportViewer1.Size = new System.Drawing.Size(1278, 316);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1284, 503);
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
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox chkIsSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVehicleNo;
        private System.Windows.Forms.BindingSource vehicleBindingSource;
        private System.Windows.Forms.CheckBox chkLorryBill;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private mylib.lightbutton cmdList;
        private mylib.lightbutton cmdexit;
        private System.Windows.Forms.CheckBox chkTotal;
    }
}