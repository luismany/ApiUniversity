using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.Data;
using University.BL.Data.Models;
using University.BL.DTOs;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using AutoMapper;
using System.Threading.Tasks;

namespace University_Api.Controllers
{
    public class DocentesController : ApiController
    {
        private IMapper mapper;
        private readonly DocentesService docentesService = new DocentesService(new DocentesRepository(UniversityDbContext.Create()));

        public DocentesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var listaDocentes = await docentesService.GetAll();

            var listaDocentesDTO= listaDocentes.Select( docente => mapper.Map<DocentesDTO>(docente));

            return Ok(listaDocentesDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var docente = await docentesService.GetById(id);

            if (docente == null)
                return BadRequest("El docente no existe");

            var docenteDTO = mapper.Map<DocentesDTO>(docente);
            return Ok(docenteDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insertar(DocentesDTO docentesDTO)
        {
            if (docentesDTO == null)
                return BadRequest("No se ingresaron datos ");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var nuevoDocente = mapper.Map<Docentes>(docentesDTO);
                nuevoDocente = await docentesService.Insert(nuevoDocente);
                return Ok(nuevoDocente);
            }
            catch (Exception ex){ return InternalServerError(ex); }
            
        }
        [HttpPut]
        public async Task<IHttpActionResult> Modificar(DocentesDTO docentesDTO, int id)
        {
            

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (docentesDTO.Id != id)
                return BadRequest("El Id a modificar no coincide");

            var flag = await docentesService.GetById(id);

            if (flag == null)
                return BadRequest("El Id a modificar no existe");

            try
            {
                var docenteModificado = mapper.Map<Docentes>(docentesDTO);
                docenteModificado = await docentesService.Update(docenteModificado);
                return Ok(docenteModificado);
            }
            catch (Exception ex){ return InternalServerError(ex); }

        }
        [HttpDelete]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var docente = await docentesService.GetById(id);

            if (docente == null)
                return BadRequest("El recurso a eliminar no existe");

            await docentesService.Delete(id);

            return Ok("Eliminado correctamente");
        }

    }

}
