using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace standard.report
{
    public partial class frmRpt : Form
    {
        public frmRpt()
        {
            InitializeComponent();
        }

        private void frmRpt_Load(object sender, EventArgs e)
        {
            LoadData();
            this.reportview.RefreshReport();
        }

        void LoadData()
        {
            reportview.SetDisplayMode(DisplayMode.PrintLayout);
            reportview.ZoomMode = ZoomMode.FullPage;
            //reportview.ZoomMode = ZoomMode.Percent;
            //reportview.ZoomPercent = 120;
            
        }

        private void cmdvh_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
