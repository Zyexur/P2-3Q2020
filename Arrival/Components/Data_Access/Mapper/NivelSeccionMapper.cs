using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class NivelSeccionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_CENTRO_EDU = "ID_CENTRO_EDU";
        private const string DB_COL_ID_SECCION = "ID_SECCION";
        private const string DB_COL_ID_CENTRO_NIVEL = "ID_CENTRO_NIVEL";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var nivel = new SqlOperation { ProcedureName = "CRE_NIVEL_SECCION_PR" };

            var n = (NivelSeccion)entity;
            nivel.AddVarcharParam(DB_COL_ID_CENTRO_EDU, n.IdCentroEdu);
            nivel.AddIntParam(DB_COL_ID_SECCION, n.IdSeccion);
            nivel.AddIntParam(DB_COL_ID_CENTRO_NIVEL, n.IdCentroNivel);

            return nivel;
        }

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var nivel = new SqlOperation { ProcedureName = "RET_ALL_NIVEL_SECCION_ID_PR" };

            var n = (NivelSeccion)entity;
            nivel.AddIntParam(DB_COL_ID_SECCION, n.IdSeccion);
            nivel.AddVarcharParam(DB_COL_ID_CENTRO_EDU, n.IdCentroEdu);
            nivel.AddIntParam(DB_COL_ID_CENTRO_NIVEL, n.IdCentroNivel);

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
            var nivel = new NivelSeccion
            {
                IdCentroEdu = GetStringValue(row, DB_COL_ID_CENTRO_EDU),
                IdSeccion = GetIntValue(row, DB_COL_ID_SECCION),
                IdCentroNivel = GetIntValue(row, DB_COL_ID_CENTRO_NIVEL)
            };
            return nivel;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var nivel = new SqlOperation { ProcedureName = "RET_ALL_NIVEL_SECCION_PR" };

            return nivel;
        }

        public List<BaseEntity> BuildObjectsAll(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var nivel = BuildObjectAll(row);
                lstResults.Add(nivel);
            }
            return lstResults;
        }

        public BaseEntity BuildObjectAll(Dictionary<string, object> row)
        {
            var nivel = new NivelSeccion
            {
                IdCentroEdu = GetStringValue(row, DB_COL_ID_CENTRO_EDU),
                IdSeccion = GetIntValue(row, DB_COL_ID_SECCION),
                IdCentroNivel = GetIntValue(row, DB_COL_ID_CENTRO_NIVEL)
            };
            return nivel;
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
