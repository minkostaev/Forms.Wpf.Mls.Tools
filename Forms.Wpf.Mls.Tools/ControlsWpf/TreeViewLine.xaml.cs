namespace Forms.Wpf.Mls.Tools.ControlsWpf;

/// <summary>
/// Interaction logic for TreeView with lines showing
/// </summary>
public partial class TreeViewLine : System.Windows.Controls.UserControl
{
    public TreeViewLine()
    {
        InitializeComponent();
        TreeLines = trVwMain;
    }
    public System.Windows.Controls.TreeView TreeLines { get; private set; }
}