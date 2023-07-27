namespace Entities
{
    public class Empresa : BaseEntity
    {
        public string CedulaJuridica { get; set; }
        public string NombreJuridico { get; set; }
        public string Correo { get; set; }
        public string NumTelefono { get; set; }
        public string Imagen { get; set; }
        public string Coordenada { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public Empresa(string cedulaJuridica, string nombreJuridico, string correo, string numTelefono, string coordenada, string tipo, string estado)
        {
            CedulaJuridica = cedulaJuridica;
            NombreJuridico = nombreJuridico;
            Correo = correo;
            NumTelefono = numTelefono;
            Coordenada = coordenada;
            Tipo = tipo;
            Estado = estado;
        }

        public Empresa(string cedulaJuridica, string nombreJuridico, string correo, string numTelefono, string imagen, string coordenada, string tipo, string estado) : this(cedulaJuridica, nombreJuridico, correo, numTelefono, imagen, coordenada, estado)
        {
            CedulaJuridica = cedulaJuridica;
            NombreJuridico = nombreJuridico;
            Correo = correo;
            NumTelefono = numTelefono;
            Imagen = imagen;
            Coordenada = coordenada;
            Tipo = tipo;
            Estado = estado;
        }

        public Empresa(string cedulaJuridica, string nombreJuridico, string correo, string numTelefono, string tipo, string estado)
        {
            CedulaJuridica = cedulaJuridica;
            NombreJuridico = nombreJuridico;
            Correo = correo;
            NumTelefono = numTelefono;
            Tipo = tipo;
            Estado = estado;
        }

        public Empresa()
        {
        }
    }
}
