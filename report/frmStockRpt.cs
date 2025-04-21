using Microsoft.Reporting.WinForms;
using standard.classes;
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
    public partial class frmStockRpt : Form
    {
        public frmStockRpt()
        {
            InitializeComponent();
        }

        public string _ReportName = "";
        public bool _isWithRate = true;
        private void frmAddressPrint_Load(object sender, EventArgs e)
        {

            LoadData();
            //  this.reportViewer1.RefreshReport();
        }
        AutoCompleteStringCollection itemAC = new AutoCompleteStringCollection();
        AutoCompleteStringCollection CategoryAC = new AutoCompleteStringCollection();
        private void LoadData()
        {
            if (_ReportName == "Item Report")
            {
                chkIsWithRate.Visible = true;
                chkIsWithRate.Checked = true;
                this.Text = "Item Report";
                lbltitle.Text = "Item Report";
            }
            else if (_ReportName == "LedgerItemDetail Report")
            {
                this.Text = "LedgerwiseItemDetail Report";
                lbltitle.Text = "LedgerwiseItemDetail Report";
            }
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            using (db)
            {

                var sup = from a in db.categories select new { a.cat_id, a.cat_name };
                categoryBindingSource.DataSource = sup;

                var itemsdata = from a in db.items select new { a.item_id, a.item_name };
                itemBindingSource.DataSource = itemsdata;


                foreach (var li in itemsdata)
                {
                    itemAC.Add(li.item_name);
                }
                cboItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboItemName.AutoCompleteCustomSource = itemAC;

                foreach (var li in sup)
                {
                    CategoryAC.Add(li.cat_name);
                }
                cboCategory.AutoCompleteMode = AutoCompleteMode.Suggest;
                cboCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cboCategory.AutoCompleteCustomSource = CategoryAC;
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
                int ItemId = Convert.ToInt32(cboItemName.SelectedValue);
                int catid = Convert.ToInt32(cboCategory.SelectedValue);
                if (_ReportName == "Item Report")
                {
                    var data = db.usp_itemSelect(ItemId, null, catid, null);
                    if (_isWithRate == true)
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptItem.rdlc";
                    else
                        reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptItemClean.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }
                else if (_ReportName == "LedgerwiseItemDetail Report")
                {
                    //List<ReportParameter> rparam = new List<ReportParameter>();
                    //rparam.Add(new ReportParameter("Category",cboCategory.Text));
                    //rparam.Add(new ReportParameter("ItemName",cboItemName.Text));



                    var data = db.usp_ledgerItemDetailsReport(ItemId, catid, null, null, null);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptLedgerItemDetail.rdlc";
                    ReportParameter p1 = new ReportParameter("Category", cboCategory.Text.ToString());
                    ReportParameter p2 = new ReportParameter("ItemName", cboItemName.Text.ToString());
                    // reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                    //reportViewer1.LocalReport.SetParameters(rparam);
                }
                else
                {
                    var data = db.usp_stockReport(ItemId, catid);
                    reportViewer1.LocalReport.ReportEmbeddedResource = "standard.report.rptStock.rdlc";
                    ReportDataSource reportsource = new ReportDataSource("DataSet1", data.ToList());
                    reportViewer1.LocalReport.DataSources.Add(reportsource);
                }
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

        private void cmdList_Click(object sender, EventArgs e)
        {
            LoadReport();
        }



        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem == null)
                return;
            //ledgermasterBindingSource.Clear();
            InventoryDataContext db = new InventoryDataContext();
            using (db)
            {
                var sup = from a in db.items
                          where a.cat_id == Convert.ToInt32(cboCategory.SelectedValue) || a.item_id == 0
                          select new { a.item_id, a.item_name };
                itemBindingSource.DataSource = sup;
            }
        }

        private void cboCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboItemName.Focus();
        }

        private void cboItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdList_Click(null, null);
        }

        private void chkIsWithRate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsWithRate.Checked == true)
            {
                _isWithRate = true;
                chkIsWithRate.Text = "With Rate";
                chkIsWithRate.BackColor = Color.Green;
                chkIsWithRate.ForeColor = Color.White;
            }
            else
            {
                _isWithRate = false;
                chkIsWithRate.Text = "With Out Rate";
                chkIsWithRate.BackColor = Color.Red;
                chkIsWithRate.ForeColor = Color.White;
            }
        }
    }
}
