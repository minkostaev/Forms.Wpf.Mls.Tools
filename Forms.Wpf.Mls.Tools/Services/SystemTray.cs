using System.ComponentModel;
using System.Windows;

namespace Forms.Wpf.Mls.Tools.Services;

// This is my NotifyIcon for WPF
// You'll need to add <UseWindowsForms>true</UseWindowsForms> to your project file
public class SystemTray
{
    public SystemTray(Window window)
    {
        Window = window;
        SystemIcon = new NotifyIcon();

        #region Default Context Menu
        var contextMenuDefault = new ContextMenuStrip();
        var mnItmExit = new ToolStripMenuItem("Exit");
        mnItmExit.Click += delegate
        {
            SystemIcon.Visible = false;
            window.Close();
        };
        contextMenuDefault.Items.Add(mnItmExit);
        #endregion

        SystemIcon.ContextMenuStrip = contextMenuDefault;
        SystemIcon.Visible = true;
        SystemIcon.Icon = AssemblyProperties.AssemblyIcon;
        SystemIcon.Text = AssemblyProperties.AssemblyName;
        SystemIcon.MouseDown += SystemIcon_MouseDown;

        Window.Closing += Window_Closing;
    }
    // to do form
    //public SystemTray(Form form)
    //{
    //}

    // 
    private NotifyIcon SystemIcon { get; set; }
    private Window Window { get; set; }

    /// <summary>
    /// Icon showing in the taskbar tray
    /// </summary>
    public bool Visibility
    {
        get
        {
            return SystemIcon.Visible;
        }
        set
        {
            SystemIcon.Visible = value;
        }
    }
    /// <summary>
    /// Icon source for the tray
    /// </summary>
    public Icon Icon
    {
        get
        {
            return SystemIcon.Icon;
        }
        set
        {
            SystemIcon.Icon = value;
        }
    }
    /// <summary>
    /// Text to display on the tray icon
    /// </summary>
    public string Text
    {
        get
        {
            return SystemIcon.Text;
        }
        set
        {
            SystemIcon.Text = value;
        }
    }
    /// <summary>
    /// Context Menu for the tray
    /// </summary>
    public ContextMenuStrip ContextMenu
    {
        get
        {
            return SystemIcon.ContextMenuStrip;
        }
        set
        {
            SystemIcon.ContextMenuStrip = value;
        }
    }

    // 
    private void Window_Closing(object? sender, CancelEventArgs e)
    {
        if (SystemIcon.Visible)
        {
            e.Cancel = true;
            Window.Hide();
        }
    }

    private void SystemIcon_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            if (Window.Visibility == System.Windows.Visibility.Visible)
            {
                Window.Hide();
            }
            else
            {
                Window.Show();
                Window.Activate();
            }
        }
    }

}