using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Dapper_DAL.BaseService
{
    public class OracleDynamicParameters : IOracleDynamicParameters, SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<OracleParameter> oracleParameters = new List<OracleParameter>();


        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);
            var cmd = (OracleCommand)command;
            if (cmd != null)
            {
                cmd.BindByName = true;
                cmd.Parameters.AddRange(oracleParameters.ToArray());
            }
        }


        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value, int? size)
        {
            OracleParameter oracleParameter;
            if (size.HasValue)
            {
                oracleParameter = new OracleParameter(name, oracleDbType, size.Value, value, direction);
            }
            else
            {
                oracleParameter = new OracleParameter(name, oracleDbType, value, direction);
            }

            oracleParameters.Add(oracleParameter);
        }

        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        {
            Add(name, oracleDbType, direction, null, null);
        }
        public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value)
        {
            Add(name, oracleDbType, direction, value, null);
        }

        //public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction, object value = null, int? size = null)
        //{
        //    OracleParameter oracleParameter;
        //    if (size.HasValue)
        //    {
        //        oracleParameter = new OracleParameter(name, oracleDbType, size.Value, value, direction);
        //    }
        //    else
        //    {
        //        oracleParameter = new OracleParameter(name, oracleDbType, value, direction);
        //    }

        //    oracleParameters.Add(oracleParameter);
        //}

        //public void Add(string name, OracleDbType oracleDbType, ParameterDirection direction)
        //{
        //    var oracleParameter = new OracleParameter(name, oracleDbType, direction);
        //    oracleParameters.Add(oracleParameter);
        //}
    }
}
