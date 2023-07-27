using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class SolicitudTR_CEManager
    {
        private SolicitudTR_CECrud crudSolicitud;

        public SolicitudTR_CEManager()
        {
            crudSolicitud = new SolicitudTR_CECrud();
        }

        public void Create(SolicitudTR_CE solicitud)
        {
            try
            {
                crudSolicitud.Create(solicitud);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public bool RetrieveSolicitud(SolicitudTR_CE solicitud)
        {
            var result = crudSolicitud.Retrieve<SolicitudTR_CE>(solicitud);
            if(result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<SolicitudTR_CE> RetrieveAllSolicitudes(SolicitudTR_CE solicitud)
        {
            return crudSolicitud.RetrieveAllSolicitudes<SolicitudTR_CE>(solicitud);
        }

        public void Update(SolicitudTR_CE solicitud)
        {
            try
            {
                crudSolicitud.Update(solicitud);

            }catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}
