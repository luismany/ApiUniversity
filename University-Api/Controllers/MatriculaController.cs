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
using University.BL.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace University_Api.Controllers
{
    public class MatriculaController : ApiController
    {
        private readonly IMapper mapper;
        private readonly MatriculaService matriculaService = new MatriculaService(new MatriculaRepository(UniversityDbContext.Create()));

        public MatriculaController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var listaMatriculas = await matriculaService.GetAll();

            var listaMatriculasDTO = listaMatriculas.Select(matricula=> mapper.Map<MatriculaDTO>(matricula));

           return Ok(listaMatriculasDTO);

        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var matricula = await matriculaService.GetById(id);
            if (matricula == null)
                return BadRequest("La matricula no existe");

            var matriculaDTO = mapper.Map<MatriculaDTO>(matricula);
            return Ok(matriculaDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insertar(MatriculaDTO matriculaDTO)
        {
            if (matriculaDTO == null)
                return BadRequest("No se ingreso el modelo");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var nuevaMatricula = mapper.Map<Matricula>(matriculaDTO);

                nuevaMatricula = await matriculaService.Insert(nuevaMatricula);
                return Ok(nuevaMatricula);

            }
            catch (Exception ex) { return InternalServerError(ex); }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Modificar(MatriculaDTO matriculaDTO, int id)
        {
            if (matriculaDTO.Id != id)
                return BadRequest("El Id no coinside con el modelo a modificar");

            var flag = await matriculaService.GetById(id);
            if (flag == null)
                return BadRequest("El Id a modificar no existe");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var matriculaModificada = mapper.Map<Matricula>(matriculaDTO);
                await matriculaService.Update(matriculaModificada);
                return Ok(matriculaModificada);
            }
            catch (Exception ex){ return InternalServerError(ex); }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var flag = await matriculaService.GetById(id);
            if (flag == null)
                return BadRequest("El modelo a eliminar No existe");

            await matriculaService.Delete(id);
            return Ok("Eliminado correctamente");

        }
    }
}
