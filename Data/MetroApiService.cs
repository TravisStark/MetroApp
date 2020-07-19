using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MetroApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using AspNetMonsters.Blazor.Geolocation;
using Geolocation;
using Microsoft.Azure.Cosmos;

namespace MetroApp.Data
{
    public class MetroApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        private CosmosClient cosmosClient;

        // The database we will create
        private Database database;

        // The container we will create.
        private Container container;

        // The name of the database and container we will create
        private string databaseId = "MetroData";
        private string containerId = "RailStations";

        
        // public MetroApiService(IConfiguration config, IHttpClientFactory clientFactory)
        // {
        //     
        // }
        
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


        // public async Task<RailStations> UpdateStationsAsync()
        // {

        //     var config = _config;
        //     var client = _clientFactory.CreateClient();
        //     var baseUrl = config.GetValue<string>("BaseWmataUrl");
        //     var key = config.GetValue<string>("ApiKey");

        //     var stationsUrl = config.GetValue<string>("RailStationsUrl");

        //     var uriStations = new Uri($"{ baseUrl }/{ stationsUrl }?api_key={ key }");
        //     var uriTrains = new Uri($"{ baseUrl }{ config.GetValue<string>("WmataApi.TrainPositionsUrl") }&api_key={ key }");

        //     return await client.GetFromJsonAsync<RailStations>(uriStations);

        // }

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

            var stationsUrl = config.GetValue<string>("NextTrainsUrl");

            var uri = new Uri($"{ baseUrl }{ stationsUrl }{ stationCode }?api_key={ key }");

            var nextTrains = await client.GetFromJsonAsync<NextTrains>(uri);
            return nextTrains.Trains;
        }

        public Dictionary<double, Station> GetNearestStations(Location location)
        {
            var lat = (double)location.Latitude;
            var lon = (double)location.Longitude;
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                RailStations stations;
                stations = JsonSerializer.Deserialize<RailStations>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                var distances = new SortedDictionary<double, Station>();
                foreach(var station in stations.Stations)
                {
                    var distance = GeoCalculator.GetDistance(lat, lon, station.Lat, station.Lon);
                    if (!distances.ContainsKey(distance)){
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
