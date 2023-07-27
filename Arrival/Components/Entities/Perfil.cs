using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Perfil : BaseEntity
    {
        public string CedulaFisica{ get; set; }
        public string Rol { get; set; }
        public string EstadoPerfil { get; set; }

        public Perfil(string rol, string estadoPerfil)
        {
            Rol = rol;
            EstadoPerfil = estadoPerfil;
        }

        public Perfil(string cedulaFisica, string rol, string estadoPerfil)
        {
            CedulaFisica = cedulaFisica;
            Rol = rol;
            EstadoPerfil = estadoPerfil;
        }

        public Perfil()
        {
        }
    }
}
