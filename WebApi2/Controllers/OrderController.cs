using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2.Data;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("pedido")]
    public class OrderController : Controller
    {
        private readonly WAContext _context;
        public OrderController(WAContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Order>> Get()
        {
            return await _context.Pedidos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
            if (id < 0) return NotFound();
            return Ok(pedido);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            _context.Pedidos.Add(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Order order)
        {
            var pedidoExiste = await _context.Pedidos.FindAsync(id);
            if (pedidoExiste == null) return NotFound();
            pedidoExiste.UserName = order.UserName;
            pedidoExiste.PrecoFrete = order.PrecoFrete;
            pedidoExiste.OrderItems = order.OrderItems;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var index = await _context.Pedidos.FindAsync(id);
            if (index == null) return NotFound();
            _context.Pedidos.Remove(index);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
