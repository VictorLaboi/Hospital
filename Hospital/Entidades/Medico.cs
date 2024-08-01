using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entidades
{
    internal class Medico
    {
        public Guid DoctorId { get; set; }
        public string Nombre { get; set; }    
        public string Especialidad { get; set; }
        public Guid IdDepartamento { get; set;}
    }
}
