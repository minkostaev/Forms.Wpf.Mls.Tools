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
        EscapeCloses.InitForm(this);

        // I want to use it in shortcut properties after installation
        string[] args = Environment.GetCommandLineArgs();// to do 
        // to do

        var windows = new Windows(this)
        { Dock = DockStyle.Fill };
        tbPgWindows.Controls.Add(windows);

        ///var prsn = new Person();
        ///string json = @"{""Name"": ""John"",""Age"": 30}";
        ///prsn = JsonConvert.JsonStringToObject(prsn, json) as Person;// to do more

        //var asd = JsonConvert.JsonFileToDictionary(@"C:\Users\shefa\Downloads\Trakt_history_13-5-2023 242.json");

        var folders = new Folders
        { Dock = DockStyle.Fill };
        tbPgFolders.Controls.Add(folders);



    }

}