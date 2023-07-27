using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : BaseEntity
    {
        public string CedulaFisica { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string NumTelefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Imagen { get; set; }
        public string Codigo { get; set; }
        public string Contrasenna { get; set; }
        public string EstadoUsuario { get; set; }
        public string Coordenada { get; set; }
        public string Rol { get; set; }
        public string Fecha { get { return FechaNacimiento.ToShortDateString(); } }
       
    public Usuario()
    {
    }

    public Usuario(string cedulaFisica, string nombre, string apellido, string correo, string numTelefono, DateTime fechaNacimiento, string coordenada, string rol)
    {
        CedulaFisica = cedulaFisica;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        NumTelefono = numTelefono;
        FechaNacimiento = fechaNacimiento;
        Coordenada = coordenada;
        Rol = rol;
    }

    public Usuario(string cedulaFisica, string nombre, string apellido, string correo, string numTelefono, DateTime fechaNacimiento, string imagen, string codigo, string contrasenna, string estadoUsuario, string coordenada)
    {
        CedulaFisica = cedulaFisica;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        NumTelefono = numTelefono;
        FechaNacimiento = fechaNacimiento;
        Imagen = imagen;
        Codigo = codigo;
        Contrasenna = contrasenna;
        EstadoUsuario = estadoUsuario;
        Coordenada = coordenada;
    }
}
}
