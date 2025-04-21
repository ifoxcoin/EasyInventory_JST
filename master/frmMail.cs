using mylib;
using standard.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
	public class frmMail : Form
	{
		private IContainer components = null;

		private a1panel pnlentry;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private lightbutton cmdsave;

		private lightbutton cmdclear;

		private lightbutton cmdclose;

		private outlookgroup groupsett;

		private outlookgroup groupdown;

		private Label lblserver;

		private Label lbluname;

		private Label lblfrom;

		private Label lblto;

		private Label lblport;

		private Label lblpwd;

		private Label lblpath;

		private TextBox txtpath;

		private TextBox txtserver;

		private TextBox txtfrom;

		private TextBox txtuser;

		private TextBox txtpwd;

		private TextBox txtto;

		private decimalbox txtport;

		private FolderBrowserDialog folderOpen;

		private CheckBox chkssl;

		public frmMail()
		{
			InitializeComponent();
		}

		private void frmShift_Load(object sender, EventArgs e)
		{
			try
			{
				loadWO();
				txtserver.Select();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void loadWO()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			IQueryable<mail> queryable = inventoryDataContext.mails.Select((mail a) => a);
			using (IEnumerator<mail> enumerator = queryable.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					mail current = enumerator.Current;
					txtserver.Text = current.mail_server;
					txtfrom.Text = current.mail_from;
					txtto.Text = current.mail_to;
					txtuser.Text = current.mail_uid;
					txtpwd.Text = current.mail_pwd;
					txtport.Value = current.mail_port.Value;
					txtpath.Text = current.mail_dpath;
					chkssl.Checked = ((current.mail_ssl == 'Y') ? true : false);
				}
			}
		}

		private void clearAD()
		{
			txtserver.Text = string.Empty;
			txtfrom.Text = string.Empty;
			txtto.Text = string.Empty;
			txtuser.Text = string.Empty;
			txtpwd.Text = string.Empty;
			txtport.Value = 0m;
			txtpath.Text = string.Empty;
			chkssl.Checked = false;
		}

		private void cmdsave_Click(object sender, EventArgs e)
		{
			try
			{
				InventoryDataContext inventoryDataContext = new InventoryDataContext();
				mail mail = new mail();
				if (MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
				{
					mail.mail_server = txtserver.Text.Trim();
					mail.mail_from = txtfrom.Text.Trim();
					mail.mail_to = txtto.Text.Trim();
					mail.mail_uid = txtuser.Text.Trim();
					mail.mail_pwd = txtpwd.Text;
					mail.mail_port = (int)txtport.Value;
					mail.mail_ssl = (chkssl.Checked ? 'Y' : 'N');
					mail.mail_dpath = txtpath.Text.Trim();
					inventoryDataContext.usp_mailInsert(mail.mail_server, mail.mail_from, mail.mail_uid, mail.mail_pwd, mail.mail_port, mail.mail_to, mail.mail_ssl, mail.mail_dpath);
					MessageBox.Show("Record saved successfully...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void cmdcancel_Click(object sender, EventArgs e)
		{
			clearAD();
			loadWO();
		}

		private void cmdclose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void txtserver_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtserver.Text.Trim() != string.Empty)
			{
				txtfrom.Focus();
			}
		}

		private void txtfrom_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtfrom.Text.Trim() != string.Empty)
			{
				txtuser.Focus();
			}
		}

		private void txtuser_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtuser.Text.Trim() != string.Empty)
			{
				txtpwd.Focus();
			}
		}

		private void txtpwd_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtpwd.Text.Trim() != string.Empty)
			{
				txtport.Focus();
			}
		}

		private void txtport_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtport.Value != 0m)
			{
				txtto.Focus();
			}
		}

		private void chkssl_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				txtpath.Focus();
			}
		}

		private void txtto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtto.Text.Trim() != string.Empty)
			{
				txtpath.Focus();
			}
		}

		private void txtpath_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtpath.Text.Trim() != string.Empty)
			{
				cmdsave.Focus();
			}
		}

		private void txtpath_Click(object sender, EventArgs e)
		{
			if (folderOpen.ShowDialog() == DialogResult.OK)
			{
				txtpath.Text = folderOpen.SelectedPath;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(standard.master.frmMail));
			pnlentry = new mylib.a1panel();
			groupdown = new mylib.outlookgroup(components);
			txtpath = new System.Windows.Forms.TextBox();
			lblpath = new System.Windows.Forms.Label();
			groupsett = new mylib.outlookgroup(components);
			chkssl = new System.Windows.Forms.CheckBox();
			txtport = new mylib.decimalbox(components);
			txtto = new System.Windows.Forms.TextBox();
			txtpwd = new System.Windows.Forms.TextBox();
			txtuser = new System.Windows.Forms.TextBox();
			txtfrom = new System.Windows.Forms.TextBox();
			txtserver = new System.Windows.Forms.TextBox();
			lblpwd = new System.Windows.Forms.Label();
			lblport = new System.Windows.Forms.Label();
			lblto = new System.Windows.Forms.Label();
			lblserver = new System.Windows.Forms.Label();
			lbluname = new System.Windows.Forms.Label();
			lblfrom = new System.Windows.Forms.Label();
			cmdclose = new mylib.lightbutton();
			cmdclear = new mylib.lightbutton();
			cmdsave = new mylib.lightbutton();
			a1Paneltitle = new mylib.a1panel();
			lbltitle = new System.Windows.Forms.Label();
			folderOpen = new System.Windows.Forms.FolderBrowserDialog();
			pnlentry.SuspendLayout();
			groupdown.SuspendLayout();
			groupsett.SuspendLayout();
			a1Paneltitle.SuspendLayout();
			SuspendLayout();
			pnlentry.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			pnlentry.BorderColor = System.Drawing.Color.Gray;
			pnlentry.Controls.Add(groupdown);
			pnlentry.Controls.Add(groupsett);
			pnlentry.Controls.Add(cmdclose);
			pnlentry.Controls.Add(cmdclear);
			pnlentry.Controls.Add(cmdsave);
			pnlentry.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			pnlentry.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			pnlentry.GradientStartColor = System.Drawing.Color.WhiteSmoke;
			pnlentry.Image = null;
			pnlentry.ImageLocation = new System.Drawing.Point(4, 4);
			pnlentry.Location = new System.Drawing.Point(12, 48);
			pnlentry.Name = "pnlentry";
			pnlentry.RoundCornerRadius = 25;
			pnlentry.ShadowOffSet = 0;
			pnlentry.Size = new System.Drawing.Size(389, 351);
			pnlentry.TabIndex = 0;
			groupdown.BackColor = System.Drawing.Color.Transparent;
			groupdown.Controls.Add(txtpath);
			groupdown.Controls.Add(lblpath);
			groupdown.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			groupdown.Icon = null;
			groupdown.Image = null;
			groupdown.IsTransparent = false;
			groupdown.LineColor = System.Drawing.SystemColors.Highlight;
			groupdown.Location = new System.Drawing.Point(15, 232);
			groupdown.Name = "groupdown";
			groupdown.Padding = new System.Windows.Forms.Padding(4, 22, 4, 4);
			groupdown.Size = new System.Drawing.Size(356, 56);
			groupdown.TabIndex = 1;
			groupdown.Text = "Download Path";
			txtpath.BackColor = System.Drawing.Color.White;
			txtpath.Location = new System.Drawing.Point(99, 23);
			txtpath.MaxLength = 500;
			txtpath.Name = "txtpath";
			txtpath.ReadOnly = true;
			txtpath.Size = new System.Drawing.Size(250, 26);
			txtpath.TabIndex = 0;
			txtpath.TabStop = false;
			txtpath.Click += new System.EventHandler(txtpath_Click);
			txtpath.KeyDown += new System.Windows.Forms.KeyEventHandler(txtpath_KeyDown);
			lblpath.AutoSize = true;
			lblpath.BackColor = System.Drawing.Color.Transparent;
			lblpath.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpath.Location = new System.Drawing.Point(10, 26);
			lblpath.Name = "lblpath";
			lblpath.Size = new System.Drawing.Size(42, 18);
			lblpath.TabIndex = 16;
			lblpath.Text = "Path";
			lblpath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			groupsett.BackColor = System.Drawing.Color.Transparent;
			groupsett.Controls.Add(chkssl);
			groupsett.Controls.Add(txtport);
			groupsett.Controls.Add(txtto);
			groupsett.Controls.Add(txtpwd);
			groupsett.Controls.Add(txtuser);
			groupsett.Controls.Add(txtfrom);
			groupsett.Controls.Add(txtserver);
			groupsett.Controls.Add(lblpwd);
			groupsett.Controls.Add(lblport);
			groupsett.Controls.Add(lblto);
			groupsett.Controls.Add(lblserver);
			groupsett.Controls.Add(lbluname);
			groupsett.Controls.Add(lblfrom);
			groupsett.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			groupsett.Icon = null;
			groupsett.Image = null;
			groupsett.IsTransparent = false;
			groupsett.LineColor = System.Drawing.SystemColors.Highlight;
			groupsett.Location = new System.Drawing.Point(15, 16);
			groupsett.Name = "groupsett";
			groupsett.Padding = new System.Windows.Forms.Padding(4, 22, 4, 4);
			groupsett.Size = new System.Drawing.Size(356, 210);
			groupsett.TabIndex = 0;
			groupsett.Text = "Settings";
			chkssl.AutoSize = true;
			chkssl.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			chkssl.Location = new System.Drawing.Point(226, 142);
			chkssl.Name = "chkssl";
			chkssl.Size = new System.Drawing.Size(110, 22);
			chkssl.TabIndex = 5;
			chkssl.Text = "Enable SSL";
			chkssl.UseVisualStyleBackColor = true;
			chkssl.KeyDown += new System.Windows.Forms.KeyEventHandler(chkssl_KeyDown);
			txtport.AllowFormat = false;
			txtport.DecimalPlaces = 0;
			txtport.Location = new System.Drawing.Point(99, 140);
			txtport.MaxLength = 3;
			txtport.Name = "txtport";
			txtport.RightAlign = true;
			txtport.Size = new System.Drawing.Size(100, 26);
			txtport.TabIndex = 4;
			txtport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			mylib.decimalbox decimalbox = txtport;
			int[] bits = new int[4];
			decimalbox.Value = new decimal(bits);
			txtport.KeyDown += new System.Windows.Forms.KeyEventHandler(txtport_KeyDown);
			txtto.Location = new System.Drawing.Point(99, 168);
			txtto.MaxLength = 100;
			txtto.Name = "txtto";
			txtto.Size = new System.Drawing.Size(250, 26);
			txtto.TabIndex = 6;
			txtto.KeyDown += new System.Windows.Forms.KeyEventHandler(txtto_KeyDown);
			txtpwd.Location = new System.Drawing.Point(99, 112);
			txtpwd.MaxLength = 25;
			txtpwd.Name = "txtpwd";
			txtpwd.PasswordChar = '#';
			txtpwd.Size = new System.Drawing.Size(250, 26);
			txtpwd.TabIndex = 3;
			txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(txtpwd_KeyDown);
			txtuser.Location = new System.Drawing.Point(99, 84);
			txtuser.MaxLength = 100;
			txtuser.Name = "txtuser";
			txtuser.Size = new System.Drawing.Size(250, 26);
			txtuser.TabIndex = 2;
			txtuser.KeyDown += new System.Windows.Forms.KeyEventHandler(txtuser_KeyDown);
			txtfrom.Location = new System.Drawing.Point(99, 56);
			txtfrom.MaxLength = 100;
			txtfrom.Name = "txtfrom";
			txtfrom.Size = new System.Drawing.Size(250, 26);
			txtfrom.TabIndex = 1;
			txtfrom.KeyDown += new System.Windows.Forms.KeyEventHandler(txtfrom_KeyDown);
			txtserver.Location = new System.Drawing.Point(99, 28);
			txtserver.MaxLength = 100;
			txtserver.Name = "txtserver";
			txtserver.Size = new System.Drawing.Size(250, 26);
			txtserver.TabIndex = 0;
			txtserver.KeyDown += new System.Windows.Forms.KeyEventHandler(txtserver_KeyDown);
			lblpwd.AutoSize = true;
			lblpwd.BackColor = System.Drawing.Color.Transparent;
			lblpwd.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpwd.Location = new System.Drawing.Point(10, 116);
			lblpwd.Name = "lblpwd";
			lblpwd.Size = new System.Drawing.Size(81, 18);
			lblpwd.TabIndex = 17;
			lblpwd.Text = "Password";
			lblport.AutoSize = true;
			lblport.BackColor = System.Drawing.Color.Transparent;
			lblport.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblport.Location = new System.Drawing.Point(10, 144);
			lblport.Name = "lblport";
			lblport.Size = new System.Drawing.Size(40, 18);
			lblport.TabIndex = 16;
			lblport.Text = "Port";
			lblto.AutoSize = true;
			lblto.BackColor = System.Drawing.Color.Transparent;
			lblto.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblto.Location = new System.Drawing.Point(10, 172);
			lblto.Name = "lblto";
			lblto.Size = new System.Drawing.Size(62, 18);
			lblto.TabIndex = 15;
			lblto.Text = "Mail To";
			lblto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			lblserver.AutoSize = true;
			lblserver.BackColor = System.Drawing.Color.Transparent;
			lblserver.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblserver.Location = new System.Drawing.Point(10, 32);
			lblserver.Name = "lblserver";
			lblserver.Size = new System.Drawing.Size(59, 18);
			lblserver.TabIndex = 14;
			lblserver.Text = "Server";
			lbluname.AutoSize = true;
			lbluname.BackColor = System.Drawing.Color.Transparent;
			lbluname.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbluname.Location = new System.Drawing.Point(10, 88);
			lbluname.Name = "lbluname";
			lbluname.Size = new System.Drawing.Size(90, 18);
			lbluname.TabIndex = 13;
			lbluname.Text = "User Name";
			lblfrom.AutoSize = true;
			lblfrom.BackColor = System.Drawing.Color.Transparent;
			lblfrom.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblfrom.Location = new System.Drawing.Point(10, 60);
			lblfrom.Name = "lblfrom";
			lblfrom.Size = new System.Drawing.Size(82, 18);
			lblfrom.TabIndex = 12;
			lblfrom.Text = "Mail From";
			cmdclose.AutoSize = true;
			cmdclose.BackColor = System.Drawing.Color.Transparent;
			cmdclose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclose.Location = new System.Drawing.Point(281, 303);
			cmdclose.Name = "cmdclose";
			cmdclose.Size = new System.Drawing.Size(90, 30);
			cmdclose.TabIndex = 4;
			cmdclose.Text = "&Close";
			cmdclose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			cmdclose.UseVisualStyleBackColor = false;
			cmdclose.Click += new System.EventHandler(cmdclose_Click);
			cmdclear.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclear.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclear.Location = new System.Drawing.Point(189, 303);
			cmdclear.Name = "cmdclear";
			cmdclear.Size = new System.Drawing.Size(90, 30);
			cmdclear.TabIndex = 3;
			cmdclear.Text = "Cl&ear";
			cmdclear.UseVisualStyleBackColor = true;
			cmdclear.Click += new System.EventHandler(cmdcancel_Click);
			cmdsave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdsave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdsave.Location = new System.Drawing.Point(97, 303);
			cmdsave.Name = "cmdsave";
			cmdsave.Size = new System.Drawing.Size(90, 30);
			cmdsave.TabIndex = 2;
			cmdsave.Text = "&Update";
			cmdsave.UseVisualStyleBackColor = true;
			cmdsave.Click += new System.EventHandler(cmdsave_Click);
			a1Paneltitle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			a1Paneltitle.BorderColor = System.Drawing.Color.Gray;
			a1Paneltitle.Controls.Add(lbltitle);
			a1Paneltitle.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			a1Paneltitle.GradientStartColor = System.Drawing.Color.White;
			a1Paneltitle.Image = null;
			a1Paneltitle.ImageLocation = new System.Drawing.Point(4, 4);
			a1Paneltitle.Location = new System.Drawing.Point(12, 13);
			a1Paneltitle.Name = "a1Paneltitle";
			a1Paneltitle.ShadowOffSet = 0;
			a1Paneltitle.Size = new System.Drawing.Size(389, 29);
			a1Paneltitle.TabIndex = 2;
			lbltitle.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			lbltitle.AutoSize = true;
			lbltitle.BackColor = System.Drawing.Color.Transparent;
			lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(25, 6);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(47, 18);
			lbltitle.TabIndex = 1;
			lbltitle.Text = "MAIL";
			lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(419, 411);
			base.Controls.Add(a1Paneltitle);
			base.Controls.Add(pnlentry);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmMail";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Tag = "MASTER";
			Text = "MAIL";
			base.Load += new System.EventHandler(frmShift_Load);
			pnlentry.ResumeLayout(false);
			pnlentry.PerformLayout();
			groupdown.ResumeLayout(false);
			groupdown.PerformLayout();
			groupsett.ResumeLayout(false);
			groupsett.PerformLayout();
			a1Paneltitle.ResumeLayout(false);
			a1Paneltitle.PerformLayout();
			ResumeLayout(false);
		}
	}
}
