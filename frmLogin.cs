using System;
using System.Data;
using System.Windows.Forms;
using mylib;
using System.Data.SqlClient;
using System.Configuration;
using standard.classes;

namespace standard
{
    public partial class frmLogin : Form
    {
        mylib.dbcon cn;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUser();
                txtname.Select();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        void LoadUser()
        {
            string[] consts; object obj;
            txtname.AutoCompleteCustomSource = null;
            consts = ConfigurationManager.ConnectionStrings["standard.Properties.Settings.constr"].ConnectionString.Split(';');
            foreach (string s in consts)
            {
                switch(s.Split('=')[0].ToUpper())
                {
                    case "DATA SOURCE":
                    case "SERVER":
                        global.server = @s.Split('=')[1];
                        break;
                    case "INITIAL CATALOG":
                    case "DATABASE":
                        global.mdb = @s.Split('=')[1];
                        break;
                    case "USER ID":
                    case "UID":
                        global.uid = s.Split('=')[1];
                        break;
                    case "PASSWORD":
                    case "PWD":
                        global.pwd = s.Split('=')[1];
                        break;
                }
            }
            global.constring = ConfigurationManager.ConnectionStrings["standard.Properties.Settings.constr"].ConnectionString;
            cn = new dbcon(global.constring);
            AutoCompleteStringCollection namesCollection = null;
            namesCollection = new AutoCompleteStringCollection();
            SqlParameter[] param = { new SqlParameter("@users_uid", DBNull.Value) };
            DataTable dt = cn.getdata("usp_usersSelect", param);
            foreach (DataRow dr in dt.Rows)
                namesCollection.Add(Convert.ToString(dr["users_name"]));
            txtname.AutoCompleteCustomSource = namesCollection;
            obj = null;
            cn.executescalar("select getdate()", ref obj);
            dtpdate.Value = Convert.ToDateTime(obj).Date;
            global.sysdate = dtpdate.Value.Date;
            global.comid = 1;
        }
        private void txtupper_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToString(e.KeyChar).ToUpper()[0];
        }
        /// <summary>
        /// exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// login to project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdlogin_Click(object sender, EventArgs e)
        {
            object obj;
            try
            {
                using (cn)
                {
                    obj = null;
                    cn.executescalar("select users_pwd from users where users_name='" + txtname.Text + "'", ref obj);
                    if (security.Decrypt(Convert.ToString(obj), txtname.Text) != txtpwd.Text)
                    { MessageBox.Show("Invalid Password"); txtpwd.Focus(); return; }
                    obj = null;
                    cn.executescalar("select users_uid from users where users_name='" + txtname.Text + "'", ref obj);
                    if (Convert.ToInt32(obj) == 0)
                    { MessageBox.Show("Invalid UserName"); txtname.Focus(); return; }
                    global.ucode = Convert.ToInt32(obj);
                    obj = null;
                    cn.executescalar("select users_type from users where users_uid=" + global.ucode, ref obj);
                    global.utype = Convert.ToString(obj);
                }
                global.sysdate = dtpdate.Value.Date;
                global.fdate = dtpdate.Value.Date.AddYears(-1);
                //global.fdate = global.sysdate.Month >= 1 && global.sysdate.Month <= 3 ? new DateTime(global.sysdate.Year - 1, 4, 1) : new DateTime(global.sysdate.Year, 4, 01);
                global.tdate = global.sysdate.Month >= 1 && global.sysdate.Month <= 3 ? new DateTime(global.sysdate.Year, 3, 31) : new DateTime(global.sysdate.Year + 1, 3, 31);
                InventoryDataContext cc = new InventoryDataContext();
                 cc.usp_backup(global.mdb);
                this.Owner.Enabled = true;
                this.Close();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtname.Text.Trim() != string.Empty)
                txtpwd.Focus();
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdlogin_Click(null, null);
        }

        private void dtpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdlogin.Focus();
        }

        private void lbldb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmDatabase frm = new frmDatabase();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LoadUser();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }
    }

}
