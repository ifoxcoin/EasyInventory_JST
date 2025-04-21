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
	public class frmPackingReceipt : Form
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

		public frmPackingReceipt()
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
				cboCity.SelectedIndex = 1;
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
				uspcommissionreceiptSelectResultBindingSource.DataSource = inventoryDataContext.usp_packingreceiptSelect(null, null, null, null);
				cbocustomer.SelectedIndex = -1;
				long? no = 0L;
				inventoryDataContext.usp_getYearNo("pkrec_no", global.sysdate, ref no);
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
				packingreceipt packingreceipt = new packingreceipt();
				packingreceipt.led_agid = Convert.ToInt32(cbocustomer.SelectedValue);
				if (packingreceipt.led_agid == 0)
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
						packingreceipt.pr_date = dtprecdate.Value;
						num = id;
						if (num.GetValueOrDefault() == 0 && num.HasValue)
						{
							packingreceipt.pr_date = dtprecdate.Value;
							packingreceipt.com_id = 1L;
							long? no = 0L;
							inventoryDataContext.usp_setYearNo("pkrec_no", global.sysdate, ref no);
							foreach (DataGridViewRow item in (IEnumerable)dgvReceipt.Rows)
							{
								if (Convert.ToDecimal(item.Cells["cReceived"].Value) > 0m)
								{
									txtrecno.Text = Convert.ToString(no);
									if (!item.IsNewRow)
									{
										packingreceipt.pr_billamt = Convert.ToDecimal(item.Cells["cBillAmt"].Value);
										packingreceipt.sm_id = Convert.ToInt32(item.Cells["cSMId"].Value);
										packingreceipt.pr_newbalance = Convert.ToDecimal(item.Cells["cNewBalance"].Value);
										packingreceipt.pr_receivedamt = Convert.ToDecimal(item.Cells["cReceived"].Value);
										packingreceipt.pr_no = Convert.ToInt32(no);
										if (packingreceipt.pr_newbalance <= 0m)
										{
											packingreceipt.pr_isclose = true;
										}
										else
										{
											packingreceipt.pr_isclose = false;
										}
										inventoryDataContext.usp_packingreceiptInsert(packingreceipt.pr_no, packingreceipt.pr_date, packingreceipt.led_agid, packingreceipt.sm_id, packingreceipt.com_id, packingreceipt.pr_billamt, packingreceipt.pr_receivedamt, packingreceipt.pr_newbalance, packingreceipt.pr_isclose);
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
				uspcommissionreceiptSelectResultBindingSource.DataSource = inventoryDataContext.usp_packingreceiptSelect(null, Convert.ToInt32(cboCustomerView.SelectedValue), dtpfdate.Value, dtptdate.Value);
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
					decimal value = Convert.ToDecimal(dglist["recreceivedamtDataGridViewTextBoxColumn", e.RowIndex].Value);
					InventoryDataContext inventoryDataContext = new InventoryDataContext();
					if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						inventoryDataContext.usp_packingreceiptDelete(num, num2, value);
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
					join ag in inventoryDataContext.ledgermasters on le.led_agid equals ag.led_id
					where le.led_agid == (long?)(long)Convert.ToInt32(cbocustomer.SelectedValue) && list.sm_ispackingclose == (bool?)false
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
						dgvReceipt.Rows[num].Cells["cBillAmt"].Value = item2.sm_packingcharge;
						num2 += item2.sm_packingcharge - item2.sm_paidpacking;
						dgvReceipt.Rows[num].Cells["cReceived"].Value = 0;
						dgvReceipt.Rows[num].Cells["cExistReceived"].Value = item2.sm_paidpacking;
						dgvReceipt.Rows[num].Cells["cNewBalance"].Value = item2.sm_packingcharge - item2.sm_paidpacking;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(standard.trans.frmPackingReceipt));
			tablemain = new System.Windows.Forms.TableLayoutPanel();
			lbltitle = new System.Windows.Forms.Label();
			tableentry = new System.Windows.Forms.TableLayoutPanel();
			lblopno = new System.Windows.Forms.Label();
			txtrecno = new System.Windows.Forms.TextBox();
			lbldate = new System.Windows.Forms.Label();
			dtprecdate = new System.Windows.Forms.DateTimePicker();
			label2 = new System.Windows.Forms.Label();
			cboCity = new System.Windows.Forms.ComboBox();
			ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(components);
			lblAddress = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			txtOutstanding = new mylib.decimalbox(components);
			txtPaidamt = new mylib.decimalbox(components);
			txtNewBalance = new mylib.decimalbox(components);
			lblfrom = new System.Windows.Forms.Label();
			cbocustomer = new System.Windows.Forms.ComboBox();
			ledgermasterBindingSource = new System.Windows.Forms.BindingSource(components);
			tablecmd = new System.Windows.Forms.TableLayoutPanel();
			cmdsave = new mylib.lightbutton();
			cmdrefresh = new mylib.lightbutton();
			cmdclose = new mylib.lightbutton();
			cmdview = new mylib.lightbutton();
			pnlentry = new System.Windows.Forms.Panel();
			dgvReceipt = new mylib.mygrid();
			osno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBilldate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cBillAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cExistReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cNewBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cDayscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cSMId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			tableview = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			cboCityView = new System.Windows.Forms.ComboBox();
			ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(components);
			label5 = new System.Windows.Forms.Label();
			dtptdate = new System.Windows.Forms.DateTimePicker();
			lblhyp = new System.Windows.Forms.Label();
			dtpfdate = new System.Windows.Forms.DateTimePicker();
			lblfdate = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			cboCustomerView = new System.Windows.Forms.ComboBox();
			ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(components);
			cmdList = new mylib.lightbutton();
			cmdexit = new mylib.lightbutton();
			dglist = new mylib.mygrid();
			ldelete = new System.Windows.Forms.DataGridViewImageColumn();
			ledit = new System.Windows.Forms.DataGridViewImageColumn();
			lprint = new System.Windows.Forms.DataGridViewImageColumn();
			cr_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cr_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ledaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cr_billamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cr_receivedamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cr_newbalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			smidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			uspcommissionreceiptSelectResultBindingSource = new System.Windows.Forms.BindingSource(components);
			lblsubtitle = new System.Windows.Forms.Label();
			pnlview = new System.Windows.Forms.Panel();
			lblAddress1 = new System.Windows.Forms.Label();
			tablemain.SuspendLayout();
			tableentry.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ledgermasterCityBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)ledgermasterBindingSource).BeginInit();
			tablecmd.SuspendLayout();
			pnlentry.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvReceipt).BeginInit();
			tableview.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ledgermasteCityViewrBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)ledgermasterViewBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)dglist).BeginInit();
			((System.ComponentModel.ISupportInitialize)uspcommissionreceiptSelectResultBindingSource).BeginInit();
			pnlview.SuspendLayout();
			SuspendLayout();
			tablemain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			tablemain.ColumnCount = 1;
			tablemain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tablemain.Controls.Add(lbltitle, 0, 0);
			tablemain.Controls.Add(tableentry, 0, 1);
			tablemain.Controls.Add(tablecmd, 0, 3);
			tablemain.Controls.Add(pnlentry, 0, 2);
			tablemain.Dock = System.Windows.Forms.DockStyle.Fill;
			tablemain.Location = new System.Drawing.Point(0, 0);
			tablemain.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			tablemain.Name = "tablemain";
			tablemain.RowCount = 4;
			tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125f));
			tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71f));
			tablemain.Size = new System.Drawing.Size(1370, 697);
			tablemain.TabIndex = 0;
			lbltitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			lbltitle.AutoSize = true;
			lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(590, 8);
			lbltitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(189, 23);
			lbltitle.TabIndex = 3;
			lbltitle.Text = "PACKING RECEIPT";
			tableentry.ColumnCount = 8;
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 357f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 398f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72f));
			tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableentry.Controls.Add(lblopno, 0, 0);
			tableentry.Controls.Add(txtrecno, 1, 0);
			tableentry.Controls.Add(lbldate, 0, 1);
			tableentry.Controls.Add(dtprecdate, 1, 1);
			tableentry.Controls.Add(label2, 2, 0);
			tableentry.Controls.Add(cboCity, 3, 0);
			tableentry.Controls.Add(label1, 0, 2);
			tableentry.Controls.Add(label3, 2, 2);
			tableentry.Controls.Add(label4, 4, 2);
			tableentry.Controls.Add(txtOutstanding, 1, 2);
			tableentry.Controls.Add(txtPaidamt, 3, 2);
			tableentry.Controls.Add(txtNewBalance, 5, 2);
			tableentry.Controls.Add(lblfrom, 2, 1);
			tableentry.Controls.Add(cbocustomer, 3, 1);
			tableentry.Controls.Add(lblAddress, 4, 0);
			tableentry.Controls.Add(lblAddress1, 4, 1);
			tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
			tableentry.Location = new System.Drawing.Point(7, 46);
			tableentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			tableentry.Name = "tableentry";
			tableentry.RowCount = 4;
			tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35f));
			tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableentry.Size = new System.Drawing.Size(1356, 111);
			tableentry.TabIndex = 0;
			lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblopno.AutoSize = true;
			lblopno.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblopno.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblopno.Location = new System.Drawing.Point(5, 6);
			lblopno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblopno.Name = "lblopno";
			lblopno.Size = new System.Drawing.Size(115, 23);
			lblopno.TabIndex = 1;
			lblopno.Text = "Receipt No";
			txtrecno.Anchor = System.Windows.Forms.AnchorStyles.Left;
			txtrecno.BackColor = System.Drawing.Color.White;
			txtrecno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtrecno.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			txtrecno.Location = new System.Drawing.Point(144, 7);
			txtrecno.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			txtrecno.MaxLength = 20;
			txtrecno.Name = "txtrecno";
			txtrecno.Size = new System.Drawing.Size(203, 30);
			txtrecno.TabIndex = 0;
			txtrecno.TabStop = false;
			lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lbldate.AutoSize = true;
			lbldate.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lbldate.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbldate.Location = new System.Drawing.Point(5, 41);
			lbldate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lbldate.Name = "lbldate";
			lbldate.Size = new System.Drawing.Size(95, 23);
			lbldate.TabIndex = 2;
			lbldate.Text = "Rec Date";
			dtprecdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			dtprecdate.CustomFormat = "dd-MM-yyyy";
			dtprecdate.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dtprecdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtprecdate.Location = new System.Drawing.Point(144, 42);
			dtprecdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			dtprecdate.Name = "dtprecdate";
			dtprecdate.Size = new System.Drawing.Size(201, 30);
			dtprecdate.TabIndex = 0;
			dtprecdate.KeyDown += new System.Windows.Forms.KeyEventHandler(dtpdate_KeyDown);
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			label2.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label2.Location = new System.Drawing.Point(357, 6);
			label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(48, 23);
			label2.TabIndex = 10;
			label2.Text = "City";
			cboCity.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cboCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			cboCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			cboCity.DataSource = ledgermasterCityBindingSource;
			cboCity.DisplayMember = "led_address2";
			cboCity.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cboCity.FormattingEnabled = true;
			cboCity.Location = new System.Drawing.Point(501, 7);
			cboCity.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cboCity.Name = "cboCity";
			cboCity.Size = new System.Drawing.Size(347, 31);
			cboCity.TabIndex = 4;
			cboCity.ValueMember = "led_id";
			cboCity.SelectedValueChanged += new System.EventHandler(cboCity_SelectedValueChanged);
			cboCity.KeyDown += new System.Windows.Forms.KeyEventHandler(cboCity_KeyDown);
			ledgermasterCityBindingSource.DataSource = typeof(standard.classes.ledgermaster);
			lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblAddress.AutoSize = true;
			tableentry.SetColumnSpan(lblAddress, 4);
			lblAddress.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblAddress.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
			lblAddress.Location = new System.Drawing.Point(858, 6);
			lblAddress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblAddress.Name = "lblAddress";
			lblAddress.Size = new System.Drawing.Size(16, 23);
			lblAddress.TabIndex = 10;
			lblAddress.Text = ".";
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			label1.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label1.Location = new System.Drawing.Point(5, 76);
			label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(128, 23);
			label1.TabIndex = 10;
			label1.Text = "Outstanding";
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			label3.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label3.Location = new System.Drawing.Point(357, 76);
			label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(132, 23);
			label3.TabIndex = 10;
			label3.Text = "Paid Amount";
			label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			label4.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label4.Location = new System.Drawing.Point(858, 76);
			label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(133, 23);
			label4.TabIndex = 10;
			label4.Text = "New Balance";
			txtOutstanding.AllowFormat = false;
			txtOutstanding.Anchor = System.Windows.Forms.AnchorStyles.Left;
			txtOutstanding.BackColor = System.Drawing.Color.White;
			txtOutstanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtOutstanding.DecimalPlaces = 1;
			txtOutstanding.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			txtOutstanding.Location = new System.Drawing.Point(144, 77);
			txtOutstanding.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			txtOutstanding.MaxLength = 10;
			txtOutstanding.Name = "txtOutstanding";
			txtOutstanding.RightAlign = true;
			txtOutstanding.Size = new System.Drawing.Size(203, 30);
			txtOutstanding.TabIndex = 11;
			txtOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			mylib.decimalbox decimalbox = txtOutstanding;
			int[] bits = new int[4];
			decimalbox.Value = new decimal(bits);
			txtPaidamt.AllowFormat = false;
			txtPaidamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			txtPaidamt.BackColor = System.Drawing.Color.White;
			txtPaidamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtPaidamt.DecimalPlaces = 2;
			txtPaidamt.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			txtPaidamt.Location = new System.Drawing.Point(501, 77);
			txtPaidamt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			txtPaidamt.MaxLength = 10;
			txtPaidamt.Name = "txtPaidamt";
			txtPaidamt.RightAlign = true;
			txtPaidamt.Size = new System.Drawing.Size(347, 30);
			txtPaidamt.TabIndex = 11;
			txtPaidamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			mylib.decimalbox decimalbox2 = txtPaidamt;
			bits = new int[4];
			decimalbox2.Value = new decimal(bits);
			txtPaidamt.TextChanged += new System.EventHandler(txtPaidamt_TextChanged);
			txtPaidamt.KeyDown += new System.Windows.Forms.KeyEventHandler(txtPaidamt_KeyDown_1);
			txtNewBalance.AllowFormat = false;
			txtNewBalance.Anchor = System.Windows.Forms.AnchorStyles.Left;
			txtNewBalance.BackColor = System.Drawing.Color.Magenta;
			txtNewBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtNewBalance.DecimalPlaces = 1;
			txtNewBalance.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			txtNewBalance.ForeColor = System.Drawing.SystemColors.Info;
			txtNewBalance.Location = new System.Drawing.Point(1001, 77);
			txtNewBalance.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			txtNewBalance.MaxLength = 10;
			txtNewBalance.Name = "txtNewBalance";
			txtNewBalance.RightAlign = true;
			txtNewBalance.Size = new System.Drawing.Size(191, 30);
			txtNewBalance.TabIndex = 11;
			txtNewBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			mylib.decimalbox decimalbox3 = txtNewBalance;
			bits = new int[4];
			decimalbox3.Value = new decimal(bits);
			lblfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblfrom.AutoSize = true;
			lblfrom.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblfrom.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblfrom.Location = new System.Drawing.Point(357, 41);
			lblfrom.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblfrom.Name = "lblfrom";
			lblfrom.Size = new System.Drawing.Size(102, 23);
			lblfrom.TabIndex = 10;
			lblfrom.Text = "Customer";
			cbocustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cbocustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			cbocustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			cbocustomer.DataSource = ledgermasterBindingSource;
			cbocustomer.DisplayMember = "led_name";
			cbocustomer.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cbocustomer.FormattingEnabled = true;
			cbocustomer.Location = new System.Drawing.Point(501, 42);
			cbocustomer.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cbocustomer.Name = "cbocustomer";
			cbocustomer.Size = new System.Drawing.Size(347, 31);
			cbocustomer.TabIndex = 4;
			cbocustomer.ValueMember = "led_id";
			cbocustomer.SelectedValueChanged += new System.EventHandler(cbopurfrom_SelectedValueChanged);
			cbocustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(cbopurfrom_KeyDown);
			cbocustomer.Leave += new System.EventHandler(cbocustomer_Leave);
			ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
			tablecmd.ColumnCount = 5;
			tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159f));
			tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159f));
			tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159f));
			tablecmd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159f));
			tablecmd.Controls.Add(cmdsave, 1, 0);
			tablecmd.Controls.Add(cmdrefresh, 2, 0);
			tablecmd.Controls.Add(cmdclose, 4, 0);
			tablecmd.Controls.Add(cmdview, 3, 0);
			tablecmd.Dock = System.Windows.Forms.DockStyle.Fill;
			tablecmd.Location = new System.Drawing.Point(7, 631);
			tablecmd.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			tablecmd.Name = "tablecmd";
			tablecmd.RowCount = 1;
			tablecmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tablecmd.Size = new System.Drawing.Size(1356, 57);
			tablecmd.TabIndex = 3;
			cmdsave.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmdsave.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cmdsave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdsave.Location = new System.Drawing.Point(725, 7);
			cmdsave.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cmdsave.Name = "cmdsave";
			cmdsave.Size = new System.Drawing.Size(149, 43);
			cmdsave.TabIndex = 0;
			cmdsave.Text = "&Save";
			cmdsave.UseVisualStyleBackColor = true;
			cmdsave.Click += new System.EventHandler(cmdsave_Click);
			cmdrefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmdrefresh.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cmdrefresh.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdrefresh.Location = new System.Drawing.Point(884, 7);
			cmdrefresh.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cmdrefresh.Name = "cmdrefresh";
			cmdrefresh.Size = new System.Drawing.Size(149, 43);
			cmdrefresh.TabIndex = 1;
			cmdrefresh.Text = "&Refresh";
			cmdrefresh.UseVisualStyleBackColor = true;
			cmdrefresh.Click += new System.EventHandler(cmdrefresh_Click);
			cmdclose.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmdclose.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cmdclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclose.Location = new System.Drawing.Point(1202, 7);
			cmdclose.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cmdclose.Name = "cmdclose";
			cmdclose.Size = new System.Drawing.Size(149, 43);
			cmdclose.TabIndex = 3;
			cmdclose.Text = "&Close";
			cmdclose.UseVisualStyleBackColor = true;
			cmdclose.Click += new System.EventHandler(cmdclose_Click);
			cmdview.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cmdview.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cmdview.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdview.Location = new System.Drawing.Point(1043, 7);
			cmdview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cmdview.Name = "cmdview";
			cmdview.Size = new System.Drawing.Size(149, 43);
			cmdview.TabIndex = 2;
			cmdview.Text = "&View";
			cmdview.UseVisualStyleBackColor = true;
			cmdview.Click += new System.EventHandler(cmdview_Click);
			pnlentry.Controls.Add(dgvReceipt);
			pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlentry.Location = new System.Drawing.Point(7, 173);
			pnlentry.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			pnlentry.Name = "pnlentry";
			pnlentry.Size = new System.Drawing.Size(1356, 442);
			pnlentry.TabIndex = 1;
			dgvReceipt.AllowUserToDeleteRows = false;
			dgvReceipt.AllowUserToResizeRows = false;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dgvReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dgvReceipt.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgvReceipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvReceipt.Columns.AddRange(osno, cBillNo, cBilldate, cBillAmt, cReceived, cExistReceived, cNewBalance, cDayscount, cSMId);
			dgvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
			dgvReceipt.Location = new System.Drawing.Point(0, 0);
			dgvReceipt.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			dgvReceipt.MultiSelect = false;
			dgvReceipt.Name = "dgvReceipt";
			dgvReceipt.ReadOnly = true;
			dgvReceipt.RowHeadersVisible = false;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dgvReceipt.RowsDefaultCellStyle = dataGridViewCellStyle3;
			dgvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dgvReceipt.ShowCellToolTips = false;
			dgvReceipt.Size = new System.Drawing.Size(1356, 442);
			dgvReceipt.TabIndex = 0;
			dgvReceipt.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(dgopen_CellEndEdit);
			dgvReceipt.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(dgvPurchase_EditingControlShowing);
			dgvReceipt.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dgopen_RowsAdded);
			dgvReceipt.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(dgopen_RowsRemoved);
			dgvReceipt.KeyDown += new System.Windows.Forms.KeyEventHandler(dgopen_KeyDown);
			osno.HeaderText = "SNO";
			osno.Name = "osno";
			osno.ReadOnly = true;
			osno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			osno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			osno.Width = 45;
			cBillNo.HeaderText = "BILL NO";
			cBillNo.Name = "cBillNo";
			cBillNo.ReadOnly = true;
			cBillNo.Width = 150;
			cBilldate.HeaderText = "BILL DATE";
			cBilldate.Name = "cBilldate";
			cBilldate.ReadOnly = true;
			cBilldate.Width = 150;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle4.Format = "N2";
			cBillAmt.DefaultCellStyle = dataGridViewCellStyle4;
			cBillAmt.HeaderText = "BILL AMOUNT";
			cBillAmt.Name = "cBillAmt";
			cBillAmt.ReadOnly = true;
			cBillAmt.Width = 150;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle5.Format = "N2";
			cReceived.DefaultCellStyle = dataGridViewCellStyle5;
			cReceived.HeaderText = "RECEIVED";
			cReceived.MaxInputLength = 10;
			cReceived.Name = "cReceived";
			cReceived.ReadOnly = true;
			cReceived.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			cReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cReceived.Width = 150;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle6.Format = "N2";
			cExistReceived.DefaultCellStyle = dataGridViewCellStyle6;
			cExistReceived.HeaderText = "ALREADY RECEIVED";
			cExistReceived.Name = "cExistReceived";
			cExistReceived.ReadOnly = true;
			cExistReceived.Width = 150;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle7.Format = "N2";
			cNewBalance.DefaultCellStyle = dataGridViewCellStyle7;
			cNewBalance.HeaderText = "NEW BALANCE";
			cNewBalance.Name = "cNewBalance";
			cNewBalance.ReadOnly = true;
			cNewBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			cNewBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			cNewBalance.Width = 150;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			cDayscount.DefaultCellStyle = dataGridViewCellStyle8;
			cDayscount.HeaderText = "DAYS COUNT";
			cDayscount.Name = "cDayscount";
			cDayscount.ReadOnly = true;
			cDayscount.Width = 150;
			cSMId.HeaderText = "SMID";
			cSMId.Name = "cSMId";
			cSMId.ReadOnly = true;
			cSMId.Visible = false;
			tableview.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			tableview.ColumnCount = 1;
			tableview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableview.Controls.Add(tableLayoutPanel1, 0, 1);
			tableview.Controls.Add(dglist, 0, 2);
			tableview.Controls.Add(lblsubtitle, 0, 0);
			tableview.Dock = System.Windows.Forms.DockStyle.Fill;
			tableview.Location = new System.Drawing.Point(0, 0);
			tableview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			tableview.Name = "tableview";
			tableview.RowCount = 4;
			tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40f));
			tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100f));
			tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53f));
			tableview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			tableview.Size = new System.Drawing.Size(1370, 697);
			tableview.TabIndex = 0;
			tableLayoutPanel1.ColumnCount = 11;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 345f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154f));
			tableLayoutPanel1.Controls.Add(cboCityView, 5, 0);
			tableLayoutPanel1.Controls.Add(label5, 4, 0);
			tableLayoutPanel1.Controls.Add(dtptdate, 3, 0);
			tableLayoutPanel1.Controls.Add(lblhyp, 2, 0);
			tableLayoutPanel1.Controls.Add(dtpfdate, 1, 0);
			tableLayoutPanel1.Controls.Add(lblfdate, 0, 0);
			tableLayoutPanel1.Controls.Add(label6, 0, 1);
			tableLayoutPanel1.Controls.Add(cboCustomerView, 1, 1);
			tableLayoutPanel1.Controls.Add(cmdList, 5, 1);
			tableLayoutPanel1.Controls.Add(cmdexit, 6, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(7, 51);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel1.Size = new System.Drawing.Size(1356, 86);
			tableLayoutPanel1.TabIndex = 5;
			cboCityView.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cboCityView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			cboCityView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			cboCityView.DataSource = ledgermasteCityViewrBindingSource;
			cboCityView.DisplayMember = "led_address2";
			cboCityView.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cboCityView.FormattingEnabled = true;
			cboCityView.Location = new System.Drawing.Point(554, 7);
			cboCityView.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cboCityView.Name = "cboCityView";
			cboCityView.Size = new System.Drawing.Size(335, 31);
			cboCityView.TabIndex = 27;
			cboCityView.ValueMember = "led_id";
			cboCityView.SelectedValueChanged += new System.EventHandler(cboCityView_SelectedValueChanged);
			ledgermasteCityViewrBindingSource.DataSource = typeof(standard.classes.ledgermaster);
			label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			label5.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label5.Location = new System.Drawing.Point(489, 10);
			label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(48, 23);
			label5.TabIndex = 26;
			label5.Text = "City";
			dtptdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			dtptdate.CustomFormat = "dd-MM-yyyy";
			dtptdate.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dtptdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtptdate.Location = new System.Drawing.Point(328, 7);
			dtptdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			dtptdate.Name = "dtptdate";
			dtptdate.Size = new System.Drawing.Size(151, 30);
			dtptdate.TabIndex = 1;
			dtptdate.ValueChanged += new System.EventHandler(dtptdate_ValueChanged);
			dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(dtptdate_KeyDown);
			lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
			lblhyp.AutoSize = true;
			lblhyp.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblhyp.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblhyp.Location = new System.Drawing.Point(295, 10);
			lblhyp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblhyp.Name = "lblhyp";
			lblhyp.Size = new System.Drawing.Size(18, 23);
			lblhyp.TabIndex = 1;
			lblhyp.Text = "-";
			dtpfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			dtpfdate.CalendarFont = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dtpfdate.CustomFormat = "dd-MM-yyyy";
			dtpfdate.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dtpfdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtpfdate.Location = new System.Drawing.Point(121, 7);
			dtpfdate.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			dtpfdate.Name = "dtpfdate";
			dtpfdate.Size = new System.Drawing.Size(159, 30);
			dtpfdate.TabIndex = 0;
			dtpfdate.ValueChanged += new System.EventHandler(dtpfdate_ValueChanged);
			dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(dtpfdate_KeyDown);
			lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblfdate.AutoSize = true;
			lblfdate.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblfdate.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblfdate.Location = new System.Drawing.Point(5, 10);
			lblfdate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblfdate.Name = "lblfdate";
			lblfdate.Size = new System.Drawing.Size(54, 23);
			lblfdate.TabIndex = 23;
			lblfdate.Text = "Date";
			label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			label6.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			label6.Location = new System.Drawing.Point(5, 53);
			label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(102, 23);
			label6.TabIndex = 28;
			label6.Text = "Customer";
			cboCustomerView.Anchor = System.Windows.Forms.AnchorStyles.Left;
			cboCustomerView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			cboCustomerView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			tableLayoutPanel1.SetColumnSpan(cboCustomerView, 3);
			cboCustomerView.DataSource = ledgermasterViewBindingSource;
			cboCustomerView.DisplayMember = "led_name";
			cboCustomerView.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cboCustomerView.FormattingEnabled = true;
			cboCustomerView.Location = new System.Drawing.Point(121, 50);
			cboCustomerView.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			cboCustomerView.Name = "cboCustomerView";
			cboCustomerView.Size = new System.Drawing.Size(358, 31);
			cboCustomerView.TabIndex = 29;
			cboCustomerView.ValueMember = "led_id";
			cboCustomerView.KeyDown += new System.Windows.Forms.KeyEventHandler(cboCustomerView_KeyDown);
			ledgermasterViewBindingSource.DataSource = typeof(standard.classes.ledgermaster);
			cmdList.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			cmdList.BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			cmdList.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cmdList.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdList.Location = new System.Drawing.Point(742, 45);
			cmdList.Margin = new System.Windows.Forms.Padding(2);
			cmdList.Name = "cmdList";
			cmdList.Size = new System.Drawing.Size(150, 39);
			cmdList.TabIndex = 2;
			cmdList.Text = "&View";
			cmdList.UseVisualStyleBackColor = false;
			cmdList.Click += new System.EventHandler(cmdview_Click);
			cmdexit.BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cmdexit.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			cmdexit.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdexit.Location = new System.Drawing.Point(896, 45);
			cmdexit.Margin = new System.Windows.Forms.Padding(2);
			cmdexit.Name = "cmdexit";
			cmdexit.Size = new System.Drawing.Size(150, 39);
			cmdexit.TabIndex = 3;
			cmdexit.Text = "&Exit";
			cmdexit.UseVisualStyleBackColor = false;
			cmdexit.Click += new System.EventHandler(cmdexit_Click);
			dglist.AllowUserToAddRows = false;
			dglist.AllowUserToDeleteRows = false;
			dglist.AllowUserToResizeRows = false;
			dglist.AutoGenerateColumns = false;
			dglist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			dglist.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dglist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
			dglist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dglist.Columns.AddRange(ldelete, ledit, lprint, cr_no, cr_date, lednameDataGridViewTextBoxColumn, ledaddress2DataGridViewTextBoxColumn, cr_billamt, cr_receivedamt, cr_newbalance, smidDataGridViewTextBoxColumn, comidDataGridViewTextBoxColumn, idDataGridViewTextBoxColumn);
			dglist.DataSource = uspcommissionreceiptSelectResultBindingSource;
			dglist.Dock = System.Windows.Forms.DockStyle.Fill;
			dglist.Location = new System.Drawing.Point(7, 153);
			dglist.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			dglist.MultiSelect = false;
			dglist.Name = "dglist";
			dglist.ReadOnly = true;
			dglist.RowHeadersVisible = false;
			dglist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dglist.ShowCellToolTips = false;
			dglist.Size = new System.Drawing.Size(1356, 480);
			dglist.TabIndex = 1;
			dglist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dglist_CellContentClick);
			dglist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dglist_CellDoubleClick);
			dglist.KeyDown += new System.Windows.Forms.KeyEventHandler(dgList_KeyDown);
			ldelete.HeaderText = "DELETE";
			ldelete.Image = standard.Properties.Resources.delete;
			ldelete.Name = "ldelete";
			ldelete.ReadOnly = true;
			ldelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			ledit.HeaderText = "EDIT";
			ledit.Name = "ledit";
			ledit.ReadOnly = true;
			ledit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			ledit.Visible = false;
			ledit.Width = 45;
			lprint.HeaderText = "PRINT";
			lprint.Name = "lprint";
			lprint.ReadOnly = true;
			lprint.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			lprint.Visible = false;
			lprint.Width = 45;
			cr_no.DataPropertyName = "cr_no";
			cr_no.HeaderText = "No";
			cr_no.Name = "cr_no";
			cr_no.ReadOnly = true;
			cr_date.DataPropertyName = "cr_date";
			cr_date.HeaderText = "Date";
			cr_date.Name = "cr_date";
			cr_date.ReadOnly = true;
			cr_date.Width = 125;
			lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
			lednameDataGridViewTextBoxColumn.HeaderText = "Customer";
			lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
			lednameDataGridViewTextBoxColumn.ReadOnly = true;
			lednameDataGridViewTextBoxColumn.Width = 250;
			ledaddress2DataGridViewTextBoxColumn.DataPropertyName = "led_address2";
			ledaddress2DataGridViewTextBoxColumn.HeaderText = "City";
			ledaddress2DataGridViewTextBoxColumn.Name = "ledaddress2DataGridViewTextBoxColumn";
			ledaddress2DataGridViewTextBoxColumn.ReadOnly = true;
			ledaddress2DataGridViewTextBoxColumn.Width = 200;
			cr_billamt.DataPropertyName = "cr_billamt";
			cr_billamt.HeaderText = "Bill Amt";
			cr_billamt.Name = "cr_billamt";
			cr_billamt.ReadOnly = true;
			cr_billamt.Width = 125;
			cr_receivedamt.DataPropertyName = "cr_receivedamt";
			cr_receivedamt.HeaderText = "Paid";
			cr_receivedamt.Name = "cr_receivedamt";
			cr_receivedamt.ReadOnly = true;
			cr_receivedamt.Width = 125;
			cr_newbalance.DataPropertyName = "cr_newbalance";
			cr_newbalance.HeaderText = "Balance";
			cr_newbalance.Name = "cr_newbalance";
			cr_newbalance.ReadOnly = true;
			cr_newbalance.Width = 125;
			smidDataGridViewTextBoxColumn.DataPropertyName = "sm_id";
			smidDataGridViewTextBoxColumn.HeaderText = "sm_id";
			smidDataGridViewTextBoxColumn.Name = "smidDataGridViewTextBoxColumn";
			smidDataGridViewTextBoxColumn.ReadOnly = true;
			smidDataGridViewTextBoxColumn.Visible = false;
			comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
			comidDataGridViewTextBoxColumn.HeaderText = "com_id";
			comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
			comidDataGridViewTextBoxColumn.ReadOnly = true;
			comidDataGridViewTextBoxColumn.Visible = false;
			idDataGridViewTextBoxColumn.DataPropertyName = "id";
			idDataGridViewTextBoxColumn.HeaderText = "id";
			idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			idDataGridViewTextBoxColumn.ReadOnly = true;
			idDataGridViewTextBoxColumn.Visible = false;
			uspcommissionreceiptSelectResultBindingSource.DataSource = typeof(standard.classes.usp_commissionreceiptSelectResult);
			lblsubtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			lblsubtitle.AutoSize = true;
			lblsubtitle.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblsubtitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblsubtitle.Location = new System.Drawing.Point(613, 10);
			lblsubtitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblsubtitle.Name = "lblsubtitle";
			lblsubtitle.Size = new System.Drawing.Size(144, 23);
			lblsubtitle.TabIndex = 4;
			lblsubtitle.Text = "RECEIPT LIST";
			pnlview.Controls.Add(tableview);
			pnlview.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlview.Enabled = false;
			pnlview.Location = new System.Drawing.Point(0, 0);
			pnlview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			pnlview.Name = "pnlview";
			pnlview.Size = new System.Drawing.Size(1370, 697);
			pnlview.TabIndex = 12;
			lblAddress1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lblAddress1.AutoSize = true;
			lblAddress1.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			lblAddress1.ForeColor = System.Drawing.Color.FromArgb(0, 192, 0);
			lblAddress1.Location = new System.Drawing.Point(858, 41);
			lblAddress1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			lblAddress1.Name = "lblAddress1";
			lblAddress1.Size = new System.Drawing.Size(16, 23);
			lblAddress1.TabIndex = 10;
			lblAddress1.Text = ".";
			base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 23f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(1370, 697);
			base.Controls.Add(tablemain);
			base.Controls.Add(pnlview);
			Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Bold);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			base.Name = "frmPackingReceipt";
			base.ShowInTaskbar = false;
			base.Tag = "TRANSACTION";
			Text = "PACKING RECEIPT";
			base.Load += new System.EventHandler(frmAmType_Load);
			tablemain.ResumeLayout(false);
			tablemain.PerformLayout();
			tableentry.ResumeLayout(false);
			tableentry.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ledgermasterCityBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)ledgermasterBindingSource).EndInit();
			tablecmd.ResumeLayout(false);
			pnlentry.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvReceipt).EndInit();
			tableview.ResumeLayout(false);
			tableview.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)ledgermasteCityViewrBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)ledgermasterViewBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)dglist).EndInit();
			((System.ComponentModel.ISupportInitialize)uspcommissionreceiptSelectResultBindingSource).EndInit();
			pnlview.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
