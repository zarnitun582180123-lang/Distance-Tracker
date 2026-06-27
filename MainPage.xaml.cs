using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Devices.Sensors;
using System.Diagnostics;

namespace MapApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await RequestLocationPermissionAsync();
    }

    private async Task RequestLocationPermissionAsync()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        if (status != PermissionStatus.Granted)
        {
            await DisplayAlert("Permission Denied", "Location access is required to use the map.", "OK");
        }
    }

    private async void OnSearchBarButtonPressed(object sender, EventArgs e)
    {
        string query = LocationSearchBar.Text;

        if (string.IsNullOrWhiteSpace(query))
        {
            await DisplayAlert("Invalid", "Please enter a location to search.", "OK");
            return;
        }

        try
        {
            var locations = await Geocoding.GetLocationsAsync(query);
            var destination = locations?.FirstOrDefault();

            if (destination != null)
            {
                var userLocation = await Geolocation.GetLocationAsync();

                if (userLocation == null)
                {
                    await DisplayAlert("Error", "Unable to get your current location.", "OK");
                    return;
                }

                double distanceKm = Location.CalculateDistance(
                    new Location(userLocation.Latitude, userLocation.Longitude),
                    new Location(destination.Latitude, destination.Longitude),
                    DistanceUnits.Kilometers);

                var destPosition = new Location(destination.Latitude, destination.Longitude);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(destPosition, Distance.FromKilometers(1)));

                MyMap.Pins.Clear();
                MyMap.Pins.Add(new Pin
                {
                    Label = $"{query} ({distanceKm:F2} km from you)",
                    Location = destPosition,
                    Type = PinType.Place
                });

                await DisplayAlert("Distance", $"Distance to {query}: {distanceKm:F2} km", "OK");
            }
            else
            {
                await DisplayAlert("Not Found", "No location found for your search.", "OK");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Search failed: {ex.Message}");
            await DisplayAlert("Error", "Something went wrong while searching.", "OK");
        }
    }
}
