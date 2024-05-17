namespace MockBookingSystem.Services;

using MockBookingSystem.Models;
using System.Threading.Tasks;

public interface ISearchClient
{
    Task<List<Hotel>> SearchHotelsAsync(string destinationCode);
    Task<List<Flight>> SearchFlightsAsync(string departureAirport, string arrivalAirport);
}

