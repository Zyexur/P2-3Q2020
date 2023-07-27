using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Localidad : BaseEntity
    {
        public int IdLocalidad { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public Localidad(int idLocalidad, string provincia, string canton, string distrito)
        {
            IdLocalidad = idLocalidad;
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
        }

        public Localidad(string provincia, string canton, string distrito)
        {
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
        }

        public Localidad()
        {
        }
    }
}
