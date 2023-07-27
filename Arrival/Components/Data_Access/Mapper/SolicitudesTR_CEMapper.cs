using Data_Access.Dao;
using Entities;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class SolicitudesTR_CEMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_ID_CE = "ID_CE";
        private const string DB_ID_TR = "ID_TR";
        private const string DB_NOMBRE = "NOMBRE_JURIDICO";
        private const string DB_ESTADO = "ESTADO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var operation = new SqlOperation { ProcedureName = "CRE_SOL_TR_CE_PR" };
            operation.AddVarcharParam(DB_ID_CE, s.CedulaCE);
            operation.AddVarcharParam(DB_ID_TR, s.CedulaTR);

            return operation;
        }
        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var operation = new SqlOperation { ProcedureName = "RET_SOL_TR_CE_PR" };
            operation.AddVarcharParam(DB_ID_CE, s.CedulaCE);
            operation.AddVarcharParam(DB_ID_TR, s.CedulaTR);

            return operation;
        }

        public SqlOperation GetRetrieveAllSolicitudes(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOL_TR_CE_PR" };
            operation.AddVarcharParam(DB_ID_CE, s.CedulaCE);

            return operation;
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            throw new System.NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var operation = new SqlOperation { ProcedureName = "UPD_SOL_TR_CE" };
            operation.AddIntParam(DB_ID_SOLICITUD, s.IdSolicitud);
            operation.AddVarcharParam(DB_ESTADO, s.Estado);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudTR_CE
            {
                IdSolicitud = GetIntValue(row, DB_ID_SOLICITUD),
                CedulaTR = GetStringValue(row, DB_ID_TR),
                NombreEmpresa = GetStringValue(row, DB_NOMBRE)
            };
            return solicitud;
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

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}
