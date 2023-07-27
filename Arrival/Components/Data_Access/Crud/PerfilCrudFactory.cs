using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class PerfilCrudFactory : CrudFactory
    {
        PerfilMapper mapper;

        public PerfilCrudFactory()
        {
            mapper = new PerfilMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var perfil = (Perfil)entity;
            var sqlOperation = mapper.GetCreateStatement(perfil);
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

        public List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByIdStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lst;
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var perfil = (Perfil)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(perfil));
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
