using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Dtos
{
    public class MunicipioBE
    {
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public string NombreDepto { get; set; }
        public int PaisId { get; set; }
        public string NombrePais { get; set; }
    }
}
