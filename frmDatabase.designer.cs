namespace standard
{
    partial class frmDatabase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabase));
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.txtlogin = new System.Windows.Forms.TextBox();
            this.lblpasswrd = new System.Windows.Forms.Label();
            this.lbllogname = new System.Windows.Forms.Label();
            this.cboDBName = new System.Windows.Forms.ComboBox();
            this.lbldb = new System.Windows.Forms.Label();
            this.cmdserver = new mylib.lightbutton();
            this.cboserver = new System.Windows.Forms.ComboBox();
            this.lblserver = new System.Windows.Forms.Label();
            this.rdowindows = new System.Windows.Forms.RadioButton();
            this.rdosql = new System.Windows.Forms.RadioButton();
            this.cmdcancel = new mylib.lightbutton();
            this.cmdok = new mylib.lightbutton();
            this.SuspendLayout();
            // 
            // txtpwd
            // 
            this.txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpwd.Location = new System.Drawing.Point(89, 105);
            this.txtpwd.MaxLength = 50;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(178, 21);
            this.txtpwd.TabIndex = 5;
            this.txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // txtlogin
            // 
            this.txtlogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlogin.Location = new System.Drawing.Point(89, 81);
            this.txtlogin.MaxLength = 50;
            this.txtlogin.Name = "txtlogin";
            this.txtlogin.Size = new System.Drawing.Size(178, 21);
            this.txtlogin.TabIndex = 4;
            this.txtlogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLogin_KeyDown);
            // 
            // lblpasswrd
            // 
            this.lblpasswrd.AutoSize = true;
            this.lblpasswrd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblpasswrd.Location = new System.Drawing.Point(12, 109);
            this.lblpasswrd.Name = "lblpasswrd";
            this.lblpasswrd.Size = new System.Drawing.Size(61, 13);
            this.lblpasswrd.TabIndex = 43;
            this.lblpasswrd.Text = "Password";
            // 
            // lbllogname
            // 
            this.lbllogname.AutoSize = true;
            this.lbllogname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbllogname.Location = new System.Drawing.Point(12, 85);
            this.lbllogname.Name = "lbllogname";
            this.lbllogname.Size = new System.Drawing.Size(37, 13);
            this.lbllogname.TabIndex = 42;
            this.lbllogname.Text = "Login";
            // 
            // cboDBName
            // 
            this.cboDBName.FormattingEnabled = true;
            this.cboDBName.Location = new System.Drawing.Point(89, 129);
            this.cboDBName.Name = "cboDBName";
            this.cboDBName.Size = new System.Drawing.Size(178, 21);
            this.cboDBName.TabIndex = 6;
            this.cboDBName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboDBName_KeyDown);
            this.cboDBName.Click += new System.EventHandler(this.cboDBName_Click);
            // 
            // lbldb
            // 
            this.lbldb.AutoSize = true;
            this.lbldb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lbldb.Location = new System.Drawing.Point(12, 133);
            this.lbldb.Name = "lbldb";
            this.lbldb.Size = new System.Drawing.Size(61, 13);
            this.lbldb.TabIndex = 41;
            this.lbldb.Text = "Database";
            // 
            // cmdserver
            // 
            this.cmdserver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdserver.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdserver.Location = new System.Drawing.Point(235, 13);
            this.cmdserver.Name = "cmdserver";
            this.cmdserver.Size = new System.Drawing.Size(32, 23);
            this.cmdserver.TabIndex = 1;
            this.cmdserver.Text = "...";
            this.cmdserver.UseVisualStyleBackColor = true;
            this.cmdserver.Click += new System.EventHandler(this.cmdServer_Click);
            // 
            // cboserver
            // 
            this.cboserver.FormattingEnabled = true;
            this.cboserver.Location = new System.Drawing.Point(89, 14);
            this.cboserver.Name = "cboserver";
            this.cboserver.Size = new System.Drawing.Size(146, 21);
            this.cboserver.TabIndex = 0;
            this.cboserver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboServer_KeyDown);
            // 
            // lblserver
            // 
            this.lblserver.AutoSize = true;
            this.lblserver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.lblserver.Location = new System.Drawing.Point(12, 18);
            this.lblserver.Name = "lblserver";
            this.lblserver.Size = new System.Drawing.Size(69, 13);
            this.lblserver.TabIndex = 40;
            this.lblserver.Text = "SQL Server";
            // 
            // rdowindows
            // 
            this.rdowindows.AutoSize = true;
            this.rdowindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.rdowindows.Location = new System.Drawing.Point(12, 39);
            this.rdowindows.Name = "rdowindows";
            this.rdowindows.Size = new System.Drawing.Size(161, 17);
            this.rdowindows.TabIndex = 2;
            this.rdowindows.Text = "&Windows authentication";
            this.rdowindows.UseVisualStyleBackColor = true;
            this.rdowindows.CheckedChanged += new System.EventHandler(this.rdoWindows_CheckedChanged);
            this.rdowindows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoWindows_KeyDown);
            // 
            // rdosql
            // 
            this.rdosql.AutoSize = true;
            this.rdosql.Checked = true;
            this.rdosql.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(100)))), ((int)(((byte)(151)))));
            this.rdosql.Location = new System.Drawing.Point(12, 60);
            this.rdosql.Name = "rdosql";
            this.rdosql.Size = new System.Drawing.Size(173, 17);
            this.rdosql.TabIndex = 3;
            this.rdosql.TabStop = true;
            this.rdosql.Text = "&SQL Server authentication";
            this.rdosql.UseVisualStyleBackColor = true;
            this.rdosql.CheckedChanged += new System.EventHandler(this.rdoSQL_CheckedChanged);
            this.rdosql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdoSQL_KeyDown);
            // 
            // cmdcancel
            // 
            this.cmdcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdcancel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdcancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdcancel.Location = new System.Drawing.Point(180, 154);
            this.cmdcancel.Name = "cmdcancel";
            this.cmdcancel.Size = new System.Drawing.Size(80, 25);
            this.cmdcancel.TabIndex = 8;
            this.cmdcancel.Text = "&Cancel";
            this.cmdcancel.UseVisualStyleBackColor = true;
            this.cmdcancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdok
            // 
            this.cmdok.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdok.Location = new System.Drawing.Point(91, 154);
            this.cmdok.Name = "cmdok";
            this.cmdok.Size = new System.Drawing.Size(80, 25);
            this.cmdok.TabIndex = 7;
            this.cmdok.Text = "&OK";
            this.cmdok.UseVisualStyleBackColor = true;
            this.cmdok.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.CancelButton = this.cmdcancel;
            this.ClientSize = new System.Drawing.Size(284, 187);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtlogin);
            this.Controls.Add(this.lblpasswrd);
            this.Controls.Add(this.lbllogname);
            this.Controls.Add(this.cboDBName);
            this.Controls.Add(this.lbldb);
            this.Controls.Add(this.cmdserver);
            this.Controls.Add(this.cboserver);
            this.Controls.Add(this.lblserver);
            this.Controls.Add(this.rdowindows);
            this.Controls.Add(this.rdosql);
            this.Controls.Add(this.cmdcancel);
            this.Controls.Add(this.cmdok);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabase";
            this.ShowInTaskbar = false;
            this.Text = "Database";
            this.Load += new System.EventHandler(this.frmDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txtlogin;
        private System.Windows.Forms.Label lblpasswrd;
        private System.Windows.Forms.Label lbllogname;
        private System.Windows.Forms.ComboBox cboDBName;
        private System.Windows.Forms.Label lbldb;
        private mylib.lightbutton cmdserver;
        private System.Windows.Forms.ComboBox cboserver;
        private System.Windows.Forms.Label lblserver;
        private System.Windows.Forms.RadioButton rdowindows;
        private System.Windows.Forms.RadioButton rdosql;
        private mylib.lightbutton cmdcancel;
        private mylib.lightbutton cmdok;
    }
}