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

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetTodosLosProductos()
        {
            return await _context.Producto
                .Include(s => s.Sucursal)
                .Include(c => c.Categoria)
                .ToListAsync();
        }

        // GET: api/Productos/ProductoId - Obtiene el Producto solicitado, para pagina informacion detallada.
        [HttpGet("{productoId}")]
        public async Task<ActionResult<Producto>> GetProductoPorId(int productoId)
        {
            var query = await _context.Producto.FromSqlInterpolated($"SELECT * FROM producto WHERE productoId = {productoId}")
                        .Include(s => s.Sucursal)
                        .SingleOrDefaultAsync();

            if (query != null)
            {
                return query;
            }
            else
            {
                return NotFound();
            }
        }


        // POST: api/Productos/add/[Producto] -  Inserta un objeto Producto en la tabla producto.
        [HttpPost("add")]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
