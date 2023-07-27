using System;

namespace Entities
{
    public class SolicitudTR_CE : BaseEntity
    {
        public int IdSolicitud { get; set; }
        public string CedulaCE { get; set; }
        public string CedulaTR { get; set; }
        public string NombreEmpresa { get; set; }
        public string Estado { get; set; }

        public SolicitudTR_CE(int idSolicitud, string cedulaCE, string cedulaTR, string estado)
        {
            IdSolicitud = idSolicitud;
            CedulaCE = cedulaCE;
            CedulaTR = cedulaTR;
            Estado = estado;
        }
        public SolicitudTR_CE()
        {

        }
    }
}