namespace Forms.Test.Helper;

using Forms.Test.Helper.Controls;
using Forms.Wpf.Mls.Tools.Services;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // Save-Load Windows Size and Position
        SizePositioning.AssignForm(this);

        // Escape closes window
        var escapeCloses = new EscapeCloses(this);
        //escapeCloses.AskConfirmation = true;
        //escapeCloses.AskMessage = "aaaa";
        //escapeCloses.AskCaption = "bbbb";

        // I want to use it in shortcut properties after installation
        string[] args = Environment.GetCommandLineArgs();// to do 


        var windows = new Windows(this)
        { Dock = DockStyle.Fill };
        tbPgWindows.Controls.Add(windows);


        var folders = new Folders
        { Dock = DockStyle.Fill };
        tbPgFolders.Controls.Add(folders);



    }

}