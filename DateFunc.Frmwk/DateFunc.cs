using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFunc.Frmwk
{
    public class DateFunc
    {
        //--------------------------Months----------------------------------------------------------------------//
        public static DateTime GetMonthEnd(DateTime date)
        {
            int monthEndDay = DateTime.DaysInMonth(date.Year, date.Month);

            return new DateTime(date.Year, date.Month, monthEndDay);
        }

        public static DateTime GetMonthEnd()
        {
            return GetMonthEnd(DateTime.Now);
        }

        public static DateRange GetMonthRange(DateTime date)
        {
            DateRange range = new DateRange
            {
                Start = new DateTime(date.Year, date.Month, 1),
                End = GetMonthEnd(date)
            };

            return range;
        }

        public static DateRange GetMonthRange()
        {
            return GetMonthRange(DateTime.Now);
        }

        public static DateRange GetPrevMonthRange(DateTime date)
        {
            DateTime tempDate = new DateTime(date.Year, date.Month - 1, date.Day);
            DateRange range = GetMonthRange(tempDate);
            return range;
        }

        public static DateRange GetPrevMonthRange()
        {
            return GetPrevMonthRange(DateTime.Now);
        }

        public static DateRange GetMonth2DateRange(DateTime date)
        {
            DateRange range = GetMonthRange(date);
            range.End = date;

            return range;
        }

        public static DateRange GetMonth2DateRange()
        {
            return GetMonth2DateRange(DateTime.Now);
        }

        //-------------------------------------Quarters-------------------------------------------------------------//
        public static DateRange GetQuarter(DateTime thisDate)
        {
            var result = new DateRange();
            int inMonth, inYear;
            int quarter;

            inMonth = thisDate.Month;
            inYear = thisDate.Year;
            quarter = (inMonth - 1) / 3;
            switch (quarter)
            {
                case 0:
                    result.Start = new DateTime(inYear, 1, 1);
                    result.End = new DateTime(inYear, 3, 31);
                    break;
                case 1:
                    result.Start = new DateTime(inYear, 4, 1);
                    result.End = new DateTime(inYear, 6, 30);
                    break;
                case 2:
                    result.Start = new DateTime(inYear, 7, 1);
                    result.End = new DateTime(inYear, 9, 30);
                    break;
                case 3:
                    result.Start = new DateTime(inYear, 10, 1);
                    result.End = new DateTime(inYear, 12, 31);
                    break;
                default: //Not likely to happen unless .NET breaks
                    result.Start = new DateTime(inYear, 1, 1);
                    result.End = new DateTime(inYear, 3, 31);
                    break;
            }
            return result;
        }

        public static DateRange GetQuarter()
        {
            return GetQuarter(DateTime.Now);
        }

        public static DateRange GetPrevQuarter(DateTime date)
        {
            int inMonth = date.Month;
            int inYear = date.Year;
                inMonth = inMonth - 3;
                if (inMonth < 1)
                {
                    inMonth += 12;
                    inYear--;
                }
            DateTime quaterDate = new DateTime(inYear, inMonth, date.Day);
            return GetQuarter(quaterDate);
        }

        public static DateRange GetPrevQuarter()
        {
            return GetQuarter(DateTime.Now);
        }

        public static DateRange GetQuarter2Date(DateTime date)
        {
            DateRange range = GetQuarter(date);
            range.End = date;

            return range;
        }
        public static DateRange GetQuarter2Date()
        {
            return GetQuarter2Date(DateTime.Now);
        }

        //----------------------------------------Week-----------------------------------------------------------------//
        public static DateRange GetWeek(DateTime date)
        {
            DayOfWeek currentDay = date.DayOfWeek;
            int daysTillCurrentDay = currentDay - DayOfWeek.Sunday;
            DateRange range = new DateRange
            {
                Start = date.AddDays(-daysTillCurrentDay),
                End = date.AddDays(6 - daysTillCurrentDay)
            };

            return range;
        }

        public static DateRange GetWeek()
        {
            return GetWeek(DateTime.Now);
        }

        public static DateRange GetPrevWeek(DateTime date)
        {
            return GetWeek( date.AddDays(-7));
        }

        public static DateRange GetPrevWeek()
        {
            return GetPrevWeek(DateTime.Now);
        }

        public static DateRange GetWeek2Date(DateTime date)
        {
            DateRange range = GetWeek(date);
            range.End = date;

            return range;
        }

        public static DateRange GetWeek2Date()
        {
            return GetWeek2Date(DateTime.Now);
        }
    }

    public class DateRange
    {
        DateTime _start;
        DateTime _end;

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }
        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }
    }
}
  