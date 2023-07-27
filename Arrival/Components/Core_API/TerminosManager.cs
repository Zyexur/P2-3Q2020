using System;
using System.Collections.Generic;
using Data_Access.Crud;
using Entities;
using Exceptions;

namespace Core_API
{
    public class TerminosManager
    {
        private TerminosCrudFactory crud;

        public TerminosManager()
        {
            crud = new TerminosCrudFactory();
        }

        public void Create(TerminosCondiciones tc)
        {
            crud.Create(tc);
        }

        public TerminosCondiciones Retrieve(TerminosCondiciones tc)
        {
            TerminosCondiciones terminos = null;
            try
            {
                terminos = crud.Retrieve<TerminosCondiciones>(tc);
                if (terminos == null)
                {
                    throw new Exception(); //cambiar por clase exceptions
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return terminos;
        }

        public List<TerminosCondiciones> RetrieveAll()
        {
            return crud.RetrieveAll<TerminosCondiciones>();
        }

        public void Update(TerminosCondiciones tc)
        {
            crud.Update(tc);
        }

        public void Delete(TerminosCondiciones tc)
        {
            crud.Delete(tc);
        }
    }
}