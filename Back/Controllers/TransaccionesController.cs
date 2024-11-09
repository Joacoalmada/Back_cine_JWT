using Back.Data.Models;
using Back.Data.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        ITransaccionService _service;

        public TransaccionesController(ITransaccionService service)
        {
            _service = service;
        }


        // GET: api/<TransaccionesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.ObtenerTransacciones());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TransaccionesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(id > 0)
                {
                    return Ok(await _service.ObtenerTransaccionPorId(id));
                }
                else
                {
                    return BadRequest("Dato requerido ingresado incorrectamente!");
                }
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("FechaCompra")]
        public async Task<IActionResult> Get([FromQuery] DateTime fecha)
        {
            try
            {
                return Ok(await _service.ObtenerTransaccionesPorFecha(fecha));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        } 

        // POST api/<TransaccionesController>
        [HttpPost]
        public IActionResult Post([FromBody] Transaccione transaccion)
        {
            try
            {
                if (ValidarTransaccion(transaccion))
                {
                    if (_service.Guardar(transaccion).Result)
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

        private bool ValidarTransaccion(Transaccione transaccion)
        {
            return transaccion.CantidadTicket > 0 && transaccion.FechaCompra >= DateTime.Now;
        }

        // PUT api/<TransaccionesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Transaccione transaccion)
        {
            try
            {
                if (ValidarTransaccion(transaccion))
                {
                    if (_service.Guardar(transaccion).Result)
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

        // DELETE api/<TransaccionesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(id > 0)
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
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
