using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public interface IDatabaseConnections
    {
        //IList<Connection> ConnectionStrings { get; set; }
        IEnumerable<Connection> OracleConnections { get; set; }
        IEnumerable<Connection> MSSqlConnections { get; set; }
    }
}
