# Season 2 - Episode 1: Introducing Web Development with ASP.NET Core

.NET 6, and .NET Core before it was originally built to make cloud development of web applications easier and deliver the smallest and fastest web applications that take advantage of all the cloud technologies.  According to the [May 2020 Techempower benchmark](https://www.techempower.com/benchmarks/#section=data-r19&hw=ph&test=plaintext), ASP.NET Core is the fastest framework available:

![Benchmark results](./img/Techempower.png)

In this **Second Season** of CSharp with CSharpFritz, we're going to learn all about how to build web applications with ASP.NET Core and .NET 6.

### Assumptions

Starting with this season, we are going to assume that you've been through the first season and that you know the basics of working with C#.  Additionally, we're going to assume that you are familiar with the syntax of HTML and CSS.  We'll discuss web server architecture, but no previous web application development experience will be assumed.

## Tools Needed

To get started with ASP.NET Core, you can work on Windows, Mac, or Linux using your favorite text editor.  You can use a full development environment like Visual Studio 2019 on Windows, or something as simple as vim or emacs.

Get the .NET 6 SDK from [get.dot.net](https://get.dot.net)

## ASP.NET Core templates / project models

ASP.NET Core is a framework for building web applications that generate HTML, the document format that web browsers understand, on a server and delivering that HTML to the browser.  The framework is built on top of the .NET Framework, which is a cross-platform, open-source, and cross-platform development platform.

ASP.NET Core comes with a number of templates that you can use to get started with your web application.  These templates are called "project models".  You can use these templates to create a new project, or you can use them to start with a project that you already have.

Here are the templates that ship with ASP.NET Core in the .NET 6 SDK:

| Template Name | Short Name | Language |
| ------------- | ---------- | -------- |
| ASP.NET Core Empty | web | [C#],F# |
| ASP.NET Core gRPC Service | grpc | [C#] |
| ASP.NET Core Web API | webapi | [C#],F# |
| ASP.NET Core Web App | webapp,razor | [C#] |
| ASP.NET (Model-View-Controller)| mvc | [C#],F# |                              
| ASP.NET Core with Angular | angular | [C#] |         
| ASP.NET Core with React.js | react | [C#] |                        
| ASP.NET Core with React.js and Redux | reactredux | [C#] |

You can find these templates in Visual Studio in the File - New menu.  If you are working at the command-line outside of Visual Studio, you can use the `dotnet new` command to create a new project from one of these templates.

## Websites are console apps!

### Folder Structure

The default folder structure for Razor Pages is:

```
- Pages
|- Index.cshtml
|- Shared
- wwwroot
- MyApp.csproj
- Program.cs
```

The `MyApp.csproj` file contains the definition of the web project so that .NET knows how to compile and prepare the web server.  

The `wwwroot` folder contains the files that are served to the browser without interaction of the server.  The content of these files is simply read and delivered as requested.  You will find JavaScript, CSS, fonts, and images in the `wwwroot` folder.  

The `Pages` folder contains the Razor Pages that are interpreted and served to the browser.  Inside the `Pages` folder is a  `Shared` folder that contains the shared code that can used by all Razor Pages.  You'll find a shared layout in this folder by default.

### Program.cs

Program is a top-level file that, as of .NET 6, does not contain any C# classes or methods.  It is the entry point for your application.  It is the first file that is executed when the application starts.  It is the only file that is executed when you run the application.

Program.cs configures the web server, application services, and starts the web server.  At that point, control is handed over to the individual pages, controllers, and implemented code in the rest of your application.

### Startup.cs

In older versions of ASP.NET Core, Program.cs would start the web server and hand-off configuration of application services to a class named Startup.cs.  You can still use this architecture to configure your application with ASP.NET Core in .NET 6, but it is no longer the recommended approach.

## Razor Pages and Razor

In ASP.NET Core, we use a template language called Razor to define and format the HTML we will deliver to the browser.  The Razor templates are executed on the server when the content they define is requested and the output of the template is delivered to the browser.

In our first project template we will work with, we'll use Razor Pages to deliver HTML to the browser.  Razor Pages allow you to define interactions with the server as a Page or individual file that is requested by the browser.

### Introducing Razor Syntax

## Building and working with our application

If you are using Visual Studio 2022, you can use the `Start` button on the toolbar to start the web server.  This will start the web server and allow you to interact with the server.  You can use the `Stop` toolbar button to stop the web server.

If you are working with the application at the command-line, you can use the `dotnet run` command to start the web server.  This will start the web server and allow you to interact with the server.  You can also use the `dotnet watch` command to start the server and automatically patch content as you update it on the server.
