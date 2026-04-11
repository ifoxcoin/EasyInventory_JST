using Microsoft.Reporting.WinForms;
using mylib;
using standard.classes;
using standard.report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Linq;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace standard.trans
{
    public class frmPurchase : Form
    {
        private delegate void SetColumnIndex(string colname);

        private long? id;

        private frmItemlist objsv;

        private AutoCompleteStringCollection acsItemCode;

        private AutoCompleteStringCollection acsItemName;

        private AutoCompleteStringCollection acsCategoryName;

        private IContainer components = null;

        private TableLayoutPanel tablemain;

        private Label lbltitle;

        private TableLayoutPanel tableentry;

        private Label lblopno;

        private Label lbldate;

        private DateTimePicker dtppurdate;

        private TableLayoutPanel tablecmd;

        private lightbutton cmdsave;

        private lightbutton cmdrefresh;

        private lightbutton cmdclose;

        private TableLayoutPanel tablesum;

        private Label lbltotqty;

        private decimalbox txttotqty;

        private Panel pnlentry;

        private Label lblfrom;

        private ComboBox cbopurfrom;

        private decimalbox txttotamt;

        private Label lblnetamt;

        private Panel pnlview;

        private TableLayoutPanel tableview;

        private mygrid dglist;

        private lightbutton cmdview;

        private Label lblsubtitle;

        private DataGridViewTextBoxColumn miidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mibillnoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mibilldateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn amnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mitotamtDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn minetamtDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn minarrationDataGridViewTextBoxColumn;

        private TextBox txtpurno;

        private BindingSource ledgermasterBindingSource;

        private Label lblAddress;

        private Label label2;

        private ComboBox cboCity;

        private BindingSource ledgermasterCityBindingSource;

        private BindingSource usppurchasemasterSelectResultBindingSource;

        private DataGridViewTextBoxColumn comname1DataGridViewTextBoxColumn;

        private BindingSource ledgermasteCityViewrBindingSource;

        private BindingSource ledgermasterViewBindingSource;

        private mygrid dgvPurchase;

        private DateTimePicker dtptdate;

        private DateTimePicker importDate;

        private lightbutton cmdexit;

        private Label lblhyp;

        private DateTimePicker dtpfdate;

        private Label lblfdate;

        private Label lblImportDate;

        private Label label5;

        private ComboBox cboCityView;

        private Label label6;

        private lightbutton cmdList;

        private Button importButton;

        private TableLayoutPanel tableLayoutPanel1;

        private Label lblBillNo;

        private TextBox txtSearchBillNo;

        private ComboBox cboSupplierView;

        private DataGridViewImageColumn ldelete;

        private DataGridViewImageColumn ledit;

        private DataGridViewImageColumn lprint;

        private DataGridViewTextBoxColumn pmnoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn pmdateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn pmtotqtyDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn pmtotamountDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn comnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn pmudateDataGridViewTextBoxColumn;

        private DataGridViewImageColumn lImport;

        private DataGridViewTextBoxColumn isImport;

        private DataGridViewTextBoxColumn pmdescDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private Label lblDiscountPer;
        private Label lblDiscountRate;
        private decimalbox txtDiscountPercentage;
        private decimalbox txtDiscountRate;
        private Label lblFrieght;
        private decimalbox txtFrieght;
        private CheckBox chkIsFrieght;
        private Label label1;
        private TextBox txtBillNo;
        private decimalbox txtWages;
        private Label label3;
        private Label label4;
        private ComboBox cboCompany;
        private BindingSource companyBindingSource;
        private DataGridViewTextBoxColumn cSNo;
        private DataGridViewTextBoxColumn cCategory;
        private DataGridViewTextBoxColumn cItemName;
        private DataGridViewTextBoxColumn cQty;
        private DataGridViewTextBoxColumn cRate;
        private DataGridViewTextBoxColumn cTaxPercentage;
        private DataGridViewTextBoxColumn cTaxAmount;
        private DataGridViewTextBoxColumn cItemUnitValue;
        private DataGridViewTextBoxColumn cItemUnit;
        private DataGridViewTextBoxColumn cFrieghtCharge;
        private DataGridViewTextBoxColumn cAmount;
        private DataGridViewTextBoxColumn cCatID;
        private DataGridViewTextBoxColumn cItemID;
        private DataGridViewTextBoxColumn cMrp;
        private Label label7;
        private decimalbox txttottax;
        private Label label8;
        private ComboBox cboAgent;
        private BindingSource ledgermasterBindingSource1;
        private DataGridViewTextBoxColumn pmidDataGridViewTextBoxColumn;

        public frmPurchase()
        {
            InitializeComponent();
        }

        private void frmAmType_Load(object sender, EventArgs e)
        {
            try
            {
                id = 0L;
                objsv = new frmItemlist();
                objsv.dgview.KeyDown += dgSearch_KeyDown;
                objsv.dgview.CellDoubleClick += dgSearch_CellDoubleClick;
                LoadData();
                AutoFill();
                txtBillNo.Select();
            }
            catch (Exception ex)
            {
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void dgSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objsv.dgview.CurrentCell != null)
            {
                int rowIndex = Convert.ToInt32(objsv.dgview.CurrentCell.RowIndex);
                int r = dgvPurchase.CurrentCell.RowIndex;
                dgvPurchase["cItemId", r].Value = objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value;
                dgvPurchase["cItemName", r].Value = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value;
                global.itemname = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value.ToString();
                global.itemid = Convert.ToInt32(objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value);
                dgvPurchase["cItemName", r].Value = global.itemname;
                dgvPurchase["cItemId", r].Value = global.itemid;
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    dgvPurchase.Rows.RemoveAt(r);
                }
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    var queryable = from li in inventoryDataContext.items
                                    join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                    where li.item_id == Convert.ToInt32(dgvPurchase["cItemId", r].Value)
                                    select new
                                    {
                                        cat,
                                        li
                                    };
                    foreach (var item in queryable)
                    {
                        dgvPurchase["cRate", r].Value = item.li.item_purchaserate;
                        dgvPurchase["cItemID", r].Value = item.li.item_id;
                        dgvPurchase["cCategory", r].Value = item.cat.cat_name;
                        dgvPurchase["cCatID", r].Value = item.cat.cat_id;
                        dgvPurchase["cItemUnitValue", r].Value = item.li.item_quantity;
                        dgvPurchase["cItemUnit", r].Value = item.li.item_unit;
                    }
                }
                dgvPurchase.Focus();
                objsv.Close();
            }
        }

        private void dgSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (objsv.dgview.CurrentCell == null)
            {
                return;
            }
            if (e.KeyCode == Keys.Return)
            {
                int rowIndex = Convert.ToInt32(objsv.dgview.CurrentCell.RowIndex);
                int r = dgvPurchase.CurrentCell.RowIndex;
                dgvPurchase["cItemId", r].Value = objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value;
                dgvPurchase["cItemName", r].Value = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value;
                global.itemname = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value.ToString();
                global.itemid = Convert.ToInt32(objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value);
                dgvPurchase["cItemName", r].Value = global.itemname;
                dgvPurchase["cItemId", r].Value = global.itemid;
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    dgvPurchase.Rows.RemoveAt(r);
                }
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    var queryable = from li in inventoryDataContext.items
                                    join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                    where li.item_id == Convert.ToInt32(dgvPurchase["cItemId", r].Value)
                                    select new
                                    {
                                        cat,
                                        li
                                    };
                    foreach (var item in queryable)
                    {
                        dgvPurchase["cRate", r].Value = item.li.item_purchaserate;
                        dgvPurchase["cItemID", r].Value = item.li.item_id;
                        dgvPurchase["cCategory", r].Value = item.cat.cat_name;
                        dgvPurchase["cCatID", r].Value = item.cat.cat_id;
                        dgvPurchase["cItemUnitValue", r].Value = item.li.item_quantity;
                        dgvPurchase["cItemUnit", r].Value = item.li.item_unit;
                    }
                }
                dgvPurchase.CurrentCell = dgvPurchase.Rows[r].Cells["cQty"];
                dgvPurchase.Focus();
                objsv.Close();
                dgvPurchase.CurrentCell = dgvPurchase["cQty", r];
                dgvPurchase.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                objsv.Close();
            }
        }

        private void loadgrid(long catid)
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            objsv.dgview.DataSource = inventoryDataContext.usp_GetItemList(null, catid);
        }

        private void LoadData()
        {
            dtppurdate.MinDate = DateTimePicker.MinimumDateTime;
            dtppurdate.MaxDate = DateTime.MaxValue; // Or DateTime.Today.AddYears(1)

            DateTime today = DateTime.Today;
            DateTime financialYearStart;

            if (today.Month >= 4)
            {
                // April to December → current year April 1
                financialYearStart = new DateTime(today.Year, 4, 1);
            }
            else
            {
                // Jan to March → previous year April 1
                financialYearStart = new DateTime(today.Year - 1, 4, 1);
            }

            dtppurdate.Value = today;
            dtpfdate.Value = financialYearStart;

            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            using (inventoryDataContext)
            {
                var source = from a in inventoryDataContext.ledgermasters
                             where a.led_accounttype == "SUPPLIER" || a.led_id == 0
                             select new
                             {
                                 a.led_id,
                                 a.led_name,
                                 a.led_address2,
                                 a.led_agid
                             } into x
                             orderby x.led_id
                             select x;
                var Agent = from a in inventoryDataContext.ledgermasters
                             where a.led_accounttype == "AGENT" || a.led_id == 0
                            select new
                             {
                                 a.led_id,
                                 a.led_name,
                                 a.led_address2,
                                 a.led_agid
                             } into x
                             orderby x.led_id
                            select x;

                ledgermasterBindingSource.DataSource = source.OrderBy(x => x.led_address2);
                ledgermasterBindingSource1.DataSource = Agent.OrderBy(x => x.led_id);
                cboAgent.SelectedIndex = -1;
                cboAgent.Text = "--Select--";
                ledgermasterViewBindingSource.DataSource = source.OrderBy(x => x.led_address2);
                ledgermasteCityViewrBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                usppurchasemasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_purchasemasterSelect(null, null, null, null, null, null);
                companyBindingSource.DataSource = inventoryDataContext.usp_companySelect(null);
                List<usp_itemSelectResult> list = inventoryDataContext.usp_itemSelect(null, null, null, null).ToList();
                AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                foreach (usp_itemSelectResult item in list)
                {
                    autoCompleteStringCollection.Add(item.item_name);
                }
                long? no = 0L;
                inventoryDataContext.usp_getYearNo("pur_no", global.sysdate, ref no, null);
                txtpurno.Text = Convert.ToString(no);
                usppurchasemasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_purchasemasterSelect(null, Convert.ToInt32(cbopurfrom.SelectedValue), dtpfdate.Value.Date, dtppurdate.Value.Date, null, null);
            }
        }

        private void AutoFill()
        {
            acsItemCode = new AutoCompleteStringCollection();
            acsItemName = new AutoCompleteStringCollection();
            acsCategoryName = new AutoCompleteStringCollection();
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            using (inventoryDataContext)
            {
                IQueryable<category> queryable = inventoryDataContext.categories.Select((category li) => li);
                foreach (category item in queryable)
                {
                    acsCategoryName.Add(item.cat_name);
                }
                IQueryable<item> queryable2 = inventoryDataContext.items.Select((item li) => li);
                foreach (item item2 in queryable2)
                {
                    acsItemCode.Add(item2.item_code);
                    acsItemName.Add(item2.item_name);
                }
            }
        }

        private void ClearData()
        {
            cbopurfrom.SelectedIndex = 0;
            cboCompany.SelectedIndex = -1;
            //cbopurfrom.Text = string.Empty;
            lblAddress.Text = string.Empty;
            dgvPurchase.Rows.Clear();
            txttotqty.Value = 0m;
            txttotamt.Value = 0m;
            txttottax.Value = 0m;
            txtBillNo.Text = string.Empty;
            txtDiscountRate.Value = 0m;
            txtDiscountPercentage.Value = 0m;
            txtWages.Value = 0m;
            txtFrieght.Value = 0m;
            id = 0L;
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            item item = null;
            DbTransaction dbTransaction = null;
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                purchasemaster purchasemaster = new purchasemaster();
                purchasedetail purchasedetail = new purchasedetail();
                purchasemaster.led_id = Convert.ToInt32(cbopurfrom.SelectedValue);
                if (purchasemaster.led_id == 0)
                {
                    MessageBox.Show("Invalid 'Supplier'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cbopurfrom.Focus();
                }
                else
                {
                    List<item> source = inventoryDataContext.items.Select((item itemRow) => itemRow).ToList();
                    foreach (DataGridViewRow dr in (IEnumerable)dgvPurchase.Rows)
                    {
                        if (!dr.IsNewRow)
                        {
                            item = source.FirstOrDefault(match => match.item_id == Convert.ToInt32(dr.Cells["cItemID"].Value));
                            dr.Cells["cItemId"].Value = (item?.item_id ?? 0);
                            if (Convert.ToInt32(dr.Cells["cItemId"].Value) == 0 || Convert.ToDecimal(dr.Cells["cAmount"].Value) == 0m || Convert.ToDecimal(dr.Cells["cQty"].Value) == 0m)
                            {
                                MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                dgvPurchase.Focus();
                                return;
                            }
                        }
                    }
                    if (dgvPurchase.RowCount <= 1)
                    {
                        MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvPurchase.Focus();
                    }
                    else
                    {
                        if (id != 0)
                        {
                        }
                        if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                        {
                            purchasemaster.pm_totamount = txttotamt.Value;
                            purchasemaster.pm_totqty = txttotqty.Value;
                            purchasemaster.pm_billno = txtBillNo.Text;
                            purchasemaster.com_id = Convert.ToInt32(cboCompany.SelectedValue);
                            purchasemaster.pm_wages = txtWages.Value;
                            purchasemaster.pm_frieght = txtFrieght.Value;
                            purchasemaster.pm_totaltaxamount = txttottax.Value;
                            purchasemaster.pm_discountpercentage = txtDiscountPercentage.Value;
                            purchasemaster.pm_discountamount = txtDiscountRate.Value;
                            purchasemaster.pm_date = dtppurdate.Value;
                            purchasemaster.pm_desc = "";
                            purchasemaster.pm_id = 1L;
                            purchasemaster.pm_paid = 0;
                            purchasemaster.pm_agid = Convert.ToInt64(cboAgent.SelectedValue);
                            if (id == 0)
                            {
                                long? no = 0L;
                                inventoryDataContext.usp_setYearNo("pur_no", global.sysdate, ref no, null);
                                purchasemaster.pm_no = Convert.ToInt64(no);
                                inventoryDataContext.usp_purchasemasterInsert(ref id, purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, purchasemaster.pm_discountpercentage, purchasemaster.pm_discountamount, purchasemaster.pm_wages, purchasemaster.pm_frieght, purchasemaster.pm_billno, purchasemaster.com_id, global.ucode, global.sysdate, purchasemaster.pm_desc, false, purchasemaster.pm_paid, purchasemaster.pm_totaltaxamount, false, purchasemaster.pm_agid);
                                foreach (DataGridViewRow item2 in (IEnumerable)dgvPurchase.Rows)
                                {
                                    if (!item2.IsNewRow)
                                    {
                                        purchasedetail.pd_unitvalue = Convert.ToDecimal(item2.Cells["cItemUnitValue"].Value);
                                        purchasedetail.pd_qty = Convert.ToDecimal(item2.Cells["cQty"].Value);
                                        purchasedetail.pd_prate = Convert.ToDecimal(item2.Cells["cRate"].Value);
                                        purchasedetail.cat_id = Convert.ToInt32(item2.Cells["cCatID"].Value);
                                        purchasedetail.item_id = Convert.ToInt32(item2.Cells["cItemId"].Value);
                                        purchasedetail.pd_amount = Convert.ToDecimal(item2.Cells["cAmount"].Value);
                                        purchasedetail.item_id = Convert.ToInt32(item2.Cells["cItemId"].Value);
                                        purchasedetail.pd_particulars = item2.Cells["cItemName"].Value.ToString();
                                        purchasedetail.pd_totfrieght = Convert.ToDecimal(item2.Cells["cFrieghtCharge"].Value);
                                        purchasedetail.pd_taxpercentage = Convert.ToDecimal(item2.Cells["cTaxPercentage"].Value);
                                        purchasedetail.pd_taxamount = Convert.ToDecimal(item2.Cells["cTaxAmount"].Value);
                                        inventoryDataContext.usp_purchasedetailsInsert(Convert.ToInt32(id), purchasedetail.item_id, purchasedetail.cat_id, purchasedetail.pd_particulars, purchasedetail.pd_qty, purchasedetail.pd_unitvalue, purchasedetail.pd_prate, purchasedetail.pd_amount, purchasedetail.pd_totfrieght, purchasedetail.pd_taxpercentage, purchasedetail.pd_taxamount);
                                        var catid = inventoryDataContext.items.Where(i => i.item_id == purchasedetail.item_id).Select(i => i.cat_id).FirstOrDefault();
                                        if (catid == 39)
                                        {
                                            inventoryDataContext.usp_stockInsert(id, "PURCHASE", purchasedetail.item_id, purchasemaster.com_id, purchasedetail.pd_unitvalue, 0m, global.sysdate);
                                        }
                                        else
                                        {
                                            inventoryDataContext.usp_stockInsert(id, "PURCHASE", purchasedetail.item_id, purchasemaster.com_id, purchasedetail.pd_qty, 0m, global.sysdate);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                purchasemaster.pm_no = Convert.ToInt64(txtpurno.Text);
                                var oldGuid = inventoryDataContext.purchasemasters.Where(pm => pm.pm_id == id).Select(pm => pm.pm_guid).FirstOrDefault();

                                if (oldGuid != null)
                                {
                                    purchasemaster.pm_guid = oldGuid;
                                }
                                else
                                {
                                    purchasemaster.pm_guid = null;
                                }

                                inventoryDataContext.usp_purchasemasterUpdate(Convert.ToInt64(id), purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, purchasemaster.pm_discountpercentage, purchasemaster.pm_discountamount, purchasemaster.pm_wages, purchasemaster.pm_frieght, purchasemaster.pm_billno, purchasemaster.com_id, global.ucode, global.sysdate, purchasemaster.pm_desc, false, purchasemaster.pm_paid, purchasemaster.pm_totaltaxamount, purchasemaster.pm_isimport, purchasemaster.pm_guid, purchasemaster.pm_agid);
                                inventoryDataContext.usp_purchasedetailsDelete(Convert.ToInt32(id));
                                inventoryDataContext.usp_stockDelete(Convert.ToInt32(id), "PURCHASE");
                                foreach (DataGridViewRow item3 in (IEnumerable)dgvPurchase.Rows)
                                {
                                    if (!item3.IsNewRow)
                                    {
                                        purchasedetail.pd_unitvalue = Convert.ToDecimal(item3.Cells["cItemUnitValue"].Value);
                                        purchasedetail.pd_qty = Convert.ToDecimal(item3.Cells["cQty"].Value);
                                        purchasedetail.pd_prate = Convert.ToDecimal(item3.Cells["cRate"].Value);
                                        purchasedetail.cat_id = Convert.ToInt32(item3.Cells["cCatID"].Value);
                                        purchasedetail.pd_particulars = item3.Cells["cItemName"].Value.ToString();
                                        purchasedetail.item_id = Convert.ToInt32(item3.Cells["cItemId"].Value);
                                        purchasedetail.pd_amount = Convert.ToDecimal(item3.Cells["cAmount"].Value);
                                        purchasedetail.item_id = Convert.ToInt32(item3.Cells["cItemId"].Value);
                                        purchasedetail.pd_totfrieght = Convert.ToDecimal(item3.Cells["cFrieghtCharge"].Value);
                                        purchasedetail.pd_taxpercentage = Convert.ToDecimal(item3.Cells["cTaxPercentage"].Value);
                                        purchasedetail.pd_taxamount = Convert.ToDecimal(item3.Cells["cTaxAmount"].Value);
                                        purchasedetail.pd_particulars = "";
                                        inventoryDataContext.usp_purchasedetailsInsert(Convert.ToInt32(id), purchasedetail.item_id, purchasedetail.cat_id, purchasedetail.pd_particulars, purchasedetail.pd_qty, purchasedetail.pd_unitvalue, purchasedetail.pd_prate, purchasedetail.pd_amount, purchasedetail.pd_totfrieght, purchasedetail.pd_taxpercentage, purchasedetail.pd_taxamount);
                                        var catid = inventoryDataContext.items.Where(i => i.item_id == purchasedetail.item_id).Select(i => i.cat_id).FirstOrDefault();
                                        if (catid == 39)
                                        {
                                            inventoryDataContext.usp_stockInsert(id, "PURCHASE", purchasedetail.item_id, purchasemaster.com_id, purchasedetail.pd_unitvalue, 0m, global.sysdate);
                                        }
                                        else
                                        {
                                            inventoryDataContext.usp_stockInsert(id, "PURCHASE", purchasedetail.item_id, purchasemaster.com_id, purchasedetail.pd_qty, 0m, global.sysdate);
                                        }
                                    }
                                }
                            }
                            //loadReport(Convert.ToInt32(id));
                            ClearData();
                            LoadData();
                            dtppurdate.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dbTransaction?.Rollback();
                ClearData();
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void loadReport(int smid)
        {
            decimal amount = 0m;
            decimal num = 0m;
            decimal num2 = 0m;
            decimal num3 = 0m;
            decimal num4 = 0m;
            string empty = string.Empty;
            long num5 = 0L;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string value = string.Empty;
            string empty5 = string.Empty;
            DateTime? dateTime = null;
            if (dglist.CurrentCell != null)
            {
                List<ReportParameter> list = new List<ReportParameter>();
                if (MessageBox.Show("Are you sure to Print Bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    ISingleResult<usp_purchasemasterSelectResult> singleResult = inventoryDataContext.usp_purchasemasterSelect(smid, null, null, null, null, null);
                    foreach (usp_purchasemasterSelectResult item in singleResult)
                    {
                        int? num6 = 1;
                        dateTime = item.pm_date;
                        num5 = item.pm_no;
                        amount = item.pm_totamount;
                        num = 0m;
                        num4 = 0m;
                        num2 = item.pm_totamount;
                        value = general.MoneyToText(amount);
                    }
                    ISingleResult<usp_companySelectResult> singleResult2 = inventoryDataContext.usp_companySelect(1L);
                    using (IEnumerator<usp_companySelectResult> enumerator2 = singleResult2.GetEnumerator())
                    {
                        if (enumerator2.MoveNext())
                        {
                            usp_companySelectResult current2 = enumerator2.Current;
                            list.Add(new ReportParameter("com_name", current2.com_name));
                            list.Add(new ReportParameter("com_add1", current2.com_add1));
                            list.Add(new ReportParameter("com_add2", current2.com_add2));
                            list.Add(new ReportParameter("com_add3", current2.com_add3));
                            list.Add(new ReportParameter("com_city", current2.com_city));
                            list.Add(new ReportParameter("com_pin", current2.com_pin));
                            list.Add(new ReportParameter("com_phone", current2.com_phone));
                            list.Add(new ReportParameter("com_mobile1", current2.com_mobile1));
                            list.Add(new ReportParameter("com_tin", current2.com_tin));
                            list.Add(new ReportParameter("com_cst", current2.com_cst));
                            list.Add(new ReportParameter("com_email", current2.com_email));
                            list.Add(new ReportParameter("com_pan", current2.com_pan));
                            list.Add(new ReportParameter("com_cstdate", Convert.ToDateTime(current2.com_cstdate).ToString("dd-MMM-yyyy")));
                        }
                    }
                    list.Add(new ReportParameter("ordno", num5.ToString()));
                    list.Add(new ReportParameter("orddate", $"{dateTime:dd-MMM-yyyy}"));
                    list.Add(new ReportParameter("rstext", value));
                    list.Add(new ReportParameter("am_acccode", empty2));
                    list.Add(new ReportParameter("am_account", empty3));
                    list.Add(new ReportParameter("am_bank", empty4));
                    list.Add(new ReportParameter("title", empty5));
                    list.Add(new ReportParameter("mi_totamt", num2.ToString("0.00")));
                    list.Add(new ReportParameter("mi_discount", num4.ToString("0.00")));
                    list.Add(new ReportParameter("mi_discount", num4.ToString("0.00")));
                    list.Add(new ReportParameter("mi_packing", num.ToString("0.00")));
                    list.Add(new ReportParameter("mi_netamt", amount.ToString("0.00")));
                    frmRpt frmRpt = new frmRpt();
                    frmRpt.WindowState = FormWindowState.Maximized;
                    ISingleResult<usp_purchasemasterSelectResult> dataSourceValue = inventoryDataContext.usp_purchasemasterSelect(smid, null, null, null, null, null);
                    ISingleResult<usp_purchasedetailsSelectResult> dataSourceValue2 = inventoryDataContext.usp_purchasedetailsSelect(smid, null, null, null, null, null);
                    frmRpt.reportview.RefreshReport();
                    frmRpt.reportview.LocalReport.ReportEmbeddedResource = "standard.report.purinv.rdlc";
                    frmRpt.reportview.LocalReport.DataSources.Clear();
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_minvoiceSelect", dataSourceValue));
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("ds_usp_dinvoiceSelect", dataSourceValue2));
                    frmRpt.reportview.LocalReport.SetParameters(list);
                    frmRpt.reportview.RefreshReport();
                    frmRpt.reportview.LocalReport.Refresh();
                    frmRpt.ShowDialog();
                }
            }
        }

        private void cmdrefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadData();
            dtppurdate.Focus();
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Mymethod(string colname)
        {
            dgvPurchase.CurrentCell = dgvPurchase[colname, dgvPurchase.RowCount - 1];
            dgvPurchase.BeginEdit(selectAll: true);
            dgvPurchase.Focus();
        }

        private void dgopen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPurchase.CurrentCell == null)
            {
                return;
            }
            if (cbopurfrom == null || Convert.ToInt32(cbopurfrom.SelectedValue) == 0)
            {
                MessageBox.Show("Invalid 'Customer'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cbopurfrom.Focus();
                return;
            }
            int r = dgvPurchase.CurrentCell.RowIndex;
            int columnIndex = dgvPurchase.CurrentCell.ColumnIndex;
            decimal result;
            decimal result2;
            decimal qty;
            decimal unitValue;
            if (columnIndex == cCategory.Index)
            {
                try
                {
                    if (dgvPurchase["cCategory", r].Value != null)
                    {
                        if (Convert.ToString(dgvPurchase["cCategory", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                        {
                            dgvPurchase.Rows.RemoveAt(r);
                        }
                        InventoryDataContext inventoryDataContext = new InventoryDataContext();
                        long num = (from li in inventoryDataContext.categories
                                    where li.cat_name == dgvPurchase["cCategory", r].Value.ToString().Trim()
                                    select li.cat_id).SingleOrDefault();
                        if (num <= 0)
                        {
                            MessageBox.Show("Invalid 'Category'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            loadgrid(num);
                            objsv.ShowDialog();
                            string itemname = global.itemname;
                            long itemid = global.itemid;
                            InventoryDataContext inventoryDataContext2 = new InventoryDataContext();
                            using (inventoryDataContext2)
                            {
                                var selectedItem = inventoryDataContext2.items.FirstOrDefault(i => i.item_id == itemid);

                                if (selectedItem.item_purchaserate <= 0)
                                {
                                    MessageBox.Show("Invalid purchase rate!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //return;
                                }
                                IQueryable<item> queryable = from li in inventoryDataContext2.items
                                                             join cat in inventoryDataContext2.categories on li.cat_id equals cat.cat_id
                                                             where cat.cat_name == Convert.ToString(dgvPurchase["cCategory", r].Value)
                                                             select li;
                                if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                                {
                                    dgvPurchase["cItemUnitValue", r].ReadOnly = false;
                                    dgvPurchase["cQty", r].ReadOnly = true;
                                    dgvPurchase["cQty", r].Value = 1;
                                }
                                decimal amount = 0;

                                if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                                {
                                    amount = 0;
                                }
                                dgvPurchase["cTaxPercentage", r].Value = selectedItem.item_taxpercentage.ToString("0.00");
                                foreach (item item in queryable)
                                {
                                    acsItemCode.Add(item.item_code);
                                    acsItemName.Add(item.item_name);
                                }
                            }
                            dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCellAddress.Y].Cells["cQty"];
                            dgvPurchase.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    frmException ex2 = new frmException(ex);
                    ex2.ShowDialog();
                }
            }
            else if (columnIndex == cItemName.Index)
            {
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        dgvPurchase.Rows.RemoveAt(r);
                    }));
                }
                InventoryDataContext inventoryDataContext2 = new InventoryDataContext();
                using (inventoryDataContext2)
                {
                    var queryable2 = from li in inventoryDataContext2.items
                                     join cat in inventoryDataContext2.categories on li.cat_id equals cat.cat_id
                                     where li.item_id == Convert.ToInt32(dgvPurchase["cItemID", r].Value)
                                     select new
                                     {
                                         cat,
                                         li
                                     };

                    if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                    {
                        dgvPurchase["cItemUnitValue", r].ReadOnly = false;
                    }
                    decimal amount = 0;

                    if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                    {
                        amount = 0;
                    }

                    foreach (var item2 in queryable2)
                    {
                        var selectedItem = inventoryDataContext2.items.FirstOrDefault(i => i.item_id == item2.li.item_id);
                        if (selectedItem != null)
                        {
                            if (selectedItem.item_purchaserate <= 0)
                            {
                                MessageBox.Show("Invalid purchase rate!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        dgvPurchase["cRate", r].Value = item2.li.item_purchaserate;
                        dgvPurchase["cItemId", r].Value = item2.li.item_id;
                        dgvPurchase["cCategory", r].Value = item2.cat.cat_name;
                        dgvPurchase["cCatID", r].Value = item2.cat.cat_id;
                        dgvPurchase["cItemUnitValue", r].Value = item2.li.item_quantity;
                        dgvPurchase["cItemUnit", r].Value = item2.li.item_unit;
                        dgvPurchase["cTaxPercentage", r].Value = item2.li.item_taxpercentage.ToString("0.00");
                    }
                }
                dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCellAddress.Y].Cells["cQty"];
                dgvPurchase.Focus();
            }

            else if (columnIndex == cItemUnitValue.Index)
            {
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    dgvPurchase.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvPurchase["cQty", r].Value), out qty);
                result = Math.Abs(qty);
                decimal.TryParse(Convert.ToString(dgvPurchase["cItemUnitValue", r].Value), out unitValue);

                dgvPurchase["cQty", r].Value = ((result > 0m) ? ((object)result) : null);
                decimal.TryParse(Convert.ToString(dgvPurchase["cRate", r].Value), out result2);

                if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                {
                    if (result2 > 0m && unitValue > 0m)
                    {
                        decimal amount = (result2 * unitValue);
                        dgvPurchase["cAmount", r].Value = amount.ToString("N2"); // format to 2 decimals
                    }
                    else
                    {
                        dgvPurchase["cAmount", r].Value = null;
                    }
                }

                decimal totalAmount = Convert.ToDecimal(dgvPurchase["cAmount", r].Value);
                decimal taxPercent = Convert.ToDecimal(dgvPurchase["cTaxPercentage", r].Value);

                // Formula: TaxAmount = Amount * Tax% / 100
                decimal taxAmount = totalAmount * taxPercent / 100;

                dgvPurchase["cTaxAmount", r].Value = taxAmount.ToString("0.00");
                calacTotal();
                dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCellAddress.Y].Cells["cRate"];
                dgvPurchase.Focus();

            }

            else if (columnIndex == cQty.Index)
            {
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    dgvPurchase.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvPurchase["cQty", r].Value), out qty);
                result = Math.Abs(qty);
                decimal.TryParse(Convert.ToString(dgvPurchase["cItemUnitValue", r].Value), out unitValue);

                dgvPurchase["cQty", r].Value = ((result > 0m) ? ((object)result) : null);
                decimal.TryParse(Convert.ToString(dgvPurchase["cRate", r].Value), out result2);

                if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                {
                    if (result2 > 0m && unitValue > 0m)
                    {
                        decimal amount = (result2 * unitValue);
                        dgvPurchase["cAmount", r].Value = amount.ToString("N2"); // format to 2 decimals
                    }
                    else
                    {
                        dgvPurchase["cAmount", r].Value = null;
                    }
                }
                else
                {
                    if (result2 > 0m && result > 0m)
                    {
                        decimal amount = (result2 * result);
                        dgvPurchase["cAmount", r].Value = amount.ToString("N2"); // format to 2 decimals
                    }
                    else
                    {
                        dgvPurchase["cAmount", r].Value = null;
                    }
                }

                decimal totalAmount = Convert.ToDecimal(dgvPurchase["cAmount", r].Value);
                decimal taxPercent = Convert.ToDecimal(dgvPurchase["cTaxPercentage", r].Value);

                // Formula: TaxAmount = Amount * Tax% / 100
                decimal taxAmount = totalAmount * taxPercent / 100;

                dgvPurchase["cTaxAmount", r].Value = taxAmount.ToString("0.00");


                calacTotal();
                dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCellAddress.Y].Cells["cRate"];
                dgvPurchase.Focus();
            }

            else if (columnIndex == cMrp.Index)
            {
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    dgvPurchase.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvPurchase["cMrp", r].Value), out result2);
                result2 = Math.Abs(result2);
                dgvPurchase["cMrp", r].Value = ((result2 > 0m) ? ((object)result2) : null);
            }

            else if (columnIndex == cRate.Index)
            {
                if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
                {
                    dgvPurchase.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvPurchase["cRate", r].Value), out result2);
                result2 = Math.Abs(result2);
                dgvPurchase["cRate", r].Value = ((result2 > 0m) ? ((object)result2) : null);
                decimal.TryParse(Convert.ToString(dgvPurchase["cQty", r].Value), out result);
                decimal.TryParse(Convert.ToString(dgvPurchase["cItemUnitValue", r].Value), out unitValue);

                if (dgvPurchase["cCatID", r].Value != null && Convert.ToInt32(dgvPurchase["cCatID", r].Value) == 39)
                {
                    dgvPurchase["cAmount", r].Value = ((result2 > 0m && unitValue > 0m) ? ((object)(result2 * unitValue)) : null);
                }
                else
                {
                    dgvPurchase["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
                }

                decimal totalAmount = Convert.ToDecimal(dgvPurchase["cAmount", r].Value);
                decimal taxPercent = Convert.ToDecimal(dgvPurchase["cTaxPercentage", r].Value);

                // Formula: TaxAmount = Amount * Tax% / 100
                decimal taxAmount = totalAmount * taxPercent / 100;

                dgvPurchase["cTaxAmount", r].Value = taxAmount.ToString("0.00");
                calacTotal();
                dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCellAddress.Y].Cells["cRate"];
                dgvPurchase.Focus();
            }
        }

        private void dgopen_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calacTotal();
        }

        private void dgopen_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calacTotal();
        }

        private void calacTotal()
        {
            List<string> list = new List<string>();
            list.Add("cQty");
            list.Add("cAmount");
            list.Add("cTaxAmount");
            List<decimal> totalSNo = bus.getTotalSNo(dgvPurchase, "cSNo", list);
            txttotqty.Value = Convert.ToDecimal(totalSNo[0]);
            txttotamt.Text = totalSNo[1].ToString("0.00");
            txttottax.Text = totalSNo[2].ToString("0.00");
            List<decimal> list2 = new List<decimal>();
            decimal d1 = totalSNo[1];
            decimal d2 = 0m;
            decimal value = txtDiscountPercentage.Value;
            decimal d3 = (d1 + d2) * value / 100m;
            decimal frieght = txtFrieght.Value;
            decimal wages = txtWages.Value;
            decimal discountRate = txtDiscountRate.Value;
            decimal taxAmount = txttottax.Value;
            //if (!string.IsNullOrWhiteSpace(txtDiscountRate.Text) && txtDiscountRate.Value > 0)
            //{
            //    txtDiscountPercentage.Text = "0";
            //    decimal num = txtDiscountRate.Value / d1 * 100m;
            //    txtDiscountPercentage.Text = $"{num:0.00}";
            //}                      
            decimal total = d1 + frieght + wages + taxAmount - discountRate;
            txttotamt.Text = $"{Math.Ceiling(total):0.00}";
            list2.Add(txttotamt.Value);
            list2.Add(0m);
            list2.Add(0m);
            list2.Add(0m);
            list2.Add(0m);
            list2.Add(0m);
            list2.Add(0m);
        }

        private void dgopen_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvPurchase.CurrentCell == null)
            {
                return;
            }
            if (dgvPurchase.CurrentCell.ColumnIndex == 1)
            {
            }
            if (e.KeyCode == Keys.F3 || e.KeyCode == Keys.Delete)
            {
                if (dgvPurchase.CurrentRow.IsNewRow)
                {
                    return;
                }
                dgvPurchase.Rows.RemoveAt(dgvPurchase.CurrentCell.RowIndex);
            }
            if ((e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab) && dgvPurchase.CurrentCell.ColumnIndex == cQty.Index && !dgvPurchase.CurrentRow.IsNewRow)
            {
                dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCell.RowIndex + 1].Cells["cCategory"];
                dgvPurchase.Focus();
            }
        }

        private void dtpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cbopurfrom.Focus();
            }
        }

        private void dtpbilldate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cbopurfrom.Focus();
            }
        }

        private void cbopurfrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && cbopurfrom.Text.Trim() != string.Empty)
            {
                cboCompany.Focus();
            }
        }

        private void cmdview_Click(object sender, EventArgs e)
        {
            pnlview.Enabled = true;
            tablemain.Enabled = false;
            pnlview.BringToFront();
            tablemain.SendToBack();
            pnlview.Select();
            cmdList_Click(this, null);
            dtpfdate.Focus();
        }

        private void dgList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    cmdexit_Click(this, null);
                }
                else if (e.KeyCode == Keys.F8)
                {
                    loadReport(Convert.ToInt32(dglist.CurrentRow.Cells["pmidDataGridViewTextBoxColumn"].Value));
                }
            }
            catch (Exception ex)
            {
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            pnlview.Enabled = false;
            tablemain.Enabled = true;
            pnlview.SendToBack();
            tablemain.BringToFront();
            txtBillNo.Focus();
        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                if (txtSearchBillNo.Text == string.Empty)
                {
                    usppurchasemasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_purchasemasterSelect(null, Convert.ToInt32(cboSupplierView.SelectedValue), dtpfdate.Value.Date, dtptdate.Value.Date, null, null);
                }
                else
                {
                    usppurchasemasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_purchasemasterSelect(null, null, null, null, null, Convert.ToInt32(txtSearchBillNo.Text));
                }
            }
            catch (Exception ex)
            {
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void dglist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dglist.CurrentCell != null)
            {
                loadlist();
            }
        }

        private void loadlist()
        {
            int num = Convert.ToInt32(dglist["pmidDataGridViewTextBoxColumn", dglist.CurrentRow.Index].Value);
            id = num;
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            ISingleResult<usp_purchasemasterSelectResult> singleResult = inventoryDataContext.usp_purchasemasterSelect(num, null, null, null, null, null);
            using (IEnumerator<usp_purchasemasterSelectResult> enumerator = singleResult.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    usp_purchasemasterSelectResult current = enumerator.Current;
                    txtpurno.Text = Convert.ToString(current.pm_no);
                    txtBillNo.Text = current.pm_billno;
                    cboCompany.SelectedValue = current.com_id;
                    cboCity.Text = current.led_address2.ToString();
                    cbopurfrom.SelectedValue = current.led_id;
                    dtppurdate.Value = Convert.ToDateTime(current.pm_date);
                    cbopurfrom.SelectedValue = current.led_id;
                    txtDiscountPercentage.Text = current.pm_discountpercentage.ToString();
                    txtDiscountRate.Text = current.pm_discountamount.ToString();
                    txtWages.Text = current.pm_wages.ToString();
                    txtFrieght.Text = current.pm_frieght.ToString();
                    if (current.pm_agid != null && cboAgent.Items.Count > 0)
                    {
                        cboAgent.SelectedValue = current.pm_agid;
                    }

                    txttottax.Text = current.pm_totaltaxamount.ToString();
                }
            }
            ISingleResult<usp_purchasedetailsSelectResult> singleResult2 = inventoryDataContext.usp_purchasedetailsSelect(num, null, null, null, null, null);
            dgvPurchase.Rows.Clear();
            dgvPurchase.AllowUserToAddRows = false;
            foreach (usp_purchasedetailsSelectResult item in singleResult2)
            {
                dgvPurchase.Rows.Add();
                dgvPurchase["cCatID", dgvPurchase.RowCount - 1].Value = item.cat_id;
                dgvPurchase["cItemId", dgvPurchase.RowCount - 1].Value = item.item_id;
                dgvPurchase["cCategory", dgvPurchase.RowCount - 1].Value = item.cat_name;
                dgvPurchase["cItemName", dgvPurchase.RowCount - 1].Value = item.item_name;
                dgvPurchase["cRate", dgvPurchase.RowCount - 1].Value = item.pd_prate;
                dgvPurchase["cQty", dgvPurchase.RowCount - 1].Value = item.pd_qty;
                dgvPurchase["cAmount", dgvPurchase.RowCount - 1].Value = item.pd_amount;
                dgvPurchase["cItemUnitValue", dgvPurchase.RowCount - 1].Value = item.pd_unitvalue;
                dgvPurchase["cItemUnit", dgvPurchase.RowCount - 1].Value = item.item_unit;
                dgvPurchase["cTaxPercentage", dgvPurchase.RowCount - 1].Value = item.pd_taxpercentage;
                dgvPurchase["cTaxAmount", dgvPurchase.RowCount - 1].Value = item.pd_taxamount;
                //dgvPurchase["cFrieghtCharge", dgvPurchase.RowCount - 1].Value = item.pd_totfrieght;
            }
            dgvPurchase.AllowUserToAddRows = true;
            calacTotal();
            pnlview.Enabled = false;
            tablemain.Enabled = true;
            pnlview.SendToBack();
            tablemain.BringToFront();
            txtBillNo.Focus();
        }

        private void dglist_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dglist.Columns[e.ColumnIndex].Name == "isImport" && e.Value != null)
            {
                if (e.Value is bool)
                {
                    bool isImport = (bool)e.Value;
                    e.Value = isImport ? "Imported" : "Not Import";
                    e.CellStyle.ForeColor = isImport ? Color.Green : Color.Red;
                    e.FormattingApplied = true;
                }
            }
        }

        private void dglist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ldelete.Index && e.RowIndex > -1)
                {
                    int num = Convert.ToInt32(dglist["pmidDataGridViewTextBoxColumn", e.RowIndex].Value);
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        InventoryDataContext inventoryDataContext2 = new InventoryDataContext();
                        inventoryDataContext2.usp_stockDelete(num, "PURCHASE");
                        inventoryDataContext2.usp_purchasedetailsDelete(num);
                        inventoryDataContext2.usp_purchasemasterDelete(num);
                        cmdList_Click(this, null);
                        MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (e.ColumnIndex == ledit.Index && e.RowIndex > -1)
                {
                    if (dglist.CurrentCell != null)
                    {
                        loadlist();
                    }
                }
                else if (e.ColumnIndex == lprint.Index && e.RowIndex > -1)
                {
                    loadReport(Convert.ToInt32(dglist.CurrentRow.Cells["pmidDataGridViewTextBoxColumn"].Value));
                }
                else if (e.ColumnIndex == lImport.Index && e.RowIndex > -1)
                {
                    int pmid = Convert.ToInt32(dglist.Rows[e.RowIndex].Cells["pmidDataGridViewTextBoxColumn"].Value);

                    DialogResult result = MessageBox.Show("Are you sure to import to Tally?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ImportPurchaseToTally(pmid);
                    }
                }
            }
            catch (Exception ex)
            {
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void dtpfdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                dtptdate.Focus();
            }
        }

        private void dtptdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdList.Focus();
            }
        }

        private void dtpfdate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpfdate.Value.Date > dtptdate.Value.Date)
            {
                dtptdate.Value = dtpfdate.Value.Date;
            }
        }

        private void dtptdate_ValueChanged(object sender, EventArgs e)
        {
            if (dtptdate.Value.Date < dtpfdate.Value.Date)
            {
                dtpfdate.Value = dtptdate.Value.Date;
            }
        }

        private void cbopurfrom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cbopurfrom.Text.Trim() == ""))
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    IQueryable<ledgermaster> queryable = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_id == (long)Convert.ToInt32(cbopurfrom.SelectedValue));
                    foreach (ledgermaster item in queryable)
                    {
                        lblAddress.Text = item.led_address + "," + item.led_address1 + "," + item.led_address2 + "-" + item.led_pincode;
                        chkIsFrieght.Checked = item.led_isfreight;
                        cboAgent.SelectedValue = item.led_agid;
                    }

                }
            }
        }

        private void dgvPurchase_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvPurchase.Columns[dgvPurchase.CurrentCellAddress.X].Name == "cItemName")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = acsItemName;
                }
            }
            else if (dgvPurchase.Columns[dgvPurchase.CurrentCellAddress.X].Name == "cItemCode")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = acsItemCode;
                }
            }
            else if (dgvPurchase.Columns[dgvPurchase.CurrentCellAddress.X].Name == "cCategory")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = acsCategoryName;
                }
            }
            else
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteCustomSource = null;
                }
            }
        }

        private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            if (cboCity.SelectedItem != null)
            {
                using (inventoryDataContext)
                {
                    ledgermasterBindingSource.Clear();
                    var source = from a in inventoryDataContext.ledgermasters
                                 where a.led_accounttype == "Supplier" && a.led_address2 == cboCity.Text.ToString()
                                 select new
                                 {
                                     a.led_id,
                                     a.led_name
                                 };
                    ledgermasterBindingSource.DataSource = source.OrderBy(x => x.led_name);
                    cbopurfrom.DataSource = source.OrderBy(x => x.led_name);
                }
            }
        }

        private void cboCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cbopurfrom.Focus();
            }
        }

        //private void cboCityView_SelectedValueChanged(object sender, EventArgs e)
        //{
        //	if (cboCityView.SelectedItem != null)
        //	{
        //		InventoryDataContext inventoryDataContext = new InventoryDataContext();
        //		using (inventoryDataContext)
        //		{
        //			ledgermasterViewBindingSource.Clear();
        //			var source = from a in inventoryDataContext.ledgermasters
        //				where a.led_accounttype == "Supplier" && a.led_address2 == cboCityView.Text.ToString().Trim()
        //				select new
        //				{
        //					a.led_id,
        //					a.led_name
        //				};
        //			ledgermasterViewBindingSource.DataSource = source.OrderBy(x => x.led_name);
        //			cboSupplierView.DataSource = source.OrderBy(x => x.led_name);
        //		}
        //	}
        //}

        private void txtSearchBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdList_Click(null, null);
            }
        }

        private void cboSupplierView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdList_Click(null, null);
            }
        }

        private void cboCityView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cboSupplierView.Focus();
            }
        }

        public static class TallyHelper
        {

            public static string BuildPurchaseVoucherXml(usp_purchasemasterSelectResult master, List<usp_purchasedetailsSelectResult> details)
            {
                string date = Convert.ToDateTime(master.pm_date).ToString("yyyyMMdd", CultureInfo.InvariantCulture);
                string voucherNumber = Convert.ToString(master.pm_billno);
                Guid guid;
                if (master.pm_guid != null)
                {
                    guid = master.pm_guid ?? Guid.NewGuid();
                }
                else
                {
                    guid = Guid.NewGuid();
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    purchasemaster purchasemaster = inventoryDataContext.purchasemasters.FirstOrDefault(x => x.pm_id == master.pm_id);
                    inventoryDataContext.usp_purchasemasterUpdate(master.pm_id, purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, purchasemaster.pm_discountpercentage, purchasemaster.pm_discountamount, purchasemaster.pm_wages, purchasemaster.pm_frieght, purchasemaster.pm_billno, purchasemaster.com_id, global.ucode, global.sysdate, purchasemaster.pm_desc, purchasemaster.pm_isclose, purchasemaster.pm_paid, purchasemaster.pm_totaltaxamount, purchasemaster.pm_isimport, guid, purchasemaster.pm_agid);
                }

                string companyName = master.com_id == 2 ? "JEYAKKODI TRADERS 2026-2027" : master.com_id == 1 ? "SAAMY TRADE LINKS 2026-2027" : "Unknown Company";
                string purchaseLedger = master.com_id == 2 ? "Purchase GST" : master.com_id == 1 ? "PURCHASES GST" : "Unknown Type";
                string supplierLedger = master.com_id == 2 ? master.led_name : master.com_id == 1 ? master.led_stlname : null;
                string supplierGSTIN = master.led_tin ?? "";
                string partyAddressLine1 = master.led_address;
                string partyAddressLine2 = master.led_address1;
                string partyAddressLine3 = master.led_address2;
                string RegistrationType = !string.IsNullOrEmpty(supplierGSTIN) ? "Regular" : "Unregistered/Consumer";
                string vehicleNo = master.led_vehicleno;
                string action = string.IsNullOrEmpty(guid.ToString()) ? "Create" : "Alter";
                string state = master.led_state ?? "Tamil Nadu";
                string godown = "Main Location";

                decimal gstAmount = master.pm_totaltaxamount;
                string igstLedger = "IGST";
                string cgstLedger = "CGST";
                string sgstLedger = "SGST";
                decimal cgst = Math.Truncate((gstAmount / 2) * 100) / 100;
                decimal sgst = Math.Truncate((gstAmount / 2) * 100) / 100;

                StringBuilder xml = new StringBuilder();

                xml.AppendLine("<ENVELOPE>");
                xml.AppendLine("  <HEADER>");
                xml.AppendLine("    <TALLYREQUEST>Import Data</TALLYREQUEST>");
                xml.AppendLine("  </HEADER>");
                xml.AppendLine("  <BODY>");
                xml.AppendLine("    <IMPORTDATA>");
                xml.AppendLine("      <REQUESTDESC>");
                xml.AppendLine("        <REPORTNAME>Vouchers</REPORTNAME>");
                xml.AppendLine("        <STATICVARIABLES>");
                xml.AppendLine($"          <SVCURRENTCOMPANY>{companyName}</SVCURRENTCOMPANY>");
                xml.AppendLine("        </STATICVARIABLES>");
                xml.AppendLine("      </REQUESTDESC>");
                xml.AppendLine("      <REQUESTDATA>");
                xml.AppendLine("        <TALLYMESSAGE xmlns:UDF=\"TallyUDF\">");
                xml.AppendLine($"          <VOUCHER REMOTEID=\"{guid}\" VCHTYPE=\"GST PURCHASE\" ACTION=\"{action}\" GUID=\"{guid}\" OBJVIEW=\"Invoice Voucher View\">");

                xml.AppendLine($"            <DATE>{date}</DATE>");
                xml.AppendLine($"            <GUID>{guid}</GUID>");
                xml.AppendLine($"            <VOUCHERNUMBER>{voucherNumber}</VOUCHERNUMBER>");
                xml.AppendLine($"            <SUPPINVNO>{voucherNumber}</SUPPINVNO>");
                xml.AppendLine($"            <PARTYLEDGERNAME>{supplierLedger}</PARTYLEDGERNAME>");
                xml.AppendLine($"            <VOUCHERTYPENAME>GST PURCHASE</VOUCHERTYPENAME>");
                xml.AppendLine("            <CLASSNAME>PURCHASE</CLASSNAME>");
                xml.AppendLine($"            <BASICBUYERNAME>{supplierLedger}</BASICBUYERNAME>");
                xml.AppendLine($"            <BASICBASEPARTYNAME>{supplierLedger}</BASICBASEPARTYNAME>");
                xml.AppendLine($"            <REFERENCE>{voucherNumber}</REFERENCE>");
                xml.AppendLine($"            <PARTYGSTIN>{supplierGSTIN}</PARTYGSTIN>");
                xml.AppendLine($"            <PLACEOFSUPPLY>Tamil Nadu</PLACEOFSUPPLY>");
                xml.AppendLine($"            <STATENAME>{state}</STATENAME>");
                xml.AppendLine("            <COUNTRYOFRESIDENCE>India</COUNTRYOFRESIDENCE>");
                xml.AppendLine($"            <GSTREGISTRATIONTYPE>{RegistrationType}</GSTREGISTRATIONTYPE>");
                xml.AppendLine($"            <BASICSHIPVESSELNO>{vehicleNo}</BASICSHIPVESSELNO>");

                // Buyer (Bill To) Address
                // Buyer (Bill To) Address
                xml.AppendLine($"            <PARTYLEDGERNAME>{supplierLedger}</PARTYLEDGERNAME>");
                xml.AppendLine($"            <PARTYMAILINGNAME>{supplierLedger}</PARTYMAILINGNAME>");
                xml.AppendLine("             <ADDRESS.LIST TYPE=\"String\">");
                xml.AppendLine($"              <ADDRESS>{partyAddressLine1}</ADDRESS>");
                xml.AppendLine($"              <ADDRESS>{partyAddressLine2}</ADDRESS>");
                xml.AppendLine($"              <ADDRESS>{partyAddressLine3}</ADDRESS>");
                xml.AppendLine($"              <ADDRESS>{state}</ADDRESS>");
                xml.AppendLine("             </ADDRESS.LIST>");

                xml.AppendLine("            <BASICBUYERADDRESS.LIST TYPE=\"String\">");
                xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine1}</BASICBUYERADDRESS>");
                xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine2}</BASICBUYERADDRESS>");
                xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine3}</BASICBUYERADDRESS>");
                xml.AppendLine("            </BASICBUYERADDRESS.LIST>");

                // Consignee (Ship To) Address
                xml.AppendLine("            <BASICSHIPADDRESS.LIST TYPE=\"String\">");
                xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine1}</BASICSHIPADDRESS>");
                xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine2}</BASICSHIPADDRESS>");
                xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine3}</BASICSHIPADDRESS>");
                xml.AppendLine("            </BASICSHIPADDRESS.LIST>");
                xml.AppendLine("            <ISINVOICE>Yes</ISINVOICE>");
                xml.AppendLine("            <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>");

                // Supplier Ledger Entry - Debit
                xml.AppendLine("            <LEDGERENTRIES.LIST>");
                xml.AppendLine($"              <LEDGERNAME>{supplierLedger}</LEDGERNAME>");
                xml.AppendLine("              <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                xml.AppendLine("              <ISPARTYLEDGER>Yes</ISPARTYLEDGER>");
                xml.AppendLine($"              <AMOUNT>{master.pm_totamount:0.00}</AMOUNT>");
                xml.AppendLine("            </LEDGERENTRIES.LIST>");

                if (gstAmount > 0)
                {

                    if (state == "Tamil Nadu")
                    {

                        // CGST Ledger Entry
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{cgstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>-{cgst:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                        // SGST Ledger Entry
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{sgstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>-{sgst:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                    }
                    else
                    {

                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{igstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>-{gstAmount:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                    }

                }

                // Item-wise Inventory Entries
                foreach (var item in details)
                {
                    xml.AppendLine("            <ALLINVENTORYENTRIES.LIST>");
                    xml.AppendLine($"              <STOCKITEMNAME>{item.item_fullname}</STOCKITEMNAME>");

                    if (item.item_fullname == "CHILLIES IN KGS")
                    {
                        xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                        xml.AppendLine("              <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"              <RATE>{item.pd_prate:0.00}/kg</RATE>");
                        xml.AppendLine($"              <ACTUALQTY>{item.pd_unitvalue} kg</ACTUALQTY>");
                        xml.AppendLine($"              <BILLEDQTY>{item.pd_unitvalue} Kg</BILLEDQTY>");
                        xml.AppendLine($"              <AMOUNT>-{item.pd_amount:0.00}</AMOUNT>");
                        //xml.AppendLine("              <ISSUPPORTQTY>No</ISSUPPORTQTY>");
                        xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("                <GODOWNNAME>Main Location</GODOWNNAME>");
                        xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                        xml.AppendLine("                <DESTINATIONGODOWN>Main Location</DESTINATIONGODOWN>");
                        xml.AppendLine($"                <AMOUNT>{item.pd_amount:0.00}</AMOUNT>");
                        xml.AppendLine($"                <ACTUALQTY>{item.pd_unitvalue} Kg</ACTUALQTY>");
                        xml.AppendLine($"                <BILLEDQTY>{item.pd_unitvalue} Kg</BILLEDQTY>");
                        xml.AppendLine($"                <RATE>{item.pd_prate:0.00}/Kg</RATE>");
                        xml.AppendLine("              </BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("             <GSTDETAILS.LIST>");
                        xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                        xml.AppendLine("              <TAXABILITY>Taxable</TAXABILITY>"); // Change to "Taxable" if needed
                        xml.AppendLine("              <ISREVERSECHARGEAPPLICABLE>No</ISREVERSECHARGEAPPLICABLE>");
                        xml.AppendLine("              <ISNONGSTGOODS>No</ISNONGSTGOODS>");
                        xml.AppendLine("              <GSTINELIGIBLEITC>No</GSTINELIGIBLEITC>");
                        xml.AppendLine("              <ISGSTINVOICE>Yes</ISGSTINVOICE>");
                        xml.AppendLine("              </GSTDETAILS.LIST>");
                        xml.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine($"                <LEDGERNAME>{purchaseLedger}</LEDGERNAME>");
                        xml.AppendLine("                <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"                <AMOUNT>-{item.pd_amount:0.00}</AMOUNT>");
                        xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");
                    }
                    else
                    {

                        xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                        xml.AppendLine("              <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"              <RATE>{item.pd_prate:0.00}/Bag</RATE>");
                        xml.AppendLine($"              <ACTUALQTY>{item.pd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"              <BILLEDQTY>{item.pd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"              <AMOUNT>-{item.pd_amount:0.00}</AMOUNT>");
                        xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                        xml.AppendLine($"                <GODOWNNAME>{godown}</GODOWNNAME>");
                        xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                        xml.AppendLine($"                <AMOUNT>-{item.pd_amount:0.00}</AMOUNT>");
                        xml.AppendLine($"                <ACTUALQTY>{item.pd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"                <BILLEDQTY>{item.pd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"                <RATE>{item.pd_prate:0.00}/Bag</RATE>");
                        xml.AppendLine("              </BATCHALLOCATIONS.LIST>");

                        if (gstAmount <= 0)
                        {
                            xml.AppendLine("              <GSTDETAILS.LIST>");
                            xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                            xml.AppendLine("              <TAXABILITY>Exempt</TAXABILITY>"); // Change to "Taxable" if needed
                            xml.AppendLine("              </GSTDETAILS.LIST>");
                        }
                        else
                        {
                            xml.AppendLine("              <GSTDETAILS.LIST>");
                            xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                            xml.AppendLine("              <TAXABILITY>Taxable</TAXABILITY>"); // Change to "Taxable" if needed
                            xml.AppendLine("              <ISREVERSECHARGEAPPLICABLE>No</ISREVERSECHARGEAPPLICABLE>");
                            xml.AppendLine("              <ISNONGSTGOODS>No</ISNONGSTGOODS>");
                            xml.AppendLine("              <GSTINELIGIBLEITC>No</GSTINELIGIBLEITC>");
                            xml.AppendLine("              <ISGSTINVOICE>Yes</ISGSTINVOICE>");
                            xml.AppendLine("              </GSTDETAILS.LIST>");
                        }

                        xml.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine($"                <LEDGERNAME>{purchaseLedger}</LEDGERNAME>");
                        xml.AppendLine("                <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"                <AMOUNT>-{item.pd_amount:0.00}</AMOUNT>");
                        xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");
                    }

                }

                decimal itemTotal = details.Sum(i => Math.Round((i.item_fullname == "CHILLIES IN KGS" ? i.pd_unitvalue * i.pd_prate : i.pd_qty * i.pd_prate), 2));

                // Add GST
                decimal finalTotal = 0;
                if (gstAmount > 0)
                {

                    if (state == "Tamil Nadu")
                    {
                        finalTotal = itemTotal + cgst + sgst;
                    }
                    else
                    {
                        finalTotal = itemTotal + gstAmount;                    
                    }
                }     // Always round UP
                decimal roundedTotal = Math.Ceiling(finalTotal);

                // Calculate round off difference
                decimal roundOff = roundedTotal - finalTotal;

                if (roundOff != 0)
                {
                    xml.AppendLine("      <LEDGERENTRIES.LIST>");
                    xml.AppendLine("        <LEDGERNAME>Round Off</LEDGERNAME>");
                    xml.AppendLine("        <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                    xml.AppendLine($"        <AMOUNT>-{roundOff:0.00}</AMOUNT>");
                    xml.AppendLine("      </LEDGERENTRIES.LIST>");
                }


                xml.AppendLine("          </VOUCHER>");
                xml.AppendLine("        </TALLYMESSAGE>");
                xml.AppendLine("      </REQUESTDATA>");
                xml.AppendLine("    </IMPORTDATA>");
                xml.AppendLine("  </BODY>");
                xml.AppendLine("</ENVELOPE>");

                return xml.ToString();
            }

            public static bool SendToTally(string xmlPayload, int pmid)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:9000");
                    byte[] bytes = Encoding.UTF8.GetBytes(xmlPayload);

                    request.Method = "POST";
                    request.ContentType = "application/xml";
                    request.ContentLength = bytes.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }

                    using (WebResponse response = request.GetResponse())
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd();

                        if (result.Contains("<CREATED>1</CREATED>") || result.Contains("<ALTERED>1</ALTERED>"))
                        {
                            using (InventoryDataContext inventoryDataContext = new InventoryDataContext())
                            {
                                var purchasemaster = inventoryDataContext.purchasemasters.FirstOrDefault(x => x.pm_id == pmid);
                                if (purchasemaster != null)
                                {
                                    inventoryDataContext.usp_purchasemasterUpdate(
                               pmid, purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, purchasemaster.pm_discountpercentage, purchasemaster.pm_discountamount, purchasemaster.pm_wages, purchasemaster.pm_frieght, purchasemaster.pm_billno, purchasemaster.com_id, global.ucode, global.sysdate, purchasemaster.pm_desc, purchasemaster.pm_isclose, purchasemaster.pm_paid, purchasemaster.pm_totaltaxamount, true, purchasemaster.pm_guid, purchasemaster.pm_agid
                                    );
                                }
                            }
                        }
                        MessageBox.Show("Tally Response:\n" + result,
                            "Tally Reply", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return result.Contains("<LINEERROR>") == false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending to Tally: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            public static string SendToTallySilent(string xmlPayload)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:9000");
                    byte[] bytes = Encoding.UTF8.GetBytes(xmlPayload);

                    request.Method = "POST";
                    request.ContentType = "application/xml";
                    request.ContentLength = bytes.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }

                    using (WebResponse response = request.GetResponse())
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd(); // just return response
                    }
                }
                catch (Exception ex)
                {
                    return "ERROR: " + ex.Message;
                }
            }
        }

        private void ImportPurchaseToTally(int pmid)
        {
            using (var db = new InventoryDataContext())
            {
                var purchaseMaster = db.usp_purchasemasterSelect(pmid, null, null, null, null, null).FirstOrDefault();
                var purchaseDetails = db.usp_purchasedetailsSelect(pmid, null, null, null, null, null).ToList();

                if (purchaseMaster == null)
                {
                    MessageBox.Show("Purchase record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tallyXml = TallyHelper.BuildPurchaseVoucherXml(purchaseMaster, purchaseDetails);
                //string xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tally_test.xml"); 
                //File.WriteAllText(xmlPath, tallyXml); 
                //Process.Start("notepad.exe", xmlPath); 

                bool success = TallyHelper.SendToTally(tallyXml, (int)purchaseMaster.pm_id);

                MessageBox.Show(success ? "Imported to Tally successfully!" : "Failed to import to Tally.", "Status", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                ClearData();
                LoadData();
            }
        }

        private void ImportTodaysPurchasesToTally(object sender, EventArgs e)
        {
            using (var db = new InventoryDataContext())
            {
                DateTime Date = importDate.Value.Date;

                var purchaseMasters = db.usp_purchasemasterSelect(
                    null, null, Date, Date, null, null
                ).ToList();

                if (purchaseMasters == null || purchaseMasters.Count == 0)
                {
                    MessageBox.Show("No purchases found for today.",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure to Import Purchase on {importDate.Value:dd-MM-yyyy} to Tally?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return; // User cancelled
                }

                int created = 0, altered = 0, failed = 0;
                List<string> errorMessages = new List<string>();

                foreach (var master in purchaseMasters)
                {
                    var details = db.usp_purchasedetailsSelect(master.pm_id, null, null, null, null, null).ToList();
                    if (details.Count == 0) continue;

                    string tallyXml = TallyHelper.BuildPurchaseVoucherXml(master, details);
                    string response = TallyHelper.SendToTallySilent(tallyXml);

                    if (response.StartsWith("ERROR:"))
                    {
                        failed++;
                        errorMessages.Add(response);
                    }
                    else if (response.Contains("<CREATED>1</CREATED>"))
                    {
                        created++;
                        var purchasemaster = db.purchasemasters.FirstOrDefault(x => x.pm_id == master.pm_id);
                        if (purchasemaster != null)
                        {
                            db.usp_purchasemasterUpdate(
                                master.pm_id, purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, purchasemaster.pm_discountpercentage, purchasemaster.pm_discountamount, purchasemaster.pm_wages, purchasemaster.pm_frieght, purchasemaster.pm_billno, purchasemaster.com_id, global.ucode, global.sysdate, purchasemaster.pm_desc, purchasemaster.pm_isclose, purchasemaster.pm_paid, purchasemaster.pm_totaltaxamount, true, purchasemaster.pm_guid, purchasemaster.pm_agid
                            );
                        }
                    }
                    else if (response.Contains("<ALTERED>1</ALTERED>"))
                    {
                        altered++;
                        var purchasemaster = db.purchasemasters.FirstOrDefault(x => x.pm_id == master.pm_id);
                        if (purchasemaster != null)
                        {
                            db.usp_purchasemasterUpdate(
                                master.pm_id, purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, purchasemaster.pm_discountpercentage, purchasemaster.pm_discountamount, purchasemaster.pm_wages, purchasemaster.pm_frieght, purchasemaster.pm_billno, purchasemaster.com_id, global.ucode, global.sysdate, purchasemaster.pm_desc, purchasemaster.pm_isclose, purchasemaster.pm_paid, purchasemaster.pm_totaltaxamount, true, purchasemaster.pm_guid, purchasemaster.pm_agid
                            );
                        }
                    }
                    else if (response.Contains("<LINEERROR>"))
                    {
                        failed++;
                        errorMessages.Add(response);
                    }
                }

                string summary = $"Today's Purchase Import Completed!\n\n" +
                                 $"Created: {created}\n" +
                                 $"Altered: {altered}\n" +
                                 $"Failed: {failed}";

                if (errorMessages.Count > 0)
                {
                    summary += "\n\nErrors:\n" + string.Join("\n", errorMessages.Take(3)); // show first 3 errors
                }

                MessageBox.Show(summary, "Tally Import Status",
                    MessageBoxButtons.OK, failed > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                ClearData();
                LoadData();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            this.tablemain = new System.Windows.Forms.TableLayoutPanel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tableentry = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbopurfrom = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblfrom = new System.Windows.Forms.Label();
            this.lblopno = new System.Windows.Forms.Label();
            this.txtpurno = new System.Windows.Forms.TextBox();
            this.dtppurdate = new System.Windows.Forms.DateTimePicker();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.chkIsFrieght = new System.Windows.Forms.CheckBox();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tablecmd = new System.Windows.Forms.TableLayoutPanel();
            this.cmdsave = new mylib.lightbutton();
            this.cmdrefresh = new mylib.lightbutton();
            this.cmdclose = new mylib.lightbutton();
            this.cmdview = new mylib.lightbutton();
            this.tablesum = new System.Windows.Forms.TableLayoutPanel();
            this.lblnetamt = new System.Windows.Forms.Label();
            this.txttotamt = new mylib.decimalbox(this.components);
            this.txttotqty = new mylib.decimalbox(this.components);
            this.lbltotqty = new System.Windows.Forms.Label();
            this.lblDiscountPer = new System.Windows.Forms.Label();
            this.lblFrieght = new System.Windows.Forms.Label();
            this.txtFrieght = new mylib.decimalbox(this.components);
            this.lblDiscountRate = new System.Windows.Forms.Label();
            this.txtDiscountRate = new mylib.decimalbox(this.components);
            this.txtWages = new mylib.decimalbox(this.components);
            this.txtDiscountPercentage = new mylib.decimalbox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txttottax = new mylib.decimalbox(this.components);
            this.pnlentry = new System.Windows.Forms.Panel();
            this.dgvPurchase = new mylib.mygrid();
            this.cSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTaxPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemUnitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrieghtCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableview = new System.Windows.Forms.TableLayoutPanel();
            this.dglist = new mylib.mygrid();
            this.ldelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ledit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.pmnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmtotqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmtotamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmudateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lImport = new System.Windows.Forms.DataGridViewImageColumn();
            this.isImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmdescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pmidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usppurchasemasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblsubtitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.lblfdate = new System.Windows.Forms.Label();
            this.lblhyp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.txtSearchBillNo = new System.Windows.Forms.TextBox();
            this.cmdexit = new mylib.lightbutton();
            this.cboSupplierView = new System.Windows.Forms.ComboBox();
            this.ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdList = new mylib.lightbutton();
            this.lblImportDate = new System.Windows.Forms.Label();
            this.importDate = new System.Windows.Forms.DateTimePicker();
            this.importButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCityView = new System.Windows.Forms.ComboBox();
            this.ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlview = new System.Windows.Forms.Panel();
            this.tablemain.SuspendLayout();
            this.tableentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource1)).BeginInit();
            this.tablecmd.SuspendLayout();
            this.tablesum.SuspendLayout();
            this.pnlentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.tableview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usppurchasemasterSelectResultBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).BeginInit();
            this.pnlview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablemain
            // 
            this.tablemain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tablemain.ColumnCount = 1;
            this.tablemain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.Controls.Add(this.lbltitle, 0, 0);
            this.tablemain.Controls.Add(this.tableentry, 0, 1);
            this.tablemain.Controls.Add(this.tablecmd, 0, 4);
            this.tablemain.Controls.Add(this.tablesum, 0, 3);
            this.tablemain.Controls.Add(this.pnlentry, 0, 2);
            this.tablemain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablemain.Location = new System.Drawing.Point(0, 0);
            this.tablemain.Margin = new System.Windows.Forms.Padding(6);
            this.tablemain.Name = "tablemain";
            this.tablemain.RowCount = 5;
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tablemain.Size = new System.Drawing.Size(1671, 719);
            this.tablemain.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(8, 9);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(115, 23);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "PURCHASE";
            // 
            // tableentry
            // 
            this.tableentry.ColumnCount = 9;
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.Controls.Add(this.label1, 0, 0);
            this.tableentry.Controls.Add(this.cbopurfrom, 3, 1);
            this.tableentry.Controls.Add(this.lblfrom, 2, 1);
            this.tableentry.Controls.Add(this.lblopno, 0, 1);
            this.tableentry.Controls.Add(this.txtpurno, 1, 1);
            this.tableentry.Controls.Add(this.dtppurdate, 3, 0);
            this.tableentry.Controls.Add(this.lbldate, 2, 0);
            this.tableentry.Controls.Add(this.lblAddress, 0, 2);
            this.tableentry.Controls.Add(this.chkIsFrieght, 3, 2);
            this.tableentry.Controls.Add(this.txtBillNo, 1, 0);
            this.tableentry.Controls.Add(this.label4, 4, 0);
            this.tableentry.Controls.Add(this.cboCompany, 5, 0);
            this.tableentry.Controls.Add(this.label2, 4, 1);
            this.tableentry.Controls.Add(this.cboCity, 5, 1);
            this.tableentry.Controls.Add(this.label8, 6, 0);
            this.tableentry.Controls.Add(this.cboAgent, 7, 0);
            this.tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableentry.Location = new System.Drawing.Point(8, 47);
            this.tableentry.Margin = new System.Windows.Forms.Padding(6);
            this.tableentry.Name = "tableentry";
            this.tableentry.RowCount = 3;
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableentry.Size = new System.Drawing.Size(1655, 138);
            this.tableentry.TabIndex = 0;
            this.tableentry.Paint += new System.Windows.Forms.PaintEventHandler(this.tableentry_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bill No.";
            // 
            // cbopurfrom
            // 
            this.cbopurfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbopurfrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbopurfrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbopurfrom.DataSource = this.ledgermasterBindingSource;
            this.cbopurfrom.DisplayMember = "led_name";
            this.cbopurfrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbopurfrom.FormattingEnabled = true;
            this.cbopurfrom.Location = new System.Drawing.Point(620, 53);
            this.cbopurfrom.Margin = new System.Windows.Forms.Padding(6);
            this.cbopurfrom.Name = "cbopurfrom";
            this.cbopurfrom.Size = new System.Drawing.Size(262, 31);
            this.cbopurfrom.TabIndex = 4;
            this.cbopurfrom.ValueMember = "led_id";
            this.cbopurfrom.SelectedValueChanged += new System.EventHandler(this.cbopurfrom_SelectedValueChanged);
            this.cbopurfrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbopurfrom_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblfrom
            // 
            this.lblfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfrom.Location = new System.Drawing.Point(438, 57);
            this.lblfrom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(151, 23);
            this.lblfrom.TabIndex = 10;
            this.lblfrom.Text = "Purchase From";
            // 
            // lblopno
            // 
            this.lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblopno.AutoSize = true;
            this.lblopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblopno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblopno.Location = new System.Drawing.Point(6, 57);
            this.lblopno.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblopno.Name = "lblopno";
            this.lblopno.Size = new System.Drawing.Size(129, 23);
            this.lblopno.TabIndex = 1;
            this.lblopno.Text = "Purchase No";
            // 
            // txtpurno
            // 
            this.txtpurno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtpurno.BackColor = System.Drawing.Color.White;
            this.txtpurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpurno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtpurno.Location = new System.Drawing.Point(202, 54);
            this.txtpurno.Margin = new System.Windows.Forms.Padding(6);
            this.txtpurno.MaxLength = 20;
            this.txtpurno.Name = "txtpurno";
            this.txtpurno.ReadOnly = true;
            this.txtpurno.Size = new System.Drawing.Size(224, 30);
            this.txtpurno.TabIndex = 0;
            this.txtpurno.TabStop = false;
            // 
            // dtppurdate
            // 
            this.dtppurdate.CustomFormat = "dd-MM-yyyy";
            this.dtppurdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtppurdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtppurdate.Location = new System.Drawing.Point(620, 6);
            this.dtppurdate.Margin = new System.Windows.Forms.Padding(6);
            this.dtppurdate.Name = "dtppurdate";
            this.dtppurdate.Size = new System.Drawing.Size(262, 30);
            this.dtppurdate.TabIndex = 0;
            this.dtppurdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpdate_KeyDown);
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldate.Location = new System.Drawing.Point(438, 11);
            this.lbldate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(92, 23);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Pur Date";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.tableentry.SetColumnSpan(this.lblAddress, 2);
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAddress.Location = new System.Drawing.Point(6, 103);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(16, 23);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = ".";
            // 
            // chkIsFrieght
            // 
            this.chkIsFrieght.AutoSize = true;
            this.chkIsFrieght.Enabled = false;
            this.chkIsFrieght.ForeColor = System.Drawing.Color.Red;
            this.chkIsFrieght.Location = new System.Drawing.Point(617, 95);
            this.chkIsFrieght.Name = "chkIsFrieght";
            this.chkIsFrieght.Size = new System.Drawing.Size(275, 27);
            this.chkIsFrieght.TabIndex = 12;
            this.chkIsFrieght.Text = "Frieght Charge Applicable";
            this.chkIsFrieght.UseVisualStyleBackColor = true;
            // 
            // txtBillNo
            // 
            this.txtBillNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBillNo.Location = new System.Drawing.Point(201, 8);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(226, 30);
            this.txtBillNo.TabIndex = 13;
            this.txtBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBillNo_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(927, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCompany.DataSource = this.companyBindingSource;
            this.cboCompany.DisplayMember = "com_name";
            this.cboCompany.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(1055, 7);
            this.cboCompany.Margin = new System.Windows.Forms.Padding(6);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(150, 31);
            this.cboCompany.TabIndex = 15;
            this.cboCompany.ValueMember = "com_id";
            this.cboCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCompany_KeyDown);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(standard.classes.company);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(927, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "City";
            this.label2.Visible = false;
            // 
            // cboCity
            // 
            this.cboCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCity.DataSource = this.ledgermasterCityBindingSource;
            this.cboCity.DisplayMember = "led_address2";
            this.cboCity.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(1055, 53);
            this.cboCity.Margin = new System.Windows.Forms.Padding(6);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(150, 31);
            this.cboCity.TabIndex = 4;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.Visible = false;
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label8.Location = new System.Drawing.Point(1235, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "Agent";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cboAgent
            // 
            this.cboAgent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboAgent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAgent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgent.DataSource = this.ledgermasterBindingSource1;
            this.cboAgent.DisplayMember = "led_name";
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(1355, 7);
            this.cboAgent.Margin = new System.Windows.Forms.Padding(6);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(150, 31);
            this.cboAgent.TabIndex = 17;
            this.cboAgent.ValueMember = "led_id";
            this.cboAgent.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cboAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboAgent_KeyDown);
            // 
            // ledgermasterBindingSource1
            // 
            this.ledgermasterBindingSource1.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // tablecmd
            // 
            this.tablecmd.ColumnCount = 5;
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tablecmd.Controls.Add(this.cmdsave, 1, 0);
            this.tablecmd.Controls.Add(this.cmdrefresh, 2, 0);
            this.tablecmd.Controls.Add(this.cmdclose, 4, 0);
            this.tablecmd.Controls.Add(this.cmdview, 3, 0);
            this.tablecmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablecmd.Location = new System.Drawing.Point(8, 659);
            this.tablecmd.Margin = new System.Windows.Forms.Padding(6);
            this.tablecmd.Name = "tablecmd";
            this.tablecmd.RowCount = 1;
            this.tablecmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.Size = new System.Drawing.Size(1655, 52);
            this.tablecmd.TabIndex = 3;
            // 
            // cmdsave
            // 
            this.cmdsave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdsave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdsave.Location = new System.Drawing.Point(1021, 6);
            this.cmdsave.Margin = new System.Windows.Forms.Padding(6);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(148, 40);
            this.cmdsave.TabIndex = 0;
            this.cmdsave.Text = "&Save";
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // cmdrefresh
            // 
            this.cmdrefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdrefresh.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdrefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdrefresh.Location = new System.Drawing.Point(1181, 6);
            this.cmdrefresh.Margin = new System.Windows.Forms.Padding(6);
            this.cmdrefresh.Name = "cmdrefresh";
            this.cmdrefresh.Size = new System.Drawing.Size(148, 40);
            this.cmdrefresh.TabIndex = 1;
            this.cmdrefresh.Text = "&Refresh";
            this.cmdrefresh.UseVisualStyleBackColor = true;
            this.cmdrefresh.Click += new System.EventHandler(this.cmdrefresh_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1501, 6);
            this.cmdclose.Margin = new System.Windows.Forms.Padding(6);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(148, 40);
            this.cmdclose.TabIndex = 3;
            this.cmdclose.Text = "&Close";
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // cmdview
            // 
            this.cmdview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdview.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdview.Location = new System.Drawing.Point(1341, 6);
            this.cmdview.Margin = new System.Windows.Forms.Padding(6);
            this.cmdview.Name = "cmdview";
            this.cmdview.Size = new System.Drawing.Size(148, 40);
            this.cmdview.TabIndex = 2;
            this.cmdview.Text = "&View";
            this.cmdview.UseVisualStyleBackColor = true;
            this.cmdview.Click += new System.EventHandler(this.cmdview_Click);
            // 
            // tablesum
            // 
            this.tablesum.ColumnCount = 8;
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 224F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablesum.Controls.Add(this.lblnetamt, 4, 1);
            this.tablesum.Controls.Add(this.txttotamt, 5, 1);
            this.tablesum.Controls.Add(this.txttotqty, 5, 0);
            this.tablesum.Controls.Add(this.lbltotqty, 4, 0);
            this.tablesum.Controls.Add(this.lblDiscountPer, 0, 1);
            this.tablesum.Controls.Add(this.lblFrieght, 0, 0);
            this.tablesum.Controls.Add(this.txtFrieght, 1, 0);
            this.tablesum.Controls.Add(this.lblDiscountRate, 2, 0);
            this.tablesum.Controls.Add(this.txtDiscountRate, 3, 0);
            this.tablesum.Controls.Add(this.txtWages, 3, 1);
            this.tablesum.Controls.Add(this.txtDiscountPercentage, 1, 1);
            this.tablesum.Controls.Add(this.label3, 2, 1);
            this.tablesum.Controls.Add(this.label7, 6, 0);
            this.tablesum.Controls.Add(this.txttottax, 7, 0);
            this.tablesum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesum.Location = new System.Drawing.Point(8, 557);
            this.tablesum.Margin = new System.Windows.Forms.Padding(6);
            this.tablesum.Name = "tablesum";
            this.tablesum.RowCount = 2;
            this.tablesum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablesum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablesum.Size = new System.Drawing.Size(1655, 88);
            this.tablesum.TabIndex = 2;
            // 
            // lblnetamt
            // 
            this.lblnetamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblnetamt.AutoSize = true;
            this.lblnetamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblnetamt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblnetamt.Location = new System.Drawing.Point(811, 54);
            this.lblnetamt.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblnetamt.Name = "lblnetamt";
            this.lblnetamt.Size = new System.Drawing.Size(125, 23);
            this.lblnetamt.TabIndex = 8;
            this.lblnetamt.Text = "Net Amount";
            // 
            // txttotamt
            // 
            this.txttotamt.AllowFormat = false;
            this.txttotamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttotamt.BackColor = System.Drawing.Color.White;
            this.txttotamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotamt.DecimalPlaces = 2;
            this.txttotamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txttotamt.Location = new System.Drawing.Point(979, 51);
            this.txttotamt.Margin = new System.Windows.Forms.Padding(6);
            this.txttotamt.Name = "txttotamt";
            this.txttotamt.ReadOnly = true;
            this.txttotamt.RightAlign = true;
            this.txttotamt.Size = new System.Drawing.Size(193, 30);
            this.txttotamt.TabIndex = 6;
            this.txttotamt.TabStop = false;
            this.txttotamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotamt.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txttotqty
            // 
            this.txttotqty.AllowFormat = false;
            this.txttotqty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttotqty.BackColor = System.Drawing.Color.White;
            this.txttotqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotqty.DecimalPlaces = 2;
            this.txttotqty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txttotqty.Location = new System.Drawing.Point(979, 7);
            this.txttotqty.Margin = new System.Windows.Forms.Padding(6);
            this.txttotqty.Name = "txttotqty";
            this.txttotqty.ReadOnly = true;
            this.txttotqty.RightAlign = true;
            this.txttotqty.Size = new System.Drawing.Size(193, 30);
            this.txttotqty.TabIndex = 5;
            this.txttotqty.TabStop = false;
            this.txttotqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotqty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lbltotqty
            // 
            this.lbltotqty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotqty.AutoSize = true;
            this.lbltotqty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbltotqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltotqty.Location = new System.Drawing.Point(811, 10);
            this.lbltotqty.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbltotqty.Name = "lbltotqty";
            this.lbltotqty.Size = new System.Drawing.Size(99, 23);
            this.lbltotqty.TabIndex = 2;
            this.lbltotqty.Text = "Total Qty";
            // 
            // lblDiscountPer
            // 
            this.lblDiscountPer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscountPer.AutoSize = true;
            this.lblDiscountPer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblDiscountPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblDiscountPer.Location = new System.Drawing.Point(6, 54);
            this.lblDiscountPer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiscountPer.Name = "lblDiscountPer";
            this.lblDiscountPer.Size = new System.Drawing.Size(123, 23);
            this.lblDiscountPer.TabIndex = 9;
            this.lblDiscountPer.Text = "Discount %";
            this.lblDiscountPer.Visible = false;
            // 
            // lblFrieght
            // 
            this.lblFrieght.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrieght.AutoSize = true;
            this.lblFrieght.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrieght.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblFrieght.Location = new System.Drawing.Point(5, 10);
            this.lblFrieght.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFrieght.Name = "lblFrieght";
            this.lblFrieght.Size = new System.Drawing.Size(78, 23);
            this.lblFrieght.TabIndex = 14;
            this.lblFrieght.Text = "Frieght";
            // 
            // txtFrieght
            // 
            this.txtFrieght.AllowFormat = false;
            this.txtFrieght.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFrieght.BackColor = System.Drawing.Color.White;
            this.txtFrieght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFrieght.DecimalPlaces = 2;
            this.txtFrieght.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtFrieght.Location = new System.Drawing.Point(165, 7);
            this.txtFrieght.Margin = new System.Windows.Forms.Padding(6);
            this.txtFrieght.Name = "txtFrieght";
            this.txtFrieght.RightAlign = true;
            this.txtFrieght.Size = new System.Drawing.Size(193, 30);
            this.txtFrieght.TabIndex = 15;
            this.txtFrieght.TabStop = false;
            this.txtFrieght.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFrieght.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFrieght.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFrieght_KeyDown);
            this.txtFrieght.Leave += new System.EventHandler(this.txtFrieght_Leave);
            // 
            // lblDiscountRate
            // 
            this.lblDiscountRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiscountRate.AutoSize = true;
            this.lblDiscountRate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblDiscountRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblDiscountRate.Location = new System.Drawing.Point(377, 10);
            this.lblDiscountRate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiscountRate.Name = "lblDiscountRate";
            this.lblDiscountRate.Size = new System.Drawing.Size(144, 23);
            this.lblDiscountRate.TabIndex = 10;
            this.lblDiscountRate.Text = "Discount Rate";
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.AllowFormat = false;
            this.txtDiscountRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiscountRate.BackColor = System.Drawing.Color.White;
            this.txtDiscountRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountRate.DecimalPlaces = 2;
            this.txtDiscountRate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscountRate.Location = new System.Drawing.Point(601, 7);
            this.txtDiscountRate.Margin = new System.Windows.Forms.Padding(6);
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.RightAlign = true;
            this.txtDiscountRate.Size = new System.Drawing.Size(193, 30);
            this.txtDiscountRate.TabIndex = 12;
            this.txtDiscountRate.TabStop = false;
            this.txtDiscountRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountRate.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscountRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscountRate_KeyDown);
            this.txtDiscountRate.Leave += new System.EventHandler(this.txtDiscountRate_Leave);
            // 
            // txtWages
            // 
            this.txtWages.AllowFormat = false;
            this.txtWages.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtWages.BackColor = System.Drawing.Color.White;
            this.txtWages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWages.DecimalPlaces = 2;
            this.txtWages.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtWages.Location = new System.Drawing.Point(601, 51);
            this.txtWages.Margin = new System.Windows.Forms.Padding(6);
            this.txtWages.Name = "txtWages";
            this.txtWages.RightAlign = true;
            this.txtWages.Size = new System.Drawing.Size(193, 30);
            this.txtWages.TabIndex = 16;
            this.txtWages.TabStop = false;
            this.txtWages.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWages.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWages_KeyDown);
            this.txtWages.Leave += new System.EventHandler(this.txtWages_Leave);
            // 
            // txtDiscountPercentage
            // 
            this.txtDiscountPercentage.AllowFormat = false;
            this.txtDiscountPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiscountPercentage.BackColor = System.Drawing.Color.White;
            this.txtDiscountPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountPercentage.DecimalPlaces = 2;
            this.txtDiscountPercentage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscountPercentage.Location = new System.Drawing.Point(165, 51);
            this.txtDiscountPercentage.Margin = new System.Windows.Forms.Padding(6);
            this.txtDiscountPercentage.Name = "txtDiscountPercentage";
            this.txtDiscountPercentage.ReadOnly = true;
            this.txtDiscountPercentage.RightAlign = true;
            this.txtDiscountPercentage.Size = new System.Drawing.Size(193, 30);
            this.txtDiscountPercentage.TabIndex = 11;
            this.txtDiscountPercentage.TabStop = false;
            this.txtDiscountPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountPercentage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscountPercentage.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(376, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Wages";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label7.Location = new System.Drawing.Point(1185, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Total Tax";
            // 
            // txttottax
            // 
            this.txttottax.AllowFormat = false;
            this.txttottax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttottax.BackColor = System.Drawing.Color.White;
            this.txttottax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttottax.DecimalPlaces = 2;
            this.txttottax.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txttottax.Location = new System.Drawing.Point(1356, 7);
            this.txttottax.Margin = new System.Windows.Forms.Padding(6);
            this.txttottax.Name = "txttottax";
            this.txttottax.ReadOnly = true;
            this.txttottax.RightAlign = true;
            this.txttottax.Size = new System.Drawing.Size(193, 30);
            this.txttottax.TabIndex = 18;
            this.txttottax.TabStop = false;
            this.txttottax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttottax.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pnlentry
            // 
            this.pnlentry.Controls.Add(this.dgvPurchase);
            this.pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlentry.Location = new System.Drawing.Point(8, 199);
            this.pnlentry.Margin = new System.Windows.Forms.Padding(6);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.Size = new System.Drawing.Size(1655, 344);
            this.pnlentry.TabIndex = 1;
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToDeleteRows = false;
            this.dgvPurchase.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.dgvPurchase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchase.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSNo,
            this.cCategory,
            this.cItemName,
            this.cQty,
            this.cRate,
            this.cTaxPercentage,
            this.cTaxAmount,
            this.cItemUnitValue,
            this.cItemUnit,
            this.cFrieghtCharge,
            this.cAmount,
            this.cCatID,
            this.cItemID,
            this.cMrp});
            this.dgvPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchase.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchase.Margin = new System.Windows.Forms.Padding(6);
            this.dgvPurchase.MultiSelect = false;
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.dgvPurchase.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPurchase.ShowCellToolTips = false;
            this.dgvPurchase.Size = new System.Drawing.Size(1655, 344);
            this.dgvPurchase.TabIndex = 1;
            this.dgvPurchase.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgopen_CellEndEdit);
            this.dgvPurchase.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPurchase_EditingControlShowing);
            this.dgvPurchase.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgopen_RowsAdded);
            this.dgvPurchase.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgopen_RowsRemoved);
            this.dgvPurchase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgopen_KeyDown);
            // 
            // cSNo
            // 
            this.cSNo.HeaderText = "SNO";
            this.cSNo.Name = "cSNo";
            this.cSNo.ReadOnly = true;
            this.cSNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cSNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cSNo.Width = 55;
            // 
            // cCategory
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCategory.DefaultCellStyle = dataGridViewCellStyle3;
            this.cCategory.HeaderText = "CATEGORY";
            this.cCategory.Name = "cCategory";
            this.cCategory.Width = 150;
            // 
            // cItemName
            // 
            this.cItemName.HeaderText = "ITEM NAME";
            this.cItemName.Name = "cItemName";
            this.cItemName.Width = 300;
            // 
            // cQty
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.cQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.cQty.HeaderText = "QTY";
            this.cQty.MaxInputLength = 8;
            this.cQty.Name = "cQty";
            this.cQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cQty.Width = 150;
            // 
            // cRate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0.00";
            this.cRate.DefaultCellStyle = dataGridViewCellStyle5;
            this.cRate.HeaderText = "RATE";
            this.cRate.MaxInputLength = 10;
            this.cRate.Name = "cRate";
            this.cRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cRate.Width = 150;
            // 
            // cTaxPercentage
            // 
            this.cTaxPercentage.HeaderText = "Tax %";
            this.cTaxPercentage.Name = "cTaxPercentage";
            this.cTaxPercentage.ReadOnly = true;
            // 
            // cTaxAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cTaxAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.cTaxAmount.HeaderText = "Tax Amount";
            this.cTaxAmount.Name = "cTaxAmount";
            this.cTaxAmount.ReadOnly = true;
            this.cTaxAmount.Width = 150;
            // 
            // cItemUnitValue
            // 
            this.cItemUnitValue.HeaderText = "UNIT VALUE";
            this.cItemUnitValue.Name = "cItemUnitValue";
            this.cItemUnitValue.ReadOnly = true;
            // 
            // cItemUnit
            // 
            this.cItemUnit.HeaderText = "UNIT";
            this.cItemUnit.Name = "cItemUnit";
            this.cItemUnit.ReadOnly = true;
            // 
            // cFrieghtCharge
            // 
            this.cFrieghtCharge.HeaderText = "FRIEGHT CHARGE";
            this.cFrieghtCharge.Name = "cFrieghtCharge";
            this.cFrieghtCharge.ReadOnly = true;
            this.cFrieghtCharge.Visible = false;
            // 
            // cAmount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0.00";
            this.cAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.cAmount.HeaderText = "AMOUNT";
            this.cAmount.Name = "cAmount";
            this.cAmount.ReadOnly = true;
            this.cAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cAmount.Width = 150;
            // 
            // cCatID
            // 
            this.cCatID.HeaderText = "CatID";
            this.cCatID.Name = "cCatID";
            this.cCatID.Visible = false;
            // 
            // cItemID
            // 
            this.cItemID.HeaderText = "ItemID";
            this.cItemID.Name = "cItemID";
            this.cItemID.Visible = false;
            // 
            // cMrp
            // 
            dataGridViewCellStyle8.Format = "N2";
            this.cMrp.DefaultCellStyle = dataGridViewCellStyle8;
            this.cMrp.HeaderText = "MRP";
            this.cMrp.Name = "cMrp";
            this.cMrp.Visible = false;
            this.cMrp.Width = 150;
            // 
            // tableview
            // 
            this.tableview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableview.ColumnCount = 1;
            this.tableview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.Controls.Add(this.dglist, 0, 2);
            this.tableview.Controls.Add(this.lblsubtitle, 0, 0);
            this.tableview.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableview.Location = new System.Drawing.Point(0, 0);
            this.tableview.Margin = new System.Windows.Forms.Padding(6);
            this.tableview.Name = "tableview";
            this.tableview.RowCount = 4;
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableview.Size = new System.Drawing.Size(1671, 719);
            this.tableview.TabIndex = 0;
            // 
            // dglist
            // 
            this.dglist.AllowUserToAddRows = false;
            this.dglist.AllowUserToDeleteRows = false;
            this.dglist.AllowUserToResizeRows = false;
            this.dglist.AutoGenerateColumns = false;
            this.dglist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dglist.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ldelete,
            this.ledit,
            this.lprint,
            this.pmnoDataGridViewTextBoxColumn,
            this.pmdateDataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.pmtotqtyDataGridViewTextBoxColumn,
            this.pmtotamountDataGridViewTextBoxColumn,
            this.ledidDataGridViewTextBoxColumn,
            this.comnameDataGridViewTextBoxColumn,
            this.usersuidDataGridViewTextBoxColumn,
            this.usersnameDataGridViewTextBoxColumn,
            this.pmudateDataGridViewTextBoxColumn,
            this.lImport,
            this.isImport,
            this.pmdescDataGridViewTextBoxColumn,
            this.comidDataGridViewTextBoxColumn,
            this.pmidDataGridViewTextBoxColumn});
            this.dglist.DataSource = this.usppurchasemasterSelectResultBindingSource;
            this.dglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglist.Location = new System.Drawing.Point(8, 165);
            this.dglist.Margin = new System.Windows.Forms.Padding(6);
            this.dglist.MultiSelect = false;
            this.dglist.Name = "dglist";
            this.dglist.ReadOnly = true;
            this.dglist.RowHeadersVisible = false;
            this.dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dglist.ShowCellToolTips = false;
            this.dglist.Size = new System.Drawing.Size(1655, 526);
            this.dglist.TabIndex = 1;
            this.dglist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglist_CellContentClick);
            this.dglist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglist_CellDoubleClick);
            this.dglist.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dglist_CellFormatting);
            this.dglist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgList_KeyDown);
            // 
            // ldelete
            // 
            this.ldelete.HeaderText = "DELETE";
            this.ldelete.Image = global::standard.Properties.Resources.delete;
            this.ldelete.Name = "ldelete";
            this.ldelete.ReadOnly = true;
            this.ldelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ldelete.Width = 75;
            // 
            // ledit
            // 
            this.ledit.HeaderText = "EDIT";
            this.ledit.Image = global::standard.Properties.Resources.edit;
            this.ledit.Name = "ledit";
            this.ledit.ReadOnly = true;
            this.ledit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ledit.Width = 65;
            // 
            // lprint
            // 
            this.lprint.HeaderText = "PRINT";
            this.lprint.Image = global::standard.Properties.Resources.print;
            this.lprint.Name = "lprint";
            this.lprint.ReadOnly = true;
            this.lprint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lprint.Width = 65;
            // 
            // pmnoDataGridViewTextBoxColumn
            // 
            this.pmnoDataGridViewTextBoxColumn.DataPropertyName = "pm_billno";
            this.pmnoDataGridViewTextBoxColumn.HeaderText = "Bill No";
            this.pmnoDataGridViewTextBoxColumn.Name = "pmnoDataGridViewTextBoxColumn";
            this.pmnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmnoDataGridViewTextBoxColumn.Width = 150;
            // 
            // pmdateDataGridViewTextBoxColumn
            // 
            this.pmdateDataGridViewTextBoxColumn.DataPropertyName = "pm_date";
            this.pmdateDataGridViewTextBoxColumn.HeaderText = "Bill Date";
            this.pmdateDataGridViewTextBoxColumn.Name = "pmdateDataGridViewTextBoxColumn";
            this.pmdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmdateDataGridViewTextBoxColumn.Width = 120;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Supplier";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 300;
            // 
            // pmtotqtyDataGridViewTextBoxColumn
            // 
            this.pmtotqtyDataGridViewTextBoxColumn.DataPropertyName = "pm_totqty";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "N0";
            this.pmtotqtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.pmtotqtyDataGridViewTextBoxColumn.HeaderText = "Total Qty";
            this.pmtotqtyDataGridViewTextBoxColumn.Name = "pmtotqtyDataGridViewTextBoxColumn";
            this.pmtotqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmtotqtyDataGridViewTextBoxColumn.Width = 200;
            // 
            // pmtotamountDataGridViewTextBoxColumn
            // 
            this.pmtotamountDataGridViewTextBoxColumn.DataPropertyName = "pm_totamount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.pmtotamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.pmtotamountDataGridViewTextBoxColumn.HeaderText = "Total Amount";
            this.pmtotamountDataGridViewTextBoxColumn.Name = "pmtotamountDataGridViewTextBoxColumn";
            this.pmtotamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmtotamountDataGridViewTextBoxColumn.Width = 200;
            // 
            // ledidDataGridViewTextBoxColumn
            // 
            this.ledidDataGridViewTextBoxColumn.DataPropertyName = "led_id";
            this.ledidDataGridViewTextBoxColumn.HeaderText = "led_id";
            this.ledidDataGridViewTextBoxColumn.Name = "ledidDataGridViewTextBoxColumn";
            this.ledidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledidDataGridViewTextBoxColumn.Visible = false;
            // 
            // comnameDataGridViewTextBoxColumn
            // 
            this.comnameDataGridViewTextBoxColumn.DataPropertyName = "com_name";
            this.comnameDataGridViewTextBoxColumn.HeaderText = "com_name";
            this.comnameDataGridViewTextBoxColumn.Name = "comnameDataGridViewTextBoxColumn";
            this.comnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.comnameDataGridViewTextBoxColumn.Visible = false;
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
            // pmudateDataGridViewTextBoxColumn
            // 
            this.pmudateDataGridViewTextBoxColumn.DataPropertyName = "pm_udate";
            this.pmudateDataGridViewTextBoxColumn.HeaderText = "pm_udate";
            this.pmudateDataGridViewTextBoxColumn.Name = "pmudateDataGridViewTextBoxColumn";
            this.pmudateDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmudateDataGridViewTextBoxColumn.Visible = false;
            // 
            // lImport
            // 
            this.lImport.HeaderText = "IMPORT";
            this.lImport.Image = global::standard.Properties.Resources.Export;
            this.lImport.Name = "lImport";
            this.lImport.ReadOnly = true;
            this.lImport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lImport.Width = 150;
            // 
            // isImport
            // 
            this.isImport.DataPropertyName = "pm_isimport";
            this.isImport.HeaderText = "IMPORT STATUS";
            this.isImport.Name = "isImport";
            this.isImport.ReadOnly = true;
            this.isImport.Width = 160;
            // 
            // pmdescDataGridViewTextBoxColumn
            // 
            this.pmdescDataGridViewTextBoxColumn.DataPropertyName = "pm_desc";
            this.pmdescDataGridViewTextBoxColumn.HeaderText = "pm_desc";
            this.pmdescDataGridViewTextBoxColumn.Name = "pmdescDataGridViewTextBoxColumn";
            this.pmdescDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmdescDataGridViewTextBoxColumn.Visible = false;
            // 
            // comidDataGridViewTextBoxColumn
            // 
            this.comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
            this.comidDataGridViewTextBoxColumn.HeaderText = "com_id";
            this.comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
            this.comidDataGridViewTextBoxColumn.ReadOnly = true;
            this.comidDataGridViewTextBoxColumn.Visible = false;
            // 
            // pmidDataGridViewTextBoxColumn
            // 
            this.pmidDataGridViewTextBoxColumn.DataPropertyName = "pm_id";
            this.pmidDataGridViewTextBoxColumn.HeaderText = "pm_id";
            this.pmidDataGridViewTextBoxColumn.Name = "pmidDataGridViewTextBoxColumn";
            this.pmidDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmidDataGridViewTextBoxColumn.Visible = false;
            // 
            // usppurchasemasterSelectResultBindingSource
            // 
            this.usppurchasemasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_purchasemasterSelectResult);
            // 
            // lblsubtitle
            // 
            this.lblsubtitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblsubtitle.AutoSize = true;
            this.lblsubtitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblsubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblsubtitle.Location = new System.Drawing.Point(8, 16);
            this.lblsubtitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblsubtitle.Name = "lblsubtitle";
            this.lblsubtitle.Size = new System.Drawing.Size(165, 23);
            this.lblsubtitle.TabIndex = 4;
            this.lblsubtitle.Text = "PURCHASE LIST";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblBillNo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtptdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblfdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblhyp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpfdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchBillNo, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdexit, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboSupplierView, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdList, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblImportDate, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.importDate, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.importButton, 10, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1661, 95);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblBillNo
            // 
            this.lblBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblBillNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblBillNo.Location = new System.Drawing.Point(444, 12);
            this.lblBillNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(68, 23);
            this.lblBillNo.TabIndex = 35;
            this.lblBillNo.Text = "BillNo";
            // 
            // dtptdate
            // 
            this.dtptdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtptdate.CustomFormat = "dd-MM-yyyy";
            this.dtptdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtptdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptdate.Location = new System.Drawing.Point(285, 8);
            this.dtptdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(149, 30);
            this.dtptdate.TabIndex = 1;
            this.dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // lblfdate
            // 
            this.lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfdate.AutoSize = true;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(4, 12);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(54, 23);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            // 
            // lblhyp
            // 
            this.lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhyp.AutoSize = true;
            this.lblhyp.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblhyp.Location = new System.Drawing.Point(263, 14);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(14, 18);
            this.lblhyp.TabIndex = 1;
            this.lblhyp.Text = "-";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(640, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 23);
            this.label6.TabIndex = 31;
            this.label6.Text = "Supplier";
            // 
            // dtpfdate
            // 
            this.dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(96, 8);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(159, 30);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // txtSearchBillNo
            // 
            this.txtSearchBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchBillNo.Location = new System.Drawing.Point(548, 8);
            this.txtSearchBillNo.Name = "txtSearchBillNo";
            this.txtSearchBillNo.Size = new System.Drawing.Size(85, 30);
            this.txtSearchBillNo.TabIndex = 34;
            this.txtSearchBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBillNo_KeyDown);
            // 
            // cmdexit
            // 
            this.cmdexit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(905, 48);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(115, 45);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // cboSupplierView
            // 
            this.cboSupplierView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboSupplierView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplierView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cboSupplierView, 3);
            this.cboSupplierView.DataSource = this.ledgermasterViewBindingSource;
            this.cboSupplierView.DisplayMember = "led_name";
            this.cboSupplierView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboSupplierView.FormattingEnabled = true;
            this.cboSupplierView.Location = new System.Drawing.Point(740, 8);
            this.cboSupplierView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cboSupplierView.Name = "cboSupplierView";
            this.cboSupplierView.Size = new System.Drawing.Size(329, 31);
            this.cboSupplierView.TabIndex = 36;
            this.cboSupplierView.ValueMember = "led_id";
            // 
            // ledgermasterViewBindingSource
            // 
            this.ledgermasterViewBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // cmdList
            // 
            this.cmdList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(762, 48);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(115, 45);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // lblImportDate
            // 
            this.lblImportDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblImportDate.Location = new System.Drawing.Point(1192, 11);
            this.lblImportDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportDate.Name = "lblImportDate";
            this.lblImportDate.Size = new System.Drawing.Size(142, 25);
            this.lblImportDate.TabIndex = 30;
            this.lblImportDate.Text = "Import Date";
            // 
            // importDate
            // 
            this.importDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.importDate.CustomFormat = "dd-MM-yyyy";
            this.importDate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.importDate.Location = new System.Drawing.Point(1355, 7);
            this.importDate.Margin = new System.Windows.Forms.Padding(0);
            this.importDate.Name = "importDate";
            this.importDate.Size = new System.Drawing.Size(159, 33);
            this.importDate.TabIndex = 1;
            this.importDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // importButton
            // 
            this.importButton.BackColor = System.Drawing.Color.Red;
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.ForeColor = System.Drawing.Color.White;
            this.importButton.Location = new System.Drawing.Point(1525, 3);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(100, 40);
            this.importButton.TabIndex = 16;
            this.importButton.Text = "Tally Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.ImportTodaysPurchasesToTally);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(4, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "City";
            // 
            // cboCityView
            // 
            this.cboCityView.Location = new System.Drawing.Point(0, 0);
            this.cboCityView.Name = "cboCityView";
            this.cboCityView.Size = new System.Drawing.Size(121, 21);
            this.cboCityView.TabIndex = 0;
            // 
            // ledgermasteCityViewrBindingSource
            // 
            this.ledgermasteCityViewrBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // pnlview
            // 
            this.pnlview.Controls.Add(this.tableview);
            this.pnlview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlview.Enabled = false;
            this.pnlview.Location = new System.Drawing.Point(0, 0);
            this.pnlview.Margin = new System.Windows.Forms.Padding(6);
            this.pnlview.Name = "pnlview";
            this.pnlview.Size = new System.Drawing.Size(1671, 719);
            this.pnlview.TabIndex = 12;
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1671, 719);
            this.Controls.Add(this.tablemain);
            this.Controls.Add(this.pnlview);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmPurchase";
            this.ShowInTaskbar = false;
            this.Tag = "TRANSACTION";
            this.Text = "PURCHASE";
            this.Load += new System.EventHandler(this.frmAmType_Load);
            this.tablemain.ResumeLayout(false);
            this.tablemain.PerformLayout();
            this.tableentry.ResumeLayout(false);
            this.tableentry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource1)).EndInit();
            this.tablecmd.ResumeLayout(false);
            this.tablesum.ResumeLayout(false);
            this.tablesum.PerformLayout();
            this.pnlentry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.tableview.ResumeLayout(false);
            this.tableview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usppurchasemasterSelectResultBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).EndInit();
            this.pnlview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //private void txtDiscountRate_Leave(object sender, EventArgs e)
        //{
        //    if (txtDiscountRate.Text != null && !(txtDiscountRate.Text == string.Empty) && Convert.ToDecimal(txtDiscountRate.Text) > 0m)
        //    {
        //        List<string> list = new List<string>();
        //        list.Add("cQty");
        //        list.Add("cAmount");
        //        List<decimal> totalSNo = bus.getTotalSNo(dgvPurchase, "cSNo", list);
        //        txtDiscountPercentage.Text = "0";
        //        decimal d1 = totalSNo[1];
        //        decimal num = txtDiscountRate.Value / d1 * 100m;
        //        txtDiscountPercentage.Text = $"{num:0.00}";

        //        txttotamt.Text = $"{d1 - txtDiscountRate.Value:0.00}";
        //        cmdsave.Focus();
        //    }
        //}

        //private void txtDiscountPercentage_Leave(object sender, EventArgs e)
        //{
        //    if (txtDiscountPercentage.Tag == null)
        //    {
        //        if (txtDiscountPercentage.Value > 100m)
        //        {
        //            txtDiscountPercentage.Text = "0";
        //        }
        //        else
        //        {
        //            calacTotal();
        //        }
        //    }
        //}

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                dtppurdate.Focus();
            }
        }


        private void txtFrieght_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                calacTotal();
            }
        }

        private void txtWages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                calacTotal();
            }
        }

        private void txtDiscountRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                calacTotal();
            }
        }

        private void txtFrieght_Leave(object sender, EventArgs e)
        {
            calacTotal();
        }

        private void txtWages_Leave(object sender, EventArgs e)
        {
            calacTotal();
        }

        private void txtDiscountRate_Leave(object sender, EventArgs e)
        {
            calacTotal();
        }

        private void cboCompany_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Return && cbopurfrom.Text.Trim() != string.Empty)
            {
                cboAgent.Focus();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableentry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboAgent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                dgvPurchase.CurrentCell = dgvPurchase["cCategory", 0];
                dgvPurchase.Focus();
            }
        }

        //private void cboCity_SelectedValueChanged_1(object sender, EventArgs e)
        //{
        //    InventoryDataContext inventoryDataContext = new InventoryDataContext();
        //    if (cboCity.SelectedItem != null)
        //    {
        //        using (inventoryDataContext)
        //        {
        //            ledgermasterBindingSource.Clear();
        //            var source = from a in inventoryDataContext.ledgermasters
        //                         where a.led_accounttype == "Supplier" && a.led_address2 == cboCity.Text.ToString()
        //                         select new
        //                         {
        //                             a.led_id,
        //                             a.led_name
        //                         };
        //            ledgermasterBindingSource.DataSource = source.OrderBy(x => x.led_name);
        //            cbopurfrom.DataSource = source.OrderBy(x => x.led_name);
        //        }
        //    }
        //}

        //private void txtDiscountPercentage_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Return)
        //    {
        //        cmdsave.Focus();
        //    }
        //}

        //private void txtDiscountRate_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Return)
        //    {
        //        cmdsave.Focus();
        //    }
        //}
    }
}
