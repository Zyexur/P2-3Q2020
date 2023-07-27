using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class CentroEduNivelCrudFactory : CrudFactory
    {
        CentroEducativoNivelMapper mapper;

        public CentroEduNivelCrudFactory()
        {
            mapper = new CentroEducativoNivelMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var centroEduNivel = (CentroEducativoNivel)entity;
            var sqlOperation = mapper.GetCreateStatement(centroEduNivel);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
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
            var lstDatos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstDatos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstDatos;
        }

        public List<T> RetrieveAllById<T>(BaseEntity entity)
        {
            var lstDatos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByIdStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstDatos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstDatos;
        }

        public override void Update(BaseEntity entity)
        {
            var membresia = (Membresia)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(membresia));
        }
    }
}
