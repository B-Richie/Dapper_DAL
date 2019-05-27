using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public class OracleParameterFactory : IOracleParameterFactory
    {

        #region ServiceLocatorPattern
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
        #endregion


        #region FactoryPattern
        public IOracleDynamicParameters CreateOracleParameters()
        {
            IOracleDynamicParameters oracleDynamicParameters = new OracleDynamicParameters();
            return oracleDynamicParameters;
        }
        #endregion

    }
}
