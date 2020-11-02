# Session 10 - Projects, Solutions, and Unit Testing

We've learned a lot about how to use the C# language, but have not yet actually written a file to disk or built an application.  Starting with this session and going fowrard, we will be working outside the browser and .NET notebooks.  You can use the .NET SDK at the command-line, Visual Studio Code, Visual Studio for Mac, or Visual Studio 2019 among other IDEs and editors to build and interact with your .NET projects.

## The .NET SDK

The .NET SDK is the term we use to refer to the tools that you use to compile and build your applications.  You can get a copy of the tools you need from [https://get.dot.net](https://get.dot.net)  There are separate instructions available for use on Windows, Mac, or Linux.  Once installed, you will be able to work with the code that you write to build applications.

The SDK delivers a series of templates and tools that will help you with your .NET programming tasks.  The primary tool that you will be using is the `dotnet` command-line application.  You can verify that your installation procedure worked properly by executing the following at the command-line:

```
dotnet --info
```

A **project** is a unit of application code that can either represent the user-interface of an application, the server component of an application, or a re-usable component of a project.  We can create projects using the `dotnet new` command.  The default templates that ship with .NET 5 are listed below:

```
Templates                                         Short Name               Language          Tags
--------------------------------------------      -------------------      ------------      ----------------------
Console Application                               console                  [C#], F#, VB      Common/Console
Class library                                     classlib                 [C#], F#, VB      Common/Library
WPF Application                                   wpf                      [C#]              Common/WPF
WPF Class library                                 wpflib                   [C#]              Common/WPF
WPF Custom Control Library                        wpfcustomcontrollib      [C#]              Common/WPF
WPF User Control Library                          wpfusercontrollib        [C#]              Common/WPF
Windows Forms (WinForms) Application              winforms                 [C#]              Common/WinForms
Windows Forms (WinForms) Class library            winformslib              [C#]              Common/WinForms
Worker Service                                    worker                   [C#], F#          Common/Worker/Web
Unit Test Project                                 mstest                   [C#], F#, VB      Test/MSTest
NUnit 3 Test Project                              nunit                    [C#], F#, VB      Test/NUnit
NUnit 3 Test Item                                 nunit-test               [C#], F#, VB      Test/NUnit
xUnit Test Project                                xunit                    [C#], F#, VB      Test/xUnit
Razor Component                                   razorcomponent           [C#]              Web/ASP.NET
Razor Page                                        page                     [C#]              Web/ASP.NET
MVC ViewImports                                   viewimports              [C#]              Web/ASP.NET
MVC ViewStart                                     viewstart                [C#]              Web/ASP.NET
Blazor Server App                                 blazorserver             [C#]              Web/Blazor
Blazor WebAssembly App                            blazorwasm               [C#]              Web/Blazor/WebAssembly
ASP.NET Core Empty                                web                      [C#], F#          Web/Empty
ASP.NET Core Web App (Model-View-Controller)      mvc                      [C#], F#          Web/MVC
ASP.NET Core Web App                              webapp                   [C#]              Web/MVC/Razor Pages
ASP.NET Core with Angular                         angular                  [C#]              Web/MVC/SPA
ASP.NET Core with React.js                        react                    [C#]              Web/MVC/SPA
ASP.NET Core with React.js and Redux              reactredux               [C#]              Web/MVC/SPA
Razor Class Library                               razorclasslib            [C#]              Web/Razor/Library
ASP.NET Core Web API                              webapi                   [C#], F#          Web/WebAPI
ASP.NET Core gRPC Service                         grpc                     [C#]              Web/gRPC
dotnet gitignore file                             gitignore                                  Config
global.json file                                  globaljson                                 Config
NuGet Config                                      nugetconfig                                Config
Dotnet local tool manifest file                   tool-manifest                              Config
Web Config                                        webconfig                                  Config
Solution File                                     sln                                        Solution
Protocol Buffer File                              proto                                      Web/gRPC
```

The Console Application template can be used to quickly create a simple application that will greet you with a friendly "hello world" message.  Create a new application in a folder called `App1` with the following command:

```
dotnet new console -o App1
```

Enter the App1 folder and run the new application with this command:

```
dotnet run
```

### The project file

In .NET projects that are written with C#, our projects are defined by the presence of a `csproj` file.  Let's look at the content of the `App1.csproj` file that was created earlier:

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

</Project>
```

This XML-based file contains all of the information necessary to build an executable file using the .NET SDK.  Information will be added to this file to indicate how to interact with the source files in this project, the packages from NuGet (the .NET package repository), and the type of output this project should output.  There are many configuration options available for a project file, with [documentation available from Microsoft](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/web-deployment-in-the-enterprise/understanding-the-project-file).

The most common type of project that you will create is the `classlib` template that defines a class library.  A class library is a project that isn't directly executable but is a re-usable unit of code that can be packaged and referenced by many different projects and applications.  In this session, let's create a simple class library with some logic for managing a simple shopping cart, calculating totals, and applying coupon codes.  The final source code for the session can be found in [this folder](https://github.com/csharpfritz/csharp_with_csharpfritz/tree/main/sessions/0110-UnitTests).  let's start with a project called `Logic`:

```
dotnet new classlib -o Logic
```

We'll replace the Class1.cs file with information about a Product object called `Product.cs`:

```
using System;

namespace Logic

{

	public class Product
	{

		public int ProductId { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

	}

}
```




### The solution file

We can group together projects of various types
