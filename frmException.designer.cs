namespace standard
{
    partial class frmException
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmException));
            this.txtsource = new System.Windows.Forms.TextBox();
            this.txtstack = new System.Windows.Forms.TextBox();
            this.txtinnerexception = new System.Windows.Forms.TextBox();
            this.txtmsg = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdOk = new mylib.lightbutton();
            this.SuspendLayout();
            // 
            // txtsource
            // 
            this.txtsource.BackColor = System.Drawing.Color.White;
            this.txtsource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsource.Location = new System.Drawing.Point(113, 127);
            this.txtsource.Name = "txtsource";
            this.txtsource.ReadOnly = true;
            this.txtsource.Size = new System.Drawing.Size(335, 20);
            this.txtsource.TabIndex = 15;
            this.txtsource.TabStop = false;
            // 
            // txtstack
            // 
            this.txtstack.BackColor = System.Drawing.Color.White;
            this.txtstack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstack.Location = new System.Drawing.Point(113, 91);
            this.txtstack.Name = "txtstack";
            this.txtstack.ReadOnly = true;
            this.txtstack.Size = new System.Drawing.Size(335, 20);
            this.txtstack.TabIndex = 14;
            this.txtstack.TabStop = false;
            // 
            // txtinnerexception
            // 
            this.txtinnerexception.BackColor = System.Drawing.Color.White;
            this.txtinnerexception.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtinnerexception.Location = new System.Drawing.Point(113, 56);
            this.txtinnerexception.Name = "txtinnerexception";
            this.txtinnerexception.ReadOnly = true;
            this.txtinnerexception.Size = new System.Drawing.Size(335, 20);
            this.txtinnerexception.TabIndex = 13;
            this.txtinnerexception.TabStop = false;
            // 
            // txtmsg
            // 
            this.txtmsg.BackColor = System.Drawing.Color.White;
            this.txtmsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmsg.Location = new System.Drawing.Point(113, 22);
            this.txtmsg.Name = "txtmsg";
            this.txtmsg.ReadOnly = true;
            this.txtmsg.Size = new System.Drawing.Size(335, 20);
            this.txtmsg.TabIndex = 12;
            this.txtmsg.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(17, 131);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(41, 13);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Source";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(17, 95);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(66, 13);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "Stack Trace";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(17, 60);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(81, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Inner Exception";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(17, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 13);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Message";
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOk.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOk.Location = new System.Drawing.Point(194, 160);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 16;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.CancelButton = this.cmdOk;
            this.ClientSize = new System.Drawing.Size(469, 191);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtsource);
            this.Controls.Add(this.txtstack);
            this.Controls.Add(this.txtinnerexception);
            this.Controls.Add(this.txtmsg);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmException";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exception Generated";
            this.Load += new System.EventHandler(this.frmException_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtsource;
        internal System.Windows.Forms.TextBox txtstack;
        internal System.Windows.Forms.TextBox txtinnerexception;
        internal System.Windows.Forms.TextBox txtmsg;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private mylib.lightbutton cmdOk;
    }
}