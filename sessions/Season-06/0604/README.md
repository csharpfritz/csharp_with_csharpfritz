## Session 0604 : Platform Features and Themes

Our application is running on a modern operating system on a phone or desktop and should be able to access the features made available on that system.  In this first part, we will access the map feature to display a monkey's location

### Check for internet

We can easily check to see if our user is connected to the internet with the built in `IConnectivity` of .NET MAUI

1. First, let's get access to the `IConnectivity` found inside of .NET MAUI. Let's inject `IConnectivity` into our `MonkeysViewModel` constructor:

    ```csharp
    IConnectivity connectivity;
    public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
    }
    ```

1. Register the `Connectivity.Current` in our `MauiProgram.cs`.


1. While we are here let's add both `IGeolocation` and `IMap`, add the code:

    ```csharp
    builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
    builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
    builder.Services.AddSingleton<IMap>(Map.Default);
    ```

1. Now, let's check for internet inside of the `GetMonkeysAsync` method and display an alert if offline.

    ```csharp
    if (connectivity.NetworkAccess != NetworkAccess.Internet)
    {
        await Shell.Current.DisplayAlert("No connectivity!",
            $"Please check internet and try again.", "OK");
        return;
    }
    ```

    Run the app on your emulator and toggle on and off airplane mode to check your implementation.


### Find Closest Monkey!

We can add more functionality to this page using the GPS of the device since each monkey has a latitude and longitude associated with it.

1. First, let's get access to the `IGeolocator` found inside of .NET MAUI. Let's inject `IGeolocator` into our `MonkeysViewModel` constructor:

    ```csharp
    IConnectivity connectivity;
    IGeolocation geolocation;
    public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }
    ```


1. In our `MonkeysViewModel.cs`, let's create another method called `GetClosestMonkey`:

    ```csharp
    [RelayCommand]
    async Task GetClosestMonkey()
    {

    }
    ```

1. We can then fill it in by using .NET MAUI  to query for our location and helpers that find the closest monkey to us:

    ```csharp
    [RelayCommand]
    async Task GetClosestMonkey()
    {
        if (IsBusy || Monkeys.Count == 0)
            return;

        try
        {
            // Get cached location, else get real location.
            var location = await geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }

            // Find closest monkey to us
            var first = Monkeys.OrderBy(m => location.CalculateDistance(
                new Location(m.Latitude, m.Longitude), DistanceUnits.Miles))
                .FirstOrDefault();

            await Shell.Current.DisplayAlert("", first.Name + " " +
                first.Location, "OK");

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to query location: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }
    ```


1. Back in our `MainPage.xaml` we can add another `Button` that will call this new method:

    Add the following XAML under the Search button.

    ```xml
    <Button Text="Find Closest" 
        Command="{Binding GetClosestMonkeyCommand}"
        IsEnabled="{Binding IsNotBusy}"
        Grid.Row="1"
        Grid.Column="1"
        Style="{StaticResource ButtonOutline}"
        Margin="8"/>
    ```

Re-run the app to see geolocation in action after you load monkeys!

This project is pre-configured with all required permissions and features needed for Geolocation. You can read the documentation to find out more about setup, but here is a quick overview.

1. .NET MAUI is pre-configured in all .NET MAUI applications including handling permissions.
1. Android manifest information was pre-configured in **MonkeyFinder -> Platforms -> Android -> AssemblyInfo.cs**
1. iOS/macOS manifest information was configured in the **info.plist** file for each platform
1. Windows manifest information was configured in the **Package.appxmanifest**

### Opening Maps

.NET MAUI provides over 60 platform features from a single API and opening the default map application is built in!

1. Inject `IMap` into our `MonkeyDetailsViewModel`:

    ```csharp
    IMap map;
    public MonkeyDetailsViewModel(IMap map)
    {
        this.map = map;
    }
    ```

1. Open the `MonkeyDetailsViewModel.cs` file and add a method called `OpenMap` that calls into the `Map` API passing it the monkey's location:

    ```csharp
    [RelayCommand]
    async Task OpenMap()
    {
        try
        {
            await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
            {
                Name = Monkey.Name,
                NavigationMode = NavigationMode.None
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to launch maps: {ex.Message}");
            await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        }
    }

    ```

### Update DetailsPage.xaml UI


Above the monkey's name, let's add a button that calls the `OpenMapCommand`.

```xml
<Button Text="Show on Map" 
        Command="{Binding OpenMapCommand}"
        HorizontalOptions="Center" 
        WidthRequest="200" 
        Margin="8"
        Style="{StaticResource ButtonOutline}"/>
                
<Label Style="{StaticResource MediumLabel}" Text="{Binding Monkey.Details}" />
```

Run the application, navigate to a monkey, and then press Show on Map to launch the map app on the specific platform.


## iOS Safe Area Layouts

In addition to accessing cross-platform device APIs, .NET MAUI also includes platform specific integrations. If you have been running the Monkey Finder app on an iOS device with a notch, you may have noticed that the buttons on the bottom overlap the bar on the bottom of the device. iOS has the concept of Safe Areas and you must progmatically set this. However, thanks to platform specifics, you can set them directly in the XAML.

