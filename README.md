# Forms.Wpf.Mls.Tools

[![Badge Name](https://img.shields.io/badge/GitHub-Forms.Wpf.Mls.Tools-blue.svg)](https://github.com/minkostaev/Forms.Wpf.Mls.Tools)
[![NuGet version (Forms.Wpf.Mls.Tools)](https://img.shields.io/nuget/v/Forms.Wpf.Mls.Tools.svg?style=flat-square)](https://www.nuget.org/packages/Forms.Wpf.Mls.Tools/)

This library will help your Windows Forms and WPF apps with usefull tools (services and controls).

Services:

## AssemblyProperties - Ready to use Exe/dll properties

It has simple to use properties. Now it has only 5, but more will be added in the future. One example:

```
var appIcon = AssemblyProperties.AssemblyIcon;
```

## EscapeCloses - On ESC keyboard pressed closes Window/Form

Easy to use service to close Window/Form on keyboard key press button ESC

## Shortcuts - Methods for creating shortcut

Easy to create shortcut with one line. It has also Startup Shortcut - ready to use method to add shortcut to users startup folder.

```
Shortcuts.CreateShortcut(exePath, lnkPath);
```

## SizePositioning - Save Window/Form position and size on the monitor

It's not the standard way with project's resource  properties. This uses json. Serialize on close and deserialize on load. To use it you need only this line:

```
SizePositioning.AssignForm(this);
```
or
```
SizePositioning.AssignWindow(this);
```

## SpecialFolders - Windows' special folders

It has simple to use properties. Now it has only 5, but more will be added in the future. One example 'C:\ProgramData':

```
var progData = SpecialFolders.CommonAppData;
```

Controls:

## SystemTray - Adding NotifyIcon control to Window/Form

This adds icon in the Windows taskbar system tray. It has default context menu that you can replace with your own. It also has - close app to the tray icon and doble click opens back the app.

```
var SystemIcon = new SystemTray(form);
chBxSystemTray.CheckedChanged += delegate { SystemIcon.Visibility = chBxSystemTray.Checked; };
````
