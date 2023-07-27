using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NivelesSecciones : BaseEntity
    {
        public string NombreNivel { get; set; }
        public string NombreSeccion {get;set;}
        public string IdCentroEdu { get; set; }

        public NivelesSecciones()
        {
        }
    }
}
