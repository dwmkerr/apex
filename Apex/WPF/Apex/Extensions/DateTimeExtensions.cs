using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Apex.Extensions
{
  public static class DateTimeExtensions
  {
    public static DateTime BeginningOfWeek(this DateTime me)
    {
      //difference in days
      int diff = (int)me.DayOfWeek - (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek; //sunday=always0, monday=always1, etc.

      //As a result we need to have day 0,1,2,3,4,5,6 
      if (diff < 0)
      {
        diff += 7;
      }
     return me.AddDays(-1 * diff).Date.BeginningOfDay();
    }

    public static DateTime BeginningOfMonth(this DateTime me)
    {
      return new DateTime(me.Year, me.Month, 1, 0, 0, 0);
    }


    public static DateTime BeginningOfDay(this DateTime me)
    {
      return new DateTime(me.Year, me.Month, me.Day, 0, 0, 0);
    }

    public static DateTime EndOfDay(this DateTime me)
    {
      return new DateTime(me.Year, me.Month, me.Day, 23, 59, 59 );
    }

    public static int WorkDaysBetween(DateTime startD, DateTime endD)
    {
      double calcBusinessDays =
      1 + ((endD - startD).TotalDays * 5 -
      (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;
      if ((int)endD.DayOfWeek == 6) calcBusinessDays--;
      if ((int)startD.DayOfWeek == 0) calcBusinessDays--;
      return (int)calcBusinessDays;
    }
  }
}
