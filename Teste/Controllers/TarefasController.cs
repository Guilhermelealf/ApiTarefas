using Microsoft.AspNetCore.Mvc;
using Teste.Models;
using Teste.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Teste.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/tarefas")]
    public class TarefasController : ControllerBase
    {

        private readonly TarefaDbContext _context;

        public TarefasController(TarefaDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            if(_context.Tarefa == null) return NotFound();
            
            return await _context.Tarefa.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            if (_context.Tarefa == null) return NotFound();

            var tarefa = await _context.Tarefa.FindAsync(id);

            if (tarefa == null) return NotFound();

            return Ok(tarefa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Tarefa>>> PostTarefas(int id, Tarefa tarefa)
        {
            if (_context.Tarefa == null) return Problem("Erro ao criar um produto, contate o suporte");

            if (!ModelState.IsValid)
            {
                return ValidationProblem(new ValidationProblemDetails(ModelState)
                {
                    Title = "Um ou mais erros de validação ocorreram!"
                });
            }

            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefas), new {id = tarefa.Id}, tarefa);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutTarefa(int id, Tarefa tarefa)
        {
            if(id != tarefa.Id) return BadRequest();

            _context.Entry(tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!await _context.Tarefa.AnyAsync(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);

            if (tarefa == null) return NotFound();

            _context.Tarefa.Remove(tarefa);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
