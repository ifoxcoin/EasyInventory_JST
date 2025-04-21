namespace standard.report
{
    partial class frmRpt
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
            this.reportview = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmdvh = new System.Windows.Forms.Button();
           // this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportview
            // 
            this.reportview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportview.Location = new System.Drawing.Point(0, 0);
            this.reportview.Name = "reportview";
          //  this.reportview.ServerReport.BearerToken = null;
            this.reportview.Size = new System.Drawing.Size(658, 376);
            this.reportview.TabIndex = 0;
            // 
            // cmdvh
            // 
            this.cmdvh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdvh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdvh.Image = global::standard.Properties.Resources.delete;
            this.cmdvh.Location = new System.Drawing.Point(603, 0);
            this.cmdvh.Name = "cmdvh";
            this.cmdvh.Size = new System.Drawing.Size(55, 27);
            this.cmdvh.TabIndex = 37;
            this.cmdvh.Tag = "H";
            this.cmdvh.UseVisualStyleBackColor = true;
            this.cmdvh.Click += new System.EventHandler(this.cmdvh_Click);
            // 
            // reportViewer1
            // 
            //this.reportViewer1.Location = new System.Drawing.Point(76, 54);
            //this.reportViewer1.Name = "reportViewer1";
            //this.reportViewer1.ServerReport.BearerToken = null;
            //this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            //this.reportViewer1.TabIndex = 38;
            // 
            // frmRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.CancelButton = this.cmdvh;
            this.ClientSize = new System.Drawing.Size(658, 376);
           // this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmdvh);
            this.Controls.Add(this.reportview);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Name = "frmRpt";
            this.ShowInTaskbar = false;
            this.Text = "REPORT";
            this.Load += new System.EventHandler(this.frmRpt_Load);
            this.ResumeLayout(false);

        }

        #endregion

       public Microsoft.Reporting.WinForms.ReportViewer reportview;
        private System.Windows.Forms.Button cmdvh;
       
    }
}