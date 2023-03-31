using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P03_WebApi.Models;

namespace P03_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly EquiposContext _equipoContext;

        public UsuariosController(EquiposContext equipoContext)
        {
            _equipoContext = equipoContext;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            var listadoUsuarios = (from usuario in _equipoContext.usuarios 
                                   join carrera in _equipoContext.carreras on usuario.carrera_id equals carrera.carrera_id
                                   select new
                                   {
                                       usuario.nombre,
                                       usuario.documento,
                                       usuario.tipo,
                                       usuario.carnet,
                                       carrera.nombre_carrera
                                   }).ToList();

            if (listadoUsuarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoUsuarios);
        }
        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("Add")]
        public IActionResult Crear([FromBody] Usuario _usuario)
        {

            try
            {
                _equipoContext.usuarios.Add(_usuario);
                _equipoContext.SaveChanges();

                return Ok(_usuario);

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
        public IActionResult actualizar(int id, [FromBody] Usuario _usuario)
        {
            Usuario? usuarioExistente = _equipoContext.usuarios.Find(id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.nombre = _usuario.nombre;
            usuarioExistente.documento = _usuario.documento;
            usuarioExistente.tipo = _usuario.tipo;
            usuarioExistente.carnet = _usuario.carnet;
            usuarioExistente.carrera_id = _usuario.carrera_id;

            _equipoContext.Entry(usuarioExistente).State = EntityState.Modified;
            _equipoContext.SaveChanges();

            return Ok(usuarioExistente);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("detelet/{id}")]
        public IActionResult EliminarTipoEquipo(int id)
        {
            Usuario? usuarioExistente = _equipoContext.usuarios.Find(id);

            if (usuarioExistente == null) return NotFound();

            _equipoContext.Entry(usuarioExistente).State = EntityState.Deleted;
            _equipoContext.SaveChanges();

            return Ok(usuarioExistente);

        }
        #endregion

    }
}
