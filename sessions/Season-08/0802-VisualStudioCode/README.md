# 0802 - Visual Studio Code Tips and Tricks

Visual Studio Code is one of the most popular code editors in the world, and has been receiving regular updates monthly since its original release in 2015.

Wikipedia has a nice article about the history of [Visual Studio Code](https://en.wikipedia.org/wiki/Visual_Studio_Code).

## Current Version and Acquision

[Visual Studio Code](https://code.visualstudio.com) is available in [source code](https://github.com/microsoft/vscode) form and in binary distributions for Windows, Mac, and Linux.  You can also run it in the browser, with instances available on GitHub CodeSpaces.  

Try opening a page of code from GitHub when signed in by just pressing the 'dot' key on your keyboard `.`  You can also change the GitHub URL by replacing `github.com` with `github.dev` and open the current page in Visual Studio Code in the browser.

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
- `Ctrl+P` - Open the File navigator and locate a file by name
- `Ctrl+Alt+P` - Open the Command Pallete to execute a command for Visual Studio Code
- `Ctrl+T` - Search your code - filenames, classes, interfaces, methods, properties, events, enums
- `Ctrl+G` - Goto line number
- `F12` - Goto definition of the object under cursor
- `Shift+F12` - Find all references of the object under cursor
- `Ctrl+F12` - Find all implementations of the interface under cursor, if not an interface, goes to definition
- `Previous Mouse Button` to navigate to the previous code location
- `Next Mouse Button` to navigate to the next code location
- `Ctrl+M M` to collapse / expand the current block of code

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

## The Terminal

- The terminal can be opened by pressing <code>Ctrl+`</Code>

## Make Visual Studio yours

- Get your favorite themes from the [marketplace](https://marketplace.visualstudio.com/search?target=VSCode&category=Themes&sortBy=Installs)
- Use sites like [VSCode Themes](https://vscodethemes.com/) to preview popular themes
- Configure and use snippets to use code patterns again and again quickly.  Select **Insert Snippet** from the command pallete to review the avaialble snippets and use **Configure User Snippets** to create a collection of snippets for yourself

## Extensions

- [GitHub Copilot](https://marketplace.visualstudio.com/items?itemName=GitHub.copilot) - get suggestions to help write code based on your comments and other code open in Visual Studio (paid service with a free trial available)
- [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [C# Dev Kit][(https://visualstudio.microsoft.com/services/live-share/](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)) to add in Visual Studio 2022 features like Solution Explorer, improved Debugging, and Test running