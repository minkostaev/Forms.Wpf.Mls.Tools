namespace Forms.Wpf.Mls.Tools.Services;

using System.Windows;
using System.Windows.Input;

public static class EscapeCloses
{
    /// <summary>
    /// Assign Window to close on ESC key pressed
    /// </summary>
    /// <param name="window"></param>
    public static void InitWindow(Window window)
    {
        window.PreviewKeyDown += (s, e) =>
        {
            if (e.Key == Key.Escape)
            {
                window.Close();
            }
        };
    }

    /// <summary>
    /// Assign Form to close on ESC key pressed
    /// </summary>
    /// <param name="form"></param>
    public static void InitForm(Form form)
    {
        form.KeyPreview = true;//important
        form.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
            }
        };
    }

}