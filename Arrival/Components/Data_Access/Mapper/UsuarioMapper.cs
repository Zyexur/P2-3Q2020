using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class UsuarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_CEDULA_FISICA = "CEDULA_FISICA";
        private const string DB_NOMBRE = "NOMBRE";
        private const string DB_APELLIDO = "APELLIDO";
        private const string DB_CORREO = "CORREO";
        private const string DB_NUM_TELEFONO = "NUM_TELEFONO";
        private const string DB_FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        private const string DB_IMAGEN = "IMAGEN";
        private const string DB_CODIGO = "CODIGO";
        private const string DB_CONTRASENNA = "CONTRASENNA";
        private const string DB_ESTADO_USUARIO = "ESTADO_USUARIO";
        private const string DB_COORDENADA = "COORDENADA";
        private const string DB_ROL = "ROL";
        private const string DB_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        private const string DB_CEDULA_FISICA_ESTUDIANTE = "CEDULA_FISICA_ESTUDIANTE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                CedulaFisica = GetStringValue(row, DB_CEDULA_FISICA),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Apellido = GetStringValue(row, DB_APELLIDO),
                Correo = GetStringValue(row, DB_CORREO),
                NumTelefono = GetStringValue(row, DB_NUM_TELEFONO),
                FechaNacimiento = GetDateValue(row, DB_FECHA_NACIMIENTO),
                Imagen = GetStringValue(row, DB_IMAGEN),
                Codigo = GetStringValue(row, DB_CODIGO),
                Contrasenna = GetStringValue(row, DB_CONTRASENNA),
                EstadoUsuario = GetStringValue(row, DB_ESTADO_USUARIO),
                Coordenada = GetStringValue(row, DB_COORDENADA),
                Rol = GetStringValue(row, DB_ROL)
            };

            return usuario;
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

        public List<BaseEntity> BuildObjectsCentro(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var option = BuildObjectCentro(row);
                lstResults.Add(option);
            }

            return lstResults;
        }

        public BaseEntity BuildObjectCentro(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                CedulaFisica = GetStringValue(row, DB_CEDULA_FISICA),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Apellido = GetStringValue(row, DB_APELLIDO),
                Correo = GetStringValue(row, DB_CORREO),
                NumTelefono = GetStringValue(row, DB_NUM_TELEFONO),
                FechaNacimiento = GetDateValue(row, DB_FECHA_NACIMIENTO),
                EstadoUsuario = GetStringValue(row, DB_ESTADO_USUARIO),
                Rol = GetStringValue(row, DB_ROL)
            };

            return usuario;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);
            operation.AddVarcharParam(DB_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_APELLIDO, u.Apellido);
            operation.AddVarcharParam(DB_CORREO, u.Correo);
            operation.AddVarcharParam(DB_NUM_TELEFONO, u.NumTelefono);
            operation.AddDateParam(DB_FECHA_NACIMIENTO, u.FechaNacimiento);
            operation.AddVarcharParam(DB_COORDENADA, u.Coordenada);
            operation.AddVarcharParam(DB_ROL, u.Rol);
            operation.AddVarcharParam(DB_CODIGO, u.Codigo);

            return operation;
        }

        public SqlOperation GetCreateChoferStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CHOFER_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);
            operation.AddVarcharParam(DB_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_APELLIDO, u.Apellido);
            operation.AddVarcharParam(DB_CORREO, u.Correo);
            operation.AddVarcharParam(DB_NUM_TELEFONO, u.NumTelefono);
            operation.AddDateParam(DB_FECHA_NACIMIENTO, u.FechaNacimiento);
            operation.AddVarcharParam(DB_COORDENADA, u.Coordenada);
            operation.AddVarcharParam(DB_CODIGO, u.Codigo);

            return operation;
        }

        public SqlOperation GetActivateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ACTIVAR_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);

            return operation;
        }

        public BaseEntity BuildObjectRetrieve(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                CedulaFisica = GetStringValue(row, DB_CEDULA_FISICA),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Apellido = GetStringValue(row, DB_APELLIDO),
                Correo = GetStringValue(row, DB_CORREO),
                Contrasenna = GetStringValue(row, DB_CONTRASENNA),
                NumTelefono = GetStringValue(row, DB_NUM_TELEFONO),
                FechaNacimiento = GetDateValue(row, DB_FECHA_NACIMIENTO),
                EstadoUsuario = GetStringValue(row, DB_ESTADO_USUARIO),
                Rol = GetStringValue(row, DB_ROL)
            };

            return usuario;
        }

        public List<BaseEntity> BuildObjectsRetrieve(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var option = BuildObjectRetrieve(row);
                lstResults.Add(option);
            }

            return lstResults;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USUARIO_PR" };

            var c = (Usuario)entity;

            operation.AddVarcharParam(DB_CEDULA_FISICA, c.CedulaFisica);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIO_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveAllByCentroStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIOS_CE_PR" };
            var e = (Empresa)entity;
            operation.AddVarcharParam("CEDULA_JURIDICA", e.CedulaJuridica);

            return operation;
        }

        public SqlOperation GetRetrieveAllByTransportistaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIOS_TRANSPORTISTA_PR" };
            var e = (Empresa)entity;
            operation.AddVarcharParam("CEDULA_JURIDICA", e.CedulaJuridica);

            return operation;
        }

        public SqlOperation GetRetrieveAllByChoferStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USUARIOS_CHOFER_PR" };
            var e = (Empresa)entity;
            operation.AddVarcharParam("CEDULA_JURIDICA", e.CedulaJuridica);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, c.CedulaFisica);
            operation.AddVarcharParam(DB_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_APELLIDO, c.Apellido);
            operation.AddVarcharParam(DB_CORREO, c.Correo);
            operation.AddVarcharParam(DB_NUM_TELEFONO, c.NumTelefono);
            operation.AddDateParam(DB_FECHA_NACIMIENTO, c.FechaNacimiento);
            return operation;
        }

        public SqlOperation GetUpdateEstadoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_ESTADO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);
            operation.AddVarcharParam(DB_ESTADO_USUARIO, u.EstadoUsuario);

            return operation;

        }

        public SqlOperation GetCreateContrasennaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_CONTRASENNA_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_CORREO, c.Correo);
            operation.AddVarcharParam(DB_CONTRASENNA, c.Contrasenna);

            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_CORREO, c.Correo);

            return operation;
        }

        public SqlOperation GetUpdateContrasennaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USUARIO_CONTRASENNA_PR" };

            var c = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, c.CedulaFisica);
            operation.AddVarcharParam(DB_CONTRASENNA, c.Contrasenna);

            return operation;
        }

        public SqlOperation GetRetriveByIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USUARIO_ID_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);

            return operation;
        }

        public SqlOperation GetAsociarEmpresaStatement(string cedulaJuridica, string cedulaFisica)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ASOCIACION_EMPRESA_USUARIO_PR" };

            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisica);
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, cedulaJuridica);

            return operation;
        }

        public SqlOperation GetRetrieveEstudiantesPariente(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ESTUDIANTES_PARIENTE_PR" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);

            return operation;
        }

        public SqlOperation GetAsociarEstudianteParienteStatement(string cedulaFisicaPariente, string cedulaFisicaEstudiante)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ASOCIACION_ESTUDIANTE_PARIENTE_PR" };

            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisicaPariente);
            operation.AddVarcharParam(DB_CEDULA_FISICA_ESTUDIANTE, cedulaFisicaEstudiante);

            return operation;
        }

        public SqlOperation GetCreateEstudianteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ESTUDIANTE_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);
            operation.AddVarcharParam(DB_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_APELLIDO, u.Apellido);
            operation.AddVarcharParam(DB_CORREO, u.Correo);
            operation.AddVarcharParam(DB_NUM_TELEFONO, u.NumTelefono);
            operation.AddDateParam(DB_FECHA_NACIMIENTO, u.FechaNacimiento);
            operation.AddVarcharParam(DB_COORDENADA, u.Coordenada);
            operation.AddVarcharParam(DB_ROL, u.Rol);

            return operation;
        }
        public SqlOperation GetRetrieveEstudiantesSinCentro(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ESTUDIANTES_SIN_CENTRO_PR" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);

            return operation;
        }

        public SqlOperation GetRetrieveEstudiantesRutaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ESTUDIANTES_RUTA_PR" };
            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_CEDULA_FISICA, u.CedulaFisica);

            return operation;
        }
    }
}
