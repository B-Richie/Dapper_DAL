using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public static class ConnectionStringConfiguration
    {
        public static void AddConnectionStrings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            #region transient

            //services.AddTransient<IDbConnection, OracleConnection>();
            //services.AddTransient<IDbConnection, SqlConnection>();
            //services.Configure<DatabaseConnections>(configuration.GetSection("DatabaseConnections"));
            //services.AddTransient(resolver =>
            //{
            //    var databaseConnections = resolver.GetService<IOptions<DatabaseConnections>>().Value;
            //    var iDbConnections = resolver.GetServices<IDbConnection>();
            //    databaseConnections.OracleConnections.ToList().ForEach(ora =>
            //    {
            //        ora.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(OracleConnection)).FirstOrDefault();
            //        ora.dbConnection.ConnectionString = ora.ConnectionString;
            //        //ora.Guid = Guid.NewGuid();
            //    });
            //    databaseConnections.MSSqlConnections.ToList().ForEach(sql =>
            //    {
            //        sql.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(SqlConnection)).FirstOrDefault();
            //        sql.dbConnection.ConnectionString = sql.ConnectionString;
            //        //sql.Guid = Guid.NewGuid();
            //    });
            //    return databaseConnections;
            //});

            #endregion

            #region scoped

            services.AddScoped<IDbConnection, OracleConnection>();
            services.AddScoped<IDbConnection, SqlConnection>();
            services.Configure<DatabaseConnections>(configuration.GetSection("DatabaseConnections"));
            services.AddScoped(resolver =>
            {
                var databaseConnections = resolver.GetService<IOptions<DatabaseConnections>>().Value;
                var iDbConnections = resolver.GetServices<IDbConnection>();
                databaseConnections.OracleConnections.ToList().ForEach(ora =>
                {
                    ora.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(OracleConnection)).FirstOrDefault();
                    ora.dbConnection.ConnectionString = ora.ConnectionString;
                    //ora.Guid = Guid.NewGuid();
                });
                databaseConnections.MSSqlConnections.ToList().ForEach(sql =>
                {
                    sql.dbConnection = iDbConnections.Where(w => w.GetType() == typeof(SqlConnection)).FirstOrDefault();
                    sql.dbConnection.ConnectionString = sql.ConnectionString;
                    //sql.Guid = Guid.NewGuid();
                });
                return databaseConnections;
            });

            #endregion

            services.AddTransient<IOracleDynamicParameters, OracleDynamicParameters>();
            services.AddTransient<IOracleParameterFactory, OracleParameterFactory>();
        }
    }
}
