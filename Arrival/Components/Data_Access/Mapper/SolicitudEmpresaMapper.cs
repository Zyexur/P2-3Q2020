using Data_Access.Dao;
using Entities;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class SolicitudEmpresaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_FECHA_CREACION = "FECHA_CREACION";
        private const string DB_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        private const string DB_NOMBRE_JURIDICO = "NOMBRE_JURIDICO";
        public SqlOperation GetRejectStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "REJ_SOLICITUD_EMPRESA_PR" };
            var s = (SolicitudEmpresa)entity;
            operation.AddIntParam(DB_ID_SOLICITUD, s.IdSolicitud);

            return operation;
        }
        public SqlOperation GetApproveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "APP_SOLICITUD_EMPRESA_PR" };
            var s = (SolicitudEmpresa)entity;
            operation.AddIntParam(DB_ID_SOLICITUD, s.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUD_EMPRESA_PR" };
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudEmpresa
            {
                IdSolicitud = GetIntValue(row, DB_ID_SOLICITUD),
                FechaCreacion = GetDateValue(row, DB_FECHA_CREACION),
                CedulaJuridica = GetStringValue(row, DB_CEDULA_JURIDICA),
                NombreJuridico = GetStringValue(row, DB_NOMBRE_JURIDICO),
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

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
