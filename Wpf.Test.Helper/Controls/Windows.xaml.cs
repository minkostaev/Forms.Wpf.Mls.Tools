﻿using Forms.Wpf.Mls.Tools.Services;
using System.Windows.Controls;

namespace Wpf.Test.Helper.Controls;

/// <summary>
/// Interaction logic for Windows.xaml
/// </summary>
public partial class Windows : UserControl
{
    public Windows(MainWindow window)
    {
        InitializeComponent();

        #region System Tray
        var SystemIcon = new SystemTray(window);
        chBxSystemTray.IsChecked = true;
        chBxSystemTray.Checked += delegate { SystemIcon.Visibility = true; };
        chBxSystemTray.Unchecked += delegate { SystemIcon.Visibility = false; };
        #endregion
        
        #region Always On Top
        chBxAlwaysOnTop.Checked += delegate { window.Topmost = true; };
        chBxAlwaysOnTop.Unchecked += delegate { window.Topmost = false; };
        #endregion

        #region Show In Taskbar
        chBxShowInTaskbar.IsChecked = true;
        chBxShowInTaskbar.Checked += delegate { window.ShowInTaskbar = true; };
        chBxShowInTaskbar.Unchecked += delegate { window.ShowInTaskbar = false; };
        #endregion

        // Startup Shortcut
        chBxWindowsStartup.IsChecked = Shortcuts.IsAppInpStartup;
        chBxWindowsStartup.Checked += delegate { Shortcuts.AddAppStartupShortcut(); };
        chBxWindowsStartup.Unchecked += delegate { Shortcuts.RemoveAppStartupShortcut(); };

    }

}