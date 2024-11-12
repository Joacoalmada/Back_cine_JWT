using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back.Controllers;
using Back.Data;
using Microsoft.AspNetCore.Authorization;
using Back.Data.Dto;
using Back.Data.Customs;
using Back.Data.Models;
using Back.Data.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly CineDBContext _dbContext;
        private readonly Utilidades _utilidades;

        public AcessoController(CineDBContext dbContext, Utilidades utilidades)
        {
            _dbContext = dbContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrar")]

        public async Task<IActionResult> Registrarse(DtoUsuario us)
        {
            var ModeloUsuario = new Usuario
            {
                IdUsuario = us.Id,
                Nombre = us.Nombre,
                Apellido = us.Apellido,
                Email = us.Correo,
                Contrasena = _utilidades.encriptarSHA256(us.clave)
            };

            await _dbContext.Usuarios.AddAsync(ModeloUsuario);
            await _dbContext.SaveChangesAsync();

            if(ModeloUsuario.IdUsuario != 0)
                return StatusCode(StatusCodes.Status200OK, new {isSuccess = true});
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });

            
            
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(LoginDto login) 
        {
            var usuarioEncontrado = await _dbContext.Usuarios.Where(u => u.Email == login.Correo && u.Contrasena == _utilidades.encriptarSHA256(login.Clave)).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado) });
        }
    }

   
}
