# Session 10 - Projects, Solutions, and Unit Testing

We've learned a lot about how to use the C# language, but have not yet actually written a file to disk or built an application.  Starting with this session and going fowrard, we will be working outside the browser and .NET notebooks.  You can use the .NET SDK at the command-line, Visual Studio Code, Visual Studio for Mac, or Visual Studio 2019 among other IDEs and editors to build and interact with your .NET projects.

## The .NET SDK

The .NET SDK is the term we use to refer to the tools that you use to compile and build your applications.  You can get a copy of the tools you need from [https://get.dot.net](https://get.dot.net)  There are separate instructions available for use on Windows, Mac, or Linux.  Once installed, you will be able to work with the code that you write to build applications.

The SDK delivers a series of templates and tools that will help you with your .NET programming tasks.  The primary tool that you will be using is the `dotnet` command-line application.  You can verify that your installation procedure worked properly by executing the following at the command-line:

```
dotnet --info
```

A **project** is a unit of application code that can either represent the user-interface of an application, the server component of an application, or a re-usable component of a project.  We can create projects using the `dotnet new` command.
