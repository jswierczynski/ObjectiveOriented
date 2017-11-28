using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tasks")]
    public class TasksController : Controller
    {
        private readonly ObjectivesContext _context;

        public TasksController(ObjectivesContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<ObjectiveTask> GetTasks()
        {
			return _context.Tasks.Include("ParentObjective").Include("ParentTask");
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObjectiveTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objectiveTask = await _context.Tasks
				.Include("ParentObjective").Include("ParentTask")
				.SingleOrDefaultAsync(m => m.Id == id);

            if (objectiveTask == null)
            {
                return NotFound();
            }

			return Ok(objectiveTask);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectiveTask([FromRoute] int id, [FromBody] ObjectiveTask objectiveTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objectiveTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(objectiveTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveTaskExists(id))
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

        // POST: api/Tasks
        [HttpPost]
        public async Task<IActionResult> PostObjectiveTask([FromBody] BaseObjectiveTaskBinding task)
        {
            if	(!ModelState.IsValid || 
				(task.ParentTaskId > 0 && task.ParentObjectiveID > 0))
            {
                return BadRequest(ModelState);
            }

			ObjectiveTask objectiveTask = new ObjectiveTask(task, _context);

            _context.Tasks.Add(objectiveTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectiveTask", new { id = objectiveTask.Id }, objectiveTask);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectiveTask([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objectiveTask = await _context.Tasks.SingleOrDefaultAsync(m => m.Id == id);
            if (objectiveTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(objectiveTask);
            await _context.SaveChangesAsync();

            return Ok(objectiveTask);
        }

        private bool ObjectiveTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}