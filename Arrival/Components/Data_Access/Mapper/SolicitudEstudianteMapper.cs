using Data_Access.Dao;
using Entities;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class SolicitudEstudianteMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID_SOLICITUD = "ID_SOLICITUD";
        private const string DB_FECHA_CREACION = "FECHA_CREACION";
        private const string DB_NOMBRE_JURIDICO = "NOMBRE_JURIDICO";
        private const string DB_CEDULA_FISICA = "CEDULA_FISICA";
        private const string DB_NOMBRE = "NOMBRE";
        private const string DB_APELLIDO = "APELLIDO";
        private const string DB_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        private const string DB_ESTADO = "ESTADO";
        public SqlOperation GetRejectStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "REJ_SOLICITUD_ESTUDIANTE_PR" };
            var s = (SolicitudEstudiante)entity;
            operation.AddIntParam(DB_ID_SOLICITUD, s.IdSolicitud);

            return operation;
        }
        public SqlOperation GetApproveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "APP_SOLICITUD_ESTUDIANTE_PR" };
            var s = (SolicitudEstudiante)entity;
            operation.AddIntParam(DB_ID_SOLICITUD, s.IdSolicitud);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement(string cedulaFisica)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUD_ESTUDIANTE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisica);
            return operation;
        }

        public SqlOperation GetRetrieveAllParienteStatement(string cedulaFisicaPariente)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SOLICITUD_ESTUDIANTE_PARIENTE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaPariente);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudEstudiante
            {
                IdSolicitud = GetIntValue(row, DB_ID_SOLICITUD),
                FechaCreacion = GetDateValue(row, DB_FECHA_CREACION),
                CedulaFisica = GetStringValue(row, DB_CEDULA_FISICA),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Apellido = GetStringValue(row, DB_APELLIDO)
            };
            return solicitud;
        }

        public BaseEntity BuildObjectPariente(Dictionary<string, object> row)
        {
            var solicitud = new SolicitudEstudiante
            {
                IdSolicitud = GetIntValue(row, DB_ID_SOLICITUD),
                FechaCreacion = GetDateValue(row, DB_FECHA_CREACION),
                NombreJuridico = GetStringValue(row, DB_NOMBRE_JURIDICO),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Apellido = GetStringValue(row, DB_APELLIDO),
                Estado = GetStringValue(row, DB_ESTADO)
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

        public List<BaseEntity> BuildObjectsPariente(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var option = BuildObjectPariente(row);
                lstResults.Add(option);
            }
            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SOLICITUD_ESTUDIANTE_PR" };
            var s = (SolicitudEstudiante)entity;
            operation.AddDateParam(DB_FECHA_CREACION, s.FechaCreacion);
            operation.AddVarcharParam(DB_CEDULA_FISICA, s.CedulaFisica);
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, s.CedulaJuridica);
            return operation;
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

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}
