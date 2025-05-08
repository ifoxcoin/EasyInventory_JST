using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
	public class frmRoute : Form
	{
		private int id = 0;

		private IContainer components = null;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private TableLayoutPanel tblMain;

		private TableLayoutPanel tblEntry;

		private Label label1;

		private lightbutton cmdclose;

		private TextBox txtRoute;

		private DataGridView dgview;

		private TableLayoutPanel tblSearch;

		private TextBox txtSearch;

		private Label lblSearch;

		private TableLayoutPanel tblCommand;

		private lightbutton btnClear;

		private lightbutton btnDelete;

		private lightbutton btnSave;
        private BindingSource uspRouteSelectResultBindingSource;
        private Label lblCode;
        private DataGridViewTextBoxColumn cRoute;
        private DataGridViewTextBoxColumn catidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn catnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cCode;
        private DataGridViewTextBoxColumn cTamilName;
        private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn catudateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cCompany;
        private DataGridViewTextBoxColumn cat_udate;
        private DataGridViewTextBoxColumn users_uid;
        private DataGridViewTextBoxColumn ccat_id;
        private DataGridViewTextBoxColumn ccom_id;
        private DataGridViewTextBoxColumn rt_id;
        private DataGridViewTextBoxColumn rtRoute;
        private DataGridViewTextBoxColumn rtVehicleNo;
        private TextBox txtCode;

		public frmRoute()
		{
			InitializeComponent();
		}

		private void frmItems_Load(object sender, EventArgs e)
		{
			try
			{
				LoadData();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void cmdclose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void Clear()
		{
			txtRoute.Text = string.Empty;
            txtCode.Text = string.Empty;
			id = 0;
			LoadData();
		}

		private void LoadData()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			dgview.DataSource = inventoryDataContext.usp_routeSelect(null,txtSearch.Text);
            {
               
            }
           
        }

		private void EditData()
		{
			if (dgview.CurrentCell != null)
			{
				int rowIndex = dgview.CurrentCell.RowIndex;
				id = Convert.ToInt32(dgview["rt_id", rowIndex].Value);
				txtRoute.Text = Convert.ToString(dgview["rtRoute", rowIndex].Value);
                txtCode.Text = Convert.ToString(dgview["rtVehicleNo", rowIndex].Value);
                txtRoute.Focus();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (id != 0 && MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					InventoryDataContext inventoryDataContext = new InventoryDataContext();
					inventoryDataContext.usp_routeDelete(id);
					Clear();
					MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				route at = new route();
				at.rt_name = txtRoute.Text.Trim();
                at.rt_vehicleno = txtCode.Text.Trim();
                if (at.rt_name == string.Empty)
				{
					MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					txtRoute.Focus();
				}
				else
				{
					var source = from b in inventoryDataContext.routes
						where b.rt_name == at.rt_name && b.rt_id != (long)id
						select new
						{
							b.rt_id
						};
					if (source.Count() != 0)
					{
						MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						txtRoute.Focus();
					}
					else if (id == 0)
					{
						if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
						{
							inventoryDataContext.usp_routeInsert(at.rt_name,at.rt_vehicleno, global.ucode, global.sysdate);
							MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							goto IL_0315;
						}
					}
					else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						inventoryDataContext.usp_routeUpdate(id, at.rt_name,at.rt_vehicleno, global.ucode, global.sysdate);
						MessageBox.Show("Record updated successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_0315;
					}
				}
				goto end_IL_0010;
				IL_0315:
				Clear();
				end_IL_0010:;
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void dgview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditData();
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			dgview.DataSource = inventoryDataContext.usp_routeSelect(null,txtSearch.Text);
		}

		private void txtRoute_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return)
			{
                //SendKeys.Send("{TAB}");
                txtCode.Focus();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.uspRouteSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblEntry = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.tblCommand = new System.Windows.Forms.TableLayoutPanel();
            this.cmdclose = new mylib.lightbutton();
            this.btnClear = new mylib.lightbutton();
            this.btnDelete = new mylib.lightbutton();
            this.btnSave = new mylib.lightbutton();
            this.cat_udate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.users_uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccat_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccom_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a1Paneltitle.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspRouteSelectResultBindingSource)).BeginInit();
            this.tblEntry.SuspendLayout();
            this.tblCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Paneltitle
            // 
            this.a1Paneltitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
            this.a1Paneltitle.Controls.Add(this.lbltitle);
            this.a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
            this.a1Paneltitle.Image = null;
            this.a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Paneltitle.Location = new System.Drawing.Point(5, 6);
            this.a1Paneltitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1319, 44);
            this.a1Paneltitle.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(38, 8);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(82, 28);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "Route";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblMain
            // 
            this.tblMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblSearch, 0, 2);
            this.tblMain.Controls.Add(this.dgview, 0, 3);
            this.tblMain.Controls.Add(this.a1Paneltitle, 0, 0);
            this.tblMain.Controls.Add(this.tblEntry, 0, 1);
            this.tblMain.Controls.Add(this.tblCommand, 0, 4);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.Size = new System.Drawing.Size(1329, 768);
            this.tblMain.TabIndex = 2;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 368F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tblSearch.Controls.Add(this.lblSearch, 0, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(5, 224);
            this.tblSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1319, 59);
            this.tblSearch.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(358, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(358, 35);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSearch.Location = new System.Drawing.Point(4, 15);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(280, 28);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search By Route Name";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.AllowUserToResizeRows = false;
            this.dgview.AutoGenerateColumns = false;
            this.dgview.BackgroundColor = System.Drawing.Color.White;
            this.dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgview.ColumnHeadersHeight = 25;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cat_udate,
            this.users_uid,
            this.ccat_id,
            this.ccom_id,
            this.rt_id,
            this.rtRoute,
            this.rtVehicleNo});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.uspRouteSelectResultBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(5, 294);
            this.dgview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgview.Name = "dgview";
            this.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgview.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgview.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(1319, 397);
            this.dgview.TabIndex = 4;
            this.dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgview_CellDoubleClick);
            // 
            // uspRouteSelectResultBindingSource
            // 
            this.uspRouteSelectResultBindingSource.DataSource = typeof(standard.classes.usp_routeSelectResult);
            // 
            // tblEntry
            // 
            this.tblEntry.ColumnCount = 4;
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.Controls.Add(this.label1, 0, 1);
            this.tblEntry.Controls.Add(this.txtRoute, 1, 1);
            this.tblEntry.Controls.Add(this.lblCode, 0, 2);
            this.tblEntry.Controls.Add(this.txtCode, 1, 2);
            this.tblEntry.Location = new System.Drawing.Point(5, 61);
            this.tblEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblEntry.Name = "tblEntry";
            this.tblEntry.RowCount = 3;
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblEntry.Size = new System.Drawing.Size(1319, 152);
            this.tblEntry.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(4, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Route Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRoute
            // 
            this.txtRoute.BackColor = System.Drawing.Color.White;
            this.txtRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoute.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(304, 55);
            this.txtRoute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRoute.MaxLength = 50;
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(360, 34);
            this.txtRoute.TabIndex = 1;
            this.txtRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRoute_KeyDown);
            // 
            // lblCode
            // 
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCode.Location = new System.Drawing.Point(3, 112);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(143, 28);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Vehicle No.";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtCode.Location = new System.Drawing.Point(304, 109);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(361, 34);
            this.txtCode.TabIndex = 4;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // tblCommand
            // 
            this.tblCommand.ColumnCount = 5;
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.Controls.Add(this.cmdclose, 4, 0);
            this.tblCommand.Controls.Add(this.btnClear, 3, 0);
            this.tblCommand.Controls.Add(this.btnDelete, 2, 0);
            this.tblCommand.Controls.Add(this.btnSave, 1, 0);
            this.tblCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCommand.Location = new System.Drawing.Point(5, 702);
            this.tblCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblCommand.Name = "tblCommand";
            this.tblCommand.RowCount = 1;
            this.tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.Size = new System.Drawing.Size(1319, 60);
            this.tblCommand.TabIndex = 5;
            // 
            // cmdclose
            // 
            this.cmdclose.AutoSize = true;
            this.cmdclose.BackColor = System.Drawing.Color.Transparent;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1173, 5);
            this.cmdclose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(135, 50);
            this.cmdclose.TabIndex = 3;
            this.cmdclose.Text = "&Close";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = false;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClear.Location = new System.Drawing.Point(1023, 5);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 50);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "&Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnDelete.Location = new System.Drawing.Point(873, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 50);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSave.Location = new System.Drawing.Point(723, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cat_udate
            // 
            this.cat_udate.DataPropertyName = "cat_udate";
            this.cat_udate.HeaderText = "cat_udate";
            this.cat_udate.Name = "cat_udate";
            this.cat_udate.Visible = false;
            // 
            // users_uid
            // 
            this.users_uid.DataPropertyName = "users_uid";
            this.users_uid.HeaderText = "uid";
            this.users_uid.Name = "users_uid";
            this.users_uid.Visible = false;
            // 
            // ccat_id
            // 
            this.ccat_id.DataPropertyName = "cat_id";
            this.ccat_id.HeaderText = "cat_id";
            this.ccat_id.Name = "ccat_id";
            this.ccat_id.Visible = false;
            // 
            // ccom_id
            // 
            this.ccom_id.DataPropertyName = "com_id";
            this.ccom_id.HeaderText = "com_id";
            this.ccom_id.Name = "ccom_id";
            this.ccom_id.Visible = false;
            // 
            // rt_id
            // 
            this.rt_id.DataPropertyName = "rt_id";
            this.rt_id.HeaderText = "rt_id";
            this.rt_id.Name = "rt_id";
            this.rt_id.Visible = false;
            // 
            // rtRoute
            // 
            this.rtRoute.DataPropertyName = "rt_name";
            this.rtRoute.HeaderText = "Name";
            this.rtRoute.Name = "rtRoute";
            this.rtRoute.ReadOnly = true;
            this.rtRoute.Width = 200;
            // 
            // rtVehicleNo
            // 
            this.rtVehicleNo.DataPropertyName = "rt_vehicleno";
            this.rtVehicleNo.HeaderText = "Vehicle No";
            this.rtVehicleNo.Name = "rtVehicleNo";
            this.rtVehicleNo.ReadOnly = true;
            this.rtVehicleNo.Width = 200;
            // 
            // frmRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1329, 768);
            this.Controls.Add(this.tblMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmRoute";
            this.ShowIcon = false;
            this.Text = "Route";
            this.Load += new System.EventHandler(this.frmItems_Load);
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspRouteSelectResultBindingSource)).EndInit();
            this.tblEntry.ResumeLayout(false);
            this.tblEntry.PerformLayout();
            this.tblCommand.ResumeLayout(false);
            this.tblCommand.PerformLayout();
            this.ResumeLayout(false);

		}

        //private void cboCompany_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    txtRoute.Focus();
        //}

        private void cboCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRoute.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

      
    }
}
