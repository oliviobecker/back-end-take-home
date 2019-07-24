How to run

It's an API .Net Core C#

Can be started with visual studio, deploying to IIS or by command line with the .NET CLI

To run via CLI execute the following command with the prompt (after installing .NET CLI):

dotnet run --project ./solution/GuestLogix.Flights.API/GuestLogix.Flights.API/GuestLogix.Flights.API.csproj

It will start a server running into localhost:5000

Access http://localhost:5000/flights/bestroute/ (example: http://localhost:5000/flights/bestroute/YYZ/ORD)
