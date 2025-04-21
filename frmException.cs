using System;
using System.Windows.Forms;

namespace standard
{
    public partial class frmException : Form
    {
        public frmException()
        {
            InitializeComponent();
        }
        public frmException(Exception ex)
        {
            InitializeComponent();
            ExpMsg = ex.Message;
            Source = ex.Source;
            Stack = ex.StackTrace;
            InnerExpmsg = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
        }
        private void frmException_Load(object sender, EventArgs e)
        {
            writeTofile();
            dispMsg();
            cmdOk.Select();
        }
        void writeTofile()
        {
            String fpath = Application.StartupPath + @"\appExp.dat";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fpath, true);
            sw.WriteLine("Exception:" + ExpMsg );
            sw.WriteLine("innerException:" + InnerExpmsg );
            sw.WriteLine("Source:" + Source  );
            sw.WriteLine("Stack Trace:" + Stack );
            sw.WriteLine("Generated On:" + DateTime.Now);
            sw.Flush();
            sw.Close();
        }
        void dispMsg() {
            txtinnerexception.Text = InnerExpmsg;
            txtmsg.Text = ExpMsg;
            txtsource.Text = Source;
            txtstack.Text = Stack;
        }
        private String _expmsg; String _innerExp; String _source; String _stack;
        public String ExpMsg{ get{return _expmsg; } set{_expmsg=value;}}
        public String InnerExpmsg { get { return _innerExp ;} set { _innerExp=value ;} }
        public String Source { get { return _source  ;} set {_source=value  ;} }
        public String Stack { get {return _stack  ;} set {_stack=value  ;} }
        private void cmdOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}