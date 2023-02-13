## Session 0602 : Overview and Displaying Data

Let's start by getting a basic overview of .NET MAUI and how projects are structured.

### Understanding the .NET MAUI single project

.NET Multi-platform App UI (.NET MAUI) single project takes the platform-specific development experiences you typically encounter while developing apps and abstracts them into a single shared project that can target Android, iOS, macOS, and Windows.

.NET MAUI single project provides a simplified and consistent cross-platform development experience, regardless of the platforms being targeted. .NET MAUI single project provides the following features:

- A single shared project that can target Android, iOS, macOS, and Windows.
- A simplified debug target selection for running your .NET MAUI apps.
- Shared resource files within the single project.
- Access to platform-specific APIs and tools when required.
- A single cross-platform app entry point.

.NET MAUI single project is enabled using multi-targeting and the use of SDK-style projects in .NET 6.

#### Resource files

Resource management for cross-platform app development has traditionally been problematic. Each platform has its own approach to managing resources, that must be implemented on each platform. For example, each platform has differing image requirements that typically involves creating multiple versions of each image at different resolutions. Therefore, a single image typically has to be duplicated multiple times per platform, at different resolutions, with the resulting images having to use different filename and folder conventions on each platform.

.NET MAUI single project enables resource files to be stored in a single location while being consumed on each platform. This includes fonts, images, the app icon, the splash screen, and raw assets.

> IMPORTANT:
> Each image resource file is used as a source image, from which images of the required resolutions are generated for each platform at build time.

Resource files should be placed in the _Resources_ folder of your .NET MAUI app project, or child folders of the _Resources_ folder, and must have their build action set correctly. The following table shows the build actions for each resource file type:

| Resource | Build action |
| -------- | ------------ |
| App icon | MauiIcon |
| Fonts | MauiFont |
| Images | MauiImage |
| Splash screen | MauiSplashScreen |
| Raw assets | MauiAsset |

<!--| CSS files | MauiCss | -->

> NOTE:
> XAML files are also stored in your .NET MAUI app project, and are automatically assigned the **MauiXaml** build action when created by project and item templates. However, XAML files will not typically be located in the _Resources_ folder of the app project.

When a resource file is added to a .NET MAUI app project, a corresponding entry for the resource is created in the project (.csproj) file. After adding a resource file, its build action can be set in the **Properties** window. The following screenshot shows a _Resources_ folder containing image and font resources in child folders:

![Image and font resources screenshot.](img/Resources.PNG)

Child folders of the _Resources_ folder can be designated for each resource type by editing the project file for your app:

```xml
<ItemGroup>
    <!-- Images -->
    <MauiImage Include="Resources\Images\*" />

    <!-- Fonts -->
    <MauiFont Include="Resources\Fonts\*" />

    <!-- Raw Assets (also remove the "Resources\Raw" prefix) -->
    <MauiAsset Include="Resources\Raw\**" LogicalName="%(RecursiveDir)%(Filename)%(Extension)" />
</ItemGroup>
```

The wildcard character (`*`) indicates that all the files within the folder will be treated as being of the specified resource type. In addition, it's possible to include all files from child folders:

```xml
<ItemGroup>
    <!-- Images -->
    <MauiImage Include="Resources\Images\**\*" />
</ItemGroup>
```

In this example, the double wildcard character ('**') specifies that the _Images_ folder can contain child folders. Therefore, `<MauiImage Include="Resources\Images\**\*" />` specifies that any files in the _Resources\Images_ folder, or any child folders of the _Images_ folder, will be used as source images from which images of the required resolution are generated for each platform.

Platform-specific resources will override their shared resource counterparts. For example, if you have an Android-specific image located at _Platforms\Android\Resources\drawable-xhdpi\logo.png_, and you also provide a shared _Resources\Images\logo.svg_ image, the Scalable Vector Graphics (SVG) file will be used to generate the required Android images, except for the XHDPI image that already exists as a platform-specific image.

