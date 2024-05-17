namespace MockBookingSystem.Models
{
    public class Booking
    {
        public Booking(BookReq request)
        {
            Request = request;
        }
        public int SleepTime { get; set; } = new Random().Next(30, 61);
        public DateTime BookingTime { get; set; } = DateTime.UtcNow;
        public BookReq Request { get; set; }
    }
}
