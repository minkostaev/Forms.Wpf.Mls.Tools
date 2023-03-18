using Forms.Wpf.Mls.Tools.Services;
using System.Diagnostics;
using System;
using System.Windows.Controls;

namespace Wpf.Test.Helper.Controls;

/// <summary>
/// Interaction logic for Folders.xaml
/// </summary>
public partial class Folders : UserControl
{
    public Folders()
    {
        InitializeComponent();

        btnStartupSystem.Click += delegate { Process.Start("explorer.exe", tbStartSystem.Text); };
        btnStartupUser.Click += delegate { Process.Start("explorer.exe", tbStartUser.Text); };

        tbStartSystem.Text = SpecialFolders.StartupSystem;
        tbStartUser.Text = SpecialFolders.StartupUser;
        
        tbUser.Text = Environment.UserName;
        tbLocal.Text = SpecialFolders.LocalAppData;

        tbAppVersion.Text = AssemblyProperties.AppVersion;
        tbDllVersion.Text = AssemblyProperties.DllVersion;

        tbAppName.Text = AssemblyProperties.AssemblyName;
        tbDllName.Text = AssemblyProperties.DllName;

    }

}