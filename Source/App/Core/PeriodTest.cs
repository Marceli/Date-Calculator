using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Core
{
    [TestFixture]
    public class PeriodTest
    {
        [Test]
        public void CalculateDifference_ForSameDates_Returns0()
        {
            var period = new Date(2002, 1, 1);
            var period1 = new Date(2002, 1, 1);
            Assert.AreEqual(0,period.CalculateDifference(period1));

        }
        [Test]
        public void CalculateDifference_ForTommorow_Returns1()
        {
            var period = new Date(2002, 1, 1);
            var period1 = new Date(2002, 1, 2);
            Assert.AreEqual(1, period.CalculateDifference(period1));

        }

        [Test]
        public void CalculateDifference_ForNormalYear_Returns366()
        {
            var period = new Date(2009, 1, 1);
            var period1 = new Date(2010, 1, 1);
            Assert.AreEqual(366, period.CalculateDifference(period1));

        }

        [Test]
        public void CalculateDifference_ForLeapYear_Returns365()
        {
            var period = new Date(2000, 1, 1);
            var period1 = new Date(2001, 1, 1);
            Assert.AreEqual(365, period.CalculateDifference(period1));

        }
        [Test]
        public void CalculateDifference_ShouldNotChangePeriod()
        {
            var period = new Date(2000, 1, 1);
            var period1 = new Date(2001, 1, 1);
            period.CalculateDifference(period1);
            Assert.AreEqual(period, new Date(2000,1,1));

        }       
        [Test]
        public void CalculateDifference_ShouldReturnTheSameResultAsDateTime()
        {
            var period = new Date(1972, 5, 15);
            var dateTime = new DateTime(period.Years, period.Months, period.Days);
            var period1 = new Date(2009, 11, 17);
            var dateTime1 = new DateTime(period1.Years, period1.Months, period1.Days);


            period.CalculateDifference(period1);
            Assert.AreEqual((dateTime1-dateTime).Days,period.CalculateDifference(period1));

        }

    }
}
