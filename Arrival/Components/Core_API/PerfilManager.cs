using Data_Access.Crud;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Core_API
{
    public class PerfilManager : BaseManager
    {
        private PerfilCrudFactory crudPerfil;
        private UsuarioCrudFactory crudUsuario;

        public PerfilManager()
        {
            crudPerfil = new PerfilCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
        }

        public void Create(Perfil perfil)
        {
            crudPerfil.Create(perfil);
        }

        public List<Perfil> RetrieveAllById(BaseEntity entity)
        {
            return crudPerfil.RetrieveAllById<Perfil>(entity);
        }

        public void Update(Perfil perfil)
        {
            var mng = new UsuarioManager();
            var usuario = new Usuario
            {
                CedulaFisica = perfil.CedulaFisica
            };

            usuario = mng.RetrieveById(usuario);

            perfil.EstadoPerfil = usuario.EstadoUsuario;

            if (perfil.EstadoPerfil.Equals("ACTIVO"))
            {
                perfil.EstadoPerfil = "INACTIVO";
                crudPerfil.Update(perfil);
                usuario.EstadoUsuario = "INACTIVO";
               // crudUsuario.UpdatePerfil(usuario);
            }
            else
            {
                perfil.EstadoPerfil = "ACTIVO";
                crudPerfil.Update(perfil);
                usuario.EstadoUsuario = "ACTIVO";
               //crudUsuario.UpdatePerfil(usuario);
            }
        }
    }
}
