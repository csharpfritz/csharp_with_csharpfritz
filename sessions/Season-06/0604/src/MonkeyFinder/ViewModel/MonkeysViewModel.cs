using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Networking;
using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel {

	public ObservableCollection<Monkey> Monkeys { get; } = new();

	MonkeyService monkeyService;
	private readonly IConnectivity _Connectivity;
	private readonly IGeolocation _Geolocation;

	public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation) {
		Title = "Monkey Finder";
		this.monkeyService = monkeyService;
		_Connectivity = connectivity;
		_Geolocation = geolocation;
	}

	[ObservableProperty]
	bool isRefreshing;

	[RelayCommand]
	async Task GetMonkeysAsync() {
		if (IsBusy)
			return;

		if (_Connectivity.NetworkAccess != NetworkAccess.Internet) {
			await Shell.Current.DisplayAlert("No connectivity!",
					$"Please check internet and try again.", "OK");
			return;
		}


		try {
			IsBusy = true;
			var monkeys = await monkeyService.GetMonkeys();

			if (Monkeys.Count != 0)
				Monkeys.Clear();

			foreach (var monkey in monkeys)
				Monkeys.Add(monkey);

		}
		catch (Exception ex) {
			Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
			await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
		}
		finally {
			IsBusy = false;
			IsRefreshing = false;
		}

	}

	[RelayCommand]
	async Task GoToDetails(Monkey monkey) {
		if (monkey == null)
			return;

		await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
		{
				{"Monkey", monkey }
		});
	}

	[RelayCommand]
	async Task GetClosestMonkey() {
		if (IsBusy || Monkeys.Count == 0)
			return;

		try {
			// Get cached location, else get real location.
			//var location = await _Geolocation.GetLastKnownLocationAsync();
			//if (location == null) {
				var location = await _Geolocation.GetLocationAsync(new GeolocationRequest {
					DesiredAccuracy = GeolocationAccuracy.Lowest,
					Timeout = TimeSpan.FromSeconds(30)
				});
			//}

			// Find closest monkey to us
			var first = Monkeys.OrderBy(m => location.CalculateDistance(
					new Location(m.Latitude, m.Longitude), DistanceUnits.Miles))
					.FirstOrDefault();

			await Shell.Current.DisplayAlert("", first.Name + " " +
					first.Location, "OK");

		}
		catch (Exception ex) {
			Debug.WriteLine($"Unable to query location: {ex.Message}");
			await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
		}
	}

}

