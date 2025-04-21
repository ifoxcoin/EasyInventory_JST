namespace standard
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.radLabelProductName = new System.Windows.Forms.Label();
            this.radLabelVersion = new System.Windows.Forms.Label();
            this.radLabelCopyright = new System.Windows.Forms.Label();
            this.radLabelCompanyName = new System.Windows.Forms.Label();
            this.radTextBoxDescription = new System.Windows.Forms.TextBox();
            this.okRadButton = new mylib.lightbutton();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.radLabelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.radLabelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.radLabelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.radLabelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.radTextBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okRadButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.496676F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.496676F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.496676F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.496676F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.48338F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.52991F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(394, 198);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(124, 192);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // radLabelProductName
            // 
            this.radLabelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelProductName.Location = new System.Drawing.Point(136, 0);
            this.radLabelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.radLabelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.radLabelProductName.Name = "radLabelProductName";
            this.radLabelProductName.Size = new System.Drawing.Size(255, 17);
            this.radLabelProductName.TabIndex = 19;
            this.radLabelProductName.Text = "Product";
            this.radLabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radLabelVersion
            // 
            this.radLabelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelVersion.Location = new System.Drawing.Point(136, 18);
            this.radLabelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.radLabelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.radLabelVersion.Name = "radLabelVersion";
            this.radLabelVersion.Size = new System.Drawing.Size(255, 17);
            this.radLabelVersion.TabIndex = 0;
            this.radLabelVersion.Text = "Version";
            this.radLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radLabelCopyright
            // 
            this.radLabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelCopyright.Location = new System.Drawing.Point(136, 36);
            this.radLabelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.radLabelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.radLabelCopyright.Name = "radLabelCopyright";
            this.radLabelCopyright.Size = new System.Drawing.Size(255, 17);
            this.radLabelCopyright.TabIndex = 21;
            this.radLabelCopyright.Text = "Copy Rights";
            this.radLabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radLabelCompanyName
            // 
            this.radLabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabelCompanyName.Location = new System.Drawing.Point(136, 54);
            this.radLabelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.radLabelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.radLabelCompanyName.Name = "radLabelCompanyName";
            this.radLabelCompanyName.Size = new System.Drawing.Size(255, 17);
            this.radLabelCompanyName.TabIndex = 22;
            this.radLabelCompanyName.Text = "Company";
            this.radLabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radTextBoxDescription
            // 
            this.radTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBoxDescription.Location = new System.Drawing.Point(136, 75);
            this.radTextBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.radTextBoxDescription.Multiline = true;
            this.radTextBoxDescription.Name = "radTextBoxDescription";
            this.radTextBoxDescription.ReadOnly = true;
            this.radTextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.radTextBoxDescription.Size = new System.Drawing.Size(255, 88);
            this.radTextBoxDescription.TabIndex = 23;
            this.radTextBoxDescription.TabStop = false;
            this.radTextBoxDescription.Text = "Attendance software is suitable for all king of organization.  It provides friend" +
    "ly and rich environment for user. It also has simple reports for attendance and " +
    "salary detail.\r\n";
            // 
            // okRadButton
            // 
            this.okRadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okRadButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okRadButton.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okRadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(66)))), ((int)(((byte)(122)))));
            this.okRadButton.Location = new System.Drawing.Point(316, 172);
            this.okRadButton.Name = "okRadButton";
            this.okRadButton.Size = new System.Drawing.Size(75, 23);
            this.okRadButton.TabIndex = 24;
            this.okRadButton.Text = "&OK";
            // 
            // frmAbout
            // 
            this.AcceptButton = this.okRadButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(412, 216);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Us";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label radLabelProductName;
        private System.Windows.Forms.Label radLabelVersion;
        private System.Windows.Forms.Label radLabelCopyright;
        private System.Windows.Forms.Label radLabelCompanyName;
        private System.Windows.Forms.TextBox radTextBoxDescription;
        private mylib.lightbutton okRadButton;
    }
}
