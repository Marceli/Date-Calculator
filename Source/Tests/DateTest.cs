using System;
using Core;
using NUnit.Framework;
using System.Diagnostics;

namespace Tests
{
    [TestFixture]
    public class DateTest
    {
        [Test]
        public void IsLeapYear_ForLeapYear_ReturnsTrue()
        {
            Assert.IsTrue(Date.IsLeapYear(2000));
        }

        [Test]
        public void IsLeapYear_ForOrdinalYear_ReturnsFalse()
        {
            Assert.IsFalse(Date.IsLeapYear(2001));
        }
        [Test]
        public void CalculateDifference_ForLeapYear_Returns366()
        {
            var period = new Date(2000, 1, 1);
            var period1 = new Date(2001, 1, 1);
            Assert.AreEqual(366, period.CalculateDifference(period1));
        }

        [Test]
        public void CalculateDifference_ForNormalYear_Returns365()
        {
            var period = new Date(2009, 1, 1);
            var period1 = new Date(2010, 1, 1);
            Assert.AreEqual(365, period.CalculateDifference(period1));
        }

        [Test]
        public void CalculateDifference_ForSameDates_Returns0()
        {
            var period = new Date(2002, 1, 1);
            var period1 = new Date(2002, 1, 1);
            Assert.AreEqual(0, period.CalculateDifference(period1));
        }

        [Test]
        public void CalculateDifference_ForTommorow_Returns1()
        {
            var period = new Date(2002, 1, 1);
            var period1 = new Date(2002, 1, 2);
            Assert.AreEqual(1, period.CalculateDifference(period1));
        }

        [Test]
        public void CalculateDifference_ShouldNotChangePeriod()
        {
            var period = new Date(2000, 1, 1);
            var period1 = new Date(2001, 1, 1);
            period.CalculateDifference(period1);
            Assert.AreEqual(period, new Date(2000, 1, 1));
        }

        [Test]
        public void CalculateDifference_ShouldReturnTheSameResultAsDateTime()
        {
            var period = new Date(1972, 5, 15);
            var dateTime = new DateTime(period.Years, period.Months, period.Days);
            var period1 = new Date(2009, 11, 17);
            var dateTime1 = new DateTime(period1.Years, period1.Months, period1.Days);


            period.CalculateDifference(period1);
            Assert.AreEqual((dateTime1 - dateTime).Days, period.CalculateDifference(period1));
        }

        [Test]
        public void CompareTo_WithTheSameDates_Returns0()
        {
            var date1 = new Date(2009, 11, 17);
           
            var date2 = new Date(2009, 11, 17);
              Assert.AreEqual(0,date1.CompareTo(date2));
        }
        [Test]
        public void CompareTo_WithLaterDate_ReturnsNegative1()
        {
           
            var date1 = new Date(2009, 11, 17);

            var date2 = new Date(2009, 11, 18);
            Assert.AreEqual(-1, date1.CompareTo(date2));
        }
        [Test]
        public void CompareTo_WithEarlierDate_Returns1()
        {
           
            var date1 = new Date(2009, 11, 17);

            var date2 = new Date(2009, 11, 18);
            Assert.AreEqual(1, date2.CompareTo(date1));
        }
        [Test]
        public void LessOperator_ForEarlierDate_ReturnsTrue()
        {

            var date1 = new Date(2009, 11, 17);
            var date2 = new Date(2009, 11, 18);
            

           
            Assert.IsTrue(date1 < date2);
        }
        [Test]
        public void GreaterOperator_ForEarlierDate_ReturnsFalse()
        {

            var date1 = new Date(2009, 11, 17);
            var date2 = new Date(2009, 11, 18);
            Assert.IsFalse(date1 > date2);
        }
        [Test]
        [ExpectedException("Year should be between 1 and 4000")]
        public void Constructor_WithYearOutsideRange_ThrowsArgumentException()
        {
            var date1 = new Date(4001, 11, 17);
        }
        [Test]
        [ExpectedException("Month should be between 1 and 12")]
        public void Constructor_WithMonthOutsideRange_ThrowsArgumentException()
        {
            var date1 = new Date(2009, 13, 17);
        }
        [Test]
        [ExpectedException("Day should be between 1 and 28")]
        public void Constructor_WithDayOutsideRange_ThrowsArgumentException()
        {
            var date1 = new Date(2009, 2, 29);
        }
    }
}