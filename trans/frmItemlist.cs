using standard.classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace standard.trans
{
	public class frmItemlist : Form
	{
		private int _catid = 0;

		public int itemID = 0;

		public string itemname = "";

		private IContainer components = null;

		public DataGridView dgview;

		private BindingSource uspGetItemListResultBindingSource;

		private DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn cStock;

		private DataGridViewTextBoxColumn itempurchaserateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn itemcostrateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn itemsupersepecialrateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn itemspecialrateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn itemwholesalerateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn itemmrpDataGridViewTextBoxColumn;

		public int catid
		{
			get
			{
				return _catid;
			}
			set
			{
				_catid = value;
			}
		}

		public frmItemlist()
		{
			InitializeComponent();
		}

		private void frmItemlist_Load(object sender, EventArgs e)
		{
			if (_catid > 0)
			{
				LoadData();
			}
		}

		private void LoadData()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			dgview.DataSource = inventoryDataContext.usp_GetItemList(null, _catid);
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
			components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			dgview = new System.Windows.Forms.DataGridView();
			itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itempurchaserateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itemcostrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itemsupersepecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itemspecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itemwholesalerateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			itemmrpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			uspGetItemListResultBindingSource = new System.Windows.Forms.BindingSource(components);
			((System.ComponentModel.ISupportInitialize)dgview).BeginInit();
			((System.ComponentModel.ISupportInitialize)uspGetItemListResultBindingSource).BeginInit();
			SuspendLayout();
			dgview.AllowUserToAddRows = false;
			dgview.AllowUserToDeleteRows = false;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold);
			dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dgview.AutoGenerateColumns = false;
			dgview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			dgview.BackgroundColor = System.Drawing.Color.White;
			dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgview.Columns.AddRange(itemidDataGridViewTextBoxColumn, itemnameDataGridViewTextBoxColumn, cStock, itempurchaserateDataGridViewTextBoxColumn, itemcostrateDataGridViewTextBoxColumn, itemsupersepecialrateDataGridViewTextBoxColumn, itemspecialrateDataGridViewTextBoxColumn, itemwholesalerateDataGridViewTextBoxColumn, itemmrpDataGridViewTextBoxColumn);
			dgview.Cursor = System.Windows.Forms.Cursors.Default;
			dgview.DataSource = uspGetItemListResultBindingSource;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dgview.DefaultCellStyle = dataGridViewCellStyle3;
			dgview.Dock = System.Windows.Forms.DockStyle.Fill;
			dgview.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold);
			dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			dgview.Location = new System.Drawing.Point(0, 0);
			dgview.Margin = new System.Windows.Forms.Padding(4);
			dgview.MultiSelect = false;
			dgview.Name = "dgview";
			dgview.ReadOnly = true;
			dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dgview.RowHeadersVisible = false;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold);
			dgview.RowsDefaultCellStyle = dataGridViewCellStyle5;
			dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgview.Size = new System.Drawing.Size(1112, 674);
			dgview.TabIndex = 3;
			itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
			itemidDataGridViewTextBoxColumn.HeaderText = "item_id";
			itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
			itemidDataGridViewTextBoxColumn.ReadOnly = true;
			itemidDataGridViewTextBoxColumn.Visible = false;
			itemidDataGridViewTextBoxColumn.Width = 78;
			itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
			itemnameDataGridViewTextBoxColumn.FillWeight = 428.2585f;
			itemnameDataGridViewTextBoxColumn.HeaderText = "Item Name";
			itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
			itemnameDataGridViewTextBoxColumn.ReadOnly = true;
			itemnameDataGridViewTextBoxColumn.Width = 300;
			cStock.DataPropertyName = "stock";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkMagenta;
			dataGridViewCellStyle6.Format = "N0";
			cStock.DefaultCellStyle = dataGridViewCellStyle6;
			cStock.HeaderText = "Stock";
			cStock.Name = "cStock";
			cStock.ReadOnly = true;
			itempurchaserateDataGridViewTextBoxColumn.DataPropertyName = "item_purchaserate";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N2";
			itempurchaserateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
			itempurchaserateDataGridViewTextBoxColumn.FillWeight = 6.263931f;
			itempurchaserateDataGridViewTextBoxColumn.HeaderText = "Pur Rate";
			itempurchaserateDataGridViewTextBoxColumn.Name = "itempurchaserateDataGridViewTextBoxColumn";
			itempurchaserateDataGridViewTextBoxColumn.ReadOnly = true;
			itemcostrateDataGridViewTextBoxColumn.DataPropertyName = "item_costrate";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N2";
			itemcostrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
			itemcostrateDataGridViewTextBoxColumn.FillWeight = 9.575002f;
			itemcostrateDataGridViewTextBoxColumn.HeaderText = "Cost Rate";
			itemcostrateDataGridViewTextBoxColumn.Name = "itemcostrateDataGridViewTextBoxColumn";
			itemcostrateDataGridViewTextBoxColumn.ReadOnly = true;
			itemsupersepecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_supersepecialrate";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle9.Format = "N2";
			itemsupersepecialrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
			itemsupersepecialrateDataGridViewTextBoxColumn.FillWeight = 49.38031f;
			itemsupersepecialrateDataGridViewTextBoxColumn.HeaderText = "Super Spl Rate";
			itemsupersepecialrateDataGridViewTextBoxColumn.Name = "itemsupersepecialrateDataGridViewTextBoxColumn";
			itemsupersepecialrateDataGridViewTextBoxColumn.ReadOnly = true;
			itemsupersepecialrateDataGridViewTextBoxColumn.Width = 130;
			itemspecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_specialrate";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle10.Format = "N2";
			itemspecialrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
			itemspecialrateDataGridViewTextBoxColumn.FillWeight = 32.55278f;
			itemspecialrateDataGridViewTextBoxColumn.HeaderText = "Spl Rate";
			itemspecialrateDataGridViewTextBoxColumn.Name = "itemspecialrateDataGridViewTextBoxColumn";
			itemspecialrateDataGridViewTextBoxColumn.ReadOnly = true;
			itemspecialrateDataGridViewTextBoxColumn.Width = 130;
			itemwholesalerateDataGridViewTextBoxColumn.DataPropertyName = "item_wholesalerate";
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle11.Format = "N2";
			itemwholesalerateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
			itemwholesalerateDataGridViewTextBoxColumn.FillWeight = 21.70458f;
			itemwholesalerateDataGridViewTextBoxColumn.HeaderText = "Wholesale Rate";
			itemwholesalerateDataGridViewTextBoxColumn.Name = "itemwholesalerateDataGridViewTextBoxColumn";
			itemwholesalerateDataGridViewTextBoxColumn.ReadOnly = true;
			itemwholesalerateDataGridViewTextBoxColumn.Width = 130;
			itemmrpDataGridViewTextBoxColumn.DataPropertyName = "item_mrp";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle12.Format = "N2";
			itemmrpDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
			itemmrpDataGridViewTextBoxColumn.FillWeight = 14.71107f;
			itemmrpDataGridViewTextBoxColumn.HeaderText = "Mrp";
			itemmrpDataGridViewTextBoxColumn.Name = "itemmrpDataGridViewTextBoxColumn";
			itemmrpDataGridViewTextBoxColumn.ReadOnly = true;
			uspGetItemListResultBindingSource.DataSource = typeof(standard.classes.usp_GetItemListResult);
			base.AutoScaleDimensions = new System.Drawing.SizeF(13f, 25f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1112, 674);
			base.Controls.Add(dgview);
			Font = new System.Drawing.Font("Tahoma", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "frmItemlist";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Itemlist";
			base.Load += new System.EventHandler(frmItemlist_Load);
			((System.ComponentModel.ISupportInitialize)dgview).EndInit();
			((System.ComponentModel.ISupportInitialize)uspGetItemListResultBindingSource).EndInit();
			ResumeLayout(false);
		}
	}
}