1. Open `MainPage.xaml` and add a new namespace for iOS specifics:

    ```xml
    xmlns:ios="clr-namespace:Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;assembly=Microsoft.Maui.Controls"
    ```

1. On the `ContentPage` node, you can now set the following property:

    ```xml
    ios:Page.UseSafeArea="True"
    ```

Re-run the application on an iOS simulator or device and notice the buttons have automatically been shifted up.

## Adding Pull-to-Refresh

The .NET MAUI `ListView` has built in support for pull-to-refresh, however a `RefreshView` enables developers to add pull-to-refresh to other controls such as `ScrollView` & `CollectionView`. 

Let's add the new `RefreshView` to add pull-to-refresh to our `CollectionView`.

Update the `CollectionView` logic by wrapping it with a `RefreshView` from:

```xml
<CollectionView
    Grid.ColumnSpan="2"
    ItemsSource="{Binding Monkeys}"
    SelectionMode="None">
    <!-- Template -->
</CollectionView>
```

to:

```xml
<RefreshView
    Grid.ColumnSpan="2"
    Command="{Binding GetMonkeysCommand}"
    IsRefreshing="{Binding IsRefreshing}">
    <ContentView>
        <CollectionView
            ItemsSource="{Binding Monkeys}"
            SelectionMode="None">
            <!-- Template -->
        </CollectionView>
    </ContentView>
</RefreshView>
```

Notice that we moved the `Grid.ColumnSpan="2"` to the `RefreshView` since it is the new parent view in the `Grid`.

Since the user can initiate a refresh, we will want to create a new variable in our code behind to bind to stop refreshing when we are done.

1. Open `MonkeysViewModel.cs` and add a new property:

    ```csharp
    [ObservableProperty]
    bool isRefreshing;
    ```

1. In the `finally` of the `GetMonkeysAsync` set `IsRefreshing` to `false`:

    ```csharp
    finally
    {
        IsBusy = false;
        IsRefreshing = false;
    }
    ```

This will enable pull-to-refresh on iOS, Android, macOS, and Windows (on touch screen):

![Android emulator with pull to refresh enabled](src/PullToRefresh.PNG)

> Important Note: If you are on iOS there currently is a bug which makes the UI look incorrect. It is recommended to remove the RefreshView when testing on iOS for the rest of the workshop.

## Layout

`CollectionView` will automatically layout items in a vertical stack layout. There are several built in `ItemsLayout` that can be used. Let's explore.

### LinearItemsLayout 

This is the default layout that can display items in either vertical or horizontal orientations. You can set the `ItemsLayout` property to `VerticalList` or `HorizontalList`. 

To access additional properties on the `LinearItemsLayout` we will need to set a sub-property:

```xml
<CollectionView
    ItemsSource="{Binding Monkeys}"
    SelectionMode="None">
    <!-- Add ItemsLayout -->
    <CollectionView.ItemsLayout>
        <LinearItemsLayout Orientation="Vertical" />
    </CollectionView.ItemsLayout>
    <!-- ItemTemplate -->
</CollectionView>
```

### GridItemsLayout

More interesting is the ability to use `GridItemsLayout` that automatically spaces out items with different spans.  

Let's use the `GridItemsLayout` and change the span to 3 

```xml
<CollectionView
    ItemsSource="{Binding Monkeys}"
    SelectionMode="None">
    <!-- Change ItemsLayout to GridItemsLayout-->
    <CollectionView.ItemsLayout>
        <GridItemsLayout Orientation="Vertical" Span="3" />
    </CollectionView.ItemsLayout>
    <!-- ItemTemplate -->
</CollectionView>
```

![Monkeys in a grid with 3 columns](img/GridItemsLayoutVert.png)

We can change the `Orientation` to `Horizontal` and now our CollectionView will scroll left to right!

```xml
<CollectionView.ItemsLayout>
    <GridItemsLayout Orientation="Horizontal" Span="5" />
</CollectionView.ItemsLayout>
```

![List of monkeys scrolling left to right](img/GridItemsLayoutHorizontal.png)

Let's go back to our original single column `CollectionView`:

```xml
<CollectionView.ItemsLayout>
    <LinearItemsLayout Orientation="Vertical" />
</CollectionView.ItemsLayout>
```

## EmptyView

> Important Note: There is currently an issue on Android in which the EmptyView will not go away. It is recommended to remove it when testing on Android at this time.

There are many neat features to `CollectionView` including grouping, header, footers, and the ability to set a view that is displayed when there are no items.

Let's add an image centered in the `EmptyView`:

```xml
<CollectionView
    ItemsSource="{Binding Monkeys}"
    SelectionMode="None">
    <!-- Add EmptyView -->
    <CollectionView.EmptyView>
        <StackLayout Padding="100">
            <Image
                HorizontalOptions="Center"
                Source="nodata.png"
                HeightRequest="160"
                WidthRequest="160"
                VerticalOptions="Center" />
        </StackLayout>
    </CollectionView.EmptyView>
    <!-- ItemTemplate & ItemsLayout-->
</CollectionView>
```


