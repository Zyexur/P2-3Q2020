using System;

namespace Entities
{
    public class Factura : BaseEntity
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Monto { get; set; }

        public Factura(int idFactura, DateTime fechaFactura, string nombre, string cedula, string monto)
        {
            IdFactura = idFactura;
            FechaFactura = fechaFactura;
            Nombre = nombre;
            Cedula = cedula;
            Monto = monto;
        }

        public Factura(DateTime fechaFactura, string nombre, string cedula, string monto)
        {
            FechaFactura = fechaFactura;
            Nombre = nombre;
            Cedula = cedula;
            Monto = monto;
        }

        public Factura()
        {
        }
    }
}
