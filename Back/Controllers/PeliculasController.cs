using Back.Data.Models;
using Back.Data.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {

        IPeliculaService _service;

        public PeliculasController(IPeliculaService service)
        {
            _service = service;
        }

        // GET: api/<PeliculasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.ObtenerPeliculas());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<PeliculasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(id > 0)
                {
                    var pelicula = await _service.ObtenerPeliculaPorId(id);
                    if (pelicula != null)
                    {
                        return Ok(pelicula);
                    }
                    else
                    {
                        return NotFound("Pelicula no encotrada");
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

        // POST api/<PeliculasController>
        [HttpPost]
        public IActionResult Post([FromBody] Pelicula pelicula)
        {
            try
            {
                if (ValidarPelicula(pelicula))
                {
                    if (_service.GuardarPelicula(pelicula).Result)
                    {
                        return Ok("Pelicula agregada correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido agregar la pelicula");
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

        private bool ValidarPelicula(Pelicula pelicula)
        {
            return  !string.IsNullOrEmpty(pelicula.Titulo) && 
                    !string.IsNullOrEmpty(pelicula.Portada) && 
                    pelicula.DuracionMin > 0 && 
                    pelicula.IdGenero > 0 &&
                    pelicula.IdDirector > 0 &&
                    pelicula.IdClasificacion > 0 &&
                    pelicula.IdIdioma > 0;
        }

        // PUT api/<PeliculasController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Pelicula pelicula)
        {
            try
            {
                if (ValidarPelicula(pelicula))
                {
                    if (_service.GuardarPelicula(pelicula).Result)
                    {
                        return Ok("Pelicula actualizada correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido actualizar la pelicula");
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

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(id > 0)
                {
                    if (_service.EliminarPelicula(id).Result)
                    {
                        return Ok("Pelicula eliminada correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido eliminar la pelicula");
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
