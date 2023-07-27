using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Viaje : BaseEntity
    {
        public int IdViaje { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string CedulaFisica { get; set; }
        public string Estado { get; set; }
        public int IdRuta { get; set; }
        public string NombreRuta { get; set; }

        public Viaje()
        {
        }

        public Viaje(int idViaje, DateTime fechaInicio, DateTime fechaFin, string cedulaFisica, string estado, int idRuta, string nombreRuta)
        {
            IdViaje = idViaje;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            CedulaFisica = cedulaFisica;
            Estado = estado;
            IdRuta = idRuta;
            NombreRuta = nombreRuta;
        }
    }
}
