# Dapper_DAL
	Multi-provider IOC data access layer using Dapper
	Reference in any client application
	
How It Works:

	BaseService.cs
		Abstract class implementing Dapper database commands. An abstract IDbConnection property is passed in containing the provider and connection string to your database of choice. Inherit this class within your service layer.


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
				
				
		Client Startup.cs implementation example:
			 public IConfiguration Configuration { get; }

			public void ConfigureServices(IServiceCollection services)
			{
			   ...   
			    services.AddConnectionStrings(Configuration);
			   ...
			}
		
