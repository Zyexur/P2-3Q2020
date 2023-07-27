using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Mapper
{
    public class PagoMapper : EntityMapper, IObjectMapper
    {

        private const string DB_COL_ID_PAGO = "ID_PAGO";
        private const string DB_COL_FECHA_PAGO = "FECHA_PAGO";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_ID_SUSCRIPCION = "ID_USUARIO_SUSCRIPCION";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var pago = new Pago
            {
                IdPago = GetIntValue(row, DB_COL_ID_PAGO),
                FechaPago = GetDateValue(row, DB_COL_FECHA_PAGO),
                Monto = GetIntValue(row, DB_COL_MONTO),
                Suscripcion = GetIntValue(row, DB_COL_ID_SUSCRIPCION)
            };

            return pago;
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
            var operation = new SqlOperation { ProcedureName = "CRE_PAGO_PR" };

            var p = (Pago)entity;
            operation.AddIntParam(DB_COL_ID_PAGO, p.IdPago);
            operation.AddDateParam(DB_COL_FECHA_PAGO, p.FechaPago);
            operation.AddIntParam(DB_COL_MONTO, Convert.ToInt32(p.Monto));
            operation.AddIntParam(DB_COL_ID_SUSCRIPCION, p.Suscripcion);



            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PAGO_PR" };

            var p = (Pago)entity;
            operation.AddIntParam(DB_COL_ID_PAGO, p.IdPago);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PAGOS_PR" };
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PAGO_PR" };
            var p = (Pago)entity;
            operation.AddIntParam(DB_COL_ID_PAGO, p.IdPago);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
