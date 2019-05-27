using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Dapper_DAL.BaseService
{
    public abstract class BaseService
    {
        abstract protected IDbConnection Connection { get; set; }
        abstract protected string SQL { get; set; }

        protected BaseService()
        {
        }

        protected virtual T Get<T>(int id) where T : class
        {
            var result = QueryFirstOrDefault<T>(SQL, new { id });
            return result;
        }

        #region Execute
        protected int Execute(string sql, CommandType commandType, object parameters, IDbTransaction transaction, int? commandTimeout)
        {
            return Connection.Execute(sql, parameters, transaction, commandTimeout, commandType);
        }

        protected int Execute(string sql, CommandType commandType, object parameters, IDbTransaction transaction)
        {
            return Execute(sql, commandType, parameters, transaction, null);
        }

        protected int Execute(string sql, CommandType commandType, object parameters)
        {
            return Execute(sql, commandType, parameters, null, null);
        }

        protected int Execute(string sql, CommandType commandType)
        {
            return Execute(sql, commandType, null, null, null);
        }

        protected int Execute(string sql, object parameters)
        {
            return Execute(sql, CommandType.Text, parameters, null, null);
        }
        #endregion


        #region ExecuteAsync
        protected async Task<int> ExecuteAsync(string sql, CommandType commandType, object parameters, IDbTransaction transaction, int? commandTimeout)
        {
            return await Connection.ExecuteAsync(sql, parameters, transaction, commandTimeout, commandType);
        }

        protected async Task<int> ExecuteAsync(string sql, CommandType commandType, object parameters, IDbTransaction transaction)
        {
            return await ExecuteAsync(sql, commandType, parameters, transaction, null);
        }

        protected async Task<int> ExecuteAsync(string sql, CommandType commandType, object parameters)
        {
            return await ExecuteAsync(sql, commandType, parameters, null, null);
        }

        protected async Task<int> ExecuteAsync(string sql, CommandType commandType)
        {
            return await ExecuteAsync(sql, commandType, null, null, null);
        }

        protected async Task<int> ExecuteAsync(string sql, object parameters)
        {
            return await ExecuteAsync(sql, CommandType.Text, parameters, null, null);
        }
        #endregion


        #region QueryAsync
        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout, CommandType commandType)
        {
            return await Connection.QueryAsync<T>(sql, types, map, parameters, transaction, buffered, splitOn, commandTimeout, commandType);

        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout)
        {
            return await QueryAsync<T>(sql, types, map, parameters, transaction, buffered, splitOn, commandTimeout, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered, string splitOn)
        {
            return await QueryAsync<T>(sql, types, map, parameters, transaction, buffered, splitOn, null, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction)
        {
            return await QueryAsync<T>(sql, types, map, parameters, transaction, true, string.Empty, null, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map, object parameters)
        {
            return await QueryAsync<T>(sql, types, map, parameters, null, true, string.Empty, null, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, Type[] types, Func<object[], T> map)
        {
            return await QueryAsync<T>(sql, types, map, null, null, true, string.Empty, null, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType)
        {
            var result = await Connection.QueryAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
            return result;
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout)
        {
            return await QueryAsync<T>(sql, parameters, transaction, commandTimeout, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters, IDbTransaction transaction)
        {
            return await QueryAsync<T>(sql, parameters, transaction, null, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters)
        {
            return await QueryAsync<T>(sql, parameters, null, null, CommandType.Text);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            return await QueryAsync<T>(sql, null, null, null, CommandType.Text);
        }
        #endregion


        #region QueryFirstOrDefaultAsync
        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout)
        {
            return await QueryFirstOrDefaultAsync<T>(sql, parameters, transaction, commandTimeout, CommandType.Text);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters, IDbTransaction transaction)
        {
            return await QueryFirstOrDefaultAsync<T>(sql, parameters, transaction, null, CommandType.Text);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters)
        {
            return await QueryFirstOrDefaultAsync<T>(sql, parameters, null, null, CommandType.Text);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql)
        {
            return await QueryFirstOrDefaultAsync<T>(sql, null, null, null, CommandType.Text);
        }
        #endregion


        #region QueryFirstOrDefault

        protected T QueryFirstOrDefault<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType)
        {
            return Connection.QueryFirstOrDefault<T>(sql, parameters, transaction, commandTimeout, commandType);
        }

        protected T QueryFirstOrDefault<T>(string sql, object parameters, IDbTransaction transaction, int? commandTimeout)
        {
            return QueryFirstOrDefault<T>(sql, parameters, transaction, commandTimeout, CommandType.Text);
        }

        protected T QueryFirstOrDefault<T>(string sql, object parameters, IDbTransaction transaction)
        {
            return QueryFirstOrDefault<T>(sql, parameters, transaction, null, CommandType.Text);
        }

        protected T QueryFirstOrDefault<T>(string sql, object parameters)
        {
            return QueryFirstOrDefault<T>(sql, parameters, null, null, CommandType.Text);
        }
        protected T QueryFirstOrDefault<T>(string sql)
        {
            return QueryFirstOrDefault<T>(sql, null, null, null, CommandType.Text);
        }
        #endregion


        #region Query
        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout, CommandType commandType)
        {
            return Connection.Query(sql, types, map, parameters, transaction, buffered, splitOn, commandTimeout, commandType);
        }

        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered, string splitOn, int? commandTimeout)
        {
            return Query(sql, types, map, parameters, transaction, buffered, splitOn, commandTimeout, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered, string splitOn)
        {
            return Query(sql, types, map, parameters, transaction, buffered, splitOn, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction, bool buffered)
        {
            return Query(sql, types, map, parameters, transaction, buffered, string.Empty, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map, object parameters, IDbTransaction transaction)
        {
            return Query(sql, types, map, parameters, transaction, false, string.Empty, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map, object parameters)
        {
            return Query(sql, types, map, parameters, null, false, string.Empty, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, Type[] types, Func<object[], T> map)
        {
            return Query(sql, types, map, null, null, false, string.Empty, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters, IDbTransaction transaction, bool buffered, int? commandTimeout, CommandType commandType)
        {
            return Connection.Query<T>(sql, parameters, transaction, buffered, commandTimeout, commandType);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters, IDbTransaction transaction, bool buffered, int? commandTimeout)
        {
            return Query<T>(sql, parameters, transaction, buffered, commandTimeout, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters, IDbTransaction transaction, bool buffered)
        {
            return Query<T>(sql, parameters, transaction, buffered, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters, IDbTransaction transaction)
        {
            return Query<T>(sql, parameters, transaction, true, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql, object parameters)
        {
            return Query<T>(sql, parameters, null, true, null, CommandType.Text);
        }

        protected IEnumerable<T> Query<T>(string sql)
        {
            return Query<T>(sql, null, null, true, null, CommandType.Text);
        }
        #endregion

    }
}
