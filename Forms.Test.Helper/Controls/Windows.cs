namespace Forms.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.Services;

public partial class Windows : UserControl
{
    public Windows(Form form)
    {
        InitializeComponent();

        // System Tray
        chBxSystemTray.Checked = true;
        var SystemIcon = new SystemTray(form, false, false);
        chBxSystemTray.CheckedChanged += delegate { SystemIcon.Visibility = chBxSystemTray.Checked; };

        // Always On Top
        chBxAlwaysOnTop.CheckedChanged += delegate { form.TopMost = chBxAlwaysOnTop.Checked; };

        // Show In Taskbar
        chBxShowInTaskbar.Checked = true;
        chBxShowInTaskbar.CheckedChanged += delegate { form.ShowInTaskbar = chBxShowInTaskbar.Checked; };

        // Startup Shortcut
        chBxWindowsStartup.Checked = Shortcuts.IsAppInpStartup;
        chBxWindowsStartup.CheckedChanged += delegate
        {
            if (chBxWindowsStartup.Checked)
            {
                Shortcuts.AddAppStartupShortcut();
            }
            else
            {
                Shortcuts.RemoveAppStartupShortcut();
            }
        };


        SystemIcon.ClickOnNotification += delegate
        {
            System.Windows.Forms.MessageBox.Show("lalala");
        };
        button1.Click += delegate
        {
            SystemIcon.ShowNotification(1000, "title", "text", ToolTipIcon.Info);
        };




    }


}