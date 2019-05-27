using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_DAL.BaseService
{
    public interface IOracleParameterFactory
    {
        IOracleDynamicParameters CreateOracleParameters();
    }
}
