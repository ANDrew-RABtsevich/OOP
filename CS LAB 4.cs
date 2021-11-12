using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab4
{
    public partial class List
    {
        // вложенный класс
        public class Date
        {
            private int day;
            private int month;
            private int year;
            public int Day
            {
                get => day;
                set
                {
                    if (value < 1)
                    {
                        day = 1;
                    }
                    else if (value > 31)
                    {
                        day = 31;
                    }
                    else
                    {
                        day = value;
                    }
                }
            }
            public int Month
            {
                get => month;
                set
                {
                    if (value < 1)
                    {
                        day = 1;
                        month = 1;
                    }
                    else if (value > 12)
                    {
                        day = 12;
                        month = 12;
                    }
                    else
                    {
                        day = value;
                        month = value;
                    }
                }
            }
            public int Year { get; set; }
            public Date(int dayOfCreation, int monthOfCreation, int yearOfCreation)
            {
                Day = dayOfCreation;
                Month = monthOfCreation;
                Year = yearOfCreation;
            }
            public override string ToString() => $"День создания - {Day}, месяц создания - {Month}, " +
                $"год создания - {Year}.";
        }
    }
}