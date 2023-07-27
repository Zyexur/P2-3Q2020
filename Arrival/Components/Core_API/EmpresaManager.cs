using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class EmpresaManager : BaseManager

    {
        private EmpresaCrudFactory crudEmpresa;
        private UsuarioCrudFactory crudUsuario;
        private BitacoraCrudFactory crudBitacora;
        public EmpresaManager()
        {
            crudEmpresa = new EmpresaCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
            crudBitacora = new BitacoraCrudFactory();
        }
        public void Create(Empresa empresa, string cedulaFisica)
        {
            try
            {
                var accion = new Bitacora();

                if (empresa.Tipo == "ce")
                {
                    accion.Accion = "Centro educativo creado";
                    accion.CedulaFisica = cedulaFisica;
                    accion.Fecha = DateTime.Now;
                }
                else
                {
                    accion.Accion = "Empresa de transporte creada";
                    accion.CedulaFisica = cedulaFisica;
                    accion.Fecha = DateTime.Now;
                }

                var e = crudEmpresa.Retrieve<Empresa>(empresa);
                
                if (e != null) //empresa ya existe
                {
                    throw new Exception();
                }
                else
                {
                    crudEmpresa.Create(empresa);
                    crudUsuario.AsociarEmpresa(empresa.CedulaJuridica, cedulaFisica);
                    crudBitacora.Create(accion);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Update(Empresa empresa, string cedulaFisica)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Empresa actualizada",
                    CedulaFisica = cedulaFisica,
                    Fecha = DateTime.Now
                };
                var e = crudEmpresa.Retrieve<Empresa>(empresa);
                if (e == null) //empresa no existe
                {
                    //throw new BusinessException(0);
                }
                else
                {
                    crudEmpresa.Update(empresa);
                    crudBitacora.Create(accion);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Empresa empresa, string cedulaFisica)
        {
            try
            {
                var accion = new Bitacora
                {
                    Accion = "Empresa eliminada",
                    CedulaFisica = cedulaFisica,
                    Fecha = DateTime.Now
                };
                var e = crudEmpresa.Retrieve<Empresa>(empresa);
                if (e == null) //empresa no existe
                {
                    //throw new BusinessException(0);
                }
                else
                {
                    crudEmpresa.Delete(empresa);
                    crudBitacora.Create(accion);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Empresa> RetrieveAll()
        {
            return crudEmpresa.RetrieveAll<Empresa>();
        }

        public Empresa RetrieveById(Empresa empresa)
        {
            return crudEmpresa.Retrieve<Empresa>(empresa);
        }

        public List<Empresa> RetrieveAllCE()
        {
            return crudEmpresa.RetrieveAllCE<Empresa>();
        }
        public List<Empresa> RetrieveAllCEById(string cedulaTr)
        {
            return crudEmpresa.RetrieveAllCEById<Empresa>(cedulaTr);
        }

        public List<Empresa> RetrieveAllTrans()
        {
            return crudEmpresa.RetrieveAllTrans<Empresa>();
        }
        public List<Empresa> RetrieveAllTransById(string cedulaCe)
        {
            return crudEmpresa.RetrieveAllTransById<Empresa>(cedulaCe);
        }

        public List<Empresa> RetrieveEmpresaByUserId(string cedulaFisica)
        {
            return crudEmpresa.RetrieveEmpresaByUserId<Empresa>(cedulaFisica);
        }

        public List<Empresa> RetrieveEmpresasTransporteByCJ(string cedulajuridica)
        {
            return crudEmpresa.RetrieveEmpresasTransporteByCJ<Empresa>(cedulajuridica);
        }
    }
}
