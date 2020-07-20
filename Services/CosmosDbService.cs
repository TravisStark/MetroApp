using MetroApp.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroApp.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName
            )
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        //public async Task AddItemAsync(Item item)
        //{
        //    await this._container.CreateItemAsync<Item>(item, new PartitionKey(item.Id));
        //}

        //public async Task DeleteItemAsync(string id)
        //{
        //    await this._container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        //}

        //public async Task<Item> GetStationAsync(string id)
        //{
        //    try
        //    {
        //        ItemResponse<Item> response = await this._container.ReadItemAsync<Item>(id, new PartitionKey(id));
        //        return response.Resource;
        //    }
        //    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        return null;
        //    }

        //}

        public async Task<IEnumerable<Station>> GetStationsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Station>(new QueryDefinition(queryString));
            var results = new List<Station>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results.OrderBy(x => x.Name);
        }

        //public async Task AddItemAsync(Item item)
        //{
        //    await this._container.CreateItemAsync<Item>(item, new PartitionKey(item.Id));
        //}

        public async Task AddStationsAsync(IEnumerable<Station> stations)
        {
            foreach (var station in stations.Distinct())
            {
                await this._container.UpsertItemAsync<Station>(station, new PartitionKey(station.Name));
            }
        }
    }
}
