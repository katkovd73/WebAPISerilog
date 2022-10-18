# WebAPISerilog
This project is .NET 5 Web API with EF-database first
Serilog setup for txt file and SQL Server database

Nuget packages:
1. Serilog.AspNetCore
2. Serilog.Sinks.File - writing to text file
3. Serilog.Sinks.MSSqlServer - writing to SQL Server database

Update Program.cs file: add try/catch block to Main method and one line
to CreateHostBuilder method

Update appsettings.json file with Serilog settings

Create a table in your database with following fields:
CREATE TABLE [dbo].[Logs] (
    [Id]              INT            NOT NULL,
    [Message]         NVARCHAR (MAX) NULL,
    [MessageTemplate] NVARCHAR (MAX) NULL,
    [Level]           NVARCHAR (MAX) NULL,
    [TimeStamp]       DATETIME2 (7)  NULL,
    [Exception]       NVARCHAR (MAX) NULL,
    [Properties]      NVARCHAR (MAX) NULL,
    [LogEvent]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

Run EF scaffold command to generate a model in the project

In controllers inject an instance of an Iloger

private readonly ILogger<PhonesController> _logger;
  
 public PhonesController(ILogger<PhonesController> logger, dbcontext db)
 {
    _logger = logger;
 } 
  
 Use _logger inside the catch block or anywhere else:
  try
            {                
                _logger.LogInformation("This is just a log entry for the try block");
                throw new Exception("Error Happened");
                return Ok(_db.Phones);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception in Catch block: " + ex.Message);
                return BadRequest("Sorry, we could not load the data");
            }
