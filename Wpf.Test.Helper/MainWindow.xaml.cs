using Forms.Wpf.Mls.Tools.Services;
using System;
using System.Windows;
using System.Windows.Input;
using Wpf.Test.Helper.Controls;

namespace Wpf.Test.Helper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Save-Load Windows Size and Position
        SizePositioning.AssignWindow(this);

        // Escape closes window
        var escapeCloses = new EscapeCloses(this);
        //escapeCloses.AskConfirmation = true;

        // I want to use it in shortcut properties after installation
        string[] args = Environment.GetCommandLineArgs();

        grdFolders.Children.Add(new Folders());
        grdWindows.Children.Add(new Windows(this));

        //this.PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); };

    }

}