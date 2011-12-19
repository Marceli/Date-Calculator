using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controllers;

namespace DateCalculation
{
    public partial class Default : System.Web.UI.Page,IDateCalculatorView
    {
        private DateCalculatorController controller;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.controller = new DateCalculatorController(this);
        }

        protected void ClearButtonClick(object sender, EventArgs e)
        {
            controller.Clear();
        }

        protected void CalculateButtonClick(object sender, EventArgs e)
        {
           controller.Calculate();
        }
        



        #region Implementation of IDateCalculatorView

        public void DisplayCustomMessageInValidationSummary(string message)
        {

            CustomValidator CustomValidatorCtrl = new CustomValidator();

            CustomValidatorCtrl.IsValid = false;
            CustomValidatorCtrl.Visible = false;

            CustomValidatorCtrl.ErrorMessage = message;
            Control form=this.Page.FindControl("form1");
            form.Controls.Add(CustomValidatorCtrl);
        }  

        public string StartDay
        {
            get { return this.txtStartDay.Text; }
            set { txtStartDay.Text=value; }
        }

        public string StartMonth
        {
            get { return txtStartMonth.Text; }
            set { txtStartMonth.Text = value; }
        }

        public string StartYear
        {
            get { return txtStartYear.Text; }
            set { txtStartYear.Text = value; }
        }

        public string EndDay
        {
            get { return txtEndDay.Text; }
            set { txtEndDay.Text = value; }
        }

        public string EndMonth
        {
            get { return txtEndMonth.Text; }
            set { txtEndMonth.Text = value; }
        }

        public string EndYear
        {
            get { return txtEndYear.Text; }
            set { txtEndYear.Text = value; }
        }

        public string Result
        {
            set
            {
                lblResult.Text = value;
                pnlResult.Visible=true; 
            }
        }

        #endregion
    }
}
