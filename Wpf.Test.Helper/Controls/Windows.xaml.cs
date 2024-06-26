﻿namespace Wpf.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.ControlsWf;
using Forms.Wpf.Mls.Tools.Models;
using Forms.Wpf.Mls.Tools.Services;
using System.Windows.Controls;
using Wpf.Test.Helper.Models;

public partial class Windows : UserControl
{
    public Windows(MainWindow window)
    {
        InitializeComponent();

        // Default ConfigurationManager
        // in file 'App.config' :
        //<?xml version="1.0"?>
        //<configuration>
        //  <connectionStrings>
        //    <add name="mongo" connectionString="db+srv://pass:db.com"/>
        //  </connectionStrings>
        //</configuration>
        //var connectionString = ConfigurationManager.ConnectionStrings["mongo"].ConnectionString;

        // AppSettings load
        var wSettings = AppSettings.Load(new WindowsSettings(), WindowsLocation.LocalData, "WindowsSettings") as WindowsSettings;
        wSettings ??= new WindowsSettings();
        ////

        #region System Tray
        var systemIcon = new SystemTray(window);
        systemIcon.Visibility = wSettings.SystemTray;
        chBxSystemTray.IsChecked = wSettings.SystemTray;
        chBxSystemTray.Checked += delegate
        {
            wSettings.SystemTray = true;
            systemIcon.Visibility = wSettings.SystemTray;
            SaveSettings(wSettings);
        };
        chBxSystemTray.Unchecked += delegate
        {
            wSettings.SystemTray = false;
            systemIcon.Visibility = wSettings.SystemTray;
            SaveSettings(wSettings);
        };
        btnNotification.Click += delegate
        {
            systemIcon.ShowNotification("");
        };
        #endregion

        #region Always On Top
        window.Topmost = wSettings.AlwaysOnTop;
        chBxAlwaysOnTop.IsChecked = wSettings.AlwaysOnTop;
        chBxAlwaysOnTop.Checked += delegate
        {
            wSettings.AlwaysOnTop = true;
            window.Topmost = wSettings.AlwaysOnTop;
            SaveSettings(wSettings);
        };
        chBxAlwaysOnTop.Unchecked += delegate
        {
            wSettings.AlwaysOnTop = false;
            window.Topmost = wSettings.AlwaysOnTop;
            SaveSettings(wSettings);
        };
        #endregion

        #region Show In Taskbar
        window.ShowInTaskbar = wSettings.ShowInTaskbar;
        chBxShowInTaskbar.IsChecked = wSettings.ShowInTaskbar;
        chBxShowInTaskbar.Checked += delegate
        {
            wSettings.ShowInTaskbar = true;
            window.ShowInTaskbar = wSettings.ShowInTaskbar;
            SaveSettings(wSettings);
        };
        chBxShowInTaskbar.Unchecked += delegate
        {
            wSettings.ShowInTaskbar = false;
            window.ShowInTaskbar = wSettings.ShowInTaskbar;
            SaveSettings(wSettings);
        };
        #endregion

        // Startup Shortcut
        var startupShortcut = new StartupShortcut();
        chBxWindowsStartup.IsChecked = startupShortcut.IsAppInStartup;
        chBxWindowsStartup.Checked += delegate { startupShortcut.Add(); };
        chBxWindowsStartup.Unchecked += delegate { startupShortcut.Remove(); };

    }

    private static void SaveSettings(WindowsSettings? windowsSettings)
    {
        AppSettings.Save(windowsSettings, WindowsLocation.LocalData, "WindowsSettings");
    }

}