![Emulator without any items in it showing an image in the middle](img/EmptyView.png)

## App Themes

Up to this point, we have used a standard light theme on the application. .NET MAUI has the concept of reusable Application Resources and resources that can automatically adapt to the theme of the device. 

## Reusable Resources

Open the `App.xaml` file and notice that there are several `Color` entries and `Styles`. These were configured ahead of time for some basic colors and styles that we used throughout the application. For example, we have defined a light color for the main background color:

```xml
<Color x:Key="LightBackground">#FAF9F8</Color>
```

It can be referenced later by any UI element or by a shared style that can be reused. For example our `ButtonOutline` style applies to the `Button` control and gives it a rounded corner, sets colors for the text, border, and background:

```xml
<Style x:Key="ButtonOutline" TargetType="Button">
    <Setter Property="Background" Value="{StaticResource LightBackground}" />
    <Setter Property="TextColor" Value="{StaticResource Primary}" />
    <Setter Property="BorderColor" Value="{StaticResource Primary}" />
    <Setter Property="BorderWidth" Value="2" />
    <Setter Property="HeightRequest" Value="40" />
    <Setter Property="CornerRadius" Value="20" />
</Style>
```

This is a great way to share code across your entire application. 

## Theme Changes - Light/Dark Theme

What happens when you want to respond to the user changing their device to use dark mode? Well, .NET MAUI has the concept of  an `AppThemeBinding` for values. Let's take a `Label`'s `TextColor` property. We can define two new colors to use:

```xml
<Color x:Key="LabelText">Black</Color>
<Color x:Key="LabelTextDark">White</Color>
```

We would want the text to be Black when the background color is light, and White when the background color is dark. Normally, we would set the color to a single color such as:

```xml
<Label Text="Hello, world!" TextColor="{StaticResource LabelText}"/>
```

However, this will not adjust to app theme changes. We could make it a `DynamicResource`, listen for app theme changes, and update the `LabelText` value, or we can use an `AppThemeBinding`:

```xml
<Label Text="Hello, world!" 
       TextColor="{AppThemeBinding Light={StaticResource LabelText}, Dark={StaticResource LabelTextDark}}"/>
```

We now have the option of creating a re-usable style that we reference by name or a style that applies to every element of a specific type:

```xml
<Style TargetType="Label" x:Key="DefaultLabel">
    <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource LabelText}, Dark={StaticResource LabelTextDark}}" />
</Style>
```

```xml
<Label Text="Hello, world!" 
       Style="{StaticResource DefaultLabel}"/>
```

If we leave out the `x:Key`, then it will apply automatically to every `Label` in our app.

```xml
<Style TargetType="Label">
    <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource LabelText}, Dark={StaticResource LabelTextDark}}" />
</Style>
```

## Update Resources

Now, let's add in light/dark theme support throughout our entire application.


1. Let's add some new colors we will use into our `ResourceDictionary`:

    ```xml
    <Color x:Key="CardBackground">White</Color>
    <Color x:Key="CardBackgroundDark">#1C1C1E</Color>

    <Color x:Key="LabelText">#1F1F1F</Color>
    <Color x:Key="LabelTextDark">White</Color>
    ```

1. Let's update background colors on pages from:

    ```xml
    <Style ApplyToDerivedTypes="True" TargetType="Page">
        <Setter Property="BackgroundColor" Value="{StaticResource LightBackground}" />
    </Style>
    ```

    to:

    ```xml
    <Style ApplyToDerivedTypes="True" TargetType="Page">
        <Setter Property="BackgroundColor" Value="{AppThemeBinding Light={StaticResource LightBackground}, Dark={StaticResource DarkBackground}}" />
    </Style>
    ```


1. Update the `BaseLabel`'s `TextColor` value:

    ```xml
    <Setter Property="TextColor" Value="{AppThemeBinding Light={StaticResource LabelText}, Dark={StaticResource LabelTextDark}}" />
    ```

1. Add the `Background` on our `RefreshView`

    ```xml
    <Style ApplyToDerivedTypes="True" TargetType="RefreshView">
        <Setter Property="RefreshColor" Value="{StaticResource Primary}" />
        <!--Add this-->
        <Setter Property="Background" Value="{AppThemeBinding Light={StaticResource LightBackground}, Dark={StaticResource DarkBackground}}" />
    </Style>
    ```

1. Update the `Background` on the `ButtonOutline`

    ```xml
    <Setter Property="Background" Value="{AppThemeBinding Light={StaticResource LightBackground}, Dark={StaticResource DarkBackground}}" />
    ```

1. Update the `Background` on the `CardView`

    ```xml
    <Setter Property="Background" Value="{AppThemeBinding Light={StaticResource CardBackground}, Dark={StaticResource CardBackgroundDark}}" />
    ```

Now, let's run the app and change the theme:

![Changing themes](img/Themes.gif)


You did it! Congratulations! You built your first .NET MAUI application, loaded data from the internet, implemented navigation, added platform features, and themed the app!

