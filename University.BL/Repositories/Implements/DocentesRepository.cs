using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Data;

namespace University.BL.Repositories.Implements
{
    public class DocentesRepository: GenericRepository<Docentes>, IDocentesRepository
    {
        public DocentesRepository(UniversityDbContext universityDbContext):base(universityDbContext)
        {

        }
    }
}
