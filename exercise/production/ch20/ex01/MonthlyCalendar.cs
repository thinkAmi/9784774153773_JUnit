using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace production.ch20.ex01
{
    /// <summary>
    /// コンストラクタを利用しているCalendarオブジェクト
    /// </summary>
    public class MonthlyCalendar
    {
        private readonly DateTime cal;

        public MonthlyCalendar()
        {
            this.cal = DateTime.Now;
        }

        public int GetRemainingDays()
        {
            return DateTime.DaysInMonth(cal.Year, cal.Month) - cal.Day;
        }
    }
}
