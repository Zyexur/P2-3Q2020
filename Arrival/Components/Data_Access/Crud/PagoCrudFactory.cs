using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Crud
{
    public class PagoCrudFactory : CrudFactory
    {
        PagoMapper mapper;

        public PagoCrudFactory() : base()
        {
            mapper = new PagoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var pago = (Pago)entity;
            var sqlOperation = mapper.GetCreateStatement(pago);
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
            var lstPagos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstPagos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstPagos;
        }

        public override void Delete(BaseEntity entity)
        {
            var pago = (Pago)entity;
            var sqlOperation = mapper.GetDeleteStatement(pago);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
