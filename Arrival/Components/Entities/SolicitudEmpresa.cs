using System;

namespace Entities
{
    public class SolicitudEmpresa : BaseEntity
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CedulaJuridica { get; set; }
        public string NombreJuridico { get; set; }
        public SolicitudEmpresa(int idSolicitud, DateTime fechaCreacion, string cedulaJuridica, string nombreJuridico)
        {
            IdSolicitud = idSolicitud;
            FechaCreacion = fechaCreacion;
            CedulaJuridica = cedulaJuridica;
            NombreJuridico = nombreJuridico;
        }
        public SolicitudEmpresa()
        {

        }
    }
}
