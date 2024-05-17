﻿namespace MockBookingSystem.Models
{
    public class Option
    {
        public string OptionCode { get; set; }
        public int HotelCode { get; set; }
        public int FlightCode { get; set; }
        public string ArrivalAirport { get; set; }
        public double Price { get; set; }
    }
}
