using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class EstudiantesRepository: GenericRepository<Estudiantes>, IEstudiantesRepository
    {
        public EstudiantesRepository(UniversityDbContext universityDbContext): base(universityDbContext)
        {

        }
    }
}
