using System;

namespace Entities
{
    public class SolicitudEstudiante : BaseEntity
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CedulaFisica { get; set; }
        public string CedulaJuridica { get; set; }
        public string NombreJuridico { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; }   
        public string Estado { get; set; }

        public SolicitudEstudiante(int idSolicitud, DateTime fechaCreacion, string cedulaJuridica, string nombreJuridico, string cedulaFisica, string nombre, string apellido, string estado)
        {
            IdSolicitud = idSolicitud;
            FechaCreacion = fechaCreacion;
            CedulaJuridica = cedulaJuridica;
            NombreJuridico = nombreJuridico;
            CedulaFisica = cedulaFisica;
            Nombre = nombre;
            Apellido = apellido;
            Estado = estado;
        }
        public SolicitudEstudiante()
        {

        }

    }
}
