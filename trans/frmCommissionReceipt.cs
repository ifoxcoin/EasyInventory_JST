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
	public class frmCommissionReceipt : Form
	{
		private delegate void SetColumnIndex(string colname);

		private int? id;

		private AutoCompleteStringCollection acsItemCode;

		private AutoCompleteStringCollection acsItemName;

		private AutoCompleteStringCollection acsCategoryName;

		private IContainer components = null;

		private TableLayoutPanel tablemain;

		private Label lbltitle;

		private mygrid dgvReceipt;

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

		private ComboBox cbocustomer;

		private Panel pnlview;

		private TableLayoutPanel tableview;

		private mygrid dglist;

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

		private Label label5;

		private ComboBox cboCityView;

		private Label label6;

		private ComboBox cboCustomerView;

		private BindingSource ledgermasteCityViewrBindingSource;

		private BindingSource ledgermasterViewBindingSource;

		private DataGridViewTextBoxColumn osno;

		private DataGridViewTextBoxColumn cBillNo;

		private DataGridViewTextBoxColumn cBilldate;

		private DataGridViewTextBoxColumn cBillAmt;

		private DataGridViewTextBoxColumn cReceived;

		private DataGridViewTextBoxColumn cExistReceived;

		private DataGridViewTextBoxColumn cNewBalance;

		private DataGridViewTextBoxColumn cDayscount;

		private DataGridViewTextBoxColumn cSMId;

		private BindingSource uspcommissionreceiptSelectResultBindingSource;

		private TableLayoutPanel tableLayoutPanel1;

		private DataGridViewImageColumn ldelete;

		private DataGridViewImageColumn ledit;

		private DataGridViewImageColumn lprint;

		private DataGridViewTextBoxColumn cr_no;

		private DataGridViewTextBoxColumn cr_date;

		private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledaddress2DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn cr_billamt;

		private DataGridViewTextBoxColumn cr_receivedamt;

		private DataGridViewTextBoxColumn cr_newbalance;

		private DataGridViewTextBoxColumn smidDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;

		private Label lblAddress1;

		public frmCommissionReceipt()
		{
			InitializeComponent();
		}

		private void frmAmType_Load(object sender, EventArgs e)
		{
			try
			{
				id = 0;
				LoadData();
				cboCity.SelectedIndex = 1;
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
					where a.led_accounttype == "Agent" || a.led_id == 0
					select new
					{
						a.led_id,
						a.led_name,
						a.led_address2
					};
				ledgermasterCityBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
				ledgermasteCityViewrBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
				uspcommissionreceiptSelectResultBindingSource.DataSource = inventoryDataContext.usp_commissionreceiptSelect(null, null, null, null);
				cbocustomer.SelectedIndex = -1;
				long? no = 0L;
				inventoryDataContext.usp_getYearNo("comrec_no", global.sysdate, ref no);
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
			cbocustomer.SelectedIndex = -1;
			cbocustomer.Text = string.Empty;
			dgvReceipt.Rows.Clear();
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
				commissionreceipt commissionreceipt = new commissionreceipt();
				commissionreceipt.led_agid = Convert.ToInt32(cbocustomer.SelectedValue);
				if (commissionreceipt.led_agid == 0)
				{
					MessageBox.Show("Invalid 'Agent'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					cbocustomer.Focus();
				}
				else if (dgvReceipt.RowCount <= 1)
				{
					MessageBox.Show("Invalid data to save", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					dgvReceipt.Focus();
				}
				else
				{
					int? num = id;
					if (num.GetValueOrDefault() != 0 || !num.HasValue)
					{
					}
					if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						commissionreceipt.cr_date = dtprecdate.Value;
						num = id;
						if (num.GetValueOrDefault() == 0 && num.HasValue)
						{
							commissionreceipt.cr_date = dtprecdate.Value;
							commissionreceipt.com_id = 1L;
							long? no = 0L;
							inventoryDataContext.usp_setYearNo("commrec_no", global.sysdate, ref no);
							foreach (DataGridViewRow item in (IEnumerable)dgvReceipt.Rows)
							{
								if (Convert.ToDecimal(item.Cells["cReceived"].Value) > 0m)
								{
									txtrecno.Text = Convert.ToString(no);
									if (!item.IsNewRow)
									{
										commissionreceipt.cr_billamt = Convert.ToDecimal(item.Cells["cBillAmt"].Value);
										commissionreceipt.sm_id = Convert.ToInt32(item.Cells["cSMId"].Value);
										commissionreceipt.cr_newbalance = Convert.ToDecimal(item.Cells["cNewBalance"].Value);
										commissionreceipt.cr_receivedamt = Convert.ToDecimal(item.Cells["cReceived"].Value);
										commissionreceipt.cr_no = Convert.ToInt32(no);
										if (commissionreceipt.cr_newbalance <= 0m)
										{
											commissionreceipt.cr_isclose = true;
										}
										else
										{
											commissionreceipt.cr_isclose = false;
										}
										inventoryDataContext.usp_commissionreceiptInsert(commissionreceipt.cr_no, commissionreceipt.cr_date, commissionreceipt.led_agid, commissionreceipt.sm_id, commissionreceipt.com_id, commissionreceipt.cr_billamt, commissionreceipt.cr_receivedamt, commissionreceipt.cr_newbalance, commissionreceipt.cr_isclose);
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
			dgvReceipt.CurrentCell = dgvReceipt[colname, dgvReceipt.RowCount - 1];
			dgvReceipt.BeginEdit(selectAll: true);
			dgvReceipt.Focus();
		}

		private void dgopen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvReceipt.CurrentCell != null)
			{
				int r = dgvReceipt.CurrentCell.RowIndex;
				int columnIndex = dgvReceipt.CurrentCell.ColumnIndex;
				if (Convert.ToString(dgvReceipt["cCategory", r].Value) == string.Empty && !dgvReceipt.CurrentRow.IsNewRow)
				{
					dgvReceipt.Rows.RemoveAt(r);
				}
				acsItemName = new AutoCompleteStringCollection();
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				using (inventoryDataContext)
				{
					IQueryable<item> queryable = from li in inventoryDataContext.items
						join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
						where cat.cat_name == Convert.ToString(dgvReceipt["cCategory", r].Value)
						select li;
					foreach (item item in queryable)
					{
						acsItemCode.Add(item.item_code);
						acsItemName.Add(item.item_name);
					}
				}
				if (Convert.ToString(dgvReceipt["cItemName", r].Value) == string.Empty && !dgvReceipt.CurrentRow.IsNewRow)
				{
					dgvReceipt.Rows.RemoveAt(r);
				}
				using (inventoryDataContext)
				{
					var queryable2 = from li in inventoryDataContext.items
						join cat in inventoryDataContext.categories on li.cat_id equals cat.cat_id
						where li.item_name == Convert.ToString(dgvReceipt["cItemName", r].Value)
						select new
						{
							cat,
							li
						};
					foreach (var item2 in queryable2)
					{
						dgvReceipt["cPurRate", r].Value = item2.li.item_purchaserate;
						dgvReceipt["cItemCode", r].Value = item2.li.item_code;
						dgvReceipt["cItemId", r].Value = item2.li.item_id;
						dgvReceipt["cCategory", r].Value = item2.cat.cat_name;
						dgvReceipt["cCatId", r].Value = item2.cat.cat_id;
					}
				}
				dgvReceipt.CurrentCell = dgvReceipt.Rows[dgvReceipt.CurrentCellAddress.Y].Cells["cQty"];
				dgvReceipt.Focus();
				if (Convert.ToString(dgvReceipt["cItemName", r].Value) == string.Empty && !dgvReceipt.CurrentRow.IsNewRow)
				{
					dgvReceipt.Rows.RemoveAt(r);
				}
				decimal.TryParse(Convert.ToString(dgvReceipt["cQty", r].Value), out decimal result);
				result = Math.Abs(result);
				dgvReceipt["cQty", r].Value = ((result > 0m) ? ((object)result) : null);
				decimal.TryParse(Convert.ToString(dgvReceipt["cPurRate", r].Value), out decimal result2);
				dgvReceipt["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
				calacTotal();
				SetColumnIndex method = Mymethod;
				dgvReceipt.BeginInvoke(method, "cCategory");
				if (Convert.ToString(dgvReceipt["cItemName", r].Value) == string.Empty && !dgvReceipt.CurrentRow.IsNewRow)
				{
					dgvReceipt.Rows.RemoveAt(r);
				}
				decimal.TryParse(Convert.ToString(dgvReceipt["cMrp", r].Value), out result2);
				result2 = Math.Abs(result2);
				dgvReceipt["cMrp", r].Value = ((result2 > 0m) ? ((object)result2) : null);
				if (Convert.ToString(dgvReceipt["cItemName", r].Value) == string.Empty && !dgvReceipt.CurrentRow.IsNewRow)
				{
					dgvReceipt.Rows.RemoveAt(r);
				}
				decimal.TryParse(Convert.ToString(dgvReceipt["cPurRate", r].Value), out result2);
				result2 = Math.Abs(result2);
				dgvReceipt["cPurRate", r].Value = ((result2 > 0m) ? ((object)result2) : null);
				decimal.TryParse(Convert.ToString(dgvReceipt["cQty", r].Value), out result);
				dgvReceipt["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
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
			if (dgvReceipt.CurrentCell == null)
			{
				return;
			}
			if (dgvReceipt.CurrentCell.ColumnIndex == 1)
			{
			}
			if (e.KeyCode == Keys.F3 || e.KeyCode == Keys.Delete)
			{
				if (dgvReceipt.CurrentRow.IsNewRow)
				{
					return;
				}
				dgvReceipt.Rows.RemoveAt(dgvReceipt.CurrentCell.RowIndex);
			}
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
			{
				if (dgvReceipt.CurrentCell.ColumnIndex == dgvReceipt.Columns.Count - 5)
				{
					dgvReceipt.Rows.Add();
					dgvReceipt.CurrentCell = dgvReceipt.Rows[dgvReceipt.CurrentCellAddress.Y + 1].Cells[1];
					dgvReceipt.Focus();
				}
				else
				{
					dgvReceipt.CurrentCell = dgvReceipt.Rows[dgvReceipt.CurrentCellAddress.Y].Cells[dgvReceipt.CurrentCell.ColumnIndex + 1];
					dgvReceipt.BeginEdit(selectAll: true);
					dgvReceipt.Focus();
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
				cbocustomer.Focus();
			}
		}

		private void cbopurfrom_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && cbocustomer.Text.Trim() != string.Empty)
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
				uspcommissionreceiptSelectResultBindingSource.DataSource = inventoryDataContext.usp_commissionreceiptSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value, dtptdate.Value);
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
					int num = Convert.ToInt32(dglist["idDataGridViewTextBoxColumn", e.RowIndex].Value);
					int num2 = Convert.ToInt32(dglist["smidDataGridViewTextBoxColumn", e.RowIndex].Value);
					decimal value = Convert.ToDecimal(dglist["cr_receivedamt", e.RowIndex].Value);
					InventoryDataContext inventoryDataContext = new InventoryDataContext();
					if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						inventoryDataContext.usp_commissionreceiptDelete(num, num2, value);
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
			if (!(cbocustomer.Text.Trim() == ""))
			{
			}
		}

		private void dgvPurchase_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dgvReceipt.Columns[dgvReceipt.CurrentCellAddress.X].Name == "cItemName")
			{
				TextBox textBox = e.Control as TextBox;
				if (textBox != null)
				{
					textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
					textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
					textBox.AutoCompleteCustomSource = acsItemName;
				}
			}
			else if (dgvReceipt.Columns[dgvReceipt.CurrentCellAddress.X].Name == "cItemCode")
			{
				TextBox textBox = e.Control as TextBox;
				if (textBox != null)
				{
					textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
					textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
					textBox.AutoCompleteCustomSource = acsItemCode;
				}
			}
			else if (dgvReceipt.Columns[dgvReceipt.CurrentCellAddress.X].Name == "cCategory")
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
						where a.led_accounttype == "Agent" && a.led_address2 == cboCity.Text.ToString()
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
				cbocustomer.Focus();
			}
		}

		private void txtPaidamt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cmdsave.Focus();
			}
		}

		private void cbocustomer_Leave(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			using (inventoryDataContext)
			{
				IQueryable<ledgermaster> queryable = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_id == (long)Convert.ToInt32(cbocustomer.SelectedValue));
				foreach (ledgermaster item in queryable)
				{
					lblAddress.Text = item.led_address + "," + item.led_address1 + ",";
					lblAddress1.Text = item.led_address2 + "-" + item.led_pincode;
				}
				IQueryable<salesmaster> queryable2 = from list in inventoryDataContext.salesmasters
					join le in inventoryDataContext.ledgermasters on list.led_id equals le.led_id
					join ag in inventoryDataContext.ledgermasters on le.led_id equals ag.led_id
					where ag.led_agid == (long?)(long)Convert.ToInt32(cbocustomer.SelectedValue) && list.sm_iscommissionclose == (bool?)false
					select list;
				if (queryable2.Count() <= 0)
				{
					MessageBox.Show("No pending bills for " + cbocustomer.Text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					dgvReceipt.Rows.Clear();
					int num = 0;
					decimal num2 = 0m;
					foreach (salesmaster item2 in queryable2)
					{
						dgvReceipt.Rows.Add();
						dgvReceipt.Rows[num].Cells["osno"].Value = num + 1;
						dgvReceipt.Rows[num].Cells["cSMId"].Value = item2.sm_id;
						dgvReceipt.Rows[num].Cells["cBillNo"].Value = item2.sm_refno;
						dgvReceipt.Rows[num].Cells["cBilldate"].Value = item2.sm_date.Value.ToString("dd-MM-yyyy");
						TimeSpan timeSpan = DateTime.Now.Subtract(item2.sm_date.Value);
						dgvReceipt.Rows[num].Cells["cDayscount"].Value = timeSpan.Days;
						dgvReceipt.Rows[num].Cells["cBillAmt"].Value = item2.sm_profit;
						num2 += item2.sm_profit - item2.sm_paidcommission;
						dgvReceipt.Rows[num].Cells["cReceived"].Value = 0;
						dgvReceipt.Rows[num].Cells["cExistReceived"].Value = item2.sm_paidcommission;
						dgvReceipt.Rows[num].Cells["cNewBalance"].Value = item2.sm_profit - item2.sm_paidcommission;
						num++;
					}
					txtOutstanding.DecimalPlaces = 2;
					txtNewBalance.DecimalPlaces = 2;
					txtOutstanding.Value = Convert.ToDecimal(num2.ToString("N2"));
					txtNewBalance.Value = Convert.ToDecimal(num2.ToString("N2"));
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
			foreach (DataGridViewRow item in (IEnumerable)dgvReceipt.Rows)
			{
				item.Cells["cReceived"].Value = "0.00";
				item.Cells["cNewBalance"].Value = Convert.ToDecimal(item.Cells["cBillAmt"].Value) - Convert.ToDecimal(item.Cells["cExistReceived"].Value);
			}
			if (txtPaidamt.Value > 0m)
			{
				foreach (DataGridViewRow item2 in (IEnumerable)dgvReceipt.Rows)
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
							item2.Cells["cReceived"].Value = Convert.ToDecimal(item2.Cells["cNewBalance"].Value);
							num += Convert.ToDecimal(item2.Cells["cNewBalance"].Value);
							item2.Cells["cNewBalance"].Value = "0.00";
						}
						else
						{
							item2.Cells["cReceived"].Value = num2;
							item2.Cells["cNewBalance"].Value = Convert.ToDecimal(item2.Cells["cNewBalance"].Value) - num2;
							num += num2;
						}
					}
				}
			}
			else
			{
				foreach (DataGridViewRow item3 in (IEnumerable)dgvReceipt.Rows)
				{
					item3.Cells["cReceived"].Value = "0.00";
					item3.Cells["cNewBalance"].Value = Convert.ToDecimal(item3.Cells["cBillAmt"].Value) - Convert.ToDecimal(item3.Cells["cExistReceived"].Value);
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
						where a.led_accounttype == "Agent" && a.led_address2 == cboCityView.Text.ToString()
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

		private void cboCustomerView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cmdList_Click(null, null);
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommissionReceipt));
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
            this.cbocustomer = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.tablecmd = new System.Windows.Forms.TableLayoutPanel();
            this.cmdsave = new mylib.lightbutton();
            this.cmdrefresh = new mylib.lightbutton();
            this.cmdclose = new mylib.lightbutton();
            this.cmdview = new mylib.lightbutton();
            this.pnlentry = new System.Windows.Forms.Panel();
            this.dgvReceipt = new mylib.mygrid();
            this.osno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBilldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBillAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cExistReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNewBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDayscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSMId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableview = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboCityView = new System.Windows.Forms.ComboBox();
            this.ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.lblhyp = new System.Windows.Forms.Label();
            this.dtpfdate = new System.Windows.Forms.DateTimePicker();
            this.lblfdate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCustomerView = new System.Windows.Forms.ComboBox();
            this.ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdList = new mylib.lightbutton();
            this.cmdexit = new mylib.lightbutton();
            this.dglist = new mylib.mygrid();
            this.ldelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ledit = new System.Windows.Forms.DataGridViewImageColumn();
            this.lprint = new System.Windows.Forms.DataGridViewImageColumn();
            this.cr_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr_billamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr_receivedamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cr_newbalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspcommissionreceiptSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblsubtitle = new System.Windows.Forms.Label();
            this.pnlview = new System.Windows.Forms.Panel();
            this.tablemain.SuspendLayout();
            this.tableentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            this.tablecmd.SuspendLayout();
            this.pnlentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            this.tableview.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspcommissionreceiptSelectResultBindingSource)).BeginInit();
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
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tablemain.Size = new System.Drawing.Size(1370, 697);
            this.tablemain.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(568, 8);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(234, 23);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "COMMISSION RECEIPT";
            // 
            // tableentry
            // 
            this.tableentry.ColumnCount = 8;
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 398F));
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
            this.tableentry.Controls.Add(this.cbocustomer, 3, 1);
            this.tableentry.Controls.Add(this.lblAddress, 4, 0);
            this.tableentry.Controls.Add(this.lblAddress1, 4, 1);
            this.tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableentry.Location = new System.Drawing.Point(7, 46);
            this.tableentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableentry.Name = "tableentry";
            this.tableentry.RowCount = 4;
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.Size = new System.Drawing.Size(1356, 111);
            this.tableentry.TabIndex = 0;
            // 
            // lblopno
            // 
            this.lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblopno.AutoSize = true;
            this.lblopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblopno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblopno.Location = new System.Drawing.Point(5, 6);
            this.lblopno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblopno.Name = "lblopno";
            this.lblopno.Size = new System.Drawing.Size(115, 23);
            this.lblopno.TabIndex = 1;
            this.lblopno.Text = "Receipt No";
            // 
            // txtrecno
            // 
            this.txtrecno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtrecno.BackColor = System.Drawing.Color.White;
            this.txtrecno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrecno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtrecno.Location = new System.Drawing.Point(144, 7);
            this.txtrecno.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtrecno.MaxLength = 20;
            this.txtrecno.Name = "txtrecno";
            this.txtrecno.Size = new System.Drawing.Size(203, 30);
            this.txtrecno.TabIndex = 0;
            this.txtrecno.TabStop = false;
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldate.Location = new System.Drawing.Point(5, 41);
            this.lbldate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(95, 23);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Rec Date";
            // 
            // dtprecdate
            // 
            this.dtprecdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtprecdate.CustomFormat = "dd-MM-yyyy";
            this.dtprecdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtprecdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtprecdate.Location = new System.Drawing.Point(144, 42);
            this.dtprecdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtprecdate.Name = "dtprecdate";
            this.dtprecdate.Size = new System.Drawing.Size(201, 30);
            this.dtprecdate.TabIndex = 0;
            this.dtprecdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpdate_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(357, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
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
            this.cboCity.Location = new System.Drawing.Point(501, 7);
            this.cboCity.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(347, 31);
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
            this.label1.Location = new System.Drawing.Point(5, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Outstanding";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(357, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Paid Amount";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(858, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 23);
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
            this.txtOutstanding.Location = new System.Drawing.Point(144, 77);
            this.txtOutstanding.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtOutstanding.MaxLength = 10;
            this.txtOutstanding.Name = "txtOutstanding";
            this.txtOutstanding.RightAlign = true;
            this.txtOutstanding.Size = new System.Drawing.Size(203, 30);
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
            this.txtPaidamt.Location = new System.Drawing.Point(501, 77);
            this.txtPaidamt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtPaidamt.MaxLength = 10;
            this.txtPaidamt.Name = "txtPaidamt";
            this.txtPaidamt.RightAlign = true;
            this.txtPaidamt.Size = new System.Drawing.Size(347, 30);
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
            this.txtNewBalance.Location = new System.Drawing.Point(1001, 77);
            this.txtNewBalance.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtNewBalance.MaxLength = 10;
            this.txtNewBalance.Name = "txtNewBalance";
            this.txtNewBalance.RightAlign = true;
            this.txtNewBalance.Size = new System.Drawing.Size(191, 30);
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
            this.lblfrom.Location = new System.Drawing.Point(357, 41);
            this.lblfrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(102, 23);
            this.lblfrom.TabIndex = 10;
            this.lblfrom.Text = "Customer";
            // 
            // cbocustomer
            // 
            this.cbocustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbocustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbocustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbocustomer.DataSource = this.ledgermasterBindingSource;
            this.cbocustomer.DisplayMember = "led_name";
            this.cbocustomer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbocustomer.FormattingEnabled = true;
            this.cbocustomer.Location = new System.Drawing.Point(501, 42);
            this.cbocustomer.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cbocustomer.Name = "cbocustomer";
            this.cbocustomer.Size = new System.Drawing.Size(347, 31);
            this.cbocustomer.TabIndex = 4;
            this.cbocustomer.ValueMember = "led_id";
            this.cbocustomer.SelectedValueChanged += new System.EventHandler(this.cbopurfrom_SelectedValueChanged);
            this.cbocustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbopurfrom_KeyDown);
            this.cbocustomer.Leave += new System.EventHandler(this.cbocustomer_Leave);
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
            this.lblAddress.Location = new System.Drawing.Point(858, 6);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(16, 23);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = ".";
            // 
            // lblAddress1
            // 
            this.lblAddress1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAddress1.Location = new System.Drawing.Point(858, 41);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(16, 23);
            this.lblAddress1.TabIndex = 10;
            this.lblAddress1.Text = ".";
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
            this.tablecmd.Size = new System.Drawing.Size(1356, 57);
            this.tablecmd.TabIndex = 3;
            // 
            // cmdsave
            // 
            this.cmdsave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdsave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdsave.Location = new System.Drawing.Point(725, 7);
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
            this.cmdrefresh.Location = new System.Drawing.Point(884, 7);
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
            this.cmdclose.Location = new System.Drawing.Point(1202, 7);
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
            this.cmdview.Location = new System.Drawing.Point(1043, 7);
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
            this.pnlentry.Controls.Add(this.dgvReceipt);
            this.pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlentry.Location = new System.Drawing.Point(7, 173);
            this.pnlentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.Size = new System.Drawing.Size(1356, 442);
            this.pnlentry.TabIndex = 1;
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.AllowUserToDeleteRows = false;
            this.dgvReceipt.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgvReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceipt.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.osno,
            this.cBillNo,
            this.cBilldate,
            this.cBillAmt,
            this.cReceived,
            this.cExistReceived,
            this.cNewBalance,
            this.cDayscount,
            this.cSMId});
            this.dgvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceipt.Location = new System.Drawing.Point(0, 0);
            this.dgvReceipt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dgvReceipt.MultiSelect = false;
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.ReadOnly = true;
            this.dgvReceipt.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dgvReceipt.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvReceipt.ShowCellToolTips = false;
            this.dgvReceipt.Size = new System.Drawing.Size(1356, 442);
            this.dgvReceipt.TabIndex = 0;
            this.dgvReceipt.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgopen_CellEndEdit);
            this.dgvReceipt.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPurchase_EditingControlShowing);
            this.dgvReceipt.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgopen_RowsAdded);
            this.dgvReceipt.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgopen_RowsRemoved);
            this.dgvReceipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgopen_KeyDown);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.cBillAmt.DefaultCellStyle = dataGridViewCellStyle3;
            this.cBillAmt.HeaderText = "BILL AMOUNT";
            this.cBillAmt.Name = "cBillAmt";
            this.cBillAmt.ReadOnly = true;
            this.cBillAmt.Width = 150;
            // 
            // cReceived
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.cReceived.DefaultCellStyle = dataGridViewCellStyle4;
            this.cReceived.HeaderText = "RECEIVED";
            this.cReceived.MaxInputLength = 10;
            this.cReceived.Name = "cReceived";
            this.cReceived.ReadOnly = true;
            this.cReceived.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cReceived.Width = 150;
            // 
            // cExistReceived
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.cExistReceived.DefaultCellStyle = dataGridViewCellStyle5;
            this.cExistReceived.HeaderText = "ALREADY RECEIVED";
            this.cExistReceived.Name = "cExistReceived";
            this.cExistReceived.ReadOnly = true;
            this.cExistReceived.Width = 150;
            // 
            // cNewBalance
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.cNewBalance.DefaultCellStyle = dataGridViewCellStyle6;
            this.cNewBalance.HeaderText = "NEW BALANCE";
            this.cNewBalance.Name = "cNewBalance";
            this.cNewBalance.ReadOnly = true;
            this.cNewBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNewBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cNewBalance.Width = 150;
            // 
            // cDayscount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cDayscount.DefaultCellStyle = dataGridViewCellStyle7;
            this.cDayscount.HeaderText = "DAYS COUNT";
            this.cDayscount.Name = "cDayscount";
            this.cDayscount.ReadOnly = true;
            this.cDayscount.Width = 150;
            // 
            // cSMId
            // 
            this.cSMId.HeaderText = "SMID";
            this.cSMId.Name = "cSMId";
            this.cSMId.ReadOnly = true;
            this.cSMId.Visible = false;
            // 
            // tableview
            // 
            this.tableview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableview.ColumnCount = 1;
            this.tableview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableview.Controls.Add(this.dglist, 0, 2);
            this.tableview.Controls.Add(this.lblsubtitle, 0, 0);
            this.tableview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableview.Location = new System.Drawing.Point(0, 0);
            this.tableview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableview.Name = "tableview";
            this.tableview.RowCount = 4;
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableview.Size = new System.Drawing.Size(1370, 697);
            this.tableview.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 345F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.Controls.Add(this.cboCityView, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtptdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblhyp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpfdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblfdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboCustomerView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdList, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdexit, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 51);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1356, 86);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // cboCityView
            // 
            this.cboCityView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCityView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCityView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCityView.DataSource = this.ledgermasteCityViewrBindingSource;
            this.cboCityView.DisplayMember = "led_address2";
            this.cboCityView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCityView.FormattingEnabled = true;
            this.cboCityView.Location = new System.Drawing.Point(554, 7);
            this.cboCityView.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCityView.Name = "cboCityView";
            this.cboCityView.Size = new System.Drawing.Size(335, 31);
            this.cboCityView.TabIndex = 27;
            this.cboCityView.ValueMember = "led_id";
            this.cboCityView.SelectedValueChanged += new System.EventHandler(this.cboCityView_SelectedValueChanged);
            // 
            // ledgermasteCityViewrBindingSource
            // 
            this.ledgermasteCityViewrBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(489, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "City";
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
            this.dtptdate.Size = new System.Drawing.Size(151, 30);
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
            this.lblhyp.Location = new System.Drawing.Point(295, 10);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(18, 23);
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
            this.dtpfdate.Location = new System.Drawing.Point(121, 7);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(159, 30);
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
            this.lblfdate.Location = new System.Drawing.Point(5, 10);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(54, 23);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(5, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Customer";
            // 
            // cboCustomerView
            // 
            this.cboCustomerView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCustomerView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomerView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cboCustomerView, 3);
            this.cboCustomerView.DataSource = this.ledgermasterViewBindingSource;
            this.cboCustomerView.DisplayMember = "led_name";
            this.cboCustomerView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCustomerView.FormattingEnabled = true;
            this.cboCustomerView.Location = new System.Drawing.Point(121, 50);
            this.cboCustomerView.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cboCustomerView.Name = "cboCustomerView";
            this.cboCustomerView.Size = new System.Drawing.Size(358, 31);
            this.cboCustomerView.TabIndex = 29;
            this.cboCustomerView.ValueMember = "led_id";
            this.cboCustomerView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCustomerView_KeyDown);
            // 
            // ledgermasterViewBindingSource
            // 
            this.ledgermasterViewBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // cmdList
            // 
            this.cmdList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(742, 45);
            this.cmdList.Margin = new System.Windows.Forms.Padding(2);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(150, 39);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdview_Click);
            // 
            // cmdexit
            // 
            this.cmdexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdexit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdexit.Location = new System.Drawing.Point(896, 45);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(2);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(150, 39);
            this.cmdexit.TabIndex = 3;
            this.cmdexit.Text = "&Exit";
            this.cmdexit.UseVisualStyleBackColor = false;
            this.cmdexit.Click += new System.EventHandler(this.cmdexit_Click);
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
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dglist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ldelete,
            this.ledit,
            this.lprint,
            this.cr_no,
            this.cr_date,
            this.lednameDataGridViewTextBoxColumn,
            this.ledaddress2DataGridViewTextBoxColumn,
            this.cr_billamt,
            this.cr_receivedamt,
            this.cr_newbalance,
            this.smidDataGridViewTextBoxColumn,
            this.comidDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.dglist.DataSource = this.uspcommissionreceiptSelectResultBindingSource;
            this.dglist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglist.Location = new System.Drawing.Point(7, 153);
            this.dglist.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.dglist.MultiSelect = false;
            this.dglist.Name = "dglist";
            this.dglist.ReadOnly = true;
            this.dglist.RowHeadersVisible = false;
            this.dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dglist.ShowCellToolTips = false;
            this.dglist.Size = new System.Drawing.Size(1356, 480);
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
            // cr_no
            // 
            this.cr_no.DataPropertyName = "cr_no";
            this.cr_no.HeaderText = "No";
            this.cr_no.Name = "cr_no";
            this.cr_no.ReadOnly = true;
            // 
            // cr_date
            // 
            this.cr_date.DataPropertyName = "cr_date";
            this.cr_date.HeaderText = "Date";
            this.cr_date.Name = "cr_date";
            this.cr_date.ReadOnly = true;
            this.cr_date.Width = 125;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Customer";
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
            this.ledaddress2DataGridViewTextBoxColumn.Width = 200;
            // 
            // cr_billamt
            // 
            this.cr_billamt.DataPropertyName = "cr_billamt";
            this.cr_billamt.HeaderText = "Bill Amt";
            this.cr_billamt.Name = "cr_billamt";
            this.cr_billamt.ReadOnly = true;
            this.cr_billamt.Width = 125;
            // 
            // cr_receivedamt
            // 
            this.cr_receivedamt.DataPropertyName = "cr_receivedamt";
            this.cr_receivedamt.HeaderText = "Paid";
            this.cr_receivedamt.Name = "cr_receivedamt";
            this.cr_receivedamt.ReadOnly = true;
            this.cr_receivedamt.Width = 125;
            // 
            // cr_newbalance
            // 
            this.cr_newbalance.DataPropertyName = "cr_newbalance";
            this.cr_newbalance.HeaderText = "Balance";
            this.cr_newbalance.Name = "cr_newbalance";
            this.cr_newbalance.ReadOnly = true;
            this.cr_newbalance.Width = 125;
            // 
            // smidDataGridViewTextBoxColumn
            // 
            this.smidDataGridViewTextBoxColumn.DataPropertyName = "sm_id";
            this.smidDataGridViewTextBoxColumn.HeaderText = "sm_id";
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
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspcommissionreceiptSelectResultBindingSource
            // 
            this.uspcommissionreceiptSelectResultBindingSource.DataSource = typeof(standard.classes.usp_commissionreceiptSelectResult);
            // 
            // lblsubtitle
            // 
            this.lblsubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblsubtitle.AutoSize = true;
            this.lblsubtitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblsubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblsubtitle.Location = new System.Drawing.Point(613, 10);
            this.lblsubtitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblsubtitle.Name = "lblsubtitle";
            this.lblsubtitle.Size = new System.Drawing.Size(144, 23);
            this.lblsubtitle.TabIndex = 4;
            this.lblsubtitle.Text = "RECEIPT LIST";
            // 
            // pnlview
            // 
            this.pnlview.Controls.Add(this.tableview);
            this.pnlview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlview.Enabled = false;
            this.pnlview.Location = new System.Drawing.Point(0, 0);
            this.pnlview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pnlview.Name = "pnlview";
            this.pnlview.Size = new System.Drawing.Size(1370, 697);
            this.pnlview.TabIndex = 12;
            // 
            // frmCommissionReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1370, 697);
            this.Controls.Add(this.tablemain);
            this.Controls.Add(this.pnlview);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "frmCommissionReceipt";
            this.ShowInTaskbar = false;
            this.Tag = "TRANSACTION";
            this.Text = "RECEIPT";
            this.Load += new System.EventHandler(this.frmAmType_Load);
            this.tablemain.ResumeLayout(false);
            this.tablemain.PerformLayout();
            this.tableentry.ResumeLayout(false);
            this.tableentry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            this.tablecmd.ResumeLayout(false);
            this.pnlentry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            this.tableview.ResumeLayout(false);
            this.tableview.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspcommissionreceiptSelectResultBindingSource)).EndInit();
            this.pnlview.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
