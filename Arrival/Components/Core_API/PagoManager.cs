using Data_Access.Crud;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_API
{
    public class PagoManager : BaseManager
    {
        private PagoCrudFactory crudPago;

        public PagoManager()
        {
            crudPago = new PagoCrudFactory();
        }

        public void Create(Pago pago)
        {
            crudPago.Create(pago);
        }

        public List<Pago> RetrieveAll()
        {
            return crudPago.RetrieveAll<Pago>();
        }

        public Pago RetrieveById(Pago pago)
        {
            Pago p = null;
            p = crudPago.Retrieve<Pago>(pago);
            return p;
        }

        public void Delete(Pago pago)
        {
            crudPago.Delete(pago);
        }

    }
}
