using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {

        private readonly AplicationDBcontext _context;
        public TodoListController(AplicationDBcontext context)
        {
            _context = context;
        }

        // GET: api/<TodoListController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _context.tareas.FromSqlRaw("sp_ListaTareas").ToListAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<TodoListController>
        [HttpPost]
        public async Task<ActionResult<TodoList>> Post([FromBody] TodoList newTodoList)
        {
            try
            {
                _context.tareas.Add(newTodoList);
                await _context.SaveChangesAsync(); 

                return StatusCode(201, newTodoList);
            }
            catch (Exception) 
            {
                return StatusCode(500);
            }
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoList updateTodoList)
        {
            try
            {
                if (updateTodoList == null)
                {
                    return StatusCode(404);
                }
                if (id != updateTodoList.IdTarea)
                {
                    return BadRequest(400);
                }
                _context.Update(updateTodoList);
                await _context.SaveChangesAsync();

                return Ok(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var task = await _context.tareas.FindAsync(id);

                if (task == null)
                {
                    return NotFound(404);
                }

                _context.tareas.Remove(task);
                await _context.SaveChangesAsync();

                return Ok(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{estado}")]
        public async Task<IActionResult> Get(string estado)
        {
            try
            {
                var tasks = await _context.tareas
                    .FromSqlRaw("FiltrarTareasPorEstado @estado", new SqlParameter("@estado", estado))
                    .ToListAsync();
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
