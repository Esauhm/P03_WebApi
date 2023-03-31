using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P03_WebApi.Models;


namespace P03_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosReservaController : ControllerBase
    {
        private readonly EquiposContext _equipoContext;

        public EstadosReservaController(EquiposContext equipoContext)
        {
            _equipoContext = equipoContext;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<EstadosReserva> listadoEstadoReserva = _equipoContext.estados_reserva.ToList();

            if (listadoEstadoReserva.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoEstadoReserva);
        }

        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("Add")]
        public IActionResult crear([FromBody] EstadosReserva estadosReserva)
        {

            try
            {
                _equipoContext.estados_reserva.Add(estadosReserva);
                _equipoContext.SaveChanges();

                return Ok(estadosReserva);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region ACTUALIZAR - POST

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] EstadosReserva estadosReserva)
        {
            EstadosReserva? estadoReservaExistente = _equipoContext.estados_reserva.Find(id);

            if (estadoReservaExistente == null)
            {
                return NotFound();
            }

            estadoReservaExistente.estado = estadosReserva.estado;

            _equipoContext.Entry(estadoReservaExistente).State = EntityState.Modified;
            _equipoContext.SaveChanges();

            return Ok(estadoReservaExistente);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("detelet/{id}")]
        public IActionResult EliminarMarca(int id)
        {
            EstadosReserva? estadoReservaExistente = _equipoContext.estados_reserva.Find(id);

            if (estadoReservaExistente == null) return NotFound();


            _equipoContext.Entry(estadoReservaExistente).State = EntityState.Deleted;
            _equipoContext.SaveChanges();

            return Ok(estadoReservaExistente);

        }
        #endregion
    }
}
