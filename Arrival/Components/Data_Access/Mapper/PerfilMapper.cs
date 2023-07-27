using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class PerfilMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CEDULA_FISICA = "CEDULA_FISICA";
        private const string DB_COL_ROL = "ROL";
        private const string DB_COL_ESTADO_PERFIL = "ESTADO_PERFIL";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var perfil = new SqlOperation { ProcedureName = "CRE_PERFIL_PR" };

            var p = (Perfil)entity;
            perfil.AddVarcharParam(DB_COL_CEDULA_FISICA, p.CedulaFisica);
            perfil.AddVarcharParam(DB_COL_ROL, p.Rol);

            return perfil;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();

        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var perfil = BuildObject(row);
                lstResults.Add(perfil);
            }
            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var perfil = new Perfil
            {
                CedulaFisica = GetStringValue(row, DB_COL_CEDULA_FISICA),
                Rol = GetStringValue(row, DB_COL_ROL),
                EstadoPerfil = GetStringValue(row, DB_COL_ESTADO_PERFIL)
            };
            return perfil;
        }

        public SqlOperation GetRetrieveAllByIdStatement(BaseEntity entity)
        {
            var perfil = new SqlOperation { ProcedureName = "RET_ALL_PERFIL_ROL_PR" };

            var p = (Perfil)entity;
            perfil.AddVarcharParam(DB_COL_ROL, p.Rol);

            return perfil;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PERFIL_PR" };

            var p = (Perfil)entity;
            operation.AddVarcharParam(DB_COL_CEDULA_FISICA, p.CedulaFisica);
            operation.AddVarcharParam(DB_COL_ROL, p.Rol);
            operation.AddVarcharParam(DB_COL_ESTADO_PERFIL, p.EstadoPerfil);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
