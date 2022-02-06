using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class EstudiantesService: GenericService<Estudiantes>, IEstudiantesService
    {
        public EstudiantesService(IEstudiantesRepository estudiantesRepository): base(estudiantesRepository)
        {

        }
    }
}
