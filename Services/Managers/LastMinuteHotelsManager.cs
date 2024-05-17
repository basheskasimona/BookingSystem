using MockBookingSystem.Models;

namespace MockBookingSystem.Services.Managers
{
    public class LastMinuteHotelsManager : ISearchManager
    {
        private readonly ISearchClient _searchClient;

        public LastMinuteHotelsManager(ISearchClient searchClient)
        {
            _searchClient = searchClient;
        }

        public async Task<SearchRes> Search(SearchReq request)
        {
            var result = await _searchClient.SearchHotelsAsync(request.Destination);
            var random = new Random();

            var options = result.Select(hotel => new Option
            {
                OptionCode = OptionCodeEnum.LastMinuteHotels.ToString(),
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
