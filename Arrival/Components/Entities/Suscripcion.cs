using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Suscripcion : BaseEntity
    {
        public int IdSuscripcion { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public Empresa Empresa { get; set; }
        public Membresia Membresia { get; set; }

        public Suscripcion(string estado, Usuario usuario, Membresia membresia)
        {
            Estado = estado;
            Usuario = usuario;
            Membresia = membresia;
        }
        public Suscripcion(string estado, Empresa empresa, Membresia membresia)
        {
            Estado = estado;
            Empresa = empresa;
            Membresia = membresia;
        }
        public Suscripcion(int idSuscripcion, string estado)
        {
            IdSuscripcion = idSuscripcion;
            Estado = estado;
        }

        public Suscripcion()
        {
        }
    }
}
