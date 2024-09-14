using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Services
{
    public class AuctionSvcHttpClient
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public AuctionSvcHttpClient(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        public async Task<List<Item>> GetItemsForSearchDb()
        {
            var lastUpdated = DB.Find<Item, string>()
                .Sort(x => x.Descending(i => i.UpdatedAt))
                .Project(x => x.UpdatedAt.ToString())
                .ExecuteFirstAsync();

            return await _http.GetFromJsonAsync<List<Item>>(_configuration["AuctionsServiceUrl"] + "/api/auctions");
            //return await _http.GetFromJsonAsync<List<Item>>(_configuration["AuctionsServiceUrl"] + "/api/auctions/date?" + lastUpdated);
        }
    }
}
