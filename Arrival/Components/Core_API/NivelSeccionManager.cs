using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class NivelSeccionManager : BaseManager
    {
        private NivelSeccionCrudFactory crudNivelSeccion;

        public NivelSeccionManager()
        {
            crudNivelSeccion = new NivelSeccionCrudFactory();
        }
        
        public void Create(NivelSeccion nivelSeccion)
        {
            try
            {
                var mng = new CentroEduNivelManager();

                var n = new CentroEducativoNivel
                {
                    IdCentroEdu = nivelSeccion.IdCentroEdu,
                    IdNivel = nivelSeccion.IdNivel
                };

                CentroEducativoNivel result = mng.RetrieveById(n);

                if (result != null)
                {
                    var mngNivel = new NivelSeccionManager();
                    nivelSeccion.IdCentroNivel = result.IdCentroNivel;
                    var res = mngNivel.RetrieveAllById(nivelSeccion);

                    if (res.Count == 0)
                    {
                        crudNivelSeccion.Create(nivelSeccion);
                    }
                    else
                    {
                        throw new BusinessException(4);
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<NivelSeccion> RetrieveAllById(BaseEntity entity)
        {
            return crudNivelSeccion.RetrieveAllById<NivelSeccion>(entity);
        }

        public List<NivelSeccion> RetrieveAll()
        {
            return crudNivelSeccion.RetrieveAll<NivelSeccion>();
        }
    }
}
