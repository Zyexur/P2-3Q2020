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
    public class UsuarioCrudFactory : CrudFactory
    {
        UsuarioMapper mapper;

        public UsuarioCrudFactory()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetCreateStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void CreateChofer(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetCreateChoferStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void Activate(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetActivateStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetDeleteStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsCentro(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lst;
        }

        public List<T> RetrieveAllByCentro<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByCentroStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsCentro(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lst;
        }

        public List<T> RetrieveAllByTransportista<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByTransportistaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsCentro(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lst;
        }

        public List<T> RetrieveAllByChofer<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllByChoferStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjectsCentro(lstResult);
                foreach (var c in objs)
                {
                    lst.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return lst;
        }

        //Actualizar el Update
        public override void Update(BaseEntity entity)
        {
            var usr = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(usr));
        }

        public void UpdateEstado(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateEstadoStatement(usuario));
        }

        public void CreateContrasenna(BaseEntity entity)
        {
            var cliente = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetCreateContrasennaStatement(cliente));
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

        public T RetrieveById<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByIdStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObjectRetrieve(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }



        public void UpdateContrasenna(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            dao.ExecuteProcedure(mapper.GetUpdateContrasennaStatement(usuario));
        }

        public void AsociarEmpresa(string cedulaJuridica, string cedulaFisica)
        {
            dao.ExecuteProcedure(mapper.GetAsociarEmpresaStatement(cedulaJuridica, cedulaFisica));
        }

        public void AsociarEstudiantePariente(string cedulaFisicaPariente, string cedulaFisicaEstudiante)
        {
            dao.ExecuteProcedure(mapper.GetAsociarEstudianteParienteStatement(cedulaFisicaPariente, cedulaFisicaEstudiante));
        }

        public List<T> RetrieveEstudiantesPariente<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveEstudiantesPariente(entity));
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

        public List<T> RetrieveEstudiantesSinCentro<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveEstudiantesSinCentro(entity));
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

        public void CreateEstudiante(BaseEntity entity)
        {
            var usuario = (Usuario)entity;
            var sqlOperation = mapper.GetCreateEstudianteStatement(usuario);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveEstudiantesRuta<T>(BaseEntity entity)
        {
            var lst = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveEstudiantesRutaStatement(entity));
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

    }
}
