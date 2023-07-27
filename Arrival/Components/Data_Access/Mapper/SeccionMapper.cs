using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class SeccionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_SECCION = "ID_SECCION";
        private const string DB_COL_NOMBRE = "NOMBRE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var seccion = new SqlOperation { ProcedureName = "RET_ALL_SECCION_PR" };

            return seccion;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var seccion = BuildObject(row);
                lstResults.Add(seccion);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var seccion = new Seccion
            {
                IdSeccion = GetIntValue(row, DB_COL_ID_SECCION),
                Nombre = GetStringValue(row, DB_COL_NOMBRE)
            };
            return seccion;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
