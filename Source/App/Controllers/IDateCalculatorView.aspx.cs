namespace DateCalculation
{
    public interface IDateCalculatorView
    {
        string StartDay { get; set; }
        string StartMonth { get; set; }
        string StartYear { get; set; }
        string EndDay { get; set; }
        string EndMonth { get; set; }
        string EndYear { get; set; }
        string Result { set; }
        void DisplayCustomMessageInValidationSummary(string message);
    }
}