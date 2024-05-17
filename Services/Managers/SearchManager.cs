using MockBookingSystem.Middleware;
using MockBookingSystem.Models;

namespace MockBookingSystem.Services.Managers
{
    public interface ISearchManagerFactory
    {
        ISearchManager CreateManager(SearchReq req);
    }
    public class SearchManagerFactory : ISearchManagerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchManagerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISearchManager CreateManager(SearchReq request)
        {

            if (request.FromDate < DateTime.Now || request.ToDate < DateTime.Now)
            {
                throw new CustomValidationException("Not valid request from or to date are in the past");
            }

            if (request.FromDate < DateTime.UtcNow.AddDays(45))
            {
                return CreateManager(typeof(LastMinuteHotelsManager), request);

            }

            if (String.IsNullOrEmpty(request.DepartureAirport))
            {
                return  CreateManager(typeof(HotelOnlyManager), request);
            }


            if (!string.IsNullOrEmpty(request.DepartureAirport))
            {
                return  CreateManager(typeof(HotelAndFlightManager), request);
            }

            throw new Exception("Invalid request");
        }

        private ISearchManager CreateManager(Type type, SearchReq searchReq)
        {
            var service = _serviceProvider.GetServices<ISearchManager>().FirstOrDefault(f => f.GetType() == type);
            return service == null ? throw new Exception("Service not found") : service;
        }
    }
}
