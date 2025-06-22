using Microsoft.AspNetCore.Mvc;
using ApiTarefas.Models;
using System.Collections.Generic;
using System.Linq;
using ApiTarefas.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Controllers
{
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
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            return await _context.Tarefa.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);

            if (tarefa == null) return NotFound();

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Tarefa>>> PostTarefas(int id, Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefas), new {id = tarefa.Id}, tarefa);
        }

        [HttpPut("{id:int}")]
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
