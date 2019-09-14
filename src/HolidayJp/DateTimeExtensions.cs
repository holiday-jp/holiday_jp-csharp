using System;
using System.Collections.Generic;

namespace HolidayJp
{
    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> RangeTo(this DateTime from, DateTime to, Func<DateTime, DateTime> step = null)
        {
            if (step == null)
            {
                step = x => x.AddDays(1);
            }

            while (from <= to)
            {
                yield return from;
                from = step(from);
            }
        }
    }
}