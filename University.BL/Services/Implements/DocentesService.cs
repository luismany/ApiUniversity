using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Repositories;    


namespace University.BL.Services.Implements
{
    public class DocentesService: GenericService<Docentes>, IDocentesService
    {
        public DocentesService(IDocentesRepository docentesRepository):base(docentesRepository)
        {

        }
    }
}
