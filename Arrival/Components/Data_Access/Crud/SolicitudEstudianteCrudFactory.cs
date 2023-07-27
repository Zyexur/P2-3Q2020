using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class SolicitudEstudianteCrudFactory : CrudFactory
    {
        SolicitudEstudianteMapper mapper;

        public SolicitudEstudianteCrudFactory() : base()
        {
            mapper = new SolicitudEstudianteMapper();
            dao = SqlDao.GetInstance();
        }


        public List<T> RetrieveAll<T>(string cedulaFisica)
        {
            var lstSolicitudesEstudiante = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement(cedulaFisica));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstSolicitudesEstudiante.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstSolicitudesEstudiante;
        }

        public List<T> RetrieveAllPariente<T>(string cedulaFisicaPariente)
        {
            var lstSolicitudesEstudiante = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllParienteStatement(cedulaFisicaPariente));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsPariente(lstResult);
                foreach (var c in objs)
                {
                    lstSolicitudesEstudiante.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstSolicitudesEstudiante;
        }

        public void Approve(BaseEntity entity)
        {
            var solicitud = (SolicitudEstudiante)entity;
            var sqlOperation = mapper.GetApproveStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void Reject(BaseEntity entity)
        {
            var solicitud = (SolicitudEstudiante)entity;
            var sqlOperation = mapper.GetRejectStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Create(BaseEntity entity)
        {
            var solicitud = (SolicitudEstudiante)entity;
            var sqlOperation = mapper.GetCreateStatement(solicitud);
            dao.ExecuteProcedure(sqlOperation);
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

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
