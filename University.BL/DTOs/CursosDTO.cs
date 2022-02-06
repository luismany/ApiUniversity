using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace University.BL.DTOs
{
    public class CursosDTO
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage ="El Curso es requerido")]
        [StringLength(30)]
        public string Curso { get; set; }
        [Required(ErrorMessage ="El campo Credito es requerido")]
        public int Credito { get; set; }
        public int CarreraId { get; set; }

        public virtual CarrerasDTO Carrera { get; set; }
    }
}
