using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class NivelesSeccionesMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_NOMBRE_NIVEL= "NOMBRE_NIVEL";
        private const string DB_COL_NOMBRE_SECCION = "NOMBRE_SECCION";
        private const string DB_COL_ID_CENTRO_EDU = "ID_CENTRO_EDU";

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var bitacora = new SqlOperation { ProcedureName = "RET_ALL_NIVELES_SECCIONES_PR" };

            var b = (NivelesSecciones)entity;
            bitacora.AddVarcharParam(DB_COL_ID_CENTRO_EDU, b.IdCentroEdu);

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
            var nivelesSecciones = new NivelesSecciones
            {
                NombreNivel = GetStringValue(row, DB_COL_NOMBRE_NIVEL),
                NombreSeccion = GetStringValue(row, DB_COL_NOMBRE_SECCION)
            };

            return nivelesSecciones;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new System.NotImplementedException();
        }
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
