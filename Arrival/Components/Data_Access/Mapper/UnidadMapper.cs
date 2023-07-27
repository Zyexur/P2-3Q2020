using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Mapper
{
    public class UnidadMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_PLACA = "PLACA";
        private const string DB_COL_MODELO = "MODELO";
        private const string DB_COL_MARCA = "MARCA";
        private const string DB_COL_ANNO = "ANNO";
        private const string DB_COL_TAMANO = "TAMANO";
        private const string DB_COL_CAPACIDAD = "CAPACIDAD";
        private const string DB_COL_COLOR = "COLOR";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_RUTA = "ID_RUTA";
        private const string DB_COL_ID_CHOFER = "ID_CHOFER";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var unidad = new Unidad
            {
                Placa = GetStringValue(row, DB_COL_PLACA),
                Modelo = GetStringValue(row, DB_COL_MODELO),
                Marca = GetStringValue(row, DB_COL_MARCA),
                Anno = GetDateValue(row, DB_COL_ANNO),
                Tamano = GetStringValue(row, DB_COL_TAMANO),
                Capacidad = GetIntValue(row, DB_COL_CAPACIDAD),
                Color = GetStringValue(row, DB_COL_COLOR),
                IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                IdRuta = GetIntValue(row, DB_COL_ID_RUTA),
                IdChofer = GetStringValue(row,DB_COL_ID_CHOFER)
            };
            return unidad;
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

        public SqlOperation GetRetrieveByPlacaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNIDAD_PR" };
            var u = (Unidad)entity;
            operation.AddVarcharParam(DB_COL_PLACA, u.Placa);

            return operation;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_UNIDAD_PR" };

            var c = (Unidad)entity;
            operation.AddVarcharParam(DB_COL_PLACA, c.Placa);
            operation.AddVarcharParam(DB_COL_MODELO, c.Modelo);
            operation.AddVarcharParam(DB_COL_MARCA, c.Marca);
            operation.AddDateParam(DB_COL_ANNO, c.Anno);
            operation.AddVarcharParam(DB_COL_TAMANO, c.Tamano);
            operation.AddIntParam(DB_COL_CAPACIDAD, c.Capacidad);
            operation.AddVarcharParam(DB_COL_COLOR, c.Color);
            operation.AddVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_RUTA, c.IdRuta);
            operation.AddVarcharParam(DB_COL_ID_CHOFER, c.IdChofer);

            return operation;
        }

        public SqlOperation GetRetrieveAllByEmpresaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_UNIDADES_CE_PR" };
            var u = (Unidad)entity;
            operation.AddVarcharParam(DB_COL_ID_EMPRESA, u.IdEmpresa);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_UNIDAD_PR" };
            var u = (Unidad)entity;
            operation.AddVarcharParam(DB_COL_PLACA, u.Placa);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_UNIDAD_PR" };
            var c = (Unidad)entity;
            operation.AddVarcharParam(DB_COL_PLACA, c.Placa);
            operation.AddVarcharParam(DB_COL_MODELO, c.Modelo);
            operation.AddVarcharParam(DB_COL_MARCA, c.Marca);
            operation.AddDateParam(DB_COL_ANNO, c.Anno);
            operation.AddVarcharParam(DB_COL_TAMANO, c.Tamano);
            operation.AddIntParam(DB_COL_CAPACIDAD, c.Capacidad);
            operation.AddVarcharParam(DB_COL_COLOR, c.Color);
            operation.AddVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);
            operation.AddIntParam(DB_COL_ID_RUTA, c.IdRuta);
            operation.AddVarcharParam(DB_COL_ID_CHOFER, c.IdChofer);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var u = (Unidad)entity;
            var operation = new SqlOperation { ProcedureName = "RET_UNIDAD_BY_PLACA_PR" };
            operation.AddVarcharParam(DB_COL_PLACA, u.Placa);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }
    }
}
