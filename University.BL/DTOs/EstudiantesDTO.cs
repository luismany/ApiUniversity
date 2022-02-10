using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class EstudiantesDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(16)]
        public string Cedula { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        

        public string FullName
        {
            get { return string.Format("{0} {1}", Apellido, Nombre); }
        }
    }
}
