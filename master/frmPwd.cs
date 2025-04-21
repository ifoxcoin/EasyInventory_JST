using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
	public class frmPwd : Form
	{
		private IContainer components = null;

		private a1panel pnlentry;

		private lightbutton cmdclear;

		private lightbutton cmdsave;

		private lightbutton cmclose;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private TextBox txtcpwd;

		private Label lblcpwd;

		private TextBox txtpwd;

		private Label lblpwd;

		private TextBox txtopwd;

		private Label lbluname;

		public frmPwd()
		{
			InitializeComponent();
		}

		private void frmAmType_Load(object sender, EventArgs e)
		{
			txtopwd.Select();
		}

		private void ClearUsers()
		{
			txtopwd.Text = string.Empty;
			txtpwd.Text = string.Empty;
			txtcpwd.Text = string.Empty;
		}

		private void toolStripNew_Click(object sender, EventArgs e)
		{
			ClearUsers();
			txtopwd.Focus();
		}

		private void toolStripSave_Click(object sender, EventArgs e)
		{
			try
			{
				dbcon dbcon = new dbcon(global.constring);
				using (dbcon)
				{
					InventoryDataContext inventoryDataContext = new InventoryDataContext();
					IQueryable<user> source = inventoryDataContext.users.Where((user a) => a.users_uid == global.ucode);
					user user = source.First();
					if (security.Decrypt(user.users_pwd, user.users_name) != txtopwd.Text)
					{
						MessageBox.Show("Invalid 'Old Password'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtopwd.Focus();
					}
					if (txtpwd.Text == string.Empty)
					{
						MessageBox.Show("Invalid 'New Password'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtpwd.Focus();
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
					else if (MessageBox.Show("Are you sure to update?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.No)
					{
						if (dbcon.executequery("update users set users_pwd='" + security.Encrypt(txtpwd.Text, user.users_name) + "' where users_uid=" + global.ucode) > 0)
						{
							MessageBox.Show("Password updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						ClearUsers();
						txtopwd.Focus();
					}
				}
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void toolStripRefresh_Click(object sender, EventArgs e)
		{
			ClearUsers();
			txtopwd.Focus();
		}

		private void toolStripExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtAccType_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtopwd.Text.Trim() != string.Empty)
			{
				try
				{
					InventoryDataContext inventoryDataContext = new InventoryDataContext();
					IQueryable<user> source = inventoryDataContext.users.Where((user a) => a.users_uid == global.ucode);
					user user = source.First();
					if (security.Decrypt(user.users_pwd, user.users_name) != txtopwd.Text)
					{
						MessageBox.Show("Invalid 'Password'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtopwd.Focus();
					}
					else
					{
						txtpwd.Focus();
					}
				}
				catch (Exception ex)
				{
					frmException ex2 = new frmException(ex);
					ex2.ShowDialog();
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(standard.master.frmPwd));
			pnlentry = new mylib.a1panel();
			txtcpwd = new System.Windows.Forms.TextBox();
			lblcpwd = new System.Windows.Forms.Label();
			txtpwd = new System.Windows.Forms.TextBox();
			lblpwd = new System.Windows.Forms.Label();
			txtopwd = new System.Windows.Forms.TextBox();
			lbluname = new System.Windows.Forms.Label();
			cmclose = new mylib.lightbutton();
			cmdclear = new mylib.lightbutton();
			cmdsave = new mylib.lightbutton();
			a1Paneltitle = new mylib.a1panel();
			lbltitle = new System.Windows.Forms.Label();
			pnlentry.SuspendLayout();
			a1Paneltitle.SuspendLayout();
			SuspendLayout();
			pnlentry.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			pnlentry.BorderColor = System.Drawing.Color.Gray;
			pnlentry.Controls.Add(txtcpwd);
			pnlentry.Controls.Add(lblcpwd);
			pnlentry.Controls.Add(txtpwd);
			pnlentry.Controls.Add(lblpwd);
			pnlentry.Controls.Add(txtopwd);
			pnlentry.Controls.Add(lbluname);
			pnlentry.Controls.Add(cmclose);
			pnlentry.Controls.Add(cmdclear);
			pnlentry.Controls.Add(cmdsave);
			pnlentry.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			pnlentry.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			pnlentry.GradientStartColor = System.Drawing.Color.WhiteSmoke;
			pnlentry.Image = null;
			pnlentry.ImageLocation = new System.Drawing.Point(4, 4);
			pnlentry.Location = new System.Drawing.Point(0, 35);
			pnlentry.Name = "pnlentry";
			pnlentry.RoundCornerRadius = 25;
			pnlentry.ShadowOffSet = 0;
			pnlentry.Size = new System.Drawing.Size(458, 156);
			pnlentry.TabIndex = 7;
			txtcpwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtcpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtcpwd.Location = new System.Drawing.Point(187, 65);
			txtcpwd.MaxLength = 15;
			txtcpwd.Name = "txtcpwd";
			txtcpwd.PasswordChar = '#';
			txtcpwd.Size = new System.Drawing.Size(259, 26);
			txtcpwd.TabIndex = 9;
			txtcpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(txtcpwd_KeyDown);
			lblcpwd.AutoSize = true;
			lblcpwd.BackColor = System.Drawing.Color.Transparent;
			lblcpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lblcpwd.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblcpwd.Location = new System.Drawing.Point(7, 73);
			lblcpwd.Name = "lblcpwd";
			lblcpwd.Size = new System.Drawing.Size(180, 18);
			lblcpwd.TabIndex = 11;
			lblcpwd.Text = "CONFORM PASSWORD";
			txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtpwd.Location = new System.Drawing.Point(187, 38);
			txtpwd.MaxLength = 15;
			txtpwd.Name = "txtpwd";
			txtpwd.PasswordChar = '#';
			txtpwd.Size = new System.Drawing.Size(259, 26);
			txtpwd.TabIndex = 8;
			txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(txtpwd_KeyDown);
			lblpwd.AutoSize = true;
			lblpwd.BackColor = System.Drawing.Color.Transparent;
			lblpwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lblpwd.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpwd.Location = new System.Drawing.Point(7, 46);
			lblpwd.Name = "lblpwd";
			lblpwd.Size = new System.Drawing.Size(137, 18);
			lblpwd.TabIndex = 10;
			lblpwd.Text = "NEW PASSWORD";
			txtopwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtopwd.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtopwd.Location = new System.Drawing.Point(187, 11);
			txtopwd.MaxLength = 15;
			txtopwd.Name = "txtopwd";
			txtopwd.PasswordChar = '#';
			txtopwd.Size = new System.Drawing.Size(259, 26);
			txtopwd.TabIndex = 6;
			txtopwd.KeyDown += new System.Windows.Forms.KeyEventHandler(txtAccType_KeyDown);
			lbluname.AutoSize = true;
			lbluname.BackColor = System.Drawing.Color.Transparent;
			lbluname.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lbluname.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbluname.Location = new System.Drawing.Point(7, 19);
			lbluname.Name = "lbluname";
			lbluname.Size = new System.Drawing.Size(133, 18);
			lbluname.TabIndex = 7;
			lbluname.Text = "OLD PASSWORD";
			cmclose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmclose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmclose.Location = new System.Drawing.Point(365, 106);
			cmclose.Name = "cmclose";
			cmclose.Size = new System.Drawing.Size(80, 25);
			cmclose.TabIndex = 2;
			cmclose.Text = "&Close";
			cmclose.UseVisualStyleBackColor = true;
			cmclose.Click += new System.EventHandler(toolStripExit_Click);
			cmdclear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmdclear.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclear.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclear.Location = new System.Drawing.Point(276, 106);
			cmdclear.Name = "cmdclear";
			cmdclear.Size = new System.Drawing.Size(80, 25);
			cmdclear.TabIndex = 2;
			cmdclear.Text = "Cl&ear";
			cmdclear.UseVisualStyleBackColor = true;
			cmdclear.Click += new System.EventHandler(toolStripRefresh_Click);
			cmdsave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmdsave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdsave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdsave.Location = new System.Drawing.Point(187, 106);
			cmdsave.Name = "cmdsave";
			cmdsave.Size = new System.Drawing.Size(80, 25);
			cmdsave.TabIndex = 1;
			cmdsave.Text = "&Update";
			cmdsave.UseVisualStyleBackColor = true;
			cmdsave.Click += new System.EventHandler(toolStripSave_Click);
			a1Paneltitle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
			a1Paneltitle.Controls.Add(lbltitle);
			a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
			a1Paneltitle.Image = null;
			a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
			a1Paneltitle.Location = new System.Drawing.Point(0, 4);
			a1Paneltitle.Name = "a1Paneltitle";
			a1Paneltitle.ShadowOffSet = 0;
			a1Paneltitle.Size = new System.Drawing.Size(458, 29);
			a1Paneltitle.TabIndex = 9;
			lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lbltitle.AutoSize = true;
			lbltitle.BackColor = System.Drawing.Color.Transparent;
			lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(25, 5);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(164, 18);
			lbltitle.TabIndex = 1;
			lbltitle.Text = "CHANGE PASSWORD";
			lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(458, 192);
			base.Controls.Add(a1Paneltitle);
			base.Controls.Add(pnlentry);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmPwd";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Tag = "MASTER";
			Text = "CHANGE PASSWORD";
			base.Load += new System.EventHandler(frmAmType_Load);
			base.Click += new System.EventHandler(frmAmType_Load);
			pnlentry.ResumeLayout(false);
			pnlentry.PerformLayout();
			a1Paneltitle.ResumeLayout(false);
			a1Paneltitle.PerformLayout();
			ResumeLayout(false);
		}
	}
}
