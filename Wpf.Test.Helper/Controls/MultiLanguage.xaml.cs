namespace Wpf.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.Services;
using System.Windows.Controls;

/// <summary>
/// Interaction logic for MultiLanguage.xaml
/// </summary>
public partial class MultiLanguage : UserControl
{
    public MultiLanguage()
    {
        InitializeComponent();

        btnEn.Click += delegate
        {
            LanguageService.SetCulture("en-US");
            MultiLangLabels();
        };

        btnBg.Click += delegate
        {
            LanguageService.SetCulture("bg-BG");
            MultiLangLabels();
        };

        btnNl.Click += delegate
        {
            LanguageService.SetCulture("nl-NL");
            MultiLangLabels();
        };

    }

    private void MultiLangLabels()
    {
        btnBg.Content = LanguageService.GetValue("bulgarian");
        btnEn.Content = LanguageService.GetValue("english");
        lbl.Content = LanguageService.GetValue("welcome");
    }

}
