### *Controls:*

### *Win Forms:*

- ## SystemTray - *Adding NotifyIcon control to Form/Window*

This adds icon in the Windows taskbar system tray. It has default context menu that you can replace with your own. It also has - close app to the tray icon and doble click opens back the app.

```
var SystemIcon = new SystemTray(form);
chBxSystemTray.CheckedChanged += delegate { SystemIcon.Visibility = chBxSystemTray.Checked; };
```

### *WPF:*

- ## TreeViewLine - *A custom TreeView with lines*

The change is only for visual - to look more like the Win Forms version of TreeView.

```
var treeViewLine = new TreeViewLine();
grid.Children.Add(treeViewLine);
```

[back](..)
