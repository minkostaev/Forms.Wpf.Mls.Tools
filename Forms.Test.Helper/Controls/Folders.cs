using Forms.Wpf.Mls.Tools.Services;
using System.Diagnostics;

namespace Forms.Test.Helper.Controls;

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

        tbAppName.Text = AssemblyProperties.AssemblyName;
        tbAppVersion.Text = AssemblyProperties.AppVersion;

        tbDllName.Text = AssemblyProperties.DllName;
        tbDllVersion.Text = AssemblyProperties.DllVersion;

    }

}