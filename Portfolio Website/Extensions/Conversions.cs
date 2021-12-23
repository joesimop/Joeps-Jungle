using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Portfolio_Website.Extensions
{
    public static class Conversions
    {
        public static double MetersToMiles(this double value)
        {
            return Math.Round(value * 0.000621371, 2, MidpointRounding.AwayFromZero);
            
        }

        public static string DisplayDouble(this double value, int decimalPlaces = 2)
        {
            return string.Format("{0:N"+ decimalPlaces +"}", value);
        }

        public static string DisplayTime(this double time)
        {
            TimeSpan timeString = TimeSpan.FromSeconds(time);

            var returnString = timeString.Minutes.ToString() + "min " + timeString.Seconds.ToString() + "sec";

            if (timeString.Hours > 0)
            {
                returnString = timeString.Hours.ToString() + "hr " + returnString;
            }

            return returnString;
        }

        public static string DisplayMileTime(this double time)
        {
            TimeSpan timeString = TimeSpan.FromSeconds(time);
            string returnString = Math.Abs(timeString.Minutes) + ":" + Math.Abs(timeString.Seconds).ToString("D2");

            return time < 0 ? '-' + returnString : returnString;
        }

        public static string DisplayPace(double time, double distance)
        {
            if((distance = Math.Round(distance * 0.000621371, 2, MidpointRounding.AwayFromZero)) == 0) { return "N/A"; }
            TimeSpan pace = TimeSpan.FromMinutes((time / 60) / distance);
            return pace.Minutes + ":" + pace.Seconds.ToString("D2");
        }

        public static string ToDate(this DateTime dt)
        {
            return dt.ToString("MMMM dd, yyyy");
        }

        public static double ToUnixTimeStamp(this DateTime dt)
        {
            //28800 comes from timezone offset
            return dt.Subtract(new DateTime(1970, 1, 1)).TotalSeconds + 28800;
        }

        public static string UrlEncode(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }
    }
}
