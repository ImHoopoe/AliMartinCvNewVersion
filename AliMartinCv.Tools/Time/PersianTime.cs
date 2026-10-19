using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AliMartinCv.Tools.Time
{
    public static class PersianTime
    {
        public static string ToShamsi(this DateTimeOffset dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            int year;
            int month;
            int day;
            year = pc.GetYear(dateTime.DateTime);
            month = pc.GetMonth(dateTime.DateTime);
            day = pc.GetDayOfMonth(dateTime.DateTime);
            return $"{year}/{month:00}/{day:00}";
        }
        //public static string GetTimeAgo(this DateTimeOffset dateTime)
        //{
        //    //3 روز گذشته 
        //    PersianCalendar pc = new PersianCalendar();
        //    DateTimeOffset now = DateTimeOffset.Now;
        //    int currentDay = pc.GetDayOfMonth(now.DateTime);
        //    int currentMonth = pc.GetMonth(now.DateTime);
        //    int currentYear = pc.GetYear(now.DateTime);

        //    int day = pc.GetDayOfMonth(dateTime.DateTime);
        //    int month = pc.GetMonth(dateTime.DateTime);
        //    int year = pc.GetYear(dateTime.DateTime);

        //    if (year != currentYear)
        //    {
        //        int yearDistace = currentYear - year;
        //        return $"{yearDistace} سال پیش";
        //    }
        //    if (currentYear == year && currentMonth == month)
        //    {
        //        int dayCount = currentDay - day;
        //        return $"{dayCount} روز پیش";
        //    }

        //    if (currentYear == year && currentMonth != month)
        //    {
        //        int monthDistance = currentMonth - month;
        //        return $"{monthDistance} ماه پیش";
        //    }
        //    return $"1";
        //}

        public static string GetTimeAgo(this DateTimeOffset dateTime)
        {
            TimeSpan diff = DateTimeOffset.Now - dateTime;

            if (diff.TotalSeconds < 0)
                return "در آینده";

            return diff.TotalSeconds switch
            {
                < 60 => "لحظاتی پیش",
                < 3600 => $"{(int)diff.TotalMinutes} دقیقه پیش",
                < 86400 => $"{(int)diff.TotalHours} ساعت پیش",
                < 2592000 => $"{(int)diff.TotalDays} روز پیش",
                < 31536000 => $"{(int)(diff.TotalDays / 30)} ماه پیش",
                _ => $"{(int)(diff.TotalDays / 365)} سال پیش"
            };
        }

    }
}
