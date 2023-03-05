using Forms.Wpf.Mls.Tools.Services;

namespace Forms.Test.Helper;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // Save-Load Windows Size and Position
        SizePositioning.AssignForm(this);

        // I want to use it in shortcut properties after installation
        string[] args = Environment.GetCommandLineArgs();

        //#region Special Folders
        //tbStartSystem.Text = SpecialFolders.StartupSystem;
        //tbStartUser.Text = SpecialFolders.StartupUser;

        //tbUser.Text = Environment.UserName;
        //tbLocal.Text = SpecialFolders.LocalAppData;

        //btnStartupSystem.Click += delegate { Process.Start("explorer.exe", tbStartSystem.Text); };
        //btnStartupUser.Click += delegate { Process.Start("explorer.exe", tbStartUser.Text); };
        //#endregion

        //#region System Tray
        ////var SystemIcon = new SystemTray(this);
        ////chBxSystemTray.IsChecked = true;
        ////chBxSystemTray.Checked += delegate { SystemIcon.Visibility = true; };
        ////chBxSystemTray.Unchecked += delegate { SystemIcon.Visibility = false; };
        //#endregion

        //#region Always On Top
        //chBxAlwaysOnTop.Checked += delegate { this.Topmost = true; };
        //chBxAlwaysOnTop.Unchecked += delegate { this.Topmost = false; };
        //#endregion

        //#region Show In Taskbar
        //chBxShowInTaskbar.IsChecked = true;
        //chBxShowInTaskbar.Checked += delegate { this.ShowInTaskbar = true; };
        //chBxShowInTaskbar.Unchecked += delegate { this.ShowInTaskbar = false; };
        //#endregion

    }

}