using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_API
{
    public class MembresiaManager : BaseManager
    {
        private MembresiaCrudFactory crudMembresia;

        public MembresiaManager()
        {
            crudMembresia = new MembresiaCrudFactory();
        }

        public void Create(Membresia membresia)
        {
            try
            {
                if (membresia.Nombre == "")
                {
                    throw new BusinessException(2);
                }

                if (membresia.Periodicidad == 0 || membresia.Monto == 0)
                {
                    throw new BusinessException(2);
                }

                crudMembresia.Create(membresia);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        
        }

        public List<Membresia> RetrieveAll()
        {
            return crudMembresia.RetrieveAll<Membresia>();
        }

        public Membresia RetrieveById(Membresia membresia)
        {
            Membresia m = null;

            m = crudMembresia.Retrieve<Membresia>(membresia);


            return m;
        }

        public void Update(Membresia membresia)
        {
            try
            {
                if (membresia.IdMembresia == 0)
                {
                    throw new BusinessException(2);
                }

                if (membresia.Nombre == "")
                {
                    throw new BusinessException(2);
                }

                if (membresia.Periodicidad == 0 || membresia.Monto == 0)
                {
                    throw new BusinessException(2);
                }

                crudMembresia.Update(membresia);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }        
        }

        public void Delete(Membresia membresia)
        {
            try
            {
                if (membresia.IdMembresia == 0)
                {
                    throw new BusinessException(2);
                }

                if (membresia.Nombre == "")
                {
                    throw new BusinessException(2);
                }

                if (membresia.Periodicidad == 0 || membresia.Monto == 0)
                {
                    throw new BusinessException(2);
                }

                crudMembresia.Delete(membresia);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }        
        }

    }
}
