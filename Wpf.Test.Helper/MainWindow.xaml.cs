namespace Wpf.Test.Helper;

using Forms.Wpf.Mls.Tools.Services;
using System;
using System.Windows;
using Wpf.Test.Helper.Controls;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Save-Load Windows Size and Position
        SizePositioning.AssignWindow(this);

        ///var prsn = new Person();
        ///string json = @"{""Name"": ""John"",""Age"": 30}";
        ///prsn = JsonConvert.JsonStringToObject(prsn, json) as Person;
        ///bool isSaved = AppSettings.Save(prsn, WindowsLocation.LocalData, "prop");
        ///prsn = AppSettings.Load(prsn, WindowsLocation.LocalData, "prop") as Person;

        // Escape closes window
        EscapeCloses.InitWindow(this);

        // I want to use it in shortcut properties after installation
        string[] args = Environment.GetCommandLineArgs();
        // to do

        grdFolders.Children.Add(new Folders());
        grdWindows.Children.Add(new Windows(this));
        grdTree.Children.Add(new TreeViewLines());

    }

}