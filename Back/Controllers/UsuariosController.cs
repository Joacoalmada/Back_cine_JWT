using Back.Data.Models;
using Back.Data.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.ObtenerUsuarios());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(id > 0)
                {
                    return Ok(await _service.ObtenerUsuarioPorId(id));
                }
                else
                {
                    return BadRequest("Dato requerido ingresado incorrectamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UsuariosController>
        [HttpGet("buscar")]
        public async Task<IActionResult> Get([FromQuery]string nombre, [FromQuery]string apellido)
        {
            try
            {
                if(ValidarNombre(nombre, apellido))
                {
                    return Ok(await _service.ObtenerUsuarioPorNombre(nombre, apellido));
                }
                else
                {
                    return BadRequest("Datos requeridos ingresados incorrectamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool ValidarNombre(string nombre, string apellido)
        {
            return !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (ValidarUsuario(usuario))
                {
                    if (_service.GuardarUsuario(usuario).Result)
                    {
                        return Ok("Usuario guardado correctamente!");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido guardar el usuario");
                    }
                }
                else
                {
                    return BadRequest("Datos requeridos ingresados incorrectamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool ValidarUsuario(Usuario usuario)
        {
            return ValidarNombre(usuario.Nombre, usuario.Apellido) && ValidarCampoVacio(usuario.Email) && ValidarCampoVacio(usuario.Contrasena);
        }

        private bool ValidarCampoVacio(string campo)
        {
            return !string.IsNullOrEmpty(campo);
        }

        // PUT api/<UsuariosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario)
        {
            try
            {
                if (ValidarUsuario(usuario))
                {
                    if (_service.GuardarUsuario(usuario).Result)
                    {
                        return Ok("Usuario actualizado correctamente!");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido actualizar el usuario");
                    }
                }
                else
                {
                    return BadRequest("Datos requeridos ingresados incorrectamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(id > 0)
                {
                    if (_service.EliminarUsuario(id).Result)
                    {
                        return Ok("Usuario eliminado correctamente!");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido eliminar el usuario");
                    }
                }
                else
                {
                    return BadRequest("Dato requerido ingresado incorrectamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
