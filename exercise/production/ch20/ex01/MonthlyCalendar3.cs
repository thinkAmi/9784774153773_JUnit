using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch20.ex01
{
    
    public interface ISystemCalendar
    {
        DateTime Now { get; }
    }

    public class SystemCalendar : ISystemCalendar
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }


    /// <summary>
    /// スタブで置き換え可能なSystemCalendar
    /// C#にはパッケージプライベートがないため、コンストラクタなどで渡す方法となる?
    /// See: http://stackoverflow.com/questions/10495480/how-write-stub-method-with-nunit-in-c-sharp
    /// </summary>
    public class MonthlyCalendar3
    {
        private ISystemCalendar sysCal;


        public MonthlyCalendar3(ISystemCalendar sysCal)
        {
            this.sysCal = sysCal;
        }

        public int GetRemainingDays()
        {
            DateTime cal = sysCal.Now;
            return DateTime.DaysInMonth(cal.Year, cal.Month) - cal.Day;
        }
    }
}
