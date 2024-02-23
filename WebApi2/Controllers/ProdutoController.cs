using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2.Data;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly WAContext _context;
        public ProdutoController(WAContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ICollection<Produto>> Get()
        {
            return await _context.Produtos.OrderBy(p => p.preco).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if(produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpGet]
        [Route("byname")]
        public IActionResult GetByName(string nome)
        {
            var produto = _context.Produtos.Where(p => p.Nome == nome);
            if (produto == null) return NotFound();
            return Ok(produto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Produto produto)
        {
            var index = await _context.Produtos.FindAsync(id);
            if (index == null) return NotFound();

            index.Nome = produto.Nome;
            index.Descricao = produto.Descricao;
            index.Codigo = produto.Codigo;
            index.preco = produto.preco;

            _context.Produtos.Update(index);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) return NotFound();
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
