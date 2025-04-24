using System;
using System.Windows.Forms;
using standard.master;
using standard.trans;
using standard.report;

namespace standard
{
    public partial class frmMain : Form
    {
        #region "DECLARATION"
        mylib.dbcon cn;
        bus bu;

        public frmMain()
        {
            InitializeComponent();
        }
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

        private void ribbonBtnItem_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }

        private void ribbonBtnRoute_Click(object sender, EventArgs e)
        {
            frmRoute frm = new frmRoute();
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
            frm.Show();
        }

        private void ribbonOrbhelp_Click(object sender, EventArgs e)
        {
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
            frmCategory frm = new frmCategory();
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

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();
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

        private void btnSales_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
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

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            frmReceipt frm = new frmReceipt();
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

        private void ribbonButtonrestore_Click(object sender, EventArgs e)
        {

        }

        private void btnAddressPrint_Click(object sender, EventArgs e)
        {
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
            frm.Show();

        }

        private void btnPurchaseReport_Click(object sender, EventArgs e)
        {
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
            frm.Show();

        }

        private void ribbonPanel3_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }

        private void btnReceiptReport_Click(object sender, EventArgs e)
        {
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
            frm.Show();

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }

        private void btnReceiptRpt_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }

        private void btnSupplierOutstanding_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }


        private void btnLedgerReport_Click(object sender, EventArgs e)
        {
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
            frm.Show();

        }

        private void btnLedgerwiseStock_Click(object sender, EventArgs e)
        {
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
            frm.Show();

        }

        private void btnAgentCommission_Click(object sender, EventArgs e)
        {
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
            frm.Show();


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to reset? 'it will delete all data ' ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            classes.InventoryDataContext db = new classes.InventoryDataContext();
            var obdata = db.usp_openingbalanceSelect(null, null, null, null, true, null);
            foreach (var obitem in obdata)
            {
                db.usp_openingbalanceDelete(obitem.ob_id);
            }
            var smdata = db.usp_salesmasterSelect(null, null, null, null, false, null);
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
            frm.Show();
        }

        private void btnPackingReceipt_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }

        private void btnLedgerRpt_Click(object sender, EventArgs e)
        {
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
            frm.Show();

        }

        private void btnItemRpt_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
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
            frm.Show();
        }
    }
}