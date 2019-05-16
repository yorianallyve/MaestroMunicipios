using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Model
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
