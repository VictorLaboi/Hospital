using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entidades
{
    internal class Paciente
    {
        public Guid IdPaciente { get; set; }
        public string NombrePaciente { get; set; }

        public DateOnly FechaNacimiento { get; set; }
    }
}
