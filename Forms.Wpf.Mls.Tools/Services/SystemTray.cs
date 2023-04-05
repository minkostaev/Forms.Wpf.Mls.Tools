namespace Forms.Wpf.Mls.Tools.Services;

using System.Drawing;
using System.Windows;
using System.Windows.Forms;

// You'll need to add <UseWindowsForms>true</UseWindowsForms> to your project file
public class SystemTray//NotifyIcon
{
    public SystemTray(Form form, bool useDefaultClickEvents = true, bool onClosingHideForm = true)
    {
        systemIcon = new NotifyIcon
        {
            Icon = AssemblyProperties.AssemblyIcon,
            Text = AssemblyProperties.AssemblyName,
            Visible = true,
            ContextMenuStrip = DefaultContextMenu(form),
        };

        if (useDefaultClickEvents)
            InitEventsHelpfulOptionalEvents(form);

        InitEvents();
        
        if (onClosingHideForm)
        {
            form.FormClosing += (s, e) =>
            {
                if (systemIcon.Visible)
                {
                    e.Cancel = true;
                    form.Hide();
                }
            };
        }
    }
    public SystemTray(Window window, bool useDefaultClickEvents = true, bool onClosingHideForm = true)
    {
        systemIcon = new NotifyIcon
        {
            Icon = AssemblyProperties.AssemblyIcon,
            Text = AssemblyProperties.AssemblyName,
            Visible = true,
            ContextMenuStrip = DefaultContextMenu(window),
        };

        if (useDefaultClickEvents)
            InitEventsHelpfulOptionalEvents(window);

        InitEvents();

        if (onClosingHideForm)
        {
            window.Closing += (s, e) =>
            {
                if (systemIcon.Visible)
                {
                    e.Cancel = true;
                    window.Hide();
                }
            };
        }
    }

    // 
    private NotifyIcon systemIcon { get; set; }
    private bool iconStateBeforeNotification { get; set; }
    private ContextMenuStrip DefaultContextMenu(object windowOrForm)
    {
        Window? window = null;
        Form? form = null;
        if (windowOrForm is Window)
            window = windowOrForm as Window;
        if (windowOrForm is Form)
            form = windowOrForm as Form;

        var contextMenuDefault = new ContextMenuStrip();

        var mnItmTip = new ToolStripMenuItem("Notification");
        mnItmTip.Click += delegate
        {
            ShowNotification("Notification text!", "Notification Title", ToolTipIcon.Info);
        };
        contextMenuDefault.Items.Add(mnItmTip);

        var separator1 = new ToolStripSeparator();
        contextMenuDefault.Items.Add(separator1);

        var mnItmExit = new ToolStripMenuItem("Exit");
        mnItmExit.Click += delegate
        {
            systemIcon.Visible = false;
            window?.Close();
            form?.Close();
        };
        contextMenuDefault.Items.Add(mnItmExit);

        return contextMenuDefault;
    }
    private void InitEventsHelpfulOptionalEvents(object windowOrForm)
    {
        Window? window = null;
        Form? form = null;
        if (windowOrForm is Window)
            window = windowOrForm as Window;
        if (windowOrForm is Form)
            form = windowOrForm as Form;

        systemIcon.MouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                bool visible = false;
                if (form != null)
                    visible = form.Visible;
                if (window != null)
                    visible = window.Visibility == System.Windows.Visibility.Visible;
                if (visible)
                {
                    form?.Hide();
                    window?.Hide();
                }
                else
                {
                    form?.Show();
                    form?.Activate();
                    window?.Show();
                    window?.Activate();
                }
            }
        };
        systemIcon.BalloonTipClicked += delegate
        {
            systemIcon.Visible = iconStateBeforeNotification;
            form?.Show();
            form?.Activate();
            window?.Show();
            window?.Activate();
        };
    }
    private void InitEvents()
    {
        systemIcon.MouseDown += (s, e) =>
        {
            ClickOnIcon?.Invoke(s, e);
        };
        systemIcon.BalloonTipClicked += delegate
        {
            systemIcon.Visible = iconStateBeforeNotification;
            ClickOnNotification?.Invoke(this, EventArgs.Empty);
        };
        systemIcon.BalloonTipClosed += delegate
        {
            systemIcon.Visible = iconStateBeforeNotification;
        };
    }

    /// <summary>
    /// Icon showing in the taskbar tray
    /// </summary>
    public bool Visibility
    {
        get
        {
            return systemIcon.Visible;
        }
        set
        {
            systemIcon.Visible = value;
        }
    }
    /// <summary>
    /// Icon source for the tray
    /// </summary>
    public Icon Icon
    {
        get
        {
            return systemIcon.Icon;
        }
        set
        {
            systemIcon.Icon = value;
        }
    }
    /// <summary>
    /// Text to display on the tray icon
    /// </summary>
    public string Text
    {
        get
        {
            return systemIcon.Text;
        }
        set
        {
            systemIcon.Text = value;
        }
    }
    /// <summary>
    /// Context Menu for the tray
    /// </summary>
    public ContextMenuStrip ContextMenu
    {
        get
        {
            return systemIcon.ContextMenuStrip;
        }
        set
        {
            systemIcon.ContextMenuStrip = value;
        }
    }

    /// <summary>
    /// Display Windows notification
    /// </summary>
    /// <param name="tipText">Text (main content)</param>
    /// <param name="tipTitle">Title in bold text above the text</param>
    /// <param name="tipIcon">Icon displayed infront of the text</param>
    /// <param name="timeout">Time period</param>
    public void ShowNotification(string tipText,
        string tipTitle = "", ToolTipIcon tipIcon = ToolTipIcon.None, int timeout = 1000)
    {
        if (string.IsNullOrEmpty(tipText))
        {
            tipText = " ";
        }
        iconStateBeforeNotification = systemIcon.Visible;
        systemIcon.Visible = true;
        systemIcon.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
    }

    public event EventHandler? ClickOnNotification;
    public event MouseEventHandler? ClickOnIcon;

    //public event EventHandler? VisibilityChange; // to do

}
// to do move to Controls 