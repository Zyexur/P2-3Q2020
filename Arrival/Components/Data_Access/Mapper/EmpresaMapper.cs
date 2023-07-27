using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class EmpresaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_CEDULA_JURIDICA = "CEDULA_JURIDICA";
        private const string DB_NOMBRE_JURIDICO = "NOMBRE_JURIDICO";
        private const string DB_CORREO = "CORREO";
        private const string DB_NUM_TELEFONO = "NUM_TELEFONO";
        private const string DB_ESTADO = "ESTADO";
        private const string DB_COORDENADA = "COORDENADA";
        private const string DB_TIPO = "TIPO";
        private const string DB_CEDULA_FISICA = "CEDULA_FISICA";
        private const string DB_CE_ID = "CE_ID";
        private const string DB_TR_ID = "TR_ID";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var empresa = new Empresa
            {
                CedulaJuridica = GetStringValue(row, DB_CEDULA_JURIDICA),
                NombreJuridico = GetStringValue(row, DB_NOMBRE_JURIDICO),
                Correo = GetStringValue(row, DB_CORREO),
                NumTelefono = GetStringValue(row, DB_NUM_TELEFONO),
                Estado = GetStringValue(row, DB_ESTADO),
                Coordenada = GetStringValue(row, DB_COORDENADA),
                Tipo = GetStringValue(row, DB_TIPO)
            };
            return empresa;
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

        public SqlOperation GetRetrieveEmpresaByUserIdStatement(string cedulaFisica)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EMPRESA_USUARIO_PR" };
            operation.AddVarcharParam(DB_CEDULA_FISICA, cedulaFisica);

            return operation;
        }

        public SqlOperation GetRetrieveEmpresasTransporteByCJ(string cedulajuridica)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EMPRESAS_TRANSPORTE_CE_PR" };
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, cedulajuridica);

            return operation;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = null;
            var c = (Empresa)entity;
            if(c.Tipo == "ce")
            {
                operation = new SqlOperation{ ProcedureName = "CRE_CENTRO_EDUCATIVO_PR" };
            }else if(c.Tipo == "tr")
            {
                operation = new SqlOperation { ProcedureName = "CRE_TRANS_PR" };
            }
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, c.CedulaJuridica);
            operation.AddVarcharParam(DB_NOMBRE_JURIDICO, c.NombreJuridico);
            operation.AddVarcharParam(DB_CORREO, c.Correo);
            operation.AddVarcharParam(DB_NUM_TELEFONO, c.NumTelefono);
            operation.AddVarcharParam(DB_COORDENADA, c.Coordenada);

            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EMPRESA_PR" };
            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, e.CedulaJuridica);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EMPRESAS_PR" };
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_EMPRESA_PR" };
            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, e.CedulaJuridica);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_EMPRESA_PR" };
            var e = (Empresa)entity;
            operation.AddVarcharParam(DB_CEDULA_JURIDICA, e.CedulaJuridica);
            operation.AddVarcharParam(DB_NOMBRE_JURIDICO, e.NombreJuridico);
            operation.AddVarcharParam(DB_CORREO, e.Correo);
            operation.AddVarcharParam(DB_NUM_TELEFONO, e.NumTelefono);
            operation.AddVarcharParam(DB_COORDENADA, e.Coordenada);

            return operation;
        }

        public SqlOperation GetRetrieveAllCeStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CE_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveAllCeByIdStatement(string cedulaTr)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CE_BYID_PR" };
            operation.AddVarcharParam(DB_TR_ID, cedulaTr);
            return operation;
        }

        public SqlOperation GetRetrieveAllTrStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TRANS_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveAllTrByIdStatement(string cedulaCe)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_TR_BYID_PR" };
            operation.AddVarcharParam(DB_CE_ID, cedulaCe);
            return operation;
        }

    }
}
