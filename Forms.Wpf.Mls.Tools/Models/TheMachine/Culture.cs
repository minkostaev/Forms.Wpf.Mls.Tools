namespace Forms.Wpf.Mls.Tools.Models.TheMachine;

using System.Globalization;

public class Culture
{
    public Culture() { Init(true); }
    public Culture(bool initialize) { Init(initialize); }
    private void Init(bool initialize = false)
    {
        if (initialize)
        {
            try
            {
                Name = CultureInfo.CurrentCulture.Name;
                Description = CultureInfo.CurrentCulture.EnglishName;
                Separator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            }
            catch (Exception ex) { Description = ex.Message; }
        }
    }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Separator { get; set; }
}