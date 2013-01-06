using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using production.ch20.ex01;
using System.Reflection;

namespace test.ch20.ex01
{
    [TestFixture]
    public class MonthlyCalendarTest
    {
        [Test]
        public void 現在時刻が20120131の場合GetRemainingDaysは0を返す()
        {
            //  C#の場合、パッケージプライベートという概念がないため、リフレクションで設定する
            MonthlyCalendar sut = new MonthlyCalendar();
            DateTime day = DateTime.Parse("2012/01/31");
            sut.GetType().InvokeMember("cal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, null, sut, new object[] { day });

            Assert.That(sut.GetRemainingDays(), Is.EqualTo(0));
        }

        [Test]
        public void 現在時刻が20120130の場合GetRemainingDaysは1を返す()
        {
            MonthlyCalendar sut = new MonthlyCalendar();
            DateTime day = DateTime.Parse("2012/01/30");
            sut.GetType().InvokeMember("cal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, null, sut, new object[] { day });

            Assert.That(sut.GetRemainingDays(), Is.EqualTo(1));
        }

        [Test]
        public void 現在時刻が20120201の場合GetRemainingDaysは28を返す()
        {
            MonthlyCalendar sut = new MonthlyCalendar();
            DateTime day = DateTime.Parse("2012/02/01");
            sut.GetType().InvokeMember("cal", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField, null, sut, new object[] { day });

            Assert.That(sut.GetRemainingDays(), Is.EqualTo(28));
        }
    }
}
