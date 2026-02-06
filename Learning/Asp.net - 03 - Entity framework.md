# Setting up Entity framework

## Install EF
Install Entity Framework Core CLI tool globally.
<pre>
dotnet tool install --global dotnet-ef
</pre>

## Install Nuget packages
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Sqlite

The version should not exceed the .net version that is used in the project


## Create the DbContext class
* Create a class, f.e. TestorsOnTourDbContext
* Derive from DbContext
* Define properties of type DbSet<> for all domain classes that you need a table for
* Add the service for the DbContext to the DI container (in Program.cs)
* The service has to provide a DbContext instance with the connection string as a parameter for the DbContext class


## Add connection string to settings
In appsettings.json (and appsettings.Development.json) add the setting for the connection string. F.e (SQL Server):

<pre>
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TestorsOnTourDB;Trusted_Connection=True"
  },
</pre>

or (for SqLite):
<pre>
"ConnectionStrings": {
    "DefaultConnection": "Data Source=TestorsOnTourDB.db"
  },
</pre>

## Create migrations
dotnet ef migrations add InitialCreate -p .\TestorsOnTour.Persistence\ -s .\TestorsOnTour.API\

## Create the database
<pre>
dotnet ef database update -p .\TestorsOnTour.Persistence\ -s .\TestorsOnTour.API\
</pre>


## Error handling
Problem:
<pre>
Unable to create a 'DbContext' of type 'RuntimeType'. The exception 'Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions' while attempting to activate 'TestorsOnTour.Persistence.TestorsOnTourDbContext'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
</pre>

Solution:
Check if you used the -s parameter in the cli command
<pre>
 Wrong: dotnet ef database update -p .\TestorsOnTour.Persistence\

 Right: dotnet ef database update -p .\TestorsOnTour.Persistence\ -s .\TestorsOnTour.API\
</pre>
