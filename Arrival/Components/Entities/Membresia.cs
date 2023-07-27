using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Membresia : BaseEntity
    {

        public int IdMembresia { get; set; }
        public string Nombre { get; set; }
        public int Periodicidad { get; set; }
        public double Monto { get; set; }

        public Membresia(int idMembresia, string nombre, int periodicidad, double monto)
        {
            IdMembresia = idMembresia;
            Nombre = nombre;
            Periodicidad = periodicidad;
            Monto = monto;
        }

        public Membresia(string nombre, int periodicidad, double monto)
        {
            Nombre = nombre;
            Periodicidad = periodicidad;
            Monto = monto;
        }

        public Membresia()
        {
        }
    }
}
