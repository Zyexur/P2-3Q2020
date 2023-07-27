using Data_Access.Dao;
using Entities;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class BitacoraMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_ACTIVIDAD = "ID_ACTIVIDAD";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ACCION = "ACCION";
        private const string DB_COL_CEDULA_FISICA = "CEDULA_FISICA";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var bitacora = new SqlOperation { ProcedureName = "CRE_BITACORA_PR" };

            var o = (Bitacora)entity;
            bitacora.AddDateParam(DB_COL_FECHA, o.Fecha);
            bitacora.AddVarcharParam(DB_COL_ACCION, o.Accion);
            bitacora.AddVarcharParam(DB_COL_CEDULA_FISICA, o.CedulaFisica);

            return bitacora;
        }

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var bitacora = new SqlOperation { ProcedureName = "RET_ALL_BITACORA_ID_PR" };

            var b = (Bitacora)entity;
            bitacora.AddVarcharParam(DB_COL_CEDULA_FISICA, b.CedulaFisica);

            return bitacora;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var bitacora = BuildObject(row);
                lstResults.Add(bitacora);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var bitacora = new Bitacora
            {
                IdActividad = GetIntValue(row, DB_COL_ID_ACTIVIDAD),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Accion = GetStringValue(row, DB_COL_ACCION),
                CedulaFisica = GetStringValue(row, DB_COL_CEDULA_FISICA)
            };
            return bitacora;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var bitacora = new SqlOperation { ProcedureName = "RET_ALL_BITACORA_PR" };

            return bitacora;
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
