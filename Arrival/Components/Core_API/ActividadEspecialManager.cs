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
    public class ActividadEspecialManager : BaseManager
    {
        //TODO: Archivar actividades especiales
        private ActividadEspecialCrudFactory crudActividad;

        public ActividadEspecialManager()
        {
            crudActividad = new ActividadEspecialCrudFactory();
        }

        public void Create(ActividadEspecial actividadEspecial)
        {
            try
            {
                if (actividadEspecial.Nombre.Equals("") || actividadEspecial.Desc.Equals(""))
                {
                    throw new BusinessException(2);
                }

                crudActividad.Create(actividadEspecial);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<ActividadEspecial> RetrieveAllById(BaseEntity entity)
        {
            return crudActividad.RetrieveAllById<ActividadEspecial>(entity);
        }

        public ActividadEspecial RetrieveById(ActividadEspecial actividad)
        {
            ActividadEspecial a = null;

            a = crudActividad.Retrieve<ActividadEspecial>(actividad);

            return a;
        }

        public void Update(ActividadEspecial actividadEspecial)
        {
            try
            {
                if (actividadEspecial.IdActividad == 0)
                {
                    throw new BusinessException(2);
                }

                if (actividadEspecial.Nombre.Equals("") || actividadEspecial.Desc.Equals(""))
                {
                    throw new BusinessException(2);
                }

                crudActividad.Update(actividadEspecial);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }

        public void Asociar(ActividadEspecial actividadEspecial)
        {
            try
            {
                crudActividad.Asociar(actividadEspecial);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

    }
}
