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
        private DataGridViewTextBoxColumn itemtamilnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn item_quantity;
        private DataGridViewTextBoxColumn item_unit;
        private DataGridViewTextBoxColumn cStock;
        private DataGridViewTextBoxColumn itempurchaserateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemcostrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemsupersepecialrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemspecialrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemwholesalerateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemmrpDataGridViewTextBoxColumn;
        private BindingSource uspGetItemListResultBindingSource;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itempurchaserateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcostrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsupersepecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemspecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemwholesalerateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemmrpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspGetItemListResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetItemListResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgview.AutoGenerateColumns = false;
            this.dgview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgview.BackgroundColor = System.Drawing.Color.White;
            this.dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.item_quantity,
            this.item_unit,
            this.cStock,
            this.itempurchaserateDataGridViewTextBoxColumn,
            this.itemcostrateDataGridViewTextBoxColumn,
            this.itemsupersepecialrateDataGridViewTextBoxColumn,
            this.itemspecialrateDataGridViewTextBoxColumn,
            this.itemwholesalerateDataGridViewTextBoxColumn,
            this.itemmrpDataGridViewTextBoxColumn});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.uspGetItemListResultBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(0, 0);
            this.dgview.Margin = new System.Windows.Forms.Padding(4);
            this.dgview.MultiSelect = false;
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgview.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.dgview.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(1112, 674);
            this.dgview.TabIndex = 3;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "item_id";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Visible = false;
            this.itemidDataGridViewTextBoxColumn.Width = 78;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_tamilname";
            this.itemnameDataGridViewTextBoxColumn.FillWeight = 428.2585F;
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Item Name";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 300;
            // 
            // item_quantity
            // 
            this.item_quantity.DataPropertyName = "item_quantity";
            this.item_quantity.HeaderText = "Unit";
            this.item_quantity.Name = "item_quantity";
            this.item_quantity.ReadOnly = true;
            // 
            // item_unit
            // 
            this.item_unit.DataPropertyName = "item_unit";
            this.item_unit.HeaderText = "Unit Type";
            this.item_unit.Name = "item_unit";
            this.item_unit.ReadOnly = true;
            // 
            // cStock
            // 
            this.cStock.DataPropertyName = "stock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle3.Format = "N0";
            this.cStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.cStock.HeaderText = "Stock";
            this.cStock.Name = "cStock";
            this.cStock.ReadOnly = true;
            // 
            // itempurchaserateDataGridViewTextBoxColumn
            // 
            this.itempurchaserateDataGridViewTextBoxColumn.DataPropertyName = "item_purchaserate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.itempurchaserateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.itempurchaserateDataGridViewTextBoxColumn.FillWeight = 6.263931F;
            this.itempurchaserateDataGridViewTextBoxColumn.HeaderText = "Pur Rate";
            this.itempurchaserateDataGridViewTextBoxColumn.Name = "itempurchaserateDataGridViewTextBoxColumn";
            this.itempurchaserateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemcostrateDataGridViewTextBoxColumn
            // 
            this.itemcostrateDataGridViewTextBoxColumn.DataPropertyName = "item_costrate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.itemcostrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.itemcostrateDataGridViewTextBoxColumn.FillWeight = 9.575002F;
            this.itemcostrateDataGridViewTextBoxColumn.HeaderText = "Cost Rate";
            this.itemcostrateDataGridViewTextBoxColumn.Name = "itemcostrateDataGridViewTextBoxColumn";
            this.itemcostrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcostrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsupersepecialrateDataGridViewTextBoxColumn
            // 
            this.itemsupersepecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_supersepecialrate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.itemsupersepecialrateDataGridViewTextBoxColumn.FillWeight = 49.38031F;
            this.itemsupersepecialrateDataGridViewTextBoxColumn.HeaderText = "Super Spl Rate (A)";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.Name = "itemsupersepecialrateDataGridViewTextBoxColumn";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsupersepecialrateDataGridViewTextBoxColumn.Width = 130;
            // 
            // itemspecialrateDataGridViewTextBoxColumn
            // 
            this.itemspecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_specialrate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.itemspecialrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.itemspecialrateDataGridViewTextBoxColumn.FillWeight = 32.55278F;
            this.itemspecialrateDataGridViewTextBoxColumn.HeaderText = "Spl Rate (B)";
            this.itemspecialrateDataGridViewTextBoxColumn.Name = "itemspecialrateDataGridViewTextBoxColumn";
            this.itemspecialrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemspecialrateDataGridViewTextBoxColumn.Width = 130;
            // 
            // itemwholesalerateDataGridViewTextBoxColumn
            // 
            this.itemwholesalerateDataGridViewTextBoxColumn.DataPropertyName = "item_wholesalerate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.itemwholesalerateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.itemwholesalerateDataGridViewTextBoxColumn.FillWeight = 21.70458F;
            this.itemwholesalerateDataGridViewTextBoxColumn.HeaderText = "Wholesale Rate (C)";
            this.itemwholesalerateDataGridViewTextBoxColumn.Name = "itemwholesalerateDataGridViewTextBoxColumn";
            this.itemwholesalerateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemwholesalerateDataGridViewTextBoxColumn.Width = 130;
            // 
            // itemmrpDataGridViewTextBoxColumn
            // 
            this.itemmrpDataGridViewTextBoxColumn.DataPropertyName = "item_mrp";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.itemmrpDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.itemmrpDataGridViewTextBoxColumn.FillWeight = 14.71107F;
            this.itemmrpDataGridViewTextBoxColumn.HeaderText = "Mrp";
            this.itemmrpDataGridViewTextBoxColumn.Name = "itemmrpDataGridViewTextBoxColumn";
            this.itemmrpDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemmrpDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspGetItemListResultBindingSource
            // 
            this.uspGetItemListResultBindingSource.DataSource = typeof(standard.classes.usp_GetItemListResult);
            // 
            // frmItemlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 674);
            this.Controls.Add(this.dgview);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmItemlist";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Itemlist";
            this.Load += new System.EventHandler(this.frmItemlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetItemListResultBindingSource)).EndInit();
            this.ResumeLayout(false);

		}
	}
}
