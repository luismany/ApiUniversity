using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Models;

namespace University.BL.Data
{
    public class UniversityDbContext: DbContext
    {
        public UniversityDbContext(): base("University_Api.Properties.Settings.CadenaConexion")
        {

        }

        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        


        public static UniversityDbContext Create()
        {
            return new UniversityDbContext();
        }
    }
}
