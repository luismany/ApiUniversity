using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.Repositories;


namespace University.BL.Services.Implements
{
    public class CursosServices: GenericService<Cursos>, ICursosService
    {
        public CursosServices(ICursosReposotory cursosReposotory): base(cursosReposotory)
        {

        }

        public Task Delete(Cursos flag)
        {
            throw new NotImplementedException();
        }
    }
}
