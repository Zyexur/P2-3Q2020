using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;


namespace Data_Access.Crud
{
    public class NivelCrudFactory : CrudFactory
    {
        NivelMapper mapper;

        public NivelCrudFactory()
        {
            mapper = new NivelMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
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

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
