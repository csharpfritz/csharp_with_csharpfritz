# 0801 - Visual Studio Tips and Tricks

Since the beginning, Visual Studio has been the premiere tool to build and work with .NET code using C#.  This windows-based integrated development environment tool has been available in various versions since 1997 to its latest version Visual Studio 2022.

Wikipedia has a nice article about the history of [Visual Studio](https://en.wikipedia.org/wiki/Visual_Studio).

## Current Version and Acquision

[Visual Studio](https://visualstudio.com) is available in a freemium licensing model, with a [community edition](https://visualstudio.microsoft.com/vs/community/) available for students and folks that are hoobyists or learning.

There is also a Professional edition available for organizations as well as an Enterprise edition with additional tools and access to services

## Code Writing Tips

- `Ctrl+.` to pop open the code suggestion panel with code-fixes and suggestions
- `Ctrl+<SPACE>` to open the intellisense panel with code-completion suggestions
- `<TAB>` to choose a code-completion option and accept it
- `<UP>` and `<DOWN>` when the code-completion window is open to select other options
- `<UP>` and `<DOWN>` when the method signature completion window is open to select optional override signatures
- Hold the `Ctrl` key to make these pop-ups semi-transparent 

- `Ctrl+X` to cut highlighted text to the clipboard
- `Ctrl+C` to copy highlighted text to the clipboard
- `Ctrl+V` to paste the contents of the clipboard
- `Ctrl+E C` or `Ctrl+K C` to comment the current line of code
- `Ctrl+E U` or `Ctrl+K U` to uncomment the current line of code

- `Alt+<UP>` to move the current line of code up
- `Alt+<DOWN>` to move the current line of code down

When writing HTML or other markup syntax

- `Shift+Alt+W` to wrap the current markup with a div element

When you have JSON or XML on the clipboard, try **Edit - Paste Special - Paste as Classes**

Try the **C# Interactive** window to get a REPL experience where you can experiment writing code

## Code Navigation Tips

- `Ctrl+F` to find text in the current file
- `Ctrl+H` to find and replace text in the current file
- `Ctrl+Shift+F` to find text in the current solution / project with options including regular expressions
- `Ctrl+Shift+H` to find and replace text in the current solution / project with options including regular expressions
- `Ctrl+Q` - Search features of Visual Studio
- `Ctrl+T` - Search your code - filenames, classes, interfaces, methods, properties, events, enums
- `Ctrl+G` - Goto line number
- `F12` - Goto definition of the object under cursor
- `Shift+F12` - Find all references of the object under cursor
- `Ctrl+F12` - Find all implementations of the interface under cursor, if not an interface, goes to definition
- `Shift+F2` to add a new file with a template based on the extension you specify
- `Previous Mouse Button` to navigate to the previous code location
- `Next Mouse Button` to navigate to the next code location
- `Ctrl+M M` to collapse / expand the current block of code

Hold Alt while selecting lines vertically to select a block of code and work with all of it at once

### Bookmarks

- `Ctrl+B T` to toggle a bookmark for quick navigation
- `Ctrl+B P` to navigate to the previous bookmark
- `Ctrl+B N` to navigate to the next bookmark

Customize the scroll bar to show a map of your file by right-clicking on the scroll-bar and choosing 'Scroll bar options'

Right-click on the tab bar and choose **Set Tab Layout** to allow you to move the tabs to the left or right, and customize their appearance

Configure Solution Explorer to **Track Active Item** to ensure that the current file is always highlighted in Solution Explorer

## Debugger Tips

- `F5` to start your application and begin debugging
- `Ctrl+F5` to start your application WITHOUT debugging
- `F10` to start your application, begin debugging, and stop on the first line of your code

### While debugging

- `F11` step into the next line of your code
- `F10` step OVER the current code and don't execute it
- `F9` toggle a breakpoint on the current line of code (can also be set when not debugging)
- `Ctrl+Shift+F9` delete all breakpoints
- `Shift+F11` execute and step out of the current method
- `Strl+Alt+P` attach to currently running process

Tricks to make debugging easier:

- Right-click on a breakpoint and add a condition to force the breakpoint to only stop when a condition is met
- Use Locals, Watch, and Immediate windows to get insight into the current variables in scope and execute arbitrary code while working in debug mode
- Configure your own data for the locals and watch windows by adding the [`DebuggerDisplay` attribute](https://learn.microsoft.com/visualstudio/debugger/using-the-debuggerdisplay-attribute)
- Use the Call Stack window to navigate back and forth across the calling methods

More advanced debugging capabilities available:

- Debug on a remote machine with the [remote debugger](https://learn.microsoft.com/visualstudio/debugger/remote-debugging).  This requires installing some tools on the target machine
- Debug inside a Docker container
- Debug inside Windows Subsystem for Linux
- Debug a [MAUI app on a connected device](https://learn.microsoft.com/dotnet/maui/android/device/setup)
- Use the [Snapshot Debugger](https://learn.microsoft.com/azure/azure-monitor/snapshot-debugger/snapshot-debugger) to walk through a collected snapshot from Azure Application Insights

## Make Visual Studio yours

- Get your favorite themes from the [marketplace](https://marketplace.visualstudio.com/search?term=theme&target=VS&category=All%20categories&vsVersion=vs2022&sortBy=Relevance)
- Convert themes from Visual Studio Code for Visual Studio 2022 with the [Theme Converter](https://github.com/microsoft/theme-converter-for-vs)
- Play sounds for various Visual Studio events like 'Build Succeeded' or 'Build Failed' with the System Sounds menu in Windows

## Extensions

- [GitHub Copilot](https://github.com/features/copilot) - get suggestions to help write code based on your comments and other code open in Visual Studio (paid service with a free trial available)
- [Spell Checker](https://marketplace.visualstudio.com/items?itemName=EWoodruff.VisualStudioSpellCheckerVS2017andLater)
- [Live Share](https://visualstudio.microsoft.com/services/live-share/) to allow others to collaborate on the code you're working on