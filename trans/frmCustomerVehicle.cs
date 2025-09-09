using standard.classes;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace standard.trans
{
    public class frmCustomerVehicle : Form
    {
        private int _soid = 0;
        private IContainer components = null;

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private DateTimePicker dtpfdate;
        private BindingSource vehicleBindingSource;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel3;
        private mylib.lightbutton cmdUpdate;
        private mylib.lightbutton lightbutton1;
        private DataGridViewTextBoxColumn soidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sodateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vhidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaddress2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vhnumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leddeliveryorderDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn update_vh_number;
        private DataGridViewTextBoxColumn update_led_deliveryorder;
        private BindingSource uspGetCustomerVehicleDetailinSalesorderResultBindingSource;

        public int soid
        {
            get
            {
                return _soid;
            }
            set
            {
                _soid = value;
            }
        }

        public frmCustomerVehicle()
        {
            InitializeComponent();
        }

        private void frmItemlist_Load(object sender, EventArgs e)
        {
            if (_soid > 0)
            {
                LoadData(DateTime.Today);
            }
        }

        private void frmCustomerVehicle_Load(object sender, EventArgs e)
        {
            dtpfdate.Value = DateTime.Today;
            LoadData(DateTime.Today);
        }

        private void LoadData(DateTime date)
        {
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();

                uspGetCustomerVehicleDetailinSalesorderResultBindingSource.DataSource = inventoryDataContext.usp_GetCustomerVehicleDetailinSalesorder(date);
                vehicleBindingSource.DataSource = inventoryDataContext.vehicles.Select((vehicle vh) => vh).ToList();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    row.Cells["update_vh_number"].Value = (long?)0;
                    row.Cells["update_led_deliveryorder"].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Timer dateChangeTimer;

        private void dtpfdate_ValueChanged(object sender, EventArgs e)
        {
            if (dateChangeTimer != null)
                dateChangeTimer.Stop();

            dateChangeTimer = new Timer();
            dateChangeTimer.Interval = 300; // 300 ms delay
            dateChangeTimer.Tick += (s, args) =>
            {
                dateChangeTimer.Stop();
                LoadData(dtpfdate.Value.Date);
            };
            dateChangeTimer.Start();
        }

        private void dtpfdate_CloseUp(object sender, EventArgs e)
        {
            if (dtpfdate.Value == DateTime.MinValue) return;

            LoadData(dtpfdate.Value.Date);
        }

        private void dtpfdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (dtpfdate.Value == DateTime.MinValue) return;

            LoadData(dtpfdate.Value.Date);
            if (dataGridView1.Rows.Count > 0 && !dataGridView1.Rows[0].IsNewRow)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["update_vh_number"];
                dataGridView1.BeginEdit(true);
            }

            e.Handled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var hasRowsToUpdate = dataGridView1.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow);
                if (!hasRowsToUpdate)
                {
                    MessageBox.Show("No rows to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Confirm once
                if (MessageBox.Show("Are you sure to Update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                using (var inventoryDataContext = new InventoryDataContext())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int id = Convert.ToInt32(row.Cells["ledidDataGridViewTextBoxColumn"].Value);

                        int newVehicleId = row.Cells["update_vh_number"].Value != null
                            ? Convert.ToInt32(row.Cells["update_vh_number"].Value)
                            : 0;

                        string newDeliveryOrder = row.Cells["update_led_deliveryorder"].Value?.ToString() ?? "";

                        var ledgermaster = inventoryDataContext.ledgermasters.SingleOrDefault(l => l.led_id == id);
                        if (ledgermaster == null) continue;

                        int oldVehicleId = (int)ledgermaster.vh_id;
                        if (newVehicleId != 0)
                        {
                            ledgermaster.vh_id = newVehicleId;
                        }

                        string oldDeliveryOrder = ledgermaster.led_deliveryorder;
                        if (!string.IsNullOrWhiteSpace(newDeliveryOrder))
                        {
                            ledgermaster.led_deliveryorder = newDeliveryOrder;
                        }

                        inventoryDataContext.usp_ledgermasterUpdate(
                            id,
                            ledgermaster.led_agid,
                            ledgermaster.led_accountcode,
                            ledgermaster.led_accounttype,
                            ledgermaster.led_name,
                            ledgermaster.led_stlname,
                            ledgermaster.led_address,
                            ledgermaster.led_address1,
                            ledgermaster.led_shippingaddress1,
                            ledgermaster.led_shippingaddress2,
                            ledgermaster.led_address2,
                            ledgermaster.led_state,
                            ledgermaster.led_tname,
                            ledgermaster.led_taddress,
                            ledgermaster.led_taddress1,
                            ledgermaster.led_taddress2,
                            ledgermaster.led_pincode,
                            ledgermaster.led_transport,
                            ledgermaster.led_ownerphone,
                            ledgermaster.led_ownername,
                            ledgermaster.led_managername,
                            ledgermaster.led_managerphone,
                            ledgermaster.led_deliveryorder,
                            ledgermaster.led_vehicleno,
                            ledgermaster.led_tin,
                            ledgermaster.led_isfreight,
                            ledgermaster.led_check,
                            ledgermaster.led_cst,
                            ledgermaster.led_refno,
                            global.ucode,
                            global.comid,
                            ledgermaster.rt_id,
                            ledgermaster.vh_id,
                            global.sysdate,
                            ledgermaster.led_ratetype,
                            ledgermaster.led_disper
                        );

                        // Reset row values after update
                        row.Cells["update_vh_number"].Value = (long?)0;
                        row.Cells["update_led_deliveryorder"].Value = "";
                    }

                    MessageBox.Show("Update successful.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Refresh data
                LoadData(dtpfdate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.soidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vhidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vhnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leddeliveryorderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_vh_number = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.update_led_deliveryorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspGetCustomerVehicleDetailinSalesorderResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmdUpdate = new mylib.lightbutton();
            this.lightbutton1 = new mylib.lightbutton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetCustomerVehicleDetailinSalesorderResultBindingSource)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1211, 824);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dtpfdate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1205, 44);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtpfdate
            // 
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(143, 5);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(5);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(143, 26);
            this.dtpfdate.TabIndex = 1;
            this.dtpfdate.CloseUp += new System.EventHandler(this.dtpfdate_CloseUp);
            this.dtpfdate.ValueChanged += new System.EventHandler(this.dtpfdate_ValueChanged);
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.soidDataGridViewTextBoxColumn,
            this.sodateDataGridViewTextBoxColumn,
            this.vhidDataGridViewTextBoxColumn,
            this.ledidDataGridViewTextBoxColumn,
            this.ledaddress2DataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.vhnumberDataGridViewTextBoxColumn,
            this.leddeliveryorderDataGridViewTextBoxColumn,
            this.update_vh_number,
            this.update_led_deliveryorder});
            this.dataGridView1.DataSource = this.uspGetCustomerVehicleDetailinSalesorderResultBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1205, 710);
            this.dataGridView1.TabIndex = 1;
            // 
            // soidDataGridViewTextBoxColumn
            // 
            this.soidDataGridViewTextBoxColumn.DataPropertyName = "so_id";
            this.soidDataGridViewTextBoxColumn.HeaderText = "so_id";
            this.soidDataGridViewTextBoxColumn.Name = "soidDataGridViewTextBoxColumn";
            this.soidDataGridViewTextBoxColumn.Visible = false;
            // 
            // sodateDataGridViewTextBoxColumn
            // 
            this.sodateDataGridViewTextBoxColumn.DataPropertyName = "so_date";
            this.sodateDataGridViewTextBoxColumn.HeaderText = "so_date";
            this.sodateDataGridViewTextBoxColumn.Name = "sodateDataGridViewTextBoxColumn";
            this.sodateDataGridViewTextBoxColumn.Visible = false;
            // 
            // vhidDataGridViewTextBoxColumn
            // 
            this.vhidDataGridViewTextBoxColumn.DataPropertyName = "vh_id";
            this.vhidDataGridViewTextBoxColumn.HeaderText = "vh_id";
            this.vhidDataGridViewTextBoxColumn.Name = "vhidDataGridViewTextBoxColumn";
            this.vhidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vhidDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledidDataGridViewTextBoxColumn
            // 
            this.ledidDataGridViewTextBoxColumn.DataPropertyName = "led_id";
            this.ledidDataGridViewTextBoxColumn.HeaderText = "led_id";
            this.ledidDataGridViewTextBoxColumn.Name = "ledidDataGridViewTextBoxColumn";
            this.ledidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledidDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledaddress2DataGridViewTextBoxColumn
            // 
            this.ledaddress2DataGridViewTextBoxColumn.DataPropertyName = "led_address2";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ledaddress2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.ledaddress2DataGridViewTextBoxColumn.HeaderText = "City";
            this.ledaddress2DataGridViewTextBoxColumn.Name = "ledaddress2DataGridViewTextBoxColumn";
            this.ledaddress2DataGridViewTextBoxColumn.ReadOnly = true;
            this.ledaddress2DataGridViewTextBoxColumn.Width = 150;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 300;
            // 
            // vhnumberDataGridViewTextBoxColumn
            // 
            this.vhnumberDataGridViewTextBoxColumn.DataPropertyName = "vh_number";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.vhnumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.vhnumberDataGridViewTextBoxColumn.HeaderText = "Vehicle No.";
            this.vhnumberDataGridViewTextBoxColumn.Name = "vhnumberDataGridViewTextBoxColumn";
            this.vhnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.vhnumberDataGridViewTextBoxColumn.Width = 200;
            // 
            // leddeliveryorderDataGridViewTextBoxColumn
            // 
            this.leddeliveryorderDataGridViewTextBoxColumn.DataPropertyName = "led_deliveryorder";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.leddeliveryorderDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.leddeliveryorderDataGridViewTextBoxColumn.HeaderText = "Delivery Order";
            this.leddeliveryorderDataGridViewTextBoxColumn.Name = "leddeliveryorderDataGridViewTextBoxColumn";
            this.leddeliveryorderDataGridViewTextBoxColumn.ReadOnly = true;
            this.leddeliveryorderDataGridViewTextBoxColumn.Width = 150;
            // 
            // update_vh_number
            // 
            this.update_vh_number.DataPropertyName = "vh_id";
            this.update_vh_number.DataSource = this.vehicleBindingSource;
            this.update_vh_number.DisplayMember = "vh_number";
            this.update_vh_number.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.update_vh_number.HeaderText = "update Vehicle No.";
            this.update_vh_number.Name = "update_vh_number";
            this.update_vh_number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.update_vh_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.update_vh_number.ValueMember = "vh_id";
            this.update_vh_number.Width = 200;
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataSource = typeof(standard.classes.vehicle);
            // 
            // update_led_deliveryorder
            // 
            this.update_led_deliveryorder.DataPropertyName = "UpdateDeliveryNo";
            this.update_led_deliveryorder.HeaderText = "Update Delivery No.";
            this.update_led_deliveryorder.Name = "update_led_deliveryorder";
            this.update_led_deliveryorder.Width = 200;
            // 
            // uspGetCustomerVehicleDetailinSalesorderResultBindingSource
            // 
            this.uspGetCustomerVehicleDetailinSalesorderResultBindingSource.DataSource = typeof(standard.classes.usp_GetCustomerVehicleDetailinSalesorderResult);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel3.Controls.Add(this.cmdUpdate, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lightbutton1, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 769);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1205, 52);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdUpdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdUpdate.Location = new System.Drawing.Point(927, 7);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(130, 38);
            this.cmdUpdate.TabIndex = 1;
            this.cmdUpdate.Text = "&Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lightbutton1
            // 
            this.lightbutton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightbutton1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lightbutton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.lightbutton1.Location = new System.Drawing.Point(1067, 7);
            this.lightbutton1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.lightbutton1.Name = "lightbutton1";
            this.lightbutton1.Size = new System.Drawing.Size(133, 38);
            this.lightbutton1.TabIndex = 2;
            this.lightbutton1.Text = "&Close";
            this.lightbutton1.UseVisualStyleBackColor = true;
            this.lightbutton1.Click += new System.EventHandler(this.lightbutton1_Click);
            // 
            // frmCustomerVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1211, 824);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomerVehicle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Vehicle Details";
            this.Load += new System.EventHandler(this.frmItemlist_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetCustomerVehicleDetailinSalesorderResultBindingSource)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void lightbutton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
