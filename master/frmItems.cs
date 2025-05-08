using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
    public class frmItems : Form
    {
        private int id = 0;

        private IContainer components = null;

        private a1panel a1Paneltitle;

        private Label lbltitle;

        private TableLayoutPanel tblMain;

        private TableLayoutPanel tblEntry;

        private Label label1;

        private Label label3;

        private Label label4;

        private Label label6;

        private Label label7;

        private Label label8;

        private Label label9;

        private lightbutton cmdclose;

        private TextBox txtMRP;

        private TextBox txtItemName;

        private TextBox txtPRate;

        private TextBox txtWholeSaleRate;

        private TextBox txtSpecialRate;

        private TextBox txtSuperSplRate;

        private ComboBox cboCategory;

        private DataGridView dgview;

        private TableLayoutPanel tblSearch;

        private TextBox txtSearch;

        private Label label10;

        private TableLayoutPanel tblCommand;

        private lightbutton btnClear;

        private lightbutton btnDelete;

        private lightbutton btnSave;

        private Label lblSearch;

        private BindingSource categoryBindingSource;

        private BindingSource uspitemSelectResultBindingSource;

        private Label label11;

        private ComboBox cboSearchCategory;
        private Label label12;
        private TextBox txtSerial;
        private Label label13;
        private TextBox txtBatchSearch;
        private Label lblItemFullName;
        private TextBox txtItemFullName;
        private Label lblItemTamilName;
        private TextBox txtItemTamilName;
        private Label lblCompany;
        private ComboBox cboCompany;
        private BindingSource uspcategorySelectResultBindingSource;
        private Label lblTaxPercentage;
        private TextBox txtTaxPercentage;
        private Label lblTamil;
        private BindingSource uspitemSelectResultBindingSource1;
        private BindingSource uspitemSelectResultBindingSource2;
        private Label lblItemUnit;
        private ComboBox cboItemUnit;
        private TextBox txtItemQuantity;
        private DataGridViewTextBoxColumn item_serial;
        private DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemcodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemserialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn catnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemfullnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemtamilnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn catidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemquantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemunitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itempurchaserateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemcostrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemmrpDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemwholesalerateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemspecialrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemsupersepecialrateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemtaxpercentageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn itemudateDataGridViewTextBoxColumn;
        private Label lbItemUnitType;
        private ComboBox cboItemUnitType;
        private TextBox txtUnitPerRate;
        private Label lblUnitPerRate;
        private CheckBox chkIsUnitPerRate;
        private BindingSource companyBindingSource;
        private TextBox txtCostRate;
        private Label label2;
        private TextBox txtItemCode;
        private TableLayoutPanel tableLayoutPanel1;
        private BindingSource searchcategoryBindingSource;

        public frmItems()
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
            id = 0;
            //txtItemCode.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtItemFullName.Text = string.Empty;
            txtItemTamilName.Text = string.Empty;
            txtTaxPercentage.Text = "0";
            chkIsUnitPerRate.Checked = false;
            txtUnitPerRate.Text = "0";
            txtPRate.Text = "0";
           // txtCostRate.Text = "0";
            txtMRP.Text = "0";
            txtWholeSaleRate.Text = "0";
            txtSpecialRate.Text = "0";
            txtSuperSplRate.Text = "0";
            txtSearch.Text = string.Empty;
            txtItemQuantity.Text = "0";
            LoadData();
            cboCategory.SelectedValue = 0;
            cboCompany.SelectedValue = 0;
            
            cboSearchCategory.SelectedValue = 0;
            cboItemUnitType.SelectedIndex = 1;
            cboItemUnit.SelectedIndex = 1;
        }

        private void LoadData()
        {
            txtItemName.Select();
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            dgview.DataSource = inventoryDataContext.usp_itemSelect(null, null, null,null);
            searchcategoryBindingSource.Clear();
            searchcategoryBindingSource.DataSource = inventoryDataContext.categories.Select((category li) => li);
            categoryBindingSource.DataSource = inventoryDataContext.categories.Select((category li) => li);
            companyBindingSource.DataSource = inventoryDataContext.companies.Select((company li) => li);
            cboCompany.SelectedValue = string.Empty;
            cboItemUnitType.SelectedIndex = 1;
            cboItemUnit.SelectedIndex = 1;
        }

        private void EditData()
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            if (dgview.CurrentCell != null)
            {
                int rowIndex = dgview.CurrentCell.RowIndex;
                id = Convert.ToInt32(dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value);
                ISingleResult<usp_itemSelectResult> singleResult = inventoryDataContext.usp_itemSelect(id, null, null,null);
                foreach (usp_itemSelectResult item in singleResult)
                {
                    txtItemCode.Text = item.item_code;
                    txtSerial.Text = item.item_serial.ToString();
                    txtItemName.Text = item.item_name;
                    txtItemFullName.Text = item.item_fullname;
                    txtItemTamilName.Text = item.item_tamilname;
                    txtTaxPercentage.Text = item.item_taxpercentage.ToString("N2");
                    cboCategory.SelectedValue = item.cat_id;
                    chkIsUnitPerRate.Checked = item.item_isunitperrate;
                    txtUnitPerRate.Text = item.item_perunitrate.ToString("N2");
                    cboItemUnit.Text = item.item_unit;
                    txtItemQuantity.Text = item.item_quantity.ToString();
                    cboItemUnitType.Text = item.item_unittype;
                    txtPRate.Text = item.item_purchaserate.ToString("N2");
                    txtCostRate.Text = item.item_costrate.ToString("N2");
                    txtMRP.Text = item.item_mrp.ToString("N2");
                    txtWholeSaleRate.Text = item.item_wholesalerate.ToString("N2");
                    txtSpecialRate.Text = item.item_specialrate.ToString("N2");
                    txtSuperSplRate.Text = item.item_supersepecialrate.ToString("N2");
                    txtItemName.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (id != 0 && MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    inventoryDataContext.usp_itemDelete(id);
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

        private int GetNextSerialNumber()
        {
            InventoryDataContext db = new InventoryDataContext();
            int lastSerial = db.items.Any() ? db.items.Max(x => x.item_serial).GetValueOrDefault() : 0;
            return lastSerial + 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            item it = new item();
            try
            {
                it.item_code = txtItemCode.Text.Trim();
                it.item_serial = Convert.ToInt32(GetNextSerialNumber().ToString());
                it.item_name = txtItemName.Text.Trim();
                it.item_fullname = txtItemFullName.Text.Trim();
                it.item_tamilname = txtItemTamilName.Text.Trim();
                it.item_taxpercentage = Convert.ToDecimal(txtTaxPercentage.Text.Trim());
                it.cat_id = Convert.ToInt32(cboCategory.SelectedValue);
                it.item_isunitperrate = chkIsUnitPerRate.Checked;
                it.item_perunitrate = Convert.ToDecimal(txtUnitPerRate.Text.Trim());
                if (cboItemUnit.Text == "---Select---")
                {
                    cboItemUnit.Text = "";
                }
                it.item_unit = cboItemUnit.Text.Trim();
                it.item_quantity = Convert.ToInt32(txtItemQuantity.Text.Trim());
                if (cboItemUnitType.Text == "---Select---")
                {
                    cboItemUnitType.Text = "";
                }
                if (cboCompany.SelectedValue != null)
                {
                    it.com_id = Convert.ToInt32(cboCompany.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Please select a company.");
                }
                it.item_unittype = cboItemUnitType.Text.Trim();
                it.item_purchaserate = Convert.ToDecimal(txtPRate.Text.Trim());
                it.item_costrate = 0;
                it.item_mrp = Convert.ToDecimal(txtMRP.Text.Trim());
                it.item_wholesalerate = Convert.ToDecimal(txtWholeSaleRate.Text.Trim());
                it.item_specialrate = Convert.ToDecimal(txtSpecialRate.Text.Trim());
                it.item_supersepecialrate = Convert.ToDecimal(txtSuperSplRate.Text.Trim());
                if (it.item_name == string.Empty)
                {
                    MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtItemName.Focus();
                }
                else if (it.cat_id <= 0)
                {
                    MessageBox.Show("Invalid 'Category'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtItemName.Focus();
                }
                else if (it.item_purchaserate <= 0m)
                {
                    MessageBox.Show("Invalid 'Purchaserate'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPRate.Focus();
                }
                //else if (it.item_costrate <= 0m)
                //{
                //    MessageBox.Show("Invalid 'Costrate'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    txtCostRate.Focus();
                //}
                else if (it.item_serial <= 0)
                {
                    MessageBox.Show("Invalid 'Serial No'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtSerial.Focus();
                }
                else
                {
                    var source = from b in inventoryDataContext.items
                                 where b.item_name == it.item_name && b.item_id != (long)id
                                 select new
                                 {
                                     b.cat_id
                                 };
                    if (source.Count() != 0)
                    {
                        MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtItemName.Focus();
                    }
                    else if (id == 0)
                    {
                        if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                        {
                            inventoryDataContext.usp_itemInsert(it.item_code, it.item_serial, it.item_name,it.item_fullname,it.item_tamilname, it.cat_id, it.item_isunitperrate, it.item_perunitrate, it.item_unit, it.item_quantity, it.item_unittype, it.item_purchaserate, it.item_costrate, it.item_mrp, it.item_wholesalerate, it.item_specialrate, it.item_supersepecialrate,it.item_taxpercentage, global.ucode, it.com_id, global.sysdate);
                            MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            goto IL_0602;
                        }
                    }
                    else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        inventoryDataContext.usp_itemUpdate(id, it.item_code, it.item_serial, it.item_name, it.item_fullname, it.item_tamilname, it.cat_id, it.item_isunitperrate, it.item_perunitrate, it.item_unit, it.item_quantity, it.item_unittype, it.item_purchaserate, it.item_costrate, it.item_mrp, it.item_wholesalerate, it.item_specialrate, it.item_supersepecialrate,it.item_taxpercentage, global.ucode, it.com_id, global.sysdate);
                        MessageBox.Show("Record updated successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        goto IL_0602;
                    }
                }
                goto end_IL_0022;
                IL_0602:
                Clear();
                end_IL_0022:;
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
            dgview.DataSource = inventoryDataContext.usp_itemSelect(null, txtSearch.Text, Convert.ToInt32(cboSearchCategory.SelectedValue),txtBatchSearch.Text);
        }

        private void inputControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void cboSearchCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(null, null);
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboSearchCategory = new System.Windows.Forms.ComboBox();
            this.searchcategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtBatchSearch = new System.Windows.Forms.TextBox();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.item_serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemserialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemfullnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtamilnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemquantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemunitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itempurchaserateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcostrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemmrpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemwholesalerateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemspecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsupersepecialrateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtaxpercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemudateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspitemSelectResultBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tblEntry = new System.Windows.Forms.TableLayoutPanel();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemUnit = new System.Windows.Forms.Label();
            this.txtCostRate = new System.Windows.Forms.TextBox();
            this.lblTamil = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.lblItemFullName = new System.Windows.Forms.Label();
            this.txtItemFullName = new System.Windows.Forms.TextBox();
            this.txtItemTamilName = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboItemUnit = new System.Windows.Forms.ComboBox();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.chkIsUnitPerRate = new System.Windows.Forms.CheckBox();
            this.txtUnitPerRate = new System.Windows.Forms.TextBox();
            this.lblUnitPerRate = new System.Windows.Forms.Label();
            this.lbItemUnitType = new System.Windows.Forms.Label();
            this.cboItemUnitType = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtSuperSplRate = new System.Windows.Forms.TextBox();
            this.txtSpecialRate = new System.Windows.Forms.TextBox();
            this.txtWholeSaleRate = new System.Windows.Forms.TextBox();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtPRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTaxPercentage = new System.Windows.Forms.Label();
            this.txtTaxPercentage = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.lblItemTamilName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tblCommand = new System.Windows.Forms.TableLayoutPanel();
            this.cmdclose = new mylib.lightbutton();
            this.btnClear = new mylib.lightbutton();
            this.btnDelete = new mylib.lightbutton();
            this.btnSave = new mylib.lightbutton();
            this.uspcategorySelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspitemSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspitemSelectResultBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.a1Paneltitle.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchcategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource2)).BeginInit();
            this.tblEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.tblCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspcategorySelectResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource1)).BeginInit();
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
            this.a1Paneltitle.Size = new System.Drawing.Size(1914, 44);
            this.a1Paneltitle.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(38, 8);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(72, 28);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "ITEM";
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
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.Size = new System.Drawing.Size(1924, 768);
            this.tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Controls.Add(this.lblSearch, 2, 0);
            this.tblSearch.Controls.Add(this.label11, 0, 0);
            this.tblSearch.Controls.Add(this.cboSearchCategory, 1, 0);
            this.tblSearch.Controls.Add(this.label13, 4, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 5, 0);
            this.tblSearch.Controls.Add(this.txtBatchSearch, 3, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(5, 347);
            this.tblSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1914, 59);
            this.tblSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSearch.Location = new System.Drawing.Point(540, 1);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(128, 56);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search By Batch";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label11.Location = new System.Drawing.Point(4, 1);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 56);
            this.label11.TabIndex = 0;
            this.label11.Text = "Search By Category";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSearchCategory
            // 
            this.cboSearchCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSearchCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSearchCategory.DataSource = this.searchcategoryBindingSource;
            this.cboSearchCategory.DisplayMember = "cat_name";
            this.cboSearchCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSearchCategory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchCategory.FormattingEnabled = true;
            this.cboSearchCategory.Location = new System.Drawing.Point(250, 5);
            this.cboSearchCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSearchCategory.Name = "cboSearchCategory";
            this.cboSearchCategory.Size = new System.Drawing.Size(278, 36);
            this.cboSearchCategory.TabIndex = 0;
            this.cboSearchCategory.ValueMember = "cat_id";
            this.cboSearchCategory.SelectedValueChanged += new System.EventHandler(this.cboSearchCategory_SelectedValueChanged);
            this.cboSearchCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // searchcategoryBindingSource
            // 
            this.searchcategoryBindingSource.DataSource = typeof(standard.classes.category);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label13.Location = new System.Drawing.Point(958, 15);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 28);
            this.label13.TabIndex = 0;
            this.label13.Text = "Search By Item";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(1166, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(290, 33);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtBatchSearch
            // 
            this.txtBatchSearch.BackColor = System.Drawing.Color.White;
            this.txtBatchSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchSearch.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSearch.Location = new System.Drawing.Point(746, 5);
            this.txtBatchSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBatchSearch.MaxLength = 50;
            this.txtBatchSearch.Name = "txtBatchSearch";
            this.txtBatchSearch.Size = new System.Drawing.Size(200, 33);
            this.txtBatchSearch.TabIndex = 1;
            this.txtBatchSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgview.AutoGenerateColumns = false;
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
            this.dgview.ColumnHeadersHeight = 28;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_serial,
            this.itemidDataGridViewTextBoxColumn,
            this.itemcodeDataGridViewTextBoxColumn,
            this.itemserialDataGridViewTextBoxColumn,
            this.catnameDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.itemfullnameDataGridViewTextBoxColumn,
            this.itemtamilnameDataGridViewTextBoxColumn,
            this.catidDataGridViewTextBoxColumn,
            this.itemquantityDataGridViewTextBoxColumn,
            this.itemunitDataGridViewTextBoxColumn,
            this.itempurchaserateDataGridViewTextBoxColumn,
            this.itemcostrateDataGridViewTextBoxColumn,
            this.itemmrpDataGridViewTextBoxColumn,
            this.itemwholesalerateDataGridViewTextBoxColumn,
            this.itemspecialrateDataGridViewTextBoxColumn,
            this.itemsupersepecialrateDataGridViewTextBoxColumn,
            this.itemtaxpercentageDataGridViewTextBoxColumn,
            this.usersuidDataGridViewTextBoxColumn,
            this.usersnameDataGridViewTextBoxColumn,
            this.comidDataGridViewTextBoxColumn,
            this.comnameDataGridViewTextBoxColumn,
            this.itemudateDataGridViewTextBoxColumn});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.uspitemSelectResultBindingSource2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(5, 417);
            this.dgview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgview.MultiSelect = false;
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgview.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgview.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(1914, 275);
            this.dgview.TabIndex = 0;
            this.dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgview_CellDoubleClick);
            // 
            // item_serial
            // 
            this.item_serial.DataPropertyName = "item_serial";
            this.item_serial.HeaderText = "S.No";
            this.item_serial.Name = "item_serial";
            this.item_serial.ReadOnly = true;
            this.item_serial.Visible = false;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "item_id";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemcodeDataGridViewTextBoxColumn
            // 
            this.itemcodeDataGridViewTextBoxColumn.DataPropertyName = "item_code";
            this.itemcodeDataGridViewTextBoxColumn.HeaderText = "item_code";
            this.itemcodeDataGridViewTextBoxColumn.Name = "itemcodeDataGridViewTextBoxColumn";
            this.itemcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemserialDataGridViewTextBoxColumn
            // 
            this.itemserialDataGridViewTextBoxColumn.DataPropertyName = "item_serial";
            this.itemserialDataGridViewTextBoxColumn.HeaderText = "S.NO";
            this.itemserialDataGridViewTextBoxColumn.Name = "itemserialDataGridViewTextBoxColumn";
            this.itemserialDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemserialDataGridViewTextBoxColumn.Width = 50;
            // 
            // catnameDataGridViewTextBoxColumn
            // 
            this.catnameDataGridViewTextBoxColumn.DataPropertyName = "cat_name";
            this.catnameDataGridViewTextBoxColumn.HeaderText = "Catogery";
            this.catnameDataGridViewTextBoxColumn.Name = "catnameDataGridViewTextBoxColumn";
            this.catnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.catnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Item Name";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // itemfullnameDataGridViewTextBoxColumn
            // 
            this.itemfullnameDataGridViewTextBoxColumn.DataPropertyName = "item_fullname";
            this.itemfullnameDataGridViewTextBoxColumn.HeaderText = "Item Full Name";
            this.itemfullnameDataGridViewTextBoxColumn.Name = "itemfullnameDataGridViewTextBoxColumn";
            this.itemfullnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemfullnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // itemtamilnameDataGridViewTextBoxColumn
            // 
            this.itemtamilnameDataGridViewTextBoxColumn.DataPropertyName = "item_tamilname";
            this.itemtamilnameDataGridViewTextBoxColumn.HeaderText = "Item Tamil Name";
            this.itemtamilnameDataGridViewTextBoxColumn.Name = "itemtamilnameDataGridViewTextBoxColumn";
            this.itemtamilnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemtamilnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // catidDataGridViewTextBoxColumn
            // 
            this.catidDataGridViewTextBoxColumn.DataPropertyName = "cat_id";
            this.catidDataGridViewTextBoxColumn.HeaderText = "cat_id";
            this.catidDataGridViewTextBoxColumn.Name = "catidDataGridViewTextBoxColumn";
            this.catidDataGridViewTextBoxColumn.ReadOnly = true;
            this.catidDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemquantityDataGridViewTextBoxColumn
            // 
            this.itemquantityDataGridViewTextBoxColumn.DataPropertyName = "item_quantity";
            this.itemquantityDataGridViewTextBoxColumn.HeaderText = "Item Quantity";
            this.itemquantityDataGridViewTextBoxColumn.Name = "itemquantityDataGridViewTextBoxColumn";
            this.itemquantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemunitDataGridViewTextBoxColumn
            // 
            this.itemunitDataGridViewTextBoxColumn.DataPropertyName = "item_unit";
            this.itemunitDataGridViewTextBoxColumn.HeaderText = "Item Unit";
            this.itemunitDataGridViewTextBoxColumn.Name = "itemunitDataGridViewTextBoxColumn";
            this.itemunitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itempurchaserateDataGridViewTextBoxColumn
            // 
            this.itempurchaserateDataGridViewTextBoxColumn.DataPropertyName = "item_purchaserate";
            this.itempurchaserateDataGridViewTextBoxColumn.HeaderText = "item_purchaserate";
            this.itempurchaserateDataGridViewTextBoxColumn.Name = "itempurchaserateDataGridViewTextBoxColumn";
            this.itempurchaserateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itempurchaserateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemcostrateDataGridViewTextBoxColumn
            // 
            this.itemcostrateDataGridViewTextBoxColumn.DataPropertyName = "item_costrate";
            this.itemcostrateDataGridViewTextBoxColumn.HeaderText = "item_costrate";
            this.itemcostrateDataGridViewTextBoxColumn.Name = "itemcostrateDataGridViewTextBoxColumn";
            this.itemcostrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemcostrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemmrpDataGridViewTextBoxColumn
            // 
            this.itemmrpDataGridViewTextBoxColumn.DataPropertyName = "item_mrp";
            this.itemmrpDataGridViewTextBoxColumn.HeaderText = "item_mrp";
            this.itemmrpDataGridViewTextBoxColumn.Name = "itemmrpDataGridViewTextBoxColumn";
            this.itemmrpDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemmrpDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemwholesalerateDataGridViewTextBoxColumn
            // 
            this.itemwholesalerateDataGridViewTextBoxColumn.DataPropertyName = "item_wholesalerate";
            this.itemwholesalerateDataGridViewTextBoxColumn.HeaderText = "item_wholesalerate";
            this.itemwholesalerateDataGridViewTextBoxColumn.Name = "itemwholesalerateDataGridViewTextBoxColumn";
            this.itemwholesalerateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemwholesalerateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemspecialrateDataGridViewTextBoxColumn
            // 
            this.itemspecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_specialrate";
            this.itemspecialrateDataGridViewTextBoxColumn.HeaderText = "item_specialrate";
            this.itemspecialrateDataGridViewTextBoxColumn.Name = "itemspecialrateDataGridViewTextBoxColumn";
            this.itemspecialrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemspecialrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsupersepecialrateDataGridViewTextBoxColumn
            // 
            this.itemsupersepecialrateDataGridViewTextBoxColumn.DataPropertyName = "item_supersepecialrate";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.HeaderText = "item_supersepecialrate";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.Name = "itemsupersepecialrateDataGridViewTextBoxColumn";
            this.itemsupersepecialrateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsupersepecialrateDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemtaxpercentageDataGridViewTextBoxColumn
            // 
            this.itemtaxpercentageDataGridViewTextBoxColumn.DataPropertyName = "item_taxpercentage";
            this.itemtaxpercentageDataGridViewTextBoxColumn.HeaderText = "item_taxpercentage";
            this.itemtaxpercentageDataGridViewTextBoxColumn.Name = "itemtaxpercentageDataGridViewTextBoxColumn";
            this.itemtaxpercentageDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemtaxpercentageDataGridViewTextBoxColumn.Visible = false;
            // 
            // usersuidDataGridViewTextBoxColumn
            // 
            this.usersuidDataGridViewTextBoxColumn.DataPropertyName = "users_uid";
            this.usersuidDataGridViewTextBoxColumn.HeaderText = "users_uid";
            this.usersuidDataGridViewTextBoxColumn.Name = "usersuidDataGridViewTextBoxColumn";
            this.usersuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // usersnameDataGridViewTextBoxColumn
            // 
            this.usersnameDataGridViewTextBoxColumn.DataPropertyName = "users_name";
            this.usersnameDataGridViewTextBoxColumn.HeaderText = "users_name";
            this.usersnameDataGridViewTextBoxColumn.Name = "usersnameDataGridViewTextBoxColumn";
            this.usersnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.usersnameDataGridViewTextBoxColumn.Visible = false;
            // 
            // comidDataGridViewTextBoxColumn
            // 
            this.comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
            this.comidDataGridViewTextBoxColumn.HeaderText = "com_id";
            this.comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
            this.comidDataGridViewTextBoxColumn.ReadOnly = true;
            this.comidDataGridViewTextBoxColumn.Visible = false;
            // 
            // comnameDataGridViewTextBoxColumn
            // 
            this.comnameDataGridViewTextBoxColumn.DataPropertyName = "com_name";
            this.comnameDataGridViewTextBoxColumn.HeaderText = "Company";
            this.comnameDataGridViewTextBoxColumn.Name = "comnameDataGridViewTextBoxColumn";
            this.comnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.comnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // itemudateDataGridViewTextBoxColumn
            // 
            this.itemudateDataGridViewTextBoxColumn.DataPropertyName = "item_udate";
            this.itemudateDataGridViewTextBoxColumn.HeaderText = "item_udate";
            this.itemudateDataGridViewTextBoxColumn.Name = "itemudateDataGridViewTextBoxColumn";
            this.itemudateDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemudateDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspitemSelectResultBindingSource2
            // 
            this.uspitemSelectResultBindingSource2.DataSource = typeof(standard.classes.usp_itemSelectResult);
            // 
            // tblEntry
            // 
            this.tblEntry.ColumnCount = 7;
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.Controls.Add(this.txtItemName, 1, 0);
            this.tblEntry.Controls.Add(this.label1, 0, 0);
            this.tblEntry.Controls.Add(this.lblItemUnit, 0, 4);
            this.tblEntry.Controls.Add(this.txtCostRate, 5, 6);
            this.tblEntry.Controls.Add(this.lblTamil, 4, 3);
            this.tblEntry.Controls.Add(this.label2, 4, 2);
            this.tblEntry.Controls.Add(this.txtItemCode, 5, 2);
            this.tblEntry.Controls.Add(this.lblItemFullName, 4, 5);
            this.tblEntry.Controls.Add(this.txtItemFullName, 5, 5);
            this.tblEntry.Controls.Add(this.txtItemTamilName, 1, 1);
            this.tblEntry.Controls.Add(this.cboCategory, 1, 2);
            this.tblEntry.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tblEntry.Controls.Add(this.chkIsUnitPerRate, 1, 4);
            this.tblEntry.Controls.Add(this.txtUnitPerRate, 1, 5);
            this.tblEntry.Controls.Add(this.lblUnitPerRate, 0, 5);
            this.tblEntry.Controls.Add(this.lbItemUnitType, 0, 6);
            this.tblEntry.Controls.Add(this.cboItemUnitType, 1, 6);
            this.tblEntry.Controls.Add(this.lblCompany, 2, 0);
            this.tblEntry.Controls.Add(this.cboCompany, 3, 0);
            this.tblEntry.Controls.Add(this.label9, 2, 1);
            this.tblEntry.Controls.Add(this.txtSuperSplRate, 3, 1);
            this.tblEntry.Controls.Add(this.txtSpecialRate, 3, 2);
            this.tblEntry.Controls.Add(this.txtWholeSaleRate, 3, 3);
            this.tblEntry.Controls.Add(this.txtMRP, 3, 4);
            this.tblEntry.Controls.Add(this.txtPRate, 3, 5);
            this.tblEntry.Controls.Add(this.label8, 2, 2);
            this.tblEntry.Controls.Add(this.label7, 2, 3);
            this.tblEntry.Controls.Add(this.label6, 2, 4);
            this.tblEntry.Controls.Add(this.label4, 2, 5);
            this.tblEntry.Controls.Add(this.lblTaxPercentage, 2, 6);
            this.tblEntry.Controls.Add(this.txtTaxPercentage, 3, 6);
            this.tblEntry.Controls.Add(this.label12, 4, 0);
            this.tblEntry.Controls.Add(this.txtSerial, 5, 0);
            this.tblEntry.Controls.Add(this.lblItemTamilName, 0, 1);
            this.tblEntry.Controls.Add(this.label3, 0, 2);
            this.tblEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEntry.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblEntry.Location = new System.Drawing.Point(5, 61);
            this.tblEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblEntry.Name = "tblEntry";
            this.tblEntry.RowCount = 7;
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tblEntry.Size = new System.Drawing.Size(1914, 275);
            this.tblEntry.TabIndex = 2;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(304, 5);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(290, 35);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemUnit
            // 
            this.lblItemUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemUnit.AutoSize = true;
            this.lblItemUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblItemUnit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblItemUnit.Location = new System.Drawing.Point(4, 161);
            this.lblItemUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemUnit.Name = "lblItemUnit";
            this.lblItemUnit.Size = new System.Drawing.Size(61, 28);
            this.lblItemUnit.TabIndex = 28;
            this.lblItemUnit.Text = "Unit";
            this.lblItemUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCostRate
            // 
            this.txtCostRate.BackColor = System.Drawing.Color.White;
            this.txtCostRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostRate.Location = new System.Drawing.Point(1504, 239);
            this.txtCostRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCostRate.MaxLength = 50;
            this.txtCostRate.Name = "txtCostRate";
            this.txtCostRate.Size = new System.Drawing.Size(290, 35);
            this.txtCostRate.TabIndex = 41;
            this.txtCostRate.Text = "0";
            this.txtCostRate.Visible = false;
            this.txtCostRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // lblTamil
            // 
            this.lblTamil.BackColor = System.Drawing.Color.White;
            this.lblTamil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTamil.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTamil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblTamil.Location = new System.Drawing.Point(1204, 117);
            this.lblTamil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamil.Name = "lblTamil";
            this.tblEntry.SetRowSpan(this.lblTamil, 2);
            this.lblTamil.Size = new System.Drawing.Size(292, 78);
            this.lblTamil.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(1204, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Enabled = false;
            this.txtItemCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(1504, 83);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(290, 35);
            this.txtItemCode.TabIndex = 41;
            this.txtItemCode.Visible = false;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // lblItemFullName
            // 
            this.lblItemFullName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemFullName.AutoSize = true;
            this.lblItemFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblItemFullName.Location = new System.Drawing.Point(1203, 200);
            this.lblItemFullName.Name = "lblItemFullName";
            this.lblItemFullName.Size = new System.Drawing.Size(193, 28);
            this.lblItemFullName.TabIndex = 18;
            this.lblItemFullName.Text = "Item Full Name";
            this.lblItemFullName.Visible = false;
            // 
            // txtItemFullName
            // 
            this.txtItemFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemFullName.Location = new System.Drawing.Point(1503, 198);
            this.txtItemFullName.Name = "txtItemFullName";
            this.txtItemFullName.Size = new System.Drawing.Size(291, 35);
            this.txtItemFullName.TabIndex = 42;
            this.txtItemFullName.Visible = false;
            this.txtItemFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtItemTamilName
            // 
            this.txtItemTamilName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemTamilName.Location = new System.Drawing.Point(303, 42);
            this.txtItemTamilName.Name = "txtItemTamilName";
            this.txtItemTamilName.Size = new System.Drawing.Size(291, 35);
            this.txtItemTamilName.TabIndex = 3;
            this.txtItemTamilName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtItemTamilName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemTamilName_KeyUp);
            this.txtItemTamilName.Leave += new System.EventHandler(this.txtItemTamilName_Leave);
            // 
            // cboCategory
            // 
            this.cboCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategory.DataSource = this.categoryBindingSource;
            this.cboCategory.DisplayMember = "cat_name";
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(305, 83);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(290, 36);
            this.cboCategory.TabIndex = 4;
            this.cboCategory.ValueMember = "cat_id";
            this.cboCategory.SelectedValueChanged += new System.EventHandler(this.cboCategory_SelectedValueChanged);
            this.cboCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCategory_KeyDown_1);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(standard.classes.category);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cboItemUnit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtItemQuantity, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(303, 120);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 33);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // cboItemUnit
            // 
            this.cboItemUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboItemUnit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboItemUnit.FormattingEnabled = true;
            this.cboItemUnit.Items.AddRange(new object[] {
            "---Select---",
            "Kg",
            "G"});
            this.cboItemUnit.Location = new System.Drawing.Point(151, 5);
            this.cboItemUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboItemUnit.Name = "cboItemUnit";
            this.cboItemUnit.Size = new System.Drawing.Size(139, 36);
            this.cboItemUnit.TabIndex = 1;
            this.cboItemUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboItemUnit_KeyDown_1);
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemQuantity.Location = new System.Drawing.Point(3, 3);
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(141, 35);
            this.txtItemQuantity.TabIndex = 0;
            this.txtItemQuantity.TextChanged += new System.EventHandler(this.txtItemQuantity_TextChanged);
            this.txtItemQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemQuantity_KeyPress);
            this.txtItemQuantity.Leave += new System.EventHandler(this.txtItemQuantity_Leave);
            // 
            // chkIsUnitPerRate
            // 
            this.chkIsUnitPerRate.AutoSize = true;
            this.chkIsUnitPerRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.chkIsUnitPerRate.Location = new System.Drawing.Point(303, 159);
            this.chkIsUnitPerRate.Name = "chkIsUnitPerRate";
            this.chkIsUnitPerRate.Size = new System.Drawing.Size(225, 32);
            this.chkIsUnitPerRate.TabIndex = 7;
            this.chkIsUnitPerRate.Text = "Is Unit Per Rate";
            this.chkIsUnitPerRate.UseVisualStyleBackColor = true;
            this.chkIsUnitPerRate.CheckedChanged += new System.EventHandler(this.chkIsUnitPerRate_CheckedChanged);
            this.chkIsUnitPerRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkIsUnitPerRate_KeyDown);
            // 
            // txtUnitPerRate
            // 
            this.txtUnitPerRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitPerRate.Enabled = false;
            this.txtUnitPerRate.Location = new System.Drawing.Point(303, 198);
            this.txtUnitPerRate.Name = "txtUnitPerRate";
            this.txtUnitPerRate.Size = new System.Drawing.Size(291, 35);
            this.txtUnitPerRate.TabIndex = 8;
            this.txtUnitPerRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtUnitPerRate.Leave += new System.EventHandler(this.txtItemQuantity_Leave);
            // 
            // lblUnitPerRate
            // 
            this.lblUnitPerRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnitPerRate.AutoSize = true;
            this.lblUnitPerRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblUnitPerRate.Location = new System.Drawing.Point(3, 200);
            this.lblUnitPerRate.Name = "lblUnitPerRate";
            this.lblUnitPerRate.Size = new System.Drawing.Size(169, 28);
            this.lblUnitPerRate.TabIndex = 21;
            this.lblUnitPerRate.Text = "Per Unit Rate";
            // 
            // lbItemUnitType
            // 
            this.lbItemUnitType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbItemUnitType.AutoSize = true;
            this.lbItemUnitType.BackColor = System.Drawing.Color.Transparent;
            this.lbItemUnitType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemUnitType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbItemUnitType.Location = new System.Drawing.Point(4, 240);
            this.lbItemUnitType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbItemUnitType.Name = "lbItemUnitType";
            this.lbItemUnitType.Size = new System.Drawing.Size(187, 28);
            this.lbItemUnitType.TabIndex = 33;
            this.lbItemUnitType.Text = "Item Unit Type";
            this.lbItemUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboItemUnitType
            // 
            this.cboItemUnitType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemUnitType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemUnitType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboItemUnitType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboItemUnitType.FormattingEnabled = true;
            this.cboItemUnitType.Items.AddRange(new object[] {
            "---Select---",
            "Bags"});
            this.cboItemUnitType.Location = new System.Drawing.Point(304, 239);
            this.cboItemUnitType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboItemUnitType.Name = "cboItemUnitType";
            this.cboItemUnitType.Size = new System.Drawing.Size(289, 36);
            this.cboItemUnitType.TabIndex = 9;
            this.cboItemUnitType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCompany.AutoSize = true;
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCompany.Location = new System.Drawing.Point(603, 5);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(119, 28);
            this.lblCompany.TabIndex = 22;
            this.lblCompany.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.DataSource = this.companyBindingSource;
            this.cboCompany.DisplayMember = "com_name";
            this.cboCompany.Enabled = false;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(903, 3);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(291, 36);
            this.cboCompany.TabIndex = 10;
            this.cboCompany.ValueMember = "com_id";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(standard.classes.company);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label9.Location = new System.Drawing.Point(604, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(275, 28);
            this.label9.TabIndex = 16;
            this.label9.Text = "Super Special Rate (A)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSuperSplRate
            // 
            this.txtSuperSplRate.BackColor = System.Drawing.Color.White;
            this.txtSuperSplRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuperSplRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperSplRate.Location = new System.Drawing.Point(904, 44);
            this.txtSuperSplRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSuperSplRate.MaxLength = 50;
            this.txtSuperSplRate.Name = "txtSuperSplRate";
            this.txtSuperSplRate.Size = new System.Drawing.Size(290, 35);
            this.txtSuperSplRate.TabIndex = 11;
            this.txtSuperSplRate.Text = "0";
            this.txtSuperSplRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtSpecialRate
            // 
            this.txtSpecialRate.BackColor = System.Drawing.Color.White;
            this.txtSpecialRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialRate.Location = new System.Drawing.Point(904, 83);
            this.txtSpecialRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSpecialRate.MaxLength = 50;
            this.txtSpecialRate.Name = "txtSpecialRate";
            this.txtSpecialRate.Size = new System.Drawing.Size(290, 35);
            this.txtSpecialRate.TabIndex = 12;
            this.txtSpecialRate.Text = "0";
            this.txtSpecialRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtWholeSaleRate
            // 
            this.txtWholeSaleRate.BackColor = System.Drawing.Color.White;
            this.txtWholeSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWholeSaleRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWholeSaleRate.Location = new System.Drawing.Point(904, 122);
            this.txtWholeSaleRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWholeSaleRate.MaxLength = 50;
            this.txtWholeSaleRate.Name = "txtWholeSaleRate";
            this.txtWholeSaleRate.Size = new System.Drawing.Size(290, 35);
            this.txtWholeSaleRate.TabIndex = 13;
            this.txtWholeSaleRate.Text = "0";
            this.txtWholeSaleRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtMRP
            // 
            this.txtMRP.BackColor = System.Drawing.Color.White;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRP.Location = new System.Drawing.Point(904, 161);
            this.txtMRP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMRP.MaxLength = 50;
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(290, 35);
            this.txtMRP.TabIndex = 14;
            this.txtMRP.Text = "0";
            this.txtMRP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtPRate
            // 
            this.txtPRate.BackColor = System.Drawing.Color.White;
            this.txtPRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRate.Location = new System.Drawing.Point(904, 200);
            this.txtPRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPRate.MaxLength = 50;
            this.txtPRate.Name = "txtPRate";
            this.txtPRate.Size = new System.Drawing.Size(290, 35);
            this.txtPRate.TabIndex = 15;
            this.txtPRate.Text = "0";
            this.txtPRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label8.Location = new System.Drawing.Point(604, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 28);
            this.label8.TabIndex = 14;
            this.label8.Text = "Special Rate (B)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label7.Location = new System.Drawing.Point(604, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 28);
            this.label7.TabIndex = 12;
            this.label7.Text = "Whole Sale Rate (C)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(604, 161);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "MRP (D)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(604, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Purchase Rate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTaxPercentage
            // 
            this.lblTaxPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTaxPercentage.AutoSize = true;
            this.lblTaxPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblTaxPercentage.Location = new System.Drawing.Point(603, 240);
            this.lblTaxPercentage.Name = "lblTaxPercentage";
            this.lblTaxPercentage.Size = new System.Drawing.Size(89, 28);
            this.lblTaxPercentage.TabIndex = 24;
            this.lblTaxPercentage.Text = "Tax %";
            // 
            // txtTaxPercentage
            // 
            this.txtTaxPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaxPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxPercentage.Location = new System.Drawing.Point(903, 237);
            this.txtTaxPercentage.Name = "txtTaxPercentage";
            this.txtTaxPercentage.Size = new System.Drawing.Size(291, 35);
            this.txtTaxPercentage.TabIndex = 16;
            this.txtTaxPercentage.Text = "0";
            this.txtTaxPercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label12.Location = new System.Drawing.Point(1204, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 28);
            this.label12.TabIndex = 17;
            this.label12.Text = "Serial Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.Color.White;
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerial.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(1504, 5);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSerial.MaxLength = 50;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(290, 35);
            this.txtSerial.TabIndex = 17;
            this.txtSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerial_KeyDown);
            this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // lblItemTamilName
            // 
            this.lblItemTamilName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemTamilName.AutoSize = true;
            this.lblItemTamilName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblItemTamilName.Location = new System.Drawing.Point(3, 44);
            this.lblItemTamilName.Name = "lblItemTamilName";
            this.lblItemTamilName.Size = new System.Drawing.Size(215, 28);
            this.lblItemTamilName.TabIndex = 20;
            this.lblItemTamilName.Text = "Item Tamil Name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tblCommand.Location = new System.Drawing.Point(5, 703);
            this.tblCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblCommand.Name = "tblCommand";
            this.tblCommand.RowCount = 1;
            this.tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.Size = new System.Drawing.Size(1914, 59);
            this.tblCommand.TabIndex = 3;
            // 
            // cmdclose
            // 
            this.cmdclose.AutoSize = true;
            this.cmdclose.BackColor = System.Drawing.Color.Transparent;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1768, 5);
            this.cmdclose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(135, 49);
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
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClear.Location = new System.Drawing.Point(1618, 5);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 49);
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
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnDelete.Location = new System.Drawing.Point(1468, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 49);
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
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSave.Location = new System.Drawing.Point(1318, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 49);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // uspcategorySelectResultBindingSource
            // 
            this.uspcategorySelectResultBindingSource.DataSource = typeof(standard.classes.usp_categorySelectResult);
            // 
            // uspitemSelectResultBindingSource
            // 
            this.uspitemSelectResultBindingSource.DataSource = typeof(standard.classes.usp_itemSelectResult);
            // 
            // uspitemSelectResultBindingSource1
            // 
            this.uspitemSelectResultBindingSource1.DataSource = typeof(standard.classes.usp_itemSelectResult);
            // 
            // frmItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1924, 768);
            this.Controls.Add(this.tblMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmItems";
            this.ShowIcon = false;
            this.Text = "ITEMS";
            this.Load += new System.EventHandler(this.frmItems_Load);
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchcategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource2)).EndInit();
            this.tblEntry.ResumeLayout(false);
            this.tblEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            this.tblCommand.ResumeLayout(false);
            this.tblCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uspcategorySelectResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspitemSelectResultBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        private void txtSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }           
        }

        private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();

            long selectedCatId = Convert.ToInt64(cboCategory.SelectedValue);

            // Call the stored procedure with the selected category ID
            var category = inventoryDataContext.usp_categorySelect(selectedCatId, null)
                               .FirstOrDefault(c => c.cat_id == selectedCatId);

            if (category != null)
            {
                // Set the company name from the selected category to cboCompany
                cboCompany.Text = category.com_name;
            }
            txtCostRate.Focus();
        }

        private void txtItemFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtItemTamilName.Focus();
            }
        }

        private void txtItemTamilName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                chkIsUnitPerRate.Focus();
            }
        }

        private void txtItemTamilName_Leave(object sender, EventArgs e)
        {
            txtItemTamilName.Text = lblTamil.Text;
            lblTamil.Text = string.Empty;
        }

        private void cboCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCostRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtSuperSplRate.Focus();
            }
        }

        private void txtSuperSplRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtSpecialRate.Focus();
            }
        }

        private void txtSpecialRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtWholeSaleRate.Focus();
            }
        }

        private void txtWholeSaleRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtMRP.Focus();
            }
        }

        private void txtMRP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtPRate.Focus();
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtSerial.Focus();
            }
        }

        private void txtPRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtTaxPercentage.Focus();
            }
        }

        private void txtSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // or Keys.Return
            {
                btnSave_Click(null, EventArgs.Empty);
            }
        }

        private void txtTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // or Keys.Return
            {
                txtItemCode.Focus();
            }
        }

        private void txtItemTamilName_KeyUp(object sender, KeyEventArgs e)
        {
            lblTamil.Text = tamil.toTamil(txtItemTamilName.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboItemUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtItemQuantity.Focus();
            }
        }

        private void txtItemQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                cboItemUnitType.Focus();
            }
        }

        private void txtItemQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboItemUnitType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                cboCategory.Focus();
            }           
        }

        private void chkIsUnitPerRate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsUnitPerRate.Checked)
            {
                txtUnitPerRate.Enabled = true;
                txtUnitPerRate.Focus();                
            }
            else
            {
                txtUnitPerRate.Enabled = false;
                txtUnitPerRate.ResetText();
                txtSuperSplRate.Enabled = true;
                cboItemUnit.Focus();
            }
        }

        private void txtUnitPerRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                cboItemUnit.Focus();
            }
        }

        private void txtItemQuantity_TextChanged(object sender, EventArgs e)
        {
            if (chkIsUnitPerRate.Checked && txtUnitPerRate.Text!= "")
            {
                decimal rate = Convert.ToDecimal(txtUnitPerRate.Text);
                decimal qty = Convert.ToDecimal(txtItemQuantity.Text);
                txtSuperSplRate.Text = (rate * qty).ToString("N2");
            }
        }

        private void txtItemQuantity_Leave(object sender, EventArgs e)
        {
            calculateRates();
        }
        private  void calculateRates()
        {
            try
            {
                if (chkIsUnitPerRate.Checked)
                {
                    decimal rate = Convert.ToDecimal(txtUnitPerRate.Text);
                    decimal qty = Convert.ToDecimal(txtItemQuantity.Text);
                    txtSuperSplRate.Text = (rate * qty).ToString("N2");
                    rate = (rate + Convert.ToDecimal(0.50));
                    txtSpecialRate.Text = ((rate) * qty).ToString("N2");
                    rate = (rate + Convert.ToDecimal(0.50));
                    txtWholeSaleRate.Text = (rate * qty).ToString("N2");
                    rate = (rate + Convert.ToDecimal(0.50));
                    txtMRP.Text = (rate * qty).ToString("N2");
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void chkIsUnitPerRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtUnitPerRate.Focus();
            }
        }

        private void cboCategory_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtItemQuantity.Focus();
            }
        }

        private void cboItemUnit_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                chkIsUnitPerRate.Focus();
            }
        }
    }
}
