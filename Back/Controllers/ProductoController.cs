using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Back.Data;
using Back.Data.Dto;
using Back.Data.Customs;
using Back.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly CineDBContext _dbContext;

        public ProductoController(CineDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista() 
        {
            var lista = await _dbContext.Usuarios.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new { value = lista });
        }
        
    }
}
