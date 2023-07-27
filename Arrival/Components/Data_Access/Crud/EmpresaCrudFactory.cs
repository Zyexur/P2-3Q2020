using Data_Access.Dao;
using Data_Access.Mapper;
using Entities;
using System;
using System.Collections.Generic;

namespace Data_Access.Crud
{
    public class EmpresaCrudFactory : CrudFactory
    {
        EmpresaMapper mapper;

        public EmpresaCrudFactory()
        {
            mapper = new EmpresaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var empresa = (Empresa)entity;
            var sqlOperation = mapper.GetCreateStatement(empresa);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveStatement(entity));
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
            var lstEmpresas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstEmpresas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstEmpresas;
        }
        public override void Update(BaseEntity entity)
        {
            var empresa = (Empresa)entity;
            var sqlOperation = mapper.GetUpdateStatement(empresa);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var empresa = (Empresa)entity;
            var sqlOperation = mapper.GetDeleteStatement(empresa);
            dao.ExecuteProcedure(sqlOperation);
        }

        public List<T> RetrieveAllCE<T>()
        {
            var lstCentros = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllCeStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCentros.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCentros;
        }
        public List<T> RetrieveAllCEById<T>(string cedulaTr)
        {
            var lstCentros = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllCeByIdStatement(cedulaTr));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCentros.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCentros;
        }

        public List<T> RetrieveAllTrans<T>()
        {
            var lstTransportistas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllTrStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransportistas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstTransportistas;
        }
        public List<T> RetrieveAllTransById<T>(string cedulaCe)
        {
            var lstTransportistas = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllTrByIdStatement(cedulaCe));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstTransportistas.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstTransportistas;
        }

        public List<T> RetrieveEmpresaByUserId<T>(string cedulaFisica)
        {
            var centroAdmin = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveEmpresaByUserIdStatement(cedulaFisica));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    centroAdmin.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return centroAdmin;
        }

        public List<T> RetrieveEmpresasTransporteByCJ<T>(string cedulajuridica)
        {
            var centroAdmin = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveEmpresasTransporteByCJ(cedulajuridica));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    centroAdmin.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return centroAdmin;
        }

    }
}
