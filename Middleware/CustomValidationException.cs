namespace MockBookingSystem.Middleware
{
    public class CustomValidationException : Exception
    {
        // Custom constructor
        public CustomValidationException(string message) : base("Request is not valid validation error:" + message)
        {
        }
    }
}
