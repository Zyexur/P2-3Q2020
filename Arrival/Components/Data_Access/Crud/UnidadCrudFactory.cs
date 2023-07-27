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
    public class UnidadCrudFactory: CrudFactory
    {
        UnidadMapper mapper;

        public UnidadCrudFactory() : base()
        {
            mapper = new UnidadMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var unidad = (Unidad)entity;
            var sqlOperation = mapper.GetCreateStatement(unidad);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var unidad = (Unidad)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(unidad));
        }

        public T RetrieveByPlaca<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetrieveByPlacaStatement(entity);
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

        public List<T> RetrieveAllByEmpresa<T>(BaseEntity entity)
        {
            var lstUnidades = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByEmpresaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUnidades.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstUnidades;
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var unidad = (Unidad)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(unidad));
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
    }
}
