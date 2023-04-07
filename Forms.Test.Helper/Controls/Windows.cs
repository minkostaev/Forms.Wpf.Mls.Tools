﻿namespace Forms.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.ControlsWf;
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
        btnNotification.Click += delegate
        {
            SystemIcon.ShowNotification("");
        };
        SystemIcon.ClickOnNotification += delegate
        {
            MessageBox.Show("lalala");
        };

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



    }

}