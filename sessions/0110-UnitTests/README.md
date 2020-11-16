# Session 10 - Projects, Solutions, and Unit Testing

We've learned a lot about how to use the C# language, but have not yet actually written a file to disk or built an application.  Starting with this session and going forward, we will be working outside the browser and .NET notebooks.  You can use the .NET SDK at the command-line, Visual Studio Code, Visual Studio for Mac, or Visual Studio 2019 among other IDEs and editors to build and interact with your .NET projects.

## The .NET SDK

The .NET SDK is the term we use to refer to the tools that you use to compile and build your applications.  You can get a copy of the tools you need from [https://get.dot.net](https://get.dot.net)  There are separate instructions available for use on Windows, Mac, or Linux.  Once installed, you will be able to work with the code that you write to build applications.

The SDK delivers a series of templates and tools that will help you with your .NET programming tasks.  The primary tool that you will be using is the `dotnet` command-line application.  You can verify that your installation procedure worked properly by executing the following at the command-line:

```dotnetcli
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

```dotnetcli
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

```dotnetcli
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

```dotnetcli
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

```dotnetcli
dotnet new sln
```

You can then add projects to it with this command:

```dotnetcli
dotnet sln add Logic
```

### Other files for our Logic project

I have added files for an `Order`, `OrderItem`, and a `CouponEvaluator` class to the `Logic` project.  Take a moment to inspect them and add them to your project by copying them into your `Logic` project folder.  Verify that everything is placed appropriately in your project by compiling the Logic class library again with this command:

```dotnetcli
dotnet build
```

The output should report no errors.

## Unit Tests

In software, there are many ways to write and automate tests for our applications.  We test in various scopes of the application from full system tests, to integration tests, to the smallest level - unit tests.  [Wikipedia defines unit testing](https://en.wikipedia.org/wiki/Unit_testing) as:

>    In computer programming, unit testing is a software testing method by which individual units of source code—sets of one or more computer program modules together with associated control data, usage procedures, and operating procedures—are tested to determine whether they are fit for use

To test our C# code, we can use several different test frameworks to build a **test project** that contains all of our tests.  Some of the most popular test frameworks available include:

- [MSTest](https://github.com/microsoft/testfx) - a test framework built by Microsoft and originally designed to be used with Visual Studio
- [NUnit](https://nunit.org) - a simple test framework that started as a port of the Java-based JUnit framework
- [xUnit](https://xunit.github.io/) - a test framework that grew out of NUnit to adhere more closely to the .NET conventions and typical developer usage.

Each of these frameworks ships a template project with the .NET SDK.  For this session, we will focus on xUnit, but all of the frameworks function similarly.

### Adding an xUnit test project to our solution

Let's create and add a new project called `Test` to the solution using the command line instructions:

```dotnetcli
dotnet new xunit -o Test
dotnet sln add Test
```

Our test project is now part of the solution, and we can build **BOTH** projects by running the `dotnet build` command in the same folder as the solution.  That doesn't add much value at this point, but is a starting point for us to reference later.

### Creating a reference between two projects in the same solution

Let's create a **reference** from the `Test` project to the `Logic` project so that we can start referring to objects in the `Logic` project in our `Test` project.  Execute the following code at the command-line in the `Test` project folder (replace slash appropriately for your operating system):

```dotnetcli
dotnet add reference ..\Logic
```

### Writing our first test

Let's start writing our first test and inspecting the `Logic` project.  The content of the default code file in our test project looks like the following:

```csharp
using System;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
```

A `[Fact]` is an attribute that defines a method inside of a class that xUnit should execute.  We can execute this method with this on the command-line:

```dotnetcli
dotnet test
```

The `dotnet test` method will do the following steps:

1. Restore any missing package references from NuGet
1. Compile the test project
1. Execute the xUnit Test Runner against the `Test` project 
1. Search for any methods decorated with attributes like `[Fact] that indicate they should be used for testing
1. Execute those identified methods
1. Report the results

The results from this first simple test should look like the following:

```
Microsoft (R) Test Execution Command Line Tool Version 16.8.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 1 ms - Test.dll (net5.0)
```

In 1ms of test time, we learned that all our test executed successfully.  We didn't test much, and in unit testing practices we try to make sure our tests FAIL first so that we know that they are actually testing something of value that we can fix.  Let's update that `Test1` method with this code:

```csharp
[Fact]
public void Test1()
{
  Assert.Equal(2,3);
}
```

Clearly, 2 does not equal 3... and we are using the xUnit `Assert` tool to investigate if these two values are equal.  When we execute our `dotnet test` command this time the following output is presented:

```
Microsoft (R) Test Execution Command Line Tool Version 16.8.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
[xUnit.net 00:00:00.45]     Test.UnitTest1.Test1 [FAIL]
  Failed Test.UnitTest1.Test1 [4 ms]
  Error Message:
   Assert.Equal() Failure
Expected: 2
Actual:   3
  Stack Trace:
     at Test.UnitTest1.Test1() in C:\dev\csharp_with_csharpfritz\sessions\0110-UnitTests\Test\UnitTest1.cs:line 11

Failed!  - Failed:     1, Passed:     0, Skipped:     0, Total:     1, Duration: 4 ms - Test.dll (net5.0)
```

Clearly a failure as expected and it reports which line the error occurred on as well as the value that was expected and the value that was presented.  This is a typical pattern you will find in unit testing:  `Assert(ValueExpected, ValueToInspect)`

### Re-running tests as code changes

Now that you've run your first test, you should see how painful this is going to be to run and re-run tests as you're writing code.  There are many different test runners that are embedded in our programming tools, and you can use them with great success.  The simplest automated test runner you can use is the `dotnet watch` command that will re-execute our tests whenever a file changes in the test project or the projects it references.

```dotnetcli
dotnet watch test
```

## Our first Logic test

Let's first inspect the Order object 

### Fixing the code

## Making Tests Better

There's a great article in the .NET docs about [unit testing best practices](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices) that we will summarize here as part of working on this test project.

- Fast
- Isolated
- Repeatable
 
### AAA Pattern in writing tests

Arrange

Assert

Act

### Naming Tests

- Name of method being tested
- Scenario of the test
- Expected behavior

"Given... When... Then" pattern 

### Setup and Teardown
