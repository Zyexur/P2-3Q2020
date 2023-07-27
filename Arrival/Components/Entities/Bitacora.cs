using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bitacora : BaseEntity
    {
        public int IdActividad { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string CedulaFisica { get; set; }

        public Bitacora(int idActividad, DateTime fecha, string accion, string cedulaFisica)
        {
            IdActividad = idActividad;
            Fecha = fecha;
            Accion = accion;
            CedulaFisica = cedulaFisica;
        }

        public Bitacora(DateTime fecha, string accion, string cedulaFisica)
        {
            Fecha = fecha;
            Accion = accion;
            CedulaFisica = cedulaFisica;
        }

        public Bitacora()
        {
        }
    }
}
