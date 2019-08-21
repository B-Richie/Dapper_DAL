# Dapper_DAL
    Multi-provider data access layer using Dapper
    Reference in any client application

	BaseService.cs
		Abstract class implementing Dapper database commands. An abstract IDbConnection property is passed in containing the provider and connection string to your database of choice. Inherit this class within your service layer.

