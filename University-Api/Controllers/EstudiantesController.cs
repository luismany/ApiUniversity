using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using University.BL.Data.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace University_Api.Controllers
{
    public class EstudiantesController : ApiController
    {
        private IMapper mapper;
        private readonly EstudiantesService estudiantesService = new EstudiantesService(new EstudiantesRepository(UniversityDbContext.Create()));

        public EstudiantesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

       [HttpGet]
       public async Task<IHttpActionResult> GetAll()
        {
            var listaEstudiantes = await estudiantesService.GetAll();
            var listaEstudiantesDTO = listaEstudiantes.Select(esttudiante => mapper.Map<EstudiantesDTO>(esttudiante));
            return Ok(listaEstudiantesDTO);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var estudiante = await estudiantesService.GetById(id);
            if (estudiante == null)
                return BadRequest("El Id no existe");

            try
            {
                var estudianteDTO = mapper.Map<Estudiantes>(estudiante);

                return Ok(estudianteDTO);
            }
            catch (Exception ex){ return InternalServerError(ex); }
            
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insertar(EstudiantesDTO estudiantesDTO)
        {
            if (estudiantesDTO == null)
                return BadRequest("No hay datos para Agregar");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var nuevoEstudiante = mapper.Map<Estudiantes>(estudiantesDTO);
                nuevoEstudiante = await estudiantesService.Insert(nuevoEstudiante);
                return Ok(nuevoEstudiante);
            }
            catch (Exception ex){ return InternalServerError(ex); } 
        }
        [HttpPut]
        public async Task<IHttpActionResult> Modificar(EstudiantesDTO estudiantesDTO, int id)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (estudiantesDTO.Id != id)
                return BadRequest("El Id no coincide");

            var flag = await estudiantesService.GetById(id);

            if (flag == null)
                return BadRequest("El Id a modificar no existe");

            try
            {
                var estudianteModificado = mapper.Map<Estudiantes>(estudiantesDTO);
                var estudianteModificadoDTO = await estudiantesService.Update(estudianteModificado);

                return Ok(estudianteModificadoDTO);
            }
            catch (Exception ex){ return InternalServerError(ex); }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var flag = await estudiantesService.GetById(id);
            if (flag == null)
                return BadRequest("El recurso a eliminar no existe");

            try
            {
                await estudiantesService.Delete(id);
                return Ok("Eliminado Correctamente");
            }
            catch (Exception ex){ return InternalServerError(ex); }

        }
    }
}
