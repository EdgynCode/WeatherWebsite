# WeatherWebsite

A web application for viewing current weather, 3-day forecasts, world time, and time zone conversions. Built with ASP.NET Core MVC and a separate ASP.NET Core Web API.

## Features

- View current weather and 3-day forecast for major cities
- Interactive world map to check local time anywhere
- Time zone conversion tool
- Responsive UI with Bootstrap
- Uses OpenWeatherMap API for weather data

## Project Structure

- `WeatherWebsite/` - Main ASP.NET Core MVC web application
- `WeatherWebsiteAPI/` - ASP.NET Core Web API project (template/sample)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (for WeatherWebsite)
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (for WeatherWebsiteAPI)
- [Node.js](https://nodejs.org/) (optional, for frontend assets)
- OpenWeatherMap API key

### Setup

1. **Clone the repository:**

   ```sh
   git clone <repo-url>
   cd WeatherWebsite
   ```

2. **Set up environment variables:**

   - Create a `.env` file in the `WeatherWebsite` directory:
     ```
     API_KEY=your_openweathermap_api_key
     ```

3. **Restore dependencies:**

   ```sh
   dotnet restore WeatherWebsite/WeatherWebsite.csproj
   dotnet restore WeatherWebsiteAPI/WeatherWebsiteAPI.csproj
   ```

4. **Run the application:**

   ```sh
   dotnet run --project WeatherWebsite/WeatherWebsite.csproj
   ```

   The app will be available at `https://localhost:7277` or `http://localhost:5071` by default.

### Docker

Both projects include Dockerfiles for containerized deployment. To build and run with Docker:

```sh
docker build -t weatherwebsite -f WeatherWebsite/Dockerfile WeatherWebsite
docker run -p 8080:80 weatherwebsite
```

## Usage

- **Weather Dashboard:** Select a city to view current weather and forecast.
- **World Time:** Click anywhere on the map to see the local time.
- **Time Conversion:** Convert date and time between any two time zones.

## Configuration

- Weather API key is required in the `.env` file.
- Additional configuration can be set in `appsettings.json`.

## License

This project is licensed under the MIT License.

---

**Note:** The `WeatherWebsiteAPI` project is a template/sample API and not used by the main web application by default.
