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
    public class RutaManager : BaseManager
    {
        private RutaCrudFactory crudRuta;

        public RutaManager()
        {
            crudRuta = new RutaCrudFactory();
        }

        public void Create(Ruta ruta)
        {
           
            try
            {
                if (ruta.NombreRuta.Equals("") || ruta.Hora.Equals(""))
                {
                    throw new BusinessException(2);
                }

                crudRuta.Create(ruta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);               
            }
        }

        public List<Ruta> RetrieveAllById(BaseEntity entity)
        {
            return crudRuta.RetrieveAllById<Ruta>(entity);
        }

        public Ruta RetrieveById(Ruta ruta)
        {
            Ruta r = null;

            r = crudRuta.Retrieve<Ruta>(ruta);


            return r;
        }

        public List<Ruta> RetrieveByCedula(BaseEntity entity)
        {
            return crudRuta.RetrieveAllByCedula<Ruta>(entity);
        }

        public void Update(Ruta ruta)
        {
            try
            {
                if (ruta.IdRuta == 0)
                {
                    throw new BusinessException(2);
                }

                if (ruta.NombreRuta == "" || ruta.Hora == "")
                {
                    throw new BusinessException(2);
                }

                crudRuta.Update(ruta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
      
        }

        public void Delete(Ruta ruta)
        {
            try
            {
                if (ruta.IdRuta == 0)
                {
                    throw new BusinessException(2);
                }

                if (ruta.NombreRuta == "" || ruta.Hora == "")
                {
                    throw new BusinessException(2);
                }

                crudRuta.Delete(ruta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            
        }

        public void Asociar(Ruta ruta)
        {
            try
            {
                crudRuta.Asociar(ruta);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}
