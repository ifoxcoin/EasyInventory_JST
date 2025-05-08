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
        private TabPage tabPage1;
        private TextBox txtBankName;
        private Label lblBankName;
        private Label lblAccNo;
        private TextBox txtBranch;
        private Label lblBranch;
        private TextBox txtAccNo;
        private TextBox txtGSTIN;
        private Label lblGSTIN;
        private TextBox txtFssai;
        private Label lblFssai;
        private TextBox txtCode;
        private Label label1;
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
            txtGSTIN.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtBranch.Text = string.Empty;
            txtFssai.Text = string.Empty;
            txtAccNo.Text = string.Empty;
            txtCode.Text = string.Empty;
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
                    txtGSTIN.Text = item.com_gstin;
                    txtBankName.Text = item.com_bankname;
                    txtBranch.Text = item.com_branch;
                    txtFssai.Text = item.com_fssai;
                    txtAccNo.Text = item.com_accountnumber;
                    txtCode.Text = item.com_code.ToString();
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
                cm.com_gstin = txtGSTIN.Text.Trim();
                cm.com_bankname = txtBankName.Text.Trim();
                cm.com_branch = txtBranch.Text.Trim();
                cm.com_fssai = txtFssai.Text.Trim();
                cm.com_accountnumber = txtAccNo.Text.Trim();
                cm.com_code = string.IsNullOrWhiteSpace(txtCode.Text) ? (int?)null : int.Parse(txtCode.Text.Trim());
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
						if (cm.com_default == 'N')
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
						inventoryDataContext.usp_companyInsert(cm.com_name, cm.com_add1, cm.com_add2, cm.com_add3, cm.com_city, cm.com_state, cm.com_country, cm.com_phone, cm.com_mobile1, cm.com_mobile2, cm.com_fax, cm.com_pin, cm.com_email, cm.com_web, cm.com_default, cm.com_tin, cm.com_cst, cm.com_cstdate, cm.com_pan, cm.com_gstin, cm.com_bankname, cm.com_branch, cm.com_fssai, cm.com_accountnumber, cm.com_code);
						MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_083f;
					}
				}
				else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					inventoryDataContext.usp_companyUpdate(id, cm.com_name, cm.com_add1, cm.com_add2, cm.com_add3, cm.com_city, cm.com_state, cm.com_country, cm.com_phone, cm.com_mobile1, cm.com_mobile2, cm.com_fax, cm.com_pin, cm.com_email, cm.com_web, cm.com_default, cm.com_tin, cm.com_cst, cm.com_cstdate, cm.com_pan, cm.com_gstin, cm.com_bankname, cm.com_branch, cm.com_fssai, cm.com_accountnumber, cm.com_code);
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

        private void com_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtpin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                tabemp.SelectedIndex = 1;
                txtweb.Focus();
            }
        }

        private void chkdefault_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
                tabemp.SelectedIndex = 2;
                txtBankName.Focus();
			}
		}

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompany));
            this.cmdclose = new mylib.lightbutton();
            this.pnlview = new mylib.a1panel();
            this.cmddelete = new mylib.lightbutton();
            this.cmdnew = new mylib.lightbutton();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comadd1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comadd2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comadd3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comstateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commobile1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commobile2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comfaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comemailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comwebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comdefaultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comtinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comcstdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbltitle = new System.Windows.Forms.Label();
            this.a1Paneltitle = new mylib.a1panel();
            this.pnlentry = new mylib.a1panel();
            this.cmdclear = new mylib.lightbutton();
            this.cmdsave = new mylib.lightbutton();
            this.tabemp = new System.Windows.Forms.TabControl();
            this.tabdetail = new System.Windows.Forms.TabPage();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFssai = new System.Windows.Forms.TextBox();
            this.lblFssai = new System.Windows.Forms.Label();
            this.txtGSTIN = new System.Windows.Forms.TextBox();
            this.lblGSTIN = new System.Windows.Forms.Label();
            this.txtfax = new System.Windows.Forms.TextBox();
            this.lblfax = new System.Windows.Forms.Label();
            this.txtpin = new System.Windows.Forms.MaskedTextBox();
            this.lblpin = new System.Windows.Forms.Label();
            this.txtcountry = new System.Windows.Forms.TextBox();
            this.lblcountry = new System.Windows.Forms.Label();
            this.txtstate = new System.Windows.Forms.TextBox();
            this.lblstate = new System.Windows.Forms.Label();
            this.txtcity = new System.Windows.Forms.TextBox();
            this.lblcity = new System.Windows.Forms.Label();
            this.txtadd2 = new System.Windows.Forms.TextBox();
            this.txtadd1 = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.txtcompany = new System.Windows.Forms.TextBox();
            this.lblcompany = new System.Windows.Forms.Label();
            this.tabadd = new System.Windows.Forms.TabPage();
            this.dtpcstdate = new System.Windows.Forms.DateTimePicker();
            this.lblpan = new System.Windows.Forms.Label();
            this.txtpan = new System.Windows.Forms.TextBox();
            this.lblweb = new System.Windows.Forms.Label();
            this.lbltinno = new System.Windows.Forms.Label();
            this.lblcstno = new System.Windows.Forms.Label();
            this.lblmail = new System.Windows.Forms.Label();
            this.lblcstdate = new System.Windows.Forms.Label();
            this.lblm1 = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.txtweb = new System.Windows.Forms.TextBox();
            this.chkdefault = new System.Windows.Forms.CheckBox();
            this.txttinno = new System.Windows.Forms.TextBox();
            this.txtcstno = new System.Windows.Forms.TextBox();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.txtm2 = new System.Windows.Forms.MaskedTextBox();
            this.txtm1 = new System.Windows.Forms.MaskedTextBox();
            this.txtphone = new System.Windows.Forms.MaskedTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.lblAccNo = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.pnlview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.a1Paneltitle.SuspendLayout();
            this.pnlentry.SuspendLayout();
            this.tabemp.SuspendLayout();
            this.tabdetail.SuspendLayout();
            this.tabadd.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdclose
            // 
            this.cmdclose.AutoSize = true;
            this.cmdclose.BackColor = System.Drawing.Color.Transparent;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(226, 11);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(90, 32);
            this.cmdclose.TabIndex = 2;
            this.cmdclose.Text = "&Close";
            this.cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdclose.UseVisualStyleBackColor = false;
            this.cmdclose.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // pnlview
            // 
            this.pnlview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.pnlview.BorderColor = System.Drawing.Color.Gray;
            this.pnlview.Controls.Add(this.cmdclose);
            this.pnlview.Controls.Add(this.cmddelete);
            this.pnlview.Controls.Add(this.cmdnew);
            this.pnlview.Controls.Add(this.dgview);
            this.pnlview.GradientEndColor = System.Drawing.Color.White;
            this.pnlview.GradientStartColor = System.Drawing.Color.White;
            this.pnlview.Image = null;
            this.pnlview.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlview.Location = new System.Drawing.Point(319, 46);
            this.pnlview.Name = "pnlview";
            this.pnlview.RoundCornerRadius = 25;
            this.pnlview.ShadowOffSet = 0;
            this.pnlview.Size = new System.Drawing.Size(691, 414);
            this.pnlview.TabIndex = 4;
            // 
            // cmddelete
            // 
            this.cmddelete.AutoSize = true;
            this.cmddelete.BackColor = System.Drawing.Color.Transparent;
            this.cmddelete.Enabled = false;
            this.cmddelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmddelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmddelete.Location = new System.Drawing.Point(130, 11);
            this.cmddelete.Name = "cmddelete";
            this.cmddelete.Size = new System.Drawing.Size(90, 32);
            this.cmddelete.TabIndex = 1;
            this.cmddelete.Text = "&Delete";
            this.cmddelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmddelete.UseVisualStyleBackColor = false;
            this.cmddelete.Click += new System.EventHandler(this.cmddelete_Click);
            // 
            // cmdnew
            // 
            this.cmdnew.AutoSize = true;
            this.cmdnew.BackColor = System.Drawing.Color.Transparent;
            this.cmdnew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdnew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdnew.Location = new System.Drawing.Point(34, 11);
            this.cmdnew.Name = "cmdnew";
            this.cmdnew.Size = new System.Drawing.Size(90, 32);
            this.cmdnew.TabIndex = 0;
            this.cmdnew.Text = "&New";
            this.cmdnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdnew.UseVisualStyleBackColor = false;
            this.cmdnew.Click += new System.EventHandler(this.cmdnew_Click);
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview.AutoGenerateColumns = false;
            this.dgview.BackgroundColor = System.Drawing.Color.White;
            this.dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comidDataGridViewTextBoxColumn,
            this.comnameDataGridViewTextBoxColumn,
            this.comadd1DataGridViewTextBoxColumn,
            this.comadd2DataGridViewTextBoxColumn,
            this.comadd3DataGridViewTextBoxColumn,
            this.comcityDataGridViewTextBoxColumn,
            this.comstateDataGridViewTextBoxColumn,
            this.comcountryDataGridViewTextBoxColumn,
            this.comphoneDataGridViewTextBoxColumn,
            this.commobile1DataGridViewTextBoxColumn,
            this.commobile2DataGridViewTextBoxColumn,
            this.comfaxDataGridViewTextBoxColumn,
            this.compinDataGridViewTextBoxColumn,
            this.comemailDataGridViewTextBoxColumn,
            this.comwebDataGridViewTextBoxColumn,
            this.comdefaultDataGridViewTextBoxColumn,
            this.comtinDataGridViewTextBoxColumn,
            this.comcstDataGridViewTextBoxColumn,
            this.comcstdateDataGridViewTextBoxColumn,
            this.companDataGridViewTextBoxColumn});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.companyBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(1, 45);
            this.dgview.MultiSelect = false;
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgview.RowHeadersVisible = false;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(687, 366);
            this.dgview.TabIndex = 3;
            this.dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgunit_CellDoubleClick);
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
            this.comnameDataGridViewTextBoxColumn.Width = 250;
            // 
            // comadd1DataGridViewTextBoxColumn
            // 
            this.comadd1DataGridViewTextBoxColumn.DataPropertyName = "com_add1";
            this.comadd1DataGridViewTextBoxColumn.HeaderText = "com_add1";
            this.comadd1DataGridViewTextBoxColumn.Name = "comadd1DataGridViewTextBoxColumn";
            this.comadd1DataGridViewTextBoxColumn.ReadOnly = true;
            this.comadd1DataGridViewTextBoxColumn.Visible = false;
            // 
            // comadd2DataGridViewTextBoxColumn
            // 
            this.comadd2DataGridViewTextBoxColumn.DataPropertyName = "com_add2";
            this.comadd2DataGridViewTextBoxColumn.HeaderText = "com_add2";
            this.comadd2DataGridViewTextBoxColumn.Name = "comadd2DataGridViewTextBoxColumn";
            this.comadd2DataGridViewTextBoxColumn.ReadOnly = true;
            this.comadd2DataGridViewTextBoxColumn.Visible = false;
            // 
            // comadd3DataGridViewTextBoxColumn
            // 
            this.comadd3DataGridViewTextBoxColumn.DataPropertyName = "com_add3";
            this.comadd3DataGridViewTextBoxColumn.HeaderText = "com_add3";
            this.comadd3DataGridViewTextBoxColumn.Name = "comadd3DataGridViewTextBoxColumn";
            this.comadd3DataGridViewTextBoxColumn.ReadOnly = true;
            this.comadd3DataGridViewTextBoxColumn.Visible = false;
            // 
            // comcityDataGridViewTextBoxColumn
            // 
            this.comcityDataGridViewTextBoxColumn.DataPropertyName = "com_city";
            this.comcityDataGridViewTextBoxColumn.HeaderText = "City";
            this.comcityDataGridViewTextBoxColumn.Name = "comcityDataGridViewTextBoxColumn";
            this.comcityDataGridViewTextBoxColumn.ReadOnly = true;
            this.comcityDataGridViewTextBoxColumn.Width = 200;
            // 
            // comstateDataGridViewTextBoxColumn
            // 
            this.comstateDataGridViewTextBoxColumn.DataPropertyName = "com_state";
            this.comstateDataGridViewTextBoxColumn.HeaderText = "State";
            this.comstateDataGridViewTextBoxColumn.Name = "comstateDataGridViewTextBoxColumn";
            this.comstateDataGridViewTextBoxColumn.ReadOnly = true;
            this.comstateDataGridViewTextBoxColumn.Visible = false;
            this.comstateDataGridViewTextBoxColumn.Width = 200;
            // 
            // comcountryDataGridViewTextBoxColumn
            // 
            this.comcountryDataGridViewTextBoxColumn.DataPropertyName = "com_country";
            this.comcountryDataGridViewTextBoxColumn.HeaderText = "com_country";
            this.comcountryDataGridViewTextBoxColumn.Name = "comcountryDataGridViewTextBoxColumn";
            this.comcountryDataGridViewTextBoxColumn.ReadOnly = true;
            this.comcountryDataGridViewTextBoxColumn.Visible = false;
            // 
            // comphoneDataGridViewTextBoxColumn
            // 
            this.comphoneDataGridViewTextBoxColumn.DataPropertyName = "com_phone";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            this.comphoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.comphoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.comphoneDataGridViewTextBoxColumn.Name = "comphoneDataGridViewTextBoxColumn";
            this.comphoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.comphoneDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.comphoneDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // commobile1DataGridViewTextBoxColumn
            // 
            this.commobile1DataGridViewTextBoxColumn.DataPropertyName = "com_mobile1";
            this.commobile1DataGridViewTextBoxColumn.HeaderText = "Mobile";
            this.commobile1DataGridViewTextBoxColumn.Name = "commobile1DataGridViewTextBoxColumn";
            this.commobile1DataGridViewTextBoxColumn.ReadOnly = true;
            this.commobile1DataGridViewTextBoxColumn.Visible = false;
            // 
            // commobile2DataGridViewTextBoxColumn
            // 
            this.commobile2DataGridViewTextBoxColumn.DataPropertyName = "com_mobile2";
            this.commobile2DataGridViewTextBoxColumn.HeaderText = "com_mobile2";
            this.commobile2DataGridViewTextBoxColumn.Name = "commobile2DataGridViewTextBoxColumn";
            this.commobile2DataGridViewTextBoxColumn.ReadOnly = true;
            this.commobile2DataGridViewTextBoxColumn.Visible = false;
            // 
            // comfaxDataGridViewTextBoxColumn
            // 
            this.comfaxDataGridViewTextBoxColumn.DataPropertyName = "com_fax";
            this.comfaxDataGridViewTextBoxColumn.HeaderText = "com_fax";
            this.comfaxDataGridViewTextBoxColumn.Name = "comfaxDataGridViewTextBoxColumn";
            this.comfaxDataGridViewTextBoxColumn.ReadOnly = true;
            this.comfaxDataGridViewTextBoxColumn.Visible = false;
            // 
            // compinDataGridViewTextBoxColumn
            // 
            this.compinDataGridViewTextBoxColumn.DataPropertyName = "com_pin";
            this.compinDataGridViewTextBoxColumn.HeaderText = "com_pin";
            this.compinDataGridViewTextBoxColumn.Name = "compinDataGridViewTextBoxColumn";
            this.compinDataGridViewTextBoxColumn.ReadOnly = true;
            this.compinDataGridViewTextBoxColumn.Visible = false;
            // 
            // comemailDataGridViewTextBoxColumn
            // 
            this.comemailDataGridViewTextBoxColumn.DataPropertyName = "com_email";
            this.comemailDataGridViewTextBoxColumn.HeaderText = "com_email";
            this.comemailDataGridViewTextBoxColumn.Name = "comemailDataGridViewTextBoxColumn";
            this.comemailDataGridViewTextBoxColumn.ReadOnly = true;
            this.comemailDataGridViewTextBoxColumn.Visible = false;
            // 
            // comwebDataGridViewTextBoxColumn
            // 
            this.comwebDataGridViewTextBoxColumn.DataPropertyName = "com_web";
            this.comwebDataGridViewTextBoxColumn.HeaderText = "com_web";
            this.comwebDataGridViewTextBoxColumn.Name = "comwebDataGridViewTextBoxColumn";
            this.comwebDataGridViewTextBoxColumn.ReadOnly = true;
            this.comwebDataGridViewTextBoxColumn.Visible = false;
            // 
            // comdefaultDataGridViewTextBoxColumn
            // 
            this.comdefaultDataGridViewTextBoxColumn.DataPropertyName = "com_default";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.comdefaultDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.comdefaultDataGridViewTextBoxColumn.HeaderText = "Default";
            this.comdefaultDataGridViewTextBoxColumn.Name = "comdefaultDataGridViewTextBoxColumn";
            this.comdefaultDataGridViewTextBoxColumn.ReadOnly = true;
            this.comdefaultDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.comdefaultDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.comdefaultDataGridViewTextBoxColumn.Width = 70;
            // 
            // comtinDataGridViewTextBoxColumn
            // 
            this.comtinDataGridViewTextBoxColumn.DataPropertyName = "com_tin";
            this.comtinDataGridViewTextBoxColumn.HeaderText = "com_tin";
            this.comtinDataGridViewTextBoxColumn.Name = "comtinDataGridViewTextBoxColumn";
            this.comtinDataGridViewTextBoxColumn.ReadOnly = true;
            this.comtinDataGridViewTextBoxColumn.Visible = false;
            // 
            // comcstDataGridViewTextBoxColumn
            // 
            this.comcstDataGridViewTextBoxColumn.DataPropertyName = "com_cst";
            this.comcstDataGridViewTextBoxColumn.HeaderText = "com_cst";
            this.comcstDataGridViewTextBoxColumn.Name = "comcstDataGridViewTextBoxColumn";
            this.comcstDataGridViewTextBoxColumn.ReadOnly = true;
            this.comcstDataGridViewTextBoxColumn.Visible = false;
            // 
            // comcstdateDataGridViewTextBoxColumn
            // 
            this.comcstdateDataGridViewTextBoxColumn.DataPropertyName = "com_cstdate";
            this.comcstdateDataGridViewTextBoxColumn.HeaderText = "com_cstdate";
            this.comcstdateDataGridViewTextBoxColumn.Name = "comcstdateDataGridViewTextBoxColumn";
            this.comcstdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.comcstdateDataGridViewTextBoxColumn.Visible = false;
            // 
            // companDataGridViewTextBoxColumn
            // 
            this.companDataGridViewTextBoxColumn.DataPropertyName = "com_pan";
            this.companDataGridViewTextBoxColumn.HeaderText = "com_pan";
            this.companDataGridViewTextBoxColumn.Name = "companDataGridViewTextBoxColumn";
            this.companDataGridViewTextBoxColumn.ReadOnly = true;
            this.companDataGridViewTextBoxColumn.Visible = false;
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(standard.classes.company);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(25, 6);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(130, 28);
            this.lbltitle.TabIndex = 1;
            this.lbltitle.Text = "COMPANY";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.a1Paneltitle.Location = new System.Drawing.Point(5, 11);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1005, 29);
            this.a1Paneltitle.TabIndex = 5;
            // 
            // pnlentry
            // 
            this.pnlentry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlentry.BorderColor = System.Drawing.Color.Gray;
            this.pnlentry.Controls.Add(this.cmdclear);
            this.pnlentry.Controls.Add(this.cmdsave);
            this.pnlentry.Controls.Add(this.tabemp);
            this.pnlentry.Enabled = false;
            this.pnlentry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlentry.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.pnlentry.GradientStartColor = System.Drawing.Color.WhiteSmoke;
            this.pnlentry.Image = null;
            this.pnlentry.ImageLocation = new System.Drawing.Point(4, 4);
            this.pnlentry.Location = new System.Drawing.Point(5, 46);
            this.pnlentry.Name = "pnlentry";
            this.pnlentry.RoundCornerRadius = 25;
            this.pnlentry.ShadowOffSet = 0;
            this.pnlentry.Size = new System.Drawing.Size(301, 414);
            this.pnlentry.TabIndex = 6;
            // 
            // cmdclear
            // 
            this.cmdclear.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclear.Location = new System.Drawing.Point(202, 12);
            this.cmdclear.Name = "cmdclear";
            this.cmdclear.Size = new System.Drawing.Size(90, 30);
            this.cmdclear.TabIndex = 2;
            this.cmdclear.Text = "Cl&ear";
            this.cmdclear.UseVisualStyleBackColor = true;
            this.cmdclear.Click += new System.EventHandler(this.cmdclear_Click);
            // 
            // cmdsave
            // 
            this.cmdsave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdsave.Location = new System.Drawing.Point(106, 11);
            this.cmdsave.Name = "cmdsave";
            this.cmdsave.Size = new System.Drawing.Size(90, 30);
            this.cmdsave.TabIndex = 1;
            this.cmdsave.Text = "&Update";
            this.cmdsave.UseVisualStyleBackColor = true;
            this.cmdsave.Click += new System.EventHandler(this.cmdsave_Click);
            // 
            // tabemp
            // 
            this.tabemp.Controls.Add(this.tabdetail);
            this.tabemp.Controls.Add(this.tabadd);
            this.tabemp.Controls.Add(this.tabPage1);
            this.tabemp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.tabemp.HotTrack = true;
            this.tabemp.Location = new System.Drawing.Point(7, 48);
            this.tabemp.Name = "tabemp";
            this.tabemp.SelectedIndex = 0;
            this.tabemp.Size = new System.Drawing.Size(290, 353);
            this.tabemp.TabIndex = 0;
            // 
            // tabdetail
            // 
            this.tabdetail.Controls.Add(this.txtCode);
            this.tabdetail.Controls.Add(this.label1);
            this.tabdetail.Controls.Add(this.txtFssai);
            this.tabdetail.Controls.Add(this.lblFssai);
            this.tabdetail.Controls.Add(this.txtGSTIN);
            this.tabdetail.Controls.Add(this.lblGSTIN);
            this.tabdetail.Controls.Add(this.txtfax);
            this.tabdetail.Controls.Add(this.lblfax);
            this.tabdetail.Controls.Add(this.txtpin);
            this.tabdetail.Controls.Add(this.lblpin);
            this.tabdetail.Controls.Add(this.txtcountry);
            this.tabdetail.Controls.Add(this.lblcountry);
            this.tabdetail.Controls.Add(this.txtstate);
            this.tabdetail.Controls.Add(this.lblstate);
            this.tabdetail.Controls.Add(this.txtcity);
            this.tabdetail.Controls.Add(this.lblcity);
            this.tabdetail.Controls.Add(this.txtadd2);
            this.tabdetail.Controls.Add(this.txtadd1);
            this.tabdetail.Controls.Add(this.lbladdress);
            this.tabdetail.Controls.Add(this.txtcompany);
            this.tabdetail.Controls.Add(this.lblcompany);
            this.tabdetail.Location = new System.Drawing.Point(4, 31);
            this.tabdetail.Name = "tabdetail";
            this.tabdetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabdetail.Size = new System.Drawing.Size(282, 318);
            this.tabdetail.TabIndex = 0;
            this.tabdetail.Text = "Details";
            this.tabdetail.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtCode.Location = new System.Drawing.Point(111, 190);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(165, 29);
            this.txtCode.TabIndex = 6;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(6, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 72;
            this.label1.Text = "Code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFssai
            // 
            this.txtFssai.BackColor = System.Drawing.Color.White;
            this.txtFssai.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtFssai.Location = new System.Drawing.Point(111, 270);
            this.txtFssai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFssai.MaxLength = 50;
            this.txtFssai.Name = "txtFssai";
            this.txtFssai.Size = new System.Drawing.Size(165, 29);
            this.txtFssai.TabIndex = 9;
            this.txtFssai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblFssai
            // 
            this.lblFssai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblFssai.Location = new System.Drawing.Point(6, 270);
            this.lblFssai.Name = "lblFssai";
            this.lblFssai.Size = new System.Drawing.Size(100, 20);
            this.lblFssai.TabIndex = 70;
            this.lblFssai.Text = "Fssai";
            this.lblFssai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGSTIN
            // 
            this.txtGSTIN.BackColor = System.Drawing.Color.White;
            this.txtGSTIN.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtGSTIN.Location = new System.Drawing.Point(111, 242);
            this.txtGSTIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGSTIN.MaxLength = 50;
            this.txtGSTIN.Name = "txtGSTIN";
            this.txtGSTIN.Size = new System.Drawing.Size(165, 29);
            this.txtGSTIN.TabIndex = 8;
            this.txtGSTIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblGSTIN
            // 
            this.lblGSTIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblGSTIN.Location = new System.Drawing.Point(6, 242);
            this.lblGSTIN.Name = "lblGSTIN";
            this.lblGSTIN.Size = new System.Drawing.Size(100, 20);
            this.lblGSTIN.TabIndex = 68;
            this.lblGSTIN.Text = "GSTIN";
            this.lblGSTIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtfax
            // 
            this.txtfax.Location = new System.Drawing.Point(111, 219);
            this.txtfax.Name = "txtfax";
            this.txtfax.Size = new System.Drawing.Size(165, 29);
            this.txtfax.TabIndex = 7;
            this.txtfax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblfax
            // 
            this.lblfax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblfax.Location = new System.Drawing.Point(6, 219);
            this.lblfax.Name = "lblfax";
            this.lblfax.Size = new System.Drawing.Size(100, 20);
            this.lblfax.TabIndex = 67;
            this.lblfax.Text = "Fax";
            this.lblfax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpin
            // 
            this.txtpin.Location = new System.Drawing.Point(111, 291);
            this.txtpin.Mask = "000-000";
            this.txtpin.Name = "txtpin";
            this.txtpin.Size = new System.Drawing.Size(165, 29);
            this.txtpin.TabIndex = 10;
            this.txtpin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpin_KeyDown);
            // 
            // lblpin
            // 
            this.lblpin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblpin.Location = new System.Drawing.Point(6, 295);
            this.lblpin.Name = "lblpin";
            this.lblpin.Size = new System.Drawing.Size(100, 20);
            this.lblpin.TabIndex = 66;
            this.lblpin.Text = "Pin";
            this.lblpin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcountry
            // 
            this.txtcountry.Location = new System.Drawing.Point(111, 163);
            this.txtcountry.MaxLength = 50;
            this.txtcountry.Name = "txtcountry";
            this.txtcountry.Size = new System.Drawing.Size(165, 29);
            this.txtcountry.TabIndex = 5;
            this.txtcountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblcountry
            // 
            this.lblcountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblcountry.Location = new System.Drawing.Point(6, 163);
            this.lblcountry.Name = "lblcountry";
            this.lblcountry.Size = new System.Drawing.Size(100, 20);
            this.lblcountry.TabIndex = 65;
            this.lblcountry.Text = "Country";
            this.lblcountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtstate
            // 
            this.txtstate.Location = new System.Drawing.Point(111, 135);
            this.txtstate.MaxLength = 50;
            this.txtstate.Name = "txtstate";
            this.txtstate.Size = new System.Drawing.Size(165, 29);
            this.txtstate.TabIndex = 4;
            this.txtstate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblstate
            // 
            this.lblstate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblstate.Location = new System.Drawing.Point(6, 135);
            this.lblstate.Name = "lblstate";
            this.lblstate.Size = new System.Drawing.Size(100, 20);
            this.lblstate.TabIndex = 64;
            this.lblstate.Text = "State";
            this.lblstate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcity
            // 
            this.txtcity.Location = new System.Drawing.Point(111, 106);
            this.txtcity.MaxLength = 50;
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(165, 29);
            this.txtcity.TabIndex = 3;
            this.txtcity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblcity
            // 
            this.lblcity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblcity.Location = new System.Drawing.Point(6, 106);
            this.lblcity.Name = "lblcity";
            this.lblcity.Size = new System.Drawing.Size(100, 20);
            this.lblcity.TabIndex = 63;
            this.lblcity.Text = "City";
            this.lblcity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtadd2
            // 
            this.txtadd2.Location = new System.Drawing.Point(111, 77);
            this.txtadd2.MaxLength = 50;
            this.txtadd2.Name = "txtadd2";
            this.txtadd2.Size = new System.Drawing.Size(165, 29);
            this.txtadd2.TabIndex = 2;
            this.txtadd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // txtadd1
            // 
            this.txtadd1.Location = new System.Drawing.Point(111, 49);
            this.txtadd1.MaxLength = 50;
            this.txtadd1.Name = "txtadd1";
            this.txtadd1.Size = new System.Drawing.Size(165, 29);
            this.txtadd1.TabIndex = 1;
            this.txtadd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lbladdress
            // 
            this.lbladdress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbladdress.Location = new System.Drawing.Point(6, 49);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(82, 20);
            this.lbladdress.TabIndex = 62;
            this.lbladdress.Text = "Address";
            this.lbladdress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcompany
            // 
            this.txtcompany.Location = new System.Drawing.Point(111, 21);
            this.txtcompany.MaxLength = 100;
            this.txtcompany.Name = "txtcompany";
            this.txtcompany.Size = new System.Drawing.Size(165, 29);
            this.txtcompany.TabIndex = 0;
            this.txtcompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            this.txtcompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtupper_KeyPress);
            // 
            // lblcompany
            // 
            this.lblcompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblcompany.Location = new System.Drawing.Point(6, 21);
            this.lblcompany.Name = "lblcompany";
            this.lblcompany.Size = new System.Drawing.Size(99, 20);
            this.lblcompany.TabIndex = 54;
            this.lblcompany.Text = "Company Name";
            this.lblcompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabadd
            // 
            this.tabadd.Controls.Add(this.dtpcstdate);
            this.tabadd.Controls.Add(this.lblpan);
            this.tabadd.Controls.Add(this.txtpan);
            this.tabadd.Controls.Add(this.lblweb);
            this.tabadd.Controls.Add(this.lbltinno);
            this.tabadd.Controls.Add(this.lblcstno);
            this.tabadd.Controls.Add(this.lblmail);
            this.tabadd.Controls.Add(this.lblcstdate);
            this.tabadd.Controls.Add(this.lblm1);
            this.tabadd.Controls.Add(this.lblphone);
            this.tabadd.Controls.Add(this.txtweb);
            this.tabadd.Controls.Add(this.chkdefault);
            this.tabadd.Controls.Add(this.txttinno);
            this.tabadd.Controls.Add(this.txtcstno);
            this.tabadd.Controls.Add(this.txtmail);
            this.tabadd.Controls.Add(this.txtm2);
            this.tabadd.Controls.Add(this.txtm1);
            this.tabadd.Controls.Add(this.txtphone);
            this.tabadd.Location = new System.Drawing.Point(4, 31);
            this.tabadd.Name = "tabadd";
            this.tabadd.Padding = new System.Windows.Forms.Padding(3);
            this.tabadd.Size = new System.Drawing.Size(282, 318);
            this.tabadd.TabIndex = 1;
            this.tabadd.Text = "Address";
            this.tabadd.UseVisualStyleBackColor = true;
            // 
            // dtpcstdate
            // 
            this.dtpcstdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpcstdate.CustomFormat = "dd-MM-yyyy";
            this.dtpcstdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpcstdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpcstdate.Location = new System.Drawing.Point(82, 191);
            this.dtpcstdate.Name = "dtpcstdate";
            this.dtpcstdate.ShowCheckBox = true;
            this.dtpcstdate.Size = new System.Drawing.Size(108, 27);
            this.dtpcstdate.TabIndex = 7;
            this.dtpcstdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblpan
            // 
            this.lblpan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblpan.Location = new System.Drawing.Point(8, 216);
            this.lblpan.Name = "lblpan";
            this.lblpan.Size = new System.Drawing.Size(65, 20);
            this.lblpan.TabIndex = 74;
            this.lblpan.Text = "Pan";
            this.lblpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtpan
            // 
            this.txtpan.Location = new System.Drawing.Point(82, 216);
            this.txtpan.MaxLength = 50;
            this.txtpan.Name = "txtpan";
            this.txtpan.Size = new System.Drawing.Size(191, 29);
            this.txtpan.TabIndex = 8;
            this.txtpan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblweb
            // 
            this.lblweb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblweb.Location = new System.Drawing.Point(8, 28);
            this.lblweb.Name = "lblweb";
            this.lblweb.Size = new System.Drawing.Size(65, 20);
            this.lblweb.TabIndex = 73;
            this.lblweb.Text = "Web";
            this.lblweb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltinno
            // 
            this.lbltinno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltinno.Location = new System.Drawing.Point(8, 136);
            this.lbltinno.Name = "lbltinno";
            this.lbltinno.Size = new System.Drawing.Size(65, 20);
            this.lbltinno.TabIndex = 72;
            this.lbltinno.Text = "Tin No";
            this.lbltinno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblcstno
            // 
            this.lblcstno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblcstno.Location = new System.Drawing.Point(8, 163);
            this.lblcstno.Name = "lblcstno";
            this.lblcstno.Size = new System.Drawing.Size(65, 20);
            this.lblcstno.TabIndex = 71;
            this.lblcstno.Text = "Cst No";
            this.lblcstno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblmail
            // 
            this.lblmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblmail.Location = new System.Drawing.Point(8, 109);
            this.lblmail.Name = "lblmail";
            this.lblmail.Size = new System.Drawing.Size(65, 20);
            this.lblmail.TabIndex = 70;
            this.lblmail.Text = "Mail Id";
            this.lblmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblcstdate
            // 
            this.lblcstdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblcstdate.Location = new System.Drawing.Point(8, 188);
            this.lblcstdate.Name = "lblcstdate";
            this.lblcstdate.Size = new System.Drawing.Size(65, 20);
            this.lblcstdate.TabIndex = 68;
            this.lblcstdate.Text = "Cst Date";
            this.lblcstdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblm1
            // 
            this.lblm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblm1.Location = new System.Drawing.Point(8, 82);
            this.lblm1.Name = "lblm1";
            this.lblm1.Size = new System.Drawing.Size(65, 20);
            this.lblm1.TabIndex = 67;
            this.lblm1.Text = "Mobile";
            this.lblm1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblphone
            // 
            this.lblphone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblphone.Location = new System.Drawing.Point(8, 55);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(65, 20);
            this.lblphone.TabIndex = 69;
            this.lblphone.Text = "Phone";
            this.lblphone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtweb
            // 
            this.txtweb.Location = new System.Drawing.Point(82, 28);
            this.txtweb.MaxLength = 50;
            this.txtweb.Name = "txtweb";
            this.txtweb.Size = new System.Drawing.Size(191, 29);
            this.txtweb.TabIndex = 0;
            this.txtweb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // chkdefault
            // 
            this.chkdefault.AutoSize = true;
            this.chkdefault.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.chkdefault.Location = new System.Drawing.Point(82, 244);
            this.chkdefault.Name = "chkdefault";
            this.chkdefault.Size = new System.Drawing.Size(103, 26);
            this.chkdefault.TabIndex = 9;
            this.chkdefault.Text = "Default";
            this.chkdefault.UseVisualStyleBackColor = true;
            this.chkdefault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkdefault_KeyDown);
            // 
            // txttinno
            // 
            this.txttinno.Location = new System.Drawing.Point(82, 136);
            this.txttinno.MaxLength = 50;
            this.txttinno.Name = "txttinno";
            this.txttinno.Size = new System.Drawing.Size(191, 29);
            this.txttinno.TabIndex = 5;
            this.txttinno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // txtcstno
            // 
            this.txtcstno.Location = new System.Drawing.Point(82, 163);
            this.txtcstno.MaxLength = 50;
            this.txtcstno.Name = "txtcstno";
            this.txtcstno.Size = new System.Drawing.Size(191, 29);
            this.txtcstno.TabIndex = 6;
            this.txtcstno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(82, 109);
            this.txtmail.MaxLength = 50;
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(191, 29);
            this.txtmail.TabIndex = 4;
            this.txtmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // txtm2
            // 
            this.txtm2.Location = new System.Drawing.Point(181, 82);
            this.txtm2.Mask = "0000000000";
            this.txtm2.Name = "txtm2";
            this.txtm2.Size = new System.Drawing.Size(92, 29);
            this.txtm2.TabIndex = 3;
            this.txtm2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // txtm1
            // 
            this.txtm1.Location = new System.Drawing.Point(82, 82);
            this.txtm1.Mask = "0000000000";
            this.txtm1.Name = "txtm1";
            this.txtm1.Size = new System.Drawing.Size(93, 29);
            this.txtm1.TabIndex = 2;
            this.txtm1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(82, 55);
            this.txtphone.Mask = "0000-0000000";
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(191, 29);
            this.txtphone.TabIndex = 1;
            this.txtphone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBranch);
            this.tabPage1.Controls.Add(this.lblBranch);
            this.tabPage1.Controls.Add(this.txtAccNo);
            this.tabPage1.Controls.Add(this.lblAccNo);
            this.tabPage1.Controls.Add(this.txtBankName);
            this.tabPage1.Controls.Add(this.lblBankName);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(282, 318);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Bank Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(95, 95);
            this.txtBranch.MaxLength = 100;
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(181, 29);
            this.txtBranch.TabIndex = 2;
            this.txtBranch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBranch_KeyDown);
            // 
            // lblBranch
            // 
            this.lblBranch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblBranch.Location = new System.Drawing.Point(6, 85);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(80, 49);
            this.lblBranch.TabIndex = 60;
            this.lblBranch.Text = "Branch & IFSC";
            this.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAccNo
            // 
            this.txtAccNo.BackColor = System.Drawing.Color.White;
            this.txtAccNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtAccNo.Location = new System.Drawing.Point(95, 65);
            this.txtAccNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccNo.MaxLength = 50;
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(180, 29);
            this.txtAccNo.TabIndex = 1;
            this.txtAccNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblAccNo
            // 
            this.lblAccNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblAccNo.Location = new System.Drawing.Point(6, 65);
            this.lblAccNo.Name = "lblAccNo";
            this.lblAccNo.Size = new System.Drawing.Size(99, 20);
            this.lblAccNo.TabIndex = 58;
            this.lblAccNo.Text = "A/C No.";
            this.lblAccNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(95, 33);
            this.txtBankName.MaxLength = 100;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(181, 29);
            this.txtBankName.TabIndex = 0;
            this.txtBankName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.com_KeyDown);
            // 
            // lblBankName
            // 
            this.lblBankName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblBankName.Location = new System.Drawing.Point(6, 37);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(99, 20);
            this.lblBankName.TabIndex = 55;
            this.lblBankName.Text = "Bank Name";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1022, 470);
            this.Controls.Add(this.pnlentry);
            this.Controls.Add(this.pnlview);
            this.Controls.Add(this.a1Paneltitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompany";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Tag = "MASTER";
            this.Text = "COMPANY";
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.pnlview.ResumeLayout(false);
            this.pnlview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.pnlentry.ResumeLayout(false);
            this.tabemp.ResumeLayout(false);
            this.tabdetail.ResumeLayout(false);
            this.tabdetail.PerformLayout();
            this.tabadd.ResumeLayout(false);
            this.tabadd.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}
    }
}
