namespace Forms.Wpf.Mls.Tools.Services;

using Forms.Wpf.Mls.Tools.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shell;

public static class SizePositioning
{
    public static void AssignForm(Form form,
        WindowsLocation location = WindowsLocation.LocalData)
    {
        form.StartPosition = FormStartPosition.Manual;//important
        string formName = form.GetType().Name;
        string path = AppSettings.JsonPath(location, formName);

        #region Load file and apply to Window
        var obj = JsonFileToObject(path);
        form.Location = new System.Drawing.Point((int)obj.Left, (int)obj.Top);
        form.Size = new System.Drawing.Size((int)obj.Width, (int)obj.Height);
        #endregion

        #region Save file from Window parameters
        form.Closed += delegate
        {
            var obj = new PositionSize()
            {
                Left = form.Location.X,
                Top = form.Location.Y,
                Width = form.Size.Width,
                Height = form.Size.Height
            };
            ObjectToJsonFile(obj, path);
        };
        #endregion

    }
    public static void AssignWindow(Window window,
        WindowsLocation location = WindowsLocation.LocalData, ImageSource? resetIcon = null)
    {
        string windowName = window.GetType().Name;
        string path = AppSettings.JsonPath(location, windowName);

        #region Load file and apply to Window
        var obj = JsonFileToObject(path);
        window.Left = obj.Left;
        window.Top = obj.Top;
        window.Width = obj.Width;
        window.Height = obj.Height;
        #endregion

        #region Save file from Window parameters
        window.Closed += delegate
        {
            var obj = new PositionSize()
            {
                Left = window.Left,
                Top = window.Top,
                Width = window.Width,
                Height = window.Height
            };
            ObjectToJsonFile(obj, path);
        };
        #endregion

        #region Reset button in taskbar
        ThumbButtonInfo btnInfo = new ThumbButtonInfo();
        //btnInfo.Command = new RelayCommand(DoSomething);
        //btnInfo.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/MyButtonIcon.png"));
        var appIcon = AssemblyProperties.AssemblyIcon;
        if (appIcon != null && resetIcon == null)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                appIcon.Handle, System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            btnInfo.ImageSource = imageSource;
        }
        else
        {
            btnInfo.ImageSource = resetIcon;
        }
        btnInfo.Description = "Reset window's position and size";
        btnInfo.Click += delegate
        {
            window.Left = 200;
            window.Top = 200;
            window.Width = 200;
            window.Height = 200;
        };
        var taskbarInfo = new TaskbarItemInfo();
        taskbarInfo.ThumbButtonInfos.Add(btnInfo);
        window.TaskbarItemInfo = taskbarInfo;
        #endregion

    }

    private static bool ObjectToJsonFile(PositionSize positionSize, string filePath)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(positionSize, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, jsonString);
            return true;
        }
        catch (Exception) { return false; }
    }
    private static PositionSize JsonFileToObject(string? filePath)
    {
        var defaultResult = new PositionSize()
        {
            Left = 200,
            Top = 200,
            Width = 200,
            Height = 200
        };
        if (!File.Exists(filePath))
        {
            return defaultResult;
        }
        try
        {
            string json = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<PositionSize>(json) ?? new PositionSize();
            return result;
        }
        catch (Exception) { return defaultResult; }
    }

}
// to do  add option for user to pass location