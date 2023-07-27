using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Nivel : BaseEntity
    {
        public int IdNivel { get; set; }
        public string Nombre { get; set; }

        public Nivel()
        {
        }
    }
}
