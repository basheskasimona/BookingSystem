using MockBookingSystem.Models;
using System.Text.Json;

namespace MockBookingSystem.Services.Managers
{
    public class HotelOnlyManager : ISearchManager
    {
        private readonly ISearchClient _searchClient;

        public HotelOnlyManager(ISearchClient searchClient)
        {
            _searchClient = searchClient;
        }

        public async Task<SearchRes> Search(SearchReq request)
        {
            var result = await _searchClient.SearchHotelsAsync(request.Destination);
            var random = new Random();

            var options = result.Select(hotel=> new Option
            {
                OptionCode = OptionCodeEnum.HotelOnly.ToString(),
                HotelCode = hotel.HotelCode,
                Price = random.NextDouble() * random.Next(5, 10)
            }).ToList();

            return new SearchRes
            {
                Options = options
            };
        }
    }
}
