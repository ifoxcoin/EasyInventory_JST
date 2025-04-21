using System.Windows.Forms;
using System.Data.Sql;
using System;
using System.Configuration;
using System.Data;

namespace standard
{
    public partial class frmDatabase : Form
    {
        public frmDatabase()
        {
            InitializeComponent();
        }

        private void frmDatabase_Load(object sender, System.EventArgs e)
        {
            try
            {
                string[] consts;
                consts = global.constring.Split(';');
                rdowindows.Checked = true;
                foreach (string s in consts)
                {
                    switch (s.Split('=')[0].ToUpper())
                    {
                        case "DATA SOURCE":
                        case "SERVER":
                            cboserver.Text = @s.Split('=')[1];
                            break;
                        case "INITIAL CATALOG":
                        case "DATABASE":
                            cboDBName.Text = @s.Split('=')[1];
                            break;
                        case "USER ID":
                        case "UID":
                            rdosql.Checked = true;
                            txtlogin.Text = s.Split('=')[1];
                            break;
                        case "PASSWORD":
                        case "PWD":
                            txtpwd.Text = s.Split('=')[1];
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        private void cmdServer_Click(object sender, System.EventArgs e)
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            cboserver.Items.Clear();
            foreach (System.Data.DataRow row in table.Rows)
                cboserver.Items.Add(row["InstanceName"]);
        }

        private void rdoSQL_CheckedChanged(object sender, EventArgs e)
        {
            txtlogin.Enabled = true;
            txtpwd.Enabled = true;
        }

        private void rdoWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtlogin.Text = string.Empty;
            txtpwd.Text = string.Empty;
            txtlogin.Enabled = false;
            txtpwd.Enabled = false;
        }

        private void cboServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (rdosql.Checked)
                    rdosql.Focus();
                else
                    rdowindows.Focus();
            }
        }

        private void rdoWindows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboDBName.Focus();
        }

        private void rdoSQL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtlogin.Focus();
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtlogin.Text.Trim() != string.Empty)
                txtpwd.Focus();
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cboDBName.Focus();
        }

        private void cboDBName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cboDBName.Text.Trim() != string.Empty)
                cmdok.Focus();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            string constr;
            try
            {
                if (rdosql.Checked)
                    constr = @"Data Source=" + cboserver.Text.Trim() + ";Initial Catalog=" + cboDBName.Text.Trim() + ";User ID=" + txtlogin.Text.Trim() + ";Password=" + txtpwd.Text.Trim() + ";Pooling=false";
                else
                    constr = @"Data Source=" + cboserver.Text.Trim() + ";Initial Catalog=" + cboDBName.Text.Trim() + ";Integrated Security=true;Pooling=false";
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove("standard.Properties.Settings.constr");
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("standard.Properties.Settings.constr", constr, "System.Data.SqlClient"));
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                this.Close();
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDBName_Click(object sender, EventArgs e)
        {
            mylib.dbcon cn;
            string constr;
            try
            {
                if (rdosql.Checked)
                    constr = @"Data Source=" + cboserver.Text.Trim() + ";Initial Catalog=master;User ID=" + txtlogin.Text.Trim() + ";Password=" + txtpwd.Text.Trim() + ";Pooling=false";
                else
                    constr = @"Data Source=" + cboserver.Text.Trim() + ";Initial Catalog=master;Integrated Security=true;Pooling=false";
                cboDBName.Items.Clear();
                cn = new mylib.dbcon(constr);
                DataTable dt = cn.getdata("select name from sysdatabases");
                foreach (DataRow dr in dt.Rows)
                    cboDBName.Items.Add(dr["name"]);
            }
            catch (Exception ex)
            {
                frmException frm = new frmException(ex);
                frm.ShowDialog();
            }
        }

    }
}