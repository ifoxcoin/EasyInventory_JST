using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace standard.report
{
    public partial class frmAddressPrint : Form
    {
        public frmAddressPrint()
        {
            InitializeComponent();
        }
        public bool isDirectPrint = false;
        public int ledgerID = 0;
        public bool _isWithGst = true;
        public bool _isCoverPrint = true;
        private void frmAddressPrint_Load(object sender, EventArgs e)
        {

            LoadData();
            if (isDirectPrint == true)
                DirectLoadReport();
            //  this.reportViewer1.RefreshReport();
        }

        AutoCompleteStringCollection party = new AutoCompleteStringCollection();
        private void LoadData()
        {
            chkIsWithGst.Visible = true;
            chkIsWithGst.Checked = false;
            chkIsCoverPrint.Visible = true;
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {
                ledgermasterBindingSource.DataSource = db.usp_ledgermasterSelect(null, null, null, null,null);
                cboName.SelectedValue = 0;

                var cusdata = db.usp_ledgermasterSelect(null, null, null, null,null);
                foreach (var li in cusdata)
                {
                    party.Add(li.led_name);
                }
                cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboName.AutoCompleteCustomSource = party;
                var sup = from a in db.ledgermasters where a.led_id != 0 select a;
                //   ledgermasterBindingSource.DataSource = sup;
                ledgermasterCityBindingSource.DataSource = sup.Select(x => x.led_address2).Distinct();

            }
        }


        private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        {
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            if (cboCity.SelectedItem == null)
                return;
            using (db)
            {
                var sup = from a in db.ledgermasters
                          where a.led_address2 == cboCity.Text.ToString()
                          select new { a.led_id, a.led_name };
                ledgermasterBindingSource.DataSource = sup;


            }
        }
        private void DirectLoadReport()
        {

            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {
                if (ledgerID <= 0)
                {

                    MessageBox.Show("select valid ledger to print...");
                    this.Close();
                }
                cboName.SelectedValue = ledgerID;
                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.LocalReport.DataSources.Clear();


                var data = db.usp_ledgermasterSelect(ledgerID, null, null, null,null);
                if (_isCoverPrint == true)
                {
                    if (_isWithGst == true)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrint.rdlc";
                    }
                    else
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrintNoGst.rdlc";
                    }
                }
                else
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddStickerPrint.rdlc";
                }

                ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                reportViewer1.LocalReport.DataSources.Add(reportsource);
                reportViewer1.ZoomMode = ZoomMode.Percent;                
                reportViewer1.ZoomPercent = 120;
                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();

            }

        }


        private void LoadReport()
        {

            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {
                if (Convert.ToInt32(cboName.SelectedValue) <= 0)
                {

                   // MessageBox.Show("select valid ledger to print...");
                }
                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.LocalReport.DataSources.Clear();
                int id = Convert.ToInt32(cboName.SelectedValue);
                var data = db.usp_ledgermasterSelect(id, null, null, null,null);
                if(_isCoverPrint==true)
                {
                    if(_isWithGst==true)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrint.rdlc";
                    }
                    else
                    {
                       reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddPrintNoGst.rdlc";
                    }
                }
                else
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAddStickerPrint.rdlc";
                }
             
               
                ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                reportViewer1.LocalReport.DataSources.Add(reportsource);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 120;
                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();

            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void cboCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboName.Focus();
        }

        private void cboName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnView_Click(null, null);
        }

        private void chkIsWithGst_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsWithGst.Checked == true)
            {
                _isWithGst = true;
                chkIsWithGst.Text = "With GST";
                chkIsWithGst.BackColor = Color.Green;
                chkIsWithGst.ForeColor = Color.White;
            }
            else
            {
                _isWithGst = false;
                chkIsWithGst.Text = "With Out GST";
                chkIsWithGst.BackColor = Color.Red;
                chkIsWithGst.ForeColor = Color.White;
            }
            if (isDirectPrint == true)
                DirectLoadReport();
            else
                LoadReport();
        }

        private void chkIsCoverPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsCoverPrint.Checked == true)
            {
                _isCoverPrint = true;
                chkIsCoverPrint.Text = "Cover Print";
                chkIsCoverPrint.BackColor = Color.Green;
                chkIsCoverPrint.ForeColor = Color.White;
                chkIsWithGst.Visible = true;
            }
            else
            {
                _isCoverPrint = false;
                chkIsCoverPrint.Text = "Label Print";
                chkIsCoverPrint.BackColor = Color.Red;
                chkIsCoverPrint.ForeColor = Color.White;
                chkIsWithGst.Visible = false;
            }

            if (isDirectPrint == true)
                DirectLoadReport();
            else
                LoadReport();
        }
    }
}
