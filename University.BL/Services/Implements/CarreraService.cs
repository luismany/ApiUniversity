using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class CarreraService: GenericService<Carreras>, ICarreraService
    {
        public CarreraService(ICarreraRepository carreraRepository):base(carreraRepository)
        {

        }
    }
}
