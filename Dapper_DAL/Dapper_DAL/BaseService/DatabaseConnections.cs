using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public class DatabaseConnections : IDatabaseConnections
    {
        public IEnumerable<Connection> OracleConnections { get; set; }
        public IEnumerable<Connection> MSSqlConnections { get; set; }
    }
}
