using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TerminosCondiciones : BaseEntity
    {
        public int IdApartado { get; set; }
        public string Apartado { get; set; }
        public string DescripcionApartado { get; set; }

        public TerminosCondiciones()
        {

        }

        public TerminosCondiciones(int idApartado, string apartado, string descApartado)
        {
            IdApartado = idApartado;
            Apartado = apartado;
            DescripcionApartado = descApartado;
        }

    }
}
