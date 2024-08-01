using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entidades
{
    internal class Registro
    {
        public Guid Id { get; set; }
        public DateOnly fecha { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public Guid Id_Paciente { get; set; }
        public Guid Id_Doctor { get; set; }
    }
}
