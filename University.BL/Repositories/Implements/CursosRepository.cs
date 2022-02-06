using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class CursosRepository: GenericRepository<Cursos>, ICursosReposotory
    {
        public CursosRepository(UniversityDbContext universityDBContext): base(universityDBContext)
        {

        }
    }
}
