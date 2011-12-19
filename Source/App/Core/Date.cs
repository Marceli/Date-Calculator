using System;
using System.Diagnostics;

namespace Core
{
    public struct Date:IComparable
    {
        private int days;
        private int months;
        private int years;

        public Date(int years, int months, int days)
        {
            if (years < 1 || years > 4000)
            {
                throw new ArgumentException("Year should be between 1 and 4000");
            }
            this.years = years;

            if (months < 1 || months > 12)
            {
                throw new ArgumentException("Month should be between 1 and 12");
            }
            this.months = months;
            this.days = days;
            if (days < 1 || days >DaysInMonth(months))
            {
                
                throw new ArgumentException(string.Format("Day should be between 1 and {0}",DaysInMonth(months)));
            }
        }

        public int Months
        {
            get { return months; }
        }

        public int Days
        {
            get { return days; }
        }

        public int Years
        {
            get { return years; }
        }

        public static bool IsLeapYear(int year)
        {
            if ((year < 1) || (year > 3000))
            {
                throw new ArgumentOutOfRangeException("Year", "Year out of range");
            }
            if ((year%4) != 0)
            {
                return false;
            }
            if ((year%100) == 0)
            {
                return ((year%400) == 0);
            }
            return true;
        }

        public int DaysInMonth(int month)
        {
            if (month == 2)
            {
                return IsLeapYear(Years) ? 29 : 28;
            }
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                return 31;
            }
            return 30;
        }
        /// <summary>
        /// This method could be refactored for performance if need, but it would complicate algorithm.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CalculateDifference(Date other)
        {
            var result=0;
            var temp = new Date(Years, Months, Days);
            while (temp!=other)
            {
                temp.AddDay(1);
                result++;
            }
            return result;


        }

        private void AddDay(int days)
        {
            this.days++;
            if(this.Days>DaysInMonth(Months))
            {
                this.days = 1;
                this.months++;
                if(this.months==13)
                {
                    this.years++;
                    this.months = 1;
                }
            }
        }

        public bool Equals(Date other)
        {
            return other.days == days && other.months == months && other.years == years;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (Date)) return false;
            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = days;
                result = (result*397) ^ months;
                result = (result*397) ^ years;
                return result;
            }
        }

        public static bool operator ==(Date left, Date right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !left.Equals(right);
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (!(obj is Date))
            {
                throw new ArgumentException("Object is not a Date");
            }
            Date other = (Date) obj;
            if (years != other.years)
            {
                return years.CompareTo(other.Years);
            }
            if (Months != other.Months)
            {
                return Months.CompareTo(other.Months);
            }
            return Days.CompareTo(other.Days);
        }
        public static bool operator <(Date a, Date b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator >(Date a, Date b)
        {
            return b.CompareTo(a) < 0;
        }


        #endregion
    }

}