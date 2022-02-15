using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using University.BL.Models;
using University.BL.Data.Models;

namespace University.BL.Data.Models
{
    public class Cursos
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Curso { get; set; }
        public int Credito { get; set; }
        public int CarreraId { get; set; }
        public int DocenteId { get; set; }
        public int? RegularCuatrimestreId { get; set; }
        public int? EncuentrosCuatrimestreId { get; set; }


        public virtual Carreras Carrera { get; set; }
        public virtual Docentes Docente { get; set; }
        public virtual RegularCuatrimestre RegularCuatrimestre { get; set; }
        public virtual  EncuentrosCuatrimestre EncuentrosCuatrimestre { get; set; }
       

    }
}
