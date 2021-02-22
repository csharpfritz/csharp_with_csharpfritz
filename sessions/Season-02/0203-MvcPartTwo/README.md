# ASP.NET Core MVC - Part 2: Forms, Configuration, and Logging

In our [last session](../0202-ModelViewController/README.md) we covered the basics of ASP.NET Core MVC.  We learned how to use controllers, views, and models to present a simple website.  In this continuation of the topic of MVC, we will learn about working with forms, the Configuration Model, and logging.

## Interacting with Forms

HTML makes a series of user interface options available for the browser to send data to the server for processing.  The `<input>`, `<textarea>` and `<select>` tags provide the basics for our viewers to interact with, and can be created from our Views easily, but how do we configure a Controller with actions to receive this data?

Let's create a form to allow interaction with the server.  We'll use the [Post-Redirect-Get pattern](https://wikipedia.org/wiki/Post/Redirect/Get) to model our views and controller.

### Step 1: The Form

We can place a form on any View that is returned from our application, and use the standard HTML `<form>` tag to represent that interaction.  However, there are a few ways that we can create the form using ASP.NET resources that will make it more resilient to changes in our application.

For the first sample, let's use an HTML helper to post a simple search string to the application.

```razor
@using (Html.BeginForm()) {

    <div class="input-group">

    <input type="text" name="Search" class="form-control" placeholder="Search..." />
    <input type="submit" class="btn-primary" value="Go!" />

    </div>

}
```

### Step 2: The Actions

### Validation

ModelState / Validation - https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-5.0

## Configuration

IConfiguration

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0

