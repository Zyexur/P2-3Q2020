using Data_Access.Crud;
using Entities;
using System.Collections.Generic;


namespace Core_API
{
    public class NivelManager : BaseManager
    {
        private NivelCrudFactory crudNivel;

        public NivelManager()
        {
            crudNivel = new NivelCrudFactory();
        }

        public List<Nivel> RetrieveAll()
        {
            return crudNivel.RetrieveAll<Nivel>();
        }

    }
}
