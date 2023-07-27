using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class TerminosCrudFactory : CrudFactory
    {
        TerminosMapper mapper;

        public TerminosCrudFactory()
        {
            mapper = new TerminosMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            var sqlOperation = mapper.GetCreateStatement(tc);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetrieveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        public override List<T> RetrieveAll<T>()
        {
            var lstAccounts = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAccounts.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAccounts;
        }

        public override void Update(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(tc));
        }

        public override void Delete(BaseEntity entity)
        {
            var tc = (TerminosCondiciones)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(tc));
        }
    }
}