### *Services:*

- ## AppSettings - *Save objects to files and load it back*

Object with properties to Json file and Json file deserialize back in object. One example:

```
bool isSaved = AppSettings.Save(myPropsObj, WindowsLocation.LocalData, "props");
MyPropsObj myPropsObj = AppSettings.Load(myPropsObj, WindowsLocation.LocalData, "prop") as MyPropsObj;
```

- ## AssemblyProperties - *Ready to use exe/dll properties*

It has simple to use properties. Now it has only 5, but more will be added in the future. One example:

```
var appIcon = AssemblyProperties.AssemblyIcon;
```

- ## EscapeCloses - *On ESC keyboard pressed closes Form/Window*

Easy to use service to close Window/Form on keyboard key press button ESC

```
EscapeCloses.InitWindow(this);
```

- ## JsonConvert - *Json to object and object to json*

Serialize and deserialize easy with few lines (plus file path methods)

```
var prsn = new Person();
string json = @"{""Name"": ""John"",""Age"": 30}";
prsn = JsonConvert.JsonStringToObject(json, prsn) as Person;
```

Plus: Methods that deserialize **ANY** Json to Dictionary<string, object> (supported types: list, string, int, decimal and bool)

- ## WindowsShortcut - *Method for creating shortcut*

Easy to create shortcut with one line.

```
Shortcut.Create(exePath, lnkPath);
```

- ## StartupShortcut - *Methods for add shortcut to users startup folder*

Ready to use methods to add/remove shortcut to users startup folder.

```
var startupShortcut = new StartupShortcut();
chBxWindowsStartup.IsChecked = startupShortcut.IsAppInStartup;
chBxWindowsStartup.Checked += delegate { startupShortcut.Add(); };
chBxWindowsStartup.Unchecked += delegate { startupShortcut.Remove(); };
```

- ## SizePositioning - *Save Form/Window position and size on the monitor*

It's not the standard way with project's resource  properties. This uses json. Serialize on close and deserialize on load. To use it you need only this line:

```
SizePositioning.AssignForm(this);
```

- ## SpecialFolders - *Windows' special folders*

It has simple to use properties. Now it has only 5, but more will be added in the future. One example 'C:\ProgramData':

```
var progData = SpecialFolders.CommonAppData;
```

- ## MultiLanguage - *Easily change multiple languages*

[AK MULTILANGUAGES](https://github.com/aksoftware98/multilanguages)

```
LanguageService.SetCulture("nl-NL");
lbl.Text = LanguageService.GetValue("hello_world");
```

- ## RequestManager - *Send API requests*

It sends requests to APIs

```
var response = await _requestManager.SendRequest(target, method, body);
```

- ## Internet - *Ping to check connection*

Method that check for internet connection
```
bool hasInternet = CheckForConnection();
```

[back](https://github.com/minkostaev/Forms.Wpf.Mls.Tools)
