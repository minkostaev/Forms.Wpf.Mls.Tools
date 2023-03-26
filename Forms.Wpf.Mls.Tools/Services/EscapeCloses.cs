namespace Forms.Wpf.Mls.Tools.Services;

using System.Windows;
using System.Windows.Input;

public class EscapeCloses
{
    /// <summary>
    /// Assign Window to close on ESC key pressed
    /// </summary>
    /// <param name="window"></param>
    public EscapeCloses(Window window)
    {
        window.PreviewKeyDown += (s, e) =>
        {
            if (e.Key == Key.Escape)
            {
                if (AskConfirmation)
                {
                    MessageBoxResult dialogResult = MessageBox.Show(AskMessage, AskCaption, MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (dialogResult == MessageBoxResult.OK)
                    {
                        window.Close();
                    }
                }
                else
                    window.Close();
            }
        };
    }

    /// <summary>
    /// Assign Form to close on ESC key pressed
    /// </summary>
    /// <param name="form"></param>
    public EscapeCloses(Form form)
    {
        form.KeyPreview = true;//important
        form.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (AskConfirmation)
                {
                    //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Close?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //if (DialogResult.OK == dialogResult)
                    MessageBoxResult dialogResult = MessageBox.Show(AskMessage, AskCaption, MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (dialogResult == MessageBoxResult.OK)
                    {
                        form.Close();
                    }
                }
                else
                    form.Close();
            }
        };
    }

    /// <summary>
    /// Asks for confirmation with dialog
    /// </summary>
    public bool AskConfirmation { get; set; }

    /// <summary>
    /// Text that will be displayed in close dialog
    /// </summary>
    public string AskMessage { get; set; } = "Close?";

    /// <summary>
    /// Close dialog caption
    /// </summary>
    public string AskCaption { get; set; } = "";

    // to do cancel event

    // it does't use Closing event because will conflict with SystemTray logic

}
// to do improve