using Microsoft.Extensions.Caching.Memory;
using MockBookingSystem.Middleware;
using MockBookingSystem.Models;
using MockBookingSystem.Services.Managers;
using System.ComponentModel.DataAnnotations;

namespace MockBookingSystem.Services
{
    public class Manager : IManager
    {
        private readonly ISearchManagerFactory _searchManagerFactory;
        private readonly ICodeGenerator _codegen;
        private readonly IMemoryCache _memoryCache;

        public Manager(ISearchManagerFactory searchManagerFactory, ICodeGenerator codegen, IMemoryCache memoryCache)
        {
            _searchManagerFactory = searchManagerFactory;
            _codegen = codegen;
            _memoryCache = memoryCache;
        }

        public async Task<SearchRes> Search(SearchReq request)
        {
            var manager = _searchManagerFactory.CreateManager(request);
            return await manager.Search(request);
        }

        public BookRes Book(BookReq request)
        {

            if (request.SearchReq.FromDate < DateTime.UtcNow)
            {
                throw new CustomValidationException("From date is less than today");
            }

            var code = _codegen.Generate();
            var bookingRequest = new Booking(request);

            _memoryCache.Set(code, bookingRequest);

            return new BookRes
            {
                BookingCode = code,
                BookingTime = bookingRequest.BookingTime
            };
        }

        public CheckStatusRes CheckStatus(CheckStatusReq request)
        {
            var found = _memoryCache.TryGetValue(request.BookingCode, out Booking? booking);

            if (booking == null || found == false)
                throw new Exception("Booking not found");

            var timePassed = booking.BookingTime.AddSeconds(booking.SleepTime) < DateTime.UtcNow;

            if (timePassed == false)
            {
                return new CheckStatusRes
                {
                    Status = BookingStatusEnum.Pending.ToString()
                };
            }
            return new CheckStatusRes
            {
                Status =  Enum.Parse<OptionCodeEnum>(booking.Request.OptionCode) == OptionCodeEnum.LastMinuteHotels ? BookingStatusEnum.Failed.ToString() : BookingStatusEnum.Success.ToString()
            };
        }
    }
}
