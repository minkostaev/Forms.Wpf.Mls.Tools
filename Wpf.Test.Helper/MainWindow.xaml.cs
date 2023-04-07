﻿namespace Wpf.Test.Helper;

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

        var prsn = new Person();
        string json = @"
{
    ""Type"": ""Person"",
    ""Name"": ""John"",
    ""Age"": 30
}"
;
        prsn = JsonConvert.JsonStringToObject(json, prsn) as Person;// to do more

        // Escape closes window
        var escapeCloses = new EscapeCloses(this);
        //escapeCloses.AskConfirmation = true;

        // I want to use it in shortcut properties after installation
        string[] args = Environment.GetCommandLineArgs();

        grdFolders.Children.Add(new Folders());
        grdWindows.Children.Add(new Windows(this));
        grdTree.Children.Add(new TreeViewLines());

    }

}