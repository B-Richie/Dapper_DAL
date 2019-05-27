using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Dapper_DAL.BaseService
{
    public interface IBaseService
    {
        T QueryFirstOrDefault<T>(string sql, object parameters);
        T QueryFirstOrDefault<T>(string sql);
        T QueryFirstOrDefault<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType);
        T QueryFirstOrDefault<T>(string sql, object parameters, IDbTransaction transaction);
        T QueryFirstOrDefault<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null);

        IEnumerable<T> Query<T>(string sql, object parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);

        int Execute(string sql, CommandType commandType, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
        //Task<IEnumerable<T>> ExecuteAsync<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType);
        Task<int> ExecuteAsync(string sql, CommandType commandType, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
        //Task<IEnumerable<T>> ExecuteProcAsync<T>(string sql, CommandType commandType, object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null);
        //IDbConnection Connect(string alias);
    }
}
