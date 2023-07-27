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
    public class NivelesSeccionesManager : BaseManager
    {

        private NivelesSeccionesCrudFactory crudNivelesSecciones;

        public NivelesSeccionesManager()
        {
            crudNivelesSecciones = new NivelesSeccionesCrudFactory();
        }

        public List<NivelesSecciones> RetrieveAllById(BaseEntity entity)
        {
            return crudNivelesSecciones.RetrieveAllById<NivelesSecciones>(entity);
        }

    }
}
