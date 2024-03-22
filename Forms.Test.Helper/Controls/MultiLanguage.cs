namespace Forms.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.Services;

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
        btnBg.Text = LanguageService.GetValue("bulgarian");
        btnEn.Text = LanguageService.GetValue("english");
        lbl.Text = LanguageService.GetValue("welcome");
    }

}