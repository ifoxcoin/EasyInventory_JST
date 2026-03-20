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
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace standard.trans
{
    public class frmSales : Form
    {
        private delegate void SetColumnIndex(string colname);

        private long? id;

        private List<usp_stockSelectResult> stockResult = null;

        private frmItemlist objsv;

        private AutoCompleteStringCollection acsItemCode;

        private AutoCompleteStringCollection acsItemName;

        private AutoCompleteStringCollection acsCategoryName;

        private decimal ReceivedAmt = 0m;

        private IContainer components = null;

        private TableLayoutPanel tablemain;

        private Label lbltitle;

        private mygrid dgvSales;

        private TableLayoutPanel tablecmd;

        private lightbutton cmdsave;

        private lightbutton cmdrefresh;

        private lightbutton cmdclose;

        private TableLayoutPanel tablesum;

        private Label lbltotqty;

        private decimalbox txttotqty;

        private Panel pnlentry;

        private decimalbox txttotamt;

        private Label lblnetamt;

        private Label lblPacking;

        private lightbutton cmdview;

        private Panel pnlview;

        private TableLayoutPanel tableview;

        private mygrid dglist;

        private Label lblsubtitle;

        private DataGridViewTextBoxColumn miidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mitrannoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mitrandateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn amnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mitotamtDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn minetamtDataGridViewTextBoxColumn;

        private BindingSource ledgermasterBindingSource;

        private TableLayoutPanel tableentry;

        private Label lblopno;

        private ComboBox cboissueto;

        private Label lbldate;

        private Label lblAddress;

        private DateTimePicker dtpsaldate;

        private Label lblfrom;

        private Label label2;

        private ComboBox cboCity;

        private Label label3;

        private decimalbox txtProfit;

        private Label label4;

        private decimalbox txtopno;

        private BindingSource ledgermasterCityBindingSource;

        private BindingSource uspsalesmasterSelectResultBindingSource;

        private Label lblRateType;

        private BindingSource ledgermasteCityViewrBindingSource;

        private BindingSource companyViewBindingSource;

        private BindingSource ledgermasterViewBindingSource;

        private BindingSource ledgermasterViewBindingSource1;

        private decimalbox txtDisPer;

        private Label label7;

        private decimalbox txtDiscount;

        private DateTimePicker dtptdate;

        private DateTimePicker importDate;

        private lightbutton cmdList;

        private lightbutton cmdexit;

        private Button importButton;

        private Label lblhyp;

        private DateTimePicker dtpfdate;

        private Label lblfdate;

        private ComboBox cboCustomerView;

        private Label label5;

        private ComboBox cboCityView;

        private ComboBox cboCompany;

        private Label label6;

        private TableLayoutPanel tableLayoutPanel1;

        private Label lblCompany;

        private Label lblImportDate;

        private Label lblBillNo;

        private TextBox txtSearchBillNo;

        private DataGridViewImageColumn ldelete;

        private DataGridViewImageColumn lImport;

        private DataGridViewImageColumn ledit;

        private DataGridViewImageColumn lprint;

        private DataGridViewTextBoxColumn isDraft;

        private DataGridViewTextBoxColumn isImport;

        private DataGridViewImageColumn lEstimateprint;

        private DataGridViewImageColumn ldc;

        private DataGridViewTextBoxColumn smidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smbooknoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smrefnoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smdateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn isTaxableDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smtotqtyDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smtotamountDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smdisamountDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smpackingchargeDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smprofitDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smnetamountDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smitemcountDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smudateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn smdescDataGridViewTextBoxColumn;

        private Label lblGSTIN;

        private Label lblTaxPer;

        private Label lblTaxAmt;

        private decimalbox txtTaxPer;

        private decimalbox txtTaxAmt;

        private decimalbox txtnetamt;

        private TableLayoutPanel tableLayoutPanel2;

        private decimalbox txtFinalnetamount;

        private Label txtRoundOff;
        private Label lblFrieght;
        private decimalbox txtFrieght;
        private CheckBox chkIsFrieght;
        private Label lblCom;
        private ComboBox cboCom;
        private BindingSource companyBindingSource;
        private DataGridViewTextBoxColumn cSNo;
        private DataGridViewTextBoxColumn cIsTaxable;
        private DataGridViewTextBoxColumn cCategory;
        private DataGridViewTextBoxColumn cItemName;
        private DataGridViewTextBoxColumn cQty;
        private DataGridViewTextBoxColumn cPerUnitRate;
        private DataGridViewTextBoxColumn cItemUnitType;
        private DataGridViewTextBoxColumn cStock;
        private DataGridViewTextBoxColumn cRate;
        private DataGridViewTextBoxColumn cTaxPercentage;
        private DataGridViewTextBoxColumn cTaxAmount;
        private DataGridViewTextBoxColumn cUnitValue;
        private DataGridViewTextBoxColumn cUnit;
        private DataGridViewTextBoxColumn cFrieghtCharge;
        private DataGridViewTextBoxColumn cAmount;
        private DataGridViewTextBoxColumn cOrderQty;
        private DataGridViewTextBoxColumn cCostRate;
        private DataGridViewTextBoxColumn cCatID;
        private DataGridViewTextBoxColumn cOdID;
        private DataGridViewTextBoxColumn cSdID;
        private DataGridViewTextBoxColumn cItemID;
        private DataGridViewTextBoxColumn cCostAmount;
        private DataGridViewTextBoxColumn cOdUnitValue;
        private Label lblType;
        private ComboBox cboAgent;
        private BindingSource ledgermasterBindingSource1;
        private decimalbox txtothercharges;

        public frmSales()
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
                dtpsaldate.Select();
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
                int r = dgvSales.CurrentCell.RowIndex;
                dgvSales["cItemID", r].Value = objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value;
                dgvSales["cItemName", r].Value = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value;
                global.itemname = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value.ToString();
                global.itemid = Convert.ToInt32(objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value);
                dgvSales["cItemName", r].Value = global.itemname;
                dgvSales["cItemID", r].Value = global.itemid;
                if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    var queryable = from li in inventoryDataContext.items
                                    join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                    where li.item_id == Convert.ToInt32(dgvSales["cItemID", r].Value)
                                    select new
                                    {
                                        cat,
                                        li
                                    };
                    foreach (var item in queryable)
                    {
                        dgvSales["cCostRate", r].Value = item.li.item_costrate;
                        dgvSales["cItemID", r].Value = item.li.item_id;
                        dgvSales["cCategory", r].Value = item.cat.cat_name;
                        dgvSales["cCatId", r].Value = item.cat.cat_id;
                        dgvSales["cTaxPercentage", r].Value = item.li.item_taxpercentage;
                        dgvSales["cUnit", r].Value = item.li.item_unit;
                        dgvSales["cUnitValue", r].Value = item.li.item_quantity;
                        dgvSales["cItemUnitType", r].Value = item.li.item_unittype;
                        if (lblRateType.Text.ToUpper() == "MRP  (D)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_mrp;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_mrp / item.li.item_quantity).ToString("N2") : item.li.item_mrp.ToString("N2");
                        }
                        else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_wholesalerate;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_wholesalerate / item.li.item_quantity).ToString("N2") : item.li.item_wholesalerate.ToString("N2");
                        }
                        else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_specialrate;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_specialrate / item.li.item_quantity).ToString("N2") : item.li.item_specialrate.ToString("N2");
                        }
                        else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_supersepecialrate;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_supersepecialrate / item.li.item_quantity).ToString("N2") : item.li.item_supersepecialrate.ToString("N2");
                        }
                        ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item.li.item_id, null, null, null, null);
                        dgvSales["cStock", r].Value = "0";
                        foreach (usp_stockSelectResult item2 in singleResult)
                        {
                            dgvSales["cStock", r].Value = item2.stock;
                        }
                    }
                }
                dgvSales.CurrentCell = dgvSales.Rows[r].Cells["cQty"];
                dgvSales.Focus();
                objsv.Close();
                dgvSales.CurrentCell = dgvSales["cQty", r];
                dgvSales.Focus();
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
                int r = dgvSales.CurrentCell.RowIndex;
                dgvSales["cItemID", r].Value = objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value;
                dgvSales["cItemName", r].Value = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value;
                global.itemname = objsv.dgview["itemnameDataGridViewTextBoxColumn", rowIndex].Value.ToString();
                global.itemid = Convert.ToInt32(objsv.dgview["itemidDataGridViewTextBoxColumn", rowIndex].Value);
                dgvSales["cItemName", r].Value = global.itemname;
                dgvSales["cItemID", r].Value = global.itemid;
                if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    var queryable = from li in inventoryDataContext.items
                                    join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                    where li.item_id == Convert.ToInt32(dgvSales["cItemID", r].Value)
                                    select new
                                    {
                                        cat,
                                        li
                                    };
                    foreach (var item in queryable)
                    {
                        dgvSales["cCostRate", r].Value = item.li.item_costrate;
                        dgvSales["cItemID", r].Value = item.li.item_id;
                        dgvSales["cCategory", r].Value = item.cat.cat_name;
                        dgvSales["cCatId", r].Value = item.cat.cat_id;
                        dgvSales["cTaxPercentage", r].Value = item.li.item_taxpercentage;
                        dgvSales["cUnit", r].Value = item.li.item_unit;
                        dgvSales["cUnitValue", r].Value = item.li.item_quantity;
                        dgvSales["cItemUnitType", r].Value = item.li.item_unittype;
                        if (lblRateType.Text.ToUpper() == "MRP  (D)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_mrp;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_mrp / item.li.item_quantity).ToString("N2") : item.li.item_mrp.ToString("N2");
                        }
                        else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_wholesalerate;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_wholesalerate / item.li.item_quantity).ToString("N2") : item.li.item_wholesalerate.ToString("N2");
                        }
                        else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_specialrate;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_specialrate / item.li.item_quantity).ToString("N2") : item.li.item_specialrate.ToString("N2");
                        }
                        else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_supersepecialrate;
                            dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_supersepecialrate / item.li.item_quantity).ToString("N2") : item.li.item_supersepecialrate.ToString("N2");
                        }
                        ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item.li.item_id, null, null, null, null);
                        foreach (usp_stockSelectResult item2 in singleResult)
                        {
                            dgvSales["cStock", r].Value = item2.stock;
                        }
                    }
                }
                dgvSales.CurrentCell = dgvSales.Rows[r].Cells["cQty"];
                dgvSales.Focus();
                objsv.Close();
                dgvSales.CurrentCell = dgvSales["cQty", r];
                dgvSales.Focus();
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
            dtpsaldate.MinDate = DateTimePicker.MinimumDateTime;
            dtpsaldate.MaxDate = DateTime.MaxValue; // Or DateTime.Today.AddYears(1)
            dtpsaldate.Value = DateTime.Today;
            dtpfdate.Value = DateTime.Today.AddDays(-30);

            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            using (inventoryDataContext)
            {
                var source = from a in inventoryDataContext.ledgermasters
                             where a.led_accounttype == "Customer" || a.led_id == 0
                             select new
                             {
                                 a.led_id,
                                 led_name = a.led_name + " - " + a.led_address2,
                                 a.led_address2
                             };
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
                ledgermasterViewBindingSource1.DataSource = source.OrderBy(x => x.led_address2);
                ledgermasterCityBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                ledgermasteCityViewrBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                companyViewBindingSource.DataSource = inventoryDataContext.companies.Select((company li) => li);
                companyBindingSource.DataSource = inventoryDataContext.usp_companySelect(null);
                uspsalesmasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesmasterSelect(null, null, null, null, null, null, null);
                long? no = 0L;
                int comId = Convert.ToInt32(cboCom.SelectedValue);
                inventoryDataContext.usp_getYearNo("sal_no", global.sysdate, ref no, comId);
                txtopno.Value = no.Value;
                uspsalesmasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesmasterSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value.Date, dtptdate.Value.Date, null, null, null);
                ledgermasterViewBindingSource.DataSource = source.Select(x => x.led_name).ToList();
                LoadStock();
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

        private void LoadStock()
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            IQueryable<item> queryable = inventoryDataContext.items.Select((item li) => li);
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            foreach (item item in queryable)
            {
                autoCompleteStringCollection.Add(item.item_name);
            }
        }

        private void ClearData()
        {
            cboissueto.Text = string.Empty;
            cboissueto.SelectedIndex = 0;
            cboCom.SelectedIndex = 0;
            dgvSales.Rows.Clear();
            txttotqty.Value = 0m;
            txttotamt.Value = 0m;
            txtnetamt.Value = 0m;
            txtFinalnetamount.Value = 0m;
            txtRoundOff.Text = "0";
            txtDiscount.Value = 0m;
            txtDisPer.Value = 0m;
            txtTaxAmt.Value = 0m;
            txtTaxPer.Value = 0m;
            txtothercharges.Value = 0m;
            txtSearchBillNo.Text = string.Empty;
            chkIsFrieght.Checked = false;
            id = 0L;
            ReceivedAmt = 0m;
            //cboCity.Select();
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            DbTransaction dbTransaction = null;
            item item = null;
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                salesmaster salesmaster = new salesmaster();
                salesdetail salesdetail = new salesdetail();
                salesorderdetail salesorderdetails = new salesorderdetail();
                salesorder salesorder = new salesorder();
                salesmaster.led_id = Convert.ToInt32(cboissueto.SelectedValue);
                //bool IsCommReceived = false;
                //if (id > 0)
                //    IsCommReceived = (bool)inventoryDataContext.usp_getiscommissionceceived(id).SingleOrDefault().isreceived;
                //if (IsCommReceived == true)
                //{
                //    MessageBox.Show("Can't edit commission received bill...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                if (Convert.ToInt64(cboCom.SelectedValue) == 0)
                {
                    MessageBox.Show("Invalid 'Company'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cboCom.Focus();
                    return;
                }
                else
                {
                    salesmaster.com_id = Convert.ToInt64(cboCom.SelectedValue);
                }
                if (salesmaster.led_id == 0)
                {
                    MessageBox.Show("Invalid 'Customer'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cboissueto.Focus();
                    return;
                }
                else
                {
                    List<item> source = inventoryDataContext.items.Select((item itemRow) => itemRow).ToList();
                    foreach (DataGridViewRow dr in (IEnumerable)dgvSales.Rows)
                    {
                        if (!dr.IsNewRow)
                        {
                            item = source.FirstOrDefault(match => match.item_id == Convert.ToInt32(dr.Cells["cItemID"].Value));
                            dr.Cells["cItemID"].Value = (item?.item_id ?? 0);
                            if (Convert.ToInt32(dr.Cells["cItemID"].Value) == 0)
                            {
                                MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                dgvSales.Focus();
                                return;
                            }
                        }
                    }
                    if (dgvSales.RowCount <= 1 && txtothercharges.Value == 0m)
                    {
                        MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvSales.Focus();
                    }
                    if ((ReceivedAmt > 0m))
                    {
                        MessageBox.Show("Can't edit payment received bill...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        salesmaster.sm_totamount = txttotamt.Value;
                        salesmaster.sm_packingcharge = txtothercharges.Value;
                        salesmaster.sm_totqty = decimal.TryParse(txttotqty.Text, out var totQty) ? totQty : 0;
                        salesmaster.sm_netamount = txtFinalnetamount.Value;
                        salesmaster.sm_roundamount = Convert.ToDecimal(txtRoundOff.Text);
                        salesmaster.sm_disamount = txtDiscount.Value;
                        salesmaster.sm_taxamount = txtTaxAmt.Value;
                        foreach (DataGridViewRow dr in dgvSales.Rows)
                        {
                            if (!dr.IsNewRow)
                            {
                                salesmaster.sm_taxpercentage = Convert.ToDecimal(dr.Cells["cTaxPercentage"].Value); // or the actual column name for tax %
                                break;
                            }
                        }
                        salesmaster.sm_istaxable = (salesmaster.sm_taxamount > 0);
                        salesmaster.sm_bookno = "S";
                        salesmaster.sm_date = dtpsaldate.Value;
                        salesmaster.sm_itemcount = dgvSales.Rows.Count - 1;
                        salesmaster.sm_profit = txtProfit.Value;
                        salesmaster.sm_received = ReceivedAmt;
                        salesmaster.com_id = Convert.ToUInt32(cboCom.SelectedValue.ToString());
                        salesmaster.sm_agid = Convert.ToInt64(cboAgent.SelectedValue);
                        if (id == 0)
                        {
                            long? no = 0L;
                            inventoryDataContext.usp_setYearNo("sal_no", global.sysdate, ref no, salesmaster.com_id);
                            salesmaster.sm_refno = Convert.ToInt64(no);
                            inventoryDataContext.usp_salesmasterInsert(ref id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount, salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount, salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount, salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking, salesmaster.sm_roundamount, false, false, global.ucode, global.sysdate, salesmaster.sm_desc, false, true, salesmaster.so_id, salesmaster.com_id, salesmaster.sm_istaxable, false, salesmaster.sm_agid);
                            salesdetail.sm_id = id;
                            foreach (DataGridViewRow item2 in (IEnumerable)dgvSales.Rows)
                            {
                                if (!item2.IsNewRow)
                                {
                                    salesdetail.sd_costrate = Convert.ToDecimal(item2.Cells["cCostRate"].Value);
                                    salesdetail.sd_rate = Convert.ToDecimal(item2.Cells["cRate"].Value);
                                    salesdetail.sd_totamount = Convert.ToDecimal(item2.Cells["cAmount"].Value);
                                    salesdetail.item_id = Convert.ToInt32(item2.Cells["cItemID"].Value);
                                    salesdetail.sd_qty = Convert.ToInt32(item2.Cells["cQty"].Value);
                                    salesdetail.sd_taxpercentage = Convert.ToInt32(item2.Cells["cTaxPercentage"].Value);
                                    salesdetail.sd_taxamount = Convert.ToInt32(item2.Cells["cTaxAmount"].Value);
                                    salesdetail.sd_unit = Convert.ToString(item2.Cells["cUnit"].Value);
                                    salesdetail.sd_unitvalue = Convert.ToDecimal(item2.Cells["cUnitValue"].Value);
                                    salesdetail.sd_itemunittype = Convert.ToString(item2.Cells["cItemUnitType"].Value);
                                    salesdetail.sd_perunitrate = Convert.ToDecimal(item2.Cells["cPerUnitRate"].Value);
                                    decimal? num = Convert.ToDecimal(item2.Cells["cStock"].Value);
                                    salesdetail.sd_totfrieght = Convert.ToDecimal(item2.Cells["cFrieghtCharge"].Value);
                                    inventoryDataContext.usp_salesdetailsInsert(id, salesdetail.item_id, salesdetail.sd_qty, salesdetail.sd_orderqty, salesdetail.sd_rate, salesdetail.sd_costrate, salesdetail.sd_totamount, salesdetail.sd_taxpercentage, salesdetail.sd_taxamount,
                                        salesdetail.sd_unit, salesdetail.sd_unitvalue, salesdetail.sd_itemunittype, salesdetail.sd_totfrieght, salesdetail.sd_perunitrate, salesdetail.sd_odid);
                                    var catid = inventoryDataContext.items.Where(i => i.item_id == salesdetail.item_id).Select(i => i.cat_id).FirstOrDefault();
                                    var comid = inventoryDataContext.items.Where(i => i.item_id == salesdetail.item_id).Select(i => i.com_id).FirstOrDefault();
                                    if (catid == 39)
                                    {
                                        inventoryDataContext.usp_stockInsert(id, "SALES", salesdetail.item_id, comid, 0m, salesdetail.sd_unitvalue, global.sysdate);
                                    }
                                    else
                                    {
                                        inventoryDataContext.usp_stockInsert(id, "SALES", salesdetail.item_id, comid, 0m, salesdetail.sd_qty, global.sysdate);
                                    }
                                }
                            }

                        }
                        else
                        {
                            salesmaster.sm_refno = Convert.ToInt64(txtopno.Value);
                            salesmaster.sm_iscommissionclose = false;
                            salesmaster.sm_ispackingclose = false;
                            salesmaster.sm_desc = "";
                            salesmaster.sm_isclose = false;
                            bool? isDraft = null;
                            salesmaster.sm_agid = Convert.ToInt64(cboAgent.SelectedValue);
                            var smRecord = inventoryDataContext.salesmasters.Where(s => s.sm_id == id).Select(s => new { s.sm_isdraft, s.so_id, s.sm_guid, s.sm_isimport }).FirstOrDefault();
                            if (smRecord != null)
                            {
                                isDraft = smRecord.sm_isdraft;
                                salesmaster.so_id = smRecord.so_id ?? 0;
                                salesmaster.sm_guid = smRecord.sm_guid;
                                salesmaster.sm_isimport = smRecord.sm_isimport;
                            }
                            salesmaster.com_id = Convert.ToUInt32(cboCom.SelectedValue.ToString());
                            inventoryDataContext.usp_salesmasterUpdate(id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount, salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount, salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount, salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking, salesmaster.sm_roundamount, salesmaster.sm_iscommissionclose, salesmaster.sm_ispackingclose, global.ucode, global.sysdate, salesmaster.sm_desc, salesmaster.sm_isclose, true, salesmaster.so_id, salesmaster.com_id, salesmaster.sm_istaxable, salesmaster.sm_isimport, salesmaster.sm_guid, salesmaster.sm_agid);

                            // Step 1: Collect current items and their IsTaxable info from the grid
                            var currentItemIds = new HashSet<int>();
                            var itemTaxableMap = new Dictionary<int, bool>();

                            foreach (DataGridViewRow row in dgvSales.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    int itemId = Convert.ToInt32(row.Cells["cItemID"].Value);
                                    bool isTaxable = Convert.ToBoolean(row.Cells["cIsTaxable"].Value);

                                    currentItemIds.Add(itemId);
                                    itemTaxableMap[itemId] = isTaxable;
                                }
                            }

                            // Step 2: Get existing order details from DB
                            var existingOrderDetails = inventoryDataContext.salesorderdetails
                                .Where(od => od.so_id == salesmaster.so_id && od.com_id == salesmaster.com_id && od.com_id == salesmaster.com_id && od.od_istaxable == salesmaster.sm_istaxable)
                                .ToList();

                            foreach (var orderDetail in existingOrderDetails)
                            {
                                if (!currentItemIds.Contains((int)orderDetail.item_id))
                                {
                                    bool isTaxable = orderDetail.od_istaxable;
                                    int odID = (int)orderDetail.od_id;
                                    inventoryDataContext.usp_salesorderdetailsDelete(orderDetail.so_id, isTaxable, salesmaster.com_id, odID);
                                }
                            }



                            foreach (DataGridViewRow salesorderItem in (IEnumerable)dgvSales.Rows)
                            {
                                if (!salesorderItem.IsNewRow)
                                {
                                    salesdetail.sd_id = Convert.ToInt32(salesorderItem.Cells["cSdID"].Value);
                                    salesdetail.sd_costrate = Convert.ToDecimal(salesorderItem.Cells["cCostRate"].Value);
                                    salesdetail.sd_rate = Convert.ToDecimal(salesorderItem.Cells["cRate"].Value);
                                    salesdetail.sd_totamount = Convert.ToDecimal(salesorderItem.Cells["cAmount"].Value);
                                    salesdetail.item_id = Convert.ToInt32(salesorderItem.Cells["cItemID"].Value);
                                    decimal sd_qty = Convert.ToDecimal(salesorderItem.Cells["cQty"].Value);
                                    salesdetail.sd_odid = Convert.ToInt32(salesorderItem.Cells["cOdID"].Value);
                                    decimal sd_orderqty = Convert.ToDecimal(salesorderItem.Cells["cOrderQty"].Value);
                                    salesdetail.sd_qty = Convert.ToInt32(sd_qty);
                                    salesdetail.sd_unitvalue = Convert.ToDecimal(salesorderItem.Cells["cUnitValue"].Value);
                                    salesdetail.sd_taxpercentage = Convert.ToDecimal(salesorderItem.Cells["cTaxPercentage"].Value);
                                    salesdetail.sd_taxamount = Convert.ToDecimal(salesorderItem.Cells["cTaxAmount"].Value);
                                    salesdetail.sd_unit = Convert.ToString(salesorderItem.Cells["cUnit"].Value);
                                    salesdetail.sd_itemunittype = Convert.ToString(salesorderItem.Cells["cItemUnitType"].Value);
                                    salesdetail.sd_perunitrate = Convert.ToDecimal(salesorderItem.Cells["cPerUnitRate"].Value);
                                    salesorderdetails.od_qty = Convert.ToDecimal(salesorderItem.Cells["cOrderQty"].Value);
                                    salesorderdetails.od_istaxable = Convert.ToBoolean(salesorderItem.Cells["cIsTaxable"].Value);
                                    salesorderdetails.com_id = (int)salesmaster.com_id;
                                    salesorderdetails.od_pendingqty = salesorderdetails.od_qty - salesorderdetails.od_soldqty;
                                    decimal? num = Convert.ToDecimal(salesorderItem.Cells["cQty"].Value);
                                    salesdetail.sd_totfrieght = Convert.ToDecimal(salesorderItem.Cells["cFrieghtCharge"].Value);
                                    salesorderdetails.od_unitvalue = Convert.ToDecimal(salesorderItem.Cells["cOdUnitValue"].Value);

                                    int catID = Convert.ToInt32(salesorderItem.Cells["cCatID"].Value);

                                    if (catID == 39)
                                    {
                                        salesdetail.sd_unitvalue = Convert.ToDecimal(salesorderItem.Cells["cUnitValue"].Value);
                                    }
                                    else
                                    {
                                        salesdetail.sd_unitvalue = Convert.ToDecimal(salesorderItem.Cells["cUnitValue"].Value);
                                    }

                                    if (catID == 39)
                                    {
                                        salesorderdetails.od_soldqty = Convert.ToDecimal(salesorderItem.Cells["cUnitValue"].Value);
                                    }
                                    else
                                    {
                                        salesorderdetails.od_soldqty = Convert.ToDecimal(salesdetail.sd_qty);
                                    }

                                    if (catID == 39)
                                    {
                                        salesorderdetails.od_pendingqty = Math.Max(0, salesorderdetails.od_unitvalue - salesorderdetails.od_soldqty);
                                    }
                                    else
                                    {
                                        salesorderdetails.od_pendingqty = Math.Max(0, salesorderdetails.od_qty - salesorderdetails.od_soldqty);
                                    }

                                    if (salesdetail.sd_qty > salesorderdetails.od_qty)
                                    {
                                        // Take from sales detail
                                        salesdetail.sd_qty = salesdetail.sd_qty;
                                    }
                                    else
                                    {
                                        // Take from order qty
                                        salesdetail.sd_qty = Convert.ToInt32(salesorderdetails.od_qty);
                                    }


                                    var existingOrderDetail = inventoryDataContext.salesorderdetails.Where(od => od.so_id == salesmaster.so_id && od.item_id == salesdetail.item_id && od.com_id == salesmaster.com_id).FirstOrDefault();
                                    if (existingOrderDetail != null)
                                    {
                                        inventoryDataContext.usp_salesorderdetailsUpdate(
                                            existingOrderDetail.od_id,
                                            existingOrderDetail.so_id,
                                            salesdetail.item_id,
                                            salesdetail.sd_qty,
                                            salesdetail.sd_unitvalue,
                                            salesorderdetails.od_soldqty,
                                            salesorderdetails.od_pendingqty,
                                            salesdetail.sd_perunitrate,
                                            salesmaster.com_id,
                                            existingOrderDetail.od_istaxable
                                        );
                                    }
                                    else
                                    {
                                        inventoryDataContext.usp_salesorderdetailsInsert(
                                            salesmaster.so_id,
                                            salesdetail.item_id,
                                            salesdetail.sd_qty,
                                            salesdetail.sd_unitvalue,
                                            salesdetail.sd_qty,
                                            0,
                                            salesdetail.sd_perunitrate,
                                            salesmaster.com_id,
                                            salesorderdetails.od_istaxable
                                        );
                                    }


                                }
                            }


                            inventoryDataContext.usp_salesdetailsDelete(id);
                            inventoryDataContext.usp_stockDelete(id, "SALES");
                            foreach (DataGridViewRow item3 in (IEnumerable)dgvSales.Rows)
                            {
                                if (!item3.IsNewRow)
                                {
                                    salesdetail.sd_id = Convert.ToInt32(item3.Cells["cSdID"].Value);
                                    salesdetail.sd_costrate = Convert.ToDecimal(item3.Cells["cCostRate"].Value);
                                    salesdetail.sd_rate = Convert.ToDecimal(item3.Cells["cRate"].Value);
                                    salesdetail.sd_totamount = Convert.ToDecimal(item3.Cells["cAmount"].Value);
                                    salesdetail.item_id = Convert.ToInt32(item3.Cells["cItemID"].Value);
                                    decimal sd_qty = Convert.ToDecimal(item3.Cells["cQty"].Value);
                                    salesdetail.sd_odid = Convert.ToInt32(item3.Cells["cOdID"].Value);

                                    decimal sd_orderqty = Convert.ToDecimal(item3.Cells["cOrderQty"].Value);
                                    salesdetail.sd_qty = Convert.ToInt32(sd_qty);
                                    salesdetail.sd_orderqty = Convert.ToInt32(sd_orderqty);
                                    salesdetail.sd_unitvalue = Convert.ToDecimal(item3.Cells["cUnitValue"].Value);
                                    salesdetail.sd_taxpercentage = Convert.ToDecimal(item3.Cells["cTaxPercentage"].Value);
                                    salesdetail.sd_taxamount = Convert.ToDecimal(item3.Cells["cTaxAmount"].Value);
                                    salesdetail.sd_unit = Convert.ToString(item3.Cells["cUnit"].Value);
                                    salesdetail.sd_itemunittype = Convert.ToString(item3.Cells["cItemUnitType"].Value);
                                    salesdetail.sd_perunitrate = Convert.ToDecimal(item3.Cells["cPerUnitRate"].Value);
                                    salesorderdetails.od_soldqty = Convert.ToDecimal(salesdetail.sd_qty);
                                    salesorderdetails.od_qty = Convert.ToDecimal(item3.Cells["cOrderQty"].Value);
                                    salesorderdetails.od_pendingqty = salesorderdetails.od_qty - salesorderdetails.od_soldqty;
                                    decimal? num = Convert.ToDecimal(item3.Cells["cQty"].Value);
                                    salesdetail.sd_totfrieght = Convert.ToDecimal(item3.Cells["cFrieghtCharge"].Value);
                                    inventoryDataContext.usp_salesdetailsInsert(id, salesdetail.item_id, salesdetail.sd_qty, salesdetail.sd_orderqty, salesdetail.sd_rate, salesdetail.sd_costrate, salesdetail.sd_totamount, salesdetail.sd_taxpercentage, salesdetail.sd_taxamount, salesdetail.sd_unit, salesdetail.sd_unitvalue, salesdetail.sd_itemunittype, salesdetail.sd_totfrieght, salesdetail.sd_perunitrate, salesdetail.sd_odid);
                                    var catid = inventoryDataContext.items.Where(i => i.item_id == salesdetail.item_id).Select(i => i.cat_id).FirstOrDefault();
                                    var comid = inventoryDataContext.items.Where(i => i.item_id == salesdetail.item_id).Select(i => i.com_id).FirstOrDefault();
                                    if (catid == 39)
                                    {
                                        inventoryDataContext.usp_stockInsert(id, "SALES", salesdetail.item_id, comid, 0m, salesdetail.sd_unitvalue, global.sysdate);
                                    }
                                    else
                                    {
                                        inventoryDataContext.usp_stockInsert(id, "SALES", salesdetail.item_id, comid, 0m, salesdetail.sd_qty, global.sysdate);
                                    }
                                }
                            }

                            bool orderHasPendingItems = false;

                            using (var freshContext = new InventoryDataContext())
                            {
                                var orderDetailsList = freshContext.salesorderdetails
                                                            .Where(od => od.so_id == salesmaster.so_id)
                                                            .ToList();

                                foreach (var od in orderDetailsList)
                                {
                                    if (od.od_pendingqty > 0 || (od.od_soldqty == 0 && od.od_pendingqty == 0))
                                    {
                                        orderHasPendingItems = true;
                                        break;
                                    }
                                }
                            }


                            var salesOrder = inventoryDataContext.salesorders.Where(so => so.so_id == salesmaster.so_id).FirstOrDefault();
                            if (salesOrder != null)
                            {
                                var salesOrderDetailsList = inventoryDataContext.salesorderdetails.Where(od => od.so_id == salesmaster.so_id).ToList();
                                using (var freshContext = new InventoryDataContext())
                                {
                                    decimal totalQty = freshContext.salesorderdetails
                                        .Where(od => od.so_id == salesmaster.so_id)
                                        .Sum(od => od.od_qty);
                                    salesorder.so_totqty = totalQty;
                                    salesorder.so_refno = salesOrder.so_refno;
                                }
                            }
                            else
                            {
                                salesorderdetails.od_id = 0; // or handle accordingly
                            }
                            salesorder.so_status = orderHasPendingItems ? "Partially Converted" : "Fully Converted";
                            inventoryDataContext.usp_salesorderUpdate(salesmaster.so_id, salesorder.so_refno, salesmaster.sm_date, salesmaster.led_id, salesorder.so_totqty, salesorder.so_status, global.ucode, global.sysdate, true);
                        }
                    }
                }
                loadReport(Convert.ToInt32(id));
                //LoadAddressPrint(Convert.ToInt32(cboissueto.SelectedValue));
                ClearData();
                LoadData();
                cboissueto.Focus();

            }
            catch (Exception ex)
            {
                dbTransaction?.Rollback();
                ClearData();
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void LoadAddressPrint(int ledid)
        {
            if (MessageBox.Show("Are you sure to Print Address?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                frmAddressPrint frmAddressPrint = new frmAddressPrint();
                frmAddressPrint.ledgerID = ledid;
                frmAddressPrint.isDirectPrint = true;
                frmAddressPrint.ShowDialog();
            }
        }

        private void cmdrefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadData();
            cboCity.Focus();
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Mymethod(string colname)
        {
            dgvSales.CurrentCell = dgvSales[colname, dgvSales.RowCount - 1];
            dgvSales.BeginEdit(selectAll: true);
            dgvSales.Focus();
        }

        private void dgopen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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
            list.Add("cCostAmount");
            list.Add("cTaxAmount");
            list.Add("cUnit");
            list.Add("cUnitValue");
            list.Add("cItemUnitType");
            list.Add("cFrieghtCharge");
            List<decimal> totalSNo = bus.getTotalSNo(dgvSales, "cSNo", list);
            txttotqty.Value = Convert.ToDecimal(totalSNo[0].ToString("N0"));
            txttotamt.Text = totalSNo[1].ToString("0.00");
            txtFrieght.Text = totalSNo[7].ToString("0.00");
            string d5 = totalSNo[3].ToString("0.00");
            decimal d = totalSNo[2];
            List<decimal> list2 = new List<decimal>();
            list2.Add(txttotamt.Value);
            list2.Add(txtTaxAmt.Value);
            decimal d2 = 0m;
            decimal value = txtDisPer.Value;
            decimal d3 = (txttotamt.Value + d2) * value / 100m;
            txtDiscount.Text = string.Format("{0:0.00}", d3.ToString("N2"));
            txtProfit.Text = $"{txttotamt.Value + d2 - (d + d3):0.00}";
            txtTaxAmt.Text = d5.ToString();
            decimal total = txttotamt.Value + d2 + txtothercharges.Value - d3;
            txtnetamt.Text = $"{Math.Round(total, 0, MidpointRounding.AwayFromZero):0.00}";
            decimal value2 = txtTaxPer.Value;
            decimal d4 = (txtnetamt.Value - txtothercharges.Value) * value2 / 100m;
            //txtnetamt.Text = $"{d4 + txtnetamt.Value:0.00}";
            txtTaxAmt.Text = string.Format("{0:0.00}", txtTaxAmt.Value.ToString("N2"));
            txtFinalnetamount.Text = Math.Round(txtnetamt.Value).ToString();
            txtFinalnetamount.Text = string.Format("{0:0.00}", txtFinalnetamount.Value.ToString("N2"));
            txtothercharges.Text = string.Format("{0:0.00}", txtothercharges.Value.ToString("N2"));
            txtRoundOff.Text = $"{txtFinalnetamount.Value - txtnetamt.Value:0.00}";
            if (txtRoundOff.Text.Contains("-"))
            {
                txtRoundOff.ForeColor = Color.Red;
            }
            else
            {
                txtRoundOff.ForeColor = Color.Green;
            }
        }

        private void dgopen_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvSales.CurrentCell == null)
            {
                return;
            }
            if (dgvSales.CurrentCell.ColumnIndex == 1)
            {
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (!dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(dgvSales.CurrentCell.RowIndex);
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                int r = dgvSales.CurrentCell.RowIndex;
                frmItemlist frmItemlist = new frmItemlist();
                frmItemlist.catid = Convert.ToInt32(dgvSales["cCatID", r].Value);
                frmItemlist.Show();
                string itemname = frmItemlist.itemname;
                int itemID = frmItemlist.itemID;
                try
                {
                    dgvSales["cItemName", r].Value = itemname;
                    if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                    {
                        dgvSales.Rows.RemoveAt(r);
                    }
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    using (inventoryDataContext)
                    {
                        var queryable = from li in inventoryDataContext.items
                                        join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                        where li.item_id == Convert.ToInt32(dgvSales["cItemID", r].Value)
                                        select new
                                        {
                                            cat,
                                            li
                                        };
                        foreach (var item in queryable)
                        {
                            dgvSales["cCostRate", r].Value = item.li.item_costrate;
                            dgvSales["cItemID", r].Value = item.li.item_id;
                            dgvSales["cCategory", r].Value = item.cat.cat_name;
                            dgvSales["cCatId", r].Value = item.cat.cat_id;
                            dgvSales["cTaxPercentage", r].Value = item.li.item_taxpercentage;
                            dgvSales["cUnit", r].Value = item.li.item_unit;
                            dgvSales["cUnitValue", r].Value = item.li.item_quantity;
                            dgvSales["cItemUnitType", r].Value = item.li.item_unittype;
                            if (lblRateType.Text.ToUpper() == "MRP  (D)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_mrp;
                                dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_mrp / item.li.item_quantity).ToString("N2") : item.li.item_mrp.ToString("N2");
                            }
                            else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_wholesalerate;
                                dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_wholesalerate / item.li.item_quantity).ToString("N2") : item.li.item_wholesalerate.ToString("N2");
                            }
                            else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_specialrate;
                                dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_specialrate / item.li.item_quantity).ToString("N2") : item.li.item_specialrate.ToString("N2");
                            }
                            else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_supersepecialrate;
                                dgvSales["cPerUnitRate", r].Value = item.li.item_perunitrate > 0 ? (item.li.item_supersepecialrate / item.li.item_quantity).ToString("N2") : item.li.item_supersepecialrate.ToString("N2");
                            }
                            ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item.li.item_id, null, null, null, null);
                            foreach (usp_stockSelectResult item2 in singleResult)
                            {
                                dgvSales["cStock", r].Value = item2.stock;
                            }
                        }
                    }
                    dgvSales.CurrentCell = dgvSales.Rows[dgvSales.CurrentCellAddress.Y].Cells["cQty"];
                    dgvSales.Focus();
                }
                catch
                {
                }
            }
            else if (e.KeyCode == Keys.Return && dgvSales.CurrentCell.ColumnIndex == cQty.Index)
            {
                dgvSales.CurrentCell = dgvSales.Rows[dgvSales.CurrentCell.RowIndex + 1].Cells["cCategory"];
                dgvSales.Focus();
            }
        }

        private void cbopurfrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && cboissueto.Text.Trim() != string.Empty)
            {
                dgvSales.CurrentCell = dgvSales["cItemName", dgvSales.RowCount - 1];
                dgvSales.Focus();
            }
        }

        private void txtnarration_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void cmdview_Click(object sender, EventArgs e)
        {
            pnlview.Enabled = true;
            tablemain.Enabled = false;
            pnlview.BringToFront();
            tablemain.SendToBack();
            pnlview.Select();
            cmdprint_Click(this, null);
            dtpfdate.Focus();
        }


        private void dglist_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dglist.Columns[e.ColumnIndex].Name == "isDraft")
            {
                if (e.Value is bool isDraft)
                {
                    e.Value = isDraft ? "Invoice" : "Under Preview";
                    e.CellStyle.ForeColor = isDraft ? Color.Green : Color.Red;
                    e.FormattingApplied = true;
                }
            }
            if (dglist.Columns[e.ColumnIndex].Name == "isImport")
            {
                if (e.Value is bool isImport)
                {
                    e.Value = isImport ? "Imported" : "Not Import";
                    e.CellStyle.ForeColor = isImport ? Color.Green : Color.Red;
                    e.FormattingApplied = true;
                }
            }
            if (dglist.Columns[e.ColumnIndex].Name == "taxStatus")
            {
                if (!dglist.Columns.Contains("smidDataGridViewTextBoxColumn"))
                    return;
                var sm_id = Convert.ToInt32(dglist.Rows[e.RowIndex].Cells["smidDataGridViewTextBoxColumn"].Value); // Ensure "sm_id" is present in grid
                using (var db = new InventoryDataContext())
                {
                    var taxFlags = db.salesdetails
                                     .Where(sd => sd.sm_id == sm_id)
                                     .Join(db.items,
                                           sd => sd.item_id,
                                           item => item.item_id,
                                           (sd, item) => item.item_istaxable)
                                     .ToList();

                    string taxStatus = (taxFlags.Any(x => x) && taxFlags.Any(x => !x)) ? "Mixed" :
                                       taxFlags.Any(x => x) ? "Taxable" :
                                       "Non-Taxable";

                    e.Value = taxStatus;

                    switch (taxStatus)
                    {
                        case "Taxable":
                            e.CellStyle.ForeColor = Color.Green;
                            break;
                        case "Non-Taxable":
                            e.CellStyle.ForeColor = Color.Red;
                            break;
                        case "Mixed":
                            e.CellStyle.ForeColor = Color.DarkOrange;
                            break;
                    }

                    e.FormattingApplied = true;
                }
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtptdate.Value.Date < dtpfdate.Value.Date)
            {
                dtptdate.Value = dtpfdate.Value.Date;
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpfdate.Value.Date > dtptdate.Value.Date)
            {
                dtpfdate.Value = dtptdate.Value.Date;
            }
        }

        private void dtpfdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                dtptdate.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmdexit_Click(this, null);
            }
        }

        private void dtptdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cboCityView.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cmdexit_Click(this, null);
            }
        }

        private void cmdprint_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                if (txtSearchBillNo.Text == string.Empty)
                {
                    uspsalesmasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesmasterSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value.Date, dtptdate.Value.Date, null, null, Convert.ToInt32(cboCompany.SelectedValue));

                    //var salesMasterList = inventoryDataContext.usp_salesmasterSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value.Date, dtptdate.Value.Date, null, null, Convert.ToInt32(cboCompany.SelectedValue));
                    //foreach (var sale in salesMasterList) // your usp_salesmasterSelect result
                    //{
                    //    var saleDetails = inventoryDataContext.salesdetails
                    //                        .Where(sd => sd.sm_id == sale.sm_id)
                    //                        .Join(inventoryDataContext.items,
                    //                              sd => sd.item_id,
                    //                              item => item.item_id,
                    //                              (sd, item) => new
                    //                              {
                    //                                  sale.sm_id,
                    //                                  sd.item_id,
                    //                                  item.item_name,
                    //                                  item_istaxable = item.item_istaxable ? "Taxable" : "Non-Taxable"
                    //                              }).ToList();
                    //}
                }
                else
                {
                    uspsalesmasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesmasterSelect(null, null, null, null, null, Convert.ToInt64(txtSearchBillNo.Text), null);
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
            cboissueto.Focus();
        }

        private void LedgerReport(int LedgerID)
        {
        }

        public class LogoImageModel
        {
            public byte[] LogoImage { get; set; }
        }

        private void loadReport(int smid)
        {
            decimal amount = 0m;
            decimal num = 0m;
            decimal num2 = 0m;
            decimal num3 = 0m;
            decimal num4 = 0m;
            decimal num5 = 0m;
            decimal num6 = 0m;
            decimal num7 = 0m;
            long? ledid = 0;
            long? comId = 0;
            string empty = string.Empty;
            long num8 = 0L;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string value = string.Empty;
            string empty5 = string.Empty;
            DateTime? dateTime = null;
            if (dglist.CurrentCell != null)
            {

                if (MessageBox.Show("Are you sure to Print Bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    var masterList = inventoryDataContext.usp_salesmasterSelect(smid, null, null, null, null, null, null).ToList();
                    var copyLabels = new[] { "ORIGINAL FOR RECIPIENT", "DUPLICATE FOR TRANSPORTER", "TRIPLICATE FOR SUPPLIER" };

                    foreach (var label in copyLabels)
                    {
                        List<ReportParameter> list = new List<ReportParameter>();
                        var item = masterList.First();

                        int? num9 = 1;
                        dateTime = item.sm_date;
                        num8 = item.sm_refno;
                        amount = item.sm_netamount;
                        num = item.sm_roundamount.Value;
                        num2 = item.sm_packingcharge;
                        num5 = item.sm_disamount;
                        num3 = item.sm_totamount;
                        num6 = item.sm_taxamount;
                        num7 = item.sm_taxpercentage;
                        comId = item.com_id;
                        value = general.MoneyToText(amount);
                        ledid = item.led_id;

                        string titleValue = num7 > 0 ? "Tax Invoice" : "Bill of Supply";

                        byte[] logoBytes = File.ReadAllBytes(Path.Combine(Application.StartupPath, comId == 1 ? "SaamySign.png" : "JeyakkodiSign.png"));
                        List<LogoImageModel> logoList = new List<LogoImageModel>
                        {
                            new LogoImageModel { LogoImage = logoBytes }
                        };

                        ISingleResult<usp_companySelectResult> singleResult2 = inventoryDataContext.usp_companySelect(comId);
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

                        // 📌 Invoice parameters
                        list.Add(new ReportParameter("ordno", num8.ToString()));
                        list.Add(new ReportParameter("orddate", $"{dateTime:dd-MMM-yyyy}"));
                        list.Add(new ReportParameter("rstext", value));
                        list.Add(new ReportParameter("am_acccode", empty2));
                        list.Add(new ReportParameter("am_account", empty3));
                        list.Add(new ReportParameter("am_bank", empty4));
                        list.Add(new ReportParameter("title", empty5));
                        list.Add(new ReportParameter("mi_totamt", num3.ToString("0.00")));
                        list.Add(new ReportParameter("mi_discount", num5.ToString("0.00")));
                        list.Add(new ReportParameter("mi_taxamt", num6.ToString("0.00")));
                        list.Add(new ReportParameter("mi_taxper", num7.ToString("0.00")));
                        list.Add(new ReportParameter("mi_packing", num2.ToString("0.00")));
                        list.Add(new ReportParameter("mi_netamt", amount.ToString("0.00")));
                        list.Add(new ReportParameter("mi_roundamt", num.ToString("0.00")));
                        list.Add(new ReportParameter("CopyLabel", label));
                        list.Add(new ReportParameter("title_header", titleValue));

                        // 🔽 Load form & report
                        frmRpt frmRpt = new frmRpt();
                        frmRpt.WindowState = FormWindowState.Maximized;

                        ISingleResult<usp_salesmasterSelectResult> dataSourceValue = inventoryDataContext.usp_salesmasterSelect(smid, null, null, null, null, null, null);
                        ISingleResult<usp_salesdetailsSelectResult> dataSourceValue2 = inventoryDataContext.usp_salesdetailsSelect(smid, null, null, null, null, null, null);
                        ISingleResult<usp_companySelectResult> dataSourceValue3 = inventoryDataContext.usp_companySelect(comId);
                        ISingleResult<usp_ledgermasterSelectResult> dataSourceValue4 = inventoryDataContext.usp_ledgermasterSelect(ledid, null, null, null, null, null, null);

                        // 🧾 Assign report viewer
                        frmRpt.reportview.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesInvoice1.rdlc";
                        frmRpt.reportview.LocalReport.DataSources.Clear();

                        // ✅ Add all DataSources
                        frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_minvoiceSelect", dataSourceValue));
                        frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("ds_usp_dinvoiceSelect", dataSourceValue2));
                        frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_companySelect", dataSourceValue3));
                        frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_ledgermasterSelect", dataSourceValue4));
                        frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("LogoDataSet", logoList));

                        frmRpt.reportview.LocalReport.SetParameters(list);
                        frmRpt.reportview.ZoomMode = ZoomMode.Percent;
                        frmRpt.reportview.ZoomPercent = 100;
                        frmRpt.reportview.RefreshReport();
                        frmRpt.reportview.LocalReport.Refresh();
                        frmRpt.reportview.RefreshReport();
                        frmRpt.ShowDialog();

                    }


                    //byte[] reportBytes = frmRpt.reportview.LocalReport.Render("PDF");

                    //string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    //string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                    //string Name = cboissueto.Text.Trim();
                    //string baseFileName = cboCity.Text + "_" + Name + "_" + todayDate + "_" + "receipt";
                    //string pdfFilePath = Path.Combine(downloadsPath, baseFileName + ".pdf");

                    //File.WriteAllBytes(pdfFilePath, reportBytes);

                    //frmRpt.ShowDialog();

                    // Ask to send via WhatsApp
                    //DialogResult result = MessageBox.Show("Do you want to send this bill via WhatsApp?", "Send to WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    int ledgerId = Convert.ToInt32(cboissueto.SelectedValue);
                    //    string customerPhone = GetCustomerPhoneNumber(ledgerId);

                    //    if (!string.IsNullOrEmpty(customerPhone))
                    //    {
                    //        SendViaWhatsApp(customerPhone, pdfFilePath);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Customer phone number not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                }
            }
        }


        private void loadEstimateReport(int smid)
        {
            if (dglist.CurrentCell != null)
            {
                List<ReportParameter> list = new List<ReportParameter>();
                if (MessageBox.Show("Are you sure to Print Estimate Bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    ISingleResult<usp_salesmasterSelectResult> singleResult = inventoryDataContext.usp_salesmasterSelect(smid, null, null, null, null, null, null);
                    var salesMasterData = singleResult.FirstOrDefault();
                    int? comId = Convert.ToInt32(salesMasterData.com_id);
                    frmRpt frmRpt = new frmRpt();
                    frmRpt.WindowState = FormWindowState.Maximized;
                    ISingleResult<usp_salesmasterSelectResult> dataSourceValue = inventoryDataContext.usp_salesmasterSelect(smid, null, null, null, null, null, null);
                    ISingleResult<usp_salesdetailsSelectResult> dataSourceValue2 = inventoryDataContext.usp_salesdetailsSelect(smid, null, null, null, null, null, null);
                    ISingleResult<usp_companySelectResult> dataSourceValue3 = inventoryDataContext.usp_companySelect(comId);
                    frmRpt.reportview.RefreshReport();
                    frmRpt.reportview.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesEstimate.rdlc";
                    frmRpt.reportview.LocalReport.DataSources.Clear();
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_salesMasterSelect", dataSourceValue));
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_salesDetailSelect", dataSourceValue2));
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_companySelect", dataSourceValue3));
                    frmRpt.reportview.LocalReport.SetParameters(list);
                    frmRpt.reportview.ZoomMode = ZoomMode.Percent;
                    frmRpt.reportview.ZoomPercent = 120;
                    frmRpt.reportview.RefreshReport();
                    frmRpt.reportview.LocalReport.Refresh();
                    frmRpt.reportview.RefreshReport();
                    frmRpt.ShowDialog();

                    //byte[] reportBytes = frmRpt.reportview.LocalReport.Render("PDF");

                    //string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    //string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                    //string Name = cboissueto.Text.Trim();
                    //string baseFileName = cboCity.Text + "_" + Name + "_" + todayDate + "_" + "receipt";
                    //string pdfFilePath = Path.Combine(downloadsPath, baseFileName + ".pdf");

                    //File.WriteAllBytes(pdfFilePath, reportBytes);

                    //frmRpt.ShowDialog();

                    // Ask to send via WhatsApp
                    //DialogResult result = MessageBox.Show("Do you want to send this bill via WhatsApp?", "Send to WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    int ledgerId = Convert.ToInt32(cboissueto.SelectedValue);
                    //    string customerPhone = GetCustomerPhoneNumber(ledgerId);

                    //    if (!string.IsNullOrEmpty(customerPhone))
                    //    {
                    //        SendViaWhatsApp(customerPhone, pdfFilePath);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Customer phone number not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                }
            }
        }

        private void dglist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    cmdexit_Click(this, null);
                }
                else if (e.KeyCode == Keys.F8)
                {
                    loadReport(Convert.ToInt32(dglist.CurrentRow.Cells["smidDataGridViewTextBoxColumn"].Value));
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
            int num = Convert.ToInt32(dglist["smidDataGridViewTextBoxColumn", dglist.CurrentRow.Index].Value);
            id = num;
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            ISingleResult<usp_salesmasterSelectResult> singleResult = inventoryDataContext.usp_salesmasterSelect(num, null, null, null, null, null, null);
            decimal num2 = 0m;
            decimal value = 0m;
            decimal num3 = 0m;
            decimal num4 = 0m;
            using (IEnumerator<usp_salesmasterSelectResult> enumerator = singleResult.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    usp_salesmasterSelectResult current = enumerator.Current;
                    txtopno.Text = Convert.ToString(current.sm_refno);
                    dtpsaldate.Value = Convert.ToDateTime(current.sm_date);
                    cboCom.Text = Convert.ToString(current.com_name);
                    cboCity.Text = current.led_address2;
                    cboissueto.SelectedValue = current.led_id;
                    txtothercharges.Value = current.sm_packingcharge;
                    ReceivedAmt = current.sm_received;
                    num2 = current.sm_disamount;
                    num3 = current.sm_taxamount;
                    num4 = current.sm_taxpercentage;
                    if (current.sm_agid != null && cboAgent.Items.Count > 0)
                    {
                        cboAgent.SelectedValue = current.sm_agid;
                    }

                    if (current.sm_disamount > 0m)
                    {
                        txtDisPer.Value = Math.Round(current.sm_disamount / current.sm_totamount * 100m, 2);
                    }
                    else
                    {
                        txtDisPer.Value = 0m;
                    }
                    value = current.sm_profit;
                }
            }


            ISingleResult<usp_salesdetailsSelectResult> singleResult2 = inventoryDataContext.usp_salesdetailsSelect(num, null, null, null, null, null, null);
            dgvSales.Rows.Clear();
            dgvSales.AllowUserToAddRows = false;
            foreach (usp_salesdetailsSelectResult item in singleResult2)
            {
                dgvSales.Rows.Add();
                dgvSales["cItemName", dgvSales.RowCount - 1].Value = item.item_name;
                dgvSales["cCatID", dgvSales.RowCount - 1].Value = item.cat_id;
                dgvSales["cItemID", dgvSales.RowCount - 1].Value = item.item_id;
                dgvSales["cIsTaxable", dgvSales.RowCount - 1].Value = item.item_istaxable;
                dgvSales["cOdID", dgvSales.RowCount - 1].Value = item.sd_odid;
                dgvSales["cSdID", dgvSales.RowCount - 1].Value = item.sd_id;
                dgvSales["cCategory", dgvSales.RowCount - 1].Value = item.cat_name;
                dgvSales["cCostRate", dgvSales.RowCount - 1].Value = item.sd_costrate;
                dgvSales["cRate", dgvSales.RowCount - 1].Value = item.sd_rate;
                dgvSales["cStock", dgvSales.RowCount - 1].Value = "0";
                dgvSales["cAmount", dgvSales.RowCount - 1].Value = item.sd_totamount;
                dgvSales["cQty", dgvSales.RowCount - 1].Value = item.sd_qty;
                dgvSales["cOdUnitValue", dgvSales.RowCount - 1].Value = item.sd_unitvalue.ToString("N2");
                dgvSales["cOrderQty", dgvSales.RowCount - 1].Value = item.sd_orderqty;
                dgvSales["cTaxPercentage", dgvSales.RowCount - 1].Value = item.sd_taxpercentage;
                dgvSales["cTaxAmount", dgvSales.RowCount - 1].Value = item.sd_taxamount;
                dgvSales["cUnit", dgvSales.RowCount - 1].Value = item.sd_unit;
                dgvSales["cUnitValue", dgvSales.RowCount - 1].Value = item.sd_unitvalue.ToString("N2");
                dgvSales["cItemUnitType", dgvSales.RowCount - 1].Value = item.sd_itemunittype;
                dgvSales["cPerUnitRate", dgvSales.RowCount - 1].Value = item.sd_perunitrate.ToString("N2");
                dgvSales["cFrieghtCharge", dgvSales.RowCount - 1].Value = item.sd_totfrieght.ToString("N2");
                dgvSales["cCostAmount", dgvSales.RowCount - 1].Value = (item.sd_qty * item.sd_costrate).ToString("N2");
                ISingleResult<usp_stockSelectResult> singleResult3 = inventoryDataContext.usp_stockSelect(item.item_id, null, null, null, null);
                foreach (usp_stockSelectResult item2 in singleResult3)
                {
                    DataGridViewCell dataGridViewCell = dgvSales["cStock", dgvSales.RowCount - 1];
                    if (Convert.ToInt32(dgvSales["cCatID", dgvSales.RowCount - 1].Value) == 39)
                    {
                        decimal unitValue = item.sd_unitvalue;
                        decimal? stock = item2.stock;
                        dataGridViewCell.Value = (decimal?)unitValue + stock;
                    }
                    else
                    {
                        decimal sd_qty = item.sd_qty;
                        decimal? stock = item2.stock;
                        dataGridViewCell.Value = (decimal?)sd_qty + stock;
                    }
                }
                //txtTaxAmt.Value = item.sd_taxamount;
            }

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                decimal costRate, qty, stocks, rate, taxPercentage, unitValue, FrieghtCharge, perUnitRate;

                if (Convert.ToString(row.Cells["cItemName"].Value) == string.Empty)
                {
                    dgvSales.Rows.RemoveAt(row.Index);
                    continue;
                }

                decimal.TryParse(Convert.ToString(row.Cells["cQty"].Value), out qty);
                qty = Math.Abs(qty);

                decimal.TryParse(Convert.ToString(row.Cells["cStock"].Value), out stocks);
                row.Cells["cQty"].Value = (qty > 0m) ? (object)qty : null;

                if (qty > stocks)
                {
                    MessageBox.Show("You have only " + stocks + " Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dgvSales.CurrentCell = row.Cells["cQty"];
                    dgvSales.BeginEdit(selectAll: true);
                    dgvSales.Focus();
                    break; // Stop processing further until user fixes
                }

                decimal.TryParse(Convert.ToString(row.Cells["cRate"].Value), out rate);
                decimal.TryParse(Convert.ToString(row.Cells["cCostRate"].Value), out costRate);
                decimal.TryParse(Convert.ToString(row.Cells["cTaxPercentage"].Value), out taxPercentage);
                decimal.TryParse(Convert.ToString(row.Cells["cUnitValue"].Value), out unitValue);
                decimal.TryParse(Convert.ToString(row.Cells["cPerUnitRate"].Value), out perUnitRate);


                if (Convert.ToInt32(row.Cells["cCatID"].Value) == 39)
                {
                    row.Cells["cUnitValue"].ReadOnly = false;
                    row.Cells["cQty"].ReadOnly = true;
                    row.Cells["cFrieghtCharge"].Value = 0.ToString("N2");
                }
                else
                {
                    if (chkIsFrieght.Checked)
                        row.Cells["cFrieghtCharge"].Value = ((rate > 0m && qty > 0m) ? ((object)(unitValue * qty).ToString("N2")) : null);
                    else
                        row.Cells["cFrieghtCharge"].Value = null;
                }
                decimal.TryParse(Convert.ToString(row.Cells["cFrieghtCharge"].Value), out FrieghtCharge);

                row.Cells["cAmount"].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                row.Cells["cTaxAmount"].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                row.Cells["cCostAmount"].Value = ((costRate > 0m && qty > 0m) ? ((object)(costRate * qty)) : null);

                if (Convert.ToInt32(row.Cells["cCatID"].Value) == 39)
                {
                    row.Cells["cRate"].Value = unitValue * perUnitRate;
                    decimal.TryParse(Convert.ToString(row.Cells["cRate"].Value), out rate);
                    row.Cells["cTaxAmount"].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                    row.Cells["cAmount"].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                }
            }

            // Recalculate SNo column
            SetColumnIndex method = Mymethod;
            dgvSales.BeginInvoke(method, "cSNo");

            dgvSales.AllowUserToAddRows = true;
            txtProfit.Value = value;
            txtDiscount.Value = Convert.ToDecimal(num2.ToString("N2"));
            //txtTaxAmt.Value = Convert.ToDecimal(num3.ToString("N2"));
            txtTaxPer.Value = Convert.ToDecimal(num4.ToString("N2"));
            calacTotal();
            LoadStock();
            pnlview.Enabled = false;
            tablemain.Enabled = true;
            pnlview.SendToBack();
            tablemain.BringToFront();
            cboissueto.Focus();
        }

        private void dglist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ldelete.Index && e.RowIndex > -1)
                {
                    int num = Convert.ToInt32(dglist["smidDataGridViewTextBoxColumn", e.RowIndex].Value);
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    salesorder salesorder = new salesorder();
                    var soid = inventoryDataContext.salesmasters.Where(sm => sm.sm_id == num).Select(sm => sm.so_id).FirstOrDefault();
                    var joinedList = (from sd in inventoryDataContext.salesdetails
                                      join od in inventoryDataContext.salesorderdetails
                                          on sd.sd_odid equals od.od_id
                                      where sd.sm_id == num
                                      select new
                                      {
                                          sd.sd_odid,
                                          is_taxable = od.od_istaxable,
                                          od.com_id
                                      }).ToList();


                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        inventoryDataContext.usp_salesdetailsDelete(num);
                        inventoryDataContext.usp_salesmasterDelete(num);
                        foreach (var detail in joinedList)
                        {
                            inventoryDataContext.usp_salesorderdetailsDelete(soid, detail.is_taxable, detail.com_id, detail.sd_odid);
                        }
                        inventoryDataContext.usp_stockDelete(num, "SALES");

                        var soIdsToUpdate = joinedList.Select(j => j.sd_odid)
                    .Distinct()
                    .ToList();

                        var totalQty = inventoryDataContext.salesorderdetails
                            .Where(od => od.so_id == soid)
                            .Sum(od => (decimal?)od.od_qty) ?? 0;

                        var existingOrder = inventoryDataContext.salesorders.FirstOrDefault(so => so.so_id == soid);
                        salesorder.so_refno = existingOrder.so_refno;
                        salesorder.so_date = existingOrder.so_date;
                        salesorder.led_id = existingOrder.led_id;
                        salesorder.so_status = existingOrder.so_status;
                        salesorder.so_isclose = existingOrder.so_isclose;
                        salesorder.so_udate = existingOrder.so_udate;
                        salesorder.users_uid = existingOrder.users_uid;

                        inventoryDataContext.usp_salesorderUpdate(soid, salesorder.so_refno, salesorder.so_date, salesorder.led_id, totalQty, salesorder.so_status, salesorder.users_uid, salesorder.so_udate, salesorder.so_isclose);

                        cmdprint_Click(this, null);
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
                    var isDraftValue = dglist.Rows[e.RowIndex].Cells["isDraft"].Value;

                    if (isDraftValue is bool isDraft && !isDraft)
                    {
                        MessageBox.Show("This record is not converted to Sales.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    loadReport(Convert.ToInt32(dglist.CurrentRow.Cells["smidDataGridViewTextBoxColumn"].Value));
                }
                else if (e.ColumnIndex == lEstimateprint.Index && e.RowIndex > -1)
                {
                    var isDraftValue = dglist.Rows[e.RowIndex].Cells["isDraft"].Value;

                    if (isDraftValue is bool isDraft && !isDraft)
                    {
                        MessageBox.Show("This record is not converted to Sales.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    loadEstimateReport(Convert.ToInt32(dglist.CurrentRow.Cells["smidDataGridViewTextBoxColumn"].Value));
                }
                else if (e.ColumnIndex == lImport.Index && e.RowIndex > -1)
                {
                    int smid = Convert.ToInt32(dglist.Rows[e.RowIndex].Cells["smidDataGridViewTextBoxColumn"].Value);

                    DialogResult result = MessageBox.Show("Are you sure to import to Tally?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ImportSalesToTally(smid);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK__receipt__sm_id"))
                {
                    MessageBox.Show("Record refered in receipt...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    frmException ex2 = new frmException(ex);
                    ex2.ShowDialog();
                }
            }
        }

        private void lblothers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtothercharges.Focus();
            }
        }

        private void txtothers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtDisPer.Focus();
            }
        }

        public static class TallyHelper
        {
            public static string BuildSalesVoucherXml(usp_salesmasterSelectResult master, List<usp_salesdetailsSelectResult> details)
            {
                string date = Convert.ToDateTime(master.sm_date).ToString("yyyyMMdd", CultureInfo.InvariantCulture);
                string voucherNumber = Convert.ToString(master.sm_refno);
                Guid guid;
                if (master.sm_guid != null)
                {
                    guid = master.sm_guid ?? Guid.NewGuid();
                }
                else
                {
                    guid = Guid.NewGuid();
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    salesmaster salesmaster = inventoryDataContext.salesmasters.FirstOrDefault(x => x.sm_id == master.sm_id);
                    inventoryDataContext.usp_salesmasterUpdate(salesmaster.sm_id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount, salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount, salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount, salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking, salesmaster.sm_roundamount, salesmaster.sm_iscommissionclose, salesmaster.sm_ispackingclose, global.ucode, global.sysdate, salesmaster.sm_desc, salesmaster.sm_isclose, salesmaster.sm_isdraft, salesmaster.so_id, salesmaster.com_id, salesmaster.sm_istaxable, false, guid, salesmaster.sm_agid);
                }
                string companyName = master.com_id == 2 ? "JEYAKKODI TRADERS 2025-2026" : master.com_id == 1 ? "SAAMY TRADE LINKS 2025-2026" : "Unknown Company";

                string Ledger = master.com_id == 2 ? master.led_name : master.com_id == 1 ? master.led_stlname : null;
                Ledger = System.Net.WebUtility.HtmlDecode(Ledger);
                Ledger = Regex.Replace(Ledger, @"[\u0000-\u001F\u007F-\u009F\u200B-\u200D\uFEFF]", "");
                Ledger = Ledger.Trim();
                string partyLedger = SecurityElement.Escape(Ledger);

                string action = string.IsNullOrEmpty(guid.ToString()) ? "Create" : "Alter";
                string partyGSTIN = master.led_tin ?? "";
                string Address1 = master.led_address;
                string partyAddressLine1 = SecurityElement.Escape(Address1);
                string partyAddressLine2 = master.led_address1;
                string partyAddressLine3 = master.led_address2;
                string partyAddressLine4 = master.led_pincode;
                string RegistrationType;
                if (!string.IsNullOrEmpty(partyGSTIN))
                {
                    RegistrationType = "Regular";
                }
                else
                {
                    RegistrationType = "Unregistered/Consumer";
                }
                string vehicleNo = master.led_vehicleno;

                string state = master.led_state ?? "Tamil Nadu";
                string salesLedger = "Sales GST";
                decimal gstAmount = master.sm_taxamount;
                string igstLedger = "IGST";
                string cgstLedger = "CGST";
                string sgstLedger = "SGST";
                string godown = "Main Location";

                StringBuilder xml = new StringBuilder();

                if (master.com_id == 1 & master.sm_istaxable == false)
                {
                    xml.AppendLine("<ENVELOPE>");
                    xml.AppendLine("  <HEADER><TALLYREQUEST>Import Data</TALLYREQUEST></HEADER>");
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
                    xml.AppendLine($"          <VOUCHER REMOTEID=\"{guid}\" VCHTYPE=\"Gst Sales\" ACTION=\"{action}\" GUID=\"{guid}\" OBJVIEW=\"Invoice Voucher View\">");

                    xml.AppendLine($"            <DATE>{date}</DATE>");
                    xml.AppendLine($"            <GUID>{guid}</GUID>");
                    xml.AppendLine($"            <VOUCHERNUMBER>{voucherNumber}</VOUCHERNUMBER>");
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine("            <VOUCHERTYPENAME>Gst Sales</VOUCHERTYPENAME>");
                    xml.AppendLine("            <CLASSNAME>SALES</CLASSNAME>");
                    xml.AppendLine($"            <BASICBUYERNAME>{partyLedger}</BASICBUYERNAME>");
                    xml.AppendLine($"            <BASICBASEPARTYNAME>{partyLedger}</BASICBASEPARTYNAME>");
                    xml.AppendLine($"            <PARTYGSTIN>{partyGSTIN}</PARTYGSTIN>");
                    xml.AppendLine($"            <PLACEOFSUPPLY>{state}</PLACEOFSUPPLY>");
                    xml.AppendLine($"            <STATENAME>{state}</STATENAME>");
                    xml.AppendLine("            <COUNTRYOFRESIDENCE>India</COUNTRYOFRESIDENCE>");
                    xml.AppendLine($"            <GSTREGISTRATIONTYPE>{RegistrationType}</GSTREGISTRATIONTYPE>");
                    xml.AppendLine($"            <BASICSHIPVESSELNO>{vehicleNo}</BASICSHIPVESSELNO>");


                    // Buyer (Bill To) Address
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine($"            <PARTYMAILINGNAME>{partyLedger}</PARTYMAILINGNAME>");
                    xml.AppendLine("             <ADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine1}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine2}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine3}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine4}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{state}</ADDRESS>");
                    xml.AppendLine("             </ADDRESS.LIST>");

                    xml.AppendLine("            <BASICBUYERADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine1}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine2}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine3}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine4}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{state}</BASICBUYERADDRESS>");
                    xml.AppendLine("            </BASICBUYERADDRESS.LIST>");

                    // Consignee (Ship To) Address
                    xml.AppendLine($"           <CONSIGNEEMAILINGNAME>{partyLedger}</CONSIGNEEMAILINGNAME>");
                    xml.AppendLine($"           <CONSIGNEEGSTIN>{partyGSTIN}</CONSIGNEEGSTIN>");
                    xml.AppendLine($"           <CONSIGNEESTATENAME>{state}</CONSIGNEESTATENAME>");
                    xml.AppendLine("            <BASICSHIPADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine1}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine2}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine3}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine4}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{state}</BASICSHIPADDRESS>");
                    xml.AppendLine("            </BASICSHIPADDRESS.LIST>");

                    xml.AppendLine("            <ISINVOICE>Yes</ISINVOICE>");
                    xml.AppendLine("            <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>");

                    // Ledger Entry (Customer) - Cr
                    xml.AppendLine("            <LEDGERENTRIES.LIST>");
                    xml.AppendLine($"              <LEDGERNAME>{partyLedger}</LEDGERNAME>");
                    xml.AppendLine("              <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                    xml.AppendLine("              <ISPARTYLEDGER>Yes</ISPARTYLEDGER>");
                    xml.AppendLine($"              <AMOUNT>-{master.sm_netamount:0.00}</AMOUNT>");
                    xml.AppendLine("            </LEDGERENTRIES.LIST>");

                    // Item-wise Inventory Entries
                    foreach (var item in details.Where(d => d.sd_qty > 0))
                    {
                        string itemName = $"{item.cat_name} {item.item_quantity}{item.item_unit} Bags";
                        string qtyStr = $"{item.sd_qty} {item.sd_unit}";
                        string rateStr = $"{item.sd_rate:0.00}/{item.sd_unit}";
                        decimal totalAmount = item.sd_qty * item.sd_rate;

                        xml.AppendLine("            <ALLINVENTORYENTRIES.LIST>");
                        xml.AppendLine($"              <STOCKITEMNAME>{item.item_fullname}</STOCKITEMNAME>");
                        xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                        xml.AppendLine("              <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"              <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                        xml.AppendLine($"              <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"              <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"              <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine("              <ISSUPPORTQTY>No</ISSUPPORTQTY>");
                        xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("                <GODOWNNAME>Main Location</GODOWNNAME>");
                        xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                        xml.AppendLine("                <DESTINATIONGODOWN>Main Location</DESTINATIONGODOWN>");
                        xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine($"                <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"                <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"                <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                        xml.AppendLine("              </BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("              <GSTDETAILS.LIST>");
                        xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                        xml.AppendLine("              <TAXABILITY>Exempt</TAXABILITY>"); // Change to "Taxable" if needed
                        xml.AppendLine("              </GSTDETAILS.LIST>");
                        xml.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine($"                <LEDGERNAME>{salesLedger}</LEDGERNAME>");
                        xml.AppendLine("                 <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");

                    }

                    decimal itemTotal = details.Sum(i => Math.Round((i.item_fullname == "CHILLIES IN KGS" ? i.sd_unitvalue * i.sd_perunitrate : i.sd_qty * i.sd_rate), 2));
                    decimal roundOff = Math.Round((itemTotal + gstAmount), 0, MidpointRounding.AwayFromZero) - (itemTotal + gstAmount);
                    if (roundOff != 0)
                    {
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine("        <LEDGERNAME>Round Off</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{roundOff:0.00}</AMOUNT>");
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

                if (master.com_id == 1 & master.sm_istaxable == true)
                {

                    xml.AppendLine("<ENVELOPE>");
                    xml.AppendLine("  <HEADER><TALLYREQUEST>Import Data</TALLYREQUEST></HEADER>");
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
                    xml.AppendLine($"          <VOUCHER REMOTEID=\"{guid}\" VCHTYPE=\"GST SALES T\"ACTION=\"{action}\" GUID=\"{guid}\" OBJVIEW=\"Invoice Voucher View\">");

                    xml.AppendLine($"            <DATE>{date}</DATE>");
                    xml.AppendLine($"            <GUID>{guid}</GUID>");
                    xml.AppendLine($"            <VOUCHERNUMBER>{voucherNumber}</VOUCHERNUMBER>");
                    xml.AppendLine($"            <ISMANUALVCHNO>No</ISMANUALVCHNO>");
                    xml.AppendLine($"            <AUTONUMBERING>No</AUTONUMBERING>");
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine("            <VOUCHERTYPENAME>GST SALES T</VOUCHERTYPENAME>");
                    xml.AppendLine("            <CLASSNAME>Sales Gst</CLASSNAME>");
                    xml.AppendLine($"            <BASICBUYERNAME>{partyLedger}</BASICBUYERNAME>");
                    xml.AppendLine($"            <BASICBASEPARTYNAME>{partyLedger}</BASICBASEPARTYNAME>");
                    xml.AppendLine($"            <PARTYGSTIN>{partyGSTIN}</PARTYGSTIN>");
                    xml.AppendLine($"            <PLACEOFSUPPLY>{state}</PLACEOFSUPPLY>");
                    xml.AppendLine($"            <STATENAME>{state}</STATENAME>");
                    xml.AppendLine("            <COUNTRYOFRESIDENCE>India</COUNTRYOFRESIDENCE>");
                    xml.AppendLine($"            <GSTREGISTRATIONTYPE>{RegistrationType}</GSTREGISTRATIONTYPE>");
                    xml.AppendLine($"            <BASICSHIPVESSELNO>{vehicleNo}</BASICSHIPVESSELNO>");

                    // Buyer (Bill To) Address
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine($"            <PARTYMAILINGNAME>{partyLedger}</PARTYMAILINGNAME>");
                    xml.AppendLine("            <ADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine1}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine2}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine3}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine4}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{state}</ADDRESS>");
                    xml.AppendLine("            </ADDRESS.LIST>");

                    xml.AppendLine("            <BASICBUYERADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine1}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine2}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine3}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine4}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{state}</BASICBUYERADDRESS>");
                    xml.AppendLine("            </BASICBUYERADDRESS.LIST>");

                    // Consignee (Ship To) Address
                    xml.AppendLine($"           <CONSIGNEEMAILINGNAME>{partyLedger}</CONSIGNEEMAILINGNAME>");
                    xml.AppendLine($"           <CONSIGNEEGSTIN>{partyGSTIN}</CONSIGNEEGSTIN>");
                    xml.AppendLine($"           <CONSIGNEESTATENAME>{state}</CONSIGNEESTATENAME>");
                    xml.AppendLine("            <BASICSHIPADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine1}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine2}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine3}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine4}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{state}</BASICSHIPADDRESS>");
                    xml.AppendLine("            </BASICSHIPADDRESS.LIST>");
                    xml.AppendLine("            <ISINVOICE>Yes</ISINVOICE>");
                    xml.AppendLine("            <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>");

                    xml.AppendLine("            <UDF:ISEINVAPPLICABLE.LIST TYPE=\"Logical\">");
                    xml.AppendLine("                <UDF:ISEINVAPPLICABLE>Yes</UDF:ISEINVAPPLICABLE>");
                    xml.AppendLine("            </UDF:ISEINVAPPLICABLE.LIST>");

                    // Ledger Entry (Customer) - Cr
                    xml.AppendLine("            <LEDGERENTRIES.LIST>");
                    xml.AppendLine($"              <LEDGERNAME>{partyLedger}</LEDGERNAME>");
                    xml.AppendLine("              <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                    xml.AppendLine("              <ISPARTYLEDGER>Yes</ISPARTYLEDGER>");
                    xml.AppendLine($"              <AMOUNT>-{master.sm_netamount:0.00}</AMOUNT>");
                    xml.AppendLine("            </LEDGERENTRIES.LIST>");

                    if (state == "Tamil Nadu")
                    {

                        // CGST Ledger Entry
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{cgstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{gstAmount / 2:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                        // SGST Ledger Entry
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{sgstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{gstAmount / 2:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                    }
                    else
                    {

                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{igstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{gstAmount:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");



                    }

                    // Item-wise Inventory Entries
                    foreach (var item in details.Where(d => d.sd_qty > 0 && (d.item_fullname == "CHILLIES IN KGS" ? d.sd_unitvalue >= 0 : true)))
                    {
                        string itemName = $"{item.cat_name} {item.item_quantity}{item.item_unit} Bags";
                        string qtyStr = $"{item.sd_qty} {item.sd_unit}";
                        string rateStr = $"{item.sd_rate:0.00}/{item.sd_unit}";
                        decimal totalAmount = item.sd_qty * item.sd_rate;

                        xml.AppendLine("            <ALLINVENTORYENTRIES.LIST>");
                        xml.AppendLine($"              <STOCKITEMNAME>{item.item_fullname}</STOCKITEMNAME>");

                        if (item.item_fullname == "CHILLIES IN KGS")
                        {
                            xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                            xml.AppendLine("              <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                            xml.AppendLine($"              <RATE>{item.sd_perunitrate:0.00}/kg</RATE>");
                            xml.AppendLine($"              <ACTUALQTY>{item.sd_unitvalue} kg</ACTUALQTY>");
                            xml.AppendLine($"              <BILLEDQTY>{item.sd_unitvalue} Kg</BILLEDQTY>");
                            xml.AppendLine($"              <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                            xml.AppendLine("              <ISSUPPORTQTY>No</ISSUPPORTQTY>");
                            xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                            xml.AppendLine("                <GODOWNNAME>Main Location</GODOWNNAME>");
                            xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                            xml.AppendLine("                <DESTINATIONGODOWN>Main Location</DESTINATIONGODOWN>");
                            xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                            xml.AppendLine($"                <ACTUALQTY>{item.sd_unitvalue} Kg</ACTUALQTY>");
                            xml.AppendLine($"                <BILLEDQTY>{item.sd_unitvalue} Kg</BILLEDQTY>");
                            xml.AppendLine($"                <RATE>{item.sd_perunitrate:0.00}/Kg</RATE>");
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
                            xml.AppendLine($"                <LEDGERNAME>{salesLedger}</LEDGERNAME>");
                            xml.AppendLine("                <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                            xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                            xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                            xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");
                        }
                        else
                        {
                            xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                            xml.AppendLine("              <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                            xml.AppendLine($"              <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                            xml.AppendLine($"              <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                            xml.AppendLine($"              <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                            xml.AppendLine($"              <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                            xml.AppendLine("              <ISSUPPORTQTY>No</ISSUPPORTQTY>");
                            xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                            xml.AppendLine("                <GODOWNNAME>Main Location</GODOWNNAME>");
                            xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                            xml.AppendLine("                <DESTINATIONGODOWN>Main Location</DESTINATIONGODOWN>");
                            xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                            xml.AppendLine($"                <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                            xml.AppendLine($"                <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                            xml.AppendLine($"                <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                            xml.AppendLine("              </BATCHALLOCATIONS.LIST>");
                            xml.AppendLine("              <GSTDETAILS.LIST>");
                            xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                            xml.AppendLine("              <TAXABILITY>Taxable</TAXABILITY>"); // Change to "Taxable" if needed
                            xml.AppendLine("              <ISREVERSECHARGEAPPLICABLE>No</ISREVERSECHARGEAPPLICABLE>");
                            xml.AppendLine("              <ISNONGSTGOODS>No</ISNONGSTGOODS>");
                            xml.AppendLine("              <GSTINELIGIBLEITC>No</GSTINELIGIBLEITC>");
                            xml.AppendLine("              <ISGSTINVOICE>Yes</ISGSTINVOICE>");
                            xml.AppendLine("              </GSTDETAILS.LIST>");
                            xml.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                            xml.AppendLine($"                <LEDGERNAME>{salesLedger}</LEDGERNAME>");
                            xml.AppendLine("                <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                            xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                            xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                            xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");
                        }

                    }

                    decimal itemTotal = details.Sum(i => Math.Round((i.item_fullname == "CHILLIES IN KGS" ? i.sd_unitvalue * i.sd_perunitrate : i.sd_qty * i.sd_rate), 2));
                    decimal roundOff = Math.Round((itemTotal + gstAmount), 0, MidpointRounding.AwayFromZero) - (itemTotal + gstAmount);
                    if (roundOff != 0)
                    {
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine("        <LEDGERNAME>Round Off</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{roundOff:0.00}</AMOUNT>");
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

                if (master.com_id == 2 & master.sm_istaxable == false)
                {
                    xml.AppendLine("<ENVELOPE>");
                    xml.AppendLine("  <HEADER><TALLYREQUEST>Import Data</TALLYREQUEST></HEADER>");
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
                    xml.AppendLine($"          <VOUCHER REMOTEID=\"{guid}\" VCHTYPE=\"GST SALES N\" ACTION=\"{action}\" GUID=\"{guid}\" OBJVIEW=\"Invoice Voucher View\">");

                    xml.AppendLine($"            <DATE>{date}</DATE>");
                    xml.AppendLine($"            <GUID>{guid}</GUID>");
                    xml.AppendLine($"            <VOUCHERNUMBER>{voucherNumber}</VOUCHERNUMBER>");
                    xml.AppendLine($"            <ISMANUALVCHNO>No</ISMANUALVCHNO>");
                    xml.AppendLine($"            <AUTONUMBERING>Yes</AUTONUMBERING>");
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine("            <VOUCHERTYPENAME>GST SALES N</VOUCHERTYPENAME>");
                    xml.AppendLine("            <CLASSNAME>SALES</CLASSNAME>");
                    xml.AppendLine($"            <BASICBUYERNAME>{partyLedger}</BASICBUYERNAME>");
                    xml.AppendLine($"            <BASICBASEPARTYNAME>{partyLedger}</BASICBASEPARTYNAME>");
                    xml.AppendLine($"            <PARTYGSTIN>{partyGSTIN}</PARTYGSTIN>");
                    xml.AppendLine($"            <PLACEOFSUPPLY>{state}</PLACEOFSUPPLY>");
                    xml.AppendLine($"            <STATENAME>{state}</STATENAME>");
                    xml.AppendLine("            <COUNTRYOFRESIDENCE>India</COUNTRYOFRESIDENCE>");
                    xml.AppendLine($"           <GSTREGISTRATIONTYPE>{RegistrationType}</GSTREGISTRATIONTYPE>");
                    xml.AppendLine($"            <BASICSHIPVESSELNO>{vehicleNo}</BASICSHIPVESSELNO>");

                    // Buyer (Bill To) Address
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine($"            <PARTYMAILINGNAME>{partyLedger}</PARTYMAILINGNAME>");
                    xml.AppendLine("            <ADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine1}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine2}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine3}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine4}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{state}</ADDRESS>");
                    xml.AppendLine("            </ADDRESS.LIST>");

                    xml.AppendLine("            <BASICBUYERADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine1}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine2}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine3}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine4}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{state}</BASICBUYERADDRESS>");
                    xml.AppendLine("            </BASICBUYERADDRESS.LIST>");

                    // Consignee (Ship To) Address
                    xml.AppendLine($"           <CONSIGNEEMAILINGNAME>{partyLedger}</CONSIGNEEMAILINGNAME>");
                    xml.AppendLine($"           <CONSIGNEEGSTIN>{partyGSTIN}</CONSIGNEEGSTIN>");
                    xml.AppendLine($"           <CONSIGNEESTATENAME>{state}</CONSIGNEESTATENAME>");
                    xml.AppendLine("            <BASICSHIPADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine1}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine2}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine3}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine4}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{state}</BASICSHIPADDRESS>");
                    xml.AppendLine("            </BASICSHIPADDRESS.LIST>");
                    xml.AppendLine("            <ISINVOICE>Yes</ISINVOICE>");
                    xml.AppendLine("            <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>");

                    // Ledger Entry (Customer) - Cr
                    xml.AppendLine("            <LEDGERENTRIES.LIST>");
                    xml.AppendLine($"              <LEDGERNAME>{partyLedger}</LEDGERNAME>");
                    xml.AppendLine("              <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                    xml.AppendLine("              <ISPARTYLEDGER>Yes</ISPARTYLEDGER>");
                    xml.AppendLine($"              <AMOUNT>-{master.sm_netamount:0.00}</AMOUNT>");
                    xml.AppendLine("            </LEDGERENTRIES.LIST>");

                    // Item-wise Inventory Entries
                    foreach (var item in details.Where(d => d.sd_qty > 0))
                    {
                        string itemName = $"{item.cat_name} {item.item_quantity}{item.item_unit} Bags";
                        string qtyStr = $"{item.sd_qty} {item.sd_unit}";
                        string rateStr = $"{item.sd_rate:0.00}/{item.sd_unit}";
                        decimal totalAmount = item.sd_qty * item.sd_rate;

                        xml.AppendLine("            <ALLINVENTORYENTRIES.LIST>");
                        xml.AppendLine($"              <STOCKITEMNAME>{item.item_fullname}</STOCKITEMNAME>");
                        xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                        xml.AppendLine("              <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"              <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                        xml.AppendLine($"              <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"              <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"              <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine("              <ISSUPPORTQTY>No</ISSUPPORTQTY>");
                        xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("                <GODOWNNAME>Main Location</GODOWNNAME>");
                        xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                        xml.AppendLine("                <DESTINATIONGODOWN>Main Location</DESTINATIONGODOWN>");
                        xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine($"                <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"                <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"                <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                        xml.AppendLine("              </BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("              <GSTDETAILS.LIST>");
                        xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                        xml.AppendLine("              <TAXABILITY>Exempt</TAXABILITY>"); // Change to "Taxable" if needed
                        xml.AppendLine("              </GSTDETAILS.LIST>");
                        xml.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine($"                <LEDGERNAME>{salesLedger}</LEDGERNAME>");
                        xml.AppendLine("                <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");

                    }

                    decimal itemTotal = details.Sum(i => Math.Round((i.item_fullname == "CHILLIES IN KGS" ? i.sd_unitvalue * i.sd_perunitrate : i.sd_qty * i.sd_rate), 2));
                    decimal roundOff = Math.Round((itemTotal + gstAmount), 0, MidpointRounding.AwayFromZero) - (itemTotal + gstAmount);
                    if (roundOff != 0)
                    {
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine("        <LEDGERNAME>Round Off</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{roundOff:0.00}</AMOUNT>");
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

                if (master.com_id == 2 & master.sm_istaxable == true)
                {
                    xml.AppendLine("<ENVELOPE>");
                    xml.AppendLine("  <HEADER><TALLYREQUEST>Import Data</TALLYREQUEST></HEADER>");
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
                    xml.AppendLine($"          <VOUCHER REMOTEID=\"{guid}\" VCHTYPE=\"TAXABLE SALES (GST)\" ACTION=\"{action}\" GUID=\"{guid}\" OBJVIEW=\"Invoice Voucher View\">");

                    xml.AppendLine($"            <DATE>{date}</DATE>");
                    xml.AppendLine($"            <GUID>{guid}</GUID>");
                    xml.AppendLine($"            <VOUCHERNUMBER>{voucherNumber}</VOUCHERNUMBER>");
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine("            <VOUCHERTYPENAME>TAXABLE SALES (GST)</VOUCHERTYPENAME>");
                    xml.AppendLine("            <CLASSNAME>Taxable Sales Gst</CLASSNAME>");
                    xml.AppendLine($"            <BASICBUYERNAME>{partyLedger}</BASICBUYERNAME>");
                    xml.AppendLine($"            <BASICBASEPARTYNAME>{partyLedger}</BASICBASEPARTYNAME>");
                    xml.AppendLine($"            <PARTYGSTIN>{partyGSTIN}</PARTYGSTIN>");
                    xml.AppendLine($"            <PLACEOFSUPPLY>{state}</PLACEOFSUPPLY>");
                    xml.AppendLine($"            <STATENAME>{state}</STATENAME>");
                    xml.AppendLine("            <COUNTRYOFRESIDENCE>India</COUNTRYOFRESIDENCE>");
                    xml.AppendLine($"            <GSTREGISTRATIONTYPE>{RegistrationType}</GSTREGISTRATIONTYPE>");
                    xml.AppendLine($"            <BASICSHIPVESSELNO>{vehicleNo}</BASICSHIPVESSELNO>");

                    // Buyer (Bill To) Address
                    xml.AppendLine($"            <PARTYLEDGERNAME>{partyLedger}</PARTYLEDGERNAME>");
                    xml.AppendLine($"            <PARTYMAILINGNAME>{partyLedger}</PARTYMAILINGNAME>");
                    xml.AppendLine("            <ADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine1}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine2}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine3}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{partyAddressLine4}</ADDRESS>");
                    xml.AppendLine($"              <ADDRESS>{state}</ADDRESS>");
                    xml.AppendLine("            </ADDRESS.LIST>");

                    xml.AppendLine("            <BASICBUYERADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine1}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine2}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine3}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{partyAddressLine4}</BASICBUYERADDRESS>");
                    xml.AppendLine($"              <BASICBUYERADDRESS>{state}</BASICBUYERADDRESS>");
                    xml.AppendLine("            </BASICBUYERADDRESS.LIST>");

                    // Consignee (Ship To) Address
                    xml.AppendLine($"           <CONSIGNEEMAILINGNAME>{partyLedger}</CONSIGNEEMAILINGNAME>");
                    xml.AppendLine($"           <CONSIGNEEGSTIN>{partyGSTIN}</CONSIGNEEGSTIN>");
                    xml.AppendLine($"           <CONSIGNEESTATENAME>{state}</CONSIGNEESTATENAME>");
                    xml.AppendLine("            <BASICSHIPADDRESS.LIST TYPE=\"String\">");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine1}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine2}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine3}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{partyAddressLine4}</BASICSHIPADDRESS>");
                    xml.AppendLine($"              <BASICSHIPADDRESS>{state}</BASICSHIPADDRESS>");
                    xml.AppendLine("            </BASICSHIPADDRESS.LIST>");
                    xml.AppendLine("            <ISINVOICE>Yes</ISINVOICE>");
                    xml.AppendLine("            <PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>");

                    xml.AppendLine("            <UDF:ISEINVAPPLICABLE.LIST TYPE=\"Logical\">");
                    xml.AppendLine("                <UDF:ISEINVAPPLICABLE>Yes</UDF:ISEINVAPPLICABLE>");
                    xml.AppendLine("            </UDF:ISEINVAPPLICABLE.LIST>");
                    // Ledger Entry (Customer) - Cr
                    xml.AppendLine("            <LEDGERENTRIES.LIST>");
                    xml.AppendLine($"              <LEDGERNAME>{partyLedger}</LEDGERNAME>");
                    xml.AppendLine("              <ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>");
                    xml.AppendLine("              <ISPARTYLEDGER>Yes</ISPARTYLEDGER>");
                    xml.AppendLine($"              <AMOUNT>-{master.sm_netamount:0.00}</AMOUNT>");
                    xml.AppendLine("            </LEDGERENTRIES.LIST>");

                    if (state == "Tamil Nadu")
                    {

                        // CGST Ledger Entry
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{cgstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{gstAmount / 2:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                        // SGST Ledger Entry
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{sgstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{gstAmount / 2:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                    }
                    else
                    {

                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine($"        <LEDGERNAME>{igstLedger}</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{gstAmount:0.00}</AMOUNT>");
                        xml.AppendLine("      </LEDGERENTRIES.LIST>");

                    }

                    // Item-wise Inventory Entries
                    foreach (var item in details.Where(d => d.sd_qty > 0))
                    {
                        string itemName = $"{item.cat_name} {item.item_quantity}{item.item_unit} Bags";
                        string qtyStr = $"{item.sd_qty} {item.sd_unit}";
                        string rateStr = $"{item.sd_rate:0.00}/{item.sd_unit}";
                        decimal totalAmount = item.sd_qty * item.sd_rate;

                        xml.AppendLine("            <ALLINVENTORYENTRIES.LIST>");
                        xml.AppendLine($"              <STOCKITEMNAME>{item.item_fullname}</STOCKITEMNAME>");
                        xml.AppendLine($"              <HSNCODE>{item.item_hsncode}</HSNCODE>");
                        xml.AppendLine("              <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"              <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                        xml.AppendLine($"              <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"              <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"              <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine("              <ISSUPPORTQTY>No</ISSUPPORTQTY>");
                        xml.AppendLine("              <BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("                <GODOWNNAME>Main Location</GODOWNNAME>");
                        xml.AppendLine("                <BATCHNAME>Primary Batch</BATCHNAME>");
                        xml.AppendLine("                <DESTINATIONGODOWN>Main Location</DESTINATIONGODOWN>");
                        xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine($"                <ACTUALQTY>{item.sd_qty} Bag</ACTUALQTY>");
                        xml.AppendLine($"                <BILLEDQTY>{item.sd_qty} Bag</BILLEDQTY>");
                        xml.AppendLine($"                <RATE>{item.sd_rate:0.00}/Bag</RATE>");
                        xml.AppendLine("              </BATCHALLOCATIONS.LIST>");
                        xml.AppendLine("              <GSTDETAILS.LIST>");
                        xml.AppendLine("              <HSNCODE>" + item.item_hsncode + "</HSNCODE>");
                        xml.AppendLine("              <TAXABILITY>Taxable</TAXABILITY>"); // Change to "Taxable" if needed
                        xml.AppendLine("              <ISREVERSECHARGEAPPLICABLE>No</ISREVERSECHARGEAPPLICABLE>");
                        xml.AppendLine("              <ISNONGSTGOODS>No</ISNONGSTGOODS>");
                        xml.AppendLine("              <GSTINELIGIBLEITC>No</GSTINELIGIBLEITC>");
                        xml.AppendLine("              <ISGSTINVOICE>Yes</ISGSTINVOICE>");
                        xml.AppendLine("              </GSTDETAILS.LIST>");
                        xml.AppendLine("              <ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine($"                <LEDGERNAME>{salesLedger}</LEDGERNAME>");
                        xml.AppendLine("                <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"                <AMOUNT>{totalAmount:0.00}</AMOUNT>");
                        xml.AppendLine("              </ACCOUNTINGALLOCATIONS.LIST>");
                        xml.AppendLine("            </ALLINVENTORYENTRIES.LIST>");

                    }

                    decimal itemTotal = details.Sum(i => Math.Round((i.item_fullname == "CHILLIES IN KGS" ? i.sd_unitvalue * i.sd_perunitrate : i.sd_qty * i.sd_rate), 2));
                    decimal roundOff = Math.Round((itemTotal + gstAmount), 0, MidpointRounding.AwayFromZero) - (itemTotal + gstAmount);
                    if (roundOff != 0)
                    {
                        xml.AppendLine("      <LEDGERENTRIES.LIST>");
                        xml.AppendLine("        <LEDGERNAME>Round Off</LEDGERNAME>");
                        xml.AppendLine("        <ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>");
                        xml.AppendLine($"        <AMOUNT>{roundOff:0.00}</AMOUNT>");
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

                return string.Empty;
            }

            public static bool SendToTally(string xmlPayload, int smid)
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
                                var salesmaster = inventoryDataContext.salesmasters.FirstOrDefault(x => x.sm_id == smid);
                                if (salesmaster != null)
                                {
                                    inventoryDataContext.usp_salesmasterUpdate(
                                        salesmaster.sm_id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date,
                                        salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount,
                                        salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount,
                                        salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount,
                                        salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking,
                                        salesmaster.sm_roundamount, salesmaster.sm_iscommissionclose, salesmaster.sm_ispackingclose,
                                        global.ucode, global.sysdate, salesmaster.sm_desc, salesmaster.sm_isclose,
                                        salesmaster.sm_isdraft, salesmaster.so_id, salesmaster.com_id,
                                        salesmaster.sm_istaxable, true, salesmaster.sm_guid, salesmaster.sm_agid
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

        private void ImportSalesToTally(int smid)
        {
            using (var db = new InventoryDataContext())
            {
                var salesMaster = db.usp_salesmasterSelect(smid, null, null, null, null, null, null).Where(x => x.sm_isdraft == true).FirstOrDefault();
                var salesDetails = db.usp_salesdetailsSelect(smid, null, null, null, null, null, null).ToList();
                if (salesMaster == null)
                {
                    MessageBox.Show("Sales record not found! (or) Record not convert to invoice", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tallyXml = TallyHelper.BuildSalesVoucherXml(salesMaster, salesDetails);
                //string xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tally_test.xml"); 
                //File.WriteAllText(xmlPath, tallyXml); 
                //Process.Start("notepad.exe", xmlPath); 

                bool success = TallyHelper.SendToTally(tallyXml, (int)salesMaster.sm_id);

                MessageBox.Show(success ? "Imported to Tally successfully!" : "Failed to import to Tally.", "Status", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                ClearData();
                LoadData();
            }
        }


        private void ImportTodaysSalesToTally(object sender, EventArgs e)
        {
            using (var db = new InventoryDataContext())
            {
                DateTime Date = importDate.Value.Date;

                var salesMasters = db.usp_salesmasterSelect(
                    null, null, Date, Date, null, null, null
                ).Where(x => x.sm_isdraft == true).ToList();

                if (salesMasters == null || salesMasters.Count == 0)
                {
                    MessageBox.Show("No sales records found for today!",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show($"Are you sure to Import Sales on {importDate.Value:dd-MM-yyyy} to Tally?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return; // User cancelled
                }

                int created = 0, altered = 0, failed = 0;
                List<string> errorMessages = new List<string>();

                foreach (var master in salesMasters)
                {
                    var salesDetails = db.usp_salesdetailsSelect(
                        master.sm_id, null, null, null, null, null, null
                    ).ToList();

                    if (salesDetails.Count == 0)
                        continue;

                    string tallyXml = TallyHelper.BuildSalesVoucherXml(master, salesDetails);
                    string response = TallyHelper.SendToTallySilent(tallyXml);

                    if (response.StartsWith("ERROR:"))
                    {
                        failed++;
                        errorMessages.Add(response);
                    }
                    else if (response.Contains("<CREATED>1</CREATED>"))
                    {
                        created++;
                        var salesmaster = db.salesmasters.FirstOrDefault(x => x.sm_id == master.sm_id);
                        if (salesmaster != null)
                        {
                            db.usp_salesmasterUpdate(
                                salesmaster.sm_id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date,
                                salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount,
                                salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount,
                                salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount,
                                salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking,
                                salesmaster.sm_roundamount, salesmaster.sm_iscommissionclose, salesmaster.sm_ispackingclose,
                                global.ucode, global.sysdate, salesmaster.sm_desc, salesmaster.sm_isclose,
                                salesmaster.sm_isdraft, salesmaster.so_id, salesmaster.com_id,
                                salesmaster.sm_istaxable, true, salesmaster.sm_guid, salesmaster.sm_agid
                            );
                        }
                    }
                    else if (response.Contains("<ALTERED>1</ALTERED>"))
                    {
                        altered++;
                        var salesmaster = db.salesmasters.FirstOrDefault(x => x.sm_id == master.sm_id);
                        if (salesmaster != null)
                        {
                            db.usp_salesmasterUpdate(
                                salesmaster.sm_id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date,
                                salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount,
                                salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount,
                                salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount,
                                salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking,
                                salesmaster.sm_roundamount, salesmaster.sm_iscommissionclose, salesmaster.sm_ispackingclose,
                                global.ucode, global.sysdate, salesmaster.sm_desc, salesmaster.sm_isclose,
                                salesmaster.sm_isdraft, salesmaster.so_id, salesmaster.com_id,
                                salesmaster.sm_istaxable, true, salesmaster.sm_guid, salesmaster.sm_agid
                            );
                        }
                    }
                    else if (response.Contains("<LINEERROR>"))
                    {
                        failed++;
                        errorMessages.Add(response);
                    }
                }

                string summary = $"Today's Sales Import Completed!\n\n" +
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



        private void txtothers_TextChanged(object sender, EventArgs e)
        {
        }

        //private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (cboCity.SelectedItem != null)
        //    {
        //        InventoryDataContext inventoryDataContext = new InventoryDataContext();
        //        using (inventoryDataContext)
        //        {
        //            ledgermasterBindingSource.Clear();
        //            var dataSource = from a in inventoryDataContext.ledgermasters
        //                             where a.led_accounttype == "Customer" && a.led_address2 == cboCity.Text.ToString()
        //                             select new
        //                             {
        //                                 a.led_id,
        //                                 a.led_name
        //                             };
        //            ledgermasterBindingSource.DataSource = dataSource;
        //        }
        //    }
        //}

        private void cbopurfrom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(cboissueto.Text.Trim() == ""))
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    IQueryable<ledgermaster> queryable = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_id == (long)Convert.ToInt32(cboissueto.SelectedValue));
                    foreach (ledgermaster lm in queryable)
                    {
                        lblAddress.Text = lm.led_address + "," + lm.led_address1 + "," + lm.led_address2 + "-" + lm.led_pincode;
                        lblGSTIN.Text = "GSTIN:" + lm.led_tin;
                        lblRateType.Text = lm.led_ratetype;
                        txtDisPer.Value = lm.led_disper;
                        chkIsFrieght.Checked = lm.led_isfreight;
                    }
                }
            }
        }

        private void dtpsaldate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                cboissueto.Focus();
            }
        }

        private void cboCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                cboissueto.Focus();
            }
        }

        private void cboissueto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                cboCom.Focus();
            }
        }

        private void cbocompany_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                cboAgent.Focus();
            }
        }

        private void dgvSales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvSales.Columns[dgvSales.CurrentCellAddress.X].Name == "cItemName")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = acsItemName;
                }
            }
            else if (dgvSales.Columns[dgvSales.CurrentCellAddress.X].Name == "cCategory")
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

        private void dgvSales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSales.CurrentCell == null)
            {
                return;
            }
            if (cboissueto == null || cboissueto.SelectedIndex == 0)
            {
                MessageBox.Show("Invalid 'Customer'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cboissueto.Focus();
                return;
            }
            int r = dgvSales.CurrentCell.RowIndex;
            int columnIndex = dgvSales.CurrentCell.ColumnIndex;
            decimal costRate;
            decimal qty;
            decimal orderQty;
            decimal stock;
            decimal rate;
            decimal taxPercentage;
            decimal unitValue;
            decimal PerUnitRate;
            decimal FrieghtCharge;
            if (columnIndex == cCategory.Index)
            {
                if (Convert.ToString(dgvSales["cCategory", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                acsItemName = new AutoCompleteStringCollection();
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    IQueryable<item> queryable = from li in inventoryDataContext.items
                                                 join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                                 where cat.cat_name == Convert.ToString(dgvSales["cCategory", r].Value)
                                                 select li;
                    foreach (item item in queryable)
                    {
                        acsItemCode.Add(item.item_code);
                        acsItemName.Add(item.item_name);
                    }
                }
                InventoryDataContext inventoryDataContext3 = new InventoryDataContext();
                if (dgvSales["cCategory", r].Value != null)
                {
                    long num = (from li in inventoryDataContext3.categories
                                where li.cat_name == dgvSales["cCategory", r].Value.ToString().Trim()
                                select li.cat_id).SingleOrDefault();
                    if (num <= 0)
                    {
                        MessageBox.Show("Invalid 'Category'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    loadgrid(num);
                    objsv.ShowDialog();
                    long itemid = global.itemid;
                    string itemname = global.itemname;
                    try
                    {
                        dgvSales["cItemName", r].Value = itemname;
                        dgvSales["cItemID", r].Value = itemid;
                        if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                        {
                            dgvSales.Rows.RemoveAt(r);
                        }
                        if (Convert.ToInt32(dgvSales["cCatID", r].Value) == 39)
                        {
                            dgvSales["cUnitValue", r].ReadOnly = false;
                            dgvSales["cQty", r].ReadOnly = true;
                            dgvSales["cQty", r].Value = 1;
                        }
                        using (inventoryDataContext3)
                        {
                            var queryable2 = from li in inventoryDataContext3.items
                                             join cat in inventoryDataContext3.categories on li.cat_id equals cat.cat_id
                                             where li.item_id == Convert.ToInt32(dgvSales["cItemID", r].Value)
                                             select new
                                             {
                                                 cat,
                                                 li
                                             };
                            foreach (var item2 in queryable2)
                            {
                                dgvSales["cCostRate", r].Value = item2.li.item_costrate;
                                dgvSales["cItemID", r].Value = item2.li.item_id;
                                dgvSales["cIsTaxable", r].Value = item2.li.item_istaxable;
                                dgvSales["cCategory", r].Value = item2.cat.cat_name;
                                dgvSales["cCatId", r].Value = item2.cat.cat_id;
                                dgvSales["cTaxPercentage", r].Value = item2.li.item_taxpercentage;
                                dgvSales["cUnit", r].Value = item2.li.item_unit;
                                dgvSales["cUnitValue", r].Value = item2.li.item_quantity;
                                dgvSales["cItemUnitType", r].Value = item2.li.item_unittype;

                                if (lblRateType.Text.ToUpper() == "MRP  (D)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_mrp;
                                    dgvSales["cPerUnitRate", r].Value = item2.li.item_perunitrate > 0 ? (item2.li.item_mrp / item2.li.item_quantity).ToString("N2") : item2.li.item_mrp.ToString("N2");
                                }
                                else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_wholesalerate;
                                    dgvSales["cPerUnitRate", r].Value = item2.li.item_perunitrate > 0 ? (item2.li.item_wholesalerate / item2.li.item_quantity).ToString("N2") : item2.li.item_wholesalerate.ToString("N2");
                                }
                                else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_specialrate;
                                    dgvSales["cPerUnitRate", r].Value = item2.li.item_perunitrate > 0 ? (item2.li.item_specialrate / item2.li.item_quantity).ToString("N2") : item2.li.item_specialrate.ToString("N2");
                                }
                                else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_supersepecialrate;
                                    dgvSales["cPerUnitRate", r].Value = item2.li.item_perunitrate > 0 ? (item2.li.item_supersepecialrate / item2.li.item_quantity).ToString("N2") : item2.li.item_supersepecialrate.ToString("N2");
                                }
                                decimal perUnitAmount = Convert.ToDecimal(dgvSales["cPerUnitRate", r].Value);
                                decimal amount = Convert.ToDecimal(dgvSales["cRate", r].Value);
                                if (amount <= 0)
                                {
                                    MessageBox.Show("Invalid rate! Rate must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dgvSales["cPerUnitRate", r].Value = "0.00";
                                    return;
                                }
                                else
                                {
                                    if (chkIsFrieght.Checked)
                                    {
                                        dgvSales["cPerUnitRate", r].Value = (perUnitAmount - 1).ToString("N2");
                                    }
                                    else
                                    {
                                        dgvSales["cPerUnitRate", r].Value = perUnitAmount.ToString("N2");
                                    }
                                }
                                dgvSales["cRate", r].Value = Convert.ToDecimal(dgvSales["cPerUnitRate", r].Value) * item2.li.item_quantity;
                                ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext3.usp_stockSelect(item2.li.item_id, null, null, null, null);
                                foreach (usp_stockSelectResult item3 in singleResult)
                                {
                                    dgvSales["cStock", r].Value = item3.stock;
                                }
                            }
                        }
                        if (Convert.ToDecimal(dgvSales["cQty", r].Value) >= 1)
                        {
                            decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                            decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                            decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);
                            dgvSales["cAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                            calacTotal();
                        }
                        dgvSales.CurrentCell = dgvSales.Rows[dgvSales.CurrentCellAddress.Y].Cells["cQty"];
                        dgvSales.Focus();
                    }
                    catch (Exception ex)
                    {
                        frmException ex2 = new frmException(ex);
                        ex2.ShowDialog();
                    }
                }
            }
            else if (columnIndex == cItemName.Index)
            {
                try
                {
                    if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                    {
                        dgvSales.Rows.RemoveAt(r);
                    }
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    using (inventoryDataContext)
                    {
                        var queryable2 = from li in inventoryDataContext.items
                                         join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                         where li.item_id == Convert.ToInt32(dgvSales["cItemID", r].Value)
                                         select new
                                         {
                                             cat,
                                             li
                                         };
                        foreach (var item4 in queryable2)
                        {
                            dgvSales["cCostRate", r].Value = item4.li.item_costrate;
                            dgvSales["cItemID", r].Value = item4.li.item_id;
                            dgvSales["cIsTaxable", r].Value = item4.li.item_istaxable;
                            dgvSales["cCategory", r].Value = item4.cat.cat_name;
                            dgvSales["cCatId", r].Value = item4.cat.cat_id;
                            if (lblRateType.Text.ToUpper() == "MRP  (D)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_mrp;
                                dgvSales["cPerUnitRate", r].Value = item4.li.item_perunitrate > 0 ? (item4.li.item_mrp / item4.li.item_quantity).ToString("N2") : item4.li.item_mrp.ToString("N2");
                            }
                            else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_wholesalerate;
                                dgvSales["cPerUnitRate", r].Value = item4.li.item_perunitrate > 0 ? (item4.li.item_wholesalerate / item4.li.item_quantity).ToString("N2") : item4.li.item_wholesalerate.ToString("N2");
                            }
                            else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_specialrate;
                                dgvSales["cPerUnitRate", r].Value = item4.li.item_perunitrate > 0 ? (item4.li.item_specialrate / item4.li.item_quantity).ToString("N2") : item4.li.item_specialrate.ToString("N2");
                            }
                            else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_supersepecialrate;
                                dgvSales["cPerUnitRate", r].Value = item4.li.item_perunitrate > 0 ? (item4.li.item_supersepecialrate / item4.li.item_quantity).ToString("N2") : item4.li.item_supersepecialrate.ToString("N2");
                            }
                            decimal perUnitAmount = Convert.ToDecimal(dgvSales["cPerUnitRate", r].Value);
                            decimal amount = Convert.ToDecimal(dgvSales["cRate", r].Value);
                            if (amount <= 0)
                            {
                                MessageBox.Show("Invalid rate! Rate must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dgvSales["cPerUnitRate", r].Value = "0.00";
                                return;
                            }
                            else
                            {
                                if (chkIsFrieght.Checked)
                                {
                                    dgvSales["cPerUnitRate", r].Value = (perUnitAmount - 1).ToString("N2");
                                }
                                else
                                {
                                    dgvSales["cPerUnitRate", r].Value = perUnitAmount.ToString("N2");
                                }
                            }
                            dgvSales["cRate", r].Value = Convert.ToDecimal(dgvSales["cPerUnitRate", r].Value) * item4.li.item_quantity;
                            ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item4.li.item_id, null, null, null, null);
                            foreach (usp_stockSelectResult item5 in singleResult)
                            {
                                dgvSales["cStock", r].Value = item5.stock;
                            }
                        }
                    }
                    dgvSales.CurrentCell = dgvSales.Rows[dgvSales.CurrentCellAddress.Y].Cells["cQty"];
                    dgvSales.Focus();
                }
                catch
                {
                }
            }

            else if (columnIndex == cUnitValue.Index)
            {
                try
                {
                    dgvSales["cUnitValue", r].ReadOnly = true;
                    decimal.TryParse(Convert.ToString(dgvSales["cStock", r].Value), out stock); // No Math.Abs here
                    decimal.TryParse(Convert.ToString(dgvSales["cUnitValue", r].Value), out unitValue);
                    decimal.TryParse(Convert.ToString(dgvSales["cPerUnitRate", r].Value), out PerUnitRate);
                    decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                    if (dgvSales["cCatID", r].Value != null && Convert.ToInt32(dgvSales["cCatID", r].Value) == 39)
                    {
                        dgvSales["cUnitValue", r].ReadOnly = false;
                        if (unitValue <= stock)
                        {
                            dgvSales["cUnitValue", r].Value = unitValue;
                        }
                        else
                        {
                            MessageBox.Show("You have only " + stock + " Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            dgvSales["cUnitValue", dgvSales.CurrentRow.Index].Value = null;
                            dgvSales["cRate", dgvSales.CurrentRow.Index].Value = null;
                            dgvSales["cAmount", dgvSales.CurrentRow.Index].Value = null;
                            dgvSales["cTaxAmount", dgvSales.CurrentRow.Index].Value = null;
                            dgvSales.CurrentCell = dgvSales["cUnitValue", dgvSales.CurrentRow.Index];
                            dgvSales.CurrentCell = dgvSales.Rows[dgvSales.CurrentCellAddress.Y].Cells["cUnitValue"];
                            dgvSales.Focus();
                            return;
                        }

                        dgvSales["cRate", r].Value = unitValue * PerUnitRate;
                        decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                        decimal.TryParse(Convert.ToString(dgvSales["cCostRate", r].Value), out costRate);
                        decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);
                        decimal.TryParse(Convert.ToString(dgvSales["cUnitValue", r].Value), out unitValue);
                        dgvSales["cFrieghtCharge", r].Value = 0.ToString("N2");

                        decimal.TryParse(Convert.ToString(dgvSales["cFrieghtCharge", r].Value), out FrieghtCharge);

                        dgvSales["cAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                        dgvSales["cTaxAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                        dgvSales["cCostAmount", r].Value = ((costRate > 0m && qty > 0m) ? ((object)(costRate * qty)) : null);
                        calacTotal();
                        dgvSales.CurrentCell = dgvSales.Rows[dgvSales.CurrentCellAddress.Y].Cells["cUnit"];
                        dgvSales.Focus();
                    }
                }
                catch
                {
                }
            }

            else if (columnIndex == cPerUnitRate.Index)
            {
                decimal.TryParse(Convert.ToString(dgvSales["cUnitValue", r].Value), out unitValue);
                decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                decimal.TryParse(Convert.ToString(dgvSales["cPerUnitRate", r].Value), out PerUnitRate);
                decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);

                dgvSales["cRate", r].Value = unitValue * PerUnitRate;
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);

                if (Convert.ToInt32(dgvSales["cCatID", r].Value) == 39)
                {
                    dgvSales["cUnitValue", r].ReadOnly = false;
                    dgvSales["cQty", r].ReadOnly = true;
                    dgvSales["cFrieghtCharge", r].Value = 0.ToString("N2");
                }
                else
                {
                    if (chkIsFrieght.Checked)
                        dgvSales["cFrieghtCharge", r].Value = ((rate > 0m && qty > 0m) ? ((object)(unitValue * qty).ToString("N2")) : null);
                    else
                        dgvSales["cFrieghtCharge", r].Value = null;
                }

                decimal.TryParse(Convert.ToString(dgvSales["cFrieghtCharge", r].Value), out FrieghtCharge);

                dgvSales["cAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                dgvSales["cTaxAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                calacTotal();
                SetColumnIndex method = Mymethod;
                dgvSales.BeginInvoke(method, "cCategory");

            }

            else if (columnIndex == cQty.Index)
            {
                if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                decimal sd_orderqty = Convert.ToDecimal(dgvSales["cOrderQty", r].Value);
                qty = Math.Abs(qty); // Keep this to prevent negative quantity input

                decimal.TryParse(Convert.ToString(dgvSales["cStock", r].Value), out stock); // No Math.Abs here

                dgvSales["cQty", r].Value = (qty > 0m) ? (object)qty : null;

                if (qty <= stock)
                {
                    dgvSales["cQty", r].Value = qty;
                }
                else
                {
                    MessageBox.Show("You have only " + stock + " Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dgvSales["cQty", dgvSales.CurrentRow.Index].Value = null;
                    int qtyColIndex = dgvSales.Columns["cQty"].Index;
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        dgvSales.CurrentCell = dgvSales[qtyColIndex - 1, dgvSales.CurrentRow.Index];
                    }));
                    //dgvSales.CurrentCell = dgvSales["cQty" - 1, dgvSales.CurrentRow.Index];
                    //dgvSales.BeginEdit(true);
                    //dgvSales.Focus();
                    return;
                }
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                decimal.TryParse(Convert.ToString(dgvSales["cCostRate", r].Value), out costRate);
                decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);
                decimal.TryParse(Convert.ToString(dgvSales["cUnitValue", r].Value), out unitValue);
                if (chkIsFrieght.Checked == true)
                    dgvSales["cFrieghtCharge", r].Value = ((rate > 0m && qty > 0m) ? ((object)(unitValue * qty)) : null);
                else
                    dgvSales["cFrieghtCharge", r].Value = null;

                decimal.TryParse(Convert.ToString(dgvSales["cFrieghtCharge", r].Value), out FrieghtCharge);

                dgvSales["cAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                dgvSales["cTaxAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                dgvSales["cCostAmount", r].Value = ((costRate > 0m && qty > 0m) ? ((object)(costRate * qty)) : null);
                calacTotal();
                SetColumnIndex method = Mymethod;
                dgvSales.BeginInvoke(method, "cCategory");
            }
            else if (columnIndex == cRate.Index)
            {
                decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                qty = Math.Abs(qty);
                decimal.TryParse(Convert.ToString(dgvSales["cStock", r].Value), out stock);
                stock = Math.Abs(stock);
                decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);
                if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                rate = Math.Abs(rate);
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                decimal.TryParse(Convert.ToString(dgvSales["cCostRate", r].Value), out costRate);
                dgvSales["cAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                dgvSales["cTaxAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                dgvSales["cCostAmount", r].Value = ((costRate > 0m && qty > 0m) ? ((object)(costRate * qty)) : null);
                dgvSales["cRate", r].Value = rate.ToString("N2");
                calacTotal();
                SetColumnIndex method = Mymethod;
                dgvSales.BeginInvoke(method, "cCategory");
            }
            else if (columnIndex == cUnitValue.Index)
            {
                decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                decimal.TryParse(Convert.ToString(dgvSales["cCostRate", r].Value), out costRate);
                decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);
                decimal.TryParse(Convert.ToString(dgvSales["cUnitValue", r].Value), out unitValue);
                decimal.TryParse(Convert.ToString(dgvSales["cPerUnitRate", r].Value), out PerUnitRate);
                decimal.TryParse(Convert.ToString(dgvSales["cFrieghtCharge", r].Value), out FrieghtCharge);

                if (dgvSales["cCategory", r].Value == "Chillies")
                    dgvSales["cFrieghtCharge", r].Value = 0;
                else
                    dgvSales["cFrieghtCharge", r].Value = FrieghtCharge;

                dgvSales["cRate", r].Value = unitValue * PerUnitRate;
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                dgvSales["cAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) + ((rate * qty) * taxPercentage / 100))) : null);
                dgvSales["cTaxAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                dgvSales["cCostAmount", r].Value = ((costRate > 0m && qty > 0m) ? ((object)(costRate * qty)) : null);
                calacTotal();
                SetColumnIndex method = Mymethod;
                dgvSales.BeginInvoke(method, "cCategory");
            }
        }

        private void cboRateType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && lblRateType.Text.Trim() != string.Empty)
            {
                dgvSales.CurrentCell = dgvSales["cCategory", 0];
                dgvSales.Focus();
            }
        }

        //private void cboCityView_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (cboCityView.SelectedItem != null)
        //    {
        //        InventoryDataContext inventoryDataContext = new InventoryDataContext();
        //        using (inventoryDataContext)
        //        {
        //            ledgermasterViewBindingSource.Clear();
        //            var source = from a in inventoryDataContext.ledgermasters
        //                         where a.led_accounttype == "Customer" && a.led_address2 == cboCityView.Text.ToString()
        //                         select new
        //                         {
        //                             a.led_id,
        //                             a.led_name
        //                         };
        //            ledgermasterViewBindingSource.DataSource = source.OrderBy(x => x.led_name);
        //        }
        //    }
        //}

        private void txtDisPer_Leave(object sender, EventArgs e)
        {
            if (txtDisPer.Tag == null)
            {
                if (txtDisPer.Value > 100m)
                {
                    txtDiscount.Text = "0";
                }
                else
                {
                    calacTotal();
                }
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.Text != null && !(txtDiscount.Text == string.Empty) && Convert.ToDecimal(txtDiscount.Text) > 0m)
            {
                List<string> list = new List<string>();
                list.Add("cQty");
                list.Add("cAmount");
                list.Add("cCostAmount");
                List<decimal> totalSNo = bus.getTotalSNo(dgvSales, "cSNo", list);
                txtDisPer.Text = "0";
                decimal num = txtDiscount.Value / txttotamt.Value * 100m;
                txtDisPer.Text = $"{num:0.00}";
                txtProfit.Text = $"{txttotamt.Value - ((decimal)Convert.ToInt32(totalSNo[2]) + Convert.ToDecimal(txtDiscount.Text)):0.00}";
                txtnetamt.Text = $"{txttotamt.Value + txtothercharges.Value + txtTaxAmt.Value - txtDiscount.Value:0.00}";
                txtFinalnetamount.Text = Math.Round(txtnetamt.Value).ToString();
                txtFinalnetamount.Text = string.Format("{0:0.00}", txtFinalnetamount.Value.ToString("N2"));
                txtothercharges.Text = string.Format("{0:0.00}", txtothercharges.Value.ToString("N2"));
                txtRoundOff.Text = $"{txtFinalnetamount.Value - txtnetamt.Value:0.00}";
                if (txtRoundOff.Text.Contains("-"))
                {
                    txtRoundOff.ForeColor = Color.Red;
                }
                else
                {
                    txtRoundOff.ForeColor = Color.Green;
                }
            }
        }

        private void txtopno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                dtpsaldate.Focus();
            }
        }

        private void txtDisPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                calacTotal();
                txtDiscount.Focus();
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtTaxPer.Focus();
            }
        }

        private void cboCustomerView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdprint_Click(null, null);
            }
        }

        private void txtSearchBillNo_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdprint_Click(null, null);
            }
        }

        //private void txtTaxPer_Leave(object sender, EventArgs e)
        //{
        //    if (txtTaxPer.Tag == null)
        //    {
        //        if (txtTaxPer.Value > 100m)
        //        {
        //            txtTaxAmt.Text = "0";
        //        }
        //        else
        //        {
        //            calacTotal();
        //        }
        //    }
        //}

        private void txtTaxAmt_Leave(object sender, EventArgs e)
        {
            if (txtTaxAmt.Text != null && !(txtTaxAmt.Text == string.Empty) && Convert.ToDecimal(txtTaxAmt.Text) > 0m)
            {
                List<string> list = new List<string>();
                list.Add("cQty");
                list.Add("cAmount");
                list.Add("cCostAmount");
                List<decimal> totalSNo = bus.getTotalSNo(dgvSales, "cSNo", list);
                txtTaxPer.Text = "0";
                decimal num = txtTaxAmt.Value / (txttotamt.Value - txtDiscount.Value) * 100m;
                txtTaxPer.Text = $"{num:0.00}";
                txtnetamt.Text = $"{txttotamt.Value + txtothercharges.Value - txtDiscount.Value:0.00}";
                txtFinalnetamount.Text = Math.Round(txtnetamt.Value).ToString();
                txtFinalnetamount.Text = string.Format("{0:0.00}", txtFinalnetamount.Value.ToString("N2"));
                txtothercharges.Text = string.Format("{0:0.00}", txtothercharges.Value.ToString("N2"));
                txtRoundOff.Text = $"{txtFinalnetamount.Value - txtnetamt.Value:0.00}";
                if (txtRoundOff.Text.Contains("-"))
                {
                    txtRoundOff.ForeColor = Color.Red;
                }
                else
                {
                    txtRoundOff.ForeColor = Color.Green;
                }
            }
        }

        private void txtTaxPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                calacTotal();
                txtTaxAmt.Focus();
            }
        }

        private void txtTaxAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdsave.Focus();
            }
        }

        private void cboCityView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cboCustomerView.Focus();
            }
        }

        private void txtothercharges_Leave(object sender, EventArgs e)
        {
            if (txtothercharges.Tag == null)
            {
                calacTotal();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablemain = new System.Windows.Forms.TableLayoutPanel();
            this.tableentry = new System.Windows.Forms.TableLayoutPanel();
            this.lblopno = new System.Windows.Forms.Label();
            this.txtopno = new mylib.decimalbox(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblRateType = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblfrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.dtpsaldate = new System.Windows.Forms.DateTimePicker();
            this.cboissueto = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCom = new System.Windows.Forms.Label();
            this.chkIsFrieght = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboCom = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboAgent = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lbltitle = new System.Windows.Forms.Label();
            this.tablecmd = new System.Windows.Forms.TableLayoutPanel();
            this.lblGSTIN = new System.Windows.Forms.Label();
            this.cmdsave = new mylib.lightbutton();
            this.cmdrefresh = new mylib.lightbutton();
            this.cmdclose = new mylib.lightbutton();
            this.cmdview = new mylib.lightbutton();
            this.tablesum = new System.Windows.Forms.TableLayoutPanel();
            this.lbltotqty = new System.Windows.Forms.Label();
            this.txttotqty = new mylib.decimalbox(this.components);
            this.lblPacking = new System.Windows.Forms.Label();
            this.txtDisPer = new mylib.decimalbox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblTaxAmt = new System.Windows.Forms.Label();
            this.txtTaxAmt = new mylib.decimalbox(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txttotamt = new mylib.decimalbox(this.components);
            this.txtnetamt = new mylib.decimalbox(this.components);
            this.txtDiscount = new mylib.decimalbox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtothercharges = new mylib.decimalbox(this.components);
            this.txtRoundOff = new System.Windows.Forms.Label();
            this.lblTaxPer = new System.Windows.Forms.Label();
            this.txtTaxPer = new mylib.decimalbox(this.components);
            this.lblFrieght = new System.Windows.Forms.Label();
            this.txtFrieght = new mylib.decimalbox(this.components);
            this.lblnetamt = new System.Windows.Forms.Label();
            this.txtFinalnetamount = new mylib.decimalbox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtProfit = new mylib.decimalbox(this.components);
            this.pnlentry = new System.Windows.Forms.Panel();
            this.dgvSales = new mylib.mygrid();
            this.cSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIsTaxable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPerUnitRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemUnitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTaxPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrieghtCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCostRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSdID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCostAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOdUnitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlview = new System.Windows.Forms.Panel();
            this.tableview = new System.Windows.Forms.TableLayoutPanel();
            this.lblsubtitle = new System.Windows.Forms.Label();
            this.dglist = new mylib.mygrid();
            this.ldelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ledit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.lEstimateprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.isDraft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ldc = new System.Windows.Forms.DataGridViewImageColumn();
            this.smidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smbooknoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smrefnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smtotqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTaxableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smnetamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smdisamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smpackingchargeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smitemcountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smudateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lImport = new System.Windows.Forms.DataGridViewImageColumn();
            this.isImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smdescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspsalesmasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.cboCustomerView = new System.Windows.Forms.ComboBox();
            this.ledgermasterViewBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblfdate = new System.Windows.Forms.Label();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.lblhyp = new System.Windows.Forms.Label();
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.companyViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblBillNo = new System.Windows.Forms.Label();
            this.txtSearchBillNo = new System.Windows.Forms.TextBox();
            this.lblImportDate = new System.Windows.Forms.Label();
            this.importDate = new System.Windows.Forms.DateTimePicker();
            this.importButton = new System.Windows.Forms.Button();
            this.ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboCityView = new System.Windows.Forms.ComboBox();
            this.ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.smtotamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smprofitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablemain.SuspendLayout();
            this.tableentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource1)).BeginInit();
            this.tablecmd.SuspendLayout();
            this.tablesum.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.pnlview.SuspendLayout();
            this.tableview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspsalesmasterSelectResultBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tablemain
            // 
            this.tablemain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tablemain.ColumnCount = 1;
            this.tablemain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.Controls.Add(this.tableentry, 0, 1);
            this.tablemain.Controls.Add(this.lbltitle, 0, 0);
            this.tablemain.Controls.Add(this.tablecmd, 0, 4);
            this.tablemain.Controls.Add(this.tablesum, 0, 3);
            this.tablemain.Controls.Add(this.pnlentry, 0, 2);
            this.tablemain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablemain.Location = new System.Drawing.Point(0, 0);
            this.tablemain.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tablemain.Name = "tablemain";
            this.tablemain.RowCount = 5;
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tablemain.Size = new System.Drawing.Size(1658, 749);
            this.tablemain.TabIndex = 0;
            // 
            // tableentry
            // 
            this.tableentry.ColumnCount = 9;
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableentry.Controls.Add(this.lblopno, 0, 0);
            this.tableentry.Controls.Add(this.txtopno, 1, 0);
            this.tableentry.Controls.Add(this.lblAddress, 0, 2);
            this.tableentry.Controls.Add(this.lblRateType, 2, 2);
            this.tableentry.Controls.Add(this.cboCity, 5, 2);
            this.tableentry.Controls.Add(this.lblfrom, 2, 0);
            this.tableentry.Controls.Add(this.label2, 4, 2);
            this.tableentry.Controls.Add(this.lbldate, 0, 1);
            this.tableentry.Controls.Add(this.dtpsaldate, 1, 1);
            this.tableentry.Controls.Add(this.cboissueto, 3, 0);
            this.tableentry.Controls.Add(this.lblCom, 4, 0);
            this.tableentry.Controls.Add(this.chkIsFrieght, 5, 1);
            this.tableentry.Controls.Add(this.lblType, 6, 0);
            this.tableentry.Controls.Add(this.cboCom, 5, 0);
            this.tableentry.Controls.Add(this.cboAgent, 7, 0);
            this.tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableentry.Location = new System.Drawing.Point(7, 44);
            this.tableentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableentry.Name = "tableentry";
            this.tableentry.RowCount = 3;
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableentry.Size = new System.Drawing.Size(1644, 136);
            this.tableentry.TabIndex = 4;
            // 
            // lblopno
            // 
            this.lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblopno.AutoSize = true;
            this.lblopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblopno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblopno.Location = new System.Drawing.Point(5, 11);
            this.lblopno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblopno.Name = "lblopno";
            this.lblopno.Size = new System.Drawing.Size(74, 23);
            this.lblopno.TabIndex = 1;
            this.lblopno.Text = "Bill No";
            // 
            // txtopno
            // 
            this.txtopno.AllowFormat = false;
            this.txtopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtopno.BackColor = System.Drawing.Color.White;
            this.txtopno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtopno.DecimalPlaces = 0;
            this.txtopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtopno.Location = new System.Drawing.Point(155, 7);
            this.txtopno.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtopno.Name = "txtopno";
            this.txtopno.ReadOnly = true;
            this.txtopno.RightAlign = true;
            this.txtopno.Size = new System.Drawing.Size(193, 30);
            this.txtopno.TabIndex = 0;
            this.txtopno.TabStop = false;
            this.txtopno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtopno.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtopno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtopno_KeyDown);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.tableentry.SetColumnSpan(this.lblAddress, 2);
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.Red;
            this.lblAddress.Location = new System.Drawing.Point(5, 101);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(16, 23);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = ".";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRateType
            // 
            this.lblRateType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRateType.AutoSize = true;
            this.tableentry.SetColumnSpan(this.lblRateType, 2);
            this.lblRateType.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblRateType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblRateType.Location = new System.Drawing.Point(358, 101);
            this.lblRateType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRateType.Name = "lblRateType";
            this.lblRateType.Size = new System.Drawing.Size(16, 23);
            this.lblRateType.TabIndex = 10;
            this.lblRateType.Text = ".";
            this.lblRateType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCity
            // 
            this.cboCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableentry.SetColumnSpan(this.cboCity, 2);
            this.cboCity.DataSource = this.ledgermasterCityBindingSource;
            this.cboCity.DisplayMember = "led_address2";
            this.cboCity.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(833, 97);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(236, 31);
            this.cboCity.TabIndex = 2;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.Visible = false;
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblfrom
            // 
            this.lblfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfrom.Location = new System.Drawing.Point(358, 11);
            this.lblfrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(102, 23);
            this.lblfrom.TabIndex = 10;
            this.lblfrom.Text = "Customer";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(683, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "City";
            this.label2.Visible = false;
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldate.Location = new System.Drawing.Point(5, 56);
            this.lbldate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(91, 23);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Bill Date";
            // 
            // dtpsaldate
            // 
            this.dtpsaldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpsaldate.CustomFormat = "dd-MM-yyyy";
            this.dtpsaldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpsaldate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpsaldate.Location = new System.Drawing.Point(155, 52);
            this.dtpsaldate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtpsaldate.Name = "dtpsaldate";
            this.dtpsaldate.Size = new System.Drawing.Size(190, 30);
            this.dtpsaldate.TabIndex = 1;
            this.dtpsaldate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpsaldate_KeyDown);
            // 
            // cboissueto
            // 
            this.cboissueto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboissueto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboissueto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboissueto.DataSource = this.ledgermasterBindingSource;
            this.cboissueto.DisplayMember = "led_name";
            this.cboissueto.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboissueto.FormattingEnabled = true;
            this.cboissueto.Location = new System.Drawing.Point(508, 7);
            this.cboissueto.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboissueto.Name = "cboissueto";
            this.cboissueto.Size = new System.Drawing.Size(160, 31);
            this.cboissueto.TabIndex = 3;
            this.cboissueto.ValueMember = "led_id";
            this.cboissueto.SelectedValueChanged += new System.EventHandler(this.cbopurfrom_SelectedValueChanged);
            this.cboissueto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboissueto_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblCom
            // 
            this.lblCom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCom.AutoSize = true;
            this.lblCom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCom.Location = new System.Drawing.Point(683, 11);
            this.lblCom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(99, 23);
            this.lblCom.TabIndex = 12;
            this.lblCom.Text = "Company";
            this.lblCom.Click += new System.EventHandler(this.lblCom_Click);
            // 
            // chkIsFrieght
            // 
            this.chkIsFrieght.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsFrieght.Enabled = false;
            this.chkIsFrieght.ForeColor = System.Drawing.Color.Red;
            this.chkIsFrieght.Location = new System.Drawing.Point(831, 53);
            this.chkIsFrieght.Name = "chkIsFrieght";
            this.chkIsFrieght.Size = new System.Drawing.Size(200, 29);
            this.chkIsFrieght.TabIndex = 11;
            this.chkIsFrieght.Text = "Frieght Charge Applicable";
            this.chkIsFrieght.UseVisualStyleBackColor = true;
            this.chkIsFrieght.CheckedChanged += new System.EventHandler(this.chkIsFrieght_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblType.Location = new System.Drawing.Point(1103, 11);
            this.lblType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(66, 23);
            this.lblType.TabIndex = 14;
            this.lblType.Text = "Agent";
            this.lblType.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboCom
            // 
            this.cboCom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCom.DataSource = this.companyBindingSource;
            this.cboCom.DisplayMember = "com_name";
            this.cboCom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCom.FormattingEnabled = true;
            this.cboCom.Location = new System.Drawing.Point(833, 7);
            this.cboCom.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCom.Name = "cboCom";
            this.cboCom.Size = new System.Drawing.Size(220, 31);
            this.cboCom.TabIndex = 13;
            this.cboCom.ValueMember = "com_id";
            this.cboCom.SelectedValueChanged += new System.EventHandler(this.cboCom_SelectedValueChanged);
            this.cboCom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbocompany_KeyDown);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(standard.classes.company);
            // 
            // cboAgent
            // 
            this.cboAgent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboAgent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAgent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgent.DataSource = this.ledgermasterBindingSource1;
            this.cboAgent.DisplayMember = "led_name";
            this.cboAgent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboAgent.FormattingEnabled = true;
            this.cboAgent.Location = new System.Drawing.Point(1251, 7);
            this.cboAgent.Name = "cboAgent";
            this.cboAgent.Size = new System.Drawing.Size(160, 31);
            this.cboAgent.TabIndex = 15;
            this.cboAgent.ValueMember = "led_id";
            this.cboAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboAgent_KeyDown);
            // 
            // ledgermasterBindingSource1
            // 
            this.ledgermasterBindingSource1.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(794, 7);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(70, 23);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "SALES";
            // 
            // tablecmd
            // 
            this.tablecmd.ColumnCount = 5;
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tablecmd.Controls.Add(this.lblGSTIN, 0, 0);
            this.tablecmd.Controls.Add(this.cmdsave, 1, 0);
            this.tablecmd.Controls.Add(this.cmdrefresh, 2, 0);
            this.tablecmd.Controls.Add(this.cmdclose, 4, 0);
            this.tablecmd.Controls.Add(this.cmdview, 3, 0);
            this.tablecmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablecmd.Location = new System.Drawing.Point(7, 694);
            this.tablecmd.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tablecmd.Name = "tablecmd";
            this.tablecmd.RowCount = 1;
            this.tablecmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tablecmd.Size = new System.Drawing.Size(1644, 46);
            this.tablecmd.TabIndex = 3;
            // 
            // lblGSTIN
            // 
            this.lblGSTIN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGSTIN.AutoSize = true;
            this.lblGSTIN.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblGSTIN.ForeColor = System.Drawing.Color.Red;
            this.lblGSTIN.Location = new System.Drawing.Point(5, 11);
            this.lblGSTIN.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGSTIN.Name = "lblGSTIN";
            this.lblGSTIN.Size = new System.Drawing.Size(16, 23);
            this.lblGSTIN.TabIndex = 11;
            this.lblGSTIN.Text = ".";
            // 
            // cmdsave
            // 
            this.cmdsave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdsave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdsave.Location = new System.Drawing.Point(1129, 7);
            this.cmdsave.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(120, 32);
            this.cmdsave.TabIndex = 0;
            this.cmdsave.Text = "&Save";
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // cmdrefresh
            // 
            this.cmdrefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdrefresh.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdrefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdrefresh.Location = new System.Drawing.Point(1259, 7);
            this.cmdrefresh.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdrefresh.Name = "cmdrefresh";
            this.cmdrefresh.Size = new System.Drawing.Size(120, 32);
            this.cmdrefresh.TabIndex = 1;
            this.cmdrefresh.Text = "&Refresh";
            this.cmdrefresh.UseVisualStyleBackColor = true;
            this.cmdrefresh.Click += new System.EventHandler(this.cmdrefresh_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1519, 7);
            this.cmdclose.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(120, 32);
            this.cmdclose.TabIndex = 3;
            this.cmdclose.Text = "&Close";
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // cmdview
            // 
            this.cmdview.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdview.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdview.Location = new System.Drawing.Point(1389, 7);
            this.cmdview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdview.Name = "cmdview";
            this.cmdview.Size = new System.Drawing.Size(120, 32);
            this.cmdview.TabIndex = 2;
            this.cmdview.Text = "&View";
            this.cmdview.UseVisualStyleBackColor = true;
            this.cmdview.Click += new System.EventHandler(this.cmdview_Click);
            // 
            // tablesum
            // 
            this.tablesum.ColumnCount = 13;
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tablesum.Controls.Add(this.lbltotqty, 0, 0);
            this.tablesum.Controls.Add(this.txttotqty, 1, 0);
            this.tablesum.Controls.Add(this.lblPacking, 3, 0);
            this.tablesum.Controls.Add(this.txtDisPer, 4, 0);
            this.tablesum.Controls.Add(this.label3, 0, 1);
            this.tablesum.Controls.Add(this.lblTaxAmt, 6, 1);
            this.tablesum.Controls.Add(this.txtTaxAmt, 7, 1);
            this.tablesum.Controls.Add(this.tableLayoutPanel2, 11, 0);
            this.tablesum.Controls.Add(this.txtDiscount, 4, 1);
            this.tablesum.Controls.Add(this.label7, 3, 1);
            this.tablesum.Controls.Add(this.txtothercharges, 1, 1);
            this.tablesum.Controls.Add(this.txtRoundOff, 11, 1);
            this.tablesum.Controls.Add(this.lblTaxPer, 8, 0);
            this.tablesum.Controls.Add(this.txtTaxPer, 8, 1);
            this.tablesum.Controls.Add(this.lblFrieght, 6, 0);
            this.tablesum.Controls.Add(this.txtFrieght, 7, 0);
            this.tablesum.Controls.Add(this.lblnetamt, 9, 0);
            this.tablesum.Controls.Add(this.txtFinalnetamount, 10, 0);
            this.tablesum.Controls.Add(this.label4, 9, 1);
            this.tablesum.Controls.Add(this.txtProfit, 10, 1);
            this.tablesum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesum.Location = new System.Drawing.Point(7, 592);
            this.tablesum.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tablesum.Name = "tablesum";
            this.tablesum.RowCount = 2;
            this.tablesum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablesum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablesum.Size = new System.Drawing.Size(1644, 86);
            this.tablesum.TabIndex = 2;
            // 
            // lbltotqty
            // 
            this.lbltotqty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotqty.AutoSize = true;
            this.lbltotqty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltotqty.Location = new System.Drawing.Point(5, 10);
            this.lbltotqty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltotqty.Name = "lbltotqty";
            this.lbltotqty.Size = new System.Drawing.Size(59, 23);
            this.lbltotqty.TabIndex = 2;
            this.lbltotqty.Text = "Total";
            // 
            // txttotqty
            // 
            this.txttotqty.AllowFormat = false;
            this.txttotqty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttotqty.BackColor = System.Drawing.Color.White;
            this.txttotqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotqty.DecimalPlaces = 2;
            this.txttotqty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotqty.Location = new System.Drawing.Point(90, 7);
            this.txttotqty.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txttotqty.Name = "txttotqty";
            this.txttotqty.ReadOnly = true;
            this.txttotqty.RightAlign = true;
            this.txttotqty.Size = new System.Drawing.Size(100, 30);
            this.txttotqty.TabIndex = 5;
            this.txttotqty.TabStop = false;
            this.txttotqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotqty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblPacking
            // 
            this.lblPacking.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPacking.AutoSize = true;
            this.lblPacking.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblPacking.Location = new System.Drawing.Point(270, 10);
            this.lblPacking.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPacking.Name = "lblPacking";
            this.lblPacking.Size = new System.Drawing.Size(123, 23);
            this.lblPacking.TabIndex = 10;
            this.lblPacking.Text = "Discount %";
            // 
            // txtDisPer
            // 
            this.txtDisPer.AllowFormat = false;
            this.txtDisPer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDisPer.BackColor = System.Drawing.Color.White;
            this.txtDisPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisPer.DecimalPlaces = 2;
            this.txtDisPer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisPer.Location = new System.Drawing.Point(420, 7);
            this.txtDisPer.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtDisPer.Name = "txtDisPer";
            this.txtDisPer.ReadOnly = true;
            this.txtDisPer.RightAlign = true;
            this.txtDisPer.Size = new System.Drawing.Size(100, 30);
            this.txtDisPer.TabIndex = 1;
            this.txtDisPer.TabStop = false;
            this.txtDisPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisPer.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDisPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDisPer_KeyDown);
            this.txtDisPer.Leave += new System.EventHandler(this.txtDisPer_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(5, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Others";
            // 
            // lblTaxAmt
            // 
            this.lblTaxAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTaxAmt.AutoSize = true;
            this.lblTaxAmt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblTaxAmt.Location = new System.Drawing.Point(600, 53);
            this.lblTaxAmt.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTaxAmt.Name = "lblTaxAmt";
            this.lblTaxAmt.Size = new System.Drawing.Size(89, 23);
            this.lblTaxAmt.TabIndex = 10;
            this.lblTaxAmt.Text = "Tax Amt";
            // 
            // txtTaxAmt
            // 
            this.txtTaxAmt.AllowFormat = false;
            this.txtTaxAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaxAmt.BackColor = System.Drawing.Color.White;
            this.txtTaxAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxAmt.DecimalPlaces = 2;
            this.txtTaxAmt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxAmt.Location = new System.Drawing.Point(700, 50);
            this.txtTaxAmt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtTaxAmt.Name = "txtTaxAmt";
            this.txtTaxAmt.ReadOnly = true;
            this.txtTaxAmt.RightAlign = true;
            this.txtTaxAmt.Size = new System.Drawing.Size(140, 30);
            this.txtTaxAmt.TabIndex = 2;
            this.txtTaxAmt.TabStop = false;
            this.txtTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTaxAmt.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTaxAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaxAmt_KeyDown);
            this.txtTaxAmt.Leave += new System.EventHandler(this.txtTaxAmt_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Controls.Add(this.txttotamt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtnetamt, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1203, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 37);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // txttotamt
            // 
            this.txttotamt.AllowFormat = false;
            this.txttotamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttotamt.BackColor = System.Drawing.Color.White;
            this.txttotamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotamt.DecimalPlaces = 2;
            this.txttotamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotamt.Location = new System.Drawing.Point(5, 7);
            this.txttotamt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txttotamt.Name = "txttotamt";
            this.txttotamt.ReadOnly = true;
            this.txttotamt.RightAlign = true;
            this.txttotamt.Size = new System.Drawing.Size(18, 30);
            this.txttotamt.TabIndex = 6;
            this.txttotamt.TabStop = false;
            this.txttotamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotamt.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txttotamt.Visible = false;
            // 
            // txtnetamt
            // 
            this.txtnetamt.AllowFormat = false;
            this.txtnetamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtnetamt.BackColor = System.Drawing.Color.White;
            this.txtnetamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnetamt.DecimalPlaces = 2;
            this.txtnetamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtnetamt.Location = new System.Drawing.Point(33, 7);
            this.txtnetamt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtnetamt.Name = "txtnetamt";
            this.txtnetamt.RightAlign = true;
            this.txtnetamt.Size = new System.Drawing.Size(106, 30);
            this.txtnetamt.TabIndex = 6;
            this.txtnetamt.TabStop = false;
            this.txtnetamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtnetamt.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtnetamt.Visible = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.AllowFormat = false;
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.DecimalPlaces = 2;
            this.txtDiscount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(420, 50);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.RightAlign = true;
            this.txtDiscount.Size = new System.Drawing.Size(100, 30);
            this.txtDiscount.TabIndex = 2;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label7.Location = new System.Drawing.Point(270, 53);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Discount Amt";
            // 
            // txtothercharges
            // 
            this.txtothercharges.AllowFormat = false;
            this.txtothercharges.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtothercharges.BackColor = System.Drawing.Color.White;
            this.txtothercharges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtothercharges.DecimalPlaces = 2;
            this.txtothercharges.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtothercharges.Location = new System.Drawing.Point(90, 50);
            this.txtothercharges.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtothercharges.Name = "txtothercharges";
            this.txtothercharges.RightAlign = true;
            this.txtothercharges.Size = new System.Drawing.Size(100, 30);
            this.txtothercharges.TabIndex = 2;
            this.txtothercharges.TabStop = false;
            this.txtothercharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtothercharges.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtothercharges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtothers_KeyDown);
            this.txtothercharges.Leave += new System.EventHandler(this.txtothercharges_Leave);
            // 
            // txtRoundOff
            // 
            this.txtRoundOff.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtRoundOff.AutoSize = true;
            this.txtRoundOff.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtRoundOff.ForeColor = System.Drawing.Color.Red;
            this.txtRoundOff.Location = new System.Drawing.Point(1205, 53);
            this.txtRoundOff.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtRoundOff.Name = "txtRoundOff";
            this.txtRoundOff.Size = new System.Drawing.Size(16, 23);
            this.txtRoundOff.TabIndex = 12;
            this.txtRoundOff.Text = ".";
            this.txtRoundOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRoundOff.Visible = false;
            // 
            // lblTaxPer
            // 
            this.lblTaxPer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTaxPer.AutoSize = true;
            this.lblTaxPer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblTaxPer.Location = new System.Drawing.Point(850, 0);
            this.lblTaxPer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTaxPer.Name = "lblTaxPer";
            this.lblTaxPer.Size = new System.Drawing.Size(50, 43);
            this.lblTaxPer.TabIndex = 10;
            this.lblTaxPer.Text = "Tax %";
            this.lblTaxPer.Visible = false;
            // 
            // txtTaxPer
            // 
            this.txtTaxPer.AllowFormat = false;
            this.txtTaxPer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaxPer.BackColor = System.Drawing.Color.White;
            this.txtTaxPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxPer.DecimalPlaces = 2;
            this.txtTaxPer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxPer.Location = new System.Drawing.Point(850, 50);
            this.txtTaxPer.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtTaxPer.Name = "txtTaxPer";
            this.txtTaxPer.RightAlign = true;
            this.txtTaxPer.Size = new System.Drawing.Size(60, 30);
            this.txtTaxPer.TabIndex = 1;
            this.txtTaxPer.TabStop = false;
            this.txtTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTaxPer.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTaxPer.Visible = false;
            this.txtTaxPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaxPer_KeyDown);
            // 
            // lblFrieght
            // 
            this.lblFrieght.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFrieght.AutoSize = true;
            this.lblFrieght.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrieght.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblFrieght.Location = new System.Drawing.Point(600, 10);
            this.lblFrieght.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFrieght.Name = "lblFrieght";
            this.lblFrieght.Size = new System.Drawing.Size(78, 23);
            this.lblFrieght.TabIndex = 13;
            this.lblFrieght.Text = "Frieght";
            // 
            // txtFrieght
            // 
            this.txtFrieght.AllowFormat = false;
            this.txtFrieght.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFrieght.BackColor = System.Drawing.Color.White;
            this.txtFrieght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFrieght.DecimalPlaces = 2;
            this.txtFrieght.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrieght.Location = new System.Drawing.Point(700, 7);
            this.txtFrieght.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtFrieght.Name = "txtFrieght";
            this.txtFrieght.ReadOnly = true;
            this.txtFrieght.RightAlign = true;
            this.txtFrieght.Size = new System.Drawing.Size(140, 30);
            this.txtFrieght.TabIndex = 14;
            this.txtFrieght.TabStop = false;
            this.txtFrieght.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFrieght.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblnetamt
            // 
            this.lblnetamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblnetamt.AutoSize = true;
            this.lblnetamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblnetamt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblnetamt.Location = new System.Drawing.Point(920, 10);
            this.lblnetamt.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblnetamt.Name = "lblnetamt";
            this.lblnetamt.Size = new System.Drawing.Size(125, 23);
            this.lblnetamt.TabIndex = 8;
            this.lblnetamt.Text = "Net Amount";
            // 
            // txtFinalnetamount
            // 
            this.txtFinalnetamount.AllowFormat = false;
            this.txtFinalnetamount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFinalnetamount.BackColor = System.Drawing.Color.White;
            this.txtFinalnetamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFinalnetamount.DecimalPlaces = 2;
            this.txtFinalnetamount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtFinalnetamount.Location = new System.Drawing.Point(1055, 7);
            this.txtFinalnetamount.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtFinalnetamount.Name = "txtFinalnetamount";
            this.txtFinalnetamount.ReadOnly = true;
            this.txtFinalnetamount.RightAlign = true;
            this.txtFinalnetamount.Size = new System.Drawing.Size(140, 30);
            this.txtFinalnetamount.TabIndex = 6;
            this.txtFinalnetamount.TabStop = false;
            this.txtFinalnetamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFinalnetamount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(920, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Profit";
            this.label4.Visible = false;
            // 
            // txtProfit
            // 
            this.txtProfit.AllowFormat = false;
            this.txtProfit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProfit.BackColor = System.Drawing.Color.White;
            this.txtProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfit.DecimalPlaces = 2;
            this.txtProfit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfit.Location = new System.Drawing.Point(1055, 50);
            this.txtProfit.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.ReadOnly = true;
            this.txtProfit.RightAlign = true;
            this.txtProfit.Size = new System.Drawing.Size(140, 30);
            this.txtProfit.TabIndex = 6;
            this.txtProfit.TabStop = false;
            this.txtProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProfit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtProfit.Visible = false;
            // 
            // pnlentry
            // 
            this.pnlentry.Controls.Add(this.dgvSales);
            this.pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlentry.Location = new System.Drawing.Point(7, 196);
            this.pnlentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.Size = new System.Drawing.Size(1644, 380);
            this.pnlentry.TabIndex = 1;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSNo,
            this.cIsTaxable,
            this.cCategory,
            this.cItemName,
            this.cQty,
            this.cPerUnitRate,
            this.cItemUnitType,
            this.cStock,
            this.cRate,
            this.cTaxPercentage,
            this.cTaxAmount,
            this.cUnitValue,
            this.cUnit,
            this.cFrieghtCharge,
            this.cAmount,
            this.cOrderQty,
            this.cCostRate,
            this.cCatID,
            this.cOdID,
            this.cSdID,
            this.cItemID,
            this.cCostAmount,
            this.cOdUnitValue});
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.Location = new System.Drawing.Point(0, 0);
            this.dgvSales.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSales.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSales.ShowCellToolTips = false;
            this.dgvSales.Size = new System.Drawing.Size(1644, 380);
            this.dgvSales.TabIndex = 0;
            this.dgvSales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellEndEdit);
            this.dgvSales.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSales_EditingControlShowing);
            this.dgvSales.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgopen_RowsAdded);
            this.dgvSales.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgopen_RowsRemoved);
            this.dgvSales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgopen_KeyDown);
            // 
            // cSNo
            // 
            this.cSNo.HeaderText = "SNO";
            this.cSNo.Name = "cSNo";
            this.cSNo.ReadOnly = true;
            this.cSNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cSNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cSNo.Width = 50;
            // 
            // cIsTaxable
            // 
            this.cIsTaxable.HeaderText = "IsTaxable";
            this.cIsTaxable.Name = "cIsTaxable";
            this.cIsTaxable.Visible = false;
            // 
            // cCategory
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCategory.DefaultCellStyle = dataGridViewCellStyle20;
            this.cCategory.HeaderText = "CATEGORY";
            this.cCategory.Name = "cCategory";
            this.cCategory.Width = 120;
            // 
            // cItemName
            // 
            this.cItemName.HeaderText = "ITEM NAME";
            this.cItemName.Name = "cItemName";
            // 
            // cQty
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.Format = "N0";
            dataGridViewCellStyle21.NullValue = null;
            this.cQty.DefaultCellStyle = dataGridViewCellStyle21;
            this.cQty.HeaderText = "QTY";
            this.cQty.MaxInputLength = 8;
            this.cQty.Name = "cQty";
            this.cQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cPerUnitRate
            // 
            this.cPerUnitRate.HeaderText = "PER UNIT RATE";
            this.cPerUnitRate.Name = "cPerUnitRate";
            // 
            // cItemUnitType
            // 
            this.cItemUnitType.HeaderText = "ITEM UNIT TYPE";
            this.cItemUnitType.Name = "cItemUnitType";
            this.cItemUnitType.ReadOnly = true;
            // 
            // cStock
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Format = "N0";
            dataGridViewCellStyle22.NullValue = "0";
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            this.cStock.DefaultCellStyle = dataGridViewCellStyle22;
            this.cStock.HeaderText = "STOCK";
            this.cStock.Name = "cStock";
            this.cStock.ReadOnly = true;
            this.cStock.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cStock.Visible = false;
            // 
            // cRate
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            this.cRate.DefaultCellStyle = dataGridViewCellStyle23;
            this.cRate.HeaderText = "RATE";
            this.cRate.MaxInputLength = 10;
            this.cRate.Name = "cRate";
            this.cRate.ReadOnly = true;
            this.cRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cRate.Width = 120;
            // 
            // cTaxPercentage
            // 
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = null;
            this.cTaxPercentage.DefaultCellStyle = dataGridViewCellStyle24;
            this.cTaxPercentage.HeaderText = "TAX %";
            this.cTaxPercentage.Name = "cTaxPercentage";
            this.cTaxPercentage.ReadOnly = true;
            this.cTaxPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cTaxPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cTaxPercentage.Width = 120;
            // 
            // cTaxAmount
            // 
            dataGridViewCellStyle25.Format = "N2";
            dataGridViewCellStyle25.NullValue = null;
            this.cTaxAmount.DefaultCellStyle = dataGridViewCellStyle25;
            this.cTaxAmount.HeaderText = "TAX AMOUNT";
            this.cTaxAmount.Name = "cTaxAmount";
            this.cTaxAmount.ReadOnly = true;
            this.cTaxAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cTaxAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cTaxAmount.Width = 130;
            // 
            // cUnitValue
            // 
            this.cUnitValue.HeaderText = "UNIT VALUE";
            this.cUnitValue.Name = "cUnitValue";
            this.cUnitValue.ReadOnly = true;
            // 
            // cUnit
            // 
            this.cUnit.HeaderText = "UNIT";
            this.cUnit.Name = "cUnit";
            this.cUnit.ReadOnly = true;
            // 
            // cFrieghtCharge
            // 
            this.cFrieghtCharge.HeaderText = "FRIEGHT CHARGE";
            this.cFrieghtCharge.Name = "cFrieghtCharge";
            this.cFrieghtCharge.ReadOnly = true;
            // 
            // cAmount
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "N2";
            this.cAmount.DefaultCellStyle = dataGridViewCellStyle26;
            this.cAmount.HeaderText = "AMOUNT";
            this.cAmount.Name = "cAmount";
            this.cAmount.ReadOnly = true;
            this.cAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cAmount.Width = 130;
            // 
            // cOrderQty
            // 
            this.cOrderQty.HeaderText = "ORDER QTY";
            this.cOrderQty.Name = "cOrderQty";
            this.cOrderQty.Visible = false;
            this.cOrderQty.Width = 50;
            // 
            // cCostRate
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N2";
            this.cCostRate.DefaultCellStyle = dataGridViewCellStyle27;
            this.cCostRate.HeaderText = "COST RATE";
            this.cCostRate.Name = "cCostRate";
            this.cCostRate.ReadOnly = true;
            this.cCostRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cCostRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cCostRate.Visible = false;
            this.cCostRate.Width = 130;
            // 
            // cCatID
            // 
            this.cCatID.HeaderText = "CatID";
            this.cCatID.Name = "cCatID";
            this.cCatID.Visible = false;
            // 
            // cOdID
            // 
            this.cOdID.HeaderText = "OdID";
            this.cOdID.Name = "cOdID";
            this.cOdID.Visible = false;
            // 
            // cSdID
            // 
            this.cSdID.HeaderText = "SdID";
            this.cSdID.Name = "cSdID";
            this.cSdID.Visible = false;
            // 
            // cItemID
            // 
            this.cItemID.HeaderText = "ItemID";
            this.cItemID.Name = "cItemID";
            this.cItemID.Visible = false;
            // 
            // cCostAmount
            // 
            this.cCostAmount.HeaderText = "CostAmount";
            this.cCostAmount.Name = "cCostAmount";
            this.cCostAmount.Visible = false;
            this.cCostAmount.Width = 130;
            // 
            // cOdUnitValue
            // 
            this.cOdUnitValue.HeaderText = "OdUnitValue";
            this.cOdUnitValue.Name = "cOdUnitValue";
            this.cOdUnitValue.Visible = false;
            // 
            // pnlview
            // 
            this.pnlview.Controls.Add(this.tableview);
            this.pnlview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlview.Enabled = false;
            this.pnlview.Location = new System.Drawing.Point(0, 0);
            this.pnlview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlview.Name = "pnlview";
            this.pnlview.Size = new System.Drawing.Size(1658, 749);
            this.pnlview.TabIndex = 12;
            // 
            // tableview
            // 
            this.tableview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableview.ColumnCount = 1;
            this.tableview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.Controls.Add(this.lblsubtitle, 0, 0);
            this.tableview.Controls.Add(this.dglist, 0, 2);
            this.tableview.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableview.Location = new System.Drawing.Point(0, 0);
            this.tableview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableview.Name = "tableview";
            this.tableview.RowCount = 4;
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableview.Size = new System.Drawing.Size(1658, 749);
            this.tableview.TabIndex = 0;
            // 
            // lblsubtitle
            // 
            this.lblsubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblsubtitle.AutoSize = true;
            this.lblsubtitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblsubtitle.Location = new System.Drawing.Point(763, 7);
            this.lblsubtitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblsubtitle.Name = "lblsubtitle";
            this.lblsubtitle.Size = new System.Drawing.Size(131, 25);
            this.lblsubtitle.TabIndex = 4;
            this.lblsubtitle.Text = "SALES LIST";
            // 
            // dglist
            // 
            this.dglist.AllowUserToAddRows = false;
            this.dglist.AllowUserToDeleteRows = false;
            this.dglist.AllowUserToResizeRows = false;
            this.dglist.AutoGenerateColumns = false;
            this.dglist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dglist.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ldelete,
            this.ledit,
            this.lprint,
            this.lEstimateprint,
            this.isDraft,
            this.ldc,
            this.smidDataGridViewTextBoxColumn,
            this.smbooknoDataGridViewTextBoxColumn,
            this.smrefnoDataGridViewTextBoxColumn,
            this.smdateDataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.isTaxableDataGridViewTextBoxColumn,
            this.companyDataGridViewTextBoxColumn,
            this.smtotqtyDataGridViewTextBoxColumn,
            this.smnetamountDataGridViewTextBoxColumn,
            this.smdisamountDataGridViewTextBoxColumn,
            this.smpackingchargeDataGridViewTextBoxColumn,
            this.ledidDataGridViewTextBoxColumn,
            this.smitemcountDataGridViewTextBoxColumn,
            this.usersuidDataGridViewTextBoxColumn,
            this.usersnameDataGridViewTextBoxColumn,
            this.smudateDataGridViewTextBoxColumn,
            this.lImport,
            this.isImport,
            this.smdescDataGridViewTextBoxColumn});
            this.dglist.DataSource = this.uspsalesmasterSelectResultBindingSource;
            this.dglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglist.Location = new System.Drawing.Point(7, 159);
            this.dglist.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dglist.MultiSelect = false;
            this.dglist.Name = "dglist";
            this.dglist.ReadOnly = true;
            this.dglist.RowHeadersVisible = false;
            this.dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dglist.ShowCellToolTips = false;
            this.dglist.Size = new System.Drawing.Size(1644, 569);
            this.dglist.TabIndex = 1;
            this.dglist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglist_CellContentClick);
            this.dglist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglist_CellDoubleClick);
            this.dglist.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dglist_CellFormatting);
            this.dglist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dglist_KeyDown);
            // 
            // ldelete
            // 
            this.ldelete.HeaderText = "DELETE";
            this.ldelete.Image = ((System.Drawing.Image)(resources.GetObject("ldelete.Image")));
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
            this.ledit.Width = 75;
            // 
            // lprint
            // 
            this.lprint.HeaderText = "PRINT";
            this.lprint.Image = global::standard.Properties.Resources.print;
            this.lprint.Name = "lprint";
            this.lprint.ReadOnly = true;
            this.lprint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lprint.Width = 75;
            // 
            // lEstimateprint
            // 
            this.lEstimateprint.HeaderText = "ESTIMATE PRINT";
            this.lEstimateprint.Image = global::standard.Properties.Resources.print;
            this.lEstimateprint.Name = "lEstimateprint";
            this.lEstimateprint.ReadOnly = true;
            this.lEstimateprint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lEstimateprint.Width = 150;
            // 
            // isDraft
            // 
            this.isDraft.DataPropertyName = "sm_isdraft";
            this.isDraft.HeaderText = "IS DRAFT";
            this.isDraft.Name = "isDraft";
            this.isDraft.ReadOnly = true;
            this.isDraft.Width = 120;
            // 
            // ldc
            // 
            this.ldc.HeaderText = "ldc";
            this.ldc.Name = "ldc";
            this.ldc.ReadOnly = true;
            this.ldc.Visible = false;
            this.ldc.Width = 60;
            // 
            // smidDataGridViewTextBoxColumn
            // 
            this.smidDataGridViewTextBoxColumn.DataPropertyName = "sm_id";
            this.smidDataGridViewTextBoxColumn.HeaderText = "sm_id";
            this.smidDataGridViewTextBoxColumn.Name = "smidDataGridViewTextBoxColumn";
            this.smidDataGridViewTextBoxColumn.ReadOnly = true;
            this.smidDataGridViewTextBoxColumn.Visible = false;
            // 
            // smbooknoDataGridViewTextBoxColumn
            // 
            this.smbooknoDataGridViewTextBoxColumn.DataPropertyName = "sm_bookno";
            this.smbooknoDataGridViewTextBoxColumn.HeaderText = "sm_bookno";
            this.smbooknoDataGridViewTextBoxColumn.Name = "smbooknoDataGridViewTextBoxColumn";
            this.smbooknoDataGridViewTextBoxColumn.ReadOnly = true;
            this.smbooknoDataGridViewTextBoxColumn.Visible = false;
            // 
            // smrefnoDataGridViewTextBoxColumn
            // 
            this.smrefnoDataGridViewTextBoxColumn.DataPropertyName = "sm_refno";
            this.smrefnoDataGridViewTextBoxColumn.HeaderText = "Bill No";
            this.smrefnoDataGridViewTextBoxColumn.Name = "smrefnoDataGridViewTextBoxColumn";
            this.smrefnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.smrefnoDataGridViewTextBoxColumn.Width = 85;
            // 
            // smdateDataGridViewTextBoxColumn
            // 
            this.smdateDataGridViewTextBoxColumn.DataPropertyName = "sm_date";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.Format = "dd-MM-yyyy";
            this.smdateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle30;
            this.smdateDataGridViewTextBoxColumn.HeaderText = "Bill Date";
            this.smdateDataGridViewTextBoxColumn.Name = "smdateDataGridViewTextBoxColumn";
            this.smdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.smdateDataGridViewTextBoxColumn.Width = 150;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 200;
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "com_name";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Company";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.ReadOnly = true;
            this.companyDataGridViewTextBoxColumn.Width = 200;
            // 
            // isTaxableDataGridViewTextBoxColumn
            // 
            this.isTaxableDataGridViewTextBoxColumn.DataPropertyName = "item_istaxable";
            this.isTaxableDataGridViewTextBoxColumn.HeaderText = "Taxable";
            this.isTaxableDataGridViewTextBoxColumn.Name = "taxStatus";
            this.isTaxableDataGridViewTextBoxColumn.ReadOnly = true;
            this.isTaxableDataGridViewTextBoxColumn.Width = 200;
            // 
            // smtotqtyDataGridViewTextBoxColumn
            // 
            this.smtotqtyDataGridViewTextBoxColumn.DataPropertyName = "sm_totqty";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.Format = "N0";
            this.smtotqtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle31;
            this.smtotqtyDataGridViewTextBoxColumn.HeaderText = "Total Qty";
            this.smtotqtyDataGridViewTextBoxColumn.Name = "smtotqtyDataGridViewTextBoxColumn";
            this.smtotqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.smtotqtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // smnetamountDataGridViewTextBoxColumn
            // 
            this.smnetamountDataGridViewTextBoxColumn.DataPropertyName = "sm_netamount";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.Format = "N2";
            this.smnetamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle32;
            this.smnetamountDataGridViewTextBoxColumn.HeaderText = "Net Amt";
            this.smnetamountDataGridViewTextBoxColumn.Name = "smnetamountDataGridViewTextBoxColumn";
            this.smnetamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.smnetamountDataGridViewTextBoxColumn.Width = 130;
            // 
            // smdisamountDataGridViewTextBoxColumn
            // 
            this.smdisamountDataGridViewTextBoxColumn.DataPropertyName = "sm_disamount";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle33.Format = "N2";
            this.smdisamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle33;
            this.smdisamountDataGridViewTextBoxColumn.HeaderText = "Discount";
            this.smdisamountDataGridViewTextBoxColumn.Name = "smdisamountDataGridViewTextBoxColumn";
            this.smdisamountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // smpackingchargeDataGridViewTextBoxColumn
            // 
            this.smpackingchargeDataGridViewTextBoxColumn.DataPropertyName = "sm_packingcharge";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "N2";
            this.smpackingchargeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle34;
            this.smpackingchargeDataGridViewTextBoxColumn.HeaderText = "Other Charges";
            this.smpackingchargeDataGridViewTextBoxColumn.Name = "smpackingchargeDataGridViewTextBoxColumn";
            this.smpackingchargeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledidDataGridViewTextBoxColumn
            // 
            this.ledidDataGridViewTextBoxColumn.DataPropertyName = "led_id";
            this.ledidDataGridViewTextBoxColumn.HeaderText = "led_id";
            this.ledidDataGridViewTextBoxColumn.Name = "ledidDataGridViewTextBoxColumn";
            this.ledidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledidDataGridViewTextBoxColumn.Visible = false;
            // 
            // smitemcountDataGridViewTextBoxColumn
            // 
            this.smitemcountDataGridViewTextBoxColumn.DataPropertyName = "sm_itemcount";
            this.smitemcountDataGridViewTextBoxColumn.HeaderText = "sm_itemcount";
            this.smitemcountDataGridViewTextBoxColumn.Name = "smitemcountDataGridViewTextBoxColumn";
            this.smitemcountDataGridViewTextBoxColumn.ReadOnly = true;
            this.smitemcountDataGridViewTextBoxColumn.Visible = false;
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
            // smudateDataGridViewTextBoxColumn
            // 
            this.smudateDataGridViewTextBoxColumn.DataPropertyName = "sm_udate";
            this.smudateDataGridViewTextBoxColumn.HeaderText = "sm_udate";
            this.smudateDataGridViewTextBoxColumn.Name = "smudateDataGridViewTextBoxColumn";
            this.smudateDataGridViewTextBoxColumn.ReadOnly = true;
            this.smudateDataGridViewTextBoxColumn.Visible = false;
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
            this.isImport.DataPropertyName = "sm_isimport";
            this.isImport.HeaderText = "IMPORT STATUS";
            this.isImport.Name = "isImport";
            this.isImport.ReadOnly = true;
            this.isImport.Width = 160;
            // 
            // smdescDataGridViewTextBoxColumn
            // 
            this.smdescDataGridViewTextBoxColumn.DataPropertyName = "sm_desc";
            this.smdescDataGridViewTextBoxColumn.HeaderText = "sm_desc";
            this.smdescDataGridViewTextBoxColumn.Name = "smdescDataGridViewTextBoxColumn";
            this.smdescDataGridViewTextBoxColumn.ReadOnly = true;
            this.smdescDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspsalesmasterSelectResultBindingSource
            // 
            this.uspsalesmasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_salesmasterSelectResult);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtptdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomerView, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblfdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpfdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblhyp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdList, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdexit, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCompany, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboCompany, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBillNo, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchBillNo, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblImportDate, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.importDate, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.importButton, 11, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1648, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dtptdate
            // 
            this.dtptdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtptdate.CustomFormat = "dd-MM-yyyy";
            this.dtptdate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptdate.Location = new System.Drawing.Point(290, 9);
            this.dtptdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(159, 33);
            this.dtptdate.TabIndex = 1;
            this.dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // cboCustomerView
            // 
            this.cboCustomerView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCustomerView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomerView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cboCustomerView, 2);
            this.cboCustomerView.DataSource = this.ledgermasterViewBindingSource1;
            this.cboCustomerView.DisplayMember = "led_name";
            this.cboCustomerView.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomerView.FormattingEnabled = true;
            this.cboCustomerView.Location = new System.Drawing.Point(597, 9);
            this.cboCustomerView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCustomerView.Name = "cboCustomerView";
            this.cboCustomerView.Size = new System.Drawing.Size(221, 33);
            this.cboCustomerView.TabIndex = 5;
            this.cboCustomerView.ValueMember = "led_id";
            this.cboCustomerView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCustomerView_KeyDown);
            // 
            // ledgermasterViewBindingSource1
            // 
            this.ledgermasterViewBindingSource1.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblfdate
            // 
            this.lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfdate.AutoSize = true;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(4, 13);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(62, 25);
            this.lblfdate.TabIndex = 0;
            this.lblfdate.Text = "Date";
            // 
            // dtpfdate
            // 
            this.dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(94, 9);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(168, 33);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // lblhyp
            // 
            this.lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhyp.AutoSize = true;
            this.lblhyp.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblhyp.Location = new System.Drawing.Point(270, 13);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(12, 25);
            this.lblhyp.TabIndex = 4;
            this.lblhyp.Text = "-";
            // 
            // cmdList
            // 
            this.cmdList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(839, 54);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(118, 49);
            this.cmdList.TabIndex = 6;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdprint_Click);
            // 
            // cmdexit
            // 
            this.cmdexit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(976, 54);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(118, 49);
            this.cmdexit.TabIndex = 8;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(457, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Customer";
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblCompany.Location = new System.Drawing.Point(826, 13);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(110, 25);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cboCompany, 2);
            this.cboCompany.DataSource = this.companyViewBindingSource;
            this.cboCompany.DisplayMember = "com_name";
            this.cboCompany.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(979, 9);
            this.cboCompany.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(230, 33);
            this.cboCompany.TabIndex = 3;
            this.cboCompany.ValueMember = "com_id";
            // 
            // companyViewBindingSource
            // 
            this.companyViewBindingSource.DataSource = typeof(standard.classes.company);
            // 
            // lblBillNo
            // 
            this.lblBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblBillNo.Location = new System.Drawing.Point(457, 65);
            this.lblBillNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(73, 25);
            this.lblBillNo.TabIndex = 31;
            this.lblBillNo.Text = "BillNo";
            // 
            // txtSearchBillNo
            // 
            this.txtSearchBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchBillNo.Location = new System.Drawing.Point(596, 61);
            this.txtSearchBillNo.Name = "txtSearchBillNo";
            this.txtSearchBillNo.Size = new System.Drawing.Size(94, 33);
            this.txtSearchBillNo.TabIndex = 7;
            this.txtSearchBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBillNo_KeyDown_1);
            // 
            // lblImportDate
            // 
            this.lblImportDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImportDate.AutoSize = true;
            this.lblImportDate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblImportDate.Location = new System.Drawing.Point(1275, 13);
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
            this.importDate.Location = new System.Drawing.Point(1447, 9);
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
            this.importButton.Location = new System.Drawing.Point(1626, 3);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(19, 40);
            this.importButton.TabIndex = 16;
            this.importButton.Text = "Tally Import";
            this.importButton.UseVisualStyleBackColor = false;
            this.importButton.Click += new System.EventHandler(this.ImportTodaysSalesToTally);
            // 
            // cboCityView
            // 
            this.cboCityView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCityView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCityView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCityView.DataSource = this.ledgermasteCityViewrBindingSource;
            this.cboCityView.DisplayMember = "led_address2";
            this.cboCityView.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCityView.FormattingEnabled = true;
            this.cboCityView.Location = new System.Drawing.Point(520, 5);
            this.cboCityView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCityView.Name = "cboCityView";
            this.cboCityView.Size = new System.Drawing.Size(230, 33);
            this.cboCityView.TabIndex = 3;
            this.cboCityView.ValueMember = "led_id";
            this.cboCityView.Visible = false;
            // 
            // ledgermasteCityViewrBindingSource
            // 
            this.ledgermasteCityViewrBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(457, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 52);
            this.label5.TabIndex = 2;
            this.label5.Text = "City";
            this.label5.Visible = false;
            // 
            // smtotamountDataGridViewTextBoxColumn
            // 
            this.smtotamountDataGridViewTextBoxColumn.DataPropertyName = "sm_totamount";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "N2";
            this.smtotamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle35;
            this.smtotamountDataGridViewTextBoxColumn.HeaderText = "Total Amount";
            this.smtotamountDataGridViewTextBoxColumn.Name = "smtotamountDataGridViewTextBoxColumn";
            this.smtotamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.smtotamountDataGridViewTextBoxColumn.Width = 130;
            // 
            // smprofitDataGridViewTextBoxColumn
            // 
            this.smprofitDataGridViewTextBoxColumn.DataPropertyName = "sm_profit";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle36.Format = "N2";
            this.smprofitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle36;
            this.smprofitDataGridViewTextBoxColumn.HeaderText = "Profit";
            this.smprofitDataGridViewTextBoxColumn.Name = "smprofitDataGridViewTextBoxColumn";
            this.smprofitDataGridViewTextBoxColumn.Width = 130;
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1658, 749);
            this.Controls.Add(this.tablemain);
            this.Controls.Add(this.pnlview);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "frmSales";
            this.ShowInTaskbar = false;
            this.Tag = "TRANSACTION";
            this.Text = "SALES";
            this.Load += new System.EventHandler(this.frmAmType_Load);
            this.tablemain.ResumeLayout(false);
            this.tablemain.PerformLayout();
            this.tableentry.ResumeLayout(false);
            this.tableentry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource1)).EndInit();
            this.tablecmd.ResumeLayout(false);
            this.tablecmd.PerformLayout();
            this.tablesum.ResumeLayout(false);
            this.tablesum.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlentry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.pnlview.ResumeLayout(false);
            this.tableview.ResumeLayout(false);
            this.tableview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspsalesmasterSelectResultBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private string GetCustomerPhoneNumber(int ledgerId)
        {
            using (InventoryDataContext db = new InventoryDataContext())
            {
                var phone = db.ledgermasters
                             .Where(a => a.led_id == ledgerId)
                             .Select(a => a.led_ownerphone)
                             .FirstOrDefault(); // Get the first matching record or null

                return phone ?? ""; // Return empty string if null
            }
        }

        private void SendViaWhatsApp(string phoneNumber, string filePath)
        {
            string message = "Hello, please find your receipt attached.";

            // Open WhatsApp with a pre-filled message
            string whatsappUrl = $"https://web.whatsapp.com/send?phone={phoneNumber}&text={Uri.EscapeDataString(message)}";
            Process.Start(new ProcessStartInfo(whatsappUrl) { UseShellExecute = true });

            // Wait a few seconds for WhatsApp Web/Desktop to open
            Thread.Sleep(5000);

            // Open the file dialog for the user to manually attach the file
            Process.Start("explorer.exe", filePath);
        }

        private void chkIsFrieght_CheckedChanged(object sender, EventArgs e)
        {
            //chkIsFrieght.UseVisualStyleBackColor = false;
            chkIsFrieght.ForeColor = chkIsFrieght.Checked ? Color.LimeGreen : Color.Red;
        }

        private void cboCom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (id == 0)
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                int comId = Convert.ToInt32(cboCom.SelectedValue);
                long? no = 0L;
                var ref_no = inventoryDataContext.usp_getYearNo("sal_no", global.sysdate, ref no, comId);
                txtopno.Text = no.ToString();
            }
        }

        private void lblCom_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboAgent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                dgvSales.CurrentCell = dgvSales["cCategory", 0];
                dgvSales.Focus();
            }
        }
    }
}
