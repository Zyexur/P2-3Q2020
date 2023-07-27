using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class TerminosMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private string DB_COL_APARTADO_ID = "ID";
        private string DB_COL_APARTADO = "APARTADO";
        private string DB_COL_DESCRIPCION = "DESCRIPCION";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var option = BuildObject(row);
                lstResults.Add(option);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var tc = new TerminosCondiciones
            {
                IdApartado = GetIntValue(row, DB_COL_APARTADO_ID),
                Apartado = GetStringValue(row, DB_COL_APARTADO),
                DescripcionApartado = GetStringValue(row, DB_COL_DESCRIPCION)
            };

            return tc;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            var operation = new SqlOperation { ProcedureName = "CRE_TERM_COND_PR" };
            operation.AddVarcharParam(DB_COL_APARTADO, tc.Apartado);
            operation.AddVarcharParam(DB_COL_DESCRIPCION, tc.DescripcionApartado);
            return operation;
        }
        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            var operation = new SqlOperation { ProcedureName = "RET_TERM_COND_PR" };
            operation.AddIntParam(DB_COL_APARTADO_ID, tc.IdApartado);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TERM_COND_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            var operation = new SqlOperation { ProcedureName = "UPD_TERM_COND_PR" };
            operation.AddIntParam(DB_COL_APARTADO_ID, tc.IdApartado);
            operation.AddVarcharParam(DB_COL_APARTADO, tc.Apartado);
            operation.AddVarcharParam(DB_COL_DESCRIPCION, tc.DescripcionApartado);
            return operation;
        }
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            var operation = new SqlOperation { ProcedureName = "DEL_TERM_COND_PR" };
            operation.AddIntParam(DB_COL_APARTADO_ID, tc.IdApartado);
            return operation;
        }

    }
}