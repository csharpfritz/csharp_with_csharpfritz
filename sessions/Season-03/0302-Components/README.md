# Session 0302 - Blazor Components

Blazor components are simply razor templates that you can reference by name as a tag inside of another component.

## Agenda

- Review the template
  - Survey component
  - Add the counter to the home page

## Question:  How do I create sub-folders for my Pages in Razor?

You can create and organize folders however you would like in your application's source files.  The `@page` directive controls the route location.

Check the `/Pages/Test/Page.razor` file in the demo. 

## Convention

All .razor files can be referenced as components in other templates.  Use the `/Components` folder to place those template files that do not include a `@page` directive and cannot be navigated to.

Add the `Components` folder's namespace to your `_Imports.razor` file to allow these components to be referenced elsewhere in your application:

```
@using demo.Components
```

## Parameters

The Parameter attribute allows us to add parameters to our components.  Let's start with a simple `Hat` component to present data about Fritz's hats.

## Child Content

## CSS Isolation

## Templates

## Libraries