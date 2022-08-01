# Session 1207: Logging, Filters, and Unit Tests

We've built a site that lets users visit and browse through our collection, and viewers have had a few questions and requests for specific topics that are a little more advanced and not always needed in ASP.NET Core applications.  Let's take a look at those requests and discuss.

## Agenda

1. Our first request is from [SciGama to discuss logging capabilities](https://github.com/csharpfritz/csharp_with_csharpfritz/issues/123)
    1. [Logging in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/logging/) comes from a LoggerFactory with optional additional configuration.  Let's not get ahead of ourselves and start with adding some simple logging in our APIs.
    1. We create log entries with a Category that can be used later to filter so that we can capture and inspect our logs with appropriate sensitivity
    1. Logging is delivered as increasing severity status levels: 
        1. Trace
        1. Debug
        1. Information
        1. Warning
        1. Error
        1. Critical
    1. We can provide some [initial log filtering by severity and category in appsettings.json](https://docs.microsoft.com/aspnet/core/fundamentals/logging/#configure-logging)
    1. We can also configure different logging providers to capture our logs and ship them to other services for storage.
        1. Let's configure [Serilog](https://github.com/serilog/serilog-aspnetcore) a very popular open-source Logging package
1. The next question is from [sheridanchris and asks about creating filters in ASP.NET Core](https://github.com/csharpfritz/csharp_with_csharpfritz/issues/130)
    1. [Filters](https://docs.microsoft.com/aspnet/core/mvc/controllers/filters) are a way to inject processes that run before and/or after an event in the processing pipeline executes.
    1. A typical filter that you will see in use is the [Authorize filter](https://docs.microsoft.com/aspnet/core/security/authorization/simple?) to control access to resources or the [ResponseCache filter](https://docs.microsoft.com/aspnet/core/performance/caching/response?) to cache the output of an action.
    1. We can create our own [action filter attributes](https://docs.microsoft.com/aspnet/core/mvc/controllers/filters?#action-filters) by implementing the `IActionFilter` or `IActionFilterAsync` interface. 
    1. Filters can also be [applied globally](https://docs.microsoft.com/aspnet/core/mvc/controllers/filters?#filter-scopes-and-order-of-execution) to all actions and pages.
1. Our last request is from [Elelrlelr and asks about creating a test project](https://github.com/csharpfritz/csharp_with_csharpfritz/issues/132) to help our development process.
    1. Let's add a test project using xUnit and start writing some tests
    1. We'll test with the command-line `dotnet watch test` command