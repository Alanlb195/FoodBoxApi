using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodBoxApi.Models.Database;

namespace FoodBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly FoodBoxContext _context;

        public ProductosController(FoodBoxContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        public async Task<ActionResult<IEnumerable<Producto>>> GetTodosLosProductos()
        {
            return await _context.Productos
                .Include(s => s.Sucursal)
                .Include(c => c.Categoria)
                .ToListAsync();
        }
    }
}
