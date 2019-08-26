# Dapper Data Access Layer for ASP Core 2.2
Multi-provider IOC data access layer using Dapper

Reference in any client application
	
# How It Works:

BaseService.cs

Abstract class implementing Dapper database commands. An abstract IDbConnection property is passed in containing the provider and connection string to your database of choice. You will have the ability to use multiple providers or multiple connection strings from the same provider for a single request! Inherit this class within your cleint's service layer.


ConnectionStringConfiguration.cs

Static middleware component for setting the connection strings for each provider. The IOptions interface is used to map the appsettings.json database connection section from the client:

	services.AddTransient(resolver =>
	    {
		var databaseConnections = resolver.GetService<IOptions<DatabaseConnections>>().Value;
		var iDbConnections = resolver.GetServices<IDbConnection>();
		databaseConnections.OracleConnections.ToList().ForEach(ora =>
		{
		    ora.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(OracleConnection)).FirstOrDefault();
		    ora.dbConnection.ConnectionString = ora.ConnectionString;
		    ora.Guid = Guid.NewGuid();
		});
		databaseConnections.MSSqlConnections.ToList().ForEach(sql =>
		{
		    sql.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(SqlConnection)).FirstOrDefault();
		    sql.dbConnection.ConnectionString = sql.ConnectionString;
		    sql.Guid = Guid.NewGuid();
		});
				
MS SQL and Oracle are the two providers currently in use. To add additional database providers, such as Sqlite, do the following:

-Install Microsoft.EntityFrameworkCore.Sqlite via Nuget
			
-Add the class list to DatabaseConnections.cs

	public IEnumerable<Connection> OracleConnections { get; set; }
	public IEnumerable<Connection> MSSqlConnections { get; set; }
	public IEnumerable<Connection> SqliteConnections {get; set; }
				
-Don't forget to add your Sqlite connection string(s) to the appsettings.json file in your client app

	"DatabaseConnections": {
	    "OracleConnections": [
	      {
		"Alias": "Optional",        
		"ConnectionString": "Required"
	      },
	      {
		"Alias": "Optional",        
		"ConnectionString": "Required"
	      }
	    ],
	    "MSSqlConnections": [
	      {
		"Alias": "Optional",        
		"ConnectionString": "Required"
	      }
	    ],
	    "SqliteConnections" [
	      {
		"Alias": "Optional",
		"ConnectionString": "Required"
	      }
	    ]
	  }
				
-Inject the SqliteConnection into the service container

	services.AddTransient<IDbConnection, SqliteConnection>();
				
-Resolve the DbConnection for Sqlite

	services.AddTransient(resolver =>
    {
	var databaseConnections = resolver.GetService<IOptions<DatabaseConnections>>().Value;
	var iDbConnections = resolver.GetServices<IDbConnection>();
	databaseConnections.OracleConnections.ToList().ForEach(ora =>
	{
	    ora.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(OracleConnection)).FirstOrDefault();
	    ora.dbConnection.ConnectionString = ora.ConnectionString;
	    ora.Guid = Guid.NewGuid();
	});
	databaseConnections.MSSqlConnections.ToList().ForEach(sql =>
	{
	    sql.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(SqlConnection)).FirstOrDefault();
	    sql.dbConnection.ConnectionString = sql.ConnectionString;
	    sql.Guid = Guid.NewGuid();
	});
	databaseConnections.SqliteConnections.ToList().ForEach(lite =>
	{
	    lite.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(SqliteConnection)).FirstOrDefault();
	    lite.dbConnection.ConnectionString = lite.ConnectionString;
	    lite.Guid = Guid.NewGuid();	--DI demostration purposes only					
	{);

 }
				
				
Client Startup.cs implementation example (See the Core_Dapper repo for a full example):

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
	   ...   
	    services.AddConnectionStrings(Configuration);
	   ...
	}
		