### App icons

An app icon can be added to your app project by dragging an image into the _Resources\Images_ folder of the project, and setting the build action of the icon to **MauiIcon** in the **Properties** window. This creates a corresponding entry in your project file:

```xml
<MauiIcon Include="Resources\Images\appicon.png" />
```

At build time, the app icon is resized to the correct sizes for the target platform and device. The resized app icons are then added to your app package. App icons are resized to multiple resolutions because they have multiple uses, including being used to represent the app on the device, and in the app store.

#### Images

Images can be added to your app project by dragging them to the _Resources\Images_ folder of your project, and setting their build action to **MauiImage** in the **Properties** window. This creates a corresponding entry per image in your project file:

```xml
<MauiImage Include="Resources\Images\logo.jpg" />
```

At build time, images are resized to the correct resolutions for the target platform and device. The resized images are then added to your app package.

#### Fonts

True type format (TTF) and open type font (OTF) fonts can be added to your app project by dragging them into the _Resources\Fonts_ folder of your project, and setting their build action to **MauiFont** in the **Properties** window. This creates a corresponding entry per font in your project file:

```xml
<MauiFont Include="Resources\Fonts\OpenSans-Regular.ttf" />
```

At build time, the fonts are copied to your app package.

<!-- For more information, see [Fonts](~/user-interface/fonts.md). -->

#### Splash screen

A slash screen can be added to your app project by dragging an image into the _Resources\Images_ folder of your project, and setting the build action of the image to **MauiSplashScreen** in the **Properties** window. This creates a corresponding entry in your project file:

```xml
<MauiSplashScreen Include="Resources\Images\splashscreen.svg" />
```

At build time, the splash screen image is resized to the correct size for the target platform and device. The resized splash screen is then added to your app package.

#### Raw assets

Raw asset files, such as HTML, JSON, and videos, can be added to your app project by dragging them into the _Resources_ folder of your project (or a sub-folder, such as _Resources\Assets_), and setting their build action to `MauiAsset` in the **Properties** window. This creates a corresponding entry per asset in your project file:

```xml
<MauiAsset Include="Resources\Assets\index.html" />
```

Raw assets can then be consumed by controls, as required:

```xaml
<WebView Source="index.html" />
```

At build time, raw assets are copied to your app package.

### Understanding .NET MAUI app startup

.NET Multi-platform App UI (.NET MAUI) apps are bootstrapped using the .NET Generic Host model. This enables apps to be initialized from a single location, and provides the ability to configure fonts, services, and third-party libraries.

Each platform entry point calls a `CreateMauiApp` method on the static `MauiProgram` class that creates and returns a `MauiApp`, the entry point for your app.

The `MauiProgram` class must at a minimum provide an app to run:

```csharp
namespace MyMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        return builder.Build();
    }
}  
```

The `App` class derives from the `Application` class:

```csharp
namespace MyMauiApp;

public class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
```

#### Register fonts

Fonts can be added to your app and referenced by filename or alias. This is accomplished by invoking the `ConfigureFonts` method on the `MauiAppBuilder` object. Then, on the `IFontCollection` object, call the `AddFont` method to add the required font:

```csharp

namespace MyMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        return builder.Build();
    }
}
```

In the example above, the first argument to the `AddFont` method is the font filename, while the second argument represents an optional alias by which the font can be referenced when consuming it.

Any custom fonts consumed by an app must be included in your .csproj file. This can be accomplished by referencing their filenames, or by using a wildcard:

```xml
<ItemGroup>
   <MauiFont Include="Resources\Fonts\*" />
</ItemGroup>
```

> NOTE:
> Fonts added to the project through the Solution Explorer in Visual Studio will automatically be included in the .csproj file.

The font can then be consumed by referencing its name, without the file extension:

