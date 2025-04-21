using Microsoft.Reporting.WinForms;
using mylib;
using standard.classes;
using standard.Properties;
using standard.report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
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

		private DataGridViewTextBoxColumn cSNo;

		private DataGridViewTextBoxColumn cCategory;

		private DataGridViewTextBoxColumn cItemName;

		private DataGridViewTextBoxColumn cQty;

		private DataGridViewTextBoxColumn cRate;

		private DataGridViewTextBoxColumn cAmount;

		private DataGridViewTextBoxColumn cCatID;

		private DataGridViewTextBoxColumn cItemID;

		private DataGridViewTextBoxColumn cMrp;

		private DateTimePicker dtptdate;

		private lightbutton cmdexit;

		private Label lblhyp;

		private DateTimePicker dtpfdate;

		private Label lblfdate;

		private Label label5;

		private ComboBox cboCityView;

		private Label label6;

		private lightbutton cmdList;

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

		private DataGridViewTextBoxColumn pmdescDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;

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
				dtppurdate.Select();
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
						where li.item_name == Convert.ToString(dgvPurchase["cItemName", r].Value)
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
						where li.item_name == Convert.ToString(dgvPurchase["cItemName", r].Value)
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
			dtppurdate.MinDate = global.fdate;
			dtppurdate.MaxDate = global.sysdate;
			dtppurdate.Value = global.sysdate;
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
					where a.led_accounttype == "SUPPLIER" || a.led_id == 0
					select new
					{
						a.led_id,
						a.led_name,
						a.led_address2
					} into x
					orderby x.led_address2
					select x;
				ledgermasterCityBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
				ledgermasteCityViewrBindingSource.DataSource = source.Select(x => x.led_address2).Distinct();
				usppurchasemasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_purchasemasterSelect(null, null, null, null, null, null);
				cbopurfrom.SelectedIndex = -1;
				List<usp_itemSelectResult> list = inventoryDataContext.usp_itemSelect(null, null, null,null).ToList();
				AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
				foreach (usp_itemSelectResult item in list)
				{
					autoCompleteStringCollection.Add(item.item_name);
				}
				long? no = 0L;
				inventoryDataContext.usp_getYearNo("pur_no", global.sysdate, ref no);
				txtpurno.Text = Convert.ToString(no);
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
			cbopurfrom.SelectedIndex = -1;
			cbopurfrom.Text = string.Empty;
			dgvPurchase.Rows.Clear();
			txttotqty.Value = 0m;
			txttotamt.Value = 0m;
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
							item = source.FirstOrDefault((item match) => match.item_name.ToUpper().Trim() == dr.Cells["cItemName"].Value.ToString().ToUpper().Trim());
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
							purchasemaster.pm_date = dtppurdate.Value;
							purchasemaster.pm_desc = "";
							purchasemaster.pm_id = 1L;
                            purchasemaster.pm_paid = 0;
							if (id == 0)
							{
								long? no = 0L;
								inventoryDataContext.usp_setYearNo("pur_no", global.sysdate, ref no);
								purchasemaster.pm_no = Convert.ToInt64(no);
								inventoryDataContext.usp_purchasemasterInsert(ref id, purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, global.comid, global.ucode, global.sysdate, purchasemaster.pm_desc, false, purchasemaster.pm_paid);
								foreach (DataGridViewRow item2 in (IEnumerable)dgvPurchase.Rows)
								{
									if (!item2.IsNewRow)
									{
										purchasedetail.pd_qty = Convert.ToDecimal(item2.Cells["cQty"].Value);
										purchasedetail.pd_prate = Convert.ToDecimal(item2.Cells["cRate"].Value);
										purchasedetail.cat_id = Convert.ToInt32(item2.Cells["cCatID"].Value);
										purchasedetail.item_id = Convert.ToInt32(item2.Cells["cItemId"].Value);
										purchasedetail.pd_amount = purchasedetail.pd_prate * purchasedetail.pd_qty;
										purchasedetail.item_id = Convert.ToInt32(item2.Cells["cItemId"].Value);
										purchasedetail.pd_particulars = item2.Cells["cItemName"].Value.ToString();
										inventoryDataContext.usp_purchasedetailsInsert(Convert.ToInt32(id), purchasedetail.item_id, purchasedetail.cat_id, purchasedetail.pd_particulars, purchasedetail.pd_qty, purchasedetail.pd_prate, purchasedetail.pd_amount);
										inventoryDataContext.usp_stockInsert(id, "PURCHASE", purchasedetail.item_id, global.comid, purchasedetail.pd_qty, 0m, global.sysdate);
									}
								}
							}
							else
							{
								purchasemaster.pm_no = Convert.ToInt64(txtpurno.Text);
								inventoryDataContext.usp_purchasemasterUpdate(Convert.ToInt64(id), purchasemaster.pm_no, purchasemaster.pm_date, purchasemaster.led_id, purchasemaster.pm_totqty, purchasemaster.pm_totamount, global.comid, global.ucode, global.sysdate, purchasemaster.pm_desc, false, purchasemaster.pm_paid);
								inventoryDataContext.usp_purchasedetailsDelete(Convert.ToInt32(id));
								inventoryDataContext.usp_stockDelete(Convert.ToInt32(id), "PURCHASE");
								foreach (DataGridViewRow item3 in (IEnumerable)dgvPurchase.Rows)
								{
									if (!item3.IsNewRow)
									{
										purchasedetail.pd_qty = Convert.ToDecimal(item3.Cells["cQty"].Value);
										purchasedetail.pd_prate = Convert.ToDecimal(item3.Cells["cRate"].Value);
										purchasedetail.cat_id = Convert.ToInt32(item3.Cells["cCatID"].Value);
										purchasedetail.pd_particulars = item3.Cells["cItemName"].Value.ToString();
										purchasedetail.item_id = Convert.ToInt32(item3.Cells["cItemId"].Value);
										purchasedetail.pd_amount = purchasedetail.pd_prate * purchasedetail.pd_qty;
										purchasedetail.item_id = Convert.ToInt32(item3.Cells["cItemId"].Value);
										purchasedetail.pd_particulars = "";
										inventoryDataContext.usp_purchasedetailsInsert(Convert.ToInt32(id), purchasedetail.item_id, purchasedetail.cat_id, purchasedetail.pd_particulars, purchasedetail.pd_qty, purchasedetail.pd_prate, purchasedetail.pd_amount);
										inventoryDataContext.usp_stockInsert(id, "PURCHASE", purchasedetail.item_id, global.comid, purchasedetail.pd_qty, 0m, global.sysdate);
									}
								}
							}
							loadReport(Convert.ToInt32(id));
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
			int r = dgvPurchase.CurrentCell.RowIndex;
			int columnIndex = dgvPurchase.CurrentCell.ColumnIndex;
			decimal result;
			decimal result2;
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
							acsItemName = new AutoCompleteStringCollection();
							InventoryDataContext inventoryDataContext2 = new InventoryDataContext();
							using (inventoryDataContext2)
							{
								IQueryable<item> queryable = from li in inventoryDataContext2.items
									join cat in inventoryDataContext2.categories on li.cat_id equals cat.cat_id
									where cat.cat_name == Convert.ToString(dgvPurchase["cCategory", r].Value)
									select li;
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
				catch
				{
				}
			}
			else if (columnIndex == cItemName.Index)
			{
				if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
				{
					dgvPurchase.Rows.RemoveAt(r);
				}
				InventoryDataContext inventoryDataContext2 = new InventoryDataContext();
				using (inventoryDataContext2)
				{
					var queryable2 = from li in inventoryDataContext2.items
						join cat in inventoryDataContext2.categories on li.cat_id equals cat.cat_id
						where li.item_name == Convert.ToString(dgvPurchase["cItemName", r].Value)
						select new
						{
							cat,
							li
						};
					foreach (var item2 in queryable2)
					{
						dgvPurchase["cRate", r].Value = item2.li.item_purchaserate;
						dgvPurchase["cItemCode", r].Value = item2.li.item_code;
						dgvPurchase["cItemId", r].Value = item2.li.item_id;
						dgvPurchase["cCategory", r].Value = item2.cat.cat_name;
						dgvPurchase["cCatID", r].Value = item2.cat.cat_id;
					}
				}
				dgvPurchase.CurrentCell = dgvPurchase.Rows[dgvPurchase.CurrentCellAddress.Y].Cells["cQty"];
				dgvPurchase.Focus();
			}
			else if (columnIndex == cQty.Index)
			{
				if (Convert.ToString(dgvPurchase["cItemName", r].Value) == string.Empty && !dgvPurchase.CurrentRow.IsNewRow)
				{
					dgvPurchase.Rows.RemoveAt(r);
				}
				decimal.TryParse(Convert.ToString(dgvPurchase["cQty", r].Value), out result);
				result = Math.Abs(result);
				dgvPurchase["cQty", r].Value = ((result > 0m) ? ((object)result) : null);
				decimal.TryParse(Convert.ToString(dgvPurchase["cRate", r].Value), out result2);
				dgvPurchase["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
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
				dgvPurchase["cAmount", r].Value = ((result2 > 0m && result > 0m) ? ((object)(result2 * result)) : null);
				calacTotal();
				SetColumnIndex method = Mymethod;
				dgvPurchase.BeginInvoke(method, "cCategory");
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
			List<decimal> totalSNo = bus.getTotalSNo(dgvPurchase, "cSNo", list);
			txttotqty.Value = Convert.ToDecimal(totalSNo[0]);
			txttotamt.Text = totalSNo[1].ToString("0.00");
			List<decimal> list2 = new List<decimal>();
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
				cboCity.Focus();
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
				dgvPurchase.CurrentCell = dgvPurchase["cCategory", 0];
				dgvPurchase.Focus();
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
			dtppurdate.Focus();
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
					usppurchasemasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_purchasemasterSelect(null, null, null, null, null, Convert.ToInt64(txtSearchBillNo.Text));
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
					cboCity.Text = current.led_address2.ToString();
					cbopurfrom.SelectedValue = current.led_id;
					dtppurdate.Value = Convert.ToDateTime(current.pm_date);
					cbopurfrom.SelectedValue = current.led_id;
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
			}
			dgvPurchase.AllowUserToAddRows = true;
			calacTotal();
			pnlview.Enabled = false;
			tablemain.Enabled = true;
			pnlview.SendToBack();
			tablemain.BringToFront();
			dtppurdate.Focus();
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

		private void cboCityView_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboCityView.SelectedItem != null)
			{
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				using (inventoryDataContext)
				{
					ledgermasterViewBindingSource.Clear();
					var source = from a in inventoryDataContext.ledgermasters
						where a.led_accounttype == "Supplier" && a.led_address2 == cboCityView.Text.ToString().Trim()
						select new
						{
							a.led_id,
							a.led_name
						};
					ledgermasterViewBindingSource.DataSource = source.OrderBy(x => x.led_name);
					cboSupplierView.DataSource = source.OrderBy(x => x.led_name);
				}
			}
		}

		private void label6_Click(object sender, EventArgs e)
		{
		}

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            this.tablemain = new System.Windows.Forms.TableLayoutPanel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tableentry = new System.Windows.Forms.TableLayoutPanel();
            this.lblopno = new System.Windows.Forms.Label();
            this.txtpurno = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.dtppurdate = new System.Windows.Forms.DateTimePicker();
            this.lblfrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.ledgermasterCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAddress = new System.Windows.Forms.Label();
            this.cbopurfrom = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablecmd = new System.Windows.Forms.TableLayoutPanel();
            this.cmdsave = new mylib.lightbutton();
            this.cmdrefresh = new mylib.lightbutton();
            this.cmdclose = new mylib.lightbutton();
            this.cmdview = new mylib.lightbutton();
            this.tablesum = new System.Windows.Forms.TableLayoutPanel();
            this.lbltotqty = new System.Windows.Forms.Label();
            this.txttotqty = new mylib.decimalbox(this.components);
            this.txttotamt = new mylib.decimalbox(this.components);
            this.lblnetamt = new System.Windows.Forms.Label();
            this.pnlentry = new System.Windows.Forms.Panel();
            this.dgvPurchase = new mylib.mygrid();
            this.cSNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboCityView = new System.Windows.Forms.ComboBox();
            this.ledgermasteCityViewrBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearchBillNo = new System.Windows.Forms.TextBox();
            this.cmdexit = new mylib.lightbutton();
            this.cboSupplierView = new System.Windows.Forms.ComboBox();
            this.cmdList = new mylib.lightbutton();
            this.ledgermasterViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlview = new System.Windows.Forms.Panel();
            this.tablemain.SuspendLayout();
            this.tableentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            this.tablecmd.SuspendLayout();
            this.tablesum.SuspendLayout();
            this.pnlentry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.tableview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usppurchasemasterSelectResultBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tablemain.Controls.Add(this.tablecmd, 0, 4);
            this.tablemain.Controls.Add(this.tablesum, 0, 3);
            this.tablemain.Controls.Add(this.pnlentry, 0, 2);
            this.tablemain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablemain.Location = new System.Drawing.Point(0, 0);
            this.tablemain.Margin = new System.Windows.Forms.Padding(6);
            this.tablemain.Name = "tablemain";
            this.tablemain.RowCount = 5;
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tablemain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tablemain.Size = new System.Drawing.Size(1315, 690);
            this.tablemain.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(8, 3);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(173, 35);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "PURCHASE";
            // 
            // tableentry
            // 
            this.tableentry.ColumnCount = 8;
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableentry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableentry.Controls.Add(this.lblopno, 0, 0);
            this.tableentry.Controls.Add(this.txtpurno, 1, 0);
            this.tableentry.Controls.Add(this.lbldate, 0, 1);
            this.tableentry.Controls.Add(this.dtppurdate, 1, 1);
            this.tableentry.Controls.Add(this.lblfrom, 4, 0);
            this.tableentry.Controls.Add(this.label2, 2, 0);
            this.tableentry.Controls.Add(this.cboCity, 3, 0);
            this.tableentry.Controls.Add(this.lblAddress, 4, 1);
            this.tableentry.Controls.Add(this.cbopurfrom, 5, 0);
            this.tableentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableentry.Location = new System.Drawing.Point(8, 47);
            this.tableentry.Margin = new System.Windows.Forms.Padding(6);
            this.tableentry.Name = "tableentry";
            this.tableentry.RowCount = 2;
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableentry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableentry.Size = new System.Drawing.Size(1299, 80);
            this.tableentry.TabIndex = 0;
            // 
            // lblopno
            // 
            this.lblopno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblopno.AutoSize = true;
            this.lblopno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblopno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblopno.Location = new System.Drawing.Point(6, 0);
            this.lblopno.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblopno.Name = "lblopno";
            this.lblopno.Size = new System.Drawing.Size(158, 40);
            this.lblopno.TabIndex = 1;
            this.lblopno.Text = "Purchase No";
            // 
            // txtpurno
            // 
            this.txtpurno.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtpurno.BackColor = System.Drawing.Color.White;
            this.txtpurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpurno.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtpurno.Location = new System.Drawing.Point(202, 6);
            this.txtpurno.Margin = new System.Windows.Forms.Padding(6);
            this.txtpurno.MaxLength = 20;
            this.txtpurno.Name = "txtpurno";
            this.txtpurno.ReadOnly = true;
            this.txtpurno.Size = new System.Drawing.Size(200, 42);
            this.txtpurno.TabIndex = 0;
            this.txtpurno.TabStop = false;
            // 
            // lbldate
            // 
            this.lbldate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldate.Location = new System.Drawing.Point(6, 42);
            this.lbldate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(143, 35);
            this.lbldate.TabIndex = 2;
            this.lbldate.Text = "Pur Date";
            // 
            // dtppurdate
            // 
            this.dtppurdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtppurdate.CustomFormat = "dd-MM-yyyy";
            this.dtppurdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtppurdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtppurdate.Location = new System.Drawing.Point(202, 46);
            this.dtppurdate.Margin = new System.Windows.Forms.Padding(6);
            this.dtppurdate.Name = "dtppurdate";
            this.dtppurdate.Size = new System.Drawing.Size(200, 42);
            this.dtppurdate.TabIndex = 0;
            this.dtppurdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpdate_KeyDown);
            // 
            // lblfrom
            // 
            this.lblfrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfrom.AutoSize = true;
            this.lblfrom.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfrom.Location = new System.Drawing.Point(794, 0);
            this.lblfrom.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(149, 40);
            this.lblfrom.TabIndex = 10;
            this.lblfrom.Text = "Purchase From";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(438, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 40);
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
            this.cboCity.Location = new System.Drawing.Point(500, 6);
            this.cboCity.Margin = new System.Windows.Forms.Padding(6);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(282, 43);
            this.cboCity.TabIndex = 4;
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
            this.tableentry.SetColumnSpan(this.lblAddress, 4);
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblAddress.Location = new System.Drawing.Point(794, 42);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(24, 35);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = ".";
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
            this.cbopurfrom.Location = new System.Drawing.Point(962, 6);
            this.cbopurfrom.Margin = new System.Windows.Forms.Padding(6);
            this.cbopurfrom.Name = "cbopurfrom";
            this.cbopurfrom.Size = new System.Drawing.Size(288, 43);
            this.cbopurfrom.TabIndex = 4;
            this.cbopurfrom.ValueMember = "led_id";
            this.cbopurfrom.SelectedValueChanged += new System.EventHandler(this.cbopurfrom_SelectedValueChanged);
            this.cbopurfrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbopurfrom_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
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
            this.tablecmd.Location = new System.Drawing.Point(8, 630);
            this.tablecmd.Margin = new System.Windows.Forms.Padding(6);
            this.tablecmd.Name = "tablecmd";
            this.tablecmd.RowCount = 1;
            this.tablecmd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablecmd.Size = new System.Drawing.Size(1299, 52);
            this.tablecmd.TabIndex = 3;
            // 
            // cmdsave
            // 
            this.cmdsave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdsave.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdsave.Location = new System.Drawing.Point(665, 6);
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
            this.cmdrefresh.Location = new System.Drawing.Point(825, 6);
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
            this.cmdclose.Location = new System.Drawing.Point(1145, 6);
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
            this.cmdview.Location = new System.Drawing.Point(985, 6);
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
            this.tablesum.ColumnCount = 6;
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tablesum.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablesum.Controls.Add(this.lbltotqty, 0, 0);
            this.tablesum.Controls.Add(this.txttotqty, 1, 0);
            this.tablesum.Controls.Add(this.txttotamt, 3, 0);
            this.tablesum.Controls.Add(this.lblnetamt, 2, 0);
            this.tablesum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesum.Location = new System.Drawing.Point(8, 571);
            this.tablesum.Margin = new System.Windows.Forms.Padding(6);
            this.tablesum.Name = "tablesum";
            this.tablesum.RowCount = 1;
            this.tablesum.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablesum.Size = new System.Drawing.Size(1299, 45);
            this.tablesum.TabIndex = 2;
            // 
            // lbltotqty
            // 
            this.lbltotqty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltotqty.AutoSize = true;
            this.lbltotqty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbltotqty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltotqty.Location = new System.Drawing.Point(6, 5);
            this.lbltotqty.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbltotqty.Name = "lbltotqty";
            this.lbltotqty.Size = new System.Drawing.Size(149, 35);
            this.lbltotqty.TabIndex = 2;
            this.lbltotqty.Text = "Total Qty";
            // 
            // txttotqty
            // 
            this.txttotqty.AllowFormat = false;
            this.txttotqty.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttotqty.BackColor = System.Drawing.Color.White;
            this.txttotqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotqty.DecimalPlaces = 2;
            this.txttotqty.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txttotqty.Location = new System.Drawing.Point(211, 6);
            this.txttotqty.Margin = new System.Windows.Forms.Padding(6);
            this.txttotqty.Name = "txttotqty";
            this.txttotqty.ReadOnly = true;
            this.txttotqty.RightAlign = true;
            this.txttotqty.Size = new System.Drawing.Size(193, 42);
            this.txttotqty.TabIndex = 5;
            this.txttotqty.TabStop = false;
            this.txttotqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotqty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txttotamt
            // 
            this.txttotamt.AllowFormat = false;
            this.txttotamt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txttotamt.BackColor = System.Drawing.Color.White;
            this.txttotamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttotamt.DecimalPlaces = 2;
            this.txttotamt.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txttotamt.Location = new System.Drawing.Point(621, 6);
            this.txttotamt.Margin = new System.Windows.Forms.Padding(6);
            this.txttotamt.Name = "txttotamt";
            this.txttotamt.ReadOnly = true;
            this.txttotamt.RightAlign = true;
            this.txttotamt.Size = new System.Drawing.Size(193, 42);
            this.txttotamt.TabIndex = 6;
            this.txttotamt.TabStop = false;
            this.txttotamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotamt.Value = new decimal(new int[] {
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
            this.lblnetamt.Location = new System.Drawing.Point(416, 5);
            this.lblnetamt.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblnetamt.Name = "lblnetamt";
            this.lblnetamt.Size = new System.Drawing.Size(191, 35);
            this.lblnetamt.TabIndex = 8;
            this.lblnetamt.Text = "Net Amount";
            // 
            // pnlentry
            // 
            this.pnlentry.Controls.Add(this.dgvPurchase);
            this.pnlentry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlentry.Location = new System.Drawing.Point(8, 141);
            this.pnlentry.Margin = new System.Windows.Forms.Padding(6);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.Size = new System.Drawing.Size(1299, 416);
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
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.dgvPurchase.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPurchase.ShowCellToolTips = false;
            this.dgvPurchase.Size = new System.Drawing.Size(1299, 416);
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
            this.cSNo.Width = 45;
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
            this.cItemName.Width = 500;
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
            this.cRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cRate.Width = 150;
            // 
            // cAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0.00";
            this.cAmount.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.Format = "N2";
            this.cMrp.DefaultCellStyle = dataGridViewCellStyle7;
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
            this.tableview.Size = new System.Drawing.Size(1315, 690);
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
            this.dglist.Size = new System.Drawing.Size(1299, 497);
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
            this.pmnoDataGridViewTextBoxColumn.DataPropertyName = "pm_no";
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "N0";
            this.pmtotqtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.pmtotqtyDataGridViewTextBoxColumn.HeaderText = "Total Qty";
            this.pmtotqtyDataGridViewTextBoxColumn.Name = "pmtotqtyDataGridViewTextBoxColumn";
            this.pmtotqtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.pmtotqtyDataGridViewTextBoxColumn.Width = 200;
            // 
            // pmtotamountDataGridViewTextBoxColumn
            // 
            this.pmtotamountDataGridViewTextBoxColumn.DataPropertyName = "pm_totamount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.pmtotamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
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
            this.lblsubtitle.Location = new System.Drawing.Point(8, 10);
            this.lblsubtitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblsubtitle.Name = "lblsubtitle";
            this.lblsubtitle.Size = new System.Drawing.Size(249, 35);
            this.lblsubtitle.TabIndex = 4;
            this.lblsubtitle.Text = "PURCHASE LIST";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblBillNo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtptdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblfdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblhyp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpfdate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboCityView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchBillNo, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdexit, 9, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboSupplierView, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmdList, 8, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1305, 95);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblBillNo
            // 
            this.lblBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblBillNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblBillNo.Location = new System.Drawing.Point(444, 0);
            this.lblBillNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(84, 47);
            this.lblBillNo.TabIndex = 35;
            this.lblBillNo.Text = "BillNo";
            // 
            // dtptdate
            // 
            this.dtptdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtptdate.CustomFormat = "dd-MM-yyyy";
            this.dtptdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.dtptdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptdate.Location = new System.Drawing.Point(285, 6);
            this.dtptdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(149, 42);
            this.dtptdate.TabIndex = 1;
            this.dtptdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtptdate_KeyDown);
            // 
            // lblfdate
            // 
            this.lblfdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblfdate.AutoSize = true;
            this.lblfdate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblfdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfdate.Location = new System.Drawing.Point(4, 6);
            this.lblfdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfdate.Name = "lblfdate";
            this.lblfdate.Size = new System.Drawing.Size(83, 35);
            this.lblfdate.TabIndex = 23;
            this.lblfdate.Text = "Date";
            // 
            // lblhyp
            // 
            this.lblhyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblhyp.AutoSize = true;
            this.lblhyp.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhyp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblhyp.Location = new System.Drawing.Point(263, 9);
            this.lblhyp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhyp.Name = "lblhyp";
            this.lblhyp.Size = new System.Drawing.Size(14, 28);
            this.lblhyp.TabIndex = 1;
            this.lblhyp.Text = "-";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(444, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 48);
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
            this.dtpfdate.Location = new System.Drawing.Point(96, 6);
            this.dtpfdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtpfdate.Name = "dtpfdate";
            this.dtpfdate.Size = new System.Drawing.Size(159, 42);
            this.dtpfdate.TabIndex = 0;
            this.dtpfdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfdate_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(4, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 35);
            this.label5.TabIndex = 29;
            this.label5.Text = "City";
            // 
            // cboCityView
            // 
            this.cboCityView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboCityView.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCityView.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cboCityView, 3);
            this.cboCityView.DataSource = this.ledgermasteCityViewrBindingSource;
            this.cboCityView.DisplayMember = "led_address2";
            this.cboCityView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboCityView.FormattingEnabled = true;
            this.cboCityView.Location = new System.Drawing.Point(96, 53);
            this.cboCityView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cboCityView.Name = "cboCityView";
            this.cboCityView.Size = new System.Drawing.Size(340, 43);
            this.cboCityView.TabIndex = 30;
            this.cboCityView.ValueMember = "led_id";
            this.cboCityView.SelectedValueChanged += new System.EventHandler(this.cboCityView_SelectedValueChanged);
            this.cboCityView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCityView_KeyDown);
            // 
            // ledgermasteCityViewrBindingSource
            // 
            this.ledgermasteCityViewrBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // txtSearchBillNo
            // 
            this.txtSearchBillNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearchBillNo.Location = new System.Drawing.Point(548, 3);
            this.txtSearchBillNo.Name = "txtSearchBillNo";
            this.txtSearchBillNo.Size = new System.Drawing.Size(85, 42);
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
            this.cmdexit.Location = new System.Drawing.Point(1002, 48);
            this.cmdexit.Margin = new System.Windows.Forms.Padding(1);
            this.cmdexit.Name = "cmdexit";
            this.cmdexit.Size = new System.Drawing.Size(117, 45);
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
            this.cboSupplierView.DataSource = this.usppurchasemasterSelectResultBindingSource;
            this.cboSupplierView.DisplayMember = "led_name";
            this.cboSupplierView.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cboSupplierView.FormattingEnabled = true;
            this.cboSupplierView.Location = new System.Drawing.Point(549, 53);
            this.cboSupplierView.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cboSupplierView.Name = "cboSupplierView";
            this.cboSupplierView.Size = new System.Drawing.Size(329, 43);
            this.cboSupplierView.TabIndex = 36;
            this.cboSupplierView.ValueMember = "led_id";
            // 
            // cmdList
            // 
            this.cmdList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.cmdList.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.cmdList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdList.Location = new System.Drawing.Point(885, 48);
            this.cmdList.Margin = new System.Windows.Forms.Padding(1);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(115, 45);
            this.cmdList.TabIndex = 2;
            this.cmdList.Text = "&View";
            this.cmdList.UseVisualStyleBackColor = false;
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // ledgermasterViewBindingSource
            // 
            this.ledgermasterViewBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // pnlview
            // 
            this.pnlview.Controls.Add(this.tableview);
            this.pnlview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlview.Enabled = false;
            this.pnlview.Location = new System.Drawing.Point(0, 0);
            this.pnlview.Margin = new System.Windows.Forms.Padding(6);
            this.pnlview.Name = "pnlview";
            this.pnlview.Size = new System.Drawing.Size(1315, 690);
            this.pnlview.TabIndex = 12;
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 35F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1315, 690);
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
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasteCityViewrBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterViewBindingSource)).EndInit();
            this.pnlview.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
