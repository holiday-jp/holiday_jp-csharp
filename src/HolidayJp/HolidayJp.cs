using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace HolidayJp
{
    public static class HolidayJp
    {
        private static readonly Dictionary<string, Holiday> _holidays;
        private const int MaxYear = 2050;
        private const int MinYear = 1955;
        static HolidayJp()
        {
            try
            {
                var fileName = $"HolidayJp.holidays_detailed.json";
                var assembly = typeof(HolidayJp).GetTypeInfo().Assembly;
                using (var stream = assembly.GetManifestResourceStream(fileName))
                using (var textReader = new StreamReader(stream))
                {
                    var json = textReader.ReadToEnd();
                    _holidays = JsonConvert.DeserializeObject<Dictionary<string, Holiday>>(json);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in loading holidays data!");
                throw;
            }
        }

        public static IEnumerable<Holiday> Between(DateTime start, DateTime end)
        {
            if (end < start || start.Year < MinYear || end.Year > MaxYear)
            {
                yield return null;
            }
            foreach (var date in start.RangeTo(end))
            {
                var strD = date.ToString("yyyy-MM-dd");
                if (_holidays.ContainsKey(strD))
                {
                    yield return _holidays[strD];
                }
            }
        }

        public static IEnumerable<Holiday> SomeMonth(int year, int month)
        {
            if (year > MaxYear || year < MinYear || month > 12 || month < 1)
            {
                return null;
            }
            var start = Convert.ToDateTime($"{year}-{month.ToString().PadLeft(2, '0')}-01");
            var end = start.AddMonths(1).AddDays(-1);
            return Between(start, end);
        }

        public static bool IsHoliday(DateTime somedate)
        {
            var strD = somedate.ToString("yyyy-MM-dd");
            return _holidays.ContainsKey(strD);
        }

        public static bool TryGet(DateTime somedate, out Holiday holiday)
        {
            holiday = null;
            var strD = somedate.ToString("yyyy-MM-dd");
            if (_holidays.ContainsKey(strD))
            {
                holiday = _holidays[strD];
                return true;
            }
            return false;
        }
    }
}