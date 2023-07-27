using Data_Access.Dao;
using Entities;

namespace Data_Access.Mapper
{
    public interface ISqlStatements
    {
        SqlOperation GetCreateStatement(BaseEntity entity);
        SqlOperation GetRetrieveStatement(BaseEntity entity);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetUpdateStatement(BaseEntity entity);
        SqlOperation GetDeleteStatement(BaseEntity entity);
    }
}
