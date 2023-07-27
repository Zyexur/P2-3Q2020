using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Mapper
{
    public class ListOptionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_LIST_ID = "LIST_ID";
        private const string DB_LIST_VALUE = "LIST_VALUE";
        private const string DB_LIST_DESC = "LIST_DESC";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var listOption = new OptionList
            {
                ListId = GetStringValue(row, DB_LIST_ID),
                ListValue = GetIntValue(row, DB_LIST_VALUE),
                ListDesc = GetStringValue(row, DB_LIST_DESC),
            };

            return listOption;
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

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_LIST_OPTION_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_LIST_OPTION_PR" };

            var c = (OptionList)entity;
            operation.AddVarcharParam(DB_LIST_ID, c.ListId);

            return operation;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
     
    }
}
