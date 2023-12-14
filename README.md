# Text Viewer

Text viewer is a simple dll in a Nuget package that will open a popup window with text and a simple search feature.

Search history is maintained for the most recent 100 searches for each application. The developer may optionally specify a name to the search history file in order to provide different history records for different purposes.

## Project

https://github.com/rkreisel/TextViewer.git

## Installation

```
NuGet\Install-Package TextViewer - Version 1.0.0
```

## Usage

**Note**  In both examples, the second parameter is optional. If not specified all viewer instances will share a common file. It will reside in the ProgramData folder under \HotRS\TextViewer\\*appname*\SearchHist-TxtVwrSrchHst.txt

### Load text that you create in code:

```c#
var viewer = new TextViewer.Viewer("Viewer1", "userdefinednameforsearchhistoryfile");
viewer.LoadText("This is some text");
viewer.Show();
```

### Load text from file

```c#
var viewer = new TextViewer.Viewer("Viewer2", "userdefinednameforsearchhistoryfile");
viewer.LoadFile(validfilename);
viewer.Show();
```

