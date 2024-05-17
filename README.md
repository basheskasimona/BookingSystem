#Travel Booking API

This project implements a simple booking system API for the travel industry. It allows users to search for holiday options, book them, and check the status of their bookings. The API is built using .NET 6 and Visual Studio.

#Requirments:

-Visual Studio

-.NET 6

-Internet access

-Postman

#Setup

1. Clone the repository
2. Open the solution in Visual Studio
3. Open the Postman
4. Build the solution to restore packages and dependencies
5. Run the project
6. Test the API endpoints using Postman as described in the [Usage]

#Usage

#Endpoints

1. Search

   -Method: GET
   
   -Endpoint: /api/Search/Search
   
   -Request Body:
   
	    {
	   
	    "Destination": "SKP",
	   
	    "DepartureAirport": "BCN",
	   
	    "FromDate": "2024-06-10T00:00:00",
	   
	    "ToDate": "2024-06-15T00:00:00"
	   
		}
 	-Response: Returns a list of holiday options.

2. Book

   -Method: POST
   
   -Endpoint: /api/Book/Book
   
   -Request Body:
   
	{
	
	 "optionCode": "LastMinuteHotels",
	   
		  "searchReq": {
	   
		    "destination": "SKP",
	   
		    "departureAirport": "BCN",
	   
		    "fromDate": "2024-06-10T00:00:00",
	   
		    "toDate": "2024-06-15T00:00:00"
	   
		  }
	   
}

-Response: Returns booking details.

3. CheckStatus

   -Method: GET
   
   -Endpoint: /api/CheckStatus/CheckStatus
   
   -Request Body:
   
	    {
	   
	    "BookingCode": "qTK3wu"
	   
		}
 	-Response: Returns the status of the booking.


#Authorization

Header authorization is implemented for enhanced security. Make sure to include the Authorization header in your requests.

Key: x-api-key

Value: ZNFYloswP0ZNFYloswP0


#Bonus Tasks

Global Exception Handling

Global exception handling is implemented to ensure that clients do not see detailed error messages.


#Header Authorization

Authorization headers are required for accessing the API endpoints.


Contributors

Simona Basheska
