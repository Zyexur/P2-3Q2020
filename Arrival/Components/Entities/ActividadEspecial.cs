using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ActividadEspecial : BaseEntity
    {
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
        public string Desc { get; set; }
        public string CoorInicial { get; set; }
        public string CoorFinal { get; set; }
        public string CentroEducativo { get; set; }
        public string Estudiante { get; set; }
        public string EmpresaTransporte { get; set; }

        public ActividadEspecial(string nombre, string desc, string coorFinal, string centroEducativo)
        {
            Nombre = nombre;         
            Desc = desc;
            CoorFinal = coorFinal;
            CentroEducativo = centroEducativo;
        }

        public ActividadEspecial(int idActividad, string nombre, string desc, string coorInicial, string coorFinal, string centroEducativo)
        {
            IdActividad = idActividad;
            Nombre = nombre;
            Desc = desc;
            CoorInicial = coorInicial;
            CoorFinal = coorFinal;
            CentroEducativo = centroEducativo;
        }

        public ActividadEspecial()
        {
        }
    }
}
