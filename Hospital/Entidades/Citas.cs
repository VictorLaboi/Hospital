using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hospital.Entidades
{
    internal class Citas
    {
        public Guid idCita { get; set;}
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public Guid PacienteId { get; set; }
        public Guid DoctorId{ get; set;}
    }
}
