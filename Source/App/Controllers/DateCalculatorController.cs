using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DateCalculation;

namespace Controllers
{
    public class DateCalculatorController
    {
        private IDateCalculatorView view;

        public DateCalculatorController(IDateCalculatorView view)
        {
            this.view = view;
        }

        public void Clear()
        {
            view.EndDay = "";
            view.EndMonth = "";
            view.EndYear = "";
            view.StartDay = "";
            view.StartMonth = "";
            view.StartYear = "";

        }

        public void Calculate()
        {
            try
            {
                var startDate = new Core.Date(int.Parse(view.StartYear), int.Parse(view.StartMonth), int.Parse(view.StartDay));
                var endDate = new Date(int.Parse(view.EndYear), int.Parse(view.EndMonth), int.Parse(view.EndDay));
                if (startDate > endDate)
                {
                    view.Result = endDate.CalculateDifference(startDate).ToString();
                    view.DisplayCustomMessageInValidationSummary("Start date after end date. Dates were Switched");
                }
                else
                {
                    view.Result = startDate.CalculateDifference(endDate).ToString();
                }
            }
            catch (FormatException ex)
            {
                view.DisplayCustomMessageInValidationSummary("Please Provide numeric values in boxes");
            }
            catch (ArgumentException ex)
            {
                view.DisplayCustomMessageInValidationSummary(ex.Message);
            }
            
        }
    }
}
