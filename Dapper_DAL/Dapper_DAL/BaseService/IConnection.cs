using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public interface IConnection
    {
        string Alias { get; set; }
        string ConnectionString { get; set; }
        //string ProviderName { get; set; }
        IDbConnection dbConnection { get; set; }
        Guid Guid { get; set; }
        //Guid Guid { get; }
    }
}
