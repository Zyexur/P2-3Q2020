using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Unidad : BaseEntity
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public DateTime Anno { get; set; }
        public string Tamano { get; set; }
        public int Capacidad { get; set; }
        public string Color { get; set; }
        public string IdEmpresa { get; set; }
        public int IdRuta { get; set; }
        public string IdChofer { get; set; }

        public Unidad()
        {
        }
    }
}
