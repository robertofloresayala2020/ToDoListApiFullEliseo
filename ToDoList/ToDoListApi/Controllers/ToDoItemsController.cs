using App.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly TareasContext _context;

        public TareasController(TareasContext context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var Tarea = await _context.Tareas.FindAsync(id);

            if (Tarea == null)
            {
                return NotFound();
            }

            return Tarea;
        }

        // POST: api/Tareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
        {
            try
            {
                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Tareas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, Tarea Tarea)
        {
            if (id != Tarea.Id)
            {
                return BadRequest();
            }

            _context.Entry(Tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
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

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var Tarea = await _context.Tareas.FindAsync(id);
            if (Tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(Tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.Id == id);
        }
    }
}
