namespace MockBookingSystem.Models
{
    public class CheckStatusRes
    {
        public string Status { get; set; }
    }

    public enum BookingStatusEnum
    {
        Success,
        Failed,
        Pending
    }
}
