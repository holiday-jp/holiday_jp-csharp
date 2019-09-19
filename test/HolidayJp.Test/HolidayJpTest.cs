using System;
using System.Linq;
using Xunit;

namespace HolidayJp.Test
{
    public class HolidayJpTest
    {
        [Fact]
        public void TestBetween()
        {
            var start = DateTime.Now.AddMonths(-5);
            var end = DateTime.Now.AddMonths(2);
            var result = HolidayJp.Between(start, end);
            Assert.NotNull(result);
        }

        [Fact]
        public void TestSomeMonth()
        {
            var year = 2019;
            var month = new int[] { 2, 8, 9 };
            foreach(var i in month)
            {
                var result = HolidayJp.SomeMonth(year, i);
                Assert.NotNull(result);
            }  
        }

        [Fact]
        public void TestIsHoliday()
        {
            var somedate = Convert.ToDateTime("2019-09-16");
            var result = HolidayJp.IsHoliday(somedate);
            Assert.True(result);
        }

        [Fact]
        public void TestTryGet()
        {
            var somedate = Convert.ToDateTime("2019-09-16");
            Holiday holiday;
            var result = HolidayJp.TryGet(somedate, out holiday);
            Assert.True(result);
            Assert.NotNull(holiday);
        }

        [Fact]
        public void TestThisWeek()
        {
            var result = HolidayJp.ThisWeek(StartOfWeek.Monday);
            Assert.True(result.Count() > 0);
        }
    }
}
