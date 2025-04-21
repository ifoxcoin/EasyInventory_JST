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
	public class frmCompany : Form
	{
		private int id = 0;

		private IContainer components = null;

		private lightbutton cmdclose;

		private a1panel pnlview;

		private lightbutton cmddelete;

		private lightbutton cmdnew;

		private DataGridView dgview;

		private Label lbltitle;

		private a1panel a1Paneltitle;

		private BindingSource companyBindingSource;

		private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comnameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comadd1DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comadd2DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comadd3DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comcityDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comstateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comcountryDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comphoneDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn commobile1DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn commobile2DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comfaxDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn compinDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comemailDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comwebDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comdefaultDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comtinDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comcstDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn comcstdateDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn companDataGridViewTextBoxColumn;

		private a1panel pnlentry;

		private lightbutton cmdclear;

		private lightbutton cmdsave;

		private TabPage tabdetail;

		private TextBox txtfax;

		private Label lblfax;

		private MaskedTextBox txtpin;

		private Label lblpin;

		private TextBox txtcountry;

		private Label lblcountry;

		private TextBox txtstate;

		private Label lblstate;

		private TextBox txtcity;

		private Label lblcity;

		private TextBox txtadd2;

		private TextBox txtadd1;

		private Label lbladdress;

		private TextBox txtcompany;

		private Label lblcompany;

		private TabPage tabadd;

		private DateTimePicker dtpcstdate;

		private Label lblpan;

		private TextBox txtpan;

		private Label lblweb;

		private Label lbltinno;

		private Label lblcstno;

		private Label lblmail;

		private Label lblcstdate;

		private Label lblm1;

		private Label lblphone;

		private TextBox txtweb;

		private CheckBox chkdefault;

		private TextBox txttinno;

		private TextBox txtcstno;

		private TextBox txtmail;

		private MaskedTextBox txtm2;

		private MaskedTextBox txtm1;

		private MaskedTextBox txtphone;

		private TabControl tabemp;

		public frmCompany()
		{
			InitializeComponent();
		}

		private void frmCompany_Load(object sender, EventArgs e)
		{
			try
			{
				LoadCompany();
				cmdnew.Select();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void LoadCompany()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			companyBindingSource.DataSource = inventoryDataContext.usp_companySelect(null);
		}

		private void ClearCompany()
		{
			txtcompany.Text = string.Empty;
			txtadd1.Text = string.Empty;
			txtadd2.Text = string.Empty;
			txtcity.Text = string.Empty;
			txtstate.Text = string.Empty;
			txtcountry.Text = string.Empty;
			txtpin.Text = string.Empty;
			txtfax.Text = string.Empty;
			txtweb.Text = string.Empty;
			txtphone.Text = string.Empty;
			txtm1.Text = string.Empty;
			txtm2.Text = string.Empty;
			txtmail.Text = string.Empty;
			txttinno.Text = string.Empty;
			txtcstno.Text = string.Empty;
			chkdefault.Checked = false;
			txtpan.Text = string.Empty;
			dtpcstdate.Value = global.sysdate;
			dtpcstdate.Checked = false;
			cmddelete.Enabled = false;
			tabemp.SelectedIndex = 0;
			id = 0;
		}

		private void txtupper_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void cmdnew_Click(object sender, EventArgs e)
		{
			ClearCompany();
			pnlentry.Enabled = true;
			txtcompany.Focus();
		}

		private void toolStripEdit_Click(object sender, EventArgs e)
		{
			EditCompany();
		}

		private void dgunit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			EditCompany();
			cmddelete.Enabled = true;
			txtcompany.Focus();
		}

		private void EditCompany()
		{
			if (dgview.CurrentCell != null)
			{
				int rowIndex = dgview.CurrentCell.RowIndex;
				id = Convert.ToInt32(dgview["comidDataGridViewTextBoxColumn", rowIndex].Value);
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				ISingleResult<usp_companySelectResult> singleResult = inventoryDataContext.usp_companySelect(id);
				foreach (usp_companySelectResult item in singleResult)
				{
					txtcompany.Text = item.com_name;
					txtadd1.Text = item.com_add1;
					txtadd2.Text = item.com_add2;
					txtcity.Text = item.com_city;
					txtstate.Text = item.com_state;
					txtcountry.Text = item.com_country;
					txtpin.Text = item.com_pin;
					txtfax.Text = item.com_fax;
					txtweb.Text = item.com_web;
					txtphone.Text = item.com_phone;
					txtm1.Text = item.com_mobile1;
					txtm2.Text = item.com_mobile2;
					txtmail.Text = item.com_email;
					txttinno.Text = item.com_tin;
					txtcstno.Text = item.com_cst;
					chkdefault.Checked = ((item.com_default == 'Y') ? true : false);
					txtpan.Text = item.com_pan;
					dtpcstdate.Checked = ((!(item.com_cstdate == global.NullDate)) ? true : false);
					dtpcstdate.Value = (dtpcstdate.Checked ? Convert.ToDateTime(item.com_cstdate) : global.sysdate);
				}
				pnlentry.Enabled = true;
			}
		}

		private void cmdsave_Click(object sender, EventArgs e)
		{
			try
			{
				company cm = new company();
				cm.com_name = txtcompany.Text.Trim();
				cm.com_add1 = txtadd1.Text.Trim();
				cm.com_add2 = txtadd2.Text.Trim();
				cm.com_city = txtcity.Text.Trim();
				cm.com_state = txtstate.Text.Trim();
				cm.com_country = txtcountry.Text.Trim();
				cm.com_pin = txtpin.Text.Trim();
				cm.com_fax = txtfax.Text.Trim();
				cm.com_web = txtweb.Text.Trim();
				cm.com_phone = txtphone.Text.Trim();
				cm.com_mobile1 = txtm1.Text.Trim();
				cm.com_mobile2 = txtm2.Text.Trim();
				cm.com_email = txtmail.Text.Trim();
				cm.com_tin = txttinno.Text.Trim();
				cm.com_cst = txtcstno.Text.Trim();
				cm.com_default = (chkdefault.Checked ? 'Y' : 'N');
				cm.com_pan = txtpan.Text.Trim();
				cm.com_cstdate = (dtpcstdate.Checked ? dtpcstdate.Value.Date : new DateTime(1900, 1, 1));
				InventoryDataContext inventoryDataContext;
				if (pnlentry.Enabled)
				{
					if (cm.com_name == string.Empty)
					{
						MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						txtcompany.Focus();
					}
					else
					{
						inventoryDataContext = new InventoryDataContext();
						if (cm.com_default == 'Y')
						{
							dbcon dbcon = new dbcon(global.constring);
							using (dbcon)
							{
								dbcon.executequery("update company set com_default='N'");
							}
							goto IL_0431;
						}
						IQueryable<company> source = inventoryDataContext.companies.Where((company a) => (int?)a.com_default == (int?)89 && a.com_id != (long)id);
						if (source.Count() != 0)
						{
							goto IL_0431;
						}
						MessageBox.Show("Invalid 'Default Company'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						chkdefault.Focus();
					}
				}
				goto end_IL_0010;
				IL_083f:
				ClearCompany();
				LoadCompany();
				pnlentry.Enabled = false;
				goto end_IL_0010;
				IL_0431:
				var source2 = from b in inventoryDataContext.companies
					where b.com_name == cm.com_name && b.com_id != (long)id
					select new
					{
						b.com_id
					};
				if (source2.Count() != 0)
				{
					MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					txtcompany.Focus();
				}
				else if (id == 0)
				{
					if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						inventoryDataContext.usp_companyInsert(cm.com_name, cm.com_add1, cm.com_add2, cm.com_add3, cm.com_city, cm.com_state, cm.com_country, cm.com_phone, cm.com_mobile1, cm.com_mobile2, cm.com_fax, cm.com_pin, cm.com_email, cm.com_web, cm.com_default, cm.com_tin, cm.com_cst, cm.com_cstdate, cm.com_pan);
						MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_083f;
					}
				}
				else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					inventoryDataContext.usp_companyUpdate(id, cm.com_name, cm.com_add1, cm.com_add2, cm.com_add3, cm.com_city, cm.com_state, cm.com_country, cm.com_phone, cm.com_mobile1, cm.com_mobile2, cm.com_fax, cm.com_pin, cm.com_email, cm.com_web, cm.com_default, cm.com_tin, cm.com_cst, cm.com_cstdate, cm.com_pan);
					MessageBox.Show("Record updated successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					goto IL_083f;
				}
				end_IL_0010:;
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void cmdclear_Click(object sender, EventArgs e)
		{
			ClearCompany();
			LoadCompany();
			pnlentry.Enabled = false;
		}

		private void cmddelete_Click(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			if (id != 0 && MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
			{
				inventoryDataContext.usp_companyDelete(id);
				ClearCompany();
				LoadCompany();
				pnlentry.Enabled = false;
				MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void toolStripExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtCompany_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtcompany.Text.Trim() != string.Empty)
			{
				txtadd1.Focus();
			}
		}

		private void txtadd1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtadd2.Focus();
			}
		}

		private void txtadd2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtcity.Focus();
			}
		}

		private void txtcity_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtstate.Focus();
			}
		}

		private void txtstate_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtcountry.Focus();
			}
		}

		private void txtcountry_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtpin.Focus();
			}
		}

		private void txtpin_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtfax.Focus();
			}
		}

		private void txtfax_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				tabemp.SelectedIndex = 1;
				txtweb.Focus();
			}
		}

		private void txtweb_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtphone.Focus();
			}
		}

		private void txtphone_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtm1.Focus();
			}
		}

		private void txtm1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtm2.Focus();
			}
		}

		private void txtm2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtmail.Focus();
			}
		}

		private void txtmail_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txttinno.Focus();
			}
		}

		private void txttinno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtcstno.Focus();
			}
		}

		private void txtcstno_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				dtpcstdate.Focus();
			}
		}

		private void dtpcstdate_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtpan.Focus();
			}
		}

		private void txtpan_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				chkdefault.Select();
			}
		}

		private void chkdefault_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cmdsave.Focus();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(standard.master.frmCompany));
			cmdclose = new mylib.lightbutton();
			pnlview = new mylib.a1panel();
			cmddelete = new mylib.lightbutton();
			cmdnew = new mylib.lightbutton();
			dgview = new System.Windows.Forms.DataGridView();
			comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comadd1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comadd2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comadd3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comcityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comstateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comcountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			commobile1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			commobile2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comfaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			compinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comwebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comdefaultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comtinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comcstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			comcstdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			companDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			companyBindingSource = new System.Windows.Forms.BindingSource(components);
			lbltitle = new System.Windows.Forms.Label();
			a1Paneltitle = new mylib.a1panel();
			pnlentry = new mylib.a1panel();
			cmdclear = new mylib.lightbutton();
			cmdsave = new mylib.lightbutton();
			tabemp = new System.Windows.Forms.TabControl();
			tabdetail = new System.Windows.Forms.TabPage();
			txtfax = new System.Windows.Forms.TextBox();
			lblfax = new System.Windows.Forms.Label();
			txtpin = new System.Windows.Forms.MaskedTextBox();
			lblpin = new System.Windows.Forms.Label();
			txtcountry = new System.Windows.Forms.TextBox();
			lblcountry = new System.Windows.Forms.Label();
			txtstate = new System.Windows.Forms.TextBox();
			lblstate = new System.Windows.Forms.Label();
			txtcity = new System.Windows.Forms.TextBox();
			lblcity = new System.Windows.Forms.Label();
			txtadd2 = new System.Windows.Forms.TextBox();
			txtadd1 = new System.Windows.Forms.TextBox();
			lbladdress = new System.Windows.Forms.Label();
			txtcompany = new System.Windows.Forms.TextBox();
			lblcompany = new System.Windows.Forms.Label();
			tabadd = new System.Windows.Forms.TabPage();
			dtpcstdate = new System.Windows.Forms.DateTimePicker();
			lblpan = new System.Windows.Forms.Label();
			txtpan = new System.Windows.Forms.TextBox();
			lblweb = new System.Windows.Forms.Label();
			lbltinno = new System.Windows.Forms.Label();
			lblcstno = new System.Windows.Forms.Label();
			lblmail = new System.Windows.Forms.Label();
			lblcstdate = new System.Windows.Forms.Label();
			lblm1 = new System.Windows.Forms.Label();
			lblphone = new System.Windows.Forms.Label();
			txtweb = new System.Windows.Forms.TextBox();
			chkdefault = new System.Windows.Forms.CheckBox();
			txttinno = new System.Windows.Forms.TextBox();
			txtcstno = new System.Windows.Forms.TextBox();
			txtmail = new System.Windows.Forms.TextBox();
			txtm2 = new System.Windows.Forms.MaskedTextBox();
			txtm1 = new System.Windows.Forms.MaskedTextBox();
			txtphone = new System.Windows.Forms.MaskedTextBox();
			pnlview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgview).BeginInit();
			((System.ComponentModel.ISupportInitialize)companyBindingSource).BeginInit();
			a1Paneltitle.SuspendLayout();
			pnlentry.SuspendLayout();
			tabemp.SuspendLayout();
			tabdetail.SuspendLayout();
			tabadd.SuspendLayout();
			SuspendLayout();
			cmdclose.AutoSize = true;
			cmdclose.BackColor = System.Drawing.Color.Transparent;
			cmdclose.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			cmdclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclose.Location = new System.Drawing.Point(226, 11);
			cmdclose.Name = "cmdclose";
			cmdclose.Size = new System.Drawing.Size(90, 31);
			cmdclose.TabIndex = 2;
			cmdclose.Text = "&Close";
			cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmdclose.UseVisualStyleBackColor = false;
			cmdclose.Click += new System.EventHandler(toolStripExit_Click);
			pnlview.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			pnlview.BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			pnlview.BorderColor = System.Drawing.Color.Gray;
			pnlview.Controls.Add(cmdclose);
			pnlview.Controls.Add(cmddelete);
			pnlview.Controls.Add(cmdnew);
			pnlview.Controls.Add(dgview);
			pnlview.GradientEndColor = System.Drawing.Color.White;
			pnlview.GradientStartColor = System.Drawing.Color.White;
			pnlview.Image = null;
			pnlview.ImageLocation = new System.Drawing.Point(4, 4);
			pnlview.Location = new System.Drawing.Point(319, 46);
			pnlview.Name = "pnlview";
			pnlview.RoundCornerRadius = 25;
			pnlview.ShadowOffSet = 0;
			pnlview.Size = new System.Drawing.Size(691, 414);
			pnlview.TabIndex = 4;
			cmddelete.AutoSize = true;
			cmddelete.BackColor = System.Drawing.Color.Transparent;
			cmddelete.Enabled = false;
			cmddelete.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			cmddelete.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmddelete.Location = new System.Drawing.Point(130, 11);
			cmddelete.Name = "cmddelete";
			cmddelete.Size = new System.Drawing.Size(90, 31);
			cmddelete.TabIndex = 1;
			cmddelete.Text = "&Delete";
			cmddelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmddelete.UseVisualStyleBackColor = false;
			cmddelete.Click += new System.EventHandler(cmddelete_Click);
			cmdnew.AutoSize = true;
			cmdnew.BackColor = System.Drawing.Color.Transparent;
			cmdnew.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			cmdnew.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdnew.Location = new System.Drawing.Point(34, 11);
			cmdnew.Name = "cmdnew";
			cmdnew.Size = new System.Drawing.Size(90, 31);
			cmdnew.TabIndex = 0;
			cmdnew.Text = "&New";
			cmdnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmdnew.UseVisualStyleBackColor = false;
			cmdnew.Click += new System.EventHandler(cmdnew_Click);
			dgview.AllowUserToAddRows = false;
			dgview.AllowUserToDeleteRows = false;
			dgview.AllowUserToResizeRows = false;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			dgview.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dgview.AutoGenerateColumns = false;
			dgview.BackgroundColor = System.Drawing.Color.White;
			dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgview.Columns.AddRange(comidDataGridViewTextBoxColumn, comnameDataGridViewTextBoxColumn, comadd1DataGridViewTextBoxColumn, comadd2DataGridViewTextBoxColumn, comadd3DataGridViewTextBoxColumn, comcityDataGridViewTextBoxColumn, comstateDataGridViewTextBoxColumn, comcountryDataGridViewTextBoxColumn, comphoneDataGridViewTextBoxColumn, commobile1DataGridViewTextBoxColumn, commobile2DataGridViewTextBoxColumn, comfaxDataGridViewTextBoxColumn, compinDataGridViewTextBoxColumn, comemailDataGridViewTextBoxColumn, comwebDataGridViewTextBoxColumn, comdefaultDataGridViewTextBoxColumn, comtinDataGridViewTextBoxColumn, comcstDataGridViewTextBoxColumn, comcstdateDataGridViewTextBoxColumn, companDataGridViewTextBoxColumn);
			dgview.Cursor = System.Windows.Forms.Cursors.Default;
			dgview.DataSource = companyBindingSource;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dgview.DefaultCellStyle = dataGridViewCellStyle3;
			dgview.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold);
			dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			dgview.Location = new System.Drawing.Point(1, 45);
			dgview.MultiSelect = false;
			dgview.Name = "dgview";
			dgview.ReadOnly = true;
			dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			dgview.RowHeadersVisible = false;
			dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgview.Size = new System.Drawing.Size(687, 366);
			dgview.TabIndex = 3;
			dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgunit_CellDoubleClick);
			comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
			comidDataGridViewTextBoxColumn.HeaderText = "com_id";
			comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
			comidDataGridViewTextBoxColumn.ReadOnly = true;
			comidDataGridViewTextBoxColumn.Visible = false;
			comnameDataGridViewTextBoxColumn.DataPropertyName = "com_name";
			comnameDataGridViewTextBoxColumn.HeaderText = "Company";
			comnameDataGridViewTextBoxColumn.Name = "comnameDataGridViewTextBoxColumn";
			comnameDataGridViewTextBoxColumn.ReadOnly = true;
			comnameDataGridViewTextBoxColumn.Width = 250;
			comadd1DataGridViewTextBoxColumn.DataPropertyName = "com_add1";
			comadd1DataGridViewTextBoxColumn.HeaderText = "com_add1";
			comadd1DataGridViewTextBoxColumn.Name = "comadd1DataGridViewTextBoxColumn";
			comadd1DataGridViewTextBoxColumn.ReadOnly = true;
			comadd1DataGridViewTextBoxColumn.Visible = false;
			comadd2DataGridViewTextBoxColumn.DataPropertyName = "com_add2";
			comadd2DataGridViewTextBoxColumn.HeaderText = "com_add2";
			comadd2DataGridViewTextBoxColumn.Name = "comadd2DataGridViewTextBoxColumn";
			comadd2DataGridViewTextBoxColumn.ReadOnly = true;
			comadd2DataGridViewTextBoxColumn.Visible = false;
			comadd3DataGridViewTextBoxColumn.DataPropertyName = "com_add3";
			comadd3DataGridViewTextBoxColumn.HeaderText = "com_add3";
			comadd3DataGridViewTextBoxColumn.Name = "comadd3DataGridViewTextBoxColumn";
			comadd3DataGridViewTextBoxColumn.ReadOnly = true;
			comadd3DataGridViewTextBoxColumn.Visible = false;
			comcityDataGridViewTextBoxColumn.DataPropertyName = "com_city";
			comcityDataGridViewTextBoxColumn.HeaderText = "City";
			comcityDataGridViewTextBoxColumn.Name = "comcityDataGridViewTextBoxColumn";
			comcityDataGridViewTextBoxColumn.ReadOnly = true;
			comcityDataGridViewTextBoxColumn.Width = 200;
			comstateDataGridViewTextBoxColumn.DataPropertyName = "com_state";
			comstateDataGridViewTextBoxColumn.HeaderText = "State";
			comstateDataGridViewTextBoxColumn.Name = "comstateDataGridViewTextBoxColumn";
			comstateDataGridViewTextBoxColumn.ReadOnly = true;
			comstateDataGridViewTextBoxColumn.Visible = false;
			comstateDataGridViewTextBoxColumn.Width = 200;
			comcountryDataGridViewTextBoxColumn.DataPropertyName = "com_country";
			comcountryDataGridViewTextBoxColumn.HeaderText = "com_country";
			comcountryDataGridViewTextBoxColumn.Name = "comcountryDataGridViewTextBoxColumn";
			comcountryDataGridViewTextBoxColumn.ReadOnly = true;
			comcountryDataGridViewTextBoxColumn.Visible = false;
			comphoneDataGridViewTextBoxColumn.DataPropertyName = "com_phone";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
			comphoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
			comphoneDataGridViewTextBoxColumn.HeaderText = "Phone";
			comphoneDataGridViewTextBoxColumn.Name = "comphoneDataGridViewTextBoxColumn";
			comphoneDataGridViewTextBoxColumn.ReadOnly = true;
			comphoneDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			comphoneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			commobile1DataGridViewTextBoxColumn.DataPropertyName = "com_mobile1";
			commobile1DataGridViewTextBoxColumn.HeaderText = "Mobile";
			commobile1DataGridViewTextBoxColumn.Name = "commobile1DataGridViewTextBoxColumn";
			commobile1DataGridViewTextBoxColumn.ReadOnly = true;
			commobile1DataGridViewTextBoxColumn.Visible = false;
			commobile2DataGridViewTextBoxColumn.DataPropertyName = "com_mobile2";
			commobile2DataGridViewTextBoxColumn.HeaderText = "com_mobile2";
			commobile2DataGridViewTextBoxColumn.Name = "commobile2DataGridViewTextBoxColumn";
			commobile2DataGridViewTextBoxColumn.ReadOnly = true;
			commobile2DataGridViewTextBoxColumn.Visible = false;
			comfaxDataGridViewTextBoxColumn.DataPropertyName = "com_fax";
			comfaxDataGridViewTextBoxColumn.HeaderText = "com_fax";
			comfaxDataGridViewTextBoxColumn.Name = "comfaxDataGridViewTextBoxColumn";
			comfaxDataGridViewTextBoxColumn.ReadOnly = true;
			comfaxDataGridViewTextBoxColumn.Visible = false;
			compinDataGridViewTextBoxColumn.DataPropertyName = "com_pin";
			compinDataGridViewTextBoxColumn.HeaderText = "com_pin";
			compinDataGridViewTextBoxColumn.Name = "compinDataGridViewTextBoxColumn";
			compinDataGridViewTextBoxColumn.ReadOnly = true;
			compinDataGridViewTextBoxColumn.Visible = false;
			comemailDataGridViewTextBoxColumn.DataPropertyName = "com_email";
			comemailDataGridViewTextBoxColumn.HeaderText = "com_email";
			comemailDataGridViewTextBoxColumn.Name = "comemailDataGridViewTextBoxColumn";
			comemailDataGridViewTextBoxColumn.ReadOnly = true;
			comemailDataGridViewTextBoxColumn.Visible = false;
			comwebDataGridViewTextBoxColumn.DataPropertyName = "com_web";
			comwebDataGridViewTextBoxColumn.HeaderText = "com_web";
			comwebDataGridViewTextBoxColumn.Name = "comwebDataGridViewTextBoxColumn";
			comwebDataGridViewTextBoxColumn.ReadOnly = true;
			comwebDataGridViewTextBoxColumn.Visible = false;
			comdefaultDataGridViewTextBoxColumn.DataPropertyName = "com_default";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			comdefaultDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
			comdefaultDataGridViewTextBoxColumn.HeaderText = "Default";
			comdefaultDataGridViewTextBoxColumn.Name = "comdefaultDataGridViewTextBoxColumn";
			comdefaultDataGridViewTextBoxColumn.ReadOnly = true;
			comdefaultDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			comdefaultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			comdefaultDataGridViewTextBoxColumn.Width = 70;
			comtinDataGridViewTextBoxColumn.DataPropertyName = "com_tin";
			comtinDataGridViewTextBoxColumn.HeaderText = "com_tin";
			comtinDataGridViewTextBoxColumn.Name = "comtinDataGridViewTextBoxColumn";
			comtinDataGridViewTextBoxColumn.ReadOnly = true;
			comtinDataGridViewTextBoxColumn.Visible = false;
			comcstDataGridViewTextBoxColumn.DataPropertyName = "com_cst";
			comcstDataGridViewTextBoxColumn.HeaderText = "com_cst";
			comcstDataGridViewTextBoxColumn.Name = "comcstDataGridViewTextBoxColumn";
			comcstDataGridViewTextBoxColumn.ReadOnly = true;
			comcstDataGridViewTextBoxColumn.Visible = false;
			comcstdateDataGridViewTextBoxColumn.DataPropertyName = "com_cstdate";
			comcstdateDataGridViewTextBoxColumn.HeaderText = "com_cstdate";
			comcstdateDataGridViewTextBoxColumn.Name = "comcstdateDataGridViewTextBoxColumn";
			comcstdateDataGridViewTextBoxColumn.ReadOnly = true;
			comcstdateDataGridViewTextBoxColumn.Visible = false;
			companDataGridViewTextBoxColumn.DataPropertyName = "com_pan";
			companDataGridViewTextBoxColumn.HeaderText = "com_pan";
			companDataGridViewTextBoxColumn.Name = "companDataGridViewTextBoxColumn";
			companDataGridViewTextBoxColumn.ReadOnly = true;
			companDataGridViewTextBoxColumn.Visible = false;
			companyBindingSource.DataSource = typeof(standard.classes.company);
			lbltitle.AutoSize = true;
			lbltitle.BackColor = System.Drawing.Color.Transparent;
			lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(25, 6);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(86, 18);
			lbltitle.TabIndex = 1;
			lbltitle.Text = "COMPANY";
			lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			a1Paneltitle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
			a1Paneltitle.Controls.Add(lbltitle);
			a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
			a1Paneltitle.Image = null;
			a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
			a1Paneltitle.Location = new System.Drawing.Point(5, 11);
			a1Paneltitle.Name = "a1Paneltitle";
			a1Paneltitle.ShadowOffSet = 0;
			a1Paneltitle.Size = new System.Drawing.Size(1005, 29);
			a1Paneltitle.TabIndex = 5;
			pnlentry.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			pnlentry.BorderColor = System.Drawing.Color.Gray;
			pnlentry.Controls.Add(cmdclear);
			pnlentry.Controls.Add(cmdsave);
			pnlentry.Controls.Add(tabemp);
			pnlentry.Enabled = false;
			pnlentry.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			pnlentry.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			pnlentry.GradientStartColor = System.Drawing.Color.WhiteSmoke;
			pnlentry.Image = null;
			pnlentry.ImageLocation = new System.Drawing.Point(4, 4);
			pnlentry.Location = new System.Drawing.Point(5, 46);
			pnlentry.Name = "pnlentry";
			pnlentry.RoundCornerRadius = 25;
			pnlentry.ShadowOffSet = 0;
			pnlentry.Size = new System.Drawing.Size(301, 414);
			pnlentry.TabIndex = 6;
			cmdclear.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			cmdclear.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclear.Location = new System.Drawing.Point(202, 12);
			cmdclear.Name = "cmdclear";
			cmdclear.Size = new System.Drawing.Size(90, 30);
			cmdclear.TabIndex = 2;
			cmdclear.Text = "Cl&ear";
			cmdclear.UseVisualStyleBackColor = true;
			cmdclear.Click += new System.EventHandler(cmdclear_Click);
			cmdsave.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			cmdsave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdsave.Location = new System.Drawing.Point(106, 11);
			cmdsave.Name = "cmdsave";
			cmdsave.Size = new System.Drawing.Size(90, 30);
			cmdsave.TabIndex = 1;
			cmdsave.Text = "&Update";
			cmdsave.UseVisualStyleBackColor = true;
			cmdsave.Click += new System.EventHandler(cmdsave_Click);
			tabemp.Controls.Add(tabdetail);
			tabemp.Controls.Add(tabadd);
			tabemp.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
			tabemp.HotTrack = true;
			tabemp.Location = new System.Drawing.Point(7, 48);
			tabemp.Name = "tabemp";
			tabemp.SelectedIndex = 0;
			tabemp.Size = new System.Drawing.Size(290, 353);
			tabemp.TabIndex = 0;
			tabdetail.Controls.Add(txtfax);
			tabdetail.Controls.Add(lblfax);
			tabdetail.Controls.Add(txtpin);
			tabdetail.Controls.Add(lblpin);
			tabdetail.Controls.Add(txtcountry);
			tabdetail.Controls.Add(lblcountry);
			tabdetail.Controls.Add(txtstate);
			tabdetail.Controls.Add(lblstate);
			tabdetail.Controls.Add(txtcity);
			tabdetail.Controls.Add(lblcity);
			tabdetail.Controls.Add(txtadd2);
			tabdetail.Controls.Add(txtadd1);
			tabdetail.Controls.Add(lbladdress);
			tabdetail.Controls.Add(txtcompany);
			tabdetail.Controls.Add(lblcompany);
			tabdetail.Location = new System.Drawing.Point(4, 23);
			tabdetail.Name = "tabdetail";
			tabdetail.Padding = new System.Windows.Forms.Padding(3);
			tabdetail.Size = new System.Drawing.Size(282, 326);
			tabdetail.TabIndex = 0;
			tabdetail.Text = "Details";
			tabdetail.UseVisualStyleBackColor = true;
			txtfax.Location = new System.Drawing.Point(111, 219);
			txtfax.Name = "txtfax";
			txtfax.Size = new System.Drawing.Size(165, 22);
			txtfax.TabIndex = 7;
			txtfax.KeyDown += new System.Windows.Forms.KeyEventHandler(txtfax_KeyDown);
			lblfax.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblfax.Location = new System.Drawing.Point(6, 219);
			lblfax.Name = "lblfax";
			lblfax.Size = new System.Drawing.Size(100, 20);
			lblfax.TabIndex = 67;
			lblfax.Text = "Fax";
			lblfax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtpin.Location = new System.Drawing.Point(111, 191);
			txtpin.Mask = "000-000";
			txtpin.Name = "txtpin";
			txtpin.Size = new System.Drawing.Size(165, 22);
			txtpin.TabIndex = 6;
			txtpin.KeyDown += new System.Windows.Forms.KeyEventHandler(txtpin_KeyDown);
			lblpin.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpin.Location = new System.Drawing.Point(6, 191);
			lblpin.Name = "lblpin";
			lblpin.Size = new System.Drawing.Size(100, 20);
			lblpin.TabIndex = 66;
			lblpin.Text = "Pin";
			lblpin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtcountry.Location = new System.Drawing.Point(111, 163);
			txtcountry.MaxLength = 50;
			txtcountry.Name = "txtcountry";
			txtcountry.Size = new System.Drawing.Size(165, 22);
			txtcountry.TabIndex = 5;
			txtcountry.KeyDown += new System.Windows.Forms.KeyEventHandler(txtcountry_KeyDown);
			lblcountry.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcountry.Location = new System.Drawing.Point(6, 163);
			lblcountry.Name = "lblcountry";
			lblcountry.Size = new System.Drawing.Size(100, 20);
			lblcountry.TabIndex = 65;
			lblcountry.Text = "Country";
			lblcountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtstate.Location = new System.Drawing.Point(111, 135);
			txtstate.MaxLength = 50;
			txtstate.Name = "txtstate";
			txtstate.Size = new System.Drawing.Size(165, 22);
			txtstate.TabIndex = 4;
			txtstate.KeyDown += new System.Windows.Forms.KeyEventHandler(txtstate_KeyDown);
			lblstate.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblstate.Location = new System.Drawing.Point(6, 135);
			lblstate.Name = "lblstate";
			lblstate.Size = new System.Drawing.Size(100, 20);
			lblstate.TabIndex = 64;
			lblstate.Text = "State";
			lblstate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtcity.Location = new System.Drawing.Point(111, 106);
			txtcity.MaxLength = 50;
			txtcity.Name = "txtcity";
			txtcity.Size = new System.Drawing.Size(165, 22);
			txtcity.TabIndex = 3;
			txtcity.KeyDown += new System.Windows.Forms.KeyEventHandler(txtcity_KeyDown);
			lblcity.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcity.Location = new System.Drawing.Point(6, 106);
			lblcity.Name = "lblcity";
			lblcity.Size = new System.Drawing.Size(100, 20);
			lblcity.TabIndex = 63;
			lblcity.Text = "City";
			lblcity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtadd2.Location = new System.Drawing.Point(111, 77);
			txtadd2.MaxLength = 50;
			txtadd2.Name = "txtadd2";
			txtadd2.Size = new System.Drawing.Size(165, 22);
			txtadd2.TabIndex = 2;
			txtadd2.KeyDown += new System.Windows.Forms.KeyEventHandler(txtadd2_KeyDown);
			txtadd1.Location = new System.Drawing.Point(111, 49);
			txtadd1.MaxLength = 50;
			txtadd1.Name = "txtadd1";
			txtadd1.Size = new System.Drawing.Size(165, 22);
			txtadd1.TabIndex = 1;
			txtadd1.KeyDown += new System.Windows.Forms.KeyEventHandler(txtadd1_KeyDown);
			lbladdress.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbladdress.Location = new System.Drawing.Point(6, 49);
			lbladdress.Name = "lbladdress";
			lbladdress.Size = new System.Drawing.Size(82, 20);
			lbladdress.TabIndex = 62;
			lbladdress.Text = "Address";
			lbladdress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtcompany.Location = new System.Drawing.Point(111, 21);
			txtcompany.MaxLength = 100;
			txtcompany.Name = "txtcompany";
			txtcompany.Size = new System.Drawing.Size(165, 22);
			txtcompany.TabIndex = 0;
			txtcompany.KeyDown += new System.Windows.Forms.KeyEventHandler(txtCompany_KeyDown);
			txtcompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtupper_KeyPress);
			lblcompany.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcompany.Location = new System.Drawing.Point(6, 21);
			lblcompany.Name = "lblcompany";
			lblcompany.Size = new System.Drawing.Size(99, 20);
			lblcompany.TabIndex = 54;
			lblcompany.Text = "Company Name";
			lblcompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			tabadd.Controls.Add(dtpcstdate);
			tabadd.Controls.Add(lblpan);
			tabadd.Controls.Add(txtpan);
			tabadd.Controls.Add(lblweb);
			tabadd.Controls.Add(lbltinno);
			tabadd.Controls.Add(lblcstno);
			tabadd.Controls.Add(lblmail);
			tabadd.Controls.Add(lblcstdate);
			tabadd.Controls.Add(lblm1);
			tabadd.Controls.Add(lblphone);
			tabadd.Controls.Add(txtweb);
			tabadd.Controls.Add(chkdefault);
			tabadd.Controls.Add(txttinno);
			tabadd.Controls.Add(txtcstno);
			tabadd.Controls.Add(txtmail);
			tabadd.Controls.Add(txtm2);
			tabadd.Controls.Add(txtm1);
			tabadd.Controls.Add(txtphone);
			tabadd.Location = new System.Drawing.Point(4, 23);
			tabadd.Name = "tabadd";
			tabadd.Padding = new System.Windows.Forms.Padding(3);
			tabadd.Size = new System.Drawing.Size(282, 326);
			tabadd.TabIndex = 1;
			tabadd.Text = "Address";
			tabadd.UseVisualStyleBackColor = true;
			dtpcstdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			dtpcstdate.CustomFormat = "dd-MM-yyyy";
			dtpcstdate.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dtpcstdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dtpcstdate.Location = new System.Drawing.Point(82, 191);
			dtpcstdate.Name = "dtpcstdate";
			dtpcstdate.ShowCheckBox = true;
			dtpcstdate.Size = new System.Drawing.Size(108, 21);
			dtpcstdate.TabIndex = 7;
			dtpcstdate.KeyDown += new System.Windows.Forms.KeyEventHandler(dtpcstdate_KeyDown);
			lblpan.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpan.Location = new System.Drawing.Point(8, 216);
			lblpan.Name = "lblpan";
			lblpan.Size = new System.Drawing.Size(65, 20);
			lblpan.TabIndex = 74;
			lblpan.Text = "Pan";
			lblpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtpan.Location = new System.Drawing.Point(82, 216);
			txtpan.MaxLength = 50;
			txtpan.Name = "txtpan";
			txtpan.Size = new System.Drawing.Size(191, 22);
			txtpan.TabIndex = 8;
			txtpan.KeyDown += new System.Windows.Forms.KeyEventHandler(txtpan_KeyDown);
			lblweb.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblweb.Location = new System.Drawing.Point(8, 28);
			lblweb.Name = "lblweb";
			lblweb.Size = new System.Drawing.Size(65, 20);
			lblweb.TabIndex = 73;
			lblweb.Text = "Web";
			lblweb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lbltinno.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltinno.Location = new System.Drawing.Point(8, 136);
			lbltinno.Name = "lbltinno";
			lbltinno.Size = new System.Drawing.Size(65, 20);
			lbltinno.TabIndex = 72;
			lbltinno.Text = "Tin No";
			lbltinno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblcstno.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcstno.Location = new System.Drawing.Point(8, 163);
			lblcstno.Name = "lblcstno";
			lblcstno.Size = new System.Drawing.Size(65, 20);
			lblcstno.TabIndex = 71;
			lblcstno.Text = "Cst No";
			lblcstno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblmail.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblmail.Location = new System.Drawing.Point(8, 109);
			lblmail.Name = "lblmail";
			lblmail.Size = new System.Drawing.Size(65, 20);
			lblmail.TabIndex = 70;
			lblmail.Text = "Mail Id";
			lblmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblcstdate.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcstdate.Location = new System.Drawing.Point(8, 188);
			lblcstdate.Name = "lblcstdate";
			lblcstdate.Size = new System.Drawing.Size(65, 20);
			lblcstdate.TabIndex = 68;
			lblcstdate.Text = "Cst Date";
			lblcstdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblm1.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblm1.Location = new System.Drawing.Point(8, 82);
			lblm1.Name = "lblm1";
			lblm1.Size = new System.Drawing.Size(65, 20);
			lblm1.TabIndex = 67;
			lblm1.Text = "Mobile";
			lblm1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblphone.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblphone.Location = new System.Drawing.Point(8, 55);
			lblphone.Name = "lblphone";
			lblphone.Size = new System.Drawing.Size(65, 20);
			lblphone.TabIndex = 69;
			lblphone.Text = "Phone";
			lblphone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			txtweb.Location = new System.Drawing.Point(82, 28);
			txtweb.MaxLength = 50;
			txtweb.Name = "txtweb";
			txtweb.Size = new System.Drawing.Size(191, 22);
			txtweb.TabIndex = 0;
			txtweb.KeyDown += new System.Windows.Forms.KeyEventHandler(txtweb_KeyDown);
			chkdefault.AutoSize = true;
			chkdefault.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			chkdefault.Location = new System.Drawing.Point(82, 244);
			chkdefault.Name = "chkdefault";
			chkdefault.Size = new System.Drawing.Size(71, 18);
			chkdefault.TabIndex = 9;
			chkdefault.Text = "Default";
			chkdefault.UseVisualStyleBackColor = true;
			chkdefault.KeyDown += new System.Windows.Forms.KeyEventHandler(chkdefault_KeyDown);
			txttinno.Location = new System.Drawing.Point(82, 136);
			txttinno.MaxLength = 50;
			txttinno.Name = "txttinno";
			txttinno.Size = new System.Drawing.Size(191, 22);
			txttinno.TabIndex = 5;
			txttinno.KeyDown += new System.Windows.Forms.KeyEventHandler(txttinno_KeyDown);
			txtcstno.Location = new System.Drawing.Point(82, 163);
			txtcstno.MaxLength = 50;
			txtcstno.Name = "txtcstno";
			txtcstno.Size = new System.Drawing.Size(191, 22);
			txtcstno.TabIndex = 6;
			txtcstno.KeyDown += new System.Windows.Forms.KeyEventHandler(txtcstno_KeyDown);
			txtmail.Location = new System.Drawing.Point(82, 109);
			txtmail.MaxLength = 50;
			txtmail.Name = "txtmail";
			txtmail.Size = new System.Drawing.Size(191, 22);
			txtmail.TabIndex = 4;
			txtmail.KeyDown += new System.Windows.Forms.KeyEventHandler(txtmail_KeyDown);
			txtm2.Location = new System.Drawing.Point(181, 82);
			txtm2.Mask = "0000000000";
			txtm2.Name = "txtm2";
			txtm2.Size = new System.Drawing.Size(92, 22);
			txtm2.TabIndex = 3;
			txtm2.KeyDown += new System.Windows.Forms.KeyEventHandler(txtm2_KeyDown);
			txtm1.Location = new System.Drawing.Point(82, 82);
			txtm1.Mask = "0000000000";
			txtm1.Name = "txtm1";
			txtm1.Size = new System.Drawing.Size(93, 22);
			txtm1.TabIndex = 2;
			txtm1.KeyDown += new System.Windows.Forms.KeyEventHandler(txtm1_KeyDown);
			txtphone.Location = new System.Drawing.Point(82, 55);
			txtphone.Mask = "0000-0000000";
			txtphone.Name = "txtphone";
			txtphone.Size = new System.Drawing.Size(191, 22);
			txtphone.TabIndex = 1;
			txtphone.KeyDown += new System.Windows.Forms.KeyEventHandler(txtphone_KeyDown);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(1022, 470);
			base.Controls.Add(pnlentry);
			base.Controls.Add(pnlview);
			base.Controls.Add(a1Paneltitle);
			Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "frmCompany";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Tag = "MASTER";
			Text = "COMPANY";
			base.Load += new System.EventHandler(frmCompany_Load);
			pnlview.ResumeLayout(false);
			pnlview.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgview).EndInit();
			((System.ComponentModel.ISupportInitialize)companyBindingSource).EndInit();
			a1Paneltitle.ResumeLayout(false);
			a1Paneltitle.PerformLayout();
			pnlentry.ResumeLayout(false);
			tabemp.ResumeLayout(false);
			tabdetail.ResumeLayout(false);
			tabdetail.PerformLayout();
			tabadd.ResumeLayout(false);
			tabadd.PerformLayout();
			ResumeLayout(false);
		}
	}
}
