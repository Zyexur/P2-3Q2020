using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class SolicitudEmpresaManager : BaseManager
    {
        private SolicitudEmpresaCrudFactory crudSolicitud;
        public SolicitudEmpresaManager()
        {
            crudSolicitud = new SolicitudEmpresaCrudFactory();
        }

        public List<SolicitudEmpresa> RetrieveAll()
        {
            return crudSolicitud.RetrieveAll<SolicitudEmpresa>();
        }

        public void Reject(SolicitudEmpresa solicitud)
        {
            try
            {
                crudSolicitud.Reject(solicitud);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Approve(SolicitudEmpresa solicitud)
        {
            try
            {
                crudSolicitud.Approve(solicitud);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
