using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch20.ex01;

namespace test.ch20.ex01
{
    [TestFixture]
    class MonthlyCalendar3Test
    {
        [Test]
        public void 現在時刻が20120131の場合GetRemainingDaysは0を返す()
        {
            MonthlyCalendar3 sut = new MonthlyCalendar3(new SystemCalendarMock() { Now = DateTime.Parse("2012/01/31") });
            Assert.That(sut.GetRemainingDays(), Is.EqualTo(0));
        }

        [Test]
        public void 現在時刻が20120130の場合GetRemainingDaysは1を返す()
        {
            MonthlyCalendar3 sut = new MonthlyCalendar3(new SystemCalendarMock() { Now = DateTime.Parse("2012/01/30") });
            Assert.That(sut.GetRemainingDays(), Is.EqualTo(1));
        }

        [Test]
        public void 現在時刻が20120201の場合GetRemainingDaysは28を返す()
        {
            MonthlyCalendar3 sut = new MonthlyCalendar3(new SystemCalendarMock() { Now = DateTime.Parse("2012/02/01") });
            Assert.That(sut.GetRemainingDays(), Is.EqualTo(28));
        }


        //  パターン3向けのモッククラス
        public class SystemCalendarMock : ISystemCalendar
        {
            public DateTime Now { get; set; }
        }
    }
}
