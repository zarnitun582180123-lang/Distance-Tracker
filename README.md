# MapApp — Cross-Platform .NET MAUI Map & Distance Tracker

MapApp is a modern, cross-platform mobile and desktop application built using **.NET 8 MAUI**. It integrates native mapping capabilities to allow users to search for destinations worldwide, pinpoint locations on an interactive map, and automatically calculate the geodesic distance (in kilometers) from their current position to the target location.

## 🚀 Key Features

- **Interactive Native Map Integration:** Leverages `Microsoft.Maui.Controls.Maps` to display fast, hardware-accelerated maps natively on Android, iOS, and macOS.
- **Geocoding Location Search:** Includes a fully functional search bar that translates text queries (e.g., city names, landmarks) into precise geographic coordinates (Latitude & Longitude).
- **Real-Time Geolocation & Permissions:** Seamlessly requests runtime device location permissions and tracks the user's current GPS position.
- **Intelligent Distance Calculation:** Automatically calculates the straight-line distance between the user's live position and the searched destination in kilometers (`DistanceUnits.Kilometers`).
- **Dynamic Pin Marking:** Drops custom descriptive map pins displaying the location name and the computed distance info right on top of the map view.

## 🛠️ Tech Stack & Dependencies

- **Framework:** .NET MAUI (.NET 8.0)
- **Language:** C# / XAML
- **Target Platforms:** Android (API 21+), iOS (11.0+)
- **Core NuGet Package:** `Microsoft.Maui.Controls.Maps`

## 📂 Key Architecture Files

- `MauiProgram.cs`: Bootstrapper file where `.UseMauiMaps()` is initialized to handle device-specific map hooks.
- `MainPage.xaml`: Clean UI declaration with a top search bar layer stacked over the interactive full-screen Map element.
- `MainPage.xaml.cs`: Contains the core algorithmic logic handling `Geocoding.GetLocationsAsync()`, device location fetching, and proximity computing.

## ⚙️ Setup & Installation Instructions

### Prerequisites
- Visual Studio 2022 (with the **.NET Multi-platform App UI development** workload installed).
- Target device or emulator (Android Emulator or Physical Device).

### Running the Project

1. Clone the repository:
   ```bash
   git clone [https://github.com/zarnitun/MapApp.git](https://github.com/zarnitun/MapApp.git)
