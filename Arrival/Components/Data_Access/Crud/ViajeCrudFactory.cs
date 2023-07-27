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
    public class ViajeCrudFactory : CrudFactory
    {
        ViajeMapper mapper;

        public ViajeCrudFactory()
        {
            mapper = new ViajeMapper();
            dao = SqlDao.GetInstance();
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

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveViaje<T>(string cedulaFisicaChofer)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveViajeStatement(cedulaFisicaChofer));
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

        public void Abordaje(BaseEntity entity)
        {
            var viaje = (Viaje)entity;
            var sqlOperation = mapper.GetAbordajeStatement(viaje.CedulaFisica);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveEstudiantes<T>(string cedulaFisicaChofer)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveEstudiantesStatement(cedulaFisicaChofer));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildEstudiantes(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lst;
        }

        public void AddEstudiante(string cedulaFisicaEstudiante)
        {
            var sqlOperation = mapper.GetAddEstudianteStatement(cedulaFisicaEstudiante);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void RemoveEstudiante(string cedulaFisicaEstudiante)
        {
            var sqlOperation = mapper.GetRemoveEstudianteStatement(cedulaFisicaEstudiante);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void Start(BaseEntity entity)
        {
            var viaje = (Viaje)entity;
            var sqlOperation = mapper.GetStartStatement(viaje);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void End(BaseEntity entity)
        {
            var viaje = (Viaje)entity;
            var sqlOperation = mapper.GetEndStatement(viaje);
            dao.ExecuteProcedure(sqlOperation);
        }

    }
}
