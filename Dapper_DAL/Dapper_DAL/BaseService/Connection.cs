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
        //public string ProviderName { get; set; }
        public bool disposed = false;

        public IDbConnection dbConnection { get; set; }
        public Guid Guid { get; set; }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposed)
        //        return;
        //    if (disposing)
        //    {

        //    }
        //    disposed = true;
        //}
        //public Guid Guid { get => Guid.NewGuid(); }

    }
}
