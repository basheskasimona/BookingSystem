using MockBookingSystem.Models;
using MockBookingSystem.Services;
using System.Text.Json;


public class SearchClient : ISearchClient
{
    private readonly HttpClient _httpClient;

    public SearchClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Hotel>> SearchHotelsAsync(string destinationCode)
    {
        var response = await _httpClient.GetAsync($"/api/SearchHotels?destinationCode={destinationCode}");
        response.EnsureSuccessStatusCode();
        var result =  await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Hotel>>(result);
    }

    public async Task<List<Flight>> SearchFlightsAsync(string departureAirport, string arrivalAirport)
    {
        var response = await _httpClient.GetAsync($"/api/SearchFlights?departureAirport={departureAirport}&arrivalAirport={arrivalAirport}");
        response.EnsureSuccessStatusCode();
        var result =  await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Flight>>(result);

    }
}

