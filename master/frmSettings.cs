using mylib;
using standard.classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace standard.master
{
	public class frmSettings : Form
	{
		private IContainer components = null;

		private FolderBrowserDialog fpath;

		private a1panel pnlentry;

		private lightbutton cmclose;

		private lightbutton cmdclear;

		private lightbutton cmdsave;

		private a1panel a1Paneltitle;

		private Label lbltitle;

		private TextBox txtpath;

		private Label lblpath;

		public frmSettings()
		{
			InitializeComponent();
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			try
			{
				LoadSetting();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void LoadSetting()
		{
			InventoryDataContext inventoryDataContext = new InventoryDataContext();
			var queryable = from a in inventoryDataContext.settings
				where a.sett_name == "backloc"
				select new
				{
					a.sett_str
				};
			using (var enumerator = queryable.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					var current = enumerator.Current;
					txtpath.Text = current.sett_str;
				}
			}
		}

		private void txtpath_Click(object sender, EventArgs e)
		{
			if (fpath.ShowDialog() == DialogResult.OK)
			{
				txtpath.Text = fpath.SelectedPath;
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
				inventoryDataContext.usp_settingsUpdate("backloc", txtpath.Text.Trim(), 0L);
				try
				{
					inventoryDataContext.usp_backup(global.mdb);
				}
				catch (Exception)
				{
					MessageBox.Show("Change Backup Path to another location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				MessageBox.Show("Record updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
			}
		}

		private void cmdrefresh_Click(object sender, EventArgs e)
		{
			try
			{
				LoadSetting();
			}
			catch (Exception ex)
			{
				frmException ex2 = new frmException(ex);
				ex2.ShowDialog();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(standard.master.frmSettings));
			fpath = new System.Windows.Forms.FolderBrowserDialog();
			pnlentry = new mylib.a1panel();
			txtpath = new System.Windows.Forms.TextBox();
			lblpath = new System.Windows.Forms.Label();
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
			pnlentry.Controls.Add(txtpath);
			pnlentry.Controls.Add(lblpath);
			pnlentry.Controls.Add(cmclose);
			pnlentry.Controls.Add(cmdclear);
			pnlentry.Controls.Add(cmdsave);
			pnlentry.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			pnlentry.GradientEndColor = System.Drawing.Color.FromArgb(191, 219, 254);
			pnlentry.GradientStartColor = System.Drawing.Color.WhiteSmoke;
			pnlentry.Image = null;
			pnlentry.ImageLocation = new System.Drawing.Point(4, 4);
			pnlentry.Location = new System.Drawing.Point(8, 43);
			pnlentry.Name = "pnlentry";
			pnlentry.RoundCornerRadius = 25;
			pnlentry.ShadowOffSet = 0;
			pnlentry.Size = new System.Drawing.Size(491, 167);
			pnlentry.TabIndex = 10;
			txtpath.BackColor = System.Drawing.Color.White;
			txtpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtpath.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			txtpath.Location = new System.Drawing.Point(162, 29);
			txtpath.Name = "txtpath";
			txtpath.ReadOnly = true;
			txtpath.Size = new System.Drawing.Size(317, 26);
			txtpath.TabIndex = 4;
			txtpath.Click += new System.EventHandler(txtpath_Click);
			lblpath.AutoSize = true;
			lblpath.BackColor = System.Drawing.Color.Transparent;
			lblpath.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lblpath.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lblpath.Location = new System.Drawing.Point(2, 31);
			lblpath.Name = "lblpath";
			lblpath.Size = new System.Drawing.Size(154, 18);
			lblpath.TabIndex = 3;
			lblpath.Text = "BACKUP LOCATION";
			cmclose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmclose.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmclose.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmclose.Location = new System.Drawing.Point(386, 85);
			cmclose.Name = "cmclose";
			cmclose.Size = new System.Drawing.Size(80, 25);
			cmclose.TabIndex = 2;
			cmclose.Text = "&Close";
			cmclose.UseVisualStyleBackColor = true;
			cmclose.Click += new System.EventHandler(cmdclose_Click);
			cmdclear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmdclear.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdclear.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdclear.Location = new System.Drawing.Point(297, 85);
			cmdclear.Name = "cmdclear";
			cmdclear.Size = new System.Drawing.Size(80, 25);
			cmdclear.TabIndex = 2;
			cmdclear.Text = "Cl&ear";
			cmdclear.UseVisualStyleBackColor = true;
			cmdclear.Click += new System.EventHandler(cmdrefresh_Click);
			cmdsave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			cmdsave.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdsave.ForeColor = System.Drawing.Color.FromArgb(41, 66, 122);
			cmdsave.Location = new System.Drawing.Point(208, 85);
			cmdsave.Name = "cmdsave";
			cmdsave.Size = new System.Drawing.Size(80, 25);
			cmdsave.TabIndex = 1;
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
			a1Paneltitle.Location = new System.Drawing.Point(8, 8);
			a1Paneltitle.Name = "a1Paneltitle";
			a1Paneltitle.ShadowOffSet = 0;
			a1Paneltitle.Size = new System.Drawing.Size(491, 29);
			a1Paneltitle.TabIndex = 11;
			lbltitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
			lbltitle.AutoSize = true;
			lbltitle.BackColor = System.Drawing.Color.Transparent;
			lbltitle.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
			lbltitle.ForeColor = System.Drawing.Color.FromArgb(70, 100, 151);
			lbltitle.Location = new System.Drawing.Point(25, 5);
			lbltitle.Name = "lbltitle";
			lbltitle.Size = new System.Drawing.Size(85, 18);
			lbltitle.TabIndex = 1;
			lbltitle.Text = "SETTINGS";
			lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.FromArgb(191, 219, 254);
			base.ClientSize = new System.Drawing.Size(507, 222);
			base.Controls.Add(pnlentry);
			base.Controls.Add(a1Paneltitle);
			Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ForeColor = System.Drawing.Color.Black;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmSettings";
			base.ShowInTaskbar = false;
			base.Tag = "MASTER";
			Text = "SETTINGS";
			base.Load += new System.EventHandler(frmSettings_Load);
			pnlentry.ResumeLayout(false);
			pnlentry.PerformLayout();
			a1Paneltitle.ResumeLayout(false);
			a1Paneltitle.PerformLayout();
			ResumeLayout(false);
		}
	}
}
