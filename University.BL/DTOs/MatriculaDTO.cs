using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class MatriculaDTO
    {
        public int Id { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int EstudianteId { get; set; }
        public int CarreraId { get; set; }
        public int TurnoId { get; set; }

        public virtual EstudiantesDTO Estudiante { get; set; }
        public virtual CarrerasDTO Carrera { get; set; }
        public virtual TurnosDTO Turno { get; set; }
    }
}
