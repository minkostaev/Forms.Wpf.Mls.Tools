namespace Wpf.Test.Helper.Controls;

using Forms.Wpf.Mls.Tools.ControlsWpf;
using System.Windows.Controls;

public partial class TreeViewLines : UserControl
{
    public TreeViewLines()
    {
        InitializeComponent();

        var treeViewLine = new TreeViewLine();



        var treeViewItem = new TreeViewItem();
        treeViewItem.Header = "Name Name Name";


        var treeViewItem2 = new TreeViewItem();
        treeViewItem2.Header = "Xame Xame Xame";
        treeViewItem.Items.Add(treeViewItem2);

        var treeViewItem3 = new TreeViewItem();
        treeViewItem3.Header = "3ame 3ame 3ame";

        treeViewLine.TreeLines.Items.Add(treeViewItem);
        treeViewLine.TreeLines.Items.Add(treeViewItem3);




        grd.Children.Add(treeViewLine);

    }
}