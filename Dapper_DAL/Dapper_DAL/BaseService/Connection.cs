using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public class Connection : IConnection
    {
        public string Alias { get; set; }
        public string ConnectionString { get; set; }
        public IDbConnection dbConnection { get; set; }

    }
}
