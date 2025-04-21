using System;

namespace standard
{
    public static class global
    {
        public static long ucode = 0;
        public static string utype = string.Empty;
        public static string server = string.Empty;
        public static string uid = string.Empty;
        public static string itemname = string.Empty;
        public static long itemid = 0;
        public static long comid = 0;
        public static string pwd = string.Empty;
        public static string mdb = string.Empty;
        public static string constring = string.Empty;
        public static DateTime sysdate = DateTime.MinValue;
        public static DateTime fdate = DateTime.MinValue;
        public static DateTime tdate = DateTime.MinValue;
        public static DateTime NullDate
        {
            get { return new DateTime(1900, 1, 1); }
        }
        public static TimeSpan NullTime
        {
            get { return new TimeSpan(0, 0, 0); }
        }
    }
}