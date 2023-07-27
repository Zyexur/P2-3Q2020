using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pago : BaseEntity
    {
        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public double Monto { get; set; }
        public int Suscripcion { get; set; }

        public Pago(DateTime fechaPago, double monto, int suscripcion)
        {
            FechaPago = fechaPago;
            Monto = monto;
            Suscripcion = suscripcion;
        }

        public Pago(int idPago, DateTime fechaPago, double monto, int suscripcion)
        {
            IdPago = idPago;
            FechaPago = fechaPago;
            Monto = monto;
            Suscripcion = suscripcion;
        }

        public Pago(int idPago, DateTime fechaPago, double monto)
        {
            IdPago = idPago;
            FechaPago = fechaPago;
            Monto = monto;
        }

        public Pago()
        {
        }
    }
}
