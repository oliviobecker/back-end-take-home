How to run

It's an API .Net Core C#

Can be started with visual studio, deploying to IIS or command line with the .NET CLI

To run via CLI execute the following command with the prompt (after installing .NET CLI):

dotnet run --project ./solution/GuestLogix.Flights.API/GuestLogix.Flights.API/GuestLogix.Flights.API.csproj

It will start a server into localhost:5000

Access http://localhost:5000/api/flights/findbestroute/ (example: http://localhost:5000/api/flights/findbestroute/?origin=YYZ&destination=ORD)
