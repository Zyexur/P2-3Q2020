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
    public class ActividadEspecialCrudFactory : CrudFactory
    {
        ActividadEspecialMapper mapper;

        public ActividadEspecialCrudFactory() : base()
        {
            mapper = new ActividadEspecialMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var actividadEspecial = (ActividadEspecial)entity;
            var sqlOperation = mapper.GetCreateStatement(actividadEspecial);
            dao.ExecuteProcedure(sqlOperation);
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
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            var actividadEspecial = (ActividadEspecial)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(actividadEspecial));
        }

        public void Asociar(BaseEntity entity)
        {
            var actividadEspecial = (ActividadEspecial)entity;
            var sqlOperation = mapper.GetAsociarEventoEstudianteStatement(actividadEspecial);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
