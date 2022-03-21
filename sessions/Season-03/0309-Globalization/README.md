# 0309 - Globalization and Localization in Blazor

How can we make our Blazor website appear correctly for folks in different cultures that read numbers, dates and times, and even different languages than what we are accustomed to?  This is the problem solved by the [globalization features in Blazor](https://docs.microsoft.com/aspnet/core/blazor/globalization-localization).

## Globalization

Globalization is the feature that Blazor uses to format numbers, dates and times.  Blazor can work off of the web standard Accept-Language header, interacting with the browser's configured preferences.  In applications that do NOT require globalization, you can add the following setting in the project file:

```xml
<PropertyGroup>
  <InvariantGlobalization>true</InvariantGlobalization>
</PropertyGroup>
```

In a Blazor WebAssembly app, we need to tell the project system to include globalization features by adding this block to the project file.

```xml
<PropertyGroup>
  <BlazorWebAssemblyLoadAllGlobalizationData>true</BlazorWebAssemblyLoadAllGlobalizationData>
</PropertyGroup>
```

We'll use the following component to test globalization features:

```html
@using System.Globalization

<h1>Culture Example 1</h1>

<p>
    <b>CurrentCulture</b>: @CultureInfo.CurrentCulture
</p>

<h2>Rendered values</h2>

<ul>
    <li><b>Date</b>: @dt</li>
    <li><b>Number</b>: @number.ToString("N2")</li>
</ul>

<h2><code>&lt;input&gt;</code> elements that don't set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.CurrentCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input @bind="number" /></label></li>
</ul>

<h2><code>&lt;input&gt;</code> elements that set a <code>type</code></h2>

<p>
    The following <code>&lt;input&gt;</code> elements use
    <code>CultureInfo.InvariantCulture</code>.
</p>

<ul>
    <li><label><b>Date:</b> <input type="date" @bind="dt" /></label></li>
    <li><label><b>Number:</b> <input type="number" @bind="number" /></label></li>
</ul>

@code {
    private DateTime dt = DateTime.Now;
    private double number = 1999.69;
}
```


## Localization with ASP.NET Core Resources

- Create a resource file and use IStringLocalizer&lt;ResourceFileBaseName&gt; to get the assets of that file
- See CultureExample.razor for example use 

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-6.0

In Blazor Web Assembly, you must add the Localization package with this command at the command-line:

```
dotnet add package Microsoft.Extensions.Localization
```

## Resources with Toolbelt.Blazor.I18nText

For a simpler approach to providing localized content, I recommend JSakamoto's Toolbelt i18nText package:

https://github.com/jsakamoto/Toolbelt.Blazor.I18nText

## Humanizer

I also recommend you check out Humanizer for formatting of relative dates and times using automatically translated terms.

https://github.com/Humanizr/Humanizer

Install it in your project with 

```
dotnet add package Humanizer
```