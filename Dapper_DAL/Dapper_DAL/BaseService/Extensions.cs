using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace Dapper_DAL.BaseService
{
    public static class Extensions
    {
        #region QueryFirstOrDefault
        //public static T ExecuteFirstOrDefault<T>(this IDbConnection connection, string sql, object parameters, IDbTransaction transaction, int? commandTimeout, CommandType commandType)
        //{
        //    return connection.ExecuteFirstOrDefault<T>(sql, parameters, transaction, commandTimeout, commandType);
        //}

        //public static T QueryFirstOrDefault<T>(this IDbConnection connection, string sql, object parameters, IDbTransaction transaction, int? commandTimeout)
        //{
        //    return QueryFirstOrDefault<T>(connection ,sql, parameters, transaction, commandTimeout, CommandType.Text);
        //}

        //public static T QueryFirstOrDefault<T>(this IDbConnection connection ,string sql, object parameters, IDbTransaction transaction)
        //{
        //    return QueryFirstOrDefault<T>(connection, sql, parameters, transaction, null, CommandType.Text);
        //}

        //public static T ExecuteFirstOrDefault<T>(this IDbConnection connection, string sql, object parameters)
        //{
        //    return ExecuteFirstOrDefault<T>(connection, sql, parameters, null, null, CommandType.Text);
        //}

        //public static T QueryFirstOrDefault<T>(this IDbConnection connection, string sql)
        //{
        //    return QueryFirstOrDefault<T>(connection, sql, null, null, null, CommandType.Text);
        //}
        #endregion
    }
}
