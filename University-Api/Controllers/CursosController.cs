using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using University.BL.Data.Models;



namespace University_Api.Controllers
{
    
    public class CursosController : ApiController
    {
        private IMapper mapper;
        private readonly CursosServices cursosServices = new CursosServices(new CursosRepository(UniversityDbContext.Create()));

        public CursosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var listaCursos = await cursosServices.GetAll();
            
            var listaCursosDTO = listaCursos.Select(curso => mapper.Map<CursosDTO>(curso));
            return Ok(listaCursosDTO);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var curso =await cursosServices.GetById(id);

            if (curso == null)
                return NotFound();

            var cursoDTO = mapper.Map<CursosDTO>(curso);

            return Ok(cursoDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insertar(CursosDTO cursosDTO)
        {
            if (cursosDTO == null)
                return BadRequest("No hay datos para ingresar");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var nuevoCurso = mapper.Map<Cursos>(cursosDTO);

                nuevoCurso = await cursosServices.Insert(nuevoCurso);

                return Ok(nuevoCurso);
            }
            catch (Exception ex){ return InternalServerError(ex); }

            
        }
        [HttpPut]
        public async Task<IHttpActionResult> Modificar(CursosDTO cursosDTO, int id)
        {
            
            if (cursosDTO.Id != id)
                return BadRequest("El Id no coinside con el modelo a modifiar");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var flag = await cursosServices.GetById(id);
            if (flag == null)
                return BadRequest("El Id a modificar No existe");

            try
            {
                var cursoModificado = mapper.Map<Cursos>(cursosDTO);
                cursoModificado = await cursosServices.Update(cursoModificado);
                return Ok(cursoModificado);
            }
            catch (Exception ex){ return InternalServerError(ex); }

        }
        [HttpDelete]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var flag = await cursosServices.GetById(id);

            if (flag == null)
                return BadRequest("El registro a eliminar no existe");
            else
                try
                {
                    
                    await cursosServices.Delete(id);
                    return Ok("Registro eliminado con exito");
                }
                catch (Exception ex) { return InternalServerError(ex); }
        }
       

    }
}
