# Session 0308 - Hosting and Deployment

Your Blazor app is built, what now?  Where do we put it so the world can participate in your cool application?  Let's break it down

## Blazor Static Websites

### Blazor WebAssembly and PWA

Get started with a PWA at the command-line using:

```
dotnet new blazorwasm -o MyProjectName -p true
```

### Blazor Static with Azure

Start with the repository at: https://github.com/staticwebdev/blazor-starter

## Hosted Blazor with ASP.NET Core

Create a Blazor Web Assembly application that is hosted on an ASP.NET Core service using:

```
dotnet new blazorwasm -o MyProjectName -ho true
```

This is where you want to start if you want to build applications that are hosted and running web assembly with search engine optimization.  The application can be prerendered on the server so that folks get an initial rendering, and then the web assembly application takes over and starts running in the browser.

### Prerendering configuration

Make the changes shown on:  https://docs.microsoft.com/aspnet/core/blazor/components/prerendering-and-integration

## Docker

All Blazor applications can be installed and run great in Docker containers based on Linux images. 

Visual Studio has a great tool available to add Docker support for a Blazor application.  With Visual Studio, you can also build and develop inside the docker container as well as publish the container directly to Azure Docker Container registry and start up a container on Azure App Service.

Chris Sainty has a nice set of instructions if you want to get your application running in Docker by hand:  https://chrissainty.com/containerising-blazor-applications-with-docker-containerising-a-blazor-webassembly-app/