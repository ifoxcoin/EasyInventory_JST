using mylib;
using standard.classes;
using standard.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.trans
{
    public class frmPayment : Form
    {
        private delegate void SetColumnIndex(string colname);

        private int? id;
        private bool? IsHavingOpeningBalance = false;
        private AutoCompleteStringCollection acsItemCode;

        private AutoCompleteStringCollection acsItemName;

        private AutoCompleteStringCollection acsCategoryName;

        private IContainer components = null;

        private TableLayoutPanel tablemain;

        private Label lbltitle;

        private mygrid dgvpayment;

        private TableLayoutPanel tableentry;

        private Label lblopno;

        private Label lbldate;

        private DateTimePicker dtprecdate;

        private TableLayoutPanel tablecmd;

        private lightbutton cmdsave;

        private lightbutton cmdrefresh;

        private lightbutton cmdclose;

        private Panel pnlentry;

        private Label lblfrom;

        private ComboBox cboSupplier;

        private Panel pnlview;

        private TableLayoutPanel tableview;

        private mygrid dglist;

        private TableLayoutPanel tablelist;

        private Label lblhyp;

        private DateTimePicker dtpfdate;

        private Label lblfdate;

        private DateTimePicker dtptdate;

        private lightbutton cmdList;

        private lightbutton cmdexit;

        private lightbutton cmdview;

        private Label lblsubtitle;

        private DataGridViewTextBoxColumn miidDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mibillnoDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mibilldateDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn amnameDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn mitotamtDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn minetamtDataGridViewTextBoxColumn;

        private DataGridViewTextBoxColumn minarrationDataGridViewTextBoxColumn;

        private TextBox txtrecno;

        private BindingSource ledgermasterBindingSource;

        private Label label2;

        private ComboBox cboCity;

        private BindingSource ledgermasterCityBindingSource;

        private DataGridViewTextBoxColumn comname1DataGridViewTextBoxColumn;

        private Label lblAddress;

        private Label label1;

        private Label label3;

        private Label label4;

        private decimalbox txtOutstanding;

        private decimalbox txtPaidamt;

        private decimalbox txtNewBalance;

        private BindingSource usppaymentSelectResultBindingSource;

        private Label label5;

        private ComboBox cboCityView;

        private Label label6;

        private ComboBox cboSupplierView;

        private BindingSource ledgermasteCityViewrBindingSource;

        private BindingSource ledgermasterViewBindingSource;
        private Label lblpaymentType;
        private DataGridViewImageColumn ldelete;
        private DataGridViewImageColumn ledit;
        private DataGridViewImageColumn lprint;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaddress2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recdateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn smidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recbillamtDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recpaidamtDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recnewbalanceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn reciscloseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ob_id;
        private DataGridViewTextBoxColumn osno;
        private DataGridViewTextBoxColumn cBillNo;
        private DataGridViewTextBoxColumn cBilldate;
        private DataGridViewTextBoxColumn cBillAmt;
        private DataGridViewTextBoxColumn cpaid;
        private DataGridViewTextBoxColumn cExistpaid;
        private DataGridViewTextBoxColumn cNewBalance;
        private DataGridViewTextBoxColumn cDayscount;
        private DataGridViewTextBoxColumn cPMId;
        private Label lblAddress1;

        public frmPayment()
        {
            InitializeComponent();
        }

        private void frmAmType_Load(object sender, EventArgs e)
        {
            try
            {
                id = 0;
                LoadData();
                AutoFill();
                dtprecdate.Select();
            }
            catch (Exception ex)
            {
                frmException ex2 = new frmException(ex);
                ex2.ShowDialog();
            }
        }

        private void LoadData()
        {
            dtprecdate.MinDate = global.fdate;
            dtprecdate.MaxDate = global.sysdate;
            dtprecdate.Value = global.sysdate;
            dtpfdate.MinDate = global.fdate;
            dtpfdate.MaxDate = global.sysdate;
            dtptdate.MinDate = global.fdate;
            dtptdate.MaxDate = global.sysdate;
            TimeSpan value = new TimeSpan(30, 0, 0, 0, 0);
            dtpfdate.Value = dtpfdate.Value.Subtract(value);
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            using (inventoryDataContext)
            {
                var source = from a in inventoryDataContext.ledgermasters
                             where a.led_accounttype == "Supplier" || a.led_id == 0
                             select new
                             {
                                 a.led_id,
                                 a.led_name,
                                 a.led_address2
                             };
                ledgermasterCityBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                ledgermasteCityViewrBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
                usppaymentSelectResultBindingSource.DataSource = inventoryDataContext.usp_paymentSelect(null, null, null, null);
                cboSupplier.SelectedIndex = -1;
                long? no = 0L;
                inventoryDataContext.usp_getYearNo("pay_no", global.sysdate, ref no);
                txtrecno.Text = Convert.ToString(no);
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
            cboSupplier.SelectedIndex = -1;
            cboSupplier.Text = string.Empty;
            dgvpayment.Rows.Clear();
            txtPaidamt.Value = 0m;
            txtOutstanding.Value = 0m;
            txtNewBalance.Value = 0m;
            id = 0;
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            DbTransaction dbTransaction = null;
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                payment payment = new payment();
                payment.led_id = Convert.ToInt32(cboSupplier.SelectedValue);
                if (payment.led_id == 0)
                {
                    MessageBox.Show("Invalid 'Supplier'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cboSupplier.Focus();
                }
                else if (dgvpayment.RowCount <= 1)
                {
                    MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dgvpayment.Focus();
                }
                else
                {
                    int? num = id;
                    if (num.GetValueOrDefault() != 0 || !num.HasValue)
                    {
                    }
                    if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        payment.pay_date = dtprecdate.Value;
                        num = id;
                        if (num.GetValueOrDefault() == 0 && num.HasValue)
                        {
                            payment.pay_date = dtprecdate.Value;
                            payment.com_id = 1L;
                            long? no = 0L;
                            inventoryDataContext.usp_setYearNo("pay_no", global.sysdate, ref no);
                            foreach (DataGridViewRow item in (IEnumerable)dgvpayment.Rows)
                            {
                                if (Convert.ToDecimal(item.Cells["cpaid"].Value) > 0m)
                                {
                                    txtrecno.Text = Convert.ToString(no);
                                    if (!item.IsNewRow)
                                    {
                                        payment.pay_billamt = Convert.ToDecimal(item.Cells["cBillAmt"].Value);
                                        if (IsHavingOpeningBalance == true)
                                        {
                                            payment.pm_id = 0;
                                            payment.ob_id = Convert.ToInt32(item.Cells["cPMId"].Value);
                                        }
                                        else
                                        {
                                            payment.pm_id = Convert.ToInt32(item.Cells["cPMId"].Value);
                                            payment.ob_id = 0;
                                        }

                                        payment.pay_newbalance = Convert.ToDecimal(item.Cells["cNewBalance"].Value);
                                        payment.pay_paidamt = Convert.ToDecimal(item.Cells["cpaid"].Value);
                                        payment.pay_no = Convert.ToInt32(no);
                                        if (payment.pay_newbalance <= 0m)
                                        {
                                            payment.pay_isclose = true;
                                        }
                                        else
                                        {
                                            payment.pay_isclose = false;
                                        }
                                        inventoryDataContext.usp_paymentInsert(payment.pay_no, payment.pay_date, payment.led_id, payment.pm_id, payment.ob_id, payment.com_id, payment.pay_billamt, payment.pay_paidamt, payment.pay_newbalance, payment.pay_isclose);
                                    }
                                }
                            }
                        }
                        ClearData();
                        LoadData();
                        MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dtprecdate.Focus();
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

        private void cmdrefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadData();
            dtprecdate.Focus();
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Mymethod(string colname)
        {
            dgvpayment.CurrentCell = dgvpayment[colname, dgvpayment.RowCount - 1];
            dgvpayment.BeginEdit(selectAll: true);
            dgvpayment.Focus();
        }

        private void dgopen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvpayment.CurrentCell != null)
            {
                int r = dgvpayment.CurrentCell.RowIndex;
                int columnIndex = dgvpayment.CurrentCell.ColumnIndex;
                if (Convert.ToString(dgvpayment["cCategory", r].Value) == string.Empty && !dgvpayment.CurrentRow.IsNewRow)
                {
                    dgvpayment.Rows.RemoveAt(r);
                }
                acsItemName = new AutoCompleteStringCollection();
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                using (inventoryDataContext)
                {
                    IQueryable<item> queryable = from li in inventoryDataContext.items
                                                 join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                                 where cat.cat_name == Convert.ToString(dgvpayment["cCategory", r].Value)
                                                 select li;
                    foreach (item item in queryable)
                    {
                        acsItemCode.Add(item.item_code);
                        acsItemName.Add(item.item_name);
                    }
                }
                if (Convert.ToString(dgvpayment["cItemName", r].Value) == string.Empty && !dgvpayment.CurrentRow.IsNewRow)
                {
                    dgvpayment.Rows.RemoveAt(r);
                }
                using (inventoryDataContext)
                {
                    var queryable2 = from li in inventoryDataContext.items
                                     join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
                                     where li.item_name == Convert.ToString(dgvpayment["cItemName", r].Value)
                                     select new
                                     {
                                         cat,
                                         li
                                     };
                    foreach (var item2 in queryable2)
                    {
                        dgvpayment["cPurRate", r].Value = item2.li.item_purchaserate;
                        dgvpayment["cItemCode", r].Value = item2.li.item_code;
                        dgvpayment["cItemId", r].Value = item2.li.item_id;
                        dgvpayment["cCategory", r].Value = item2.cat.cat_name;
                        dgvpayment["cCatId", r].Value = item2.cat.cat_id;
                    }
                }
                dgvpayment.CurrentCell = dgvpayment.Rows[dgvpayment.CurrentCellAddress.Y].Cells["cQty"];
                dgvpayment.Focus();
                if (Convert.ToString(dgvpayment["cItemName", r].Value) == string.Empty && !dgvpayment.CurrentRow.IsNewRow)
                {
                    dgvpayment.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvpayment["cQty", r].Value), out decimal result);
                result = Math.Abs(result);
                dgvpayment["cQty", r].Value = ((result > 0m) ? ((object)result) : null);
                decimal.TryParse(Convert.ToString(dgvpayment["cPurRate", r].Value), out decimal result2);
                dgvpayment["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
                calacTotal();
                SetColumnIndex method = Mymethod;
                dgvpayment.BeginInvoke(method, "cCategory");
                if (Convert.ToString(dgvpayment["cItemName", r].Value) == string.Empty && !dgvpayment.CurrentRow.IsNewRow)
                {
                    dgvpayment.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvpayment["cMrp", r].Value), out result2);
                result2 = Math.Abs(result2);
                dgvpayment["cMrp", r].Value = ((result2 > 0m) ? ((object)result2) : null);
                if (Convert.ToString(dgvpayment["cItemName", r].Value) == string.Empty && !dgvpayment.CurrentRow.IsNewRow)
                {
                    dgvpayment.Rows.RemoveAt(r);
                }
                decimal.TryParse(Convert.ToString(dgvpayment["cPurRate", r].Value), out result2);
                result2 = Math.Abs(result2);
                dgvpayment["cPurRate", r].Value = ((result2 > 0m) ? ((object)result2) : null);
                decimal.TryParse(Convert.ToString(dgvpayment["cQty", r].Value), out result);
                dgvpayment["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
                calacTotal();
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
            txtNewBalance.Value = txtOutstanding.Value - txtPaidamt.Value;
        }

        private void dgopen_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvpayment.CurrentCell == null)
            {
                return;
            }
            if (dgvpayment.CurrentCell.ColumnIndex == 1)
            {
            }
            if (e.KeyCode == Keys.F3 || e.KeyCode == Keys.Delete)
            {
                if (dgvpayment.CurrentRow.IsNewRow)
                {
                    return;
                }
                dgvpayment.Rows.RemoveAt(dgvpayment.CurrentCell.RowIndex);
            }
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            {
                if (dgvpayment.CurrentCell.ColumnIndex == dgvpayment.Columns.Count - 5)
                {
                    dgvpayment.Rows.Add();
                    dgvpayment.CurrentCell = dgvpayment.Rows[dgvpayment.CurrentCellAddress.Y + 1].Cells[1];
                    dgvpayment.Focus();
                }
                else
                {
                    dgvpayment.CurrentCell = dgvpayment.Rows[dgvpayment.CurrentCellAddress.Y].Cells[dgvpayment.CurrentCell.ColumnIndex + 1];
                    dgvpayment.BeginEdit(selectAll: true);
                    dgvpayment.Focus();
                }
            }
        }

        private void dtpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cboCity.Focus();
            }
        }

        private void dtpbilldate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cboSupplier.Focus();
            }
        }

        private void cbopurfrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && cboSupplier.Text.Trim() != string.Empty)
            {
                txtPaidamt.Focus();
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
            dtprecdate.Focus();
        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
                if (Convert.ToInt32(cboSupplierView.SelectedValue) > 0)
                {
                    usppaymentSelectResultBindingSource.DataSource = inventoryDataContext.usp_paymentSelect(null, Convert.ToInt32(cboSupplierView.SelectedValue), dtpfdate.Value, dtptdate.Value);
                }
                else
                {
                    usppaymentSelectResultBindingSource.DataSource = inventoryDataContext.usp_paymentSelect(null, null, dtpfdate.Value, dtptdate.Value);
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
        }

        private void dglist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == ldelete.Index && e.RowIndex > -1)
                {
                    int recid = Convert.ToInt32(dglist["idDataGridViewTextBoxColumn", e.RowIndex].Value);
                    int smid = Convert.ToInt32(dglist["smidDataGridViewTextBoxColumn", e.RowIndex].Value);
                    int ob_id = Convert.ToInt32(dglist["ob_id", e.RowIndex].Value);

                    decimal value = Convert.ToDecimal(dglist["recPAIDamtDataGridViewTextBoxColumn", e.RowIndex].Value);
                    InventoryDataContext inventoryDataContext = new InventoryDataContext();
                    if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                    {
                        inventoryDataContext.usp_paymentDelete(recid, smid, ob_id, value);
                        cmdList_Click(this, null);
                        MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (e.ColumnIndex == ledit.Index && e.RowIndex > -1 && dglist.CurrentCell != null)
                {
                    loadlist();
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
                cboCityView.Focus();
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
            if (!(cboSupplier.Text.Trim() == ""))
            {
            }
        }

        private void dgvPurchase_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvpayment.Columns[dgvpayment.CurrentCellAddress.X].Name == "cItemName")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = acsItemName;
                }
            }
            else if (dgvpayment.Columns[dgvpayment.CurrentCellAddress.X].Name == "cItemCode")
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox.AutoCompleteCustomSource = acsItemCode;
                }
            }
            else if (dgvpayment.Columns[dgvpayment.CurrentCellAddress.X].Name == "cCategory")
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
            if (cboCity.SelectedItem != null)
            {
                InventoryDataContext inventoryDataContext = new InventoryDataContext();
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
                }
            }
        }

        private void cboCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cboSupplier.Focus();
            }
        }

        private void txtPaidamt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdsave.Focus();
            }
        }

        private void cboSupplier_Leave(object sender, EventArgs e)
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            using (inventoryDataContext)
            {
                IQueryable<ledgermaster> queryable = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_id == (long)Convert.ToInt32(cboSupplier.SelectedValue));
                foreach (ledgermaster item in queryable)
                {
                    lblAddress.Text = item.led_address + "," + item.led_address1 + ",";
                    lblAddress1.Text = item.led_address2 + "-" + item.led_pincode;
                }
                IQueryable<openingbalance> openingbalancedata = inventoryDataContext.openingbalances.Where((openingbalance list) => list.led_id == (long?)(long)Convert.ToInt32(cboSupplier.SelectedValue) && list.ob_isclose == (bool?)false).OrderBy(ob => ob.ob_refno);
                if (openingbalancedata.Count() > 0)
                {
                    lblpaymentType.Text = "OpeningBalance";
                    IsHavingOpeningBalance = true;
                    dgvpayment.Rows.Clear();
                    int num = 0;
                    decimal num2 = 0m;
                    foreach (openingbalance item2 in openingbalancedata)
                    {
                        dgvpayment.Rows.Add();
                        dgvpayment.Rows[num].Cells["osno"].Value = num + 1;
                        dgvpayment.Rows[num].Cells["cPMId"].Value = item2.ob_id;
                        dgvpayment.Rows[num].Cells["cBillNo"].Value = item2.ob_refno;
                        dgvpayment.Rows[num].Cells["cBilldate"].Value = item2.ob_date.Value.ToString("dd-MM-yyyy");
                        TimeSpan timeSpan = DateTime.Now.Subtract(item2.ob_date.Value);
                        dgvpayment.Rows[num].Cells["cDayscount"].Value = timeSpan.Days;
                        dgvpayment.Rows[num].Cells["cBillAmt"].Value = item2.ob_netamount;
                        num2 += item2.ob_netamount - item2.ob_received;
                        dgvpayment.Rows[num].Cells["cpaid"].Value = 0;
                        dgvpayment.Rows[num].Cells["cExistpaid"].Value = item2.ob_received;
                        dgvpayment.Rows[num].Cells["cNewBalance"].Value = item2.ob_netamount - item2.ob_received;
                        num++;
                    }
                    txtOutstanding.DecimalPlaces = 2;
                    txtNewBalance.DecimalPlaces = 2;
                    txtOutstanding.Value = Convert.ToDecimal(num2.ToString("N2"));
                    txtNewBalance.Value = Convert.ToDecimal(num2.ToString("N2"));
                }
                else
                {
                    lblpaymentType.Text = "Purchase";
                    IsHavingOpeningBalance = false;

                    IQueryable<purchasemaster> queryable2 = inventoryDataContext.purchasemasters.Where((purchasemaster list) => list.led_id == (long?)(long)Convert.ToInt32(cboSupplier.SelectedValue) && list.pm_isclose == (bool?)false);
                    if (queryable2.Count() <= 0)
                    {
                        MessageBox.Show("No pending bills for " + cboSupplier.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        lblpaymentType.Text = "Purchase";
                        dgvpayment.Rows.Clear();
                        int num = 0;
                        decimal num2 = 0m;
                        foreach (purchasemaster item2 in queryable2)
                        {
                            dgvpayment.Rows.Add();
                            dgvpayment.Rows[num].Cells["osno"].Value = num + 1;
                            dgvpayment.Rows[num].Cells["cPMId"].Value = item2.pm_id;
                            dgvpayment.Rows[num].Cells["cBillNo"].Value = item2.pm_no;
                            dgvpayment.Rows[num].Cells["cBilldate"].Value = item2.pm_date.Value.ToString("dd-MM-yyyy");
                            TimeSpan timeSpan = DateTime.Now.Subtract(item2.pm_date.Value);
                            dgvpayment.Rows[num].Cells["cDayscount"].Value = timeSpan.Days;
                            dgvpayment.Rows[num].Cells["cBillAmt"].Value = item2.pm_totamount;
                            num2 += item2.pm_totamount - (item2.pm_paid ?? 0m);
                            dgvpayment.Rows[num].Cells["cpaid"].Value = 0;
                            dgvpayment.Rows[num].Cells["cExistpaid"].Value = item2.pm_paid;
                            dgvpayment.Rows[num].Cells["cNewBalance"].Value = item2.pm_totamount - item2.pm_paid;
                            num++;
                        }
                        txtOutstanding.DecimalPlaces = 2;
                        txtNewBalance.DecimalPlaces = 2;
                        txtOutstanding.Value = Convert.ToDecimal(num2.ToString("N2"));
                        txtNewBalance.Value = Convert.ToDecimal(num2.ToString("N2"));
                    }
                }
            }
        }

        private void txtPaidamt_TextChanged(object sender, EventArgs e)
        {
            if (txtPaidamt.Value > txtOutstanding.Value)
            {
                MessageBox.Show("Paid amount should not greater then outsatanding...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPaidamt.Value = 0m;
                return;
            }
            decimal num = 0m;
            foreach (DataGridViewRow item in (IEnumerable)dgvpayment.Rows)
            {
                item.Cells["cpaid"].Value = "0.00";
                item.Cells["cNewBalance"].Value = Convert.ToDecimal(item.Cells["cBillAmt"].Value) - Convert.ToDecimal(item.Cells["cExistpaid"].Value);
            }
            if (txtPaidamt.Value > 0m)
            {
                foreach (DataGridViewRow item2 in (IEnumerable)dgvpayment.Rows)
                {
                    if (num == txtPaidamt.Value)
                    {
                        break;
                    }
                    decimal num2 = txtPaidamt.Value - num;
                    if (num2 > 0m)
                    {
                        if (num2 >= Convert.ToDecimal(item2.Cells["cNewBalance"].Value))
                        {
                            item2.Cells["cpaid"].Value = Convert.ToDecimal(item2.Cells["cNewBalance"].Value);
                            num += Convert.ToDecimal(item2.Cells["cNewBalance"].Value);
                            item2.Cells["cNewBalance"].Value = "0.00";
                        }
                        else
                        {
                            item2.Cells["cpaid"].Value = num2;
                            item2.Cells["cNewBalance"].Value = Convert.ToDecimal(item2.Cells["cNewBalance"].Value) - num2;
                            num += num2;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow item3 in (IEnumerable)dgvpayment.Rows)
                {
                    item3.Cells["cpaid"].Value = "0.00";
                    item3.Cells["cNewBalance"].Value = Convert.ToDecimal(item3.Cells["cBillAmt"].Value) - Convert.ToDecimal(item3.Cells["cExistpaid"].Value);
                }
            }
            calacTotal();
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
                                 where a.led_accounttype == "Supplier" && a.led_address2 == cboCityView.Text.ToString()
                                 select new
                                 {
                                     a.led_id,
                                     a.led_name
                                 };
                    ledgermasterViewBindingSource.DataSource = source.OrderBy(x => x.led_name);
                }
            }
        }

        private void txtPaidamt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdsave.Focus();
            }
        }

        private void cboSupplierView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                cmdList_Click(null, null);
            }
        }

        private void tablelist_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tablemain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cboCityView_KeyDown(object sender, KeyEventArgs e)
        {
            cboSupplierView.Focus();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle91 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablemain = new System.Windows.Forms.TableLayoutPanel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tableentry = new System.Windows.Forms.TableLayoutPanel();
            this.lblopno = new System.Windows.Forms.Label();
            this.txtrecno = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.dtprecdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutstanding = new mylib.decimalbox(this.components);
            this.txtPaidamt = new mylib.decimalbox(this.components);
            this.txtNewBalance = new mylib.decimalbox(this.components);
            this.lblfrom = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblpaymentType = new System.Windows.Forms.Label();
            this.tablecmd = new System.Windows.Forms.TableLayoutPanel();
            this.cmdsave = new mylib.lightbutton();
            this.cmdrefresh = new mylib.lightbutton();
            this.cmdclose = new mylib.lightbutton();
            this.cmdview = new mylib.lightbutton();
            this.pnlentry = new System.Windows.Forms.Panel();
            this.dgvpayment = new mylib.mygrid();
            this.osno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBilldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBillAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExistpaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNewBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDayscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPMId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableview = new System.Windows.Forms.TableLayoutPanel();
            this.dglist = new mylib.mygrid();
            this.ldelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ledit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recbillamtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recpaidamtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recnewbalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reciscloseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ob_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usppaymentSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblsubtitle = new System.Windows.Forms.Label();
            this.tablelist = new System.Windows.Forms.TableLayoutPanel();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.lblhyp = new System.Windows.Forms.Label();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.lblfdate = new System.Windows.Forms.Label();
            this.cmdList = new mylib.lightbutton();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCityView = new System.Windows.Forms.ComboBox();
            this.ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cboSupplierView = new System.Windows.Forms.ComboBox();
            this.ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdexit = new mylib.lightbutton();
            this.pnlview = new System.Windows.Forms.Panel();
            this.tablemain.SuspendLayout();
            this.tableentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            this.tablecmd.SuspendLayout();
            this.pnlentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
            this.tableview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usppaymentSelectResultBindingSource)).BeginInit();
            this.tablelist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).BeginInit();
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
            this.tablemain.Controls.Add(this.tablecmd, 0, 3);
            this.tablemain.Controls.Add(this.pnlentry, 0, 2);
            this.tablemain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablemain.Location = new System.Drawing.Point(0, 0);
            this.tablemain.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tablemain.Name = "tablemain";
            this.tablemain.RowCount = 4;
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tablemain.Size = new System.Drawing.Size(1160, 697);
            this.tablemain.TabIndex = 0;
            this.tablemain.Paint += new System.Windows.Forms.PaintEventHandler(this.tablemain_Paint);
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(508, 4);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(144, 35);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "Payment";
            // 
            // tableentry
            // 
            this.tableentry.ColumnCount = 8;
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.Controls.Add(this.lblopno, 0, 0);
            this.tableentry.Controls.Add(this.txtrecno, 1, 0);
            this.tableentry.Controls.Add(this.lbldate, 0, 1);
            this.tableentry.Controls.Add(this.dtprecdate, 1, 1);
            this.tableentry.Controls.Add(this.label2, 2, 0);
            this.tableentry.Controls.Add(this.cboCity, 3, 0);
            this.tableentry.Controls.Add(this.label1, 0, 2);
            this.tableentry.Controls.Add(this.label3, 2, 2);
            this.tableentry.Controls.Add(this.label4, 4, 2);
            this.tableentry.Controls.Add(this.txtOutstanding, 1, 2);
            this.tableentry.Controls.Add(this.txtPaidamt, 3, 2);
            this.tableentry.Controls.Add(this.txtNewBalance, 5, 2);
            this.tableentry.Controls.Add(this.lblfrom, 2, 1);
            this.tableentry.Controls.Add(this.cboSupplier, 3, 1);
            this.tableentry.Controls.Add(this.lblAddress, 4, 0);
            this.tableentry.Controls.Add(this.lblAddress1, 4, 1);
            this.tableentry.Controls.Add(this.lblpaymentType, 5, 1);
            this.tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableentry.Location = new System.Drawing.Point(7, 51);
            this.tableentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableentry.Name = "tableentry";
            this.tableentry.RowCount = 4;
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.Size = new System.Drawing.Size(1146, 111);
            this.tableentry.TabIndex = 0;
            // 
            // lblopno
            // 
            this.lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblopno.AutoSize = true;
            this.lblopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblopno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblopno.Location = new System.Drawing.Point(5, 0);
            this.lblopno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblopno.Name = "lblopno";
            this.lblopno.Size = new System.Drawing.Size(113, 35);
            this.lblopno.TabIndex = 1;
            this.lblopno.Text = "Payment No";
            // 
            // txtrecno
            // 
            this.txtrecno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtrecno.BackColor = System.Drawing.Color.White;
            this.txtrecno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrecno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtrecno.Location = new System.Drawing.Point(145, 7);
            this.txtrecno.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtrecno.MaxLength = 20;
            this.txtrecno.Name = "txtrecno";
            this.txtrecno.Size = new System.Drawing.Size(203, 42);
            this.txtrecno.TabIndex = 0;
            this.txtrecno.TabStop = false;
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldate.Location = new System.Drawing.Point(5, 35);
            this.lbldate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(83, 35);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Rec Date";
            // 
            // dtprecdate
            // 
            this.dtprecdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtprecdate.CustomFormat = "dd-MM-yyyy";
            this.dtprecdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtprecdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprecdate.Location = new System.Drawing.Point(145, 42);
            this.dtprecdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtprecdate.Name = "dtprecdate";
            this.dtprecdate.Size = new System.Drawing.Size(201, 42);
            this.dtprecdate.TabIndex = 0;
            this.dtprecdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpdate_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(365, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 35);
            this.label2.TabIndex = 10;
            this.label2.Text = "City";
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
            this.cboCity.Location = new System.Drawing.Point(510, 7);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(316, 43);
            this.cboCity.TabIndex = 4;
            this.cboCity.ValueMember = "led_id";
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            this.cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCity_KeyDown);
            // 
            // ledgermasterCityBindingSource
            // 
            this.ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(5, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "Outstanding";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(365, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 35);
            this.label3.TabIndex = 10;
            this.label3.Text = "Paid Amount";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(836, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 35);
            this.label4.TabIndex = 10;
            this.label4.Text = "New Balance";
            // 
            // txtOutstanding
            // 
            this.txtOutstanding.AllowFormat = false;
            this.txtOutstanding.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOutstanding.BackColor = System.Drawing.Color.White;
            this.txtOutstanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutstanding.DecimalPlaces = 1;
            this.txtOutstanding.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtOutstanding.Location = new System.Drawing.Point(145, 77);
            this.txtOutstanding.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtOutstanding.MaxLength = 10;
            this.txtOutstanding.Name = "txtOutstanding";
            this.txtOutstanding.RightAlign = true;
            this.txtOutstanding.Size = new System.Drawing.Size(203, 42);
            this.txtOutstanding.TabIndex = 11;
            this.txtOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOutstanding.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPaidamt
            // 
            this.txtPaidamt.AllowFormat = false;
            this.txtPaidamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPaidamt.BackColor = System.Drawing.Color.White;
            this.txtPaidamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaidamt.DecimalPlaces = 2;
            this.txtPaidamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPaidamt.Location = new System.Drawing.Point(510, 77);
            this.txtPaidamt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtPaidamt.MaxLength = 10;
            this.txtPaidamt.Name = "txtPaidamt";
            this.txtPaidamt.RightAlign = true;
            this.txtPaidamt.Size = new System.Drawing.Size(316, 42);
            this.txtPaidamt.TabIndex = 11;
            this.txtPaidamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaidamt.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPaidamt.TextChanged += new System.EventHandler(this.txtPaidamt_TextChanged);
            this.txtPaidamt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaidamt_KeyDown_1);
            // 
            // txtNewBalance
            // 
            this.txtNewBalance.AllowFormat = false;
            this.txtNewBalance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNewBalance.BackColor = System.Drawing.Color.Magenta;
            this.txtNewBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewBalance.DecimalPlaces = 1;
            this.txtNewBalance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtNewBalance.ForeColor = System.Drawing.SystemColors.Info;
            this.txtNewBalance.Location = new System.Drawing.Point(987, 77);
            this.txtNewBalance.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtNewBalance.MaxLength = 10;
            this.txtNewBalance.Name = "txtNewBalance";
            this.txtNewBalance.RightAlign = true;
            this.txtNewBalance.Size = new System.Drawing.Size(191, 42);
            this.txtNewBalance.TabIndex = 11;
            this.txtNewBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewBalance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblfrom
            // 
            this.lblfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfrom.Location = new System.Drawing.Point(365, 35);
            this.lblfrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(123, 35);
            this.lblfrom.TabIndex = 10;
            this.lblfrom.Text = "SUPPLIER";
            // 
            // cboSupplier
            // 
            this.cboSupplier.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplier.DataSource = this.ledgermasterBindingSource;
            this.cboSupplier.DisplayMember = "led_name";
            this.cboSupplier.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(510, 42);
            this.cboSupplier.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(316, 43);
            this.cboSupplier.TabIndex = 4;
            this.cboSupplier.ValueMember = "led_id";
            this.cboSupplier.SelectedValueChanged += new System.EventHandler(this.cbopurfrom_SelectedValueChanged);
            this.cboSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbopurfrom_KeyDown);
            this.cboSupplier.Leave += new System.EventHandler(this.cboSupplier_Leave);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.tableentry.SetColumnSpan(this.lblAddress, 4);
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAddress.Location = new System.Drawing.Point(836, 0);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(24, 35);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = ".";
            // 
            // lblAddress1
            // 
            this.lblAddress1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAddress1.Location = new System.Drawing.Point(836, 35);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(24, 35);
            this.lblAddress1.TabIndex = 10;
            this.lblAddress1.Text = ".";
            // 
            // lblpaymentType
            // 
            this.lblpaymentType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblpaymentType.AutoSize = true;
            this.lblpaymentType.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblpaymentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblpaymentType.Location = new System.Drawing.Point(987, 35);
            this.lblpaymentType.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblpaymentType.Name = "lblpaymentType";
            this.lblpaymentType.Size = new System.Drawing.Size(251, 35);
            this.lblpaymentType.TabIndex = 10;
            this.lblpaymentType.Text = "OpeningBalance";
            // 
            // tablecmd
            // 
            this.tablecmd.ColumnCount = 5;
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tablecmd.Controls.Add(this.cmdsave, 1, 0);
            this.tablecmd.Controls.Add(this.cmdrefresh, 2, 0);
            this.tablecmd.Controls.Add(this.cmdclose, 4, 0);
            this.tablecmd.Controls.Add(this.cmdview, 3, 0);
            this.tablecmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablecmd.Location = new System.Drawing.Point(7, 631);
            this.tablecmd.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tablecmd.Name = "tablecmd";
            this.tablecmd.RowCount = 1;
            this.tablecmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.Size = new System.Drawing.Size(1146, 57);
            this.tablecmd.TabIndex = 3;
            // 
            // cmdsave
            // 
            this.cmdsave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdsave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdsave.Location = new System.Drawing.Point(515, 7);
            this.cmdsave.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(149, 43);
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
            this.cmdrefresh.Location = new System.Drawing.Point(674, 7);
            this.cmdrefresh.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdrefresh.Name = "cmdrefresh";
            this.cmdrefresh.Size = new System.Drawing.Size(149, 43);
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
            this.cmdclose.Location = new System.Drawing.Point(992, 7);
            this.cmdclose.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(149, 43);
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
            this.cmdview.Location = new System.Drawing.Point(833, 7);
            this.cmdview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdview.Name = "cmdview";
            this.cmdview.Size = new System.Drawing.Size(149, 43);
            this.cmdview.TabIndex = 2;
            this.cmdview.Text = "&View";
            this.cmdview.UseVisualStyleBackColor = true;
            this.cmdview.Click += new System.EventHandler(this.cmdview_Click);
            // 
            // pnlentry
            // 
            this.pnlentry.Controls.Add(this.dgvpayment);
            this.pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlentry.Location = new System.Drawing.Point(7, 178);
            this.pnlentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.Size = new System.Drawing.Size(1146, 437);
            this.pnlentry.TabIndex = 1;
            // 
            // dgvpayment
            // 
            this.dgvpayment.AllowUserToDeleteRows = false;
            this.dgvpayment.AllowUserToResizeRows = false;
            dataGridViewCellStyle79.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgvpayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle79;
            this.dgvpayment.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle80.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle80.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle80.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle80.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle80.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle80.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle80;
            this.dgvpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.osno,
            this.cBillNo,
            this.cBilldate,
            this.cBillAmt,
            this.cpaid,
            this.cExistpaid,
            this.cNewBalance,
            this.cDayscount,
            this.cPMId});
            this.dgvpayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvpayment.Location = new System.Drawing.Point(0, 0);
            this.dgvpayment.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dgvpayment.MultiSelect = false;
            this.dgvpayment.Name = "dgvpayment";
            this.dgvpayment.ReadOnly = true;
            this.dgvpayment.RowHeadersVisible = false;
            this.dgvpayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle86.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgvpayment.RowsDefaultCellStyle = dataGridViewCellStyle86;
            this.dgvpayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvpayment.ShowCellToolTips = false;
            this.dgvpayment.Size = new System.Drawing.Size(1146, 437);
            this.dgvpayment.TabIndex = 0;
            this.dgvpayment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgopen_CellEndEdit);
            this.dgvpayment.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPurchase_EditingControlShowing);
            this.dgvpayment.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgopen_RowsAdded);
            this.dgvpayment.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgopen_RowsRemoved);
            this.dgvpayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgopen_KeyDown);
            // 
            // osno
            // 
            this.osno.HeaderText = "SNO";
            this.osno.Name = "osno";
            this.osno.ReadOnly = true;
            this.osno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.osno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.osno.Width = 45;
            // 
            // cBillNo
            // 
            this.cBillNo.HeaderText = "BILL NO";
            this.cBillNo.Name = "cBillNo";
            this.cBillNo.ReadOnly = true;
            this.cBillNo.Width = 150;
            // 
            // cBilldate
            // 
            this.cBilldate.HeaderText = "BILL DATE";
            this.cBilldate.Name = "cBilldate";
            this.cBilldate.ReadOnly = true;
            this.cBilldate.Width = 150;
            // 
            // cBillAmt
            // 
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle81.Format = "N2";
            this.cBillAmt.DefaultCellStyle = dataGridViewCellStyle81;
            this.cBillAmt.HeaderText = "BILL AMOUNT";
            this.cBillAmt.Name = "cBillAmt";
            this.cBillAmt.ReadOnly = true;
            this.cBillAmt.Width = 150;
            // 
            // cpaid
            // 
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle82.Format = "N2";
            this.cpaid.DefaultCellStyle = dataGridViewCellStyle82;
            this.cpaid.HeaderText = "PAID";
            this.cpaid.MaxInputLength = 10;
            this.cpaid.Name = "cpaid";
            this.cpaid.ReadOnly = true;
            this.cpaid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cpaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cpaid.Width = 150;
            // 
            // cExistpaid
            // 
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle83.Format = "N2";
            this.cExistpaid.DefaultCellStyle = dataGridViewCellStyle83;
            this.cExistpaid.HeaderText = "ALREADY PAID";
            this.cExistpaid.Name = "cExistpaid";
            this.cExistpaid.ReadOnly = true;
            this.cExistpaid.Width = 150;
            // 
            // cNewBalance
            // 
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle84.Format = "N2";
            this.cNewBalance.DefaultCellStyle = dataGridViewCellStyle84;
            this.cNewBalance.HeaderText = "NEW BALANCE";
            this.cNewBalance.Name = "cNewBalance";
            this.cNewBalance.ReadOnly = true;
            this.cNewBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNewBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cNewBalance.Width = 150;
            // 
            // cDayscount
            // 
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cDayscount.DefaultCellStyle = dataGridViewCellStyle85;
            this.cDayscount.HeaderText = "DAYS COUNT";
            this.cDayscount.Name = "cDayscount";
            this.cDayscount.ReadOnly = true;
            this.cDayscount.Width = 150;
            // 
            // cPMId
            // 
            this.cPMId.HeaderText = "SMID";
            this.cPMId.Name = "cPMId";
            this.cPMId.ReadOnly = true;
            this.cPMId.Visible = false;
            // 
            // tableview
            // 
            this.tableview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableview.ColumnCount = 1;
            this.tableview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.Controls.Add(this.dglist, 0, 2);
            this.tableview.Controls.Add(this.lblsubtitle, 0, 0);
            this.tableview.Controls.Add(this.tablelist, 0, 1);
            this.tableview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableview.Location = new System.Drawing.Point(0, 0);
            this.tableview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableview.Name = "tableview";
            this.tableview.RowCount = 4;
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableview.Size = new System.Drawing.Size(1160, 697);
            this.tableview.TabIndex = 0;
            // 
            // dglist
            // 
            this.dglist.AllowUserToAddRows = false;
            this.dglist.AllowUserToDeleteRows = false;
            this.dglist.AllowUserToResizeRows = false;
            dataGridViewCellStyle87.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dglist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle87;
            this.dglist.AutoGenerateColumns = false;
            this.dglist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dglist.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle88.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle88.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle88.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle88.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle88.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle88.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle88;
            this.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ldelete,
            this.ledit,
            this.lprint,
            this.idDataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.ledaddress2DataGridViewTextBoxColumn,
            this.recnoDataGridViewTextBoxColumn,
            this.recdateDataGridViewTextBoxColumn,
            this.ledidDataGridViewTextBoxColumn,
            this.smidDataGridViewTextBoxColumn,
            this.comidDataGridViewTextBoxColumn,
            this.recbillamtDataGridViewTextBoxColumn,
            this.recpaidamtDataGridViewTextBoxColumn,
            this.recnewbalanceDataGridViewTextBoxColumn,
            this.reciscloseDataGridViewTextBoxColumn,
            this.ob_id});
            this.dglist.DataSource = this.usppaymentSelectResultBindingSource;
            this.dglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglist.Location = new System.Drawing.Point(7, 176);
            this.dglist.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dglist.MultiSelect = false;
            this.dglist.Name = "dglist";
            this.dglist.ReadOnly = true;
            this.dglist.RowHeadersVisible = false;
            this.dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglist.ShowCellToolTips = false;
            this.dglist.Size = new System.Drawing.Size(1146, 457);
            this.dglist.TabIndex = 1;
            this.dglist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglist_CellContentClick);
            this.dglist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dglist_CellDoubleClick);
            this.dglist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgList_KeyDown);
            // 
            // ldelete
            // 
            this.ldelete.HeaderText = "DELETE";
            this.ldelete.Image = global::standard.Properties.Resources.delete;
            this.ldelete.Name = "ldelete";
            this.ldelete.ReadOnly = true;
            this.ldelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ledit
            // 
            this.ledit.HeaderText = "EDIT";
            this.ledit.Name = "ledit";
            this.ledit.ReadOnly = true;
            this.ledit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ledit.Visible = false;
            this.ledit.Width = 45;
            // 
            // lprint
            // 
            this.lprint.HeaderText = "PRINT";
            this.lprint.Name = "lprint";
            this.lprint.ReadOnly = true;
            this.lprint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lprint.Visible = false;
            this.lprint.Width = 45;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Supplier";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 250;
            // 
            // ledaddress2DataGridViewTextBoxColumn
            // 
            this.ledaddress2DataGridViewTextBoxColumn.DataPropertyName = "led_address2";
            this.ledaddress2DataGridViewTextBoxColumn.HeaderText = "City";
            this.ledaddress2DataGridViewTextBoxColumn.Name = "ledaddress2DataGridViewTextBoxColumn";
            this.ledaddress2DataGridViewTextBoxColumn.ReadOnly = true;
            this.ledaddress2DataGridViewTextBoxColumn.Width = 150;
            // 
            // recnoDataGridViewTextBoxColumn
            // 
            this.recnoDataGridViewTextBoxColumn.DataPropertyName = "pay_no";
            this.recnoDataGridViewTextBoxColumn.HeaderText = "Rec No";
            this.recnoDataGridViewTextBoxColumn.Name = "recnoDataGridViewTextBoxColumn";
            this.recnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.recnoDataGridViewTextBoxColumn.Width = 120;
            // 
            // recdateDataGridViewTextBoxColumn
            // 
            this.recdateDataGridViewTextBoxColumn.DataPropertyName = "pay_date";
            this.recdateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.recdateDataGridViewTextBoxColumn.Name = "recdateDataGridViewTextBoxColumn";
            this.recdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.recdateDataGridViewTextBoxColumn.Width = 120;
            // 
            // ledidDataGridViewTextBoxColumn
            // 
            this.ledidDataGridViewTextBoxColumn.DataPropertyName = "led_id";
            this.ledidDataGridViewTextBoxColumn.HeaderText = "led_id";
            this.ledidDataGridViewTextBoxColumn.Name = "ledidDataGridViewTextBoxColumn";
            this.ledidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledidDataGridViewTextBoxColumn.Visible = false;
            // 
            // smidDataGridViewTextBoxColumn
            // 
            this.smidDataGridViewTextBoxColumn.DataPropertyName = "pm_id";
            this.smidDataGridViewTextBoxColumn.HeaderText = "pm_id";
            this.smidDataGridViewTextBoxColumn.Name = "smidDataGridViewTextBoxColumn";
            this.smidDataGridViewTextBoxColumn.ReadOnly = true;
            this.smidDataGridViewTextBoxColumn.Visible = false;
            // 
            // comidDataGridViewTextBoxColumn
            // 
            this.comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
            this.comidDataGridViewTextBoxColumn.HeaderText = "com_id";
            this.comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
            this.comidDataGridViewTextBoxColumn.ReadOnly = true;
            this.comidDataGridViewTextBoxColumn.Visible = false;
            // 
            // recbillamtDataGridViewTextBoxColumn
            // 
            this.recbillamtDataGridViewTextBoxColumn.DataPropertyName = "pay_billamt";
            dataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle89.Format = "N2";
            this.recbillamtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle89;
            this.recbillamtDataGridViewTextBoxColumn.HeaderText = "Bill Amount";
            this.recbillamtDataGridViewTextBoxColumn.Name = "recbillamtDataGridViewTextBoxColumn";
            this.recbillamtDataGridViewTextBoxColumn.ReadOnly = true;
            this.recbillamtDataGridViewTextBoxColumn.Width = 150;
            // 
            // recpaidamtDataGridViewTextBoxColumn
            // 
            this.recpaidamtDataGridViewTextBoxColumn.DataPropertyName = "pay_paidamt";
            dataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle90.Format = "N2";
            this.recpaidamtDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle90;
            this.recpaidamtDataGridViewTextBoxColumn.HeaderText = "paid Amt";
            this.recpaidamtDataGridViewTextBoxColumn.Name = "recpaidamtDataGridViewTextBoxColumn";
            this.recpaidamtDataGridViewTextBoxColumn.ReadOnly = true;
            this.recpaidamtDataGridViewTextBoxColumn.Width = 200;
            // 
            // recnewbalanceDataGridViewTextBoxColumn
            // 
            this.recnewbalanceDataGridViewTextBoxColumn.DataPropertyName = "pay_newbalance";
            dataGridViewCellStyle91.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle91.Format = "N2";
            this.recnewbalanceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle91;
            this.recnewbalanceDataGridViewTextBoxColumn.HeaderText = "Balance";
            this.recnewbalanceDataGridViewTextBoxColumn.Name = "recnewbalanceDataGridViewTextBoxColumn";
            this.recnewbalanceDataGridViewTextBoxColumn.ReadOnly = true;
            this.recnewbalanceDataGridViewTextBoxColumn.Width = 200;
            // 
            // reciscloseDataGridViewTextBoxColumn
            // 
            this.reciscloseDataGridViewTextBoxColumn.DataPropertyName = "pay_isclose";
            this.reciscloseDataGridViewTextBoxColumn.HeaderText = "Isclose";
            this.reciscloseDataGridViewTextBoxColumn.Name = "reciscloseDataGridViewTextBoxColumn";
            this.reciscloseDataGridViewTextBoxColumn.ReadOnly = true;
            this.reciscloseDataGridViewTextBoxColumn.Visible = false;
            // 
            // ob_id
            // 
            this.ob_id.DataPropertyName = "ob_id";
            this.ob_id.HeaderText = "ob_id";
            this.ob_id.Name = "ob_id";
            this.ob_id.ReadOnly = true;
            this.ob_id.Visible = false;
            // 
            // usppaymentSelectResultBindingSource
            // 
            this.usppaymentSelectResultBindingSource.DataSource = typeof(standard.classes.usp_paymentSelectResult);
            // 
            // lblsubtitle
            // 
            this.lblsubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblsubtitle.AutoSize = true;
            this.lblsubtitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblsubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblsubtitle.Location = new System.Drawing.Point(470, 11);
            this.lblsubtitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblsubtitle.Name = "lblsubtitle";
            this.lblsubtitle.Size = new System.Drawing.Size(219, 35);
            this.lblsubtitle.TabIndex = 4;
            this.lblsubtitle.Text = "payment LIST";
            // 
            // tablelist
            // 
            this.tablelist.ColumnCount = 11;
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 302F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tablelist.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tablelist.Controls.Add(this.dtptdate, 3, 0);
            this.tablelist.Controls.Add(this.lblhyp, 2, 0);
            this.tablelist.Controls.Add(this.dtpfdate, 1, 0);
            this.tablelist.Controls.Add(this.lblfdate, 0, 0);
            this.tablelist.Controls.Add(this.cmdList, 5, 1);
            this.tablelist.Controls.Add(this.label5, 4, 0);
            this.tablelist.Controls.Add(this.cboCityView, 5, 0);
            this.tablelist.Controls.Add(this.label6, 1, 1);
            this.tablelist.Controls.Add(this.cboSupplierView, 3, 1);
            this.tablelist.Controls.Add(this.cmdexit, 6, 1);
            this.tablelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablelist.Location = new System.Drawing.Point(7, 64);
            this.tablelist.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tablelist.Name = "tablelist";
            this.tablelist.RowCount = 2;
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablelist.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tablelist.Size = new System.Drawing.Size(1146, 96);
            this.tablelist.TabIndex = 0;
            this.tablelist.Paint += new System.Windows.Forms.PaintEventHandler(this.tablelist_Paint);
            // 
            // dtptdate
            // 
            this.dtptdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtptdate.CustomFormat = "dd-MM-yyyy";
            this.dtptdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtptdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptdate.Location = new System.Drawing.Point(328, 7);
            this.dtptdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(203, 42);
            this.dtptdate.TabIndex = 1;
            this.dtptdate.ValueChanged += new System.EventHandler(this.dtptdate_ValueChanged);
            this.dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // lblhyp
            // 
            this.lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhyp.AutoSize = true;
            this.lblhyp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblhyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblhyp.Location = new System.Drawing.Point(290, 6);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(28, 35);
            this.lblhyp.TabIndex = 1;
            this.lblhyp.Text = "-";
            // 
            // dtpfdate
            // 
            this.dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfdate.CustomFormat = "dd-MM-yyyy";
            this.dtpfdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfdate.Location = new System.Drawing.Point(84, 7);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(193, 42);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.ValueChanged += new System.EventHandler(this.dtpfdate_ValueChanged);
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // lblfdate
            // 
            this.lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfdate.AutoSize = true;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(5, 0);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(66, 48);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            // 
            // cmdList
            // 
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(657, 50);
            this.cmdList.Margin = new System.Windows.Forms.Padding(2);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(129, 44);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdview_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(544, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 35);
            this.label5.TabIndex = 26;
            this.label5.Text = "City";
            // 
            // cboCityView
            // 
            this.cboCityView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCityView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCityView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tablelist.SetColumnSpan(this.cboCityView, 2);
            this.cboCityView.DataSource = this.ledgermasteCityViewrBindingSource;
            this.cboCityView.DisplayMember = "led_address2";
            this.cboCityView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCityView.FormattingEnabled = true;
            this.cboCityView.Location = new System.Drawing.Point(660, 7);
            this.cboCityView.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCityView.Name = "cboCityView";
            this.cboCityView.Size = new System.Drawing.Size(242, 43);
            this.cboCityView.TabIndex = 27;
            this.cboCityView.ValueMember = "led_id";
            this.cboCityView.SelectedValueChanged += new System.EventHandler(this.cboCityView_SelectedValueChanged);
            this.cboCityView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCityView_KeyDown);
            // 
            // ledgermasteCityViewrBindingSource
            // 
            this.ledgermasteCityViewrBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(84, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 35);
            this.label6.TabIndex = 28;
            this.label6.Text = "Supplier";
            // 
            // cboSupplierView
            // 
            this.cboSupplierView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboSupplierView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplierView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tablelist.SetColumnSpan(this.cboSupplierView, 2);
            this.cboSupplierView.DataSource = this.ledgermasterViewBindingSource;
            this.cboSupplierView.DisplayMember = "led_name";
            this.cboSupplierView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboSupplierView.FormattingEnabled = true;
            this.cboSupplierView.Location = new System.Drawing.Point(328, 55);
            this.cboSupplierView.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboSupplierView.Name = "cboSupplierView";
            this.cboSupplierView.Size = new System.Drawing.Size(322, 43);
            this.cboSupplierView.TabIndex = 29;
            this.cboSupplierView.ValueMember = "led_id";
            this.cboSupplierView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboSupplierView_KeyDown);
            // 
            // ledgermasterViewBindingSource
            // 
            this.ledgermasterViewBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // cmdexit
            // 
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(817, 50);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(2);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(151, 44);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
            // 
            // pnlview
            // 
            this.pnlview.Controls.Add(this.tableview);
            this.pnlview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlview.Enabled = false;
            this.pnlview.Location = new System.Drawing.Point(0, 0);
            this.pnlview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlview.Name = "pnlview";
            this.pnlview.Size = new System.Drawing.Size(1160, 697);
            this.pnlview.TabIndex = 12;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1160, 697);
            this.Controls.Add(this.tablemain);
            this.Controls.Add(this.pnlview);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "frmPayment";
            this.ShowInTaskbar = false;
            this.Tag = "TRANSACTION";
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmAmType_Load);
            this.tablemain.ResumeLayout(false);
            this.tablemain.PerformLayout();
            this.tableentry.ResumeLayout(false);
            this.tableentry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            this.tablecmd.ResumeLayout(false);
            this.pnlentry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
            this.tableview.ResumeLayout(false);
            this.tableview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usppaymentSelectResultBindingSource)).EndInit();
            this.tablelist.ResumeLayout(false);
            this.tablelist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).EndInit();
            this.pnlview.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
