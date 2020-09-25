# HolidayMaker

Holiday Maker is a desktop application for Windows that talks with a backend service. You can search and book rooms in hotels in various parts of Sweden. It's supposed to mimic an AirBnB app, but we chose to implement this as a main hotel search feature.

## Rest specification

### Regions

`GET api/regions`  
`GET api/regions/{id}`  
`PUT api/regions/{id}/{region}`  
`POST api/regions/{region}`  
`DELETE api/regions/{id}`

### Cities

`GET api/cities`  
`GET api/cities/{id}`  
`PUT api/cities/{id}/{city}`  
`POST api/cities/{city}`  
`DELETE api/cities/{id}`

### Hotels

`GET api/hotels`  
`GET api/hotels/{id}`  
`PUT api/hotels/{id}/{city}`  
`POST api/hotels/{city}`  
`DELETE api/hotels/{id}`

### Rooms

`GET api/rooms`  
`GET api/rooms/{id}`  
`PUT api/rooms/{id}/{city}`  
`POST api/rooms/{city}`  
`DELETE api/rooms/{id}`

### Users

`GET api/users`  
`GET api/users/{id}`  
`PUT api/users/{id}/{city}`  
`POST api/users/{city}`  
`DELETE api/users/{id}`

### Bookings

`GET api/bookings`  
`GET api/bookings/{id}`  
`PUT api/bookings/{id}/{city}`  
`POST api/bookings/{city}`  
`DELETE api/bookings/{id}`


## Getting started

1. Open `HolidayMakerBackend.sln` in Visual Studio and press run. 
2. Run `Update-Database` in Package Manager Console.
3. Press Run in Visual Studio and now the backend is running.
4. Open a new Visual Studio instance and select the client project `HolidayMakerUWP`.
5. Press Run in Visual Studio and now the frontend is running.


