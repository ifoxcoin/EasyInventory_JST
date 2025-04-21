using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Globalization;

namespace standard
{
    public class bus : IDisposable
    {
        #region Load
        mylib.dbcon cn;
        public bus()
        {
            cn = new mylib.dbcon(global.constring);
        }
        #endregion

        #region Grid
        /// <summary>
        /// transfer data from gridview to datatable
        /// </summary>
        /// <param name="DT"></param>
        /// <param name="DGV"></param>
        public static void TranData(DataTable DT, DataGridView DGV)
        {
            foreach (DataGridViewColumn GVC in DGV.Columns)
                if (GVC.Visible) DT.Columns.Add(GVC.Name);
            foreach (DataGridViewRow DR in DGV.Rows)
            {
                DT.Rows.Add();
                foreach (DataGridViewCell DC in DR.Cells)
                {
                    if (DC.Visible)
                        DT.Rows[DT.Rows.Count - 1][DGV.Columns[DC.ColumnIndex].Name] = DC.FormattedValue;
                }
            }
        }
        public static void setSNo(System.Windows.Forms.DataGridView dg,string colSNo)
        {
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
                dr.Cells[colSNo].Value = dr.Index + 1;
        }
        public static decimal getMax(System.Windows.Forms.DataGridView dg, string colName)
        {
            decimal mval = 0;
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
            {
                if (dr.IsNewRow) continue;
                if (Convert.ToDecimal(dr.Cells[colName].Value) > mval)
                    mval = Convert.ToDecimal(dr.Cells[colName].Value);
            }
            return mval;
        }
        public static System.Collections.Generic.List<decimal> getTotalSNo(
            System.Windows.Forms.DataGridView dg, string colSNo,
            System.Collections.Generic.List<string> colTot)
        {
            decimal sv; System.Collections.Generic.List<decimal> tot;
            tot = new System.Collections.Generic.List<decimal>();
            for (int i = 0; i < colTot.Count; i++) tot.Add(0);
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
            {
                dr.Cells[colSNo].Value = dr.Index + 1;
                if (dr.IsNewRow) continue;
                foreach(string col in colTot)
                {
                    decimal.TryParse(Convert.ToString(dr.Cells[col].Value), out sv);
                    tot[colTot.IndexOf(col)] += sv;
                }
            }
            return tot;
        }
        public static System.Collections.Generic.List<decimal> getTotal(
            System.Windows.Forms.DataGridView dg,
            System.Collections.Generic.List<string> colTot)
        {
            decimal sv; System.Collections.Generic.List<decimal> tot;
            tot = new System.Collections.Generic.List<decimal>();
            for (int i = 0; i < colTot.Count; i++) tot.Add(0);
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
            {
                if (dr.IsNewRow) continue;
                foreach (string col in colTot)
                {
                    decimal.TryParse(Convert.ToString(dr.Cells[col].Value), out sv);
                    tot[colTot.IndexOf(col)] += sv;
                }
            }
            return tot;
        }
        public static System.Collections.Generic.List<int> getIntTotal(
            System.Windows.Forms.DataGridView dg,
            System.Collections.Generic.List<string> colTot)
        {
            int sv; System.Collections.Generic.List<int> tot;
            tot = new System.Collections.Generic.List<int>();
            for (int i = 0; i < colTot.Count; i++) tot.Add(0);
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
            {
                if (dr.IsNewRow) continue;
                foreach (string col in colTot)
                {
                    int.TryParse(Convert.ToString(dr.Cells[col].Value), out sv);
                    tot[colTot.IndexOf(col)] += sv;
                }
            }
            return tot;
        }
        public static decimal getTotal(System.Windows.Forms.DataGridView dg,string colTot)
        {
            decimal sv,tot; tot = 0;
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
            {
                if (dr.IsNewRow) continue;
                decimal.TryParse(Convert.ToString(dr.Cells[colTot].Value), out sv);
                tot += sv;
            }
            return tot;
        }
        public static decimal getTotalSNo(System.Windows.Forms.DataGridView dg, string colTot, string colSNo)
        {
            decimal sv, tot; tot = 0;
            foreach (System.Windows.Forms.DataGridViewRow dr in dg.Rows)
            {
                dr.Cells[colSNo].Value = dr.Index + 1;
                if (dr.IsNewRow) continue;
                decimal.TryParse(Convert.ToString(dr.Cells[colTot].Value), out sv);
                tot += sv;
            }
            return tot;
        }
        public static decimal getTotal(DataTable dt, string colTot)
        {
            decimal sv, tot; tot = 0;
            foreach (DataRow dr in dt.Rows)
            {
                decimal.TryParse(Convert.ToString(dr[colTot]), out sv);
                tot += sv;
            }
            return tot;
        }
        public static System.Collections.Generic.List<decimal> getTotal(DataTable dt,
            System.Collections.Generic.List<string> colTot)
        {
            decimal sv; System.Collections.Generic.List<decimal> tot;
            tot = new System.Collections.Generic.List<decimal>();
            for (int i = 0; i < colTot.Count; i++) tot.Add(0);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (string col in colTot)
                {
                    decimal.TryParse(Convert.ToString(dr[col]), out sv);
                    tot[colTot.IndexOf(col)] += sv;
                }
            }
            return tot;
        }
        #endregion

