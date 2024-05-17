using MockBookingSystem.Models;

namespace MockBookingSystem.Services
{
    public interface ISearchManager
    {
        Task<SearchRes> Search(SearchReq request);
    }
}
