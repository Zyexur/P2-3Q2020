using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Mapper
{
    public class ActividadEspecialMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID_ACTIVIDAD = "ID_ACTIVIDAD";
        private const string DB_NOMBRE = "NOMBRE";
        private const string DB_DESCRIPCION = "DESCRIPCION";
        private const string DB_COORDENADA_INICIAL = "COORDENADA_INICIAL";
        private const string DB_COORDENADA_FINAL = "COORDENADA_FINAL";
        private const string DB_ID_CENTRO_EDUCATIVO = "ID_CENTRO_EDUCATIVO";
        private string DB_ID_EMPRESA_TRANSPORTE = "ID_EMPRESA_TRANSPORTE";
        private string DB_ESTUDIANTE = "CEDULA_FISICA";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var actividadEspecial = new ActividadEspecial
            {
                IdActividad = GetIntValue(row, DB_ID_ACTIVIDAD),
                Nombre = GetStringValue(row, DB_NOMBRE),
                Desc = GetStringValue(row, DB_DESCRIPCION),
                CoorInicial = GetStringValue(row, DB_COORDENADA_INICIAL),
                CoorFinal = GetStringValue(row, DB_COORDENADA_FINAL),
                CentroEducativo = GetStringValue(row, DB_ID_CENTRO_EDUCATIVO),
                EmpresaTransporte = GetStringValue(row,DB_ID_EMPRESA_TRANSPORTE)
            };

            return actividadEspecial;
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
            var operation = new SqlOperation { ProcedureName = "CRE_ACTIVIDAD_ESPECIAL_PR" };

            var c = (ActividadEspecial)entity;
            operation.AddVarcharParam(DB_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_DESCRIPCION, c.Desc);
            operation.AddVarcharParam(DB_COORDENADA_FINAL, c.CoorFinal);
            operation.AddVarcharParam(DB_ID_CENTRO_EDUCATIVO, c.CentroEducativo);
            //operation.AddVarcharParam(DB_ID_EMPRESA_TRANSPORTE, c.EmpresaTransporte);


            return operation;
        }

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ACTIVIDAD_ESPECIAL_ID_PR" };

            var c = (ActividadEspecial)entity;
            operation.AddVarcharParam(DB_ID_CENTRO_EDUCATIVO, c.CentroEducativo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACTIVIDAD_ESPECIAL_PR" };

            var c = (ActividadEspecial)entity;
            operation.AddIntParam(DB_ID_ACTIVIDAD, c.IdActividad);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ACTIVIDAD_ESPECIAL_PR" };

            var c = (ActividadEspecial)entity;
            operation.AddIntParam(DB_ID_ACTIVIDAD, c.IdActividad);
            operation.AddVarcharParam(DB_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_DESCRIPCION, c.Desc);
            operation.AddVarcharParam(DB_COORDENADA_FINAL, c.CoorFinal);
            operation.AddVarcharParam(DB_ID_EMPRESA_TRANSPORTE, c.EmpresaTransporte);

            return operation;
        }

        public SqlOperation GetAsociarEventoEstudianteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_ASO_EVENTO_EST" };

            var c = (ActividadEspecial)entity;
            operation.AddIntParam(DB_ID_ACTIVIDAD, c.IdActividad);
            operation.AddVarcharParam(DB_ESTUDIANTE, c.Estudiante);

            return operation;
        }
    }
}
