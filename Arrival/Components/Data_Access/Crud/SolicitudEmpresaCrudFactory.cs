using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class SolicitudEmpresaCrudFactory : CrudFactory
    {
        SolicitudEmpresaMapper mapper;

        public SolicitudEmpresaCrudFactory() : base()
        {
            mapper = new SolicitudEmpresaMapper();
            dao = SqlDao.GetInstance();
        }


        public override List<T> RetrieveAll<T>()
        {
            var lstSolicitudesEmpresa = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstSolicitudesEmpresa.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstSolicitudesEmpresa;
        }

        public void Approve(BaseEntity entity)
        {
            var solicitud = (SolicitudEmpresa)entity;
            var sqlOperation = mapper.GetApproveStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void Reject(BaseEntity entity)
        {
            var solicitud = (SolicitudEmpresa)entity;
            var sqlOperation = mapper.GetRejectStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Create(BaseEntity entity)
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

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
