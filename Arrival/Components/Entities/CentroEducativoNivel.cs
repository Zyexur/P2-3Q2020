using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CentroEducativoNivel : BaseEntity
    {
        public int IdCentroNivel { get; set; }
        public string IdCentroEdu { get; set; }
        public int IdNivel { get; set; }

        public CentroEducativoNivel()
        {
        }
    }
}
