# Session 10 - Projects, Solutions, and Unit Testing

We've learned a lot about how to use the C# language, but have not yet actually written a file to disk or built an application.  Starting with this session and going forward, we will be working outside the browser and .NET notebooks.  You can use the .NET SDK at the command-line, Visual Studio Code, Visual Studio for Mac, or Visual Studio 2019 among other IDEs and editors to build and interact with your .NET projects.

## The .NET SDK

The .NET SDK is the term we use to refer to the tools that you use to compile and build your applications.  You can get a copy of the tools you need from [https://get.dot.net](https://get.dot.net)  There are separate instructions available for use on Windows, Mac, or Linux.  Once installed, you will be able to work with the code that you write to build applications.

The SDK delivers a series of templates and tools that will help you with your .NET programming tasks.  The primary tool that you will be using is the `dotnet` command-line application.  You can verify that your installation procedure worked properly by executing the following at the command-line:

```console
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

```console
dotnet run
```

This command runs several steps back-to-back-to-back to run our new application:

1. Restores any references that our project needs to execute
1. The **C# Compiler** converts the project code, an action called **compiling**, into executable content that our computer can use.
1. Executes that resultant content

### The project file

In .NET projects that are written with C#, our projects are defined by the presence of a `csproj` file.  Let's look at the content of the `App1.csproj` file that was created earlier:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

</Project>
```

This XML-based file contains all of the information necessary to build an executable file using the .NET SDK.  Information will be added to this file to indicate how to interact with the source files in this project, the packages from NuGet (the .NET package repository), and the type of output this project should output.  There are many configuration options available for a project file, with [documentation available from Microsoft](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/web-deployment-in-the-enterprise/understanding-the-project-file).

The most common type of project that you will create is the `classlib` template that defines a class library.  A class library is a project that isn't directly executable but is a re-usable unit of code that can be packaged and referenced by many different projects and applications.  In this session, let's create a simple class library with some logic for managing a simple shopping cart, calculating totals, and applying coupon codes.  The final source code for the session can be found in [this folder](https://github.com/csharpfritz/csharp_with_csharpfritz/tree/main/sessions/0110-UnitTests).  let's start with a project called `Logic`:

```console
dotnet new classlib -o Logic
```

You'll note that the SDK created a first class file for us called `Class1.cs`.  All C# code files are identified with a `.cs` file extension. 

We'll replace the Class1.cs file with information about a Product object called `Product.cs`:

```csharp
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

We can then build our project, compiling it and turning into a referencable unit using the command:

```console
dotnet build
```

This action created a folder structure `bin/Debug/net5.0` with a `Logic.dll` file in it along with some other artifacts.  This DLL file is the unit that can be reused in other projects.  On Windows machines, you will find many hundreds if not thousands of DLL files that contain these binary formatted references that applications can use.

### Namespaces

In this file we see the introduction of a concept that had not appeared in our Jupyter notebooks to this point, the namespace.  A namespace is a logical grouping of classes, interfaces, enums, and other objects so that they can be easily located in the hierarchy of .NET objects.  The typical convention used by .NET developers is to have a project defined with a root namespace (`Logic` in this case) and each folder of code in the project is defined in a **child namespace**.  

For example, if we created a folder of code called `Accounting`, then the code files in that folder would be defined with a namespace statement `Logic.Accounting`.  To refer to objects from this namespace we can either provide their **fully qualified namespace** like `Logic.Accounting.CouponEvaluator` or we can add a **using statement** to the code file that indicates the namespace that should be considered by the compiler to look up and resolve those objects in our code file.

```csharp
using Logic.Accounting;
```

### The solution file

We can group together projects of various types to make a logical **Solution** with a solution file.  The solution file is used by editors like Visual Studio 2019, Visual Studio Code, and Visual Studio for Mac to help organize your projects.  In this folder, you can find the `0110-UnitTests.sln` file that contains information about the projects in our sample.

The solution file is typically stored in a folder _ABOVE_ the projects referenced in the solution.  In our case, the Logic and Test folders contain projects in the folders below the solution file.

The solution file is defined in a format specific to Visual Studio and it is recommended that you do not handle the file directly.  You can create a new solution file with the dotnet SDK:

```console
dotnet new sln
```

You can then add projects to it with this command:

```console
dotnet sln add Logic
```

## Other files for our Logic project

I have added files for an `Order`, `OrderItem`, and a `CouponEvaluator` class to the `Logic` project.  Take a moment to inspect them and add them to your project by copying them into your `Logic` project folder.

