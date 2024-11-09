using Back.Data.Models;
using Back.Data.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionesController : ControllerBase
    {
        IFuncionService _service;

        public FuncionesController(IFuncionService service)
        {
            _service = service;
        }


        // GET: api/<FuncionesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.ObtenerFunciones());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<FuncionesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    return Ok(await _service.ObtenerFuncionesPorId(id));
                }
                else
                {
                    return BadRequest("Dato requerido ingresado incorrectamente!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Dia")]
        public async Task<IActionResult> GetAll([FromQuery] int dia)
        {
            try
            {
                return Ok(await _service.ObtenerFuncionesPorDia(dia));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<FuncionesController>
        [HttpPost]
        public IActionResult Post([FromBody] Funcione funcion)
        {
            try
            {
                if (ValidarFuncion(funcion))
                {
                    if (_service.Guardar(funcion).Result)
                    {
                        return Ok("Transaccion realizada correctamente!");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido realizar la transaccion");
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

        private bool ValidarFuncion(Funcione funcion)
        {
            return funcion.CodFuncion > 0 && funcion.Dia > 0;
        }



        [HttpPut]
        public IActionResult Put([FromBody] Funcione funcion)
        {
            try
            {
                if (ValidarFuncion(funcion))
                {
                    if (_service.Guardar(funcion).Result)
                    {
                        return Ok("Transaccion actualizada correctamente!");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido actualizar la transaccion");
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

        // DELETE api/<FuncionesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (_service.Eliminar(id).Result)
                    {
                        return Ok("Transaccion eliminada correctamente");
                    }
                    else
                    {
                        return StatusCode(500, "No se ha podido eliminar la transaccion");
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
