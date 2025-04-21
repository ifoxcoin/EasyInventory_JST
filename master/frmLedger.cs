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
	public class frmLedger : Form
	{
		private int id;

		private int CountofLedgers = 0;

		private IContainer components = null;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private TableLayoutPanel tblMain;

		private TableLayoutPanel tblEntry;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private lightbutton cmdclose;

		private TextBox txtTamilPartyName;

		private TextBox txtPartyName;

		private TextBox txtAdd1;

		private TextBox txtAdd2;

		private TextBox txtTamilAdd1;

		private TextBox txtTamilAdd2;

		private TextBox txtTamilAdd3;

		private ComboBox cboType;

		private DataGridView dgview;

		private TableLayoutPanel tblSearch;

		private TextBox txtSearch;

		private Label label10;

		private TableLayoutPanel tblCommand;

		private lightbutton btnClear;

		private lightbutton btnDelete;

		private lightbutton btnSave;

		private Label lblSearch;

		private Label label11;

		private TextBox txtAdd3;

		private TextBox txtPin;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label15;

		private TextBox txtTransport;

		private Label label16;

		private Label label17;

		private Label label18;

		private Label label19;

		private Label label21;

		private TextBox txtOwnerName;

		private TextBox txtManagerName;

		private TextBox txtOwnerPhone;

		private TextBox txtManagerPhone;

		private TextBox txtTin;

		private Label lbltamil;

		private TextBox txtCst;

		private BindingSource uspledgermasterSelectResultBindingSource;

		private Label lblref;

		private ComboBox cboReference;

		private Label label20;

		private TextBox txtSearchbyCity;

		private Label label22;

		private ComboBox cboratetype;

		private BindingSource ledgermasterBindingSource;

		private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledaccountcodeDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledaccounttypeDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledaddressDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledaddress1DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledaddress2DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledtnameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledtaddressDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledtaddress1DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledtaddress2DataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledpincodeDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledtransportDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledownernameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledownerphoneDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledmanagernameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledmanagerphoneDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledtinDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledcstDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn ledrefnoDataGridViewTextBoxColumn;

		private Label label23;

		private decimalbox txtDisPer;

		private Label label24;

		private ComboBox cboGridReference;

		private BindingSource ledgermasterBindingSource1;

		private Label lblCount;
        private CheckBox cbIsFreight;
        private TextBox txtCode;

		public frmLedger()
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
			cboratetype.SelectedIndex = 0;
			txtPartyName.Text = string.Empty;
			txtCode.Text = string.Empty;
			cboType.SelectedIndex = -1;
			cboGridReference.SelectedIndex = 0;
			txtAdd1.Text = string.Empty;
			txtAdd2.Text = string.Empty;
			txtAdd3.Text = string.Empty;
			txtPin.Text = string.Empty;
			txtTransport.Text = string.Empty;
			txtOwnerName.Text = string.Empty;
			txtOwnerPhone.Text = string.Empty;
			txtManagerName.Text = string.Empty;
			txtManagerPhone.Text = string.Empty;
			txtTin.Text = string.Empty;
            cbIsFreight.Checked = false;
			txtCst.Text = string.Empty;
			txtTamilPartyName.Text = string.Empty;
			txtTamilAdd1.Text = string.Empty;
			txtTamilAdd2.Text = string.Empty;
			txtTamilAdd3.Text = string.Empty;
			txtSearch.Text = string.Empty;
			txtSearchbyCity.Text = string.Empty;
			txtDisPer.Value = 0m;
			LoadData();
		}

		private void LoadData()
		{
			txtPartyName.Focus();
			cboType.SelectedIndex = 0;
			cboratetype.SelectedIndex = 0;
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			uspledgermasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, null);
			ledgermasterBindingSource.DataSource = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_accounttype == "Agent" || li.led_id == 0);
			FillGridReference();
		}

		private void EditData()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			if (dgview.CurrentCell != null)
			{
				int rowIndex = dgview.CurrentCell.RowIndex;
				id = Convert.ToInt32(dgview["ledidDataGridViewTextBoxColumn", rowIndex].Value);
				ISingleResult<usp_ledgermasterSelectResult> singleResult = inventoryDataContext.usp_ledgermasterSelect(id, null, null, null, null);
				cboType.SelectedIndex = 0;
				cboratetype.SelectedIndex = 0;
				foreach (usp_ledgermasterSelectResult item in singleResult)
				{
					txtPartyName.Text = item.led_name;
					txtCode.Text = item.led_accountcode;
					cboType.Text = item.led_accounttype;
					cboReference.SelectedValue = item.led_agid;
					if (item.led_ratetype == "MRP")
					{
						cboratetype.SelectedIndex = 1;
					}
					else if (item.led_ratetype == "WHOLE SALE RATE")
					{
						cboratetype.SelectedIndex = 2;
					}
					else if (item.led_ratetype == "SPECIAL RATE")
					{
						cboratetype.SelectedIndex = 3;
					}
					else if (item.led_ratetype == "SUPER SPECIAL RATE")
					{
						cboratetype.SelectedIndex = 4;
					}
					txtAdd1.Text = Convert.ToString(item.led_address);
					txtAdd2.Text = Convert.ToString(item.led_address1);
					txtAdd3.Text = Convert.ToString(item.led_address2);
					txtPin.Text = Convert.ToString(item.led_pincode);
					txtTransport.Text = Convert.ToString(item.led_transport);
					txtOwnerName.Text = Convert.ToString(item.led_ownername);
					txtOwnerPhone.Text = Convert.ToString(item.led_ownerphone);
					txtManagerName.Text = Convert.ToString(item.led_managername);
					txtManagerPhone.Text = Convert.ToString(item.led_managerphone);
					txtTin.Text = Convert.ToString(item.led_tin);
                    cbIsFreight.Checked = Convert.ToBoolean(item.led_isfreight);
                    txtCst.Text = Convert.ToString(item.led_cst);
					txtTamilPartyName.Text = Convert.ToString(item.led_tname);
					txtTamilAdd1.Text = Convert.ToString(item.led_taddress);
					txtTamilAdd2.Text = Convert.ToString(item.led_taddress1);
					txtTamilAdd3.Text = Convert.ToString(item.led_taddress2);
					txtDisPer.Value = item.led_disper;
					txtPartyName.Focus();
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
					inventoryDataContext.usp_ledgermasterDelete(id);
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

		private void btnSave_Click(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			ledgermaster ledgermaster = new ledgermaster();
			try
			{
				ledgermaster.led_accountcode = txtCode.Text.Trim();
				ledgermaster.led_name = txtPartyName.Text.Trim();
				ledgermaster.led_accounttype = cboType.Text;
				ledgermaster.led_address = txtAdd1.Text.Trim();
				ledgermaster.led_address1 = txtAdd2.Text.Trim();
				ledgermaster.led_address2 = txtAdd3.Text.Trim();
				ledgermaster.led_pincode = txtPin.Text.Trim();
				ledgermaster.led_transport = txtTransport.Text.Trim();
				ledgermaster.led_ownername = txtOwnerName.Text.Trim();
				ledgermaster.led_ownerphone = txtOwnerPhone.Text.Trim();
				ledgermaster.led_managername = txtManagerName.Text.Trim();
				ledgermaster.led_managerphone = txtManagerPhone.Text.Trim();
				ledgermaster.led_agid = Convert.ToInt32(cboReference.SelectedValue);
				ledgermaster.led_tin = txtTin.Text.Trim();
                ledgermaster.led_isfreight = cbIsFreight.Checked;
				ledgermaster.led_cst = txtCst.Text.Trim();
				ledgermaster.led_ratetype = cboratetype.Text.Trim();
				ledgermaster.led_tname = txtTamilPartyName.Text.Trim();
				ledgermaster.led_taddress = txtTamilAdd1.Text.Trim();
				ledgermaster.led_taddress1 = txtTamilAdd2.Text.Trim();
				ledgermaster.led_taddress2 = txtTamilAdd3.Text.Trim();
				ledgermaster.led_refno = Convert.ToString(global.ucode);
				ledgermaster.led_disper = txtDisPer.Value;
				if (ledgermaster.led_name == string.Empty)
				{
					MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					txtPartyName.Focus();
				}
				else if (ledgermaster.led_accounttype == string.Empty || ledgermaster.led_accounttype == "---Select---")
				{
					MessageBox.Show("Invalid 'PartyType'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					cboratetype.Focus();
				}
				else if (ledgermaster.led_ratetype == string.Empty || ledgermaster.led_ratetype == "---Select---" || cboratetype.SelectedIndex <= 0)
				{
					MessageBox.Show("Invalid 'RateType'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					cboratetype.Focus();
				}
				else if (ledgermaster.led_address2 == string.Empty)
				{
					MessageBox.Show("Invalid 'City'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					cboratetype.Focus();
				}
				else if (id == 0)
				{
					if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						inventoryDataContext.usp_ledgermasterInsert(ledgermaster.led_agid, ledgermaster.led_accountcode, ledgermaster.led_accounttype, ledgermaster.led_name, ledgermaster.led_address, ledgermaster.led_address1, ledgermaster.led_address2, ledgermaster.led_tname, ledgermaster.led_taddress, ledgermaster.led_taddress1, ledgermaster.led_taddress2, ledgermaster.led_pincode, ledgermaster.led_transport, ledgermaster.led_ownerphone, ledgermaster.led_ownername, ledgermaster.led_managername, ledgermaster.led_managerphone, ledgermaster.led_tin, ledgermaster.led_isfreight, ledgermaster.led_cst, ledgermaster.led_refno, global.ucode, global.comid, global.sysdate, ledgermaster.led_ratetype, ledgermaster.led_disper);
						MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_0521;
					}
				}
				else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					inventoryDataContext.usp_ledgermasterUpdate(id, ledgermaster.led_agid, ledgermaster.led_accountcode, ledgermaster.led_accounttype, ledgermaster.led_name, ledgermaster.led_address, ledgermaster.led_address1, ledgermaster.led_address2, ledgermaster.led_tname, ledgermaster.led_taddress, ledgermaster.led_taddress1, ledgermaster.led_taddress2, ledgermaster.led_pincode, ledgermaster.led_transport, ledgermaster.led_ownerphone, ledgermaster.led_ownername, ledgermaster.led_managername, ledgermaster.led_managerphone, ledgermaster.led_tin,ledgermaster.led_isfreight, ledgermaster.led_cst, ledgermaster.led_refno, global.ucode, global.comid, global.sysdate, ledgermaster.led_ratetype, ledgermaster.led_disper);
					MessageBox.Show("Record updated successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					goto IL_0521;
				}
				goto end_IL_000d;
				IL_0521:
				Clear();
				end_IL_000d:;
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

		private void label13_Click(object sender, EventArgs e)
		{
		}

		private void txtTamilPartyName_KeyUp(object sender, KeyEventArgs e)
		{
			lbltamil.Text = tamil.toTamil(txtTamilPartyName.Text);
		}

		private void txtTamilPartyName_Leave(object sender, EventArgs e)
		{
			txtTamilPartyName.Text = lbltamil.Text;
			lbltamil.Text = string.Empty;
		}

		private void txtTamilAdd1_KeyUp(object sender, KeyEventArgs e)
		{
			lbltamil.Text = tamil.toTamil(txtTamilAdd1.Text);
		}

		private void txtTamilAdd1_Leave(object sender, EventArgs e)
		{
			txtTamilAdd1.Text = lbltamil.Text;
			lbltamil.Text = string.Empty;
		}

		private void txtTamilAdd2_KeyUp(object sender, KeyEventArgs e)
		{
			lbltamil.Text = tamil.toTamil(txtTamilAdd2.Text);
		}

		private void txtTamilAdd2_Leave(object sender, EventArgs e)
		{
			txtTamilAdd2.Text = lbltamil.Text;
			lbltamil.Text = string.Empty;
		}

		private void txtTamilAdd3_KeyUp(object sender, KeyEventArgs e)
		{
			lbltamil.Text = tamil.toTamil(txtTamilAdd3.Text);
		}

		private void txtTamilAdd3_Leave(object sender, EventArgs e)
		{
			txtTamilAdd3.Text = lbltamil.Text;
			lbltamil.Text = string.Empty;
		}

		private void cboType_Leave(object sender, EventArgs e)
		{
		}

		private void FillGridReference()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			cboGridReference.Enabled = true;
			ledgermasterBindingSource1.DataSource = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_accounttype == "Agent" || li.led_id == 0);
		}

		private void cboType_TextChanged(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			if (cboType.Text == "Customer")
			{
				cboReference.Enabled = true;
				ledgermasterBindingSource.DataSource = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_accounttype == "Agent" || li.led_id == 0);
				cboReference.SelectedValue = 0;
			}
			else
			{
				cboReference.Enabled = false;
				cboReference.SelectedValue = 0;
				cboReference.Text = "";
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			int? num = Convert.ToInt32(cboGridReference.SelectedValue);
			int? num2 = num;
			if (num2.GetValueOrDefault() == 0 && num2.HasValue)
			{
				num = null;
			}
			dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, txtSearch.Text, txtSearchbyCity.Text, num);
		}

		private void txtSearchItemCode_TextChanged(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			int? num = Convert.ToInt32(cboGridReference.SelectedValue);
			int? num2 = num;
			if (num2.GetValueOrDefault() == 0 && num2.HasValue)
			{
				num = null;
			}
			dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, txtSearch.Text, txtSearchbyCity.Text, num);
		}

		private void txtPartyName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return)
			{
				SendKeys.Send("{TAB}");
			}
		}

		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
		}

		private void cboGridReference_TextChanged(object sender, EventArgs e)
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			int? num = Convert.ToInt32(cboGridReference.SelectedValue);
			int? num2 = num;
			if (num2.GetValueOrDefault() == 0 && num2.HasValue)
			{
				num = null;
			}
			CountofLedgers = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, num).Count();
			lblCount.Text = CountofLedgers.ToString();
			dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, num);
		}

		private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
			{
				e.Handled = true;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSearchbyCity = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboGridReference = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblCount = new System.Windows.Forms.Label();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaccountcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaccounttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtaddress1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledpincodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtransportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledownernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledownerphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledmanagernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledmanagerphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledcstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledrefnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspledgermasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblEntry = new System.Windows.Forms.TableLayoutPanel();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.txtManagerName = new System.Windows.Forms.TextBox();
            this.txtOwnerPhone = new System.Windows.Forms.TextBox();
            this.txtManagerPhone = new System.Windows.Forms.TextBox();
            this.txtTin = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.txtAdd3 = new System.Windows.Forms.TextBox();
            this.txtAdd2 = new System.Windows.Forms.TextBox();
            this.txtAdd1 = new System.Windows.Forms.TextBox();
            this.lblref = new System.Windows.Forms.Label();
            this.cboReference = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbltamil = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTamilAdd3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTamilAdd2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTamilAdd1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTamilPartyName = new System.Windows.Forms.TextBox();
            this.cboratetype = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDisPer = new mylib.decimalbox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCst = new System.Windows.Forms.TextBox();
            this.cbIsFreight = new System.Windows.Forms.CheckBox();
            this.tblCommand = new System.Windows.Forms.TableLayoutPanel();
            this.cmdclose = new mylib.lightbutton();
            this.btnClear = new mylib.lightbutton();
            this.btnDelete = new mylib.lightbutton();
            this.btnSave = new mylib.lightbutton();
            this.a1Paneltitle.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).BeginInit();
            this.tblEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).BeginInit();
            this.tblCommand.SuspendLayout();
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
            this.a1Paneltitle.Location = new System.Drawing.Point(5, 6);
            this.a1Paneltitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.a1Paneltitle.Name = "a1Paneltitle";
            this.a1Paneltitle.ShadowOffSet = 0;
            this.a1Paneltitle.Size = new System.Drawing.Size(1836, 44);
            this.a1Paneltitle.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbltitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltitle.Location = new System.Drawing.Point(38, 8);
            this.lbltitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(91, 28);
            this.lbltitle.TabIndex = 0;
            this.lbltitle.Text = "Ledger";
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
            this.tblMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 5;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 385F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.Size = new System.Drawing.Size(1846, 1074);
            this.tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 8;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Controls.Add(this.lblSearch, 0, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tblSearch.Controls.Add(this.label20, 2, 0);
            this.tblSearch.Controls.Add(this.txtSearchbyCity, 3, 0);
            this.tblSearch.Controls.Add(this.label24, 4, 0);
            this.tblSearch.Controls.Add(this.cboGridReference, 5, 0);
            this.tblSearch.Controls.Add(this.lblCount, 6, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(5, 447);
            this.tblSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.Size = new System.Drawing.Size(1836, 59);
            this.tblSearch.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSearch.Location = new System.Drawing.Point(4, 15);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(289, 28);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search By Ledger Name";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(304, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(290, 35);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label20.Location = new System.Drawing.Point(604, 15);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(180, 28);
            this.label20.TabIndex = 2;
            this.label20.Text = "Search By City";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchbyCity
            // 
            this.txtSearchbyCity.BackColor = System.Drawing.Color.White;
            this.txtSearchbyCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchbyCity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSearchbyCity.Location = new System.Drawing.Point(829, 5);
            this.txtSearchbyCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchbyCity.MaxLength = 50;
            this.txtSearchbyCity.Name = "txtSearchbyCity";
            this.txtSearchbyCity.Size = new System.Drawing.Size(290, 35);
            this.txtSearchbyCity.TabIndex = 1;
            this.txtSearchbyCity.TextChanged += new System.EventHandler(this.txtSearchItemCode_TextChanged);
            this.txtSearchbyCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label24.Location = new System.Drawing.Point(1159, 15);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(131, 28);
            this.label24.TabIndex = 2;
            this.label24.Text = "Reference";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGridReference
            // 
            this.cboGridReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboGridReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGridReference.DataSource = this.ledgermasterBindingSource1;
            this.cboGridReference.DisplayMember = "led_name";
            this.cboGridReference.Enabled = false;
            this.cboGridReference.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboGridReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboGridReference.FormattingEnabled = true;
            this.cboGridReference.Location = new System.Drawing.Point(1309, 5);
            this.cboGridReference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboGridReference.Name = "cboGridReference";
            this.cboGridReference.Size = new System.Drawing.Size(289, 36);
            this.cboGridReference.TabIndex = 2;
            this.cboGridReference.ValueMember = "led_id";
            this.cboGridReference.TextChanged += new System.EventHandler(this.cboGridReference_TextChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCount.Location = new System.Drawing.Point(1643, 0);
            this.lblCount.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(24, 35);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = ".";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgview.ColumnHeadersHeight = 28;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ledidDataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.ledaccountcodeDataGridViewTextBoxColumn,
            this.ledaccounttypeDataGridViewTextBoxColumn,
            this.ledaddressDataGridViewTextBoxColumn,
            this.ledaddress1DataGridViewTextBoxColumn,
            this.ledaddress2DataGridViewTextBoxColumn,
            this.ledtnameDataGridViewTextBoxColumn,
            this.ledtaddressDataGridViewTextBoxColumn,
            this.ledtaddress1DataGridViewTextBoxColumn,
            this.ledtaddress2DataGridViewTextBoxColumn,
            this.ledpincodeDataGridViewTextBoxColumn,
            this.ledtransportDataGridViewTextBoxColumn,
            this.ledownernameDataGridViewTextBoxColumn,
            this.ledownerphoneDataGridViewTextBoxColumn,
            this.ledmanagernameDataGridViewTextBoxColumn,
            this.ledmanagerphoneDataGridViewTextBoxColumn,
            this.ledtinDataGridViewTextBoxColumn,
            this.ledcstDataGridViewTextBoxColumn,
            this.ledrefnoDataGridViewTextBoxColumn});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.uspledgermasterSelectResultBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(5, 517);
            this.dgview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.dgview.Size = new System.Drawing.Size(1836, 481);
            this.dgview.TabIndex = 1;
            this.dgview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgview_CellDoubleClick);
            // 
            // ledidDataGridViewTextBoxColumn
            // 
            this.ledidDataGridViewTextBoxColumn.DataPropertyName = "led_id";
            this.ledidDataGridViewTextBoxColumn.HeaderText = "led_id";
            this.ledidDataGridViewTextBoxColumn.Name = "ledidDataGridViewTextBoxColumn";
            this.ledidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledidDataGridViewTextBoxColumn.Visible = false;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 250;
            // 
            // ledaccountcodeDataGridViewTextBoxColumn
            // 
            this.ledaccountcodeDataGridViewTextBoxColumn.DataPropertyName = "led_accountcode";
            this.ledaccountcodeDataGridViewTextBoxColumn.HeaderText = "Accountcode";
            this.ledaccountcodeDataGridViewTextBoxColumn.Name = "ledaccountcodeDataGridViewTextBoxColumn";
            this.ledaccountcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledaccounttypeDataGridViewTextBoxColumn
            // 
            this.ledaccounttypeDataGridViewTextBoxColumn.DataPropertyName = "led_accounttype";
            this.ledaccounttypeDataGridViewTextBoxColumn.HeaderText = "Accounttype";
            this.ledaccounttypeDataGridViewTextBoxColumn.Name = "ledaccounttypeDataGridViewTextBoxColumn";
            this.ledaccounttypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledaddressDataGridViewTextBoxColumn
            // 
            this.ledaddressDataGridViewTextBoxColumn.DataPropertyName = "led_address";
            this.ledaddressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.ledaddressDataGridViewTextBoxColumn.Name = "ledaddressDataGridViewTextBoxColumn";
            this.ledaddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledaddress1DataGridViewTextBoxColumn
            // 
            this.ledaddress1DataGridViewTextBoxColumn.DataPropertyName = "led_address1";
            this.ledaddress1DataGridViewTextBoxColumn.HeaderText = "Address 1";
            this.ledaddress1DataGridViewTextBoxColumn.Name = "ledaddress1DataGridViewTextBoxColumn";
            this.ledaddress1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledaddress2DataGridViewTextBoxColumn
            // 
            this.ledaddress2DataGridViewTextBoxColumn.DataPropertyName = "led_address2";
            this.ledaddress2DataGridViewTextBoxColumn.HeaderText = "City";
            this.ledaddress2DataGridViewTextBoxColumn.Name = "ledaddress2DataGridViewTextBoxColumn";
            this.ledaddress2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledtnameDataGridViewTextBoxColumn
            // 
            this.ledtnameDataGridViewTextBoxColumn.DataPropertyName = "led_tname";
            this.ledtnameDataGridViewTextBoxColumn.HeaderText = " Tamil Name";
            this.ledtnameDataGridViewTextBoxColumn.Name = "ledtnameDataGridViewTextBoxColumn";
            this.ledtnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledtaddressDataGridViewTextBoxColumn
            // 
            this.ledtaddressDataGridViewTextBoxColumn.DataPropertyName = "led_taddress";
            this.ledtaddressDataGridViewTextBoxColumn.HeaderText = "led_taddress";
            this.ledtaddressDataGridViewTextBoxColumn.Name = "ledtaddressDataGridViewTextBoxColumn";
            this.ledtaddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledtaddressDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledtaddress1DataGridViewTextBoxColumn
            // 
            this.ledtaddress1DataGridViewTextBoxColumn.DataPropertyName = "led_taddress1";
            this.ledtaddress1DataGridViewTextBoxColumn.HeaderText = "led_taddress1";
            this.ledtaddress1DataGridViewTextBoxColumn.Name = "ledtaddress1DataGridViewTextBoxColumn";
            this.ledtaddress1DataGridViewTextBoxColumn.ReadOnly = true;
            this.ledtaddress1DataGridViewTextBoxColumn.Visible = false;
            // 
            // ledtaddress2DataGridViewTextBoxColumn
            // 
            this.ledtaddress2DataGridViewTextBoxColumn.DataPropertyName = "led_taddress2";
            this.ledtaddress2DataGridViewTextBoxColumn.HeaderText = "led_taddress2";
            this.ledtaddress2DataGridViewTextBoxColumn.Name = "ledtaddress2DataGridViewTextBoxColumn";
            this.ledtaddress2DataGridViewTextBoxColumn.ReadOnly = true;
            this.ledtaddress2DataGridViewTextBoxColumn.Visible = false;
            // 
            // ledpincodeDataGridViewTextBoxColumn
            // 
            this.ledpincodeDataGridViewTextBoxColumn.DataPropertyName = "led_pincode";
            this.ledpincodeDataGridViewTextBoxColumn.HeaderText = "led_pincode";
            this.ledpincodeDataGridViewTextBoxColumn.Name = "ledpincodeDataGridViewTextBoxColumn";
            this.ledpincodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledpincodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledtransportDataGridViewTextBoxColumn
            // 
            this.ledtransportDataGridViewTextBoxColumn.DataPropertyName = "led_transport";
            this.ledtransportDataGridViewTextBoxColumn.HeaderText = "led_transport";
            this.ledtransportDataGridViewTextBoxColumn.Name = "ledtransportDataGridViewTextBoxColumn";
            this.ledtransportDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledtransportDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledownernameDataGridViewTextBoxColumn
            // 
            this.ledownernameDataGridViewTextBoxColumn.DataPropertyName = "led_ownername";
            this.ledownernameDataGridViewTextBoxColumn.HeaderText = "Owner Name";
            this.ledownernameDataGridViewTextBoxColumn.Name = "ledownernameDataGridViewTextBoxColumn";
            this.ledownernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledownernameDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledownerphoneDataGridViewTextBoxColumn
            // 
            this.ledownerphoneDataGridViewTextBoxColumn.DataPropertyName = "led_ownerphone";
            this.ledownerphoneDataGridViewTextBoxColumn.HeaderText = "Owner Phone";
            this.ledownerphoneDataGridViewTextBoxColumn.Name = "ledownerphoneDataGridViewTextBoxColumn";
            this.ledownerphoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledownerphoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledmanagernameDataGridViewTextBoxColumn
            // 
            this.ledmanagernameDataGridViewTextBoxColumn.DataPropertyName = "led_managername";
            this.ledmanagernameDataGridViewTextBoxColumn.HeaderText = "led_managername";
            this.ledmanagernameDataGridViewTextBoxColumn.Name = "ledmanagernameDataGridViewTextBoxColumn";
            this.ledmanagernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledmanagernameDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledmanagerphoneDataGridViewTextBoxColumn
            // 
            this.ledmanagerphoneDataGridViewTextBoxColumn.DataPropertyName = "led_managerphone";
            this.ledmanagerphoneDataGridViewTextBoxColumn.HeaderText = "led_managerphone";
            this.ledmanagerphoneDataGridViewTextBoxColumn.Name = "ledmanagerphoneDataGridViewTextBoxColumn";
            this.ledmanagerphoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledmanagerphoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledtinDataGridViewTextBoxColumn
            // 
            this.ledtinDataGridViewTextBoxColumn.DataPropertyName = "led_tin";
            this.ledtinDataGridViewTextBoxColumn.HeaderText = "led_tin";
            this.ledtinDataGridViewTextBoxColumn.Name = "ledtinDataGridViewTextBoxColumn";
            this.ledtinDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledtinDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledcstDataGridViewTextBoxColumn
            // 
            this.ledcstDataGridViewTextBoxColumn.DataPropertyName = "led_cst";
            this.ledcstDataGridViewTextBoxColumn.HeaderText = "led_cst";
            this.ledcstDataGridViewTextBoxColumn.Name = "ledcstDataGridViewTextBoxColumn";
            this.ledcstDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledcstDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledrefnoDataGridViewTextBoxColumn
            // 
            this.ledrefnoDataGridViewTextBoxColumn.DataPropertyName = "led_refno";
            this.ledrefnoDataGridViewTextBoxColumn.HeaderText = "led_refno";
            this.ledrefnoDataGridViewTextBoxColumn.Name = "ledrefnoDataGridViewTextBoxColumn";
            this.ledrefnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledrefnoDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspledgermasterSelectResultBindingSource
            // 
            this.uspledgermasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // tblEntry
            // 
            this.tblEntry.ColumnCount = 7;
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.Controls.Add(this.txtPartyName, 1, 0);
            this.tblEntry.Controls.Add(this.label1, 0, 0);
            this.tblEntry.Controls.Add(this.label2, 0, 1);
            this.tblEntry.Controls.Add(this.label3, 0, 2);
            this.tblEntry.Controls.Add(this.txtCode, 1, 1);
            this.tblEntry.Controls.Add(this.cboType, 1, 2);
            this.tblEntry.Controls.Add(this.label15, 2, 0);
            this.tblEntry.Controls.Add(this.label8, 2, 1);
            this.tblEntry.Controls.Add(this.label13, 2, 2);
            this.tblEntry.Controls.Add(this.label14, 2, 3);
            this.tblEntry.Controls.Add(this.label9, 2, 4);
            this.tblEntry.Controls.Add(this.txtOwnerName, 3, 0);
            this.tblEntry.Controls.Add(this.txtManagerName, 3, 2);
            this.tblEntry.Controls.Add(this.txtOwnerPhone, 3, 1);
            this.tblEntry.Controls.Add(this.txtManagerPhone, 3, 3);
            this.tblEntry.Controls.Add(this.txtTin, 3, 4);
            this.tblEntry.Controls.Add(this.label16, 0, 7);
            this.tblEntry.Controls.Add(this.label11, 0, 6);
            this.tblEntry.Controls.Add(this.label4, 0, 5);
            this.tblEntry.Controls.Add(this.label17, 0, 4);
            this.tblEntry.Controls.Add(this.txtPin, 1, 7);
            this.tblEntry.Controls.Add(this.txtAdd3, 1, 6);
            this.tblEntry.Controls.Add(this.txtAdd2, 1, 5);
            this.tblEntry.Controls.Add(this.txtAdd1, 1, 4);
            this.tblEntry.Controls.Add(this.lblref, 0, 3);
            this.tblEntry.Controls.Add(this.cboReference, 1, 3);
            this.tblEntry.Controls.Add(this.lbltamil, 4, 5);
            this.tblEntry.Controls.Add(this.label19, 4, 4);
            this.tblEntry.Controls.Add(this.txtTamilAdd3, 5, 4);
            this.tblEntry.Controls.Add(this.label18, 4, 3);
            this.tblEntry.Controls.Add(this.txtTamilAdd2, 5, 3);
            this.tblEntry.Controls.Add(this.label5, 4, 2);
            this.tblEntry.Controls.Add(this.txtTamilAdd1, 5, 2);
            this.tblEntry.Controls.Add(this.label7, 4, 1);
            this.tblEntry.Controls.Add(this.txtTamilPartyName, 5, 1);
            this.tblEntry.Controls.Add(this.cboratetype, 5, 0);
            this.tblEntry.Controls.Add(this.label22, 4, 0);
            this.tblEntry.Controls.Add(this.label12, 2, 5);
            this.tblEntry.Controls.Add(this.txtTransport, 3, 5);
            this.tblEntry.Controls.Add(this.label23, 2, 6);
            this.tblEntry.Controls.Add(this.txtDisPer, 3, 6);
            this.tblEntry.Controls.Add(this.label6, 6, 0);
            this.tblEntry.Controls.Add(this.label21, 4, 7);
            this.tblEntry.Controls.Add(this.txtCst, 5, 7);
            this.tblEntry.Controls.Add(this.cbIsFreight, 3, 7);
            this.tblEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEntry.Location = new System.Drawing.Point(5, 61);
            this.tblEntry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblEntry.Name = "tblEntry";
            this.tblEntry.RowCount = 10;
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tblEntry.Size = new System.Drawing.Size(1836, 375);
            this.tblEntry.TabIndex = 1;
            // 
            // txtPartyName
            // 
            this.txtPartyName.BackColor = System.Drawing.Color.White;
            this.txtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPartyName.Location = new System.Drawing.Point(229, 5);
            this.txtPartyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPartyName.MaxLength = 50;
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(290, 35);
            this.txtPartyName.TabIndex = 1;
            this.txtPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Party Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(4, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Party Type ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCode.Location = new System.Drawing.Point(229, 51);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(290, 35);
            this.txtCode.TabIndex = 2;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // cboType
            // 
            this.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboType.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "---Select---",
            "Customer",
            "Supplier"});
            this.cboType.Location = new System.Drawing.Point(229, 97);
            this.cboType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(289, 36);
            this.cboType.TabIndex = 3;
            this.cboType.TextChanged += new System.EventHandler(this.cboType_TextChanged);
            this.cboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.cboType.Leave += new System.EventHandler(this.cboType_Leave);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label15.Location = new System.Drawing.Point(529, 9);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 28);
            this.label15.TabIndex = 16;
            this.label15.Text = "Owner Name";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label8.Location = new System.Drawing.Point(529, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Owner Phone";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label13.Location = new System.Drawing.Point(529, 101);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(189, 28);
            this.label13.TabIndex = 20;
            this.label13.Text = "Manager Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label14.Location = new System.Drawing.Point(529, 147);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 28);
            this.label14.TabIndex = 22;
            this.label14.Text = "Manager Phone";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label9.Location = new System.Drawing.Point(529, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 28);
            this.label9.TabIndex = 24;
            this.label9.Text = "GSTIN";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.BackColor = System.Drawing.Color.White;
            this.txtOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtOwnerName.Location = new System.Drawing.Point(754, 5);
            this.txtOwnerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOwnerName.MaxLength = 50;
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(290, 35);
            this.txtOwnerName.TabIndex = 9;
            this.txtOwnerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtManagerName
            // 
            this.txtManagerName.BackColor = System.Drawing.Color.White;
            this.txtManagerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManagerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtManagerName.Location = new System.Drawing.Point(754, 97);
            this.txtManagerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtManagerName.MaxLength = 50;
            this.txtManagerName.Name = "txtManagerName";
            this.txtManagerName.Size = new System.Drawing.Size(290, 35);
            this.txtManagerName.TabIndex = 11;
            this.txtManagerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtOwnerPhone
            // 
            this.txtOwnerPhone.BackColor = System.Drawing.Color.White;
            this.txtOwnerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerPhone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtOwnerPhone.Location = new System.Drawing.Point(754, 51);
            this.txtOwnerPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOwnerPhone.MaxLength = 50;
            this.txtOwnerPhone.Name = "txtOwnerPhone";
            this.txtOwnerPhone.Size = new System.Drawing.Size(290, 35);
            this.txtOwnerPhone.TabIndex = 10;
            this.txtOwnerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtManagerPhone
            // 
            this.txtManagerPhone.BackColor = System.Drawing.Color.White;
            this.txtManagerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManagerPhone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtManagerPhone.Location = new System.Drawing.Point(754, 143);
            this.txtManagerPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtManagerPhone.MaxLength = 50;
            this.txtManagerPhone.Name = "txtManagerPhone";
            this.txtManagerPhone.Size = new System.Drawing.Size(290, 35);
            this.txtManagerPhone.TabIndex = 12;
            this.txtManagerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtTin
            // 
            this.txtTin.BackColor = System.Drawing.Color.White;
            this.txtTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTin.Location = new System.Drawing.Point(754, 189);
            this.txtTin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTin.MaxLength = 50;
            this.txtTin.Name = "txtTin";
            this.txtTin.Size = new System.Drawing.Size(290, 35);
            this.txtTin.TabIndex = 13;
            this.txtTin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label16.Location = new System.Drawing.Point(4, 331);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 28);
            this.label16.TabIndex = 14;
            this.label16.Text = "Pincode";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label11.Location = new System.Drawing.Point(4, 285);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 28);
            this.label11.TabIndex = 12;
            this.label11.Text = "City";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(4, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Address 2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label17.Location = new System.Drawing.Point(4, 193);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 28);
            this.label17.TabIndex = 8;
            this.label17.Text = "Address 1";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.White;
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPin.Location = new System.Drawing.Point(229, 327);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPin.MaxLength = 50;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(290, 35);
            this.txtPin.TabIndex = 8;
            this.txtPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtAdd3
            // 
            this.txtAdd3.BackColor = System.Drawing.Color.White;
            this.txtAdd3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdd3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtAdd3.Location = new System.Drawing.Point(229, 281);
            this.txtAdd3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdd3.MaxLength = 50;
            this.txtAdd3.Name = "txtAdd3";
            this.txtAdd3.Size = new System.Drawing.Size(290, 35);
            this.txtAdd3.TabIndex = 7;
            this.txtAdd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtAdd2
            // 
            this.txtAdd2.BackColor = System.Drawing.Color.White;
            this.txtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtAdd2.Location = new System.Drawing.Point(229, 235);
            this.txtAdd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdd2.MaxLength = 50;
            this.txtAdd2.Name = "txtAdd2";
            this.txtAdd2.Size = new System.Drawing.Size(290, 35);
            this.txtAdd2.TabIndex = 6;
            this.txtAdd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtAdd1
            // 
            this.txtAdd1.BackColor = System.Drawing.Color.White;
            this.txtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtAdd1.Location = new System.Drawing.Point(229, 189);
            this.txtAdd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdd1.MaxLength = 50;
            this.txtAdd1.Name = "txtAdd1";
            this.txtAdd1.Size = new System.Drawing.Size(290, 35);
            this.txtAdd1.TabIndex = 5;
            this.txtAdd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // lblref
            // 
            this.lblref.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblref.AutoSize = true;
            this.lblref.BackColor = System.Drawing.Color.Transparent;
            this.lblref.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblref.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblref.Location = new System.Drawing.Point(4, 147);
            this.lblref.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblref.Name = "lblref";
            this.lblref.Size = new System.Drawing.Size(131, 28);
            this.lblref.TabIndex = 6;
            this.lblref.Text = "Reference";
            this.lblref.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboReference
            // 
            this.cboReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReference.DataSource = this.ledgermasterBindingSource;
            this.cboReference.DisplayMember = "led_name";
            this.cboReference.Enabled = false;
            this.cboReference.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboReference.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboReference.FormattingEnabled = true;
            this.cboReference.Location = new System.Drawing.Point(229, 143);
            this.cboReference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboReference.Name = "cboReference";
            this.cboReference.Size = new System.Drawing.Size(289, 36);
            this.cboReference.TabIndex = 4;
            this.cboReference.ValueMember = "led_id";
            this.cboReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // lbltamil
            // 
            this.lbltamil.BackColor = System.Drawing.Color.White;
            this.lbltamil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblEntry.SetColumnSpan(this.lbltamil, 3);
            this.lbltamil.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbltamil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltamil.Location = new System.Drawing.Point(1054, 230);
            this.lbltamil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltamil.Name = "lbltamil";
            this.tblEntry.SetRowSpan(this.lbltamil, 2);
            this.lbltamil.Size = new System.Drawing.Size(520, 88);
            this.lbltamil.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label19.Location = new System.Drawing.Point(1054, 193);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 28);
            this.label19.TabIndex = 36;
            this.label19.Text = "City";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTamilAdd3
            // 
            this.txtTamilAdd3.BackColor = System.Drawing.Color.White;
            this.txtTamilAdd3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTamilAdd3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTamilAdd3.Location = new System.Drawing.Point(1279, 189);
            this.txtTamilAdd3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTamilAdd3.MaxLength = 50;
            this.txtTamilAdd3.Name = "txtTamilAdd3";
            this.txtTamilAdd3.Size = new System.Drawing.Size(290, 35);
            this.txtTamilAdd3.TabIndex = 20;
            this.txtTamilAdd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtTamilAdd3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTamilAdd3_KeyUp);
            this.txtTamilAdd3.Leave += new System.EventHandler(this.txtTamilAdd3_Leave);
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label18.Location = new System.Drawing.Point(1054, 147);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(126, 28);
            this.label18.TabIndex = 34;
            this.label18.Text = "Address 2";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTamilAdd2
            // 
            this.txtTamilAdd2.BackColor = System.Drawing.Color.White;
            this.txtTamilAdd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTamilAdd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTamilAdd2.Location = new System.Drawing.Point(1279, 143);
            this.txtTamilAdd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTamilAdd2.MaxLength = 50;
            this.txtTamilAdd2.Name = "txtTamilAdd2";
            this.txtTamilAdd2.Size = new System.Drawing.Size(290, 35);
            this.txtTamilAdd2.TabIndex = 19;
            this.txtTamilAdd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtTamilAdd2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTamilAdd2_KeyUp);
            this.txtTamilAdd2.Leave += new System.EventHandler(this.txtTamilAdd2_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(1054, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 28);
            this.label5.TabIndex = 32;
            this.label5.Text = "Address 1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTamilAdd1
            // 
            this.txtTamilAdd1.BackColor = System.Drawing.Color.White;
            this.txtTamilAdd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTamilAdd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTamilAdd1.Location = new System.Drawing.Point(1279, 97);
            this.txtTamilAdd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTamilAdd1.MaxLength = 50;
            this.txtTamilAdd1.Name = "txtTamilAdd1";
            this.txtTamilAdd1.Size = new System.Drawing.Size(290, 35);
            this.txtTamilAdd1.TabIndex = 18;
            this.txtTamilAdd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtTamilAdd1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTamilAdd1_KeyUp);
            this.txtTamilAdd1.Leave += new System.EventHandler(this.txtTamilAdd1_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label7.Location = new System.Drawing.Point(1054, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 28);
            this.label7.TabIndex = 30;
            this.label7.Text = "Tamil ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTamilPartyName
            // 
            this.txtTamilPartyName.BackColor = System.Drawing.Color.White;
            this.txtTamilPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTamilPartyName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTamilPartyName.Location = new System.Drawing.Point(1279, 51);
            this.txtTamilPartyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTamilPartyName.MaxLength = 50;
            this.txtTamilPartyName.Name = "txtTamilPartyName";
            this.txtTamilPartyName.Size = new System.Drawing.Size(290, 35);
            this.txtTamilPartyName.TabIndex = 17;
            this.txtTamilPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtTamilPartyName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTamilPartyName_KeyUp);
            this.txtTamilPartyName.Leave += new System.EventHandler(this.txtTamilPartyName_Leave);
            // 
            // cboratetype
            // 
            this.cboratetype.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboratetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboratetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboratetype.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboratetype.FormattingEnabled = true;
            this.cboratetype.Items.AddRange(new object[] {
            "---Select---",
            "COST RATE",
            "SUPER SPECIAL RATE  (A)",
            "SPECIAL RATE  (B)",
            "WHOLE SALE RATE  (C)",
            "MRP  (D)"});
            this.cboratetype.Location = new System.Drawing.Point(1281, 6);
            this.cboratetype.Margin = new System.Windows.Forms.Padding(6);
            this.cboratetype.Name = "cboratetype";
            this.cboratetype.Size = new System.Drawing.Size(286, 36);
            this.cboratetype.TabIndex = 16;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label22.Location = new System.Drawing.Point(1054, 9);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(129, 28);
            this.label22.TabIndex = 39;
            this.label22.Text = "Rate Type";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label12.Location = new System.Drawing.Point(529, 240);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 25);
            this.label12.TabIndex = 28;
            this.label12.Text = "Transport";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTransport
            // 
            this.txtTransport.BackColor = System.Drawing.Color.White;
            this.txtTransport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransport.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTransport.Location = new System.Drawing.Point(754, 235);
            this.txtTransport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransport.MaxLength = 50;
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(290, 35);
            this.txtTransport.TabIndex = 14;
            this.txtTransport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label23.Location = new System.Drawing.Point(529, 285);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(149, 28);
            this.label23.TabIndex = 28;
            this.label23.Text = "Discount %";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDisPer
            // 
            this.txtDisPer.AllowFormat = false;
            this.txtDisPer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDisPer.BackColor = System.Drawing.Color.White;
            this.txtDisPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisPer.DecimalPlaces = 2;
            this.txtDisPer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDisPer.Location = new System.Drawing.Point(756, 282);
            this.txtDisPer.Margin = new System.Windows.Forms.Padding(6);
            this.txtDisPer.Name = "txtDisPer";
            this.txtDisPer.RightAlign = true;
            this.txtDisPer.Size = new System.Drawing.Size(287, 35);
            this.txtDisPer.TabIndex = 15;
            this.txtDisPer.TabStop = false;
            this.txtDisPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisPer.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDisPer.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(1579, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 24);
            this.label6.TabIndex = 2;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label21.Location = new System.Drawing.Point(1054, 331);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 28);
            this.label21.TabIndex = 26;
            this.label21.Text = "Cst";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label21.Visible = false;
            // 
            // txtCst
            // 
            this.txtCst.BackColor = System.Drawing.Color.White;
            this.txtCst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCst.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCst.Location = new System.Drawing.Point(1279, 327);
            this.txtCst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCst.MaxLength = 50;
            this.txtCst.Name = "txtCst";
            this.txtCst.Size = new System.Drawing.Size(290, 35);
            this.txtCst.TabIndex = 22;
            this.txtCst.Visible = false;
            this.txtCst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // cbIsFreight
            // 
            this.cbIsFreight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbIsFreight.AutoSize = true;
            this.cbIsFreight.BackColor = System.Drawing.Color.Transparent;
            this.cbIsFreight.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbIsFreight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.cbIsFreight.Location = new System.Drawing.Point(753, 329);
            this.cbIsFreight.Name = "cbIsFreight";
            this.cbIsFreight.Size = new System.Drawing.Size(151, 32);
            this.cbIsFreight.TabIndex = 40;
            this.cbIsFreight.Text = "Is Freight";
            this.cbIsFreight.UseVisualStyleBackColor = false;
            // 
            // tblCommand
            // 
            this.tblCommand.ColumnCount = 5;
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tblCommand.Controls.Add(this.cmdclose, 4, 0);
            this.tblCommand.Controls.Add(this.btnClear, 3, 0);
            this.tblCommand.Controls.Add(this.btnDelete, 2, 0);
            this.tblCommand.Controls.Add(this.btnSave, 1, 0);
            this.tblCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCommand.Location = new System.Drawing.Point(5, 1009);
            this.tblCommand.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblCommand.Name = "tblCommand";
            this.tblCommand.RowCount = 1;
            this.tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCommand.Size = new System.Drawing.Size(1836, 59);
            this.tblCommand.TabIndex = 3;
            // 
            // cmdclose
            // 
            this.cmdclose.AutoSize = true;
            this.cmdclose.BackColor = System.Drawing.Color.Transparent;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(1690, 5);
            this.cmdclose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(135, 49);
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
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnClear.Location = new System.Drawing.Point(1540, 5);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 49);
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
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnDelete.Location = new System.Drawing.Point(1390, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 49);
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
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.btnSave.Location = new System.Drawing.Point(1240, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 49);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1846, 1074);
            this.Controls.Add(this.tblMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLedger";
            this.ShowIcon = false;
            this.Text = "Ledger";
            this.Load += new System.EventHandler(this.frmItems_Load);
            this.a1Paneltitle.ResumeLayout(false);
            this.a1Paneltitle.PerformLayout();
            this.tblMain.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspledgermasterSelectResultBindingSource)).EndInit();
            this.tblEntry.ResumeLayout(false);
            this.tblEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            this.tblCommand.ResumeLayout(false);
            this.tblCommand.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}
