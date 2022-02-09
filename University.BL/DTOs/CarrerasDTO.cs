using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CarrerasDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string NombreCarrera { get; set; }
    }
}
