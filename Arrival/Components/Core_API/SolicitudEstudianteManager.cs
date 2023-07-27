using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class SolicitudEstudianteManager : BaseManager
    {
        private SolicitudEstudianteCrudFactory crudSolicitud;
        private BitacoraCrudFactory crudBitacora;
        public SolicitudEstudianteManager()
        {
            crudSolicitud = new SolicitudEstudianteCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }

        public List<SolicitudEstudiante> RetrieveAll(string cedulaFisica)
        {
            return crudSolicitud.RetrieveAll<SolicitudEstudiante>(cedulaFisica);
        }

        public List<SolicitudEstudiante> RetrieveAllPariente(string cedulaFisicaPariente)
        {
            return crudSolicitud.RetrieveAllPariente<SolicitudEstudiante>(cedulaFisicaPariente);
        }

        public void Reject(SolicitudEstudiante solicitud, string cedulaFisica)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Solicitud de estudiante rechazada",
                    CedulaFisica = cedulaFisica,
                    Fecha = DateTime.Now
                };
                crudSolicitud.Reject(solicitud);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Approve(SolicitudEstudiante solicitud, string cedulaFisica)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Solicitud de estudiante aprobada",
                    CedulaFisica = cedulaFisica,
                    Fecha = DateTime.Now
                };
                crudSolicitud.Approve(solicitud);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Create(SolicitudEstudiante solicitud, string cedulaFisicaPariente)
        {
            try
            {
                solicitud.FechaCreacion = DateTime.Now;
                var accion = new Bitacora
                {
                    Accion = "Solicitud de estudiante creada",
                    CedulaFisica = cedulaFisicaPariente,
                    Fecha = DateTime.Now
                };
                crudSolicitud.Create(solicitud);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
