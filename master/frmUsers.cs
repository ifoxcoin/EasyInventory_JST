using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
	public class frmUsers : Form
	{
		private int id = 0;

		private IContainer components = null;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private a1panel pnlview;

		private lightbutton cmdclose;

		private lightbutton cmddelete;

		private lightbutton cmdnew;

		private DataGridView dgview;

		private BindingSource userBindingSource;

		private DataGridViewTextBoxColumn usersuidDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn usersnameDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn userslockDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn userstypeDataGridViewTextBoxColumn;

		private lightbutton cmdsave;

		private a1panel pnlentry;

		private lightbutton cmdclear;

		private TextBox txtcpwd;

		private Label lblcpwd;

		private TextBox txtpwd;

		private Label lblpwd;

		private TextBox txtuser;

		private Label lbluname;

		public frmUsers()
		{
			InitializeComponent();
		}

		private void frmUsers_Load(object sender, EventArgs e)
		{
			try
			{
				LoadUsers();
				cmdnew.Focus();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void LoadUsers()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			userBindingSource.DataSource = inventoryDataContext.usp_usersSelect(null);
		}

		private void ClearUsers()
		{
			txtuser.Text = string.Empty;
			txtpwd.Text = string.Empty;
			txtcpwd.Text = string.Empty;
			cmddelete.Enabled = false;
			id = 0;
		}

		private void cmdnew_Click(object sender, EventArgs e)
		{
			ClearUsers();
			pnlentry.Enabled = true;
			txtuser.Focus();
		}

		private void cmddelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (id != 0)
				{
					if (Convert.ToString(cmdsave.Tag) == "A")
					{
						MessageBox.Show("Can not delete ADMIN...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
					{
						InventoryDataContext inventoryDataContext = new InventoryDataContext();
						inventoryDataContext.usp_usersDelete(id);
						ClearUsers();
						LoadUsers();
						pnlentry.Enabled = false;
						MessageBox.Show("Record deleted successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
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

		private void cmdsave_Click(object sender, EventArgs e)
		{
			try
			{
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				user at = new user();
				at.users_name = txtuser.Text.Trim();
				if (pnlentry.Enabled && id == 0)
				{
					if (at.users_name == string.Empty)
					{
						MessageBox.Show("Invalid 'Name'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						txtuser.Focus();
					}
					else if (txtpwd.Text != txtcpwd.Text)
					{
						MessageBox.Show("Password and Confirm passsword must be same", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtpwd.Text = string.Empty;
						txtcpwd.Text = string.Empty;
					}
					else if (txtpwd.Text.Length < 3)
					{
						MessageBox.Show("Password should have atleast three charactors", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						txtpwd.Focus();
					}
					else
					{
						at.users_pwd = security.Encrypt(txtpwd.Text, at.users_name);
						at.users_type = ((global.utype == "A") ? 'S' : 'U');
						var source = from b in inventoryDataContext.users
							where b.users_name == at.users_name && b.users_uid != (long)id
							select new
							{
								b.users_uid
							};
						if (source.Count() != 0)
						{
							MessageBox.Show("'Name' aleady exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							txtuser.Focus();
						}
						else if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
						{
							inventoryDataContext.usp_usersInsert(at.users_name, at.users_pwd, global.ucode, at.users_type, 'N');
							MessageBox.Show("UserName : " + at.users_name + " created successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							ClearUsers();
							LoadUsers();
							pnlentry.Enabled = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void cmdclear_Click(object sender, EventArgs e)
		{
			ClearUsers();
			LoadUsers();
			pnlentry.Enabled = false;
		}

		private void txtAccType_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.KeyChar = Convert.ToString(e.KeyChar).ToUpper()[0];
		}

		private void txtAccType_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtuser.Text.Trim() != string.Empty)
			{
				txtpwd.Focus();
			}
		}

		private void txtpwd_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtpwd.Text != string.Empty)
			{
				txtcpwd.Focus();
			}
		}

		private void txtcpwd_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtcpwd.Text != string.Empty)
			{
				cmdsave.Select();
			}
		}

		private void dgview_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			EditUsers();
		}

		private void EditUsers()
		{
			if (dgview.CurrentCell != null)
			{
				int rowIndex = dgview.CurrentCell.RowIndex;
				id = Convert.ToInt32(dgview["usersuidDataGridViewTextBoxColumn", rowIndex].Value);
				txtuser.Text = Convert.ToString(dgview["usersnameDataGridViewTextBoxColumn", rowIndex].Value);
				cmdsave.Tag = Convert.ToString(dgview["userstypeDataGridViewTextBoxColumn", rowIndex].Value);
				pnlentry.Enabled = true;
				cmddelete.Enabled = true;
				txtuser.Focus();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(standard.master.frmUsers));
			a1Paneltitle = new mylib.a1panel();
			lbltitle = new System.Windows.Forms.Label();
			pnlview = new mylib.a1panel();
			cmdclose = new mylib.lightbutton();
			cmddelete = new mylib.lightbutton();
			cmdnew = new mylib.lightbutton();
			dgview = new System.Windows.Forms.DataGridView();
			usersuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			usersnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			userslockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			userstypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			userBindingSource = new System.Windows.Forms.BindingSource(components);
			pnlentry = new mylib.a1panel();
			cmdclear = new mylib.lightbutton();
			cmdsave = new mylib.lightbutton();
			txtcpwd = new System.Windows.Forms.TextBox();
			lblcpwd = new System.Windows.Forms.Label();
			txtpwd = new System.Windows.Forms.TextBox();
			lblpwd = new System.Windows.Forms.Label();
			txtuser = new System.Windows.Forms.TextBox();
			lbluname = new System.Windows.Forms.Label();
			a1Paneltitle.SuspendLayout();
			pnlview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgview).BeginInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
			pnlentry.SuspendLayout();
			SuspendLayout();
			a1Paneltitle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
			a1Paneltitle.Controls.Add(lbltitle);
			a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
			a1Paneltitle.Image = null;
			a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
			a1Paneltitle.Location = new System.Drawing.Point(15, 12);
			a1Paneltitle.Name = "a1Paneltitle";
			a1Paneltitle.ShadowOffSet = 0;
			a1Paneltitle.Size = new System.Drawing.Size(983, 29);
			a1Paneltitle.TabIndex = 11;
			lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lbltitle.AutoSize = true;
			lbltitle.BackColor = System.Drawing.Color.Transparent;
			lbltitle.Font = new System.Drawing.Font("Georgia", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(19, 5);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(64, 18);
			lbltitle.TabIndex = 1;
			lbltitle.Text = "USERS";
			lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			pnlview.Location = new System.Drawing.Point(298, 47);
			pnlview.Name = "pnlview";
			pnlview.RoundCornerRadius = 25;
			pnlview.ShadowOffSet = 0;
			pnlview.Size = new System.Drawing.Size(700, 405);
			pnlview.TabIndex = 10;
			cmdclose.AutoSize = true;
			cmdclose.BackColor = System.Drawing.Color.Transparent;
			cmdclose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclose.Location = new System.Drawing.Point(216, 8);
			cmdclose.Name = "cmdclose";
			cmdclose.Size = new System.Drawing.Size(90, 30);
			cmdclose.TabIndex = 2;
			cmdclose.Text = "&Close";
			cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmdclose.UseVisualStyleBackColor = false;
			cmdclose.Click += new System.EventHandler(cmdclose_Click);
			cmddelete.AutoSize = true;
			cmddelete.BackColor = System.Drawing.Color.Transparent;
			cmddelete.Enabled = false;
			cmddelete.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmddelete.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmddelete.Location = new System.Drawing.Point(120, 8);
			cmddelete.Name = "cmddelete";
			cmddelete.Size = new System.Drawing.Size(90, 30);
			cmddelete.TabIndex = 1;
			cmddelete.Text = "&Delete";
			cmddelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmddelete.UseVisualStyleBackColor = false;
			cmddelete.Click += new System.EventHandler(cmddelete_Click);
			cmdnew.AutoSize = true;
			cmdnew.BackColor = System.Drawing.Color.Transparent;
			cmdnew.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdnew.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdnew.Location = new System.Drawing.Point(24, 8);
			cmdnew.Name = "cmdnew";
			cmdnew.Size = new System.Drawing.Size(90, 30);
			cmdnew.TabIndex = 0;
			cmdnew.Text = "&New";
			cmdnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmdnew.UseVisualStyleBackColor = false;
			cmdnew.Click += new System.EventHandler(cmdnew_Click);
			dgview.AllowUserToAddRows = false;
			dgview.AllowUserToDeleteRows = false;
			dgview.AllowUserToResizeRows = false;
			dgview.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dgview.AutoGenerateColumns = false;
			dgview.BackgroundColor = System.Drawing.Color.White;
			dgview.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dgview.Columns.AddRange(usersuidDataGridViewTextBoxColumn, usersnameDataGridViewTextBoxColumn, userslockDataGridViewTextBoxColumn, userstypeDataGridViewTextBoxColumn);
			dgview.Cursor = System.Windows.Forms.Cursors.Default;
			dgview.DataSource = userBindingSource;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dgview.DefaultCellStyle = dataGridViewCellStyle2;
			dgview.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold);
			dgview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			dgview.Location = new System.Drawing.Point(1, 45);
			dgview.MultiSelect = false;
			dgview.Name = "dgview";
			dgview.ReadOnly = true;
			dgview.RightToLeft = System.Windows.Forms.RightToLeft.No;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dgview.RowHeadersVisible = false;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			dgview.RowsDefaultCellStyle = dataGridViewCellStyle4;
			dgview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgview.Size = new System.Drawing.Size(696, 357);
			dgview.TabIndex = 3;
			dgview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgview_CellClick);
			usersuidDataGridViewTextBoxColumn.DataPropertyName = "users_uid";
			usersuidDataGridViewTextBoxColumn.HeaderText = "users_uid";
			usersuidDataGridViewTextBoxColumn.Name = "usersuidDataGridViewTextBoxColumn";
			usersuidDataGridViewTextBoxColumn.ReadOnly = true;
			usersuidDataGridViewTextBoxColumn.Visible = false;
			usersnameDataGridViewTextBoxColumn.DataPropertyName = "users_name";
			usersnameDataGridViewTextBoxColumn.HeaderText = "Users";
			usersnameDataGridViewTextBoxColumn.Name = "usersnameDataGridViewTextBoxColumn";
			usersnameDataGridViewTextBoxColumn.ReadOnly = true;
			usersnameDataGridViewTextBoxColumn.Width = 300;
			userslockDataGridViewTextBoxColumn.DataPropertyName = "users_lock";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			userslockDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
			userslockDataGridViewTextBoxColumn.HeaderText = "Lock";
			userslockDataGridViewTextBoxColumn.Name = "userslockDataGridViewTextBoxColumn";
			userslockDataGridViewTextBoxColumn.ReadOnly = true;
			userslockDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			userslockDataGridViewTextBoxColumn.Width = 50;
			userstypeDataGridViewTextBoxColumn.DataPropertyName = "users_type";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			userstypeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
			userstypeDataGridViewTextBoxColumn.HeaderText = "Type";
			userstypeDataGridViewTextBoxColumn.Name = "userstypeDataGridViewTextBoxColumn";
			userstypeDataGridViewTextBoxColumn.ReadOnly = true;
			userstypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			userstypeDataGridViewTextBoxColumn.Width = 50;
			userBindingSource.DataSource = typeof(standard.classes.user);
			pnlentry.BorderColor = System.Drawing.Color.Gray;
			pnlentry.Controls.Add(cmdclear);
			pnlentry.Controls.Add(cmdsave);
			pnlentry.Controls.Add(txtcpwd);
			pnlentry.Controls.Add(lblcpwd);
			pnlentry.Controls.Add(txtpwd);
			pnlentry.Controls.Add(lblpwd);
			pnlentry.Controls.Add(txtuser);
			pnlentry.Controls.Add(lbluname);
			pnlentry.Enabled = false;
			pnlentry.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			pnlentry.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			pnlentry.GradientStartColor = System.Drawing.Color.WhiteSmoke;
			pnlentry.Image = null;
			pnlentry.ImageLocation = new System.Drawing.Point(4, 4);
			pnlentry.Location = new System.Drawing.Point(15, 47);
			pnlentry.Name = "pnlentry";
			pnlentry.RoundCornerRadius = 25;
			pnlentry.ShadowOffSet = 0;
			pnlentry.Size = new System.Drawing.Size(277, 405);
			pnlentry.TabIndex = 12;
			cmdclear.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			cmdclear.BackColor = System.Drawing.Color.Transparent;
			cmdclear.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclear.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclear.Location = new System.Drawing.Point(170, 8);
			cmdclear.Name = "cmdclear";
			cmdclear.Size = new System.Drawing.Size(90, 30);
			cmdclear.TabIndex = 19;
			cmdclear.Text = "Cl&ear";
			cmdclear.UseVisualStyleBackColor = false;
			cmdclear.Click += new System.EventHandler(cmdclear_Click);
			cmdsave.BackColor = System.Drawing.Color.Transparent;
			cmdsave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdsave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdsave.Location = new System.Drawing.Point(74, 8);
			cmdsave.Name = "cmdsave";
			cmdsave.Size = new System.Drawing.Size(90, 30);
			cmdsave.TabIndex = 18;
			cmdsave.Text = "&Update";
			cmdsave.UseVisualStyleBackColor = false;
			cmdsave.Click += new System.EventHandler(cmdsave_Click);
			txtcpwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtcpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtcpwd.Location = new System.Drawing.Point(105, 125);
			txtcpwd.MaxLength = 15;
			txtcpwd.Name = "txtcpwd";
			txtcpwd.PasswordChar = '#';
			txtcpwd.Size = new System.Drawing.Size(169, 26);
			txtcpwd.TabIndex = 15;
			lblcpwd.AutoSize = true;
			lblcpwd.BackColor = System.Drawing.Color.Transparent;
			lblcpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lblcpwd.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcpwd.Location = new System.Drawing.Point(3, 127);
			lblcpwd.Name = "lblcpwd";
			lblcpwd.Size = new System.Drawing.Size(104, 18);
			lblcpwd.TabIndex = 17;
			lblcpwd.Text = "Reenter Pwd";
			txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtpwd.Location = new System.Drawing.Point(105, 98);
			txtpwd.MaxLength = 15;
			txtpwd.Name = "txtpwd";
			txtpwd.PasswordChar = '#';
			txtpwd.Size = new System.Drawing.Size(169, 26);
			txtpwd.TabIndex = 14;
			lblpwd.AutoSize = true;
			lblpwd.BackColor = System.Drawing.Color.Transparent;
			lblpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lblpwd.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpwd.Location = new System.Drawing.Point(3, 100);
			lblpwd.Name = "lblpwd";
			lblpwd.Size = new System.Drawing.Size(81, 18);
			lblpwd.TabIndex = 16;
			lblpwd.Text = "Password";
			txtuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtuser.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtuser.Location = new System.Drawing.Point(105, 71);
			txtuser.MaxLength = 25;
			txtuser.Name = "txtuser";
			txtuser.Size = new System.Drawing.Size(169, 26);
			txtuser.TabIndex = 12;
			lbluname.AutoSize = true;
			lbluname.BackColor = System.Drawing.Color.Transparent;
			lbluname.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lbluname.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbluname.Location = new System.Drawing.Point(3, 73);
			lbluname.Name = "lbluname";
			lbluname.Size = new System.Drawing.Size(90, 18);
			lbluname.TabIndex = 13;
			lbluname.Text = "User Name";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(1013, 465);
			base.Controls.Add(pnlentry);
			base.Controls.Add(a1Paneltitle);
			base.Controls.Add(pnlview);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "frmUsers";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Tag = "MASTER";
			Text = "USERS";
			base.Load += new System.EventHandler(frmUsers_Load);
			a1Paneltitle.ResumeLayout(false);
			a1Paneltitle.PerformLayout();
			pnlview.ResumeLayout(false);
			pnlview.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dgview).EndInit();
			((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
			pnlentry.ResumeLayout(false);
			pnlentry.PerformLayout();
			ResumeLayout(false);
		}
	}
}
