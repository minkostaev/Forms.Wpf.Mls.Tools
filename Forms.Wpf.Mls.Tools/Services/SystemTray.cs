using System.Windows;

namespace Forms.Wpf.Mls.Tools.Services;

// This is my NotifyIcon for WPF
// You'll need to add <UseWindowsForms>true</UseWindowsForms> to your project file
public class SystemTray
{
    public SystemTray(Window window)
    {
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
        SystemIcon.MouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                if (window.Visibility == System.Windows.Visibility.Visible)
                {
                    window.Hide();
                }
                else
                {
                    window.Show();
                    window.Activate();
                }
            }
        };

        window.Closing += (s, e) =>
        {
            if (SystemIcon.Visible)
            {
                e.Cancel = true;
                window.Hide();
            }
        };
    }
    public SystemTray(Form form)
    {
        SystemIcon = new NotifyIcon();

        #region Default Context Menu
        var contextMenuDefault = new ContextMenuStrip();
        var mnItmExit = new ToolStripMenuItem("Exit");
        mnItmExit.Click += delegate
        {
            SystemIcon.Visible = false;
            form.Close();
        };
        contextMenuDefault.Items.Add(mnItmExit);
        #endregion

        SystemIcon.ContextMenuStrip = contextMenuDefault;
        SystemIcon.Visible = true;
        SystemIcon.Icon = AssemblyProperties.AssemblyIcon;
        SystemIcon.Text = AssemblyProperties.AssemblyName;
        SystemIcon.MouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                if (form.Visible)
                {
                    form.Hide();
                }
                else
                {
                    form.Show();
                    form.Activate();
                }
            }
        };

        form.FormClosing += (s, e) =>
        {
            if (SystemIcon.Visible)
            {
                e.Cancel = true;
                form.Hide();
            }
        };
    }

    // 
    private NotifyIcon SystemIcon { get; set; }

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

}