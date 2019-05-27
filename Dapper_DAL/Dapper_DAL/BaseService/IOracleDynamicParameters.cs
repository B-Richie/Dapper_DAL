using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public interface IOracleDynamicParameters
    {
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value, int? size);
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction);
        void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value);
        void AddParameters(IDbCommand command, SqlMapper.Identity identity);
    }
}
