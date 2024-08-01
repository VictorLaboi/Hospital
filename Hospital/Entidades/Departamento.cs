using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entidades
{
    internal class Departamento
    {
        public Guid IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
