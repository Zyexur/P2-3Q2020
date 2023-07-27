using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ruta : BaseEntity
    {
        public int IdRuta { get; set; }
        public string NombreRuta { get; set; }
        public string Hora { get; set; }
        public string CoorInicial { get; set; }
        public string CentroEducativo { get; set; }
        public List<Localidad> localidades { get; set; }
        public string Estudiante { get; set; }
        public string EmpresaTransporte { get; set; }

        public Ruta(string nombreRuta, string hora, string centroEducativo)
        {
            NombreRuta = nombreRuta;
            Hora = hora;
            CentroEducativo = centroEducativo;
        }

        public Ruta(int idRuta, string nombreRuta, string hora, string coorInicial, string centroEducativo)
        {
            IdRuta = idRuta;
            NombreRuta = nombreRuta;
            Hora = hora;
            CoorInicial = coorInicial;
            CentroEducativo = centroEducativo;
        }

        public Ruta()
        {
        }
    }
}
