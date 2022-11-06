using System.Globalization;
using System;

namespace ConvertTime
{
    public static class ConvertDateTime
    {
        public static string ConvertDateToString(DateTime d)
        {            
            string date_str = d.ToString("yyyyMd");
            return date_str;
        }
        public static string ConvertMiladiToShamsi(DateTime s)
        {
            PersianCalendar p = new PersianCalendar();
    return string.Format(@"{0}/{1}/{2}",
                 p.GetYear(s),
                 p.GetMonth(s),
                 p.GetDayOfMonth(s));
        }
        public static string ConvertMiladiToShamsiNoSlash(DateTime s)
        {
            PersianCalendar p = new PersianCalendar();
    return string.Format("{0}{1}{2}",
                 p.GetYear(s),
                 p.GetMonth(s),
                 p.GetDayOfMonth(s));
        }
        public static int ConvertMiladiToShamsiYear(DateTime s)
        {
            PersianCalendar p = new PersianCalendar();
            int y = p.GetYear(s);
            return y;
        }
        public static int ConvertMiladiToShamsiMonth(DateTime s)
        {
            PersianCalendar p = new PersianCalendar();
            int m = p.GetMonth(s);
            return m;
        }
        public static int ConvertMiladiToShamsiDay(DateTime s)
        {
            PersianCalendar p = new PersianCalendar();
            int d = p.GetDayOfMonth(s);
            return d;
        }
        public static double ConvertDateTimeToTimestamp(DateTime value)
        {
            TimeSpan epoch = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return (double)epoch.TotalSeconds;
        }
    }
}

