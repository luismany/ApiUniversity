using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data.Models;
using University.BL.DTOs;
using AutoMapper;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration( cfg => {

                cfg.CreateMap<Cursos, CursosDTO>(); //get
                cfg.CreateMap<CursosDTO, Cursos>();// post, put

                cfg.CreateMap<Estudiantes, EstudiantesDTO>();
                cfg.CreateMap<EstudiantesDTO, Estudiantes>();

                cfg.CreateMap<Docentes, DocentesDTO>();
                cfg.CreateMap<DocentesDTO, Docentes>();

                cfg.CreateMap<Turnos, TurnosDTO>();
                cfg.CreateMap<TurnosDTO, Turnos>();

                cfg.CreateMap<Carreras, CarrerasDTO>();
                cfg.CreateMap<CarrerasDTO, Carreras>();

                cfg.CreateMap<Matricula, MatriculaDTO>();
                cfg.CreateMap<MatriculaDTO, Matricula>();
            
            });

        }
        
    }
}
