using Data_Access.Crud;
using Entities;
using System.Collections.Generic;


namespace Core_API
{
    public class SeccionManager : BaseManager
    {
        private SeccionCrudFactory crudSeccion;

        public SeccionManager()
        {
            crudSeccion = new SeccionCrudFactory();
        }

        public List<Seccion> RetrieveAll()
        {
            return crudSeccion.RetrieveAll<Seccion>();
        }
    }
}
