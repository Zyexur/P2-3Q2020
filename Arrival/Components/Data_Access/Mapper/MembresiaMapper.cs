using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Mapper
{
    public class MembresiaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID_MEMBRESIA = "ID_MEMBRESIA";
        private const string DB_NOMBRE = "NOMBRE";
        private const string DB_PERIODICIDAD = "PERIODICIDAD";
        private const string DB_MONTO = "MONTO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var membresia = new Membresia
            {
                IdMembresia = GetIntValue(row, DB_ID_MEMBRESIA),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Periodicidad = GetIntValue(row, DB_PERIODICIDAD),
                Monto = GetDoubleValue(row, DB_MONTO),
            };

            return membresia;
        }

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

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MEMBRESIA_PR" };

            var c = (Membresia)entity;
            operation.AddVarcharParam(DB_NOMBRE, c.Nombre);
            operation.AddIntParam(DB_PERIODICIDAD, c.Periodicidad);
            operation.AddDoubleParam(DB_MONTO, c.Monto);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MEMBRESIA_PR" };

            var c = (Membresia)entity;

            operation.AddIntParam(DB_ID_MEMBRESIA, c.IdMembresia);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MEMBRESIAS_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MEMBRESIA_PR" };

            var c = (Membresia)entity;
            operation.AddIntParam(DB_ID_MEMBRESIA, c.IdMembresia);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MEMBRESIA_PR" };

            var c = (Membresia)entity;
            operation.AddIntParam(DB_ID_MEMBRESIA, c.IdMembresia);
            operation.AddVarcharParam(DB_NOMBRE, c.Nombre);
            operation.AddIntParam(DB_PERIODICIDAD, c.Periodicidad);
            operation.AddDoubleParam(DB_MONTO, c.Monto);         

            return operation;
        }
    }
}
