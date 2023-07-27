using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class CentroEducativoNivelMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_CENTRO_NIVEL = "ID_CENTRO_NIVEL";
        private const string DB_COL_ID_CENTRO_EDU = "ID_CENTRO_EDU";
        private const string DB_COL_ID_NIVEL = "ID_NIVEL";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var centroEdu = new SqlOperation { ProcedureName = "CRE_CENTRO_NIVEL_PR" };

            var c = (CentroEducativoNivel)entity;
            centroEdu.AddVarcharParam(DB_COL_ID_CENTRO_EDU, c.IdCentroEdu);
            centroEdu.AddIntParam(DB_COL_ID_NIVEL, c.IdNivel);

            return centroEdu;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var nivel = new SqlOperation { ProcedureName = "RET_ALL_CENTRO_EDU_NIVEL_PR" };

            return nivel;
        }

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var centroEduNivel = new SqlOperation { ProcedureName = "RET_ALL_CENTRO_EDU_NIVEL_ID_CENTRO_EDU_PR" };

            var c = (CentroEducativoNivel)entity;
            centroEduNivel.AddIntParam(DB_COL_ID_NIVEL, c.IdNivel);
            centroEduNivel.AddVarcharParam(DB_COL_ID_CENTRO_EDU, c.IdCentroEdu);

            return centroEduNivel;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var centroNivel = BuildObject(row);
                lstResults.Add(centroNivel);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var centroNivel = new CentroEducativoNivel
            {
                IdCentroNivel = GetIntValue(row,DB_COL_ID_CENTRO_NIVEL),
                IdCentroEdu = GetStringValue(row, DB_COL_ID_CENTRO_EDU),
                IdNivel = GetIntValue(row, DB_COL_ID_NIVEL)
            };
            return centroNivel;
        }

        public SqlOperation GetRetrieveAllStatement(BaseEntity entity)
        {
            var centroEduNivel = new SqlOperation { ProcedureName = "RET_ALL_CENTRO_EDU_NIVEL_PR" };

            return centroEduNivel;
        }

        public List<BaseEntity> BuildObjectsAll(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var centroNivel = BuildObjectAll(row);
                lstResults.Add(centroNivel);
            }
            return lstResults;
        }

        public BaseEntity BuildObjectAll(Dictionary<string, object> row)
        {
            var centroNivel = new CentroEducativoNivel
            {
                IdCentroEdu = GetStringValue(row, DB_COL_ID_CENTRO_EDU),
                IdNivel = GetIntValue(row, DB_COL_ID_NIVEL),
                IdCentroNivel = GetIntValue(row, DB_COL_ID_CENTRO_NIVEL)
            };
            return centroNivel;
        }


        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var centroEduNivel = new SqlOperation { ProcedureName = "RET_ALL_CENTRO_EDU_NIVEL_ID_CENTRO_EDU_PR" };

            var c = (CentroEducativoNivel)entity;
            centroEduNivel.AddIntParam(DB_COL_ID_NIVEL, c.IdNivel);
            centroEduNivel.AddVarcharParam(DB_COL_ID_CENTRO_EDU, c.IdCentroEdu);

            return centroEduNivel;
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
