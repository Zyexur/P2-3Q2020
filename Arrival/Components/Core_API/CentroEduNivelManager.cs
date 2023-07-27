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
    public class CentroEduNivelManager : BaseManager
    {
        private CentroEduNivelCrudFactory crudCentroEduNivel;

        public CentroEduNivelManager()
        {
            crudCentroEduNivel = new CentroEduNivelCrudFactory();
        }

        public void Create(CentroEducativoNivel centroEduNivel)
        {
            try
            {
                var nivel = RetrieveAllById(centroEduNivel);

                if (nivel.Count == 0)
                {
                    crudCentroEduNivel.Create(centroEduNivel);
                }
                else
                {
                    throw new BusinessException(6);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<CentroEducativoNivel> RetrieveAll()
        {
            return crudCentroEduNivel.RetrieveAll<CentroEducativoNivel>();
        }

        public List<CentroEducativoNivel> RetrieveAllById(BaseEntity entity)
        {
            return crudCentroEduNivel.RetrieveAllById<CentroEducativoNivel>(entity);
        }

        public CentroEducativoNivel RetrieveById(CentroEducativoNivel nivel)
        {
            CentroEducativoNivel c = null;
            try
            {
                c = crudCentroEduNivel.Retrieve<CentroEducativoNivel>(nivel);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return c;
        }
    }
}
