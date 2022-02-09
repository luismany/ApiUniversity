using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.Data.Models;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using AutoMapper;
using System.Threading.Tasks;
using University.BL.Models;

namespace University_Api.Controllers
{
    public class CarreraController : ApiController
    {
        private readonly IMapper mapper;
        private readonly CarreraService carreraService = new CarreraService(new CarreraRepository(UniversityDbContext.Create()));

        public CarreraController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var listaCarreras = await carreraService.GetAll();
            var listaCarreasDTO = listaCarreras.Select(carrera => mapper.Map<CarrerasDTO>(carrera));

            return Ok(listaCarreasDTO);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var carrera = await carreraService.GetById(id);
            if (carrera==null)
                return BadRequest("La carrera no existe");

            var carreraDTO = mapper.Map<CarrerasDTO>(carrera);

            return Ok(carreraDTO);
            
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insertar(CarrerasDTO carrerasDTO)
        {
            if (carrerasDTO == null)
                return BadRequest("No se ingresaron datos para agregar");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var nuevaCarrera = mapper.Map<Carreras>(carrerasDTO);
                nuevaCarrera = await carreraService.Insert(nuevaCarrera);

                return Ok(nuevaCarrera);

            }
            catch (Exception ex){ return InternalServerError(ex); }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Modificar(CarrerasDTO carrerasDTO, int id)
        {
            
            if (carrerasDTO.Id != id)
                return Ok("El Id no coinside con la carrera a modificar");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carrera = await carreraService.GetById(id);
            if (carrera == null)
                return BadRequest("La carrera a modificar no existe");

            try
            {
                var carreramodificada = mapper.Map<Carreras>(carrerasDTO);

                await carreraService.Update(carreramodificada);

                return Ok(carreramodificada);
            }
            catch (Exception ex){ return InternalServerError(ex); }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var carrera = await carreraService.GetById(id);
            if (carrera == null)
                return BadRequest("La carrera que desea eliminar no existe");

            await carreraService.Delete(id);

            return Ok("Eliminado correctamente");
        }
    }
}
