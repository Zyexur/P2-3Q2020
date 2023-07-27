using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Documento : BaseEntity
    {
        public int IdDocumento { get; set; }
        public string Ruta { get; set; }
        public Usuario Usuario { get; set; }
        public Empresa Empresa { get; set; }

        public Documento(string ruta, Usuario usuario)
        {
            Ruta = ruta;
            Usuario = usuario;
        }

        public Documento(string ruta, Empresa empresa)
        {
            Ruta = ruta;
            Empresa = empresa;
        }

        public Documento(int idDocumento, string ruta)
        {
            IdDocumento = idDocumento;
            Ruta = ruta;
        }

        public Documento()
        {
        }
    }
}
