using System;
using System.Windows.Forms;
using standard.master;
using standard.trans;
using standard.report;
using System.IO;
using System.Drawing;

namespace standard
{
    public partial class frmMain : Form
    {

        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                File.WriteAllText("error.log", ex.ToString());
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        #region "DECLARATION"
        mylib.dbcon cn;
        bus bu;

        //public frmMain()
        //{
        //    InitializeComponent();
        //}
        #endregion

        #region "LOAD AND MENU EVENT"
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                frmLogin frm = new frmLogin();
                frm.Owner = this;
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
                frm.Activate();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            object obj = null;
            try
            {
                if (global.server != string.Empty)
                {
                    cn = new mylib.dbcon(global.constring);
                    cn.executescalar("select users_name from users where users_uid=" + global.ucode, ref obj);
                    toolName.Text = Convert.ToString(obj);
                    bu = new bus();
                }
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        private void signoutStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form control in this.MdiChildren)
                    control.Close();
                this.Enabled = false;
                frmLogin frm = new frmLogin();
                frm.Owner = this;
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.Show();
                frm.Focus();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        private void radButtoncalculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process runExe;
            runExe = new System.Diagnostics.Process();
            runExe.StartInfo.FileName = "calc";
            runExe.Start();
        }

        private void radMenuaboutus_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.ShowDialog();
        }

        private void radMenuexit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }
        #endregion

        #region "USER MODULE"
        private void ribbonewuser_Click(object sender, EventArgs e)
        {
            if (global.utype == "U")
            { MessageBox.Show("Rights Failed."); return; }
            frmUsers frm = new frmUsers();
            foreach (Form f in this.MdiChildren)
                if (f.Name == frm.Name)
                { MessageBox.Show("Already opened"); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void ribbonchange_Click(object sender, EventArgs e)
        {
            frmPwd frm = new frmPwd();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        #endregion

        #region "TOOLS MODULE"

        private void ribbonButtonmail_Click(object sender, EventArgs e)
        {
            frmMail frm = new frmMail();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        private void ribbonButtonback_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Backup failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        #endregion

        #region "COMPANY MODULE"
        private void ribbonButtoncompany_Click(object sender, EventArgs e)
        {
            frmCompany frm = new frmCompany();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        #endregion

        private void ResetAllRibbonButtonHighlights()
        {
            ribbonButtoncompany.Checked = false;
            ribbonButtonaccgroup.Checked = false;
            ribbonButtonaccmaster.Checked = false;
            ribbonButtonback.Checked = false;
            ribbonButtonmail.Checked = false;
            ribbonButtonrestore.Checked = false;
            ribbonBtnItem.Checked = false;
            ribbonBtnRoute.Checked = false;
            ribbonBtnVehicle.Checked = false;
            btnPurchase.Checked = false;
            btnSalesOrder.Checked = false;
            btnSales.Checked = false;
            btnReceipt.Checked = false;
            btnAddressPrint.Checked = false;
            btnStock.Checked = false;
            btnPurchaseReport.Checked = false;
            btnSalesReport.Checked = false;
            btnReceiptReport.Checked = false;
            btnReceiptRpt.Checked = false;
            btnLedgerReport.Checked = false;
            btnAgentOutstandingReport.Checked = false;
            btnReset.Checked = false;
            btnCommission.Checked = false;
            btnPackingReceipt.Checked = false;
            btnLedger.Checked = false;
            btnItemRpt.Checked = false;
            btnPayment.Checked = false;
            btnOpeningStock.Checked = false;
            btnSupplierOutstanding.Checked = false;
            btnSalesLoadReport.Checked = false;
            // Add all other ribbon buttons here
        }
        private void HighlightActiveButton(RibbonButton clickedButton)
        {
            // Reset previous
            ResetAllRibbonButtonHighlights();
            if (currentActiveButton != null)
            {
                currentActiveButton.Checked = false;
            }

            // Set new active
            clickedButton.Checked = true;
            currentActiveButton = clickedButton;
        }


        private void ribbonBtnItem_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);

            frmItems frm = new frmItems();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                ribbonBtnItem.Checked = false;
            };
            frm.Show();
        }

        private void ribbonBtnRoute_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmRoute frm = new frmRoute();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                ribbonBtnRoute.Checked = false;
            };
            frm.Show();
        }

        private void ribbonBtnVehicle_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmVehicle frm = new frmVehicle();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                ribbonBtnVehicle.Checked = false;
            };
            frm.Show();
        }

        private void ribbonPurchase_Click(object sender, EventArgs e)
        {
            //frmPurchase frm = new frmPurchase();
            //if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            //{
            //    frm.Close();
            //    MessageBox.Show("Rights failed...");
            //    return;
            //}
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void ribbonButtonaccmaster_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmLedger frm = new frmLedger();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                ribbonButtonaccmaster.Checked = false;
            };
            frm.Show();
        }

        private void ribbonpurcreturn_Click(object sender, EventArgs e)
        {
            //frmPurReturn frm = new frmPurReturn();
            //if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            //{
            //    frm.Close();
            //    MessageBox.Show("Rights failed...");
            //    return;
            //}
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void ribbonsales_Click(object sender, EventArgs e)
        {
            //frmSales frm = new frmSales();
            //if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            //{
            //    frm.Close();
            //    MessageBox.Show("Rights failed...");
            //    return;
            //}
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void ribbonButtonacctype_Click(object sender, EventArgs e)
        {
            //frmAccountType frm = new frmAccountType();
            //if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            //{
            //    frm.Close();
            //    MessageBox.Show("Rights failed...");
            //    return;
            //}
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void ribbonBtntax_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmItems frm = new frmItems();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                ribbonBtnRoute.Checked = false;
            };
            frm.Show();
        }

        private void ribbonOrbhelp_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmHelp frm = new frmHelp();
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.ShowDialog();
        }

        private void ribbonButtonOpening_Click(object sender, EventArgs e)
        {
            //frmOpening frm = new frmOpening();
            //if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            //{
            //    frm.Close();
            //    MessageBox.Show("Rights failed...");
            //    return;
            //}
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.Show();
        }

        private void ribbonButtonaccgroup_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmCategory frm = new frmCategory();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                ribbonButtonaccgroup.Checked = false;
            };
            frm.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmPurchase frm = new frmPurchase();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnPurchase.Checked = false;
            };
            frm.Show();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmSales frm = new frmSales();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnSales.Checked = false;
            };
            frm.Show();
        }

        private void btnSalesOrder_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmSalesOrder frm = new frmSalesOrder(this);
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnSalesOrder.Checked = false;
            };
            frm.Show();
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmReceipt frm = new frmReceipt();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnReceipt.Checked = false;
            };
            frm.Show();

        }

        private void ribbonButtonrestore_Click(object sender, EventArgs e)
        {

        }

        private void btnAddressPrint_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmAddressPrint frm = new frmAddressPrint();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnAddressPrint.Checked = false;
            };
            frm.Show();

        }

        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Purchase Report";
            frm._LedgerType = "SUPPLIER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnPurchaseReport.Checked = false;
            };
            frm.Show();

        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Sales Report";
            frm._LedgerType = "CUSTOMER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnSalesReport.Checked = false;
            };
            frm.Show();
        }

        private void btnReceiptReport_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Receipt Report";
            frm._LedgerType = "CUSTOMER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnReceiptReport.Checked = false;
            };
            frm.Show();

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmStockRpt frm = new frmStockRpt();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnStock.Checked = false;
            };
            frm.Show();
        }

        private void btnReceiptRpt_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Ledger Outstanding Report";
            frm._LedgerType = "CUSTOMER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnReceiptRpt.Checked = false;
            };
            frm.Show();
        }

        private void btnSupplierOutstanding_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Supplier Outstanding Report";
            frm._LedgerType = "SUPPLIER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnSupplierOutstanding.Checked = false;
            };
            frm.Show();
        }

        private void btnSalesLoadReport_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmNewTransactionRpt frm = new frmNewTransactionRpt();
            frm._ReportName = "Customer Load Way Report";
            frm._LedgerType = "CUSTOMER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnSalesLoadReport.Checked = false;
            };
            frm.Show();
        }

        private void btnAgentReport_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Agent Outstanding Report";
            frm._LedgerType = "Agent";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnAgentOutstandingReport.Checked = false;
            };
            frm.Show();

        }

        private void btnLoadWayReport_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmNewTransactionRpt frm = new frmNewTransactionRpt();
            frm._ReportName = "Customer Load Way Report";
            frm._LedgerType = "CUSTOMER";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnLedgerReport.Checked = false;
            };
            frm.Show();

        }

        private void btnLedgerwiseStock_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmStockRpt frm = new frmStockRpt();
            frm._ReportName = "LedgerwiseItemDetail Report";

            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnLedgerwiseStock.Checked = false;
            };
            frm.Show();

        }

        private void btnAgentCommission_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "AgentCommission Report";
            frm._LedgerType = "Agent";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnAgentCommission.Checked = false;
            };
            frm.Show();


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            if (MessageBox.Show("Are you sure to reset? 'it will delete all data ' ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            var obdata = db.usp_openingbalanceSelect(null, null, null, null, true, null);
            foreach (var obitem in obdata)
            {
                db.usp_openingbalanceDelete(obitem.ob_id);
            }
            var smdata = db.usp_salesmasterSelect(null, null, null, null, false, null,null);
            foreach(var smitem in smdata)
            {
                db.usp_openingbalanceInsert("O", smitem.sm_refno, DateTime.Now.Date, smitem.led_id, smitem.sm_totamount, smitem.sm_profit, smitem.sm_disamount, smitem.sm_packingcharge, smitem.sm_netamount, smitem.sm_received, smitem.sm_isclose, smitem.users_uid, DateTime.Now.Date, smitem.sm_desc, smitem.sm_paidcommission, smitem.sm_paidcommission, smitem.sm_iscommissionclose, smitem.sm_ispackingclose, smitem.sm_taxamount, smitem.sm_taxpercentage, smitem.sm_roundamount);
            }
            var pmdata = db.usp_purchasemasterSelect(null, null, null, null, false, null);
            foreach (var pmitem in pmdata)
            {
                db.usp_openingbalanceInsert("O", pmitem.pm_no, pmitem.pm_date, pmitem.led_id, pmitem.pm_totamount, 0, 0, 0, pmitem.pm_totamount, pmitem.pm_paid, pmitem.pm_isclose, pmitem.users_uid, DateTime.Now.Date, pmitem.pm_desc, 0, 0, null, null, 0, 0, 0);
            }
            db.usp_ResetTransaction();
            MessageBox.Show("your application will restart to take effect...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void btnCommission_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmCommissionReceipt frm = new frmCommissionReceipt();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnCommission.Checked = false;
            };
            frm.Show();
        }

        private void btnPackingReceipt_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmPackingReceipt frm = new frmPackingReceipt();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnPackingReceipt.Checked = false;
            };
            frm.Show();
        }

        private void btnLedgerRpt_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmTransactionRpt frm = new frmTransactionRpt();
            frm._ReportName = "Ledger Report";
            frm._LedgerType = "Ledger";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnLedgerReport.Checked = false;
            };
            frm.Show();

        }

        private void btnItemRpt_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmStockRpt frm = new frmStockRpt();
            frm._ReportName = "Item Report";
            //frm._LedgerType = "Ledger";
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            //foreach (Form F in this.MdiChildren)
            //    if (frm.Name == F.Name)
            //    { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnItemRpt.Checked = false;
            };
            frm.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmPayment frm = new frmPayment();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnPayment.Checked = false;
            };
            frm.Show();
        }

        private void btnOpeningStock_Click(object sender, EventArgs e)
        {
            HighlightActiveButton((RibbonButton)sender);
            frmOpeningStock frm = new frmOpeningStock();
            if (!bu.CheckRights(Convert.ToString(frm.Tag), frm.Text))
            {
                frm.Close();
                MessageBox.Show("Rights failed...");
                return;
            }
            foreach (Form F in this.MdiChildren)
                if (frm.Name == F.Name)
                { MessageBox.Show("Already Opened.."); return; }
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += (s, args) =>
            {
                btnOpeningStock.Checked = false;
            };
            frm.Show();
        }
    }
}