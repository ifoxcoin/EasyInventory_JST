using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WinForms.Internal;
using standard.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace standard.report
{
    public partial class frmPendingSalesOrderRpt : Form
    {

        public string _ReportName = "";
        public string _LedgerType = "CUSTOMER";
        public string _ReportType = "Summary";
        public string ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
            }
        }
        public frmPendingSalesOrderRpt()
        {
            InitializeComponent();
        }

        AutoCompleteStringCollection partyautocompletelist = new AutoCompleteStringCollection();
        AutoCompleteStringCollection customerautocompletelist = new AutoCompleteStringCollection();
        private void LoadData()
        {
            //TimeSpan ts = new TimeSpan(10, 0, 0, 0);
            //dtpfdate.Value = dtpfdate.Value.Subtract(ts);
            DateTime todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


            if (todaydate.Date > new DateTime(DateTime.Now.Year, 04, 01))
                dtpfdate.Value = new DateTime(DateTime.Now.Year, 04, 01);

            else
                dtpfdate.Value = new DateTime(DateTime.Now.Year - 1, 04, 01);



            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {


                //if (_ReportName == "Sales Report")
                //{
                //    cboCity.Visible = false;
                //    lblCity.Visible = false;
                //    lblLedger.TabIndex = 3;
                //    cboName.TabIndex = 4;
                //    //ledgermasterBindingSource.Clear();
                //    var customer = from a in db.ledgermasters
                //                  //orderby a.led_name
                //              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Customer"))
                //              select new { a.led_id, a.led_name };
                //    cboName.DataSource = sup;
                //    cboName.DisplayMember = "led_name";
                //    cboName.ValueMember = "led_id";
                //    partyautocompletelist.Clear();
                //    foreach (var li in sup)
                //    {
                //        partyautocompletelist.Add(li.led_name);
                //    }

                //    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                //    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //}


            }
            

        }

        
        private void LoadReport()
        {

            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {
                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.RefreshReport();
                var data = db.usp_getPendingSaleorderList(dtpfdate.Value);
                reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptPendingSalesorderList.rdlc";
                //reportViewer1.LocalReport.SetParameters(rparam);
                ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                reportViewer1.LocalReport.DataSources.Add(reportsource);


                // reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 150;
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

        private void cmdList_Click(object sender, EventArgs e)
        {
            LoadReport();
        }


        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cboPartyType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdList_Click(null, null);
        }

        private void cboCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            LoadReport();
        }

    }
}
