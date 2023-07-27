using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class BitacoraManager : BaseManager
    {
        private BitacoraCrudFactory crudBitacora;

        public BitacoraManager()
        {
            crudBitacora = new BitacoraCrudFactory();
        }

        public void Create(Bitacora bitacora)
        {
            try
            {
                crudBitacora.Create(bitacora);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Bitacora> RetrieveAll()
        {
            return crudBitacora.RetrieveAll<Bitacora>();
        }

        public List<Bitacora> RetrieveAllById(BaseEntity entity)
        {
            return crudBitacora.RetrieveAllById<Bitacora>(entity);
        }

    }
}
