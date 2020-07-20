using AspNetMonsters.Blazor.Geolocation;
using Geolocation;
using MetroApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetroApp.Data
{
    public class MetroApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public MetroApiService(
            IWebHostEnvironment webHostEnvironment,
            IConfiguration config,
            IHttpClientFactory clientFactory
            )
        {
            WebHostEnvironment = webHostEnvironment;
            _config = config;
            _clientFactory = clientFactory;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "StationList.json"); }
        }


        public async Task<IEnumerable<Station>> GetStationsAsync()
        {

            var config = _config;
            var client = _clientFactory.CreateClient();

            var baseUrl = config.GetValue<string>("BaseWmataUrl");
            var key = config.GetValue<string>("ApiKey");
            var stationsUrl = config.GetValue<string>("RailStationsUrl");
            var uriStations = new Uri($"{ baseUrl }/{ stationsUrl }?api_key={ key }");

            var stations = await client.GetFromJsonAsync<RailStations>(uriStations);

            return stations.Stations;
        }

        public IEnumerable<Station> GetRailStations()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                RailStations stations;
                stations = JsonSerializer.Deserialize<RailStations>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return stations.Stations.OrderBy(x => x.Name);
            }
        }

        public async Task<IEnumerable<Train>> GetNextTrainsAsync(string stationCode)
        {
            var config = _config;
            var client = _clientFactory.CreateClient();
            var baseUrl = config.GetValue<string>("BaseWmataUrl");
            var key = config.GetValue<string>("ApiKey");

            var nextTrainsUrl = config.GetValue<string>("NextTrainsUrl");

            var uri = new Uri($"{ baseUrl }{ nextTrainsUrl }{ stationCode }?api_key={ key }");

            var nextTrains = await client.GetFromJsonAsync<NextTrains>(uri);
            return nextTrains.Trains ?? Enumerable.Empty<Train>();
        }

        public Dictionary<double, Station> GetNearestStations(IEnumerable<Station> stations, Location location)
        {
            var lat = (double)location.Latitude;
            var lon = (double)location.Longitude;
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var distances = new SortedDictionary<double, Station>();
                foreach (var station in stations)
                {
                    var distance = GeoCalculator.GetDistance(lat, lon, station.Lat, station.Lon);
                    if (!distances.ContainsKey(distance))
                    {
                        distances.Add(distance, station);
                    }
                }

                return distances.OrderBy(x => x.Key).Take(5).ToDictionary(x => x.Key, x => x.Value);
            }
        }


        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // public
    }
}
