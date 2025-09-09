using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
        private Label lbItemUnitType;
        private ComboBox cboItemUnitType;
        private TextBox txtUnitPerRateA;
        private Label lblSalesPerRate;
        private CheckBox chkIsUnitPerRate;
        private BindingSource companyBindingSource;
        private TextBox txtCostRate;
        private Label label2;
        private TextBox txtItemCode;
        private TableLayoutPanel tableLayoutPanel1;
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
        private Button btnExport;
        private Button btnImport;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblPurUnitRate;
        private TextBox txtPurUnitRate;
        private Label label15;
        private Label label14;
        private TextBox txtSGST;
        private Label label5;
        private TextBox txtHSNCode;
        private TextBox txtCGST;
        private ProgressBar progressBar1;
        private Label lblProgress;
        private CheckBox chkTaxable;
        private Label label17;
        private TextBox txtUnitPerRateB;
        private TextBox txtUnitPerRateC;
        private Label label16;
        private TextBox txtTallyName;
        private Label label18;
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
            txtTallyName.Text = string.Empty;
            txtItemTamilName.Text = string.Empty;
            txtTaxPercentage.Text = "0";
            chkIsUnitPerRate.Checked = false;
            chkTaxable.Checked = false;
            txtUnitPerRateA.Text = "0";
            txtUnitPerRateB.Text = "0";
            txtUnitPerRateC.Text = "0";
            txtPurUnitRate.Text = "0";
            txtPRate.Text = "0";
            // txtCostRate.Text = "0";
            txtMRP.Text = "0";
            txtWholeSaleRate.Text = "0";
            txtSpecialRate.Text = "0";
            txtSuperSplRate.Text = "0";
            txtSearch.Text = string.Empty;
            txtHSNCode.Text = string.Empty;
            txtItemQuantity.Text = "0";
            txtSGST.Text = "0";
            txtCGST.Text = "0";
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
            dgview.DataSource = inventoryDataContext.usp_itemSelect(null, null, null, null);
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
                ISingleResult<usp_itemSelectResult> singleResult = inventoryDataContext.usp_itemSelect(id, null, null, null);
                foreach (usp_itemSelectResult item in singleResult)
                {
                    txtItemCode.Text = item.item_code;
                    txtSerial.Text = item.item_serial.ToString();
                    txtItemName.Text = item.item_name;
                    txtTallyName.Text = item.item_fullname;
                    txtItemTamilName.Text = item.item_tamilname;
                    txtTaxPercentage.Text = item.item_taxpercentage.ToString("N2");
                    txtCGST.Text = item.item_cgst.ToString("N2");
                    txtSGST.Text = item.item_sgst.ToString("N2");
                    txtHSNCode.Text = item.item_hsncode;
                    cboCategory.SelectedValue = item.cat_id;
                    chkIsUnitPerRate.Checked = item.item_isunitperrate;
                    chkTaxable.Checked = item.item_istaxable;
                    txtUnitPerRateA.Text = item.item_perunitrate.ToString("N2");
                    txtUnitPerRateB.Text = item.item_perunitrateb.ToString("N2");
                    txtUnitPerRateC.Text = item.item_perunitratec.ToString("N2");
                    txtPurUnitRate.Text = item.item_purunitrate.ToString("N2");
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
                if (id == 0)
                {
                    it.item_serial = GetNextSerialNumber();
                }
                else
                {
                    it.item_serial = Convert.ToInt32(txtSerial.Text.Trim());
                }
                it.item_name = txtItemName.Text.Trim();
                it.item_fullname = txtTallyName.Text.Trim();
                it.item_tamilname = txtItemTamilName.Text.Trim();
                it.item_taxpercentage = Convert.ToDecimal(txtTaxPercentage.Text.Trim());
                it.item_cgst = Convert.ToDecimal(txtCGST.Text.Trim());
                it.item_sgst = Convert.ToDecimal(txtSGST.Text.Trim());
                it.item_hsncode = txtHSNCode.Text.Trim();
                it.cat_id = Convert.ToInt32(cboCategory.SelectedValue);
                it.item_isunitperrate = chkIsUnitPerRate.Checked;
                it.item_istaxable = chkTaxable.Checked;
                decimal perUnitRateA = 0, perUnitRateB = 0, perUnitRateC = 0, purUnitRate = 0;

                decimal.TryParse(txtUnitPerRateA.Text.Trim(), out perUnitRateA);
                decimal.TryParse(txtUnitPerRateB.Text.Trim(), out perUnitRateB);
                decimal.TryParse(txtUnitPerRateC.Text.Trim(), out perUnitRateC);
                decimal.TryParse(txtPurUnitRate.Text.Trim(), out purUnitRate);

                it.item_perunitrate = perUnitRateA;
                it.item_perunitrateb = perUnitRateB;
                it.item_perunitratec = perUnitRateC;
                it.item_purunitrate = purUnitRate;
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
                    //if (source.Count() != 0)
                    //{
                    //    MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //    txtItemName.Focus();
                    //}
                    if (id == 0)
                    {
                        if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                        {
                            inventoryDataContext.usp_itemInsert(it.item_code, it.item_serial, it.item_name, it.item_fullname, it.item_tamilname, it.cat_id, it.item_isunitperrate, it.item_istaxable, it.item_perunitrate, it.item_perunitrateb, it.item_perunitratec, it.item_purunitrate, it.item_unit, it.item_quantity, it.item_unittype, it.item_purchaserate, it.item_costrate, it.item_mrp, it.item_wholesalerate, it.item_specialrate, it.item_supersepecialrate, it.item_taxpercentage, it.item_cgst, it.item_sgst, it.item_hsncode, global.ucode, it.com_id, global.sysdate);
                            MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            goto IL_0602;
                        }
                    }
                    else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        inventoryDataContext.usp_itemUpdate(id, it.item_code, it.item_serial, it.item_name, it.item_fullname, it.item_tamilname, it.cat_id, it.item_isunitperrate, it.item_istaxable, it.item_perunitrate, it.item_perunitrateb, it.item_perunitratec, it.item_purunitrate, it.item_unit, it.item_quantity, it.item_unittype, it.item_purchaserate, it.item_costrate, it.item_mrp, it.item_wholesalerate, it.item_specialrate, it.item_supersepecialrate, it.item_taxpercentage, it.item_cgst, it.item_sgst, it.item_hsncode, global.ucode, it.com_id, global.sysdate);
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
            dgview.DataSource = inventoryDataContext.usp_itemSelect(null, txtSearch.Text, Convert.ToInt32(cboSearchCategory.SelectedValue), txtBatchSearch.Text);
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
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
            this.txtTallyName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemTamilName = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboItemUnit = new System.Windows.Forms.ComboBox();
            this.txtItemQuantity = new System.Windows.Forms.TextBox();
            this.txtUnitPerRateA = new System.Windows.Forms.TextBox();
            this.lblSalesPerRate = new System.Windows.Forms.Label();
            this.lblItemTamilName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblItemUnit = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCompany = new System.Windows.Forms.Label();
            this.cboItemUnitType = new System.Windows.Forms.ComboBox();
            this.lbItemUnitType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblItemFullName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtHSNCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaxPercentage = new System.Windows.Forms.TextBox();
            this.lblTaxPercentage = new System.Windows.Forms.Label();
            this.chkTaxable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSpecialRate = new System.Windows.Forms.TextBox();
            this.txtSuperSplRate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPurUnitRate = new System.Windows.Forms.TextBox();
            this.lblPurUnitRate = new System.Windows.Forms.Label();
            this.chkIsUnitPerRate = new System.Windows.Forms.CheckBox();
            this.txtUnitPerRateB = new System.Windows.Forms.TextBox();
            this.txtUnitPerRateC = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtWholeSaleRate = new System.Windows.Forms.TextBox();
            this.txtPRate = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTamil = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtItemFullName = new System.Windows.Forms.TextBox();
            this.txtCostRate = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel2.SuspendLayout();
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
            this.a1Paneltitle.Location = new System.Drawing.Point(4, 4);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1306, 29);
            this.a1Paneltitle.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(25, 5);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(46, 18);
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
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblMain.Size = new System.Drawing.Size(1314, 618);
            this.tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 8;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Controls.Add(this.lblSearch, 2, 0);
            this.tblSearch.Controls.Add(this.label11, 0, 0);
            this.tblSearch.Controls.Add(this.cboSearchCategory, 1, 0);
            this.tblSearch.Controls.Add(this.label13, 4, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 5, 0);
            this.tblSearch.Controls.Add(this.txtBatchSearch, 3, 0);
            this.tblSearch.Controls.Add(this.tableLayoutPanel2, 6, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(4, 284);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1306, 39);
            this.tblSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSearch.Location = new System.Drawing.Point(360, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(129, 18);
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
            this.label11.Location = new System.Drawing.Point(3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 18);
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
            this.cboSearchCategory.Location = new System.Drawing.Point(167, 3);
            this.cboSearchCategory.Name = "cboSearchCategory";
            this.cboSearchCategory.Size = new System.Drawing.Size(187, 26);
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
            this.label13.Location = new System.Drawing.Point(638, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Search By Item";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(777, 3);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(187, 25);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtBatchSearch
            // 
            this.txtBatchSearch.BackColor = System.Drawing.Color.White;
            this.txtBatchSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchSearch.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSearch.Location = new System.Drawing.Point(497, 3);
            this.txtBatchSearch.MaxLength = 50;
            this.txtBatchSearch.Name = "txtBatchSearch";
            this.txtBatchSearch.Size = new System.Drawing.Size(134, 25);
            this.txtBatchSearch.TabIndex = 1;
            this.txtBatchSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnImport, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnExport, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(969, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(183, 35);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.btnImport.Location = new System.Drawing.Point(109, 2);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 31);
            this.btnImport.TabIndex = 45;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExport.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.btnExport.Location = new System.Drawing.Point(2, 2);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(72, 31);
            this.btnExport.TabIndex = 44;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.dgview.Location = new System.Drawing.Point(4, 330);
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
            this.dgview.Size = new System.Drawing.Size(1306, 237);
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
            this.catnameDataGridViewTextBoxColumn.HeaderText = "Category";
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
            this.itemfullnameDataGridViewTextBoxColumn.Visible = false;
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
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.Controls.Add(this.txtTallyName, 5, 3);
            this.tblEntry.Controls.Add(this.label18, 4, 3);
            this.tblEntry.Controls.Add(this.label17, 0, 7);
            this.tblEntry.Controls.Add(this.txtItemName, 1, 0);
            this.tblEntry.Controls.Add(this.label1, 0, 0);
            this.tblEntry.Controls.Add(this.txtItemTamilName, 1, 1);
            this.tblEntry.Controls.Add(this.cboCategory, 1, 2);
            this.tblEntry.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tblEntry.Controls.Add(this.txtUnitPerRateA, 1, 5);
            this.tblEntry.Controls.Add(this.lblSalesPerRate, 0, 5);
            this.tblEntry.Controls.Add(this.lblItemTamilName, 0, 1);
            this.tblEntry.Controls.Add(this.label3, 0, 2);
            this.tblEntry.Controls.Add(this.lblItemUnit, 0, 3);
            this.tblEntry.Controls.Add(this.cboCompany, 3, 1);
            this.tblEntry.Controls.Add(this.lblCompany, 2, 1);
            this.tblEntry.Controls.Add(this.cboItemUnitType, 3, 0);
            this.tblEntry.Controls.Add(this.lbItemUnitType, 2, 0);
            this.tblEntry.Controls.Add(this.label6, 6, 0);
            this.tblEntry.Controls.Add(this.label2, 6, 1);
            this.tblEntry.Controls.Add(this.lblItemFullName, 6, 2);
            this.tblEntry.Controls.Add(this.label12, 4, 2);
            this.tblEntry.Controls.Add(this.txtSerial, 5, 2);
            this.tblEntry.Controls.Add(this.txtHSNCode, 5, 1);
            this.tblEntry.Controls.Add(this.label5, 4, 1);
            this.tblEntry.Controls.Add(this.txtTaxPercentage, 5, 0);
            this.tblEntry.Controls.Add(this.lblTaxPercentage, 4, 0);
            this.tblEntry.Controls.Add(this.chkTaxable, 3, 2);
            this.tblEntry.Controls.Add(this.label7, 2, 7);
            this.tblEntry.Controls.Add(this.txtSpecialRate, 3, 6);
            this.tblEntry.Controls.Add(this.txtSuperSplRate, 3, 5);
            this.tblEntry.Controls.Add(this.label8, 2, 6);
            this.tblEntry.Controls.Add(this.label9, 2, 5);
            this.tblEntry.Controls.Add(this.label4, 2, 4);
            this.tblEntry.Controls.Add(this.txtPurUnitRate, 3, 3);
            this.tblEntry.Controls.Add(this.lblPurUnitRate, 2, 3);
            this.tblEntry.Controls.Add(this.chkIsUnitPerRate, 1, 4);
            this.tblEntry.Controls.Add(this.txtUnitPerRateB, 1, 6);
            this.tblEntry.Controls.Add(this.txtUnitPerRateC, 1, 7);
            this.tblEntry.Controls.Add(this.label16, 0, 6);
            this.tblEntry.Controls.Add(this.txtWholeSaleRate, 3, 7);
            this.tblEntry.Controls.Add(this.txtPRate, 3, 4);
            this.tblEntry.Controls.Add(this.progressBar1, 5, 7);
            this.tblEntry.Controls.Add(this.lblTamil, 4, 5);
            this.tblEntry.Controls.Add(this.lblProgress, 4, 7);
            this.tblEntry.Controls.Add(this.txtSGST, 5, 6);
            this.tblEntry.Controls.Add(this.label15, 5, 5);
            this.tblEntry.Controls.Add(this.txtCGST, 5, 4);
            this.tblEntry.Controls.Add(this.label14, 4, 4);
            this.tblEntry.Controls.Add(this.txtMRP, 6, 7);
            this.tblEntry.Controls.Add(this.txtItemFullName, 6, 6);
            this.tblEntry.Controls.Add(this.txtCostRate, 6, 5);
            this.tblEntry.Controls.Add(this.txtItemCode, 6, 4);
            this.tblEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEntry.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblEntry.Location = new System.Drawing.Point(4, 40);
            this.tblEntry.Name = "tblEntry";
            this.tblEntry.RowCount = 8;
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50167F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.tblEntry.Size = new System.Drawing.Size(1306, 237);
            this.tblEntry.TabIndex = 2;
            // 
            // txtTallyName
            // 
            this.txtTallyName.BackColor = System.Drawing.Color.White;
            this.txtTallyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTallyName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTallyName.Location = new System.Drawing.Point(1003, 90);
            this.txtTallyName.MaxLength = 50;
            this.txtTallyName.Name = "txtTallyName";
            this.txtTallyName.Size = new System.Drawing.Size(194, 26);
            this.txtTallyName.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label18.Location = new System.Drawing.Point(803, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 18);
            this.label18.TabIndex = 4;
            this.label18.Text = "Tally Item Name";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label17.Location = new System.Drawing.Point(2, 203);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(151, 18);
            this.label17.TabIndex = 56;
            this.label17.Text = "Sales Unit Rate (C)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.White;
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(203, 3);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(194, 26);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItemTamilName
            // 
            this.txtItemTamilName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemTamilName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtItemTamilName.Location = new System.Drawing.Point(202, 31);
            this.txtItemTamilName.Margin = new System.Windows.Forms.Padding(2);
            this.txtItemTamilName.Name = "txtItemTamilName";
            this.txtItemTamilName.Size = new System.Drawing.Size(196, 26);
            this.txtItemTamilName.TabIndex = 3;
            this.txtItemTamilName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtItemTamilName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemTamilName_KeyUp);
            this.txtItemTamilName.Leave += new System.EventHandler(this.txtItemTamilName_Leave);
            // 
            // cboCategory
            // 
            this.cboCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCategory.DataSource = this.categoryBindingSource;
            this.cboCategory.DisplayMember = "cat_name";
            this.cboCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboCategory.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(203, 61);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(194, 26);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(202, 89);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 25);
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
            this.cboItemUnit.Location = new System.Drawing.Point(101, 3);
            this.cboItemUnit.Name = "cboItemUnit";
            this.cboItemUnit.Size = new System.Drawing.Size(92, 26);
            this.cboItemUnit.TabIndex = 1;
            this.cboItemUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboItemUnit_KeyDown_1);
            // 
            // txtItemQuantity
            // 
            this.txtItemQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemQuantity.Location = new System.Drawing.Point(2, 2);
            this.txtItemQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtItemQuantity.Name = "txtItemQuantity";
            this.txtItemQuantity.Size = new System.Drawing.Size(94, 26);
            this.txtItemQuantity.TabIndex = 0;
            this.txtItemQuantity.TextChanged += new System.EventHandler(this.txtItemQuantity_TextChanged);
            this.txtItemQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtItemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemQuantity_KeyPress);
            this.txtItemQuantity.Leave += new System.EventHandler(this.txtItemQuantity_Leave);
            // 
            // txtUnitPerRateA
            // 
            this.txtUnitPerRateA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitPerRateA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitPerRateA.Enabled = false;
            this.txtUnitPerRateA.Location = new System.Drawing.Point(202, 147);
            this.txtUnitPerRateA.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPerRateA.Name = "txtUnitPerRateA";
            this.txtUnitPerRateA.Size = new System.Drawing.Size(196, 26);
            this.txtUnitPerRateA.TabIndex = 8;
            this.txtUnitPerRateA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtUnitPerRateA.Leave += new System.EventHandler(this.txtItemQuantity_Leave);
            // 
            // lblSalesPerRate
            // 
            this.lblSalesPerRate.AutoSize = true;
            this.lblSalesPerRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSalesPerRate.Location = new System.Drawing.Point(2, 145);
            this.lblSalesPerRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalesPerRate.Name = "lblSalesPerRate";
            this.lblSalesPerRate.Size = new System.Drawing.Size(151, 18);
            this.lblSalesPerRate.TabIndex = 21;
            this.lblSalesPerRate.Text = "Sales Unit Rate (A)";
            this.lblSalesPerRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemTamilName
            // 
            this.lblItemTamilName.AutoSize = true;
            this.lblItemTamilName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblItemTamilName.Location = new System.Drawing.Point(2, 29);
            this.lblItemTamilName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItemTamilName.Name = "lblItemTamilName";
            this.lblItemTamilName.Size = new System.Drawing.Size(135, 18);
            this.lblItemTamilName.TabIndex = 20;
            this.lblItemTamilName.Text = "Item Tamil Name";
            this.lblItemTamilName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemUnit
            // 
            this.lblItemUnit.AutoSize = true;
            this.lblItemUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblItemUnit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblItemUnit.Location = new System.Drawing.Point(3, 87);
            this.lblItemUnit.Name = "lblItemUnit";
            this.lblItemUnit.Size = new System.Drawing.Size(39, 18);
            this.lblItemUnit.TabIndex = 28;
            this.lblItemUnit.Text = "Unit";
            this.lblItemUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCompany
            // 
            this.cboCompany.DataSource = this.companyBindingSource;
            this.cboCompany.DisplayMember = "com_name";
            this.cboCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCompany.Enabled = false;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(602, 31);
            this.cboCompany.Margin = new System.Windows.Forms.Padding(2);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(196, 26);
            this.cboCompany.TabIndex = 12;
            this.cboCompany.ValueMember = "com_id";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(standard.classes.company);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCompany.Location = new System.Drawing.Point(402, 29);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(76, 18);
            this.lblCompany.TabIndex = 22;
            this.lblCompany.Text = "Company";
            // 
            // cboItemUnitType
            // 
            this.cboItemUnitType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboItemUnitType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboItemUnitType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboItemUnitType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboItemUnitType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboItemUnitType.FormattingEnabled = true;
            this.cboItemUnitType.Items.AddRange(new object[] {
            "---Select---",
            "Bags"});
            this.cboItemUnitType.Location = new System.Drawing.Point(603, 3);
            this.cboItemUnitType.Name = "cboItemUnitType";
            this.cboItemUnitType.Size = new System.Drawing.Size(194, 26);
            this.cboItemUnitType.TabIndex = 11;
            this.cboItemUnitType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // lbItemUnitType
            // 
            this.lbItemUnitType.AutoSize = true;
            this.lbItemUnitType.BackColor = System.Drawing.Color.Transparent;
            this.lbItemUnitType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemUnitType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbItemUnitType.Location = new System.Drawing.Point(403, 0);
            this.lbItemUnitType.Name = "lbItemUnitType";
            this.lbItemUnitType.Size = new System.Drawing.Size(118, 18);
            this.lbItemUnitType.TabIndex = 33;
            this.lbItemUnitType.Text = "Item Unit Type";
            this.lbItemUnitType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(1203, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "MRP (D)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(1203, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // lblItemFullName
            // 
            this.lblItemFullName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemFullName.AutoSize = true;
            this.lblItemFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblItemFullName.Location = new System.Drawing.Point(1202, 58);
            this.lblItemFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItemFullName.Name = "lblItemFullName";
            this.lblItemFullName.Size = new System.Drawing.Size(79, 29);
            this.lblItemFullName.TabIndex = 18;
            this.lblItemFullName.Text = "Item Full Name";
            this.lblItemFullName.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label12.Location = new System.Drawing.Point(803, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 17;
            this.label12.Text = "Serial Code";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.Color.White;
            this.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerial.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(1003, 61);
            this.txtSerial.MaxLength = 50;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(194, 26);
            this.txtSerial.TabIndex = 21;
            this.txtSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerial_KeyDown);
            this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.BackColor = System.Drawing.Color.White;
            this.txtHSNCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHSNCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSNCode.Location = new System.Drawing.Point(1003, 32);
            this.txtHSNCode.MaxLength = 50;
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.Size = new System.Drawing.Size(194, 26);
            this.txtHSNCode.TabIndex = 20;
            this.txtHSNCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(803, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "HSN/SAC Code";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTaxPercentage
            // 
            this.txtTaxPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaxPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxPercentage.Location = new System.Drawing.Point(1002, 2);
            this.txtTaxPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaxPercentage.Name = "txtTaxPercentage";
            this.txtTaxPercentage.Size = new System.Drawing.Size(195, 26);
            this.txtTaxPercentage.TabIndex = 19;
            this.txtTaxPercentage.Text = "0";
            this.txtTaxPercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtTaxPercentage.Leave += new System.EventHandler(this.txtTaxPercentage_Leave);
            // 
            // lblTaxPercentage
            // 
            this.lblTaxPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTaxPercentage.AutoSize = true;
            this.lblTaxPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblTaxPercentage.Location = new System.Drawing.Point(802, 5);
            this.lblTaxPercentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTaxPercentage.Name = "lblTaxPercentage";
            this.lblTaxPercentage.Size = new System.Drawing.Size(57, 18);
            this.lblTaxPercentage.TabIndex = 24;
            this.lblTaxPercentage.Text = "Tax %";
            // 
            // chkTaxable
            // 
            this.chkTaxable.AutoSize = true;
            this.chkTaxable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.chkTaxable.Location = new System.Drawing.Point(602, 60);
            this.chkTaxable.Margin = new System.Windows.Forms.Padding(2);
            this.chkTaxable.Name = "chkTaxable";
            this.chkTaxable.Size = new System.Drawing.Size(105, 22);
            this.chkTaxable.TabIndex = 13;
            this.chkTaxable.Text = "Is Taxable";
            this.chkTaxable.UseVisualStyleBackColor = true;
            this.chkTaxable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTaxable_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label7.Location = new System.Drawing.Point(403, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Whole Sale Rate (C)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSpecialRate
            // 
            this.txtSpecialRate.BackColor = System.Drawing.Color.White;
            this.txtSpecialRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpecialRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecialRate.Location = new System.Drawing.Point(603, 177);
            this.txtSpecialRate.MaxLength = 50;
            this.txtSpecialRate.Name = "txtSpecialRate";
            this.txtSpecialRate.Size = new System.Drawing.Size(194, 26);
            this.txtSpecialRate.TabIndex = 17;
            this.txtSpecialRate.Text = "0";
            this.txtSpecialRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtSuperSplRate
            // 
            this.txtSuperSplRate.BackColor = System.Drawing.Color.White;
            this.txtSuperSplRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuperSplRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSuperSplRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperSplRate.Location = new System.Drawing.Point(603, 148);
            this.txtSuperSplRate.MaxLength = 50;
            this.txtSuperSplRate.Name = "txtSuperSplRate";
            this.txtSuperSplRate.Size = new System.Drawing.Size(194, 26);
            this.txtSuperSplRate.TabIndex = 16;
            this.txtSuperSplRate.Text = "0";
            this.txtSuperSplRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label8.Location = new System.Drawing.Point(403, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Special Rate (B)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label9.Location = new System.Drawing.Point(403, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Super Special Rate (A)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(403, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Purchase Rate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPurUnitRate
            // 
            this.txtPurUnitRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurUnitRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPurUnitRate.Enabled = false;
            this.txtPurUnitRate.Location = new System.Drawing.Point(602, 89);
            this.txtPurUnitRate.Margin = new System.Windows.Forms.Padding(2);
            this.txtPurUnitRate.Name = "txtPurUnitRate";
            this.txtPurUnitRate.Size = new System.Drawing.Size(196, 26);
            this.txtPurUnitRate.TabIndex = 14;
            this.txtPurUnitRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurUnitRate_KeyDown);
            this.txtPurUnitRate.Leave += new System.EventHandler(this.txtPurUnitRate_Leave);
            // 
            // lblPurUnitRate
            // 
            this.lblPurUnitRate.AutoSize = true;
            this.lblPurUnitRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblPurUnitRate.Location = new System.Drawing.Point(402, 87);
            this.lblPurUnitRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPurUnitRate.Name = "lblPurUnitRate";
            this.lblPurUnitRate.Size = new System.Drawing.Size(151, 18);
            this.lblPurUnitRate.TabIndex = 22;
            this.lblPurUnitRate.Text = "Purchase Unit Rate";
            // 
            // chkIsUnitPerRate
            // 
            this.chkIsUnitPerRate.AutoSize = true;
            this.chkIsUnitPerRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.chkIsUnitPerRate.Location = new System.Drawing.Point(202, 118);
            this.chkIsUnitPerRate.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsUnitPerRate.Name = "chkIsUnitPerRate";
            this.chkIsUnitPerRate.Size = new System.Drawing.Size(146, 22);
            this.chkIsUnitPerRate.TabIndex = 7;
            this.chkIsUnitPerRate.Text = "Is Unit Per Rate";
            this.chkIsUnitPerRate.UseVisualStyleBackColor = true;
            this.chkIsUnitPerRate.CheckedChanged += new System.EventHandler(this.chkIsUnitPerRate_CheckedChanged);
            this.chkIsUnitPerRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkIsUnitPerRate_KeyDown);
            // 
            // txtUnitPerRateB
            // 
            this.txtUnitPerRateB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitPerRateB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitPerRateB.Enabled = false;
            this.txtUnitPerRateB.Location = new System.Drawing.Point(202, 176);
            this.txtUnitPerRateB.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPerRateB.Name = "txtUnitPerRateB";
            this.txtUnitPerRateB.Size = new System.Drawing.Size(196, 26);
            this.txtUnitPerRateB.TabIndex = 9;
            this.txtUnitPerRateB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtUnitPerRateB.Leave += new System.EventHandler(this.txtItemQuantity_Leave);
            // 
            // txtUnitPerRateC
            // 
            this.txtUnitPerRateC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitPerRateC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitPerRateC.Enabled = false;
            this.txtUnitPerRateC.Location = new System.Drawing.Point(202, 205);
            this.txtUnitPerRateC.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnitPerRateC.Name = "txtUnitPerRateC";
            this.txtUnitPerRateC.Size = new System.Drawing.Size(196, 26);
            this.txtUnitPerRateC.TabIndex = 10;
            this.txtUnitPerRateC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtUnitPerRateC.Leave += new System.EventHandler(this.txtItemQuantity_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label16.Location = new System.Drawing.Point(2, 174);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 18);
            this.label16.TabIndex = 55;
            this.label16.Text = "Sales Unit Rate (B)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWholeSaleRate
            // 
            this.txtWholeSaleRate.BackColor = System.Drawing.Color.White;
            this.txtWholeSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWholeSaleRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWholeSaleRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWholeSaleRate.Location = new System.Drawing.Point(603, 206);
            this.txtWholeSaleRate.MaxLength = 50;
            this.txtWholeSaleRate.Name = "txtWholeSaleRate";
            this.txtWholeSaleRate.Size = new System.Drawing.Size(194, 26);
            this.txtWholeSaleRate.TabIndex = 18;
            this.txtWholeSaleRate.Text = "0";
            this.txtWholeSaleRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtPRate
            // 
            this.txtPRate.BackColor = System.Drawing.Color.White;
            this.txtPRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRate.Location = new System.Drawing.Point(603, 119);
            this.txtPRate.MaxLength = 50;
            this.txtPRate.Name = "txtPRate";
            this.txtPRate.Size = new System.Drawing.Size(194, 26);
            this.txtPRate.TabIndex = 15;
            this.txtPRate.Text = "0";
            this.txtPRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1002, 205);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(131, 18);
            this.progressBar1.TabIndex = 51;
            this.progressBar1.Visible = false;
            // 
            // lblTamil
            // 
            this.lblTamil.BackColor = System.Drawing.Color.White;
            this.lblTamil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTamil.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTamil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblTamil.Location = new System.Drawing.Point(803, 145);
            this.lblTamil.Name = "lblTamil";
            this.tblEntry.SetRowSpan(this.lblTamil, 2);
            this.lblTamil.Size = new System.Drawing.Size(194, 44);
            this.lblTamil.TabIndex = 27;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblProgress.Location = new System.Drawing.Point(986, 203);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(12, 34);
            this.lblProgress.TabIndex = 52;
            this.lblProgress.Text = " ";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSGST
            // 
            this.txtSGST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSGST.Location = new System.Drawing.Point(1002, 176);
            this.txtSGST.Margin = new System.Windows.Forms.Padding(2);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(195, 26);
            this.txtSGST.TabIndex = 37;
            this.txtSGST.Text = "0";
            this.txtSGST.Visible = false;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label15.Location = new System.Drawing.Point(1003, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 18);
            this.label15.TabIndex = 18;
            this.label15.Text = "SGST";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Visible = false;
            // 
            // txtCGST
            // 
            this.txtCGST.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCGST.Location = new System.Drawing.Point(1002, 118);
            this.txtCGST.Margin = new System.Windows.Forms.Padding(2);
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(195, 26);
            this.txtCGST.TabIndex = 37;
            this.txtCGST.Text = "0";
            this.txtCGST.Visible = false;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label14.Location = new System.Drawing.Point(803, 121);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 18);
            this.label14.TabIndex = 18;
            this.label14.Text = "CGST";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Visible = false;
            // 
            // txtMRP
            // 
            this.txtMRP.BackColor = System.Drawing.Color.White;
            this.txtMRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRP.Location = new System.Drawing.Point(1203, 206);
            this.txtMRP.MaxLength = 50;
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(69, 26);
            this.txtMRP.TabIndex = 50;
            this.txtMRP.Text = "0";
            this.txtMRP.Visible = false;
            this.txtMRP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtItemFullName
            // 
            this.txtItemFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemFullName.Location = new System.Drawing.Point(1202, 176);
            this.txtItemFullName.Margin = new System.Windows.Forms.Padding(2);
            this.txtItemFullName.Name = "txtItemFullName";
            this.txtItemFullName.Size = new System.Drawing.Size(71, 26);
            this.txtItemFullName.TabIndex = 42;
            this.txtItemFullName.Visible = false;
            this.txtItemFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtCostRate
            // 
            this.txtCostRate.BackColor = System.Drawing.Color.White;
            this.txtCostRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostRate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostRate.Location = new System.Drawing.Point(1203, 148);
            this.txtCostRate.MaxLength = 50;
            this.txtCostRate.Name = "txtCostRate";
            this.txtCostRate.Size = new System.Drawing.Size(69, 26);
            this.txtCostRate.TabIndex = 41;
            this.txtCostRate.Text = "0";
            this.txtCostRate.Visible = false;
            this.txtCostRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            // 
            // txtItemCode
            // 
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemCode.Enabled = false;
            this.txtItemCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(1203, 119);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(69, 26);
            this.txtItemCode.TabIndex = 41;
            this.txtItemCode.Visible = false;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputControl_KeyDown);
            this.txtItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerial_KeyPress);
            // 
            // tblCommand
            // 
            this.tblCommand.ColumnCount = 5;
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblCommand.Controls.Add(this.cmdclose, 4, 0);
            this.tblCommand.Controls.Add(this.btnClear, 3, 0);
            this.tblCommand.Controls.Add(this.btnDelete, 2, 0);
            this.tblCommand.Controls.Add(this.btnSave, 1, 0);
            this.tblCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCommand.Location = new System.Drawing.Point(4, 574);
            this.tblCommand.Name = "tblCommand";
            this.tblCommand.RowCount = 1;
            this.tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.Size = new System.Drawing.Size(1306, 40);
            this.tblCommand.TabIndex = 3;
            // 
            // cmdclose
            // 
            this.cmdclose.AutoSize = true;
            this.cmdclose.BackColor = System.Drawing.Color.Transparent;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1209, 3);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(90, 32);
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
            this.btnClear.Location = new System.Drawing.Point(1109, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 32);
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
            this.btnDelete.Location = new System.Drawing.Point(1009, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 32);
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
            this.btnSave.Location = new System.Drawing.Point(909, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1314, 618);
            this.Controls.Add(this.tblMain);
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
            this.tableLayoutPanel2.ResumeLayout(false);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
                txtUnitPerRateA.Enabled = true;
                txtUnitPerRateB.Enabled = true;
                txtUnitPerRateC.Enabled = true;
                txtPurUnitRate.Enabled = true;
                txtSuperSplRate.Enabled = false;
                txtSpecialRate.Enabled = false;
                txtWholeSaleRate.Enabled = false;
                txtPRate.Enabled = false;
                txtUnitPerRateA.Focus();
            }
            else
            {
                txtUnitPerRateA.Enabled = false;
                txtUnitPerRateA.ResetText();
                txtUnitPerRateB.Enabled = false;
                txtUnitPerRateB.ResetText();
                txtUnitPerRateC.Enabled = false;
                txtUnitPerRateC.ResetText();
                txtPurUnitRate.Enabled = false;
                txtPurUnitRate.ResetText();
                txtSuperSplRate.Enabled = true;
                txtSpecialRate.Enabled = true;
                txtWholeSaleRate.Enabled = true;
                txtPRate.Enabled = true;
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
            if (!chkIsUnitPerRate.Checked)
                return;

            decimal qty = 0, purRate = 0;

            decimal.TryParse(txtItemQuantity.Text, out qty);
            decimal.TryParse(txtPurUnitRate.Text, out purRate);
            txtPRate.Text = (purRate * qty).ToString("N2");

            if (!string.IsNullOrWhiteSpace(txtUnitPerRateA.Text))
            {
                decimal rateA = 0;
                decimal.TryParse(txtUnitPerRateA.Text, out rateA);
                txtSuperSplRate.Text = (rateA * qty).ToString("N2");
            }
            else
            {
                txtSuperSplRate.Text = "0.00";
            }

            if (!string.IsNullOrWhiteSpace(txtUnitPerRateB.Text))
            {
                decimal rateB = 0;
                decimal.TryParse(txtUnitPerRateB.Text, out rateB);
                txtSpecialRate.Text = (rateB * qty).ToString("N2");
            }
            else
            {
                txtSpecialRate.Text = "0.00";
            }

            if (!string.IsNullOrWhiteSpace(txtUnitPerRateC.Text))
            {
                decimal rateC = 0;
                decimal.TryParse(txtUnitPerRateC.Text, out rateC);
                txtWholeSaleRate.Text = (rateC * qty).ToString("N2");
            }
            else
            {
                txtWholeSaleRate.Text = "0.00";
            }
        }


        private void txtItemQuantity_Leave(object sender, EventArgs e)
        {
            calculateRates();
        }

        private void txtPurUnitRate_Leave(object sender, EventArgs e)
        {
            if (chkIsUnitPerRate.Checked && txtPurUnitRate.Text != "")
            {
                decimal rate = Convert.ToDecimal(txtPurUnitRate.Text);
                decimal qty = string.IsNullOrWhiteSpace(txtItemQuantity.Text) ? 0 : Convert.ToDecimal(txtItemQuantity.Text);
                txtPRate.Text = (rate * qty).ToString("N2");
            }
        }

        private void calculateRates()
        {
            try
            {
                if (chkIsUnitPerRate.Checked)
                {
                    decimal qty = string.IsNullOrWhiteSpace(txtItemQuantity.Text) ? 0 : Convert.ToDecimal(txtItemQuantity.Text);
                    decimal purRate = string.IsNullOrWhiteSpace(txtPurUnitRate.Text) ? 0 : Convert.ToDecimal(txtPurUnitRate.Text);

                    txtPRate.Text = (purRate * qty).ToString("N2");

                    if (!string.IsNullOrWhiteSpace(txtUnitPerRateA.Text))
                    {
                        decimal rateA = Convert.ToDecimal(txtUnitPerRateA.Text);
                        txtSuperSplRate.Text = (rateA * qty).ToString("N2");
                    }
                    else
                    {
                        txtSuperSplRate.Text = "0.00";
                    }

                    if (!string.IsNullOrWhiteSpace(txtUnitPerRateB.Text))
                    {
                        decimal rateB = Convert.ToDecimal(txtUnitPerRateB.Text);
                        txtSpecialRate.Text = (rateB * qty).ToString("N2");
                    }
                    else
                    {
                        txtSpecialRate.Text = "0.00";
                    }

                    if (!string.IsNullOrWhiteSpace(txtUnitPerRateC.Text))
                    {
                        decimal rateC = Convert.ToDecimal(txtUnitPerRateC.Text);
                        txtWholeSaleRate.Text = (rateC * qty).ToString("N2");
                    }
                    else
                    {
                        txtWholeSaleRate.Text = "0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the error
                // MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void chkIsUnitPerRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return && chkIsUnitPerRate.Checked)
            {
                txtUnitPerRateA.Focus();
            }
            else if (e.KeyData == Keys.Return)
            {
                cboItemUnitType.Focus();
            }
        }

        private void chkTaxable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return && chkIsUnitPerRate.Checked)
            {
                txtPurUnitRate.Focus();
            }
            else if (e.KeyData == Keys.Return)
            {
                txtPRate.Focus();
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



        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Load data from your database (item table)
                InventoryDataContext db = new InventoryDataContext();
                var items = db.items.ToList();

                if (items.Count == 0)
                {
                    MessageBox.Show("No records to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create Excel Application
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "ItemExport".Replace(":", "").Replace("/", "").Replace("\\", "");

                worksheet.Cells[1, 1] = "Serial No";
                worksheet.Cells[1, 2] = "Item Name";
                worksheet.Cells[1, 3] = "Item TamilName";                
                worksheet.Cells[1, 4] = "Quantity";
                worksheet.Cells[1, 5] = "Unit";
                worksheet.Cells[1, 6] = "Unit Type";
                worksheet.Cells[1, 7] = "Category";
                worksheet.Cells[1, 8] = "IsUnit Per Rate";
                worksheet.Cells[1, 9] = "Sales Unit Rate (A)";
                worksheet.Cells[1, 10] = "Sales Unit Rate (B)";
                worksheet.Cells[1, 11] = "Sales Unit Rate (C)";
                worksheet.Cells[1, 12] = "Purchase Unit Rate";
                worksheet.Cells[1, 13] = "Taxable";
                worksheet.Cells[1, 14] = "Tax Percentage";
                worksheet.Cells[1, 15] = "HSN/SAC Code";
                worksheet.Cells[1, 16] = "Company";
                worksheet.Cells[1, 17] = "Tally Item Name";

                // Fill data
                int row = 2;
                foreach (var item in items)
                {
                    worksheet.Cells[row, 1] = item.item_serial;
                    worksheet.Cells[row, 2] = item.item_name;
                    worksheet.Cells[row, 3] = item.item_tamilname;                   
                    worksheet.Cells[row, 4] = item.item_quantity;
                    worksheet.Cells[row, 5] = item.item_unit;
                    worksheet.Cells[row, 6] = item.item_unittype;
                    worksheet.Cells[row, 7] = item.cat_id;
                    worksheet.Cells[row, 8] = item.item_isunitperrate;
                    worksheet.Cells[row, 9] = item.item_perunitrate;
                    worksheet.Cells[row, 10] = item.item_perunitrateb;
                    worksheet.Cells[row, 11] = item.item_perunitratec;
                    worksheet.Cells[row, 12] = item.item_purunitrate;
                    worksheet.Cells[row, 13] = item.item_istaxable;
                    worksheet.Cells[row, 14] = item.item_taxpercentage;
                    worksheet.Cells[row, 15] = item.item_hsncode;
                    worksheet.Cells[row, 16] = item.com_id;
                    worksheet.Cells[row, 17] = item.item_fullname;
                    row++;
                }
                worksheet.Columns.AutoFit();
                // Show save dialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save Excel File";
                saveFileDialog.FileName = "ItemExport.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            Excel.Range range = null;

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Select Excel File";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = openFileDialog.FileName;               

                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                range = worksheet.UsedRange;

                string header1 = Convert.ToString((range.Cells[1, 1] as Excel.Range)?.Value2)?.Trim();
                string header2 = Convert.ToString((range.Cells[1, 2] as Excel.Range)?.Value2)?.Trim();

                if (!string.Equals(header1, "Serial No", StringComparison.OrdinalIgnoreCase) ||
                    !string.Equals(header2, "Item Name", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Invalid Excel format.",
                        "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                progressBar1.Visible = true;
                lblProgress.Text = "";
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl != progressBar1)
                        ctrl.Enabled = false;
                }

                Cursor.Current = Cursors.WaitCursor;

                int totalRows = range.Rows.Count - 1;

                InventoryDataContext db = new InventoryDataContext();

                for (int row = 2; row <= range.Rows.Count; row++) // Start from row 2 (skip headers)
                {
                    string SerialNo = Convert.ToString((range.Cells[row, 1] as Excel.Range)?.Value2)?.Trim();
                    string itemName = Convert.ToString((range.Cells[row, 2] as Excel.Range).Value2);
                    string itemTamilName = Convert.ToString((range.Cells[row, 3] as Excel.Range).Value2);
                    bool isUnitPerRate = Convert.ToBoolean((range.Cells[row, 8] as Excel.Range)?.Value2);
                    decimal tax = Convert.ToDecimal((range.Cells[row, 14] as Excel.Range)?.Value2);
                    int qty = 0;
                    var qtyValue = (range.Cells[row, 4] as Excel.Range)?.Value2;
                    double qtyDouble = 0;

                    if (qtyValue != null)
                    {
                        int.TryParse(qtyValue.ToString(), out qty);
                    }

                    if (qtyValue != null)
                    {
                        double.TryParse(qtyValue.ToString(), out qtyDouble);
                    }

                    decimal purUnitRate = Convert.ToDecimal((range.Cells[row, 12] as Excel.Range)?.Value2);

                    decimal perUnitRateA = Convert.ToDecimal((range.Cells[row, 9] as Excel.Range)?.Value2);
                    decimal perUnitRateB = Convert.ToDecimal((range.Cells[row, 10] as Excel.Range)?.Value2);
                    decimal perUnitRateC = Convert.ToDecimal((range.Cells[row, 11] as Excel.Range)?.Value2);

                    decimal superSplRate = 0, splRate = 0, wholesaleRate = 0, mrp = 0, purchaseRate = 0;

                    if (isUnitPerRate && perUnitRateA > 0 && qty > 0)
                    {
                        superSplRate = perUnitRateA * qty;
                    }
                    else
                    {
                        superSplRate = 0;
                    }
                    if (isUnitPerRate && perUnitRateB > 0 && qty > 0)
                    {
                        splRate = perUnitRateB * qty;
                    }
                    else
                    {
                        splRate = 0;
                    }
                    if (isUnitPerRate && perUnitRateC > 0 && qty > 0)
                    {
                        wholesaleRate = perUnitRateC * qty;
                    }
                    else
                    {
                        wholesaleRate = 0;
                    }


                    if (isUnitPerRate && purUnitRate > 0 && qty > 0)
                    {
                        purchaseRate = Convert.ToDecimal(qtyDouble) * purUnitRate;

                    }
                    else
                    {
                        purchaseRate = 0;
                    }

                    if (!string.IsNullOrWhiteSpace(SerialNo) && string.IsNullOrWhiteSpace(itemName) && string.IsNullOrWhiteSpace(itemTamilName))
                    {
                        continue; // skip row if only serial number is filled
                    }

                    if (row > 2 && string.IsNullOrWhiteSpace(SerialNo))
                    {
                        MessageBox.Show($"Serial number should not be empty for item: {itemName}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // or continue; if you want to skip only this row
                    }


                    if (int.TryParse(SerialNo, out int serialNumber))
                    {
                        var existingItem = db.items.FirstOrDefault(x => x.item_serial == serialNumber);

                        if (existingItem != null)
                        {
                            existingItem.item_name = Convert.ToString((range.Cells[row, 2] as Excel.Range)?.Value2) ?? " ";
                            existingItem.item_tamilname = Convert.ToString((range.Cells[row, 3] as Excel.Range)?.Value2);                           
                            existingItem.item_quantity = Convert.ToInt32((range.Cells[row, 4] as Excel.Range)?.Value2);
                            existingItem.item_unit = Convert.ToString((range.Cells[row, 5] as Excel.Range)?.Value2);
                            existingItem.item_unittype = Convert.ToString((range.Cells[row, 6] as Excel.Range)?.Value2);
                            existingItem.cat_id = Convert.ToInt32((range.Cells[row, 7] as Excel.Range)?.Value2);
                            existingItem.item_isunitperrate = Convert.ToBoolean((range.Cells[row, 8] as Excel.Range)?.Value2);
                            existingItem.item_perunitrate = isUnitPerRate ? Convert.ToDecimal((range.Cells[row, 9] as Excel.Range)?.Value2) : 0;
                            existingItem.item_perunitrateb = isUnitPerRate ? Convert.ToDecimal((range.Cells[row, 10] as Excel.Range)?.Value2) : 0;
                            existingItem.item_perunitratec = isUnitPerRate ? Convert.ToDecimal((range.Cells[row, 11] as Excel.Range)?.Value2) : 0;
                            existingItem.item_purunitrate = isUnitPerRate ? purUnitRate : 0;
                            existingItem.item_istaxable = Convert.ToBoolean((range.Cells[row, 13] as Excel.Range)?.Value2);
                            existingItem.item_taxpercentage = Convert.ToDecimal((range.Cells[row, 14] as Excel.Range)?.Value2);
                            existingItem.item_hsncode = Convert.ToString((range.Cells[row, 15] as Excel.Range)?.Value2) ?? "";
                            existingItem.com_id = Convert.ToInt32((range.Cells[row, 16] as Excel.Range)?.Value2);
                            existingItem.item_fullname = Convert.ToString((range.Cells[row, 17] as Excel.Range)?.Value2) ?? "";
                            existingItem.item_supersepecialrate = superSplRate;
                            existingItem.item_specialrate = splRate;
                            existingItem.item_wholesalerate = wholesaleRate;
                            existingItem.item_cgst = tax / 2;
                            existingItem.item_sgst = tax / 2;
                            existingItem.item_mrp = Convert.ToDecimal((range.Cells[row, 16] as Excel.Range)?.Value2);
                            existingItem.item_purchaserate = purchaseRate;

                        }
                        else
                        {
                            // Add new item
                            item newItem = new item
                            {
                                item_serial = serialNumber,
                                item_name = Convert.ToString((range.Cells[row, 2] as Excel.Range)?.Value2) ?? " ",
                                item_tamilname = Convert.ToString((range.Cells[row, 3] as Excel.Range)?.Value2),                               
                                item_quantity = qty,
                                item_unit = Convert.ToString((range.Cells[row, 5] as Excel.Range)?.Value2),
                                item_unittype = Convert.ToString((range.Cells[row, 6] as Excel.Range)?.Value2),
                                cat_id = Convert.ToInt32((range.Cells[row, 7] as Excel.Range)?.Value2),
                                item_istaxable = Convert.ToBoolean((range.Cells[row, 13] as Excel.Range)?.Value2),
                                item_taxpercentage = Convert.ToDecimal((range.Cells[row, 14] as Excel.Range)?.Value2),
                                item_hsncode = Convert.ToString((range.Cells[row, 15] as Excel.Range)?.Value2) ?? "",
                                com_id = Convert.ToInt32((range.Cells[row, 16] as Excel.Range)?.Value2),
                                item_fullname = Convert.ToString((range.Cells[row, 17] as Excel.Range)?.Value2) ?? "",
                                item_isunitperrate = isUnitPerRate,
                                item_perunitrate = perUnitRateA,
                                item_perunitrateb = perUnitRateB,
                                item_perunitratec= perUnitRateC,
                                item_purunitrate = purUnitRate,
                                item_purchaserate = purchaseRate,
                                item_supersepecialrate = superSplRate,
                                item_specialrate = splRate,
                                item_wholesalerate = wholesaleRate,
                                item_cgst = tax / 2,
                                item_sgst = tax / 2,
                                item_mrp = mrp,
                                item_code = "",
                                users_uid = 1,
                                item_udate = DateTime.Now.Date
                            };

                            db.items.InsertOnSubmit(newItem);
                        }
                    }
                    int currentRow = row - 1; // Since you started at 2
                    int percent = (int)((currentRow * 100.0) / totalRows);

                    progressBar1.Value = percent;
                    lblProgress.Text = $"Progress: {percent}%";
                    Application.DoEvents();
                }

                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Enabled = true;
                }

                Cursor.Current = Cursors.Default;
                progressBar1.Visible = false;
                lblProgress.Text = "";
                progressBar1.Value = 100;

                db.SubmitChanges();

                workbook.Close(false);
                excelApp.Quit();

                MessageBox.Show("Items imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                try
                {
                    if (range != null)
                    {
                        Marshal.ReleaseComObject(range);
                        range = null;
                    }

                    if (worksheet != null)
                    {
                        Marshal.ReleaseComObject(worksheet);
                        worksheet = null;
                    }

                    if (workbook != null)
                    {
                        try
                        {
                            workbook.Close(false);
                        }
                        catch (Exception ex)
                        {
                            // Optional: log or ignore close exception
                        }
                        Marshal.ReleaseComObject(workbook);
                        workbook = null;
                    }

                    if (excelApp != null)
                    {
                        try
                        {
                            excelApp.Quit();
                        }
                        catch (Exception ex)
                        {
                            // Optional: log or ignore quit exception
                        }
                        Marshal.ReleaseComObject(excelApp);
                        excelApp = null;
                    }
                }
                catch (Exception ex)
                {
                    // Optional: log cleanup exceptions
                }
                finally
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }
        }

        private void txtPurUnitRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                txtTaxPercentage.Focus();
            }
        }

        private void txtTaxPercentage_Leave(object sender, EventArgs e)
        {
            decimal tax = Convert.ToDecimal(txtTaxPercentage.Text);

            txtCGST.Text = Convert.ToString(tax / 2);
            txtSGST.Text = Convert.ToString(tax / 2);
        }
    }
}