        #region Rights
        public bool CheckRights(string ModuleName, string FormName)
        {
            if (CheckRights(ModuleName, FormName, "A") || CheckRights(ModuleName, FormName, "E") ||
                CheckRights(ModuleName, FormName, "D") || CheckRights(ModuleName, FormName, "V") || CheckRights(ModuleName, FormName, "P"))
                return true;
            else
                return false;
        }
        public bool CheckRights(string ModuleName, string FormName, string Mode)
        {
            object obj = null;
            if (global.utype.Equals("A"))
                return true;
            int FormCode, ModuleCode;
            cn.executescalar("select modulecode from module where modulename like '" + ModuleName + "'", ref obj);
            ModuleCode = Convert.ToInt16(obj);
            obj = null;
            cn.executescalar("select formcode from form where modulecode=" + ModuleCode + " and formname Like '" + FormName + "'", ref obj);
            FormCode = Convert.ToInt16(obj);
            obj = null;
            cn.executescalar("select count(*) from rights where " + Mode + "='Y' and formcode=" + FormCode + " and ucode=" + global.ucode, ref obj);
            if (Convert.ToInt16(obj) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Inventory
        
        public static List<decimal> gettax(List<decimal> taxlist)
        {
            /*
             * 0.gross total
             * 1.packing %
             * 2.exciseduty %
             * 3.educationcess on ED/ST %
             * 4.S & educationcess on ED/ST %
             * 5.insurance %
             * 6.cst %
             */
            List<decimal> res;
            res = new List<decimal>();
            res.Add(Math.Round((taxlist[0] * taxlist[1]) / 100,2));                 //packing-res[0]
            res.Add(Math.Round(((taxlist[0] + res[0]) * taxlist[2]) / 100, 2));     //exciseduty-res[1]
            res.Add(Math.Round((res[1] * taxlist[3]) / 100, 2));                    //educationcess on ED/ST-res[2]
            res.Add(Math.Round((res[2] * taxlist[4]) / 100, 2));                    //S & educationcess on ED/ST-res[3]
            res.Add(Math.Round((taxlist[0] * taxlist[5]) / 100, 2));                //insurance-res[4]
            res.Add(Math.Round(((taxlist[0] + res[0] + res[1] + res[2] + res[3] + res[4]) * taxlist[6]) / 100, 2)); //cst-res[5]
            return res;
        }
        #endregion

        public static int WeekOfYear(DateTime date)
        {
            CultureInfo info = new CultureInfo("en-US");
            Calendar cal = info.Calendar;
            return cal.GetWeekOfYear(date,info.DateTimeFormat.CalendarWeekRule,info.DateTimeFormat.FirstDayOfWeek);
        }

        #region IDisposable Members
        public void Dispose()
        {
            
        }
        #endregion
    }
}