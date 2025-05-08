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
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace standard.trans
{
    public class frmSalesOrder : Form
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

        private decimalbox txtopno;

        private BindingSource ledgermasterCityBindingSource;

        private BindingSource uspsalesorderSelectResultBindingSource;

        private Label lblRateType;

        private BindingSource ledgermasteCityViewrBindingSource;

        private BindingSource ledgermasterViewBindingSource;

        private DateTimePicker dtptdate;

        private lightbutton cmdList;

        private lightbutton cmdexit;

        private Label lblhyp;

        private DateTimePicker dtpfdate;

        private Label lblfdate;

        private ComboBox cboCustomerView;

        private Label label5;

        private ComboBox cboCityView;

        private Label label6;

        private TableLayoutPanel tableLayoutPanel1;

        private Label lblBillNo;

        private TextBox txtSearchBillNo;

        private DataGridViewImageColumn ldelete;

        private DataGridViewImageColumn ledit;

        private DataGridViewImageColumn lprint;

        private DataGridViewImageColumn cConvert;

        private DataGridViewTextBoxColumn isConvert;

        private DataGridViewImageColumn ldc;

        private DataGridViewTextBoxColumn soidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn sorefnoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn sodateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn sototqtyDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn comnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn soudateDataGridViewTextBoxColumn;


        private Label lblGSTIN;
        private DataGridViewTextBoxColumn smudateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSNo;
        private DataGridViewTextBoxColumn cCategory;
        private DataGridViewTextBoxColumn cItemName;
        private DataGridViewTextBoxColumn cQty;
        private DataGridViewTextBoxColumn cItemUnitType;
        private DataGridViewTextBoxColumn cStock;
        private DataGridViewTextBoxColumn cCompany;
        private DataGridViewTextBoxColumn cRate;
        private DataGridViewTextBoxColumn cTaxPercentage;
        private DataGridViewTextBoxColumn cTaxAmount;
        private DataGridViewTextBoxColumn cUnitValue;
        private DataGridViewTextBoxColumn cUnit;
        private DataGridViewTextBoxColumn cCatID;
        private DataGridViewTextBoxColumn cItemID;
        private DataGridViewTextBoxColumn cCostAmount;
        private TableLayoutPanel tableLayoutPanel2;

        public frmSalesOrder()
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
                                    where li.item_name == Convert.ToString(dgvSales["cItemName", r].Value)
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
                        }
                        else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_wholesalerate;
                        }
                        else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_specialrate;
                        }
                        else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_supersepecialrate;
                        }
                        ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item.li.item_id, null, null);
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
                                    where li.item_name == Convert.ToString(dgvSales["cItemName", r].Value)
                                    select new
                                    {
                                        cat,
                                        li
                                    };
                    foreach (var item in queryable)
                    {
                        dgvSales["cItemID", r].Value = item.li.item_id;
                        dgvSales["cCategory", r].Value = item.cat.cat_name;
                        dgvSales["cCatId", r].Value = item.cat.cat_id;
                        dgvSales["cTaxPercentage", r].Value = item.li.item_taxpercentage;
                        dgvSales["cUnit", r].Value = item.li.item_unit;
                        dgvSales["cUnitValue", r].Value = item.li.item_quantity;
                        dgvSales["cItemUnitType", r].Value = item.li.item_unittype;
                        if (lblRateType.Text.ToUpper() == "MRP (D)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_mrp;
                        }
                        else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE (C)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_wholesalerate;
                        }
                        else if (lblRateType.Text.ToUpper() == "SPECIAL RATE (B)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_specialrate;
                        }
                        else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                        {
                            dgvSales["cRate", r].Value = item.li.item_supersepecialrate;
                        }
                        ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item.li.item_id, null, null);
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
            dtpsaldate.MinDate = global.fdate;
            dtpsaldate.MaxDate = global.sysdate;
            dtpsaldate.Value = global.sysdate;
            TimeSpan value = new TimeSpan(30, 0, 0, 0, 0);
            dtpfdate.Value = dtpfdate.Value.Subtract(value);
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            using (inventoryDataContext)
            {
                var source = from a in inventoryDataContext.ledgermasters
                             where a.led_accounttype == "Customer" || a.led_id == 0
                             select new
                             {
                                 a.led_id,
                                 a.led_name,
                                 a.led_address2
                             };
                ledgermasterBindingSource.DataSource = source.OrderBy(x => x.led_address2);
                ledgermasterCityBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                ledgermasteCityViewrBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                uspsalesorderSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesorderSelect(null, null, null, null, null, null);
                long? no = 0L;
                inventoryDataContext.usp_getYearNo("so_no", global.sysdate, ref no, 0);
                txtopno.Value = no.Value;
                uspsalesorderSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesorderSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value.Date, dtptdate.Value.Date, null, null);
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
            cboissueto.SelectedIndex = -1;
            dgvSales.Rows.Clear();
            txttotqty.Value = 0m;
            txtSearchBillNo.Text = string.Empty;
            id = 0L;
            ReceivedAmt = 0m;
            cboCity.Select();
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            DbTransaction dbTransaction = null;
            item item = null;
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                salesorder salesorder = new salesorder();
                salesorderdetail salesorderdetail = new salesorderdetail();
                salesorder.led_id = Convert.ToInt32(cboissueto.SelectedValue);
                bool IsCommReceived = false;
                if (id > 0)
                    IsCommReceived = (bool)inventoryDataContext.usp_getiscommissionceceived(id).SingleOrDefault().isreceived;
                if (IsCommReceived == true)
                {
                    MessageBox.Show("Can't edit commission received bill...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (salesorder.led_id == 0)
                {
                    MessageBox.Show("Invalid 'Customer'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cboissueto.Focus();
                }
                else
                {
                    List<item> source = inventoryDataContext.items.Select((item itemRow) => itemRow).ToList();
                    foreach (DataGridViewRow dr in (IEnumerable)dgvSales.Rows)
                    {
                        if (!dr.IsNewRow)
                        {
                            item = source.FirstOrDefault((item match) => match.item_name.ToUpper().Trim() == dr.Cells["cItemName"].Value.ToString().ToUpper().Trim());
                            dr.Cells["cCatID"].Value = (item?.item_id ?? 0);
                            if (Convert.ToInt32(dr.Cells["cCatID"].Value) == 0 || Convert.ToDecimal(dr.Cells["cQty"].Value) == 0m)
                            {
                                MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                dgvSales.Focus();
                                return;
                            }
                        }
                    }
                    if (dgvSales.RowCount <= 1)
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
                        salesorder.so_totqty = Convert.ToDecimal(txttotqty.Text);
                        salesorder.so_date = dtpsaldate.Value;
                        if (id == 0)
                        {
                            long? no = 0L;
                            inventoryDataContext.usp_setYearNo("so_no", global.sysdate, ref no,0);
                            salesorder.so_refno = Convert.ToInt64(no);
                            inventoryDataContext.usp_salesorderInsert(ref id, salesorder.so_refno, salesorder.so_date, salesorder.led_id, salesorder.so_totqty,global.ucode, global.sysdate, false);
                            salesorderdetail.so_id = id;
                            foreach (DataGridViewRow item2 in (IEnumerable)dgvSales.Rows)
                            {
                                if (!item2.IsNewRow)
                                {
                                    salesorderdetail.item_id = Convert.ToInt32(item2.Cells["cCatID"].Value);
                                    salesorderdetail.od_qty = Convert.ToInt32(item2.Cells["cQty"].Value);
                                    decimal? num = Convert.ToDecimal(item2.Cells["cStock"].Value);
                                    inventoryDataContext.usp_salesorderdetailsInsert(id, salesorderdetail.item_id, salesorderdetail.od_qty);
                                }
                            }

                        }
                        else
                        {
                            salesorder.so_refno = Convert.ToInt64(txtopno.Value);
                            salesorder.so_isclose = false;
                            inventoryDataContext.usp_salesorderUpdate(id, salesorder.so_refno, salesorder.so_date, salesorder.led_id, salesorder.so_totqty, global.ucode, global.sysdate, salesorder.so_isclose);
                            inventoryDataContext.usp_salesorderdetailsDelete(id);
                            inventoryDataContext.usp_stockDelete(id, "SALES");
                            foreach (DataGridViewRow item3 in (IEnumerable)dgvSales.Rows)
                            {
                                if (!item3.IsNewRow)
                                {
                                    salesorderdetail.item_id = Convert.ToInt32(item3.Cells["cCatID"].Value);
                                    salesorderdetail.od_qty = Convert.ToInt32(item3.Cells["cQty"].Value);
                                    decimal? num = Convert.ToDecimal(item3.Cells["cQty"].Value);
                                    inventoryDataContext.usp_salesorderdetailsInsert(id, salesorderdetail.item_id, salesorderdetail.od_qty);
                                }
                            }
                        }


                    }
                }
                //loadReport(Convert.ToInt32(id));
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
            List<decimal> totalSNo = bus.getTotalSNo(dgvSales, "cSNo", list);
            txttotqty.Value = Convert.ToDecimal(totalSNo[0].ToString("N0"));
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
                                        where li.item_name == Convert.ToString(dgvSales["cItemName", r].Value)
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
                            }
                            else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_wholesalerate;
                            }
                            else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_specialrate;
                            }
                            else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                            {
                                dgvSales["cRate", r].Value = item.li.item_supersepecialrate;
                            }
                            ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item.li.item_id, null, null);
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
            if (dglist.Columns[e.ColumnIndex].Name == "isConvert")
            {
                if (e.Value is bool isConvert)
                {
                    e.Value = isConvert ? "Converted" : "Not Converted";
                    e.CellStyle.ForeColor = isConvert ? Color.Green : Color.Red;
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
                    uspsalesorderSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesorderSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value.Date, dtptdate.Value.Date, null, null);
                }
                else
                {
                    uspsalesorderSelectResultBindingSource.DataSource = inventoryDataContext.usp_salesorderSelect(null, null, null, null, null, Convert.ToInt64(txtSearchBillNo.Text));
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
                List<ReportParameter> list = new List<ReportParameter>();
                if (MessageBox.Show("Are you sure to Print Bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    ISingleResult<usp_salesorderSelectResult> singleResult = inventoryDataContext.usp_salesorderSelect(smid, null, null, null, null, null);
                    foreach (usp_salesorderSelectResult item in singleResult)
                    {
                        int? num9 = 1;
                        dateTime = item.so_date;
                        num8 = item.so_refno;
                        value = general.MoneyToText(amount);

                        ledid = item.led_id;
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
                    list.Add(new ReportParameter("ordno", num8.ToString()));
                    list.Add(new ReportParameter("orddate", $"{dateTime:dd-MMM-yyyy}"));
                    list.Add(new ReportParameter("rstext", value));
                    list.Add(new ReportParameter("am_acccode", empty2));
                    list.Add(new ReportParameter("am_account", empty3));
                    list.Add(new ReportParameter("am_bank", empty4));
                    list.Add(new ReportParameter("title", empty5));
                    list.Add(new ReportParameter("mi_totamt", num3.ToString("0.00")));
                    list.Add(new ReportParameter("mi_discount", num5.ToString("0.00")));
                    list.Add(new ReportParameter("mi_discount", num5.ToString("0.00")));
                    list.Add(new ReportParameter("mi_taxamt", num6.ToString("0.00")));
                    list.Add(new ReportParameter("mi_taxper", num7.ToString("0.00")));
                    list.Add(new ReportParameter("mi_packing", num2.ToString("0.00")));
                    list.Add(new ReportParameter("mi_netamt", amount.ToString("0.00")));
                    list.Add(new ReportParameter("mi_roundamt", num.ToString("0.00")));
                    frmRpt frmRpt = new frmRpt();
                    frmRpt.WindowState = FormWindowState.Maximized;
                    ISingleResult<usp_salesorderSelectResult> dataSourceValue = inventoryDataContext.usp_salesorderSelect(smid, null, null, null, null, null);
                    ISingleResult<usp_salesorderdetailsSelectResult> dataSourceValue2 = inventoryDataContext.usp_salesorderdetailsSelect(smid, null, null, null, null, null);
                    ISingleResult<usp_companySelectResult> dataSourceValue3 = inventoryDataContext.usp_companySelect(null);
                    ISingleResult<usp_ledgermasterSelectResult> dataSourceValue4 = inventoryDataContext.usp_ledgermasterSelect(ledid, null, null, null, null, null);
                    frmRpt.reportview.RefreshReport();
                    frmRpt.reportview.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesInvoice.rdlc";
                    //frmRpt.reportview.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesEstimate.rdlc";
                    frmRpt.reportview.LocalReport.DataSources.Clear();
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_minvoiceSelect", dataSourceValue));
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("ds_usp_dinvoiceSelect", dataSourceValue2));
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_companySelect", dataSourceValue3));
                    frmRpt.reportview.LocalReport.DataSources.Add(new ReportDataSource("usp_ledgermasterSelect", dataSourceValue4));
                    frmRpt.reportview.LocalReport.SetParameters(list);
                    frmRpt.reportview.ZoomMode = ZoomMode.Percent;
                    frmRpt.reportview.ZoomPercent = 120;
                    frmRpt.reportview.RefreshReport();
                    frmRpt.reportview.LocalReport.Refresh();
                    frmRpt.reportview.RefreshReport();
                    frmRpt.ShowDialog();

                    byte[] reportBytes = frmRpt.reportview.LocalReport.Render("PDF");

                    string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                    string Name = cboissueto.Text.Trim();
                    string baseFileName = cboCity.Text + "_" + Name + "_" + todayDate + "_" + "receipt";
                    string pdfFilePath = Path.Combine(downloadsPath, baseFileName + ".pdf");

                    File.WriteAllBytes(pdfFilePath, reportBytes);

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
                    loadReport(Convert.ToInt32(dglist.CurrentRow.Cells["soidDataGridViewTextBoxColumn"].Value));
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
                var isConvertValue = dglist.Rows[e.RowIndex].Cells["isConvert"].Value;

                if (isConvertValue is bool isConvert && isConvert)
                {
                    MessageBox.Show("This record is converted so cant't to update.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                loadlist();
            }
        }

        private void loadlist()
        {
            int num = Convert.ToInt32(dglist["soidDataGridViewTextBoxColumn", dglist.CurrentRow.Index].Value);
            id = num;
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            ISingleResult<usp_salesorderSelectResult> singleResult = inventoryDataContext.usp_salesorderSelect(num, null, null, null, null, null);
            decimal num2 = 0m;
            decimal value = 0m;
            decimal num3 = 0m;
            decimal num4 = 0m;
            using (IEnumerator<usp_salesorderSelectResult> enumerator = singleResult.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    usp_salesorderSelectResult current = enumerator.Current;
                    txtopno.Text = Convert.ToString(current.so_refno);
                    dtpsaldate.Value = Convert.ToDateTime(current.so_date);
                    cboCity.Text = current.led_address2;
                    cboissueto.SelectedValue = current.led_id;
                }
            }
            ISingleResult<usp_salesorderdetailsSelectResult> singleResult2 = inventoryDataContext.usp_salesorderdetailsSelect(num, null, null, null, null, null);
            dgvSales.Rows.Clear();
            dgvSales.AllowUserToAddRows = false;
            InventoryDataContext inventoryDataContext3 = new InventoryDataContext();
            
            foreach (usp_salesorderdetailsSelectResult item in singleResult2)
            {
                dgvSales.Rows.Add();
                dgvSales["cItemName", dgvSales.RowCount - 1].Value = item.item_name;
                dgvSales["cCatID", dgvSales.RowCount - 1].Value = item.cat_id;
                dgvSales["cCategory", dgvSales.RowCount - 1].Value = item.cat_name;
                dgvSales["cStock", dgvSales.RowCount - 1].Value = "0";
                dgvSales["cQty", dgvSales.RowCount - 1].Value = item.od_qty;
                ISingleResult<usp_stockSelectResult> singleResult3 = inventoryDataContext.usp_stockSelect(item.item_id, null, null);
                foreach (usp_stockSelectResult item2 in singleResult3)
                {
                    DataGridViewCell dataGridViewCell = dgvSales["cStock", dgvSales.RowCount - 1];
                    decimal sd_qty = item.od_qty;
                    decimal? stock = item2.stock;
                    dataGridViewCell.Value = stock;
                }
                var catData = inventoryDataContext.categories.SingleOrDefault(cat => cat.cat_id == item.cat_id);

                if (catData != null)
                {
                    string companyName = inventoryDataContext.companies
                        .Where(c => c.com_id == catData.com_id)
                        .Select(c => c.com_name)
                        .SingleOrDefault();

                    dgvSales["cCompany", dgvSales.RowCount - 1].Value = companyName;
                }
                //txtTaxAmt.Value = item.sd_taxamount;
            }
            dgvSales.AllowUserToAddRows = true;
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
                    int num = Convert.ToInt32(dglist["soidDataGridViewTextBoxColumn", e.RowIndex].Value);
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        inventoryDataContext.usp_salesorderdetailsDelete(num);
                        inventoryDataContext.usp_stockDelete(num, "SALES");
                        inventoryDataContext.usp_salesorderDelete(num);
                        cmdprint_Click(this, null);
                        MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (e.ColumnIndex == ledit.Index && e.RowIndex > -1)
                {
                    if (dglist.CurrentCell != null)
                    {
                        var isConvertValue = dglist.Rows[e.RowIndex].Cells["isConvert"].Value;

                        if (isConvertValue is bool isConvert && isConvert)
                        {
                            MessageBox.Show("This record is converted, so cant't to update.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        loadlist();
                    }
                }
                else if (e.ColumnIndex == lprint.Index && e.RowIndex > -1)
                {
                    loadReport(Convert.ToInt32(dglist.CurrentRow.Cells["soidDataGridViewTextBoxColumn"].Value));
                }
                else if (e.ColumnIndex == cConvert.Index && e.RowIndex > -1)
                {
                    var sdId = Convert.ToInt32(dglist.CurrentRow.Cells["soidDataGridViewTextBoxColumn"].Value);
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    ISingleResult<usp_salesorderdetailsSelectResult> salesOrderDetailsResult = inventoryDataContext.usp_salesorderdetailsSelect(sdId, null, null, null, null, null);
                    ISingleResult<usp_salesorderSelectResult> salesOrderResult = inventoryDataContext.usp_salesorderSelect(sdId, null, null, null, null, null);
                    salesmaster salesmaster = new salesmaster();
                    salesdetail salesdetail = new salesdetail();
                    salesorder salesorder = new salesorder();
                    List<usp_salesorderdetailsSelectResult> com1list = new List<usp_salesorderdetailsSelectResult>();
                    List<usp_salesorderdetailsSelectResult> com2list = new List<usp_salesorderdetailsSelectResult>();

                    var result = salesOrderResult.FirstOrDefault();
                    if (result.so_isclose == true)
                    {
                        MessageBox.Show("This Record Already Converted to Sales", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    foreach (usp_salesorderdetailsSelectResult sod in salesOrderDetailsResult)
                    {
                       
                        if(sod.com_id == 1)
                        {
                            com1list.Add(sod);
                        }
                        else if(sod.com_id == 2)
                        {
                            com2list.Add(sod);
                        }
                    }

                    var com1 = com1list.FirstOrDefault();
                    var com2 = com2list.FirstOrDefault();

                    if (com1list.Count>0 && com1.com_id == 1)
                    {
                        var firstItem = com1list.FirstOrDefault();

                        long? no = 0L;
                        inventoryDataContext.usp_setYearNo("sal_no", global.sysdate, ref no, firstItem.com_id);
                        salesmaster.sm_refno = Convert.ToInt64(no);
                        salesmaster.sm_bookno = "S";
                        salesmaster.sm_totqty = com1list.Sum(x => x.od_qty);
                        salesmaster.sm_date = firstItem.so_date;
                        salesmaster.led_id = firstItem.led_id;
                        salesmaster.so_id = firstItem.so_id;
                        salesorder.so_refno = firstItem.so_refno;
                        salesmaster.com_id = firstItem.com_id;
                        inventoryDataContext.usp_salesmasterInsert(ref id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount, salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount, salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount, salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking, salesmaster.sm_roundamount, false, false, global.ucode, global.sysdate, salesmaster.sm_desc, false, false, salesmaster.so_id, salesmaster.com_id);
                        inventoryDataContext.usp_salesorderUpdate(salesmaster.so_id, salesorder.so_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, global.ucode, global.sysdate, true);
                        salesdetail.sm_id = id;

                        foreach (var com1SOD in com1list)
                        {

                            salesdetail.item_id = com1SOD.item_id;
                            salesdetail.sd_qty = com1SOD.od_qty;
                            salesdetail.sd_unit = com1SOD.item_unit;
                            salesdetail.sd_unitvalue = com1SOD.item_quantity;
                            salesdetail.sd_itemunittype = com1SOD.item_unittype;
                            salesdetail.sd_taxpercentage = com1SOD.item_taxpercentage;
                            if (com1SOD.led_ratetype == "MRP  (D)")
                            {
                                salesdetail.sd_rate = com1SOD.item_mrp;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com1SOD.item_perunitrate > 0 ? (com1SOD.item_mrp / com1SOD.item_quantity).ToString("N2") : com1SOD.item_mrp.ToString("N2"));
                            }
                            else if (com1SOD.led_ratetype == "WHOLE SALE RATE  (C)")
                            {
                                salesdetail.sd_rate = com1SOD.item_wholesalerate;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com1SOD.item_perunitrate > 0 ? (com1SOD.item_wholesalerate / com1SOD.item_quantity).ToString("N2") : com1SOD.item_wholesalerate.ToString("N2"));
                            }
                            else if (com1SOD.led_ratetype == "SPECIAL RATE  (B)")
                            {
                                salesdetail.sd_rate = com1SOD.item_specialrate;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com1SOD.item_perunitrate > 0 ? (com1SOD.item_specialrate / com1SOD.item_quantity).ToString("N2") : com1SOD.item_specialrate.ToString("N2"));
                            }
                            else if (com1SOD.led_ratetype == "SUPER SPECIAL RATE  (A)")
                            {
                                salesdetail.sd_rate = com1SOD.item_supersepecialrate;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com1SOD.item_perunitrate > 0 ? (com1SOD.item_supersepecialrate / com1SOD.item_quantity).ToString("N2") : com1SOD.item_supersepecialrate.ToString("N2"));
                            }
                            //decimal? stock = Convert.ToDecimal(item2.Cells["cStock"].Value);
                            //salesdetail.sd_totfrieght = Convert.ToDecimal(txtFrieght.Text);
                            inventoryDataContext.usp_salesdetailsInsert(id, salesdetail.item_id, salesdetail.sd_qty, salesdetail.sd_rate, salesdetail.sd_costrate, salesdetail.sd_totamount, salesdetail.sd_taxpercentage, salesdetail.sd_taxamount,
                                    salesdetail.sd_unit, salesdetail.sd_unitvalue, salesdetail.sd_itemunittype, salesdetail.sd_totfrieght, salesdetail.sd_perunitrate);
 
                        }
                    }
                    if(com2list.Count>0 && com2.com_id == 2)
                    {
                        var secondItem = com2list.FirstOrDefault();
                        long? no = 0L;
                        inventoryDataContext.usp_setYearNo("sal_no", global.sysdate, ref no, secondItem.com_id);
                        salesmaster.sm_refno = Convert.ToInt64(no);
                        salesmaster.sm_bookno = "S";
                        salesmaster.sm_totqty = com2list.Sum(x => x.od_qty);
                        salesmaster.sm_date = secondItem.so_date;
                        salesmaster.led_id = secondItem.led_id;
                        salesmaster.so_id = secondItem.so_id;
                        salesorder.so_refno = secondItem.so_refno;
                        salesmaster.com_id = secondItem.com_id;
                        inventoryDataContext.usp_salesmasterInsert(ref id, salesmaster.sm_bookno, salesmaster.sm_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, salesmaster.sm_totamount, salesmaster.sm_itemcount, salesmaster.sm_profit, salesmaster.sm_disamount, salesmaster.sm_taxamount, salesmaster.sm_taxpercentage, salesmaster.sm_packingcharge, salesmaster.sm_netamount, salesmaster.sm_received, salesmaster.sm_paidcommission, salesmaster.sm_paidpacking, salesmaster.sm_roundamount, false, false, global.ucode, global.sysdate, salesmaster.sm_desc, false, false, salesmaster.so_id, salesmaster.com_id);
                        inventoryDataContext.usp_salesorderUpdate(salesmaster.so_id, salesorder.so_refno, salesmaster.sm_date, salesmaster.led_id, salesmaster.sm_totqty, global.ucode, global.sysdate, true);
                        salesdetail.sm_id = id;
                        foreach (var com2SOD in com2list)
                        {
                            salesdetail.item_id = com2SOD.item_id;
                            salesdetail.sd_qty = com2SOD.od_qty;
                            salesdetail.sd_unit = com2SOD.item_unit;
                            salesdetail.sd_unitvalue = com2SOD.item_quantity;
                            salesdetail.sd_itemunittype = com2SOD.item_unittype;
                            salesdetail.sd_taxpercentage = com2SOD.item_taxpercentage;
                            if (com2SOD.led_ratetype == "MRP  (D)")
                            {
                                salesdetail.sd_rate = com2SOD.item_mrp;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com2SOD.item_perunitrate > 0 ? (com2SOD.item_mrp / com2SOD.item_quantity).ToString("N2") : com2SOD.item_mrp.ToString("N2"));
                            }
                            else if (com2SOD.led_ratetype == "WHOLE SALE RATE  (C)")
                            {
                                salesdetail.sd_rate = com2SOD.item_wholesalerate;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com2SOD.item_perunitrate > 0 ? (com2SOD.item_wholesalerate / com2SOD.item_quantity).ToString("N2") : com2SOD.item_wholesalerate.ToString("N2"));
                            }
                            else if (com2SOD.led_ratetype == "SPECIAL RATE  (B)")
                            {
                                salesdetail.sd_rate = com2SOD.item_specialrate;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com2SOD.item_perunitrate > 0 ? (com2SOD.item_specialrate / com2SOD.item_quantity).ToString("N2") : com2SOD.item_specialrate.ToString("N2"));
                            }
                            else if (com2SOD.led_ratetype == "SUPER SPECIAL RATE  (A)")
                            {
                                salesdetail.sd_rate = com2SOD.item_supersepecialrate;
                                salesdetail.sd_perunitrate = Convert.ToDecimal(com2SOD.item_perunitrate > 0 ? (com2SOD.item_supersepecialrate / com2SOD.item_quantity).ToString("N2") : com2SOD.item_supersepecialrate.ToString("N2"));
                            }
                            //decimal? num = Convert.ToDecimal(item2.Cells["cStock"].Value);
                            //salesdetail.sd_totfrieght = Convert.ToDecimal(txtFrieght.Text);
                            inventoryDataContext.usp_salesdetailsInsert(id, salesdetail.item_id, salesdetail.sd_qty, salesdetail.sd_rate, salesdetail.sd_costrate, salesdetail.sd_totamount, salesdetail.sd_taxpercentage, salesdetail.sd_taxamount,
                                salesdetail.sd_unit, salesdetail.sd_unitvalue, salesdetail.sd_itemunittype, salesdetail.sd_totfrieght, salesdetail.sd_perunitrate);

                        }
                    }

                    MessageBox.Show("Converted to Sales", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void txtothers_TextChanged(object sender, EventArgs e)
        {
        }

        private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCity.SelectedItem != null)
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    ledgermasterBindingSource.Clear();
                    var dataSource = from a in inventoryDataContext.ledgermasters
                                     where a.led_accounttype == "Customer" && a.led_address2 == cboCity.Text.ToString()
                                     select new
                                     {
                                         a.led_id,
                                         a.led_name
                                     };
                    ledgermasterBindingSource.DataSource = dataSource;
                }
            }
        }

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

                    }
                }
            }
        }

        private void dtpsaldate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                cboCity.Focus();
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
                dgvSales.CurrentCell = dgvSales["cCategory", 0];
                dgvSales.Focus();
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
            int r = dgvSales.CurrentCell.RowIndex;
            int columnIndex = dgvSales.CurrentCell.ColumnIndex;
            decimal costRate;
            decimal qty;
            decimal stock;
            decimal rate;
            decimal taxPercentage;
            decimal unitValue;
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
                    string itemname = global.itemname;
                    long itemid = global.itemid;
                    try
                    {
                        dgvSales["cItemName", r].Value = itemname;
                        dgvSales["cItemID", r].Value = itemid;
                        if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                        {
                            dgvSales.Rows.RemoveAt(r);
                        }
                        using (inventoryDataContext3)
                        {
                            var queryable2 = from li in inventoryDataContext3.items
                                             join cat in inventoryDataContext3.categories on li.cat_id equals cat.cat_id
                                             join com in inventoryDataContext3.companies on li.com_id equals com.com_id
                                             where li.item_name == Convert.ToString(dgvSales["cItemName", r].Value)
                                             select new
                                             {
                                                 cat,
                                                 li
                                             };
                            foreach (var item2 in queryable2)
                            {
                                string companyName = inventoryDataContext3.companies
                                    .Where(c => c.com_id == item2.cat.com_id)
                                    .Select(c => c.com_name)
                                    .SingleOrDefault();
                                dgvSales["cCompany", r].Value = companyName;
                                dgvSales["cCostRate", r].Value = item2.li.item_costrate;
                                dgvSales["cItemID", r].Value = item2.li.item_id;
                                dgvSales["cCategory", r].Value = item2.cat.cat_name;
                                dgvSales["cCatId", r].Value = item2.cat.cat_id;
                                dgvSales["cTaxPercentage", r].Value = item2.li.item_taxpercentage;
                                dgvSales["cUnit", r].Value = item2.li.item_unit;
                                dgvSales["cUnitValue", r].Value = item2.li.item_quantity;
                                dgvSales["cItemUnitType", r].Value = item2.li.item_unittype;
                                
                                if (lblRateType.Text.ToUpper() == "MRP  (D)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_mrp;
                                }
                                else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_wholesalerate;
                                }
                                else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_specialrate;
                                }
                                else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                                {
                                    dgvSales["cRate", r].Value = item2.li.item_supersepecialrate;
                                }
                                ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item2.li.item_id, null, null);
                                foreach (usp_stockSelectResult item3 in singleResult)
                                {
                                    dgvSales["cStock", r].Value = item3.stock;
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
                                         where li.item_name == Convert.ToString(dgvSales["cItemName", r].Value)
                                         select new
                                         {
                                             cat,
                                             li
                                         };
                        foreach (var item4 in queryable2)
                        {
                            dgvSales["cCostRate", r].Value = item4.li.item_costrate;
                            dgvSales["cItemID", r].Value = item4.li.item_id;
                            dgvSales["cCategory", r].Value = item4.cat.cat_name;
                            dgvSales["cCatId", r].Value = item4.cat.cat_id;
                            if (lblRateType.Text.ToUpper() == "MRP  (D)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_mrp;
                            }
                            else if (lblRateType.Text.ToUpper() == "WHOLE SALE RATE  (C)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_wholesalerate;
                            }
                            else if (lblRateType.Text.ToUpper() == "SPECIAL RATE  (B)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_specialrate;
                            }
                            else if (lblRateType.Text.ToUpper() == "SUPER SPECIAL RATE  (A)")
                            {
                                dgvSales["cRate", r].Value = item4.li.item_supersepecialrate;
                            }
                            ISingleResult<usp_stockSelectResult> singleResult = inventoryDataContext.usp_stockSelect(item4.li.item_id, null, null);
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
            else if (columnIndex == cQty.Index)
            {
                if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
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
                    dgvSales.CurrentCell = dgvSales["cQty", dgvSales.CurrentRow.Index];
                    dgvSales.BeginEdit(selectAll: true);
                    dgvSales.Focus();
                }
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                decimal.TryParse(Convert.ToString(dgvSales["cTaxPercentage", r].Value), out taxPercentage);
                decimal.TryParse(Convert.ToString(dgvSales["cUnitValue", r].Value), out unitValue);
                dgvSales["cTaxAmount", r].Value = ((rate > 0m && qty > 0m) ? ((object)((rate * qty) * taxPercentage / 100)) : null);
                calacTotal();
                SetColumnIndex method = Mymethod;
                dgvSales.BeginInvoke(method, "cSNo");
                dgvSales.BeginEdit(selectAll: true);
            }
            else if (columnIndex == cRate.Index)
            {
                decimal.TryParse(Convert.ToString(dgvSales["cQty", r].Value), out qty);
                qty = Math.Abs(qty);
                decimal.TryParse(Convert.ToString(dgvSales["cStock", r].Value), out stock);
                stock = Math.Abs(stock);
                if (Convert.ToString(dgvSales["cItemName", r].Value) == string.Empty && !dgvSales.CurrentRow.IsNewRow)
                {
                    dgvSales.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                rate = Math.Abs(rate);
                decimal.TryParse(Convert.ToString(dgvSales["cRate", r].Value), out rate);
                dgvSales["cRate", r].Value = rate.ToString("N2");
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

        private void cboCityView_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCityView.SelectedItem != null)
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    ledgermasterViewBindingSource.Clear();
                    var source = from a in inventoryDataContext.ledgermasters
                                 where a.led_accounttype == "Customer" && a.led_address2 == cboCityView.Text.ToString()
                                 select new
                                 {
                                     a.led_id,
                                     a.led_name
                                 };
                    ledgermasterViewBindingSource.DataSource = source.OrderBy(x => x.led_name);
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablemain = new System.Windows.Forms.TableLayoutPanel();
            this.tableentry = new System.Windows.Forms.TableLayoutPanel();
            this.lblopno = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.dtpsaldate = new System.Windows.Forms.DateTimePicker();
            this.lblfrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtopno = new mylib.decimalbox(this.components);
            this.lblRateType = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.cboissueto = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlentry = new System.Windows.Forms.Panel();
            this.dgvSales = new mylib.mygrid();
            this.cSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemUnitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTaxPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCostAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlview = new System.Windows.Forms.Panel();
            this.tableview = new System.Windows.Forms.TableLayoutPanel();
            this.lblsubtitle = new System.Windows.Forms.Label();
            this.dglist = new mylib.mygrid();
            this.ldelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ledit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ldc = new System.Windows.Forms.DataGridViewImageColumn();
            this.soidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorefnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sodateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sototqtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cConvert = new System.Windows.Forms.DataGridViewImageColumn();
            this.isConvert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smudateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspsalesorderSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.cboCustomerView = new System.Windows.Forms.ComboBox();
            this.ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblfdate = new System.Windows.Forms.Label();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.lblhyp = new System.Windows.Forms.Label();
            this.cboCityView = new System.Windows.Forms.ComboBox();
            this.ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.txtSearchBillNo = new System.Windows.Forms.TextBox();
            this.lprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.tablemain.SuspendLayout();
            this.tableentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            this.tablecmd.SuspendLayout();
            this.tablesum.SuspendLayout();
            this.pnlentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.pnlview.SuspendLayout();
            this.tableview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspsalesorderSelectResultBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tablemain.Size = new System.Drawing.Size(1658, 749);
            this.tablemain.TabIndex = 0;
            // 
            // tableentry
            // 
            this.tableentry.ColumnCount = 9;
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 574F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.Controls.Add(this.lblopno, 0, 0);
            this.tableentry.Controls.Add(this.lbldate, 0, 1);
            this.tableentry.Controls.Add(this.dtpsaldate, 1, 1);
            this.tableentry.Controls.Add(this.lblfrom, 5, 0);
            this.tableentry.Controls.Add(this.label2, 2, 0);
            this.tableentry.Controls.Add(this.txtopno, 1, 0);
            this.tableentry.Controls.Add(this.lblRateType, 2, 1);
            this.tableentry.Controls.Add(this.cboCity, 3, 0);
            this.tableentry.Controls.Add(this.lblAddress, 4, 1);
            this.tableentry.Controls.Add(this.cboissueto, 6, 0);
            this.tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableentry.Location = new System.Drawing.Point(7, 44);
            this.tableentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableentry.Name = "tableentry";
            this.tableentry.RowCount = 2;
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableentry.Size = new System.Drawing.Size(1644, 86);
            this.tableentry.TabIndex = 4;
            // 
            // lblopno
            // 
            this.lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblopno.AutoSize = true;
            this.lblopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblopno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblopno.Location = new System.Drawing.Point(5, 4);
            this.lblopno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblopno.Name = "lblopno";
            this.lblopno.Size = new System.Drawing.Size(111, 35);
            this.lblopno.TabIndex = 1;
            this.lblopno.Text = "Bill No";
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldate.Location = new System.Drawing.Point(5, 43);
            this.lbldate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(83, 43);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Bill Date";
            // 
            // dtpsaldate
            // 
            this.dtpsaldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpsaldate.CustomFormat = "dd-MM-yyyy";
            this.dtpsaldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpsaldate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpsaldate.Location = new System.Drawing.Point(132, 50);
            this.dtpsaldate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtpsaldate.Name = "dtpsaldate";
            this.dtpsaldate.Size = new System.Drawing.Size(193, 42);
            this.dtpsaldate.TabIndex = 1;
            this.dtpsaldate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpsaldate_KeyDown);
            // 
            // lblfrom
            // 
            this.lblfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfrom.Location = new System.Drawing.Point(745, 0);
            this.lblfrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(98, 43);
            this.lblfrom.TabIndex = 10;
            this.lblfrom.Text = "Customer";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(335, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 43);
            this.label2.TabIndex = 10;
            this.label2.Text = "City";
            // 
            // txtopno
            // 
            this.txtopno.AllowFormat = false;
            this.txtopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtopno.BackColor = System.Drawing.Color.White;
            this.txtopno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtopno.DecimalPlaces = 2;
            this.txtopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtopno.Location = new System.Drawing.Point(132, 7);
            this.txtopno.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtopno.Name = "txtopno";
            this.txtopno.ReadOnly = true;
            this.txtopno.RightAlign = true;
            this.txtopno.Size = new System.Drawing.Size(193, 42);
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
            // lblRateType
            // 
            this.lblRateType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRateType.AutoSize = true;
            this.tableentry.SetColumnSpan(this.lblRateType, 2);
            this.lblRateType.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblRateType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblRateType.Location = new System.Drawing.Point(335, 47);
            this.lblRateType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRateType.Name = "lblRateType";
            this.lblRateType.Size = new System.Drawing.Size(24, 35);
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
            this.cboCity.Location = new System.Drawing.Point(395, 7);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(340, 43);
            this.cboCity.TabIndex = 2;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.tableentry.SetColumnSpan(this.lblAddress, 3);
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.Red;
            this.lblAddress.Location = new System.Drawing.Point(545, 47);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(24, 35);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = ".";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cboissueto.Location = new System.Drawing.Point(862, 7);
            this.cboissueto.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboissueto.Name = "cboissueto";
            this.cboissueto.Size = new System.Drawing.Size(314, 43);
            this.cboissueto.TabIndex = 3;
            this.cboissueto.ValueMember = "led_id";
            this.cboissueto.SelectedValueChanged += new System.EventHandler(this.cbopurfrom_SelectedValueChanged);
            this.cboissueto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboissueto_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(719, 2);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(219, 33);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "SALES ORDER";
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
            this.lblGSTIN.Location = new System.Drawing.Point(5, 5);
            this.lblGSTIN.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblGSTIN.Name = "lblGSTIN";
            this.lblGSTIN.Size = new System.Drawing.Size(24, 35);
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
            this.tablesum.Controls.Add(this.tableLayoutPanel2, 11, 0);
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
            this.lbltotqty.Location = new System.Drawing.Point(5, 0);
            this.lbltotqty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltotqty.Name = "lbltotqty";
            this.lbltotqty.Size = new System.Drawing.Size(63, 43);
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
            this.txttotqty.Size = new System.Drawing.Size(100, 42);
            this.txttotqty.TabIndex = 5;
            this.txttotqty.TabStop = false;
            this.txttotqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotqty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1203, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 37);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // pnlentry
            // 
            this.pnlentry.Controls.Add(this.dgvSales);
            this.pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlentry.Location = new System.Drawing.Point(7, 146);
            this.pnlentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.Size = new System.Drawing.Size(1644, 430);
            this.pnlentry.TabIndex = 1;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSNo,
            this.cCategory,
            this.cItemName,
            this.cQty,
            this.cItemUnitType,
            this.cStock,
            this.cCompany,
            this.cRate,
            this.cTaxPercentage,
            this.cTaxAmount,
            this.cUnitValue,
            this.cUnit,
            this.cCatID,
            this.cItemID,
            this.cCostAmount});
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.Location = new System.Drawing.Point(0, 0);
            this.dgvSales.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dgvSales.MultiSelect = false;
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSales.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSales.ShowCellToolTips = false;
            this.dgvSales.Size = new System.Drawing.Size(1644, 430);
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
            this.cSNo.Width = 70;
            // 
            // cCategory
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCategory.DefaultCellStyle = dataGridViewCellStyle2;
            this.cCategory.HeaderText = "CATEGORY";
            this.cCategory.Name = "cCategory";
            this.cCategory.Width = 200;
            // 
            // cItemName
            // 
            this.cItemName.HeaderText = "ITEM NAME";
            this.cItemName.Name = "cItemName";
            this.cItemName.Width = 300;
            // 
            // cQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.cQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.cQty.HeaderText = "QTY";
            this.cQty.MaxInputLength = 8;
            this.cQty.Name = "cQty";
            this.cQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cItemUnitType
            // 
            this.cItemUnitType.HeaderText = "ITEM UNIT TYPE";
            this.cItemUnitType.Name = "cItemUnitType";
            this.cItemUnitType.ReadOnly = true;
            this.cItemUnitType.Visible = false;
            // 
            // cStock
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.cStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.cStock.HeaderText = "STOCK";
            this.cStock.Name = "cStock";
            this.cStock.ReadOnly = true;
            this.cStock.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cStock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cCompany
            // 
            this.cCompany.HeaderText = "Company";
            this.cCompany.Name = "cCompany";
            this.cCompany.ReadOnly = true;
            this.cCompany.Width = 300;
            // 
            // cRate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.cRate.DefaultCellStyle = dataGridViewCellStyle5;
            this.cRate.HeaderText = "RATE";
            this.cRate.MaxInputLength = 10;
            this.cRate.Name = "cRate";
            this.cRate.ReadOnly = true;
            this.cRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cRate.Visible = false;
            this.cRate.Width = 120;
            // 
            // cTaxPercentage
            // 
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.cTaxPercentage.DefaultCellStyle = dataGridViewCellStyle6;
            this.cTaxPercentage.HeaderText = "TAX %";
            this.cTaxPercentage.Name = "cTaxPercentage";
            this.cTaxPercentage.ReadOnly = true;
            this.cTaxPercentage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cTaxPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cTaxPercentage.Visible = false;
            this.cTaxPercentage.Width = 120;
            // 
            // cTaxAmount
            // 
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.cTaxAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.cTaxAmount.HeaderText = "TAX AMOUNT";
            this.cTaxAmount.Name = "cTaxAmount";
            this.cTaxAmount.ReadOnly = true;
            this.cTaxAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cTaxAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cTaxAmount.Visible = false;
            this.cTaxAmount.Width = 130;
            // 
            // cUnitValue
            // 
            this.cUnitValue.HeaderText = "UNIT VALUE";
            this.cUnitValue.Name = "cUnitValue";
            this.cUnitValue.ReadOnly = true;
            this.cUnitValue.Visible = false;
            // 
            // cUnit
            // 
            this.cUnit.HeaderText = "UNIT";
            this.cUnit.Name = "cUnit";
            this.cUnit.ReadOnly = true;
            this.cUnit.Visible = false;
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
            // cCostAmount
            // 
            this.cCostAmount.HeaderText = "CostAmount";
            this.cCostAmount.Name = "cCostAmount";
            this.cCostAmount.Visible = false;
            this.cCostAmount.Width = 130;
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
            this.lblsubtitle.Location = new System.Drawing.Point(667, 2);
            this.lblsubtitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblsubtitle.Name = "lblsubtitle";
            this.lblsubtitle.Size = new System.Drawing.Size(323, 36);
            this.lblsubtitle.TabIndex = 4;
            this.lblsubtitle.Text = "SALES ORDER LIST";
            // 
            // dglist
            // 
            this.dglist.AllowUserToAddRows = false;
            this.dglist.AllowUserToDeleteRows = false;
            this.dglist.AllowUserToResizeRows = false;
            this.dglist.AutoGenerateColumns = false;
            this.dglist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dglist.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ldelete,
            this.ledit,
            this.ldc,
            this.soidDataGridViewTextBoxColumn,
            this.sorefnoDataGridViewTextBoxColumn,
            this.sodateDataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.sototqtyDataGridViewTextBoxColumn,
            this.cConvert,
            this.isConvert,
            this.ledidDataGridViewTextBoxColumn,
            this.usersuidDataGridViewTextBoxColumn,
            this.usersnameDataGridViewTextBoxColumn,
            this.smudateDataGridViewTextBoxColumn});
            this.dglist.DataSource = this.uspsalesorderSelectResultBindingSource;
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
            // ldc
            // 
            this.ldc.HeaderText = "ldc";
            this.ldc.Name = "ldc";
            this.ldc.ReadOnly = true;
            this.ldc.Visible = false;
            this.ldc.Width = 60;
            // 
            // soidDataGridViewTextBoxColumn
            // 
            this.soidDataGridViewTextBoxColumn.DataPropertyName = "so_id";
            this.soidDataGridViewTextBoxColumn.HeaderText = "so_id";
            this.soidDataGridViewTextBoxColumn.Name = "soidDataGridViewTextBoxColumn";
            this.soidDataGridViewTextBoxColumn.ReadOnly = true;
            this.soidDataGridViewTextBoxColumn.Visible = false;
            // 
            // sorefnoDataGridViewTextBoxColumn
            // 
            this.sorefnoDataGridViewTextBoxColumn.DataPropertyName = "so_refno";
            this.sorefnoDataGridViewTextBoxColumn.HeaderText = "Bill No";
            this.sorefnoDataGridViewTextBoxColumn.Name = "sorefnoDataGridViewTextBoxColumn";
            this.sorefnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.sorefnoDataGridViewTextBoxColumn.Width = 85;
            // 
            // sodateDataGridViewTextBoxColumn
            // 
            this.sodateDataGridViewTextBoxColumn.DataPropertyName = "so_date";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "dd-MM-yyyy";
            this.sodateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.sodateDataGridViewTextBoxColumn.HeaderText = "Bill Date";
            this.sodateDataGridViewTextBoxColumn.Name = "sodateDataGridViewTextBoxColumn";
            this.sodateDataGridViewTextBoxColumn.ReadOnly = true;
            this.sodateDataGridViewTextBoxColumn.Width = 150;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 200;
            // 
            // sototqtyDataGridViewTextBoxColumn
            // 
            this.sototqtyDataGridViewTextBoxColumn.DataPropertyName = "so_totqty";
            dataGridViewCellStyle11.Format = "N0";
            this.sototqtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.sototqtyDataGridViewTextBoxColumn.HeaderText = "Total Qty";
            this.sototqtyDataGridViewTextBoxColumn.Name = "sototqtyDataGridViewTextBoxColumn";
            this.sototqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.sototqtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // cConvert
            // 
            this.cConvert.HeaderText = "CONVERT TO SALES";
            this.cConvert.Image = ((System.Drawing.Image)(resources.GetObject("cConvert.Image")));
            this.cConvert.Name = "cConvert";
            this.cConvert.ReadOnly = true;
            this.cConvert.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cConvert.Width = 120;
            // 
            // isConvert
            // 
            this.isConvert.DataPropertyName = "so_isclose";
            this.isConvert.HeaderText = "IS CONVERTED";
            this.isConvert.Name = "isConvert";
            this.isConvert.ReadOnly = true;
            this.isConvert.Width = 170;
            // 
            // ledidDataGridViewTextBoxColumn
            // 
            this.ledidDataGridViewTextBoxColumn.DataPropertyName = "led_id";
            this.ledidDataGridViewTextBoxColumn.HeaderText = "led_id";
            this.ledidDataGridViewTextBoxColumn.Name = "ledidDataGridViewTextBoxColumn";
            this.ledidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledidDataGridViewTextBoxColumn.Visible = false;
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
            this.smudateDataGridViewTextBoxColumn.DataPropertyName = "so_udate";
            this.smudateDataGridViewTextBoxColumn.HeaderText = "so_udate";
            this.smudateDataGridViewTextBoxColumn.Name = "smudateDataGridViewTextBoxColumn";
            this.smudateDataGridViewTextBoxColumn.ReadOnly = true;
            this.smudateDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspsalesorderSelectResultBindingSource
            // 
            this.uspsalesorderSelectResultBindingSource.DataSource = typeof(standard.classes.usp_salesorderSelectResult);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dtptdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomerView, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblfdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpfdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblhyp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboCityView, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdList, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdexit, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBillNo, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchBillNo, 6, 1);
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
            this.dtptdate.Location = new System.Drawing.Point(274, 5);
            this.dtptdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(159, 46);
            this.dtptdate.TabIndex = 1;
            this.dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // cboCustomerView
            // 
            this.cboCustomerView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCustomerView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomerView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cboCustomerView, 2);
            this.cboCustomerView.DataSource = this.ledgermasterViewBindingSource;
            this.cboCustomerView.DisplayMember = "led_name";
            this.cboCustomerView.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomerView.FormattingEnabled = true;
            this.cboCustomerView.Location = new System.Drawing.Point(871, 5);
            this.cboCustomerView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCustomerView.Name = "cboCustomerView";
            this.cboCustomerView.Size = new System.Drawing.Size(265, 47);
            this.cboCustomerView.TabIndex = 5;
            this.cboCustomerView.ValueMember = "led_id";
            this.cboCustomerView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCustomerView_KeyDown);
            // 
            // ledgermasterViewBindingSource
            // 
            this.ledgermasterViewBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblfdate
            // 
            this.lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfdate.AutoSize = true;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(4, 0);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(60, 52);
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
            this.dtpfdate.Location = new System.Drawing.Point(78, 5);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(168, 46);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // lblhyp
            // 
            this.lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhyp.AutoSize = true;
            this.lblhyp.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblhyp.Location = new System.Drawing.Point(254, 6);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(12, 39);
            this.lblhyp.TabIndex = 4;
            this.lblhyp.Text = "-";
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
            this.cboCityView.Location = new System.Drawing.Point(504, 5);
            this.cboCityView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCityView.Name = "cboCityView";
            this.cboCityView.Size = new System.Drawing.Size(230, 47);
            this.cboCityView.TabIndex = 3;
            this.cboCityView.ValueMember = "led_id";
            this.cboCityView.SelectedValueChanged += new System.EventHandler(this.cboCityView_SelectedValueChanged);
            this.cboCityView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCityView_KeyDown);
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
            this.label5.Location = new System.Drawing.Point(441, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 52);
            this.label5.TabIndex = 2;
            this.label5.Text = "City";
            // 
            // cmdList
            // 
            this.cmdList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(884, 54);
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
            this.cmdexit.Location = new System.Drawing.Point(1021, 54);
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
            this.label6.Location = new System.Drawing.Point(742, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 52);
            this.label6.TabIndex = 4;
            this.label6.Text = "Customer";
            // 
            // lblBillNo
            // 
            this.lblBillNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblBillNo.Location = new System.Drawing.Point(620, 58);
            this.lblBillNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(114, 39);
            this.lblBillNo.TabIndex = 31;
            this.lblBillNo.Text = "BillNo";
            // 
            // txtSearchBillNo
            // 
            this.txtSearchBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchBillNo.Location = new System.Drawing.Point(741, 55);
            this.txtSearchBillNo.Name = "txtSearchBillNo";
            this.txtSearchBillNo.Size = new System.Drawing.Size(123, 46);
            this.txtSearchBillNo.TabIndex = 7;
            this.txtSearchBillNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBillNo_KeyDown_1);
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
            // frmSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1658, 749);
            this.Controls.Add(this.tablemain);
            this.Controls.Add(this.pnlview);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "frmSalesOrder";
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
            this.tablecmd.ResumeLayout(false);
            this.tablecmd.PerformLayout();
            this.tablesum.ResumeLayout(false);
            this.tablesum.PerformLayout();
            this.pnlentry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.pnlview.ResumeLayout(false);
            this.tableview.ResumeLayout(false);
            this.tableview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspsalesorderSelectResultBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
    }
}
