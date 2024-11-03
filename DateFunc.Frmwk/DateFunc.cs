using System;

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
        public static DateRange GetQuarterRange(DateTime thisDate)
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

        public static DateRange GetQuarterRange()
        {
            return GetQuarterRange(DateTime.Now);
        }

        public static DateRange GetPrevQuarterRange(DateTime date)
        {
            DateTime quaterDate = date.AddMonths(-3);
            return GetQuarterRange(quaterDate);
        }

        public static DateRange GetPrevQuarterRange()
        {
            return GetPrevQuarterRange(DateTime.Now);
        }

        public static DateRange GetQuarter2DateRange(DateTime date)
        {
            DateRange range = GetQuarterRange(date);
            range.End = date;

            return range;
        }
        public static DateRange GetQuarter2DateRange()
        {
            return GetQuarter2DateRange(DateTime.Now);
        }

        //----------------------------------------Week-----------------------------------------------------------------//
        public static DateRange GetWeekRange(DateTime date)
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

        public static DateRange GetWeekRange()
        {
            return GetWeekRange(DateTime.Now);
        }

        public static DateRange GetPrevWeekRange(DateTime date)
        {
            return GetWeekRange(date.AddDays(-7));
        }

        public static DateRange GetPrevWeekRange()
        {
            return GetPrevWeekRange(DateTime.Now);
        }

        public static DateRange GetWeek2DateRange(DateTime date)
        {
            DateRange range = GetWeekRange(date);
            range.End = date;

            return range;
        }

        public static DateRange GetWeek2DateRange()
        {
            return GetWeek2DateRange(DateTime.Now);
        }

        //-------------------------------------------------------Year---------------------------------------------//
        public static DateRange GetYearRange(DateTime date)
        {
            DateRange range = new DateRange
            {
                Start = new DateTime(date.Year, 1, 1),
                End = new DateTime(date.Year, 12, 31)
            };

            return range;
        }

        public static DateRange GetYearRange()
        {
            return GetYearRange(DateTime.Now);
        }

        public static DateRange GetYear2DateRange(DateTime date)
        {
            DateRange range = GetYearRange(date);
            range.End = date;

            return range;
        }

        public static DateRange GetYear2DateRange()
        {
            return GetYear2DateRange(DateTime.Now);
        }

        public static DateRange GetPrevYearRange(DateTime date)
        {

            return GetYearRange(date.AddYears(-1));
        }

        public static DateRange GetPrevYearRange()
        {
            return GetPrevYearRange(DateTime.Now);
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
