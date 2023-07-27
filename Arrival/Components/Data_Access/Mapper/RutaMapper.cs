using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Mapper
{
    public class RutaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private string DB_ID_RUTA = "ID_RUTA";
        private string DB_NOMBRE_RUTA = "NOMBRE_RUTA";
        private string DB_HORA = "HORA";
        private string DB_COORDENADA_INICIAL = "COORDENADA_INICIAL";
        private string DB_ID_CENTRO_EDUCATIVO = "ID_CENTRO_EDUCATIVO";
        private string DB_ID_EMPRESA_TRANSPORTE = "ID_EMPRESA_TRANSPORTE";
        private string DB_ESTUDIANTE = "CEDULA_FISICA";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ruta = new Ruta
            {
                IdRuta = GetIntValue(row, DB_ID_RUTA),
                NombreRuta = GetStringValue(row, DB_NOMBRE_RUTA),
                Hora = GetStringValue(row, DB_HORA),
                CoorInicial = GetStringValue(row, DB_COORDENADA_INICIAL),
                CentroEducativo = GetStringValue(row, DB_ID_CENTRO_EDUCATIVO),
                EmpresaTransporte = GetStringValue(row, DB_ID_EMPRESA_TRANSPORTE)
            };

            return ruta;
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
            var operation = new SqlOperation { ProcedureName = "CRE_RUTA_PR" };

            var c = (Ruta)entity;
            operation.AddVarcharParam(DB_NOMBRE_RUTA, c.NombreRuta);
            operation.AddVarcharParam(DB_HORA, c.Hora);
            operation.AddVarcharParam(DB_ID_CENTRO_EDUCATIVO, c.CentroEducativo);
            //operation.AddVarcharParam(DB_ID_EMPRESA_TRANSPORTE, c.EmpresaTransporte);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_RUTA_PR" };

            var c = (Ruta)entity;

            operation.AddIntParam(DB_ID_RUTA, c.IdRuta);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllByCedulaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_RUTAS_CEDULA_FISICA" };
            var c = (Usuario)entity;
            operation.AddVarcharParam("CEDULA_FISICA", c.CedulaFisica);

            return operation;
        }

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_RUTA_ID_PR" };

            var c = (Ruta)entity;
            operation.AddVarcharParam(DB_ID_CENTRO_EDUCATIVO, c.CentroEducativo);

            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_RUTA_PR" };

            var c = (Ruta)entity;
            operation.AddIntParam(DB_ID_RUTA, c.IdRuta);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_RUTA_PR" };

            var c = (Ruta)entity;
            operation.AddIntParam(DB_ID_RUTA, c.IdRuta);
            operation.AddVarcharParam(DB_NOMBRE_RUTA, c.NombreRuta);
            operation.AddVarcharParam(DB_HORA, c.Hora);
            operation.AddVarcharParam(DB_ID_EMPRESA_TRANSPORTE, c.EmpresaTransporte);

            return operation;
        }

        public SqlOperation GetAsociarRutaEstudianteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ASO_RUTA_EST" };

            var c = (Ruta)entity;
            operation.AddIntParam(DB_ID_RUTA, c.IdRuta);
            operation.AddVarcharParam(DB_ESTUDIANTE, c.Estudiante);

            return operation;
        }

    }
}
