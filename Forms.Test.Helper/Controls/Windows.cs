namespace Forms.Test.Helper.Controls;

using Forms.Test.Helper.Models;
using Forms.Wpf.Mls.Tools.ControlsWf;
using Forms.Wpf.Mls.Tools.Models;
using Forms.Wpf.Mls.Tools.Services;

public partial class Windows : UserControl
{
    public Windows(Form form)
    {
        InitializeComponent();

        // AppSettings load
        var wSettings = AppSettings.Load(new WindowsSettings(), WindowsLocation.LocalData, "WindowsSettings") as WindowsSettings;
        wSettings ??= new WindowsSettings();
        ////

        #region System Tray
        var systemIcon = new SystemTray(form, true, true);
        systemIcon.Visibility = wSettings.SystemTray;
        chBxSystemTray.Checked = wSettings.SystemTray;
        chBxSystemTray.CheckedChanged += delegate
        {
            wSettings.SystemTray = chBxSystemTray.Checked;
            systemIcon.Visibility = wSettings.SystemTray;
            SaveSettings(wSettings);
        };
        btnNotification.Click += delegate
        {
            systemIcon.ShowNotification("");
        };
        systemIcon.ClickOnNotification += delegate
        {
            MessageBox.Show("lalala");
        };
        #endregion

        #region Always On Top
        form.TopMost = wSettings.AlwaysOnTop;
        chBxAlwaysOnTop.Checked = wSettings.AlwaysOnTop;
        chBxAlwaysOnTop.CheckedChanged += delegate
        {
            wSettings.AlwaysOnTop = chBxAlwaysOnTop.Checked;
            form.TopMost = wSettings.AlwaysOnTop;
            SaveSettings(wSettings);
        };
        #endregion

        #region Show In Taskbar
        form.ShowInTaskbar = wSettings.ShowInTaskbar;
        chBxShowInTaskbar.Checked = wSettings.ShowInTaskbar;
        chBxShowInTaskbar.CheckedChanged += delegate
        {
            wSettings.ShowInTaskbar = chBxShowInTaskbar.Checked;
            form.ShowInTaskbar = wSettings.ShowInTaskbar;
            SaveSettings(wSettings);
        };
        #endregion

        // Startup Shortcut
        var startupShortcut = new StartupShortcut();
        chBxWindowsStartup.Checked = startupShortcut.IsAppInStartup;
        chBxWindowsStartup.CheckedChanged += delegate
        {
            if (chBxWindowsStartup.Checked)
            {
                startupShortcut.Add();
            }
            else
            {
                startupShortcut.Remove();
            }
        };


    }

    private static void SaveSettings(WindowsSettings? windowsSettings)
    {
        AppSettings.Save(windowsSettings, WindowsLocation.LocalData, "WindowsSettings");
    }

}