```xaml
<!-- Use font name -->
<Label Text="Hello .NET MAUI"
       FontFamily="OpenSans-Regular" />
```

Alternatively, it can be consumed by referencing its alias:

```xaml
<!-- Use font alias -->
<Label Text="Hello .NET MAUI"
       FontFamily="OpenSansRegular" />
```


## Displaying Data

Let's start coding and see how to display a list of data in a CollectionView.

### Open Solution in Visual Studio

This MonkeyFinder solution contains 1 project:

* MonkeyFinder - The main .NET MAUI project that targets Android, iOS, macOS, and Windows. It includes all scaffolding for the app including Models, Views, ViewModels, and Services.

The **MonkeyFinder** project also has blank code files and XAML pages that we will use during the workshop. 

### NuGet Restore

All projects have the required NuGet packages already installed, so there will be no need to install additional packages during the Hands on Lab. The first thing that we must do is restore all of the NuGet packages from the internet.

**Right-click** on the **Solution** and select **Restore NuGet packages...**

### The Shell

The [.NET MAUI Shell](https://learn.microsoft.com/dotnet/maui/fundamentals/shell) reduces the complexity of app development by providing the fundamental features that most apps require, including:

- A single place to describe the visual hierarchy of an app.
- A common navigation user experience.
- A URI-based navigation scheme that permits navigation to any page in the app.
- An integrated search handler.

In the sample code provided, the application is started with a root object in `App.xaml` that initializes the application and hands off controls to `AppShell.xaml` where the Shell is defined:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Shell xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MonkeyFinder.AppShell"
             xmlns:view="clr-namespace:MonkeyFinder.View"
             FlyoutBehavior="Disabled">

    <Shell.Resources>
        <ResourceDictionary>
            <Style x:Key="BaseStyle" TargetType="Element">
                <Setter Property="Shell.BackgroundColor" Value="{StaticResource Primary}" />
                <Setter Property="Shell.ForegroundColor" Value="{OnPlatform WinUI={StaticResource Primary}, Default=White}" />
                <Setter Property="Shell.TitleColor" Value="White" />
                <Setter Property="Shell.DisabledColor" Value="#B4FFFFFF" />
                <Setter Property="Shell.UnselectedColor" Value="{AppThemeBinding Dark=#95FFFFFF, Light=#95000000}" />
                <Setter Property="Shell.TabBarBackgroundColor" Value="{AppThemeBinding Dark={StaticResource DarkBackground}, Light={StaticResource LightBackground}}" />
                <Setter Property="Shell.TabBarForegroundColor" Value="{AppThemeBinding Dark={StaticResource LightBackground}, Light={StaticResource DarkBackground}}" />
                <Setter Property="Shell.TabBarUnselectedColor" Value="{AppThemeBinding Dark=#95FFFFFF, Light=#95000000}" />
                <Setter Property="Shell.TabBarTitleColor" Value="{AppThemeBinding Dark={StaticResource LightBackground}, Light={StaticResource DarkBackground}}" />
            </Style>
            <Style BasedOn="{StaticResource BaseStyle}" TargetType="ShellItem" ApplyToDerivedTypes="True" />
        </ResourceDictionary>
    </Shell.Resources>

    <ShellContent
        Shell.NavBarIsVisible="true"
        Title="Monkeys"
        ContentTemplate="{DataTemplate view:MainPage}"
        Route="MainPage" />

</Shell>
```

The shell defines the resources to be used in the application and the behavior of the navigation in the application.  The `Shell.Resources` markup defines the styles to be applied to the contents of the Shell.

The `ShellContent` element abstractly references the `MainPage` of our application using the `ContentTemplate` attribute and declaring that this content should be presented.  A Route is assigned as well, so that we can navigate around the application.

Check out the `Shell.NavBarIsVisible` attribute declaring that the navigation elements and title should be visible when the MainPage is displayed.

### Model

We will be downloading details about the monkey and will need a class to represent it.

We can easily convert our json file in our project at `Resources/Raw/monkeydata.json`  with the **Paste Special** feature in Visual Studio.  Copy the content of hte JSON file to your clipboard with Ctrl+C and select Edit - Paste Special - Paste JSON as Classes.  Eliminate the `RootObject` created by Visual Studio and rename the remaining class to `Monkey`

![Paste Special - Paste JSON as Classes menu](img/PasteSpecial.PNG)

If you aren't using Visual Studio, you can take these steps:

1. Open `Model/Monkey.cs`
2. In `Monkey.cs`, copy/paste the properties:

```csharp
public class Monkey
{        
    public string Name { get; set; } 
    public string Location { get; set; } 
    public string Details { get; set; } 
    public string Image { get; set; } 
    public int Population { get; set; } 
    public double Latitude { get; set; } 
    public double Longitude { get; set; } 
}
```

### Displaying Data

We can display hard coded data of any data type in a `CollectionView` in our `MainPage.xaml`. This will allow us to build out our user interface by setting the `ItemTemplate` with some simple images and labels. 

We first need to add a new namespace at the top of the `MainPage.xaml`:

```xml
xmlns:model="clr-namespace:MonkeyFinder.Model"
```

This will allow us to reference the Monkey class above for data binding purposes.

Add the following into the MainPage.xaml's `ContentPage`:

```xml
<CollectionView>
    <CollectionView.ItemsSource>
        <x:Array Type="{x:Type model:Monkey}">
            <model:Monkey
                Name="Baboon"
                Image="https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg"
                Location="Africa and Asia" />
            <model:Monkey
                Name="Capuchin Monkey"
                Image="https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg"
                Location="Central and South America" />
            <model:Monkey
                Name="Red-shanked douc"
                Image="https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg"
                Location="Vietnam" />
        </x:Array>
    </CollectionView.ItemsSource>
    <CollectionView.ItemTemplate>
        <DataTemplate x:DataType="model:Monkey">
            <HorizontalStackLayout Padding="10">
                <Image
                    Aspect="AspectFill"
                    HeightRequest="100"
                    Source="{Binding Image}"
                    WidthRequest="100" />
                <Label VerticalOptions="Center" TextColor="Gray">
                    <Label.Text>
                        <MultiBinding StringFormat="{}{0} | {1}">
                            <Binding Path="Name" />
                            <Binding Path="Location" />
                        </MultiBinding>
                    </Label.Text>
                </Label>
            </HorizontalStackLayout>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```



If we wanted to display the  two strings vertically on top of each other, we could wrap two `Label` controls inside of a `VerticalStackLayout` and assign font sizes to stand out:


```xml
 <HorizontalStackLayout Padding="10">
    <Image
        Aspect="AspectFill"
        HeightRequest="100"
        Source="{Binding Image}"
        WidthRequest="100" />
    <VerticalStackLayout VerticalOptions="Center">
        <Label Text="{Binding Name}" FontSize="24" TextColor="Gray"/>
        <Label Text="{Binding Location}" FontSize="18" TextColor="Gray"/>
    </VerticalStackLayout>
</HorizontalStackLayout>
```



### Run the App

Ensure that you have your machine setup to deploy and debug to the different platforms:

* [Android Emulator Setup](https://docs.microsoft.com/dotnet/maui/android/emulator/device-manager)
* [Windows setup for development](https://docs.microsoft.com/dotnet/maui/windows/setup)

1. In Visual Studio, set the Android or Windows app as the startup project by selecting the drop down in the debug menu and changing the `Framework`


![Visual Studio debug dropdown showing multiple frameworks](img/framework-selection.PNG)

2. In Visual Studio, click the "Debug" button or Tools -> Start Debugging
    - If you are having any trouble, see the Setup guides for your runtime platform

Running the app will result in a list of three monkeys:

![App running on Windows showing 3 monkeys](img/windows-app.PNG)
