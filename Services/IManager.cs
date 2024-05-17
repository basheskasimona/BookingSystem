using MockBookingSystem.Models;

namespace MockBookingSystem.Services
{
   public interface IManager
    {
        Task<SearchRes> Search(SearchReq request);
        BookRes Book(BookReq request);
        CheckStatusRes CheckStatus(CheckStatusReq request);
    }

}
