using Microsoft.Reporting.WinForms;
using standard.classes;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace standard.report
{
    public partial class frmNewTransactionRpt : Form
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
        public frmNewTransactionRpt()
        {
            InitializeComponent();
        }

        private void frmAddressPrint_Load(object sender, EventArgs e)
        {
            LoadTitle();
            LoadData();
            //  this.reportViewer1.RefreshReport();
        }
        AutoCompleteStringCollection partyautocompletelist = new AutoCompleteStringCollection();
        AutoCompleteStringCollection customerautocompletelist = new AutoCompleteStringCollection();
        private void LoadData()
        {
            dtpfdate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {

                var sup = (from a in db.ledgermasters
                           where a.led_accounttype.ToUpper() == _LedgerType.ToUpper() || a.led_id == 0
                           select new { a.led_id, a.led_name, a.led_address2 });
                var cus = (from a in db.ledgermasters
                           where a.led_accounttype.ToUpper() == "CUSTOMER" || a.led_id == 0
                           select new { a.led_id, a.led_name, a.led_address2 });

                var agent = (from a in db.ledgermasters
                             where a.led_accounttype.ToUpper() == "AGENT" || a.led_id == 0
                             select new { a.led_id, a.led_name, a.led_address2 });

                ledgermasterBindingSource.DataSource = sup.OrderBy(x => x.led_address2);
                uspledgermasterSelectResultBindingSource1.DataSource = db.usp_ledgermasterSelect(null, "Ledger", null, null, null, null);
                ledgermasterCityBindingSource.DataSource = sup.Select(x => x.led_address2).Distinct();
                uspledgermasterCustomerCityBindingSource.DataSource = cus.Select(x => x.led_address2).Distinct();
                uspledgermasterCustomerSelectResultBindingSource.DataSource = db.usp_ledgermasterSelect(null, "CUSTOMER", null, null, null, null);
                routeBindingSource.DataSource = db.routes.Select((route rt) => rt);
                foreach (var li in sup)
                {
                    partyautocompletelist.Add(li.led_name);
                }
                cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboName.AutoCompleteCustomSource = partyautocompletelist;

                ledgermasterBindingSource.DataSource = sup;

                if (_ReportName == "Agent Outstanding Report")
                {
                    lblLedger.Text = "Agent";
                }


            }
            if (_ReportName == "Receipt Report" || _ReportName == "Outstanding Report" || _ReportName == "Ledger Outstanding Report" || _ReportName == "Supplier Outstanding Report")
            {
                lblReference.Visible = false;
                txtCityNames.Visible = false;
                btnAddSearch.Visible = false;
                btnClear.Visible = false;
                cboCityName.Visible = false;
                lblCityName.Visible = false;
                dtpfdate.Select();
            }
            if (_ReportName == "Ledger Outstanding Report" || _ReportName == "Supplier Outstanding Report")
            {
                btnSend.Visible = true;
            }
            else if (_ReportName == "Ledger Report")
            {
                dtpfdate.Visible = false;
                lblfdate.Visible = false;
                cboCity.Visible = false;
                cboName.Visible = false;
                lblLedger.Visible = false;
                lblCity.Visible = false;
                lblReference.Visible = false;
                txtCityNames.Visible = false;
                btnAddSearch.Visible = false;
                btnClear.Visible = false;
                cboCityName.Visible = false;
                lblCityName.Visible = false;
            }
            else if (_ReportName == "AgentCommission Report" || _ReportName == "Agent Outstanding Report")
            {


                dtpfdate.Visible = false;
                lblfdate.Visible = false;
                //cboCity.Visible = false; //Arun
                //lblCity.Visible = false; //Arun

                //cboCity.Visible = false;  //arun
                //lblCity.Visible = false;  //arun
                cboCity.SelectedIndex = 1;
                lblReference.Visible = false;

                cboName.Visible = true;
                lblLedger.Visible = true;

            }
            else
            {
                dtpfdate.Select();
                lblReference.Visible = false;
                txtCityNames.Visible = false;
                btnAddSearch.Visible = false;
                btnClear.Visible = false;
                cboCityName.Visible = false;
                lblCityName.Visible = false;
            }

        }

        private void LoadTitle()
        {
            if (_ReportName == "Purchase Report")
            {
                this.Text = "Purchase Report";
                lbltitle.Text = "Purchase Report";
            }
            else if (_ReportName == "Sales Report")
            {
                this.Text = "Sales Report";
                lbltitle.Text = "Sales Report";
            }
            else if (_ReportName == "Receipt Report")
            {
                this.Text = "Receipt Report";
                lbltitle.Text = "Receipt Report";
            }
            else if (_ReportName == "Outstanding Report")
            {
                this.Text = "Outstanding Report";
                lbltitle.Text = "Outstanding Report";
            }
            else if (_ReportName == "Ledger Outstanding Report")
            {
                this.Text = "Ledger Outstanding Report";
                lbltitle.Text = "Ledger Outstanding Report";
            }
            else if (_ReportName == "Supplier Outstanding Report")
            {
                this.Text = "Supplier Outstanding Report";
                lbltitle.Text = "Supplier Outstanding Report";
            }
            else if (_ReportName == "Outstanding Report")
            {
                this.Text = "Ledger Report";
                lbltitle.Text = "Ledger Report";
            }
            else if (_ReportName == "AgentCommission Report")
            {
                this.Text = "Agent Commission Report";
                lbltitle.Text = "Agent Commission Report";
            }
            else if (_ReportName == "Ledgerwise Outstanding Report")
            {
                this.Text = "Ledgerwise Outstanding Report";
                lbltitle.Text = "Ledgerwise Outstanding Report";
            }
        }
        private void LoadReport()
        {

            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {
                //if (Convert.ToInt32(cboName.SelectedValue) <= 0)
                //{

                //    MessageBox.Show("select valid ledger to print...");
                //}
                this.reportViewer1.RefreshReport();
                reportViewer1.Visible = true;
                reportViewer1.LocalReport.Refresh();
                reportViewer1.LocalReport.DataSources.Clear();
                int ledid = Convert.ToInt32(cboName.SelectedValue);
                //   var data = db.usp_ledgermasterSelect(id, null, null, null);

                if (_ReportName == "Purchase Report")
                {

                    if (_ReportType == "Summary")
                    {
                        //List<ReportParameter> rparam = new List<ReportParameter>();
                        //rparam.Add(new ReportParameter("city", cboCity.Text));
                        //rparam.Add(new ReportParameter("partyname", cboName.Text));
                        reportViewer1.RefreshReport();
                        var data = db.usp_purchasemasterSelect(null, ledid, dtpfdate.Value, null, null, null);
                        var ledgerData = db.usp_ledgermasterSelect(ledid, null, null, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptPurchaseSummary.rdlc";
                        //reportViewer1.LocalReport.SetParameters(rparam);
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        ReportDataSource reportsource_Ledger = new ReportDataSource("DataSet2", ledgerData.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);
                        reportViewer1.LocalReport.DataSources.Add(reportsource_Ledger);
                    }
                    else
                    {

                        var data = db.usp_purchasedetailsSelect(null, ledid, dtpfdate.Value, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptPurchaseDetail.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);

                    }
                }
                else if (_ReportName == "Sales Report")
                {
                    if (_ReportType == "Summary")
                    {
                        var data = db.usp_salesmasterSelect(null, ledid, dtpfdate.Value, null, null, null, null);
                        var ledgerData = db.usp_ledgermasterSelect(ledid, null, null, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesSummary.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        ReportDataSource reportsource_Ledger = new ReportDataSource("DataSet2", ledgerData.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);
                        reportViewer1.LocalReport.DataSources.Add(reportsource_Ledger);

                    }
                    else
                    {
                        var data = db.usp_salesdetailsSelect(null, dtpfdate.Value, null, ledid, null, null, null);
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesDetail.rdlc";
                        ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                        reportViewer1.LocalReport.DataSources.Add(reportsource);

                    }
                }
                else if (_ReportName == "Receipt Report")
                {
                    var data = db.usp_receiptSelect(null, ledid, dtpfdate.Value, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptReceipt.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }

                else if (_ReportName == "Ledger Outstanding Report")
                {

                    if (cboCity.Text == "" || cboName.Text == "")
                    {
                        MessageBox.Show("Please Select any PartyName...");
                        return;
                    }
                    //List<ReportParameter> rparam = new List<ReportParameter>();
                    //rparam.Add(new ReportParameter("city", cboCity.Text));
                    //rparam.Add(new ReportParameter("partyname", cboName.Text));
                    reportViewer1.RefreshReport();
                    var data = db.usp_LedgerOutstandingRpt(ledid, dtpfdate.Value, null);
                    var ledgerData = db.usp_ledgermasterSelect(ledid, null, null, null, null, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedgersOutstanding.rdlc";
                    //reportViewer1.LocalReport.SetParameters(rparam);
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    ReportDataSource reportsource_Ledger = new ReportDataSource("DataSet2", ledgerData.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                    reportViewer1.LocalReport.DataSources.Add(reportsource_Ledger);
                }

                else if (_ReportName == "Supplier Outstanding Report")
                {

                    if (cboCity.Text == "" || cboName.Text == "")
                    {
                        MessageBox.Show("Please Select any PartyName...");
                        return;
                    }
                    //List<ReportParameter> rparam = new List<ReportParameter>();
                    //rparam.Add(new ReportParameter("city", cboCity.Text));
                    //rparam.Add(new ReportParameter("partyname", cboName.Text));
                    reportViewer1.RefreshReport();
                    var data = db.usp_SupplierOutstandingRpt(ledid, dtpfdate.Value, null);
                    var ledgerData = db.usp_ledgermasterSelect(ledid, null, null, null, null, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptSupplierOutstanding.rdlc";
                    //reportViewer1.LocalReport.SetParameters(rparam);
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    ReportDataSource reportsource_Ledger = new ReportDataSource("DataSet2", ledgerData.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                    reportViewer1.LocalReport.DataSources.Add(reportsource_Ledger);
                }
                else if (_ReportName == "AgentCommission Report")
                {
                    var data = db.usp_AgentComissionReport(ledid, null, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptAgentCommission.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }
                else if (_ReportName == "Agent Outstanding Report")
                {
                    string citynames = string.Join(",", txtCityNames.Lines.Where(line => line.Trim().Length > 0));
                    //var data = db.usp_OutstandingReport(null, ledid, null, null, null, citynames).ToList();
                    var data = db.usp_OutstandingReport(null, ledid, null, null, null, null).ToList();
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptOutstanding.rdlc";
                    //var data = db.usp_LedgerwiseOutstandingReport(ledid);
                    //reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedgerwiseOutstanding.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }

                else if (_ReportName == "Customer Load Way Report")
                {
                    var data = db.usp_getCutomerByRoute(Convert.ToInt32(cboRoute.SelectedValue.ToString()), dtpfdate.Value.Date).ToList();
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptSalesLoadWay.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("usp_getCustomerByRoute", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }
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
            if (cboRoute.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select the route.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoute.Focus();
                return;
            }
            else
            {
                LoadReport();
            }
        }


        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCity_SelectedValueChanged_1(object sender, EventArgs e)
        {
            reportViewer1.Reset();
            //if (cboPartyType.Text.Trim().ToUpper() != "CUSTOMER")
            //{
            lblReference.Visible = false;

            //}
            //else
            //{
            //    lblReference.Visible = true;
            //    cboReference.Visible = true;
            //}
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            if (cboCity.SelectedItem == null)
                return;
            using (db)
            {

                if (_ReportName == "Agent Outstanding Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Agent"))
                              //orderby a.led_name
                              select new { a.led_id, a.led_name };
                    //var PartyList = (from a in db.ledgermasters
                    //           where (a.led_accounttype.ToUpper() == "CUSTOMER" 
                    //                  || a.led_id == 0)
                    //           select new { a.led_id, a.led_name, a.led_address2 });
                    cboName.DataSource = sup;
                    //cboCustomer.DataSource = PartyList;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else if (_ReportName == "Purchase Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Supplier"))
                              //orderby a.led_name
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else if (_ReportName == "Sales Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                                  //orderby a.led_name
                              where ((a.led_address2 == cboCity.Text.ToString()) && (a.led_accounttype == "Customer"))
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                else if (_ReportName == "Supplier Outstanding Report")
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                                  //orderby a.led_name
                              where (a.led_address2 == cboCity.Text.ToString() && (a.led_accounttype == "Supplier"))
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                else
                {
                    //ledgermasterBindingSource.Clear();
                    var sup = from a in db.ledgermasters
                                  //orderby a.led_name
                              where (a.led_address2 == cboCity.Text.ToString() && (a.led_accounttype == "Customer"))
                              select new { a.led_id, a.led_name };
                    cboName.DataSource = sup;
                    cboName.DisplayMember = "led_name";
                    cboName.ValueMember = "led_id";
                    partyautocompletelist.Clear();
                    foreach (var li in sup)
                    {
                        partyautocompletelist.Add(li.led_name);
                    }

                    cboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                // ledgermasterBindingSource .DataSource = sup;

            }
        }

        private void cboCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboName.Focus();
            btnAddSearch.Focus();
        }

        private void cboName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cboName.SelectedValue) > 0)
                    cmdList_Click(null, null);
                else
                {
                    MessageBox.Show("Please select valid Ledger...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboName.Focus();
                    return;
                }
            }
        }

        private void cboPartyType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdList_Click(null, null);
        }

        private void dtptdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboCity.Focus();
        }

        private void cboCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            LoadReport();
        }

        private void btnAddSearch_Click(object sender, EventArgs e)
        {
            string cityName = cboCityName.Text;
            if (!string.IsNullOrEmpty(cityName))
            {
                if (!txtCityNames.Text.Contains(cityName))
                {
                    if (!string.IsNullOrEmpty(txtCityNames.Text))
                    {
                        txtCityNames.Text += cityName + ",";
                    }
                    else
                    {
                        txtCityNames.Text = cityName + ",";
                    }
                }
                else
                {
                    MessageBox.Show("This city has already been added.");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCityNames.Text = "";
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ReportName == "Agent Outstanding Report")
            {
                using (InventoryDataContext inventoryDataContext = new InventoryDataContext())
                {
                    int? num = Convert.ToInt32(cboName.SelectedValue);

                    if (num == 0)
                    {
                        num = null;
                    }

                    // Get distinct city names
                    var cityList = inventoryDataContext.usp_ledgermasterSelect(null, null, null, null, null, num)
                                      .Select(x => x.led_address2) // Select only city names
                                      .Distinct()  // Remove duplicates
                                      .ToList();

                    cboCityName.DataSource = cityList;
                }
            }
            else
            {
                reportViewer1.Reset();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (reportViewer1.LocalReport.DataSources.Count < 2)
            {
                MessageBox.Show("You have not loaded the report!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                byte[] reportBytes = reportViewer1.LocalReport.Render("PDF"); // Get report as PDF bytes

                // Get the user's Downloads folder
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string todayDate = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                string Name = cboName.Text.Trim();
                string baseFileName = cboCity.Text + "_" + Name + "_" + todayDate + "_" + "receipt";
                string pdfFilePath = Path.Combine(downloadsPath, baseFileName + ".pdf");

                File.WriteAllBytes(pdfFilePath, reportBytes);

                int ledgerId = Convert.ToInt32(cboName.SelectedValue);
                // Fetch the phone number from Ledger Master based on the current report
                string customerPhone = GetCustomerPhoneNumber(ledgerId);

                if (!string.IsNullOrEmpty(customerPhone))
                {
                    SendViaWhatsApp(customerPhone, pdfFilePath); // Send the temp file with the fetched phone number
                }
                else
                {
                    MessageBox.Show("Customer phone number not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetCustomerPhoneNumber(int ledgerId)
        {
            using (InventoryDataContext db = new InventoryDataContext())
            {
                var phone = db.ledgermasters
                             .Where(a => a.led_id == ledgerId)
                             .Select(a => a.led_ownerphone)
                             .FirstOrDefault(); // Get the first matching record or null

                return phone ?? ""; // Return empty string if null
            }
        }

        private void SendViaWhatsApp(string phoneNumber, string filePath)
        {
            string message = "Hello, please find your receipt attached.";

            // Open WhatsApp with a pre-filled message
            string whatsappUrl = $"https://api.whatsapp.com/send?phone={phoneNumber}&text={Uri.EscapeDataString(message)}";
            Process.Start(new ProcessStartInfo(whatsappUrl) { UseShellExecute = true });

            // Wait a few seconds for WhatsApp Web/Desktop to open
            Thread.Sleep(5000);

            // Open the file dialog for the user to manually attach the file
            Process.Start("explorer.exe", filePath);
        }

        private void cmdList_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboRoute.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the route.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoute.Focus();
                return;
            }
        }

        private void dtpfdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboRoute.Focus();
        }

        private void cboRoute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                LoadReport();
            }
        }
    }
}
