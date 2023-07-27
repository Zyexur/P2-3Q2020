using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class NivelSeccion : BaseEntity
    {
        public string IdCentroEdu { get; set; }
        public int IdSeccion { get; set; }
        public int IdCentroNivel { get; set; }
        public int IdNivel { get; set; }

        public NivelSeccion()
        {
        }
    }
}
