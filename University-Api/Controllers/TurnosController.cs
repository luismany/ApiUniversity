using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.Models;
using University.BL.DTOs;
using University.BL.Data;
using University.BL.Repositories.Implements;
using AutoMapper;
using University.BL.Services.Implements;
using System.Threading.Tasks;

namespace University_Api.Controllers
{
    public class TurnosController : ApiController
    {
        private readonly IMapper mapper;
        private readonly TurnosService turnosService = new TurnosService(new TurnosRepository(UniversityDbContext.Create()));

        public TurnosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var listaTurnos = await turnosService.GetAll();

            var listaTurnosDTO =listaTurnos.Select(turno => mapper.Map<TurnosDTO>(turno));

            return Ok(listaTurnosDTO);

        }
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var turno = await turnosService.GetById(id);

            if (turno == null)
                return BadRequest("El turno no existe");

            var turnoDTO = mapper.Map<TurnosDTO>(turno);
            return Ok(turnoDTO);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Insertar(TurnosDTO turnosDTO)
        {
            if (turnosDTO == null)
                return BadRequest("El recurso esta vacio");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            try
            {
                var nuevoTurno = mapper.Map<Turnos>(turnosDTO);

                nuevoTurno = await turnosService.Insert(nuevoTurno);

                return Ok(nuevoTurno);
            }
            catch (Exception ex){ return InternalServerError(ex); }

           
        }
        [HttpPut]
        public async Task<IHttpActionResult> Modificar(TurnosDTO turnosDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (turnosDTO.Id != id)
                return BadRequest("El Id no coincide con el recurso a modificar");
            var turno = await turnosService.GetById(id);
            if (turno == null)
                return BadRequest("El recurso a modificar no existe");

            try
            {
                var turnoModificado = mapper.Map<Turnos>(turnosDTO);
                turnoModificado = await turnosService.Update(turnoModificado);
                return Ok(turnoModificado);

            }
            catch (Exception ex){ return InternalServerError(ex); }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Eliminar(int id)
        {
            var turno = await turnosService.GetById(id);
            if (turno == null)
                return BadRequest("El turno no existe");

            await turnosService.Delete(id);
            return Ok("Eliminado Correctamente");
        }
    }
}
