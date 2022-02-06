using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;

namespace University.BL.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int EstudianteId { get; set; }
        public int CarreraId { get; set; }
        public int TurnoId { get; set; }

        public virtual Estudiantes Estudiante { get; set; }
        public virtual Carreras Carrera { get; set; }
        public virtual Turnos Turno { get; set; }
    }
}
