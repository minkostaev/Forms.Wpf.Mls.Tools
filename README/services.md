### *Services:*

- ## AssemblyProperties - *Ready to use Exe/dll properties*

It has simple to use properties. Now it has only 5, but more will be added in the future. One example:

```
var appIcon = AssemblyProperties.AssemblyIcon;
```

- ## EscapeCloses - *On ESC keyboard pressed closes Window/Form*

Easy to use service to close Window/Form on keyboard key press button ESC

- ## JsonConvert - *Json to object and object To json*

Serialize and deserialize easy with few lines (plus file path methods)

```
var prsn = new Person();
string json = @"{""Name"": ""John"",""Age"": 30}";
prsn = JsonConvert.JsonStringToObject(json, prsn) as Person;
```

- ## Shortcuts - *Methods for creating shortcut*

Easy to create shortcut with one line. It has also Startup Shortcut - ready to use method to add shortcut to users startup folder.

```
Shortcuts.CreateShortcut(exePath, lnkPath);
```

- ## SizePositioning - *Save Window/Form position and size on the monitor*

It's not the standard way with project's resource  properties. This uses json. Serialize on close and deserialize on load. To use it you need only this line:

```
SizePositioning.AssignForm(this);
```
or
```
SizePositioning.AssignWindow(this);
```

- ## SpecialFolders - *Windows' special folders*

It has simple to use properties. Now it has only 5, but more will be added in the future. One example 'C:\ProgramData':

```
var progData = SpecialFolders.CommonAppData;
```

[back](https://github.com/minkostaev/Forms.Wpf.Mls.Tools)