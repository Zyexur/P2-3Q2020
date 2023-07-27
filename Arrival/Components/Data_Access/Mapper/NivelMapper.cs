using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;


namespace Data_Access.Mapper
{
    public class NivelMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_NIVEL = "ID_NIVEL";
        private const string DB_COL_NOMBRE = "NOMBRE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var nivel = new SqlOperation { ProcedureName = "RET_ALL_NIVEL_PR" };

            return nivel;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var nivel = BuildObject(row);
                lstResults.Add(nivel);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var nivel = new Nivel
            {
                IdNivel = GetIntValue(row, DB_COL_ID_NIVEL),
                Nombre = GetStringValue(row, DB_COL_NOMBRE)
            };
            return nivel;
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
