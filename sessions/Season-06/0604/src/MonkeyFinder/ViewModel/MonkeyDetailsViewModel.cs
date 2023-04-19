using Microsoft.Maui.ApplicationModel;

namespace MonkeyFinder.ViewModel;

//Add QueryProperty
[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel {

	private readonly IMap _Map;

	public MonkeyDetailsViewModel(IMap map) {
		_Map = map;
	}

	[ObservableProperty]
	Monkey monkey;

	[RelayCommand]
	async Task OpenMap() {
		try {
			await _Map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions {
				Name = Monkey.Name,
				NavigationMode = NavigationMode.None
			});
		}
		catch (Exception ex) {
			Debug.WriteLine($"Unable to launch maps: {ex.Message}");
			await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
		}
	}

}