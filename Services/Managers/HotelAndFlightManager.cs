using MockBookingSystem.Models;
using System.Text.Json;

namespace MockBookingSystem.Services.Managers
{
    public class HotelAndFlightManager : ISearchManager
    {
        private readonly ISearchClient _searchClient;
        public HotelAndFlightManager(ISearchClient searchClient)
        {
            _searchClient = searchClient;
        }

        public async Task<SearchRes> Search(SearchReq request)
        {
            var hotels = await _searchClient.SearchHotelsAsync(request.Destination);
            var flights = await _searchClient.SearchFlightsAsync(request.DepartureAirport, request.Destination);

            var result = new List<Option>();
            var random = new Random();
            foreach (var flight in flights)
            {
                foreach (var hotel in hotels)
                {
                    result.Add(new Option
                    {
                        OptionCode = OptionCodeEnum.HotelAndFlight.ToString(),
                        ArrivalAirport = flight.ArrivalAirport,
                        FlightCode = flight.FlightCode,
                        HotelCode = hotel.HotelCode,
                        Price = random.NextDouble() * random.Next(10,25) // There is no price so random will be used
                    });
                }
            }
            return new SearchRes
            {
                Options = result
            };
        }
    }
}
