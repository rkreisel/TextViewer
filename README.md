# Text Viewer

Text viewer is a simple dll in a Nuget package that will open a popup window with text and a simple search feature.

## Project

https://github.com/rkreisel/TextViewer.git

## Installation

```
NuGet\Install-Package TextViewer - Version 1.0.0
```

## Usage

### Load text that you create in code:

```c#
var viewer = new Viewer.Viewer("Viewer1");
viewer.LoadText("This is some text");
viewer.Show();
```

### Load text from file

```c#
var viewer = new Viewer.Viewer("Viewer2");
viewer.LoadFile(validfilename);
viewer.Show();
```

