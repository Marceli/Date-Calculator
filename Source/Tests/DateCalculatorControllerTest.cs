using System;
using System.Collections.Generic;

using System.Text;
using Controllers;
using DateCalculation;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests
{
    [TestFixture]
    public class DateCalculatorControllerTest
    {
        [Test]
        public void ClearTest()
        {
            //arrange
     
            var dateCalculatorView = MockRepository.GenerateMock<IDateCalculatorView>();
            var calculatorController = new DateCalculatorController(dateCalculatorView);
            //act
            calculatorController.Clear();
            //assert
            dateCalculatorView.AssertWasCalled(x => x.EndDay = "");
            dateCalculatorView.AssertWasCalled(x => x.EndMonth = ""); 
            dateCalculatorView.AssertWasCalled(x => x.EndYear = "");
            dateCalculatorView.AssertWasCalled(x => x.StartDay = "");
            dateCalculatorView.AssertWasCalled(x => x.StartMonth = "");
            dateCalculatorView.AssertWasCalled(x => x.StartYear = "");
           
        }
        [Test]
        public void CalculationTest()
        {
            //arrange
            var dateCalculatorView = MockRepository.GenerateMock<IDateCalculatorView>();
            var calculatorController = new DateCalculatorController(dateCalculatorView);
            dateCalculatorView.Expect(x => x.StartDay).Return("1");
            dateCalculatorView.Expect(x => x.StartMonth).Return("1");
            dateCalculatorView.Expect(x => x.StartYear).Return("2009");
            dateCalculatorView.Expect(x => x.EndDay).Return("2");
            dateCalculatorView.Expect(x => x.EndMonth).Return("1");
            dateCalculatorView.Expect(x => x.EndYear).Return("2009");
            //act
            calculatorController.Calculate();
            //assert
            dateCalculatorView.AssertWasCalled(x => x.Result = "1");



        }
        [Test]
        public void Calculation_WithStartDateAfterEndDateDisplayMessage()
        {
            //arrange
            var dateCalculatorView = MockRepository.GenerateMock<IDateCalculatorView>();
            var calculatorController = new DateCalculatorController(dateCalculatorView);
            dateCalculatorView.Expect(x => x.StartDay).Return("2");
            dateCalculatorView.Expect(x => x.StartMonth).Return("1");
            dateCalculatorView.Expect(x => x.StartYear).Return("2009");
            dateCalculatorView.Expect(x => x.EndDay).Return("1");
            dateCalculatorView.Expect(x => x.EndMonth).Return("1");
            dateCalculatorView.Expect(x => x.EndYear).Return("2009");
            //act
            calculatorController.Calculate();
            //assert
            dateCalculatorView.AssertWasCalled(x => x.DisplayCustomMessageInValidationSummary("Start date after end date. Dates were Switched"));



        }
        [Test]
        public void Calculation_WithEmptyVasluesInBoxes_DisplayMessage()
        {
            //arrange
            var dateCalculatorView = MockRepository.GenerateMock<IDateCalculatorView>();
            var calculatorController = new DateCalculatorController(dateCalculatorView);
            dateCalculatorView.Expect(x => x.StartDay).Return("");
            dateCalculatorView.Expect(x => x.StartMonth).Return("");
            dateCalculatorView.Expect(x => x.StartYear).Return("");
            dateCalculatorView.Expect(x => x.EndDay).Return("");
            dateCalculatorView.Expect(x => x.EndMonth).Return("");
            dateCalculatorView.Expect(x => x.EndYear).Return("");
            //act
            calculatorController.Calculate();
            //assert
            dateCalculatorView.AssertWasCalled(x => x.DisplayCustomMessageInValidationSummary("Please Provide numeric values in boxes"));



        }
        
    }
}
