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

		private Label label23;

		private decimalbox txtDisPer;

		private Label label24;

		private ComboBox cboGridReference;

		private BindingSource ledgermasterBindingSource1;

		private Label lblCount;
        private CheckBox cbIsFreight;
        private Label lblAreaCode;
        private Label lblDeliveryOrder;
        private ComboBox cboAreaCode;
        private BindingSource routeBindingSource;
        private TextBox txtDeliveryOrder;
        private TextBox txtSearchByAreaCode;
        private Label lblSearchAreaCode;
        private DataGridViewTextBoxColumn ledareacodeDataGridViewTextBoxColumn;
        private Label lblState;
        private TextBox txtState;
        private Label lblShippingAdd2;
        private Label lblShipingAdd1;
        private TextBox txtShippingAdd1;
        private TextBox txtShippingAdd2;
        private DataGridViewTextBoxColumn ledidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledagidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lednameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaccountcodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledratetypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaccounttypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leddeliveryorderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaddressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaddress1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledaddress2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledtnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledtaddressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledtaddress1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledtaddress2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledpincodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledtransportDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledownerphoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledownernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledmanagernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledmanagerphoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledtinDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn ledisfreightDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn ledcstDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leddisperDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledrefnoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn comidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ledudateDataGridViewTextBoxColumn;
        private Label label13;
        private TextBox txtVehicleNo;
        private ComboBox cboVehicleNo;
        private BindingSource vehicleBindingSource;
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
            cboReference.SelectedIndex = -1;
            txtAdd1.Text = string.Empty;
			txtAdd2.Text = string.Empty;
			txtAdd3.Text = string.Empty;
            txtShippingAdd1.Text = string.Empty;
            txtShippingAdd2.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPin.Text = string.Empty;
			txtTransport.Text = string.Empty;
			txtOwnerName.Text = string.Empty;
			txtOwnerPhone.Text = string.Empty;
			txtManagerName.Text = string.Empty;
			txtManagerPhone.Text = string.Empty;
            cboAreaCode.SelectedIndex = 0;
            cboVehicleNo.SelectedIndex = 0;
            txtDeliveryOrder.Text = string.Empty;
            txtVehicleNo.Text = string.Empty;
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
			txtPartyName.Select();
			cboType.SelectedIndex = 0;
			cboratetype.SelectedIndex = 0;
            cboReference.SelectedValue = 0;
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            routeBindingSource.DataSource = inventoryDataContext.routes.Select((route rt) => rt);
            vehicleBindingSource.DataSource = inventoryDataContext.vehicles.Select((vehicle vh) => vh);
            uspledgermasterSelectResultBindingSource.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, null, null);
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
				ISingleResult<usp_ledgermasterSelectResult> singleResult = inventoryDataContext.usp_ledgermasterSelect(id, null, null, null, null, null);
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
                    txtShippingAdd1.Text = Convert.ToString(item.led_shippingaddress1);
                    txtShippingAdd2.Text = Convert.ToString(item.led_shippingaddress2);
                    txtState.Text = Convert.ToString(item.led_state);
                    txtPin.Text = Convert.ToString(item.led_pincode);
					txtTransport.Text = Convert.ToString(item.led_transport);
					txtOwnerName.Text = Convert.ToString(item.led_ownername);
					txtOwnerPhone.Text = Convert.ToString(item.led_ownerphone);
					txtManagerName.Text = Convert.ToString(item.led_managername);
					txtManagerPhone.Text = Convert.ToString(item.led_managerphone);
                    cboAreaCode.Text = item.rt_name;
                    cboVehicleNo.Text = item.vh_number;
                    cboratetype.Text = item.led_ratetype;
                    txtDeliveryOrder.Text = Convert.ToString(item.led_deliveryorder);
                    txtVehicleNo.Text = Convert.ToString(item.led_vehicleno);
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
				ledgermaster.led_shippingaddress1 = txtShippingAdd1.Text.Trim();
                ledgermaster.led_shippingaddress2 = txtShippingAdd2.Text.Trim();
                ledgermaster.led_address2 = txtAdd3.Text.Trim();
                ledgermaster.led_state = txtState.Text.Trim();
                ledgermaster.led_pincode = txtPin.Text.Trim();
				ledgermaster.led_transport = txtTransport.Text.Trim();
				ledgermaster.led_ownername = txtOwnerName.Text.Trim();
				ledgermaster.led_ownerphone = txtOwnerPhone.Text.Trim();
				ledgermaster.led_managername = txtManagerName.Text.Trim();
				ledgermaster.led_managerphone = txtManagerPhone.Text.Trim();
                ledgermaster.rt_id = Convert.ToInt64(cboAreaCode.SelectedValue);
                ledgermaster.vh_id = Convert.ToInt64(cboVehicleNo.SelectedValue);
                ledgermaster.led_deliveryorder = txtDeliveryOrder.Text.Trim();
                ledgermaster.led_vehicleno = txtVehicleNo.Text.Trim();
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
				else if ((ledgermaster.led_ratetype == string.Empty && cboType.Text == "Customer") || (ledgermaster.led_ratetype == "---Select---" && cboType.Text == "Customer")|| (cboratetype.SelectedIndex <= 0 && cboType.Text == "Customer"))
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
						inventoryDataContext.usp_ledgermasterInsert(ledgermaster.led_agid, ledgermaster.led_accountcode, ledgermaster.led_accounttype, ledgermaster.led_name, ledgermaster.led_address, ledgermaster.led_address1, ledgermaster.led_address2, ledgermaster.led_shippingaddress1, ledgermaster.led_shippingaddress2, ledgermaster.led_state, ledgermaster.led_tname, ledgermaster.led_taddress, ledgermaster.led_taddress1, ledgermaster.led_taddress2, ledgermaster.led_pincode, ledgermaster.led_transport, ledgermaster.led_ownerphone, ledgermaster.led_ownername, ledgermaster.led_managername, ledgermaster.led_managerphone, ledgermaster.led_deliveryorder, ledgermaster.led_vehicleno, ledgermaster.led_tin, ledgermaster.led_isfreight, ledgermaster.led_cst, ledgermaster.led_refno, global.ucode, global.comid, ledgermaster.rt_id, ledgermaster.vh_id, global.sysdate, ledgermaster.led_ratetype, ledgermaster.led_disper);
						MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						goto IL_0521;
					}
				}
				else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					inventoryDataContext.usp_ledgermasterUpdate(id, ledgermaster.led_agid, ledgermaster.led_accountcode, ledgermaster.led_accounttype, ledgermaster.led_name, ledgermaster.led_address, ledgermaster.led_address1, ledgermaster.led_shippingaddress1, ledgermaster.led_shippingaddress2, ledgermaster.led_address2, ledgermaster.led_state, ledgermaster.led_tname, ledgermaster.led_taddress, ledgermaster.led_taddress1, ledgermaster.led_taddress2, ledgermaster.led_pincode, ledgermaster.led_transport, ledgermaster.led_ownerphone, ledgermaster.led_ownername, ledgermaster.led_managername, ledgermaster.led_managerphone,ledgermaster.led_deliveryorder, ledgermaster.led_vehicleno,ledgermaster.led_tin,ledgermaster.led_isfreight, ledgermaster.led_cst, ledgermaster.led_refno, global.ucode, global.comid, ledgermaster.rt_id, ledgermaster.vh_id, global.sysdate, ledgermaster.led_ratetype, ledgermaster.led_disper);
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
			if (cboType.Text == "Supplier")
			{
				cboReference.Enabled = true;                
				ledgermasterBindingSource.DataSource = inventoryDataContext.ledgermasters.Where((ledgermaster li) => li.led_accounttype == "Agent" || li.led_id == 0);
				cboReference.SelectedValue = 0;
                cboratetype.SelectedIndex = 1;
            }
			else
			{
				cboReference.Enabled = false;              
                cboReference.SelectedValue = 0;
                cboratetype.SelectedIndex = 0;
				cboReference.Text = "";
			}
            if (cboType.Text == "Customer")
            {
                cboAreaCode.Enabled = true;
                cboVehicleNo.Enabled = true;
                cboratetype.Enabled = true;
                txtDeliveryOrder.Enabled = true;
            }
            else
            {
                cboAreaCode.Enabled = false;
                cboVehicleNo.Enabled = false;
                cboratetype.Enabled = false;                
                txtDeliveryOrder.Enabled = false;
                cboAreaCode.SelectedValue = 0;
                cboVehicleNo.SelectedValue = 0;
                txtDeliveryOrder.Text = "";
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
			dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, txtSearch.Text, txtSearchbyCity.Text, txtSearchByAreaCode.Text, num);
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
			dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, txtSearch.Text, txtSearchbyCity.Text, txtSearchByAreaCode.Text, num);
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
			CountofLedgers = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, null, num).Count();
			lblCount.Text = CountofLedgers.ToString();
			dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, null, num);
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.a1Paneltitle = new mylib.a1panel();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSearchbyCity = new System.Windows.Forms.TextBox();
            this.txtSearchByAreaCode = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.cboGridReference = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.lblSearchAreaCode = new System.Windows.Forms.Label();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.ledidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledagidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lednameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaccountcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledratetypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaccounttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leddeliveryorderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtaddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtaddress1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtaddress2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledpincodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtransportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledownerphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledownernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledmanagernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledmanagerphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledtinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledisfreightDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ledcstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leddisperDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledrefnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledudateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uspledgermasterSelectResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblEntry = new System.Windows.Forms.TableLayoutPanel();
            this.cboVehicleNo = new System.Windows.Forms.ComboBox();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.txtManagerName = new System.Windows.Forms.TextBox();
            this.txtManagerPhone = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lbltamil = new System.Windows.Forms.Label();
            this.cbIsFreight = new System.Windows.Forms.CheckBox();
            this.txtCst = new System.Windows.Forms.TextBox();
            this.cboAreaCode = new System.Windows.Forms.ComboBox();
            this.routeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.txtOwnerPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblref = new System.Windows.Forms.Label();
            this.cboReference = new System.Windows.Forms.ComboBox();
            this.ledgermasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.txtAdd1 = new System.Windows.Forms.TextBox();
            this.txtAdd2 = new System.Windows.Forms.TextBox();
            this.txtShippingAdd1 = new System.Windows.Forms.TextBox();
            this.txtShippingAdd2 = new System.Windows.Forms.TextBox();
            this.txtAdd3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblShipingAdd1 = new System.Windows.Forms.Label();
            this.lblShippingAdd2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDisPer = new mylib.decimalbox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.txtTin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeliveryOrder = new System.Windows.Forms.TextBox();
            this.lblDeliveryOrder = new System.Windows.Forms.Label();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).BeginInit();
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
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tblMain.Size = new System.Drawing.Size(1846, 1074);
            this.tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            this.tblSearch.ColumnCount = 9;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tblSearch.Controls.Add(this.lblSearch, 0, 0);
            this.tblSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tblSearch.Controls.Add(this.label20, 2, 0);
            this.tblSearch.Controls.Add(this.txtSearchbyCity, 3, 0);
            this.tblSearch.Controls.Add(this.txtSearchByAreaCode, 5, 0);
            this.tblSearch.Controls.Add(this.lblCount, 8, 0);
            this.tblSearch.Controls.Add(this.cboGridReference, 7, 0);
            this.tblSearch.Controls.Add(this.label24, 6, 0);
            this.tblSearch.Controls.Add(this.lblSearchAreaCode, 4, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(5, 482);
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
            this.lblSearch.Location = new System.Drawing.Point(4, 1);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(166, 56);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search By Ledger Name";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(208, 5);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 35);
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
            this.label20.Location = new System.Drawing.Point(412, 15);
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
            this.txtSearchbyCity.Location = new System.Drawing.Point(616, 5);
            this.txtSearchbyCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchbyCity.MaxLength = 50;
            this.txtSearchbyCity.Name = "txtSearchbyCity";
            this.txtSearchbyCity.Size = new System.Drawing.Size(195, 35);
            this.txtSearchbyCity.TabIndex = 1;
            this.txtSearchbyCity.TextChanged += new System.EventHandler(this.txtSearchItemCode_TextChanged);
            this.txtSearchbyCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtSearchByAreaCode
            // 
            this.txtSearchByAreaCode.BackColor = System.Drawing.Color.White;
            this.txtSearchByAreaCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchByAreaCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSearchByAreaCode.Location = new System.Drawing.Point(1024, 5);
            this.txtSearchByAreaCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearchByAreaCode.MaxLength = 50;
            this.txtSearchByAreaCode.Name = "txtSearchByAreaCode";
            this.txtSearchByAreaCode.Size = new System.Drawing.Size(195, 35);
            this.txtSearchByAreaCode.TabIndex = 13;
            this.txtSearchByAreaCode.TextChanged += new System.EventHandler(this.txtSearchByAreaCode_TextChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblCount.Location = new System.Drawing.Point(1640, 0);
            this.lblCount.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(24, 35);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = ".";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cboGridReference.Location = new System.Drawing.Point(1432, 5);
            this.cboGridReference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboGridReference.Name = "cboGridReference";
            this.cboGridReference.Size = new System.Drawing.Size(195, 36);
            this.cboGridReference.TabIndex = 2;
            this.cboGridReference.ValueMember = "led_id";
            this.cboGridReference.TextChanged += new System.EventHandler(this.cboGridReference_TextChanged);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label24.Location = new System.Drawing.Point(1228, 15);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(131, 28);
            this.label24.TabIndex = 2;
            this.label24.Text = "Reference";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearchAreaCode
            // 
            this.lblSearchAreaCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearchAreaCode.AutoSize = true;
            this.lblSearchAreaCode.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchAreaCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSearchAreaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblSearchAreaCode.Location = new System.Drawing.Point(820, 1);
            this.lblSearchAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchAreaCode.Name = "lblSearchAreaCode";
            this.lblSearchAreaCode.Size = new System.Drawing.Size(189, 56);
            this.lblSearchAreaCode.TabIndex = 12;
            this.lblSearchAreaCode.Text = "Search By Area Code";
            this.lblSearchAreaCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgview
            // 
            this.dgview.AllowUserToAddRows = false;
            this.dgview.AllowUserToDeleteRows = false;
            this.dgview.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgview.AutoGenerateColumns = false;
            this.dgview.BackgroundColor = System.Drawing.Color.White;
            this.dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgview.ColumnHeadersHeight = 28;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ledidDataGridViewTextBoxColumn,
            this.ledagidDataGridViewTextBoxColumn,
            this.lednameDataGridViewTextBoxColumn,
            this.ledaccountcodeDataGridViewTextBoxColumn,
            this.ledratetypeDataGridViewTextBoxColumn,
            this.ledaccounttypeDataGridViewTextBoxColumn,
            this.leddeliveryorderDataGridViewTextBoxColumn,
            this.ledaddressDataGridViewTextBoxColumn,
            this.ledaddress1DataGridViewTextBoxColumn,
            this.ledaddress2DataGridViewTextBoxColumn,
            this.ledtnameDataGridViewTextBoxColumn,
            this.ledtaddressDataGridViewTextBoxColumn,
            this.ledtaddress1DataGridViewTextBoxColumn,
            this.ledtaddress2DataGridViewTextBoxColumn,
            this.ledpincodeDataGridViewTextBoxColumn,
            this.ledtransportDataGridViewTextBoxColumn,
            this.ledownerphoneDataGridViewTextBoxColumn,
            this.ledownernameDataGridViewTextBoxColumn,
            this.ledmanagernameDataGridViewTextBoxColumn,
            this.ledmanagerphoneDataGridViewTextBoxColumn,
            this.ledtinDataGridViewTextBoxColumn,
            this.ledisfreightDataGridViewCheckBoxColumn,
            this.ledcstDataGridViewTextBoxColumn,
            this.leddisperDataGridViewTextBoxColumn,
            this.ledrefnoDataGridViewTextBoxColumn,
            this.usersuidDataGridViewTextBoxColumn,
            this.usersnameDataGridViewTextBoxColumn,
            this.comnameDataGridViewTextBoxColumn,
            this.comidDataGridViewTextBoxColumn,
            this.ledudateDataGridViewTextBoxColumn});
            this.dgview.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgview.DataSource = this.uspledgermasterSelectResultBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgview.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgview.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgview.Location = new System.Drawing.Point(5, 552);
            this.dgview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgview.MultiSelect = false;
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgview.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgview.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview.Size = new System.Drawing.Size(1836, 446);
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
            // ledagidDataGridViewTextBoxColumn
            // 
            this.ledagidDataGridViewTextBoxColumn.DataPropertyName = "led_agid";
            this.ledagidDataGridViewTextBoxColumn.HeaderText = "led_agid";
            this.ledagidDataGridViewTextBoxColumn.Name = "ledagidDataGridViewTextBoxColumn";
            this.ledagidDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledagidDataGridViewTextBoxColumn.Visible = false;
            // 
            // lednameDataGridViewTextBoxColumn
            // 
            this.lednameDataGridViewTextBoxColumn.DataPropertyName = "led_name";
            this.lednameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.lednameDataGridViewTextBoxColumn.Name = "lednameDataGridViewTextBoxColumn";
            this.lednameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lednameDataGridViewTextBoxColumn.Width = 200;
            // 
            // ledaccountcodeDataGridViewTextBoxColumn
            // 
            this.ledaccountcodeDataGridViewTextBoxColumn.DataPropertyName = "led_accountcode";
            this.ledaccountcodeDataGridViewTextBoxColumn.HeaderText = "Account Code";
            this.ledaccountcodeDataGridViewTextBoxColumn.Name = "ledaccountcodeDataGridViewTextBoxColumn";
            this.ledaccountcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledaccountcodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledratetypeDataGridViewTextBoxColumn
            // 
            this.ledratetypeDataGridViewTextBoxColumn.DataPropertyName = "led_ratetype";
            this.ledratetypeDataGridViewTextBoxColumn.HeaderText = "led_ratetype";
            this.ledratetypeDataGridViewTextBoxColumn.Name = "ledratetypeDataGridViewTextBoxColumn";
            this.ledratetypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledratetypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledaccounttypeDataGridViewTextBoxColumn
            // 
            this.ledaccounttypeDataGridViewTextBoxColumn.DataPropertyName = "led_accounttype";
            this.ledaccounttypeDataGridViewTextBoxColumn.HeaderText = "Account Type";
            this.ledaccounttypeDataGridViewTextBoxColumn.Name = "ledaccounttypeDataGridViewTextBoxColumn";
            this.ledaccounttypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledaccounttypeDataGridViewTextBoxColumn.Width = 200;
            // 
            // leddeliveryorderDataGridViewTextBoxColumn
            // 
            this.leddeliveryorderDataGridViewTextBoxColumn.DataPropertyName = "led_deliveryorder";
            this.leddeliveryorderDataGridViewTextBoxColumn.HeaderText = "Delivery Order";
            this.leddeliveryorderDataGridViewTextBoxColumn.Name = "leddeliveryorderDataGridViewTextBoxColumn";
            this.leddeliveryorderDataGridViewTextBoxColumn.ReadOnly = true;
            this.leddeliveryorderDataGridViewTextBoxColumn.Width = 200;
            // 
            // ledaddressDataGridViewTextBoxColumn
            // 
            this.ledaddressDataGridViewTextBoxColumn.DataPropertyName = "led_address";
            this.ledaddressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.ledaddressDataGridViewTextBoxColumn.Name = "ledaddressDataGridViewTextBoxColumn";
            this.ledaddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledaddressDataGridViewTextBoxColumn.ToolTipText = "Addr";
            this.ledaddressDataGridViewTextBoxColumn.Width = 250;
            // 
            // ledaddress1DataGridViewTextBoxColumn
            // 
            this.ledaddress1DataGridViewTextBoxColumn.DataPropertyName = "led_address1";
            this.ledaddress1DataGridViewTextBoxColumn.HeaderText = "Address 1";
            this.ledaddress1DataGridViewTextBoxColumn.Name = "ledaddress1DataGridViewTextBoxColumn";
            this.ledaddress1DataGridViewTextBoxColumn.ReadOnly = true;
            this.ledaddress1DataGridViewTextBoxColumn.Width = 250;
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
            this.ledtnameDataGridViewTextBoxColumn.HeaderText = "Tamil Name";
            this.ledtnameDataGridViewTextBoxColumn.Name = "ledtnameDataGridViewTextBoxColumn";
            this.ledtnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledtnameDataGridViewTextBoxColumn.Width = 200;
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
            // ledownerphoneDataGridViewTextBoxColumn
            // 
            this.ledownerphoneDataGridViewTextBoxColumn.DataPropertyName = "led_ownerphone";
            this.ledownerphoneDataGridViewTextBoxColumn.HeaderText = "led_ownerphone";
            this.ledownerphoneDataGridViewTextBoxColumn.Name = "ledownerphoneDataGridViewTextBoxColumn";
            this.ledownerphoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledownerphoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledownernameDataGridViewTextBoxColumn
            // 
            this.ledownernameDataGridViewTextBoxColumn.DataPropertyName = "led_ownername";
            this.ledownernameDataGridViewTextBoxColumn.HeaderText = "led_ownername";
            this.ledownernameDataGridViewTextBoxColumn.Name = "ledownernameDataGridViewTextBoxColumn";
            this.ledownernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledownernameDataGridViewTextBoxColumn.Visible = false;
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
            // ledisfreightDataGridViewCheckBoxColumn
            // 
            this.ledisfreightDataGridViewCheckBoxColumn.DataPropertyName = "led_isfreight";
            this.ledisfreightDataGridViewCheckBoxColumn.HeaderText = "led_isfreight";
            this.ledisfreightDataGridViewCheckBoxColumn.Name = "ledisfreightDataGridViewCheckBoxColumn";
            this.ledisfreightDataGridViewCheckBoxColumn.ReadOnly = true;
            this.ledisfreightDataGridViewCheckBoxColumn.Visible = false;
            // 
            // ledcstDataGridViewTextBoxColumn
            // 
            this.ledcstDataGridViewTextBoxColumn.DataPropertyName = "led_cst";
            this.ledcstDataGridViewTextBoxColumn.HeaderText = "led_cst";
            this.ledcstDataGridViewTextBoxColumn.Name = "ledcstDataGridViewTextBoxColumn";
            this.ledcstDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledcstDataGridViewTextBoxColumn.Visible = false;
            // 
            // leddisperDataGridViewTextBoxColumn
            // 
            this.leddisperDataGridViewTextBoxColumn.DataPropertyName = "led_disper";
            this.leddisperDataGridViewTextBoxColumn.HeaderText = "led_disper";
            this.leddisperDataGridViewTextBoxColumn.Name = "leddisperDataGridViewTextBoxColumn";
            this.leddisperDataGridViewTextBoxColumn.ReadOnly = true;
            this.leddisperDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledrefnoDataGridViewTextBoxColumn
            // 
            this.ledrefnoDataGridViewTextBoxColumn.DataPropertyName = "led_refno";
            this.ledrefnoDataGridViewTextBoxColumn.HeaderText = "led_refno";
            this.ledrefnoDataGridViewTextBoxColumn.Name = "ledrefnoDataGridViewTextBoxColumn";
            this.ledrefnoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledrefnoDataGridViewTextBoxColumn.Visible = false;
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
            // comnameDataGridViewTextBoxColumn
            // 
            this.comnameDataGridViewTextBoxColumn.DataPropertyName = "com_name";
            this.comnameDataGridViewTextBoxColumn.HeaderText = "com_name";
            this.comnameDataGridViewTextBoxColumn.Name = "comnameDataGridViewTextBoxColumn";
            this.comnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.comnameDataGridViewTextBoxColumn.Visible = false;
            // 
            // comidDataGridViewTextBoxColumn
            // 
            this.comidDataGridViewTextBoxColumn.DataPropertyName = "com_id";
            this.comidDataGridViewTextBoxColumn.HeaderText = "com_id";
            this.comidDataGridViewTextBoxColumn.Name = "comidDataGridViewTextBoxColumn";
            this.comidDataGridViewTextBoxColumn.ReadOnly = true;
            this.comidDataGridViewTextBoxColumn.Visible = false;
            // 
            // ledudateDataGridViewTextBoxColumn
            // 
            this.ledudateDataGridViewTextBoxColumn.DataPropertyName = "led_udate";
            this.ledudateDataGridViewTextBoxColumn.HeaderText = "led_udate";
            this.ledudateDataGridViewTextBoxColumn.Name = "ledudateDataGridViewTextBoxColumn";
            this.ledudateDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledudateDataGridViewTextBoxColumn.Visible = false;
            // 
            // uspledgermasterSelectResultBindingSource
            // 
            this.uspledgermasterSelectResultBindingSource.DataSource = typeof(standard.classes.usp_ledgermasterSelectResult);
            // 
            // tblEntry
            // 
            this.tblEntry.ColumnCount = 7;
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblEntry.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEntry.Controls.Add(this.cboVehicleNo, 3, 5);
            this.tblEntry.Controls.Add(this.label13, 2, 5);
            this.tblEntry.Controls.Add(this.txtPartyName, 1, 0);
            this.tblEntry.Controls.Add(this.label1, 0, 0);
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
            this.tblEntry.Controls.Add(this.txtManagerName, 6, 0);
            this.tblEntry.Controls.Add(this.txtManagerPhone, 6, 1);
            this.tblEntry.Controls.Add(this.label21, 6, 4);
            this.tblEntry.Controls.Add(this.lbltamil, 4, 6);
            this.tblEntry.Controls.Add(this.cbIsFreight, 5, 5);
            this.tblEntry.Controls.Add(this.txtCst, 6, 5);
            this.tblEntry.Controls.Add(this.cboAreaCode, 3, 4);
            this.tblEntry.Controls.Add(this.lblAreaCode, 2, 4);
            this.tblEntry.Controls.Add(this.txtOwnerPhone, 3, 3);
            this.tblEntry.Controls.Add(this.label8, 2, 3);
            this.tblEntry.Controls.Add(this.txtOwnerName, 3, 2);
            this.tblEntry.Controls.Add(this.label15, 2, 2);
            this.tblEntry.Controls.Add(this.txtPin, 3, 1);
            this.tblEntry.Controls.Add(this.label16, 2, 1);
            this.tblEntry.Controls.Add(this.label3, 0, 1);
            this.tblEntry.Controls.Add(this.cboType, 1, 1);
            this.tblEntry.Controls.Add(this.lblref, 0, 2);
            this.tblEntry.Controls.Add(this.cboReference, 1, 2);
            this.tblEntry.Controls.Add(this.label17, 0, 3);
            this.tblEntry.Controls.Add(this.txtAdd1, 1, 3);
            this.tblEntry.Controls.Add(this.txtAdd2, 1, 4);
            this.tblEntry.Controls.Add(this.txtShippingAdd1, 1, 5);
            this.tblEntry.Controls.Add(this.txtShippingAdd2, 1, 6);
            this.tblEntry.Controls.Add(this.txtAdd3, 1, 7);
            this.tblEntry.Controls.Add(this.label4, 0, 4);
            this.tblEntry.Controls.Add(this.lblShipingAdd1, 0, 5);
            this.tblEntry.Controls.Add(this.lblShippingAdd2, 0, 6);
            this.tblEntry.Controls.Add(this.label11, 0, 7);
            this.tblEntry.Controls.Add(this.lblState, 0, 8);
            this.tblEntry.Controls.Add(this.txtState, 1, 8);
            this.tblEntry.Controls.Add(this.label2, 2, 0);
            this.tblEntry.Controls.Add(this.txtCode, 3, 0);
            this.tblEntry.Controls.Add(this.txtDisPer, 5, 8);
            this.tblEntry.Controls.Add(this.label6, 2, 8);
            this.tblEntry.Controls.Add(this.label23, 4, 8);
            this.tblEntry.Controls.Add(this.label12, 6, 2);
            this.tblEntry.Controls.Add(this.txtTransport, 6, 3);
            this.tblEntry.Controls.Add(this.txtTin, 3, 7);
            this.tblEntry.Controls.Add(this.label9, 2, 7);
            this.tblEntry.Controls.Add(this.txtDeliveryOrder, 3, 6);
            this.tblEntry.Controls.Add(this.lblDeliveryOrder, 2, 6);
            this.tblEntry.Controls.Add(this.txtVehicleNo, 3, 8);
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
            this.tblEntry.Size = new System.Drawing.Size(1836, 410);
            this.tblEntry.TabIndex = 1;
            // 
            // cboVehicleNo
            // 
            this.cboVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVehicleNo.DataSource = this.vehicleBindingSource;
            this.cboVehicleNo.DisplayMember = "vh_number";
            this.cboVehicleNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboVehicleNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboVehicleNo.FormattingEnabled = true;
            this.cboVehicleNo.Location = new System.Drawing.Point(754, 235);
            this.cboVehicleNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboVehicleNo.Name = "cboVehicleNo";
            this.cboVehicleNo.Size = new System.Drawing.Size(289, 36);
            this.cboVehicleNo.TabIndex = 15;
            this.cboVehicleNo.ValueMember = "vh_id";
            this.cboVehicleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataSource = typeof(standard.classes.vehicle);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label13.Location = new System.Drawing.Point(539, 239);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 28);
            this.label13.TabIndex = 18;
            this.label13.Text = "Vehicle No.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPartyName
            // 
            this.txtPartyName.BackColor = System.Drawing.Color.White;
            this.txtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPartyName.Location = new System.Drawing.Point(250, 5);
            this.txtPartyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPartyName.MaxLength = 50;
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(281, 35);
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
            this.txtTamilAdd3.TabIndex = 22;
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
            this.txtTamilAdd2.TabIndex = 21;
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
            this.txtTamilAdd1.TabIndex = 20;
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
            this.txtTamilPartyName.TabIndex = 19;
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
            "WHOLE SALE RATE  (C)"});
            this.cboratetype.Location = new System.Drawing.Point(1281, 6);
            this.cboratetype.Margin = new System.Windows.Forms.Padding(6);
            this.cboratetype.Name = "cboratetype";
            this.cboratetype.Size = new System.Drawing.Size(286, 36);
            this.cboratetype.TabIndex = 18;
            this.cboratetype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
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
            // txtManagerName
            // 
            this.txtManagerName.BackColor = System.Drawing.Color.White;
            this.txtManagerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManagerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtManagerName.Location = new System.Drawing.Point(1579, 5);
            this.txtManagerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtManagerName.MaxLength = 50;
            this.txtManagerName.Name = "txtManagerName";
            this.txtManagerName.Size = new System.Drawing.Size(253, 35);
            this.txtManagerName.TabIndex = 11;
            this.txtManagerName.Visible = false;
            this.txtManagerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtManagerPhone
            // 
            this.txtManagerPhone.BackColor = System.Drawing.Color.White;
            this.txtManagerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManagerPhone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtManagerPhone.Location = new System.Drawing.Point(1579, 51);
            this.txtManagerPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtManagerPhone.MaxLength = 50;
            this.txtManagerPhone.Name = "txtManagerPhone";
            this.txtManagerPhone.Size = new System.Drawing.Size(253, 35);
            this.txtManagerPhone.TabIndex = 12;
            this.txtManagerPhone.Visible = false;
            this.txtManagerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label21.Location = new System.Drawing.Point(1579, 193);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 28);
            this.label21.TabIndex = 26;
            this.label21.Text = "Cst";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label21.Visible = false;
            // 
            // lbltamil
            // 
            this.lbltamil.BackColor = System.Drawing.Color.White;
            this.lbltamil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblEntry.SetColumnSpan(this.lbltamil, 3);
            this.lbltamil.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbltamil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbltamil.Location = new System.Drawing.Point(1054, 276);
            this.lbltamil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltamil.Name = "lbltamil";
            this.tblEntry.SetRowSpan(this.lbltamil, 2);
            this.lbltamil.Size = new System.Drawing.Size(520, 87);
            this.lbltamil.TabIndex = 22;
            // 
            // cbIsFreight
            // 
            this.cbIsFreight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbIsFreight.AutoSize = true;
            this.cbIsFreight.BackColor = System.Drawing.Color.Transparent;
            this.cbIsFreight.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbIsFreight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.cbIsFreight.Location = new System.Drawing.Point(1278, 237);
            this.cbIsFreight.Name = "cbIsFreight";
            this.cbIsFreight.Size = new System.Drawing.Size(151, 32);
            this.cbIsFreight.TabIndex = 31;
            this.cbIsFreight.Text = "Is Freight";
            this.cbIsFreight.UseVisualStyleBackColor = false;
            this.cbIsFreight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbIsFreight_KeyDown);
            // 
            // txtCst
            // 
            this.txtCst.BackColor = System.Drawing.Color.White;
            this.txtCst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCst.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCst.Location = new System.Drawing.Point(1579, 235);
            this.txtCst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCst.MaxLength = 50;
            this.txtCst.Name = "txtCst";
            this.txtCst.Size = new System.Drawing.Size(253, 35);
            this.txtCst.TabIndex = 23;
            this.txtCst.Visible = false;
            this.txtCst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // cboAreaCode
            // 
            this.cboAreaCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAreaCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAreaCode.DataSource = this.routeBindingSource;
            this.cboAreaCode.DisplayMember = "rt_name";
            this.cboAreaCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAreaCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboAreaCode.FormattingEnabled = true;
            this.cboAreaCode.Location = new System.Drawing.Point(754, 189);
            this.cboAreaCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboAreaCode.Name = "cboAreaCode";
            this.cboAreaCode.Size = new System.Drawing.Size(289, 36);
            this.cboAreaCode.TabIndex = 14;
            this.cboAreaCode.ValueMember = "rt_id";
            this.cboAreaCode.SelectedValueChanged += new System.EventHandler(this.cboAreaCode_SelectedValueChanged);
            this.cboAreaCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // routeBindingSource
            // 
            this.routeBindingSource.DataSource = typeof(standard.classes.route);
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.BackColor = System.Drawing.Color.Transparent;
            this.lblAreaCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblAreaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblAreaCode.Location = new System.Drawing.Point(539, 193);
            this.lblAreaCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(130, 28);
            this.lblAreaCode.TabIndex = 17;
            this.lblAreaCode.Text = "Area Code";
            this.lblAreaCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOwnerPhone
            // 
            this.txtOwnerPhone.BackColor = System.Drawing.Color.White;
            this.txtOwnerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerPhone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtOwnerPhone.Location = new System.Drawing.Point(754, 143);
            this.txtOwnerPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOwnerPhone.MaxLength = 50;
            this.txtOwnerPhone.Name = "txtOwnerPhone";
            this.txtOwnerPhone.Size = new System.Drawing.Size(290, 35);
            this.txtOwnerPhone.TabIndex = 13;
            this.txtOwnerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label8.Location = new System.Drawing.Point(539, 147);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Owner Phone";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.BackColor = System.Drawing.Color.White;
            this.txtOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOwnerName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtOwnerName.Location = new System.Drawing.Point(754, 97);
            this.txtOwnerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOwnerName.MaxLength = 50;
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(290, 35);
            this.txtOwnerName.TabIndex = 12;
            this.txtOwnerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label15.Location = new System.Drawing.Point(539, 101);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 28);
            this.label15.TabIndex = 16;
            this.label15.Text = "Owner Name";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.White;
            this.txtPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPin.Location = new System.Drawing.Point(754, 51);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPin.MaxLength = 50;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(290, 35);
            this.txtPin.TabIndex = 11;
            this.txtPin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label16.Location = new System.Drawing.Point(539, 55);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 28);
            this.label16.TabIndex = 14;
            this.label16.Text = "Pincode";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(4, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Party Type ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            "Supplier",
            "Agent"});
            this.cboType.Location = new System.Drawing.Point(250, 51);
            this.cboType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(281, 36);
            this.cboType.TabIndex = 2;
            this.cboType.TextChanged += new System.EventHandler(this.cboType_TextChanged);
            this.cboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.cboType.Leave += new System.EventHandler(this.cboType_Leave);
            // 
            // lblref
            // 
            this.lblref.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblref.AutoSize = true;
            this.lblref.BackColor = System.Drawing.Color.Transparent;
            this.lblref.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblref.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblref.Location = new System.Drawing.Point(4, 101);
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
            this.cboReference.Location = new System.Drawing.Point(250, 97);
            this.cboReference.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboReference.Name = "cboReference";
            this.cboReference.Size = new System.Drawing.Size(281, 36);
            this.cboReference.TabIndex = 3;
            this.cboReference.ValueMember = "led_id";
            this.cboReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // ledgermasterBindingSource
            // 
            this.ledgermasterBindingSource.DataSource = typeof(standard.classes.ledgermaster);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label17.Location = new System.Drawing.Point(4, 147);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 28);
            this.label17.TabIndex = 8;
            this.label17.Text = "Address 1";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAdd1
            // 
            this.txtAdd1.BackColor = System.Drawing.Color.White;
            this.txtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtAdd1.Location = new System.Drawing.Point(250, 143);
            this.txtAdd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdd1.MaxLength = 50;
            this.txtAdd1.Name = "txtAdd1";
            this.txtAdd1.Size = new System.Drawing.Size(281, 35);
            this.txtAdd1.TabIndex = 4;
            this.txtAdd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtAdd2
            // 
            this.txtAdd2.BackColor = System.Drawing.Color.White;
            this.txtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtAdd2.Location = new System.Drawing.Point(250, 189);
            this.txtAdd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdd2.MaxLength = 50;
            this.txtAdd2.Name = "txtAdd2";
            this.txtAdd2.Size = new System.Drawing.Size(281, 35);
            this.txtAdd2.TabIndex = 5;
            this.txtAdd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtShippingAdd1
            // 
            this.txtShippingAdd1.BackColor = System.Drawing.Color.White;
            this.txtShippingAdd1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingAdd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtShippingAdd1.Location = new System.Drawing.Point(250, 235);
            this.txtShippingAdd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShippingAdd1.MaxLength = 50;
            this.txtShippingAdd1.Name = "txtShippingAdd1";
            this.txtShippingAdd1.Size = new System.Drawing.Size(281, 35);
            this.txtShippingAdd1.TabIndex = 6;
            this.txtShippingAdd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtShippingAdd2
            // 
            this.txtShippingAdd2.BackColor = System.Drawing.Color.White;
            this.txtShippingAdd2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShippingAdd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtShippingAdd2.Location = new System.Drawing.Point(250, 281);
            this.txtShippingAdd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShippingAdd2.MaxLength = 50;
            this.txtShippingAdd2.Name = "txtShippingAdd2";
            this.txtShippingAdd2.Size = new System.Drawing.Size(281, 35);
            this.txtShippingAdd2.TabIndex = 7;
            this.txtShippingAdd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtAdd3
            // 
            this.txtAdd3.BackColor = System.Drawing.Color.White;
            this.txtAdd3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdd3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtAdd3.Location = new System.Drawing.Point(250, 327);
            this.txtAdd3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAdd3.MaxLength = 50;
            this.txtAdd3.Name = "txtAdd3";
            this.txtAdd3.Size = new System.Drawing.Size(281, 35);
            this.txtAdd3.TabIndex = 8;
            this.txtAdd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(4, 193);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Address 2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShipingAdd1
            // 
            this.lblShipingAdd1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShipingAdd1.AutoSize = true;
            this.lblShipingAdd1.BackColor = System.Drawing.Color.Transparent;
            this.lblShipingAdd1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblShipingAdd1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblShipingAdd1.Location = new System.Drawing.Point(4, 239);
            this.lblShipingAdd1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShipingAdd1.Name = "lblShipingAdd1";
            this.lblShipingAdd1.Size = new System.Drawing.Size(234, 28);
            this.lblShipingAdd1.TabIndex = 9;
            this.lblShipingAdd1.Text = "Shipping Address 1";
            this.lblShipingAdd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShippingAdd2
            // 
            this.lblShippingAdd2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblShippingAdd2.AutoSize = true;
            this.lblShippingAdd2.BackColor = System.Drawing.Color.Transparent;
            this.lblShippingAdd2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblShippingAdd2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblShippingAdd2.Location = new System.Drawing.Point(4, 285);
            this.lblShippingAdd2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShippingAdd2.Name = "lblShippingAdd2";
            this.lblShippingAdd2.Size = new System.Drawing.Size(234, 28);
            this.lblShippingAdd2.TabIndex = 10;
            this.lblShippingAdd2.Text = "Shipping Address 2";
            this.lblShippingAdd2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label11.Location = new System.Drawing.Point(4, 331);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 28);
            this.label11.TabIndex = 12;
            this.label11.Text = "City";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblState
            // 
            this.lblState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblState.AutoSize = true;
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblState.Location = new System.Drawing.Point(4, 377);
            this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(75, 28);
            this.lblState.TabIndex = 13;
            this.lblState.Text = "State";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.Color.White;
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtState.Location = new System.Drawing.Point(250, 373);
            this.txtState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtState.MaxLength = 50;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(281, 35);
            this.txtState.TabIndex = 9;
            this.txtState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(539, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "State Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtCode.Location = new System.Drawing.Point(754, 5);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(292, 35);
            this.txtCode.TabIndex = 10;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtDisPer
            // 
            this.txtDisPer.AllowFormat = false;
            this.txtDisPer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDisPer.BackColor = System.Drawing.Color.White;
            this.txtDisPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisPer.DecimalPlaces = 2;
            this.txtDisPer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDisPer.Location = new System.Drawing.Point(1281, 374);
            this.txtDisPer.Margin = new System.Windows.Forms.Padding(6);
            this.txtDisPer.Name = "txtDisPer";
            this.txtDisPer.RightAlign = true;
            this.txtDisPer.Size = new System.Drawing.Size(287, 35);
            this.txtDisPer.TabIndex = 18;
            this.txtDisPer.TabStop = false;
            this.txtDisPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDisPer.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDisPer.Visible = false;
            this.txtDisPer.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDisPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label6.Location = new System.Drawing.Point(539, 379);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 24);
            this.label6.TabIndex = 2;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label23.Location = new System.Drawing.Point(1054, 377);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(149, 28);
            this.label23.TabIndex = 28;
            this.label23.Text = "Discount %";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label23.Visible = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label12.Location = new System.Drawing.Point(1579, 102);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 25);
            this.label12.TabIndex = 28;
            this.label12.Text = "Transport";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Visible = false;
            // 
            // txtTransport
            // 
            this.txtTransport.BackColor = System.Drawing.Color.White;
            this.txtTransport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransport.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTransport.Location = new System.Drawing.Point(1579, 143);
            this.txtTransport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransport.MaxLength = 50;
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(253, 35);
            this.txtTransport.TabIndex = 17;
            this.txtTransport.Visible = false;
            this.txtTransport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // txtTin
            // 
            this.txtTin.BackColor = System.Drawing.Color.White;
            this.txtTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTin.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTin.Location = new System.Drawing.Point(754, 327);
            this.txtTin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTin.MaxLength = 50;
            this.txtTin.Name = "txtTin";
            this.txtTin.Size = new System.Drawing.Size(290, 35);
            this.txtTin.TabIndex = 17;
            this.txtTin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.label9.Location = new System.Drawing.Point(539, 331);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 28);
            this.label9.TabIndex = 24;
            this.label9.Text = "GSTIN";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDeliveryOrder
            // 
            this.txtDeliveryOrder.BackColor = System.Drawing.Color.White;
            this.txtDeliveryOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryOrder.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryOrder.Location = new System.Drawing.Point(754, 281);
            this.txtDeliveryOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryOrder.MaxLength = 50;
            this.txtDeliveryOrder.Name = "txtDeliveryOrder";
            this.txtDeliveryOrder.Size = new System.Drawing.Size(290, 35);
            this.txtDeliveryOrder.TabIndex = 16;
            this.txtDeliveryOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            this.txtDeliveryOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeliveryOrder_KeyPress);
            // 
            // lblDeliveryOrder
            // 
            this.lblDeliveryOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDeliveryOrder.AutoSize = true;
            this.lblDeliveryOrder.BackColor = System.Drawing.Color.Transparent;
            this.lblDeliveryOrder.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDeliveryOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblDeliveryOrder.Location = new System.Drawing.Point(539, 285);
            this.lblDeliveryOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeliveryOrder.Name = "lblDeliveryOrder";
            this.lblDeliveryOrder.Size = new System.Drawing.Size(180, 28);
            this.lblDeliveryOrder.TabIndex = 17;
            this.lblDeliveryOrder.Text = "Delivery Order";
            this.lblDeliveryOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.BackColor = System.Drawing.Color.White;
            this.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVehicleNo.Enabled = false;
            this.txtVehicleNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtVehicleNo.Location = new System.Drawing.Point(754, 373);
            this.txtVehicleNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVehicleNo.MaxLength = 50;
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.ReadOnly = true;
            this.txtVehicleNo.Size = new System.Drawing.Size(290, 35);
            this.txtVehicleNo.TabIndex = 25;
            this.txtVehicleNo.Visible = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledgermasterBindingSource)).EndInit();
            this.tblCommand.ResumeLayout(false);
            this.tblCommand.PerformLayout();
            this.ResumeLayout(false);

		}

        private void txtDeliveryOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSearchByAreaCode_TextChanged(object sender, EventArgs e)
        {
            InventoryDataContext inventoryDataContext = new InventoryDataContext();
            int? num = Convert.ToInt32(cboGridReference.SelectedValue);
            int? num2 = num;
            if (num2.GetValueOrDefault() == 0 && num2.HasValue)
            {
                num = null;
            }
            dgview.DataSource = inventoryDataContext.usp_ledgermasterSelect(null, null, txtSearch.Text, txtSearchbyCity.Text, txtSearchByAreaCode.Text, num);
        }

        private void cbIsFreight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                btnSave.Focus();
            }
        }

        private void cboAreaCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboAreaCode.SelectedValue == null)
                return;

            int areaCode = Convert.ToInt32(cboAreaCode.SelectedValue);

            using (InventoryDataContext inventoryDataContext = new InventoryDataContext())
            {
                // Assuming usp_routeSelect returns one or more records with a VehicleNo field
                var route = inventoryDataContext.usp_routeSelect(areaCode, null).FirstOrDefault();

                if (route != null && route.rt_vehicleno != null)
                {
                    txtVehicleNo.Text = route.rt_vehicleno.ToString();
                }
                else
                {
                    txtVehicleNo.Text = string.Empty;
                }
            }
        }
    }
}
