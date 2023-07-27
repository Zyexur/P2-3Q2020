using Data_Access.Dao;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Mapper
{
    public class ApplicationMessageMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_ID = "ID";
        private const string DB_MESSAGE_TEXT = "MESSAGE_TEXT";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var applicationMessage = new ApplicationMessage
            {
                Id = GetIntValue(row, DB_ID),
                MessageText = GetStringValue(row, DB_MESSAGE_TEXT),
            };

            return applicationMessage;
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

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_APPLICATION_MESSAGE_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_APPLICATION_MESSAGE_PR" };

            var c = (ApplicationMessage)entity;
            operation.AddIntParam(DB_ID, c.Id);

            return operation;
        }
    }
}
