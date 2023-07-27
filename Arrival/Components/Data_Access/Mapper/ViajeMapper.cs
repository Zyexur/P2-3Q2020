using Data_Access.Dao;
using Entities;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class ViajeMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID_VIAJE = "ID_VIAJE";
        private const string DB_CEDULA_FISICA = "CEDULA_FISICA";
        private const string DB_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_FECHA_FIN = "FECHA_FIN";
        private const string DB_ESTADO = "ESTADO";
        private const string DB_ID_RUTA = "ID_RUTA";
        private const string DB_NOMBRE_RUTA = "NOMBRE_RUTA";
        private const string DB_NOMBRE = "NOMBRE";
        private const string DB_APELLIDO = "APELLIDO";

        public SqlOperation GetRetrieveViajeStatement(string cedulaFisicaChofer)
        {
            var operation = new SqlOperation { ProcedureName = "RET_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaChofer);
            return operation;
        }

        public SqlOperation GetAbordajeStatement(string cedulaFisicaChofer)
        {
            var operation = new SqlOperation { ProcedureName = "ABO_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaChofer);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var viaje = new Viaje
            {
                IdViaje = GetIntValue(row, DB_ID_VIAJE),
                CedulaFisica = GetStringValue(row, DB_CEDULA_FISICA),
                FechaInicio = GetDateValue(row, DB_FECHA_INICIO),
                FechaFin = GetDateValue(row, DB_FECHA_FIN),
                Estado = GetStringValue(row, DB_ESTADO),
                IdRuta = GetIntValue(row, DB_ID_RUTA),
                NombreRuta = GetStringValue(row, DB_NOMBRE_RUTA)
            };
            return viaje;
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

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new System.NotImplementedException();
        }

        public List<BaseEntity> BuildEstudiantes(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var option = BuildEstudiante(row);
                lstResults.Add(option);
            }
            return lstResults;
        }

        public BaseEntity BuildEstudiante(Dictionary<string, object> row)
        {
            var estudiante = new Usuario
            {
                CedulaFisica = GetStringValue(row, DB_CEDULA_FISICA),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Apellido = GetStringValue(row, DB_APELLIDO)
            };
            return estudiante;
        }

        public SqlOperation GetRetrieveEstudiantesStatement(string cedulaFisicaChofer)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ESTUDIANTES_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaChofer);
            return operation;
        }

        public SqlOperation GetAddEstudianteStatement(string cedulaFisicaEstudiante)
        {
            var operation = new SqlOperation { ProcedureName = "ADD_ESTUDIANTE_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaEstudiante);
            return operation;
        }

        public SqlOperation GetRemoveEstudianteStatement(string cedulaFisicaEstudiante)
        {
            var operation = new SqlOperation { ProcedureName = "REM_ESTUDIANTE_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaEstudiante);
            return operation;
        }

        public SqlOperation GetStartStatement(BaseEntity entity)
        {
            var viaje = (Viaje)entity;
            var operation = new SqlOperation { ProcedureName = "STA_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, viaje.CedulaFisica);
            operation.AddDateParam(DB_FECHA_INICIO, viaje.FechaInicio);
            return operation;
        }

        public SqlOperation GetEndStatement(BaseEntity entity)
        {
            var viaje = (Viaje)entity;
            var operation = new SqlOperation { ProcedureName = "END_VIAJE_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, viaje.CedulaFisica);
            operation.AddDateParam(DB_FECHA_FIN, viaje.FechaFin);
            return operation;
        }
    }
}
