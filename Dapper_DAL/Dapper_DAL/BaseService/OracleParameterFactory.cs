using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public class OracleParameterFactory : IOracleParameterFactory
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public OracleParameterFactory(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;            
        //}

        //public IOracleDynamicParameters CreateOracleParameters()
        //{
        //    IOracleDynamicParameters oracleDynamicParameters = _httpContextAccessor.HttpContext.RequestServices.GetService<IOracleDynamicParameters>();
        //    return oracleDynamicParameters;
        //}

        public IOracleDynamicParameters CreateOracleParameters()
        {
            IOracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            return oracleDynamicParameters;
        }


    }
}
