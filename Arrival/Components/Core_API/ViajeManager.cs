using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class ViajeManager : BaseManager
    {
        private ViajeCrudFactory crudViaje;
        private BitacoraCrudFactory crudBitacora;

        public ViajeManager()
        {
            crudViaje = new ViajeCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }

        public List<Viaje> RetrieveViaje(string cedulaFisicaChofer)
        {
            return crudViaje.RetrieveViaje<Viaje>(cedulaFisicaChofer);
        }

        public void Abordaje(Viaje viaje)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Viaje puesto en abordaje",
                    CedulaFisica = viaje.CedulaFisica,
                    Fecha = DateTime.Now
                };
                crudViaje.Abordaje(viaje);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void AddEstudiante(string cedulaFisicaChofer, string cedulaFisicaEstudiante)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Estudiante agregado a viaje",
                    CedulaFisica = cedulaFisicaChofer,
                    Fecha = DateTime.Now
                };
                crudViaje.AddEstudiante(cedulaFisicaEstudiante);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void RemoveEstudiante(string cedulaFisicaChofer, string cedulaFisicaEstudiante)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Estudiante removido de viaje",
                    CedulaFisica = cedulaFisicaChofer,
                    Fecha = DateTime.Now
                };
                crudViaje.RemoveEstudiante(cedulaFisicaEstudiante);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Usuario> RetrieveEstudiantes(string cedulaFisicaChofer)
        {
            return crudViaje.RetrieveEstudiantes<Usuario>(cedulaFisicaChofer);
        }

        public void Start(Viaje viaje)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Viaje puesto en marcha",
                    CedulaFisica = viaje.CedulaFisica,
                    Fecha = DateTime.Now
                };
                viaje.FechaInicio = DateTime.Now;
                crudViaje.Start(viaje);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void End(Viaje viaje)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Viaje finalizado",
                    CedulaFisica = viaje.CedulaFisica,
                    Fecha = DateTime.Now
                };
                viaje.FechaFin = DateTime.Now;
                crudViaje.End(viaje);
                crudBitacora.Create(accion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }


    }
}
