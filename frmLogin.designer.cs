namespace standard
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lblname = new System.Windows.Forms.Label();
            this.lblpwd = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.cmdlogin = new mylib.lightbutton();
            this.cmdclose = new mylib.lightbutton();
            this.lbldb = new System.Windows.Forms.LinkLabel();
            this.picturelogin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturelogin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.lblname.Location = new System.Drawing.Point(119, 45);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(33, 14);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "User";
            // 
            // lblpwd
            // 
            this.lblpwd.AutoSize = true;
            this.lblpwd.BackColor = System.Drawing.Color.Transparent;
            this.lblpwd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblpwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.lblpwd.Location = new System.Drawing.Point(119, 82);
            this.lblpwd.Name = "lblpwd";
            this.lblpwd.Size = new System.Drawing.Size(66, 14);
            this.lblpwd.TabIndex = 1;
            this.lblpwd.Text = "Password";
            // 
            // txtname
            // 
            this.txtname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtname.Location = new System.Drawing.Point(204, 41);
            this.txtname.MaxLength = 25;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(150, 22);
            this.txtname.TabIndex = 0;
            this.txtname.Text = "ADMIN";
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtname_KeyDown);
            this.txtname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtupper_KeyPress);
            // 
            // txtpwd
            // 
            this.txtpwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpwd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtpwd.Location = new System.Drawing.Point(204, 78);
            this.txtpwd.MaxLength = 15;
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '#';
            this.txtpwd.Size = new System.Drawing.Size(150, 22);
            this.txtpwd.TabIndex = 1;
            this.txtpwd.Text = "123";
            this.txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyDown);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.BackColor = System.Drawing.Color.Transparent;
            this.lbldate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.lbldate.Location = new System.Drawing.Point(119, 146);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(36, 14);
            this.lbldate.TabIndex = 4;
            this.lbldate.Text = "Date";
            this.lbldate.Visible = false;
            // 
            // dtpdate
            // 
            this.dtpdate.CalendarFont = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdate.CustomFormat = "dd-MM-yyyy";
            this.dtpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(204, 146);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(94, 22);
            this.dtpdate.TabIndex = 2;
            this.dtpdate.Visible = false;
            this.dtpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpdate_KeyDown);
            // 
            // cmdlogin
            // 
            this.cmdlogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdlogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdlogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdlogin.Location = new System.Drawing.Point(204, 112);
            this.cmdlogin.Name = "cmdlogin";
            this.cmdlogin.Size = new System.Drawing.Size(73, 26);
            this.cmdlogin.TabIndex = 3;
            this.cmdlogin.Text = "Login";
            this.cmdlogin.UseVisualStyleBackColor = true;
            this.cmdlogin.Click += new System.EventHandler(this.cmdlogin_Click);
            // 
            // cmdclose
            // 
            this.cmdclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdclose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.cmdclose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.cmdclose.Location = new System.Drawing.Point(280, 112);
            this.cmdclose.Name = "cmdclose";
            this.cmdclose.Size = new System.Drawing.Size(73, 26);
            this.cmdclose.TabIndex = 4;
            this.cmdclose.Text = "Close";
            this.cmdclose.UseVisualStyleBackColor = true;
            this.cmdclose.Click += new System.EventHandler(this.cmdclose_Click);
            // 
            // lbldb
            // 
            this.lbldb.ActiveLinkColor = System.Drawing.Color.DeepPink;
            this.lbldb.AutoSize = true;
            this.lbldb.BackColor = System.Drawing.Color.Transparent;
            this.lbldb.DisabledLinkColor = System.Drawing.Color.Blue;
            this.lbldb.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbldb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.lbldb.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.lbldb.Location = new System.Drawing.Point(335, 151);
            this.lbldb.Name = "lbldb";
            this.lbldb.Size = new System.Drawing.Size(24, 14);
            this.lbldb.TabIndex = 5;
            this.lbldb.TabStop = true;
            this.lbldb.Text = "DB";
            this.lbldb.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lbldb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbldb_LinkClicked);
            // 
            // picturelogin
            // 
            this.picturelogin.Image = global::standard.Properties.Resources.loginpic;
            this.picturelogin.Location = new System.Drawing.Point(0, 0);
            this.picturelogin.Name = "picturelogin";
            this.picturelogin.Size = new System.Drawing.Size(113, 180);
            this.picturelogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturelogin.TabIndex = 6;
            this.picturelogin.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.cmdclose;
            this.ClientSize = new System.Drawing.Size(370, 181);
            this.ControlBox = false;
            this.Controls.Add(this.picturelogin);
            this.Controls.Add(this.lbldb);
            this.Controls.Add(this.cmdclose);
            this.Controls.Add(this.cmdlogin);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lblpwd);
            this.Controls.Add(this.lblname);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturelogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblpwd;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private mylib.lightbutton cmdlogin;
        private mylib.lightbutton cmdclose;
        private System.Windows.Forms.LinkLabel lbldb;
        private System.Windows.Forms.PictureBox picturelogin;
    }
}