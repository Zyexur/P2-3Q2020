using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class SolicitudTR_CECrud : CrudFactory
    {
        SolicitudesTR_CEMapper mapper;

        public SolicitudTR_CECrud() : base()
        {
            mapper = new SolicitudesTR_CEMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var sqlOperation = mapper.GetCreateStatement(entity);
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

        public List<T> RetrieveAllSolicitudes<T>(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var lstSolicitudes = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllSolicitudes(s));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstSolicitudes.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lstSolicitudes;
        }

        public override void Update(BaseEntity entity)
        {
            var s = (SolicitudTR_CE)entity;
            var sqlOperation = mapper.GetUpdateStatement(s);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
