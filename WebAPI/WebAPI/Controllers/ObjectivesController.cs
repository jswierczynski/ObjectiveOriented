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
    [Route("api/Objectives")]
    public class ObjectivesController : Controller
    {
        private readonly ObjectivesContext _context;

        public ObjectivesController(ObjectivesContext context)
        {
            _context = context;
        }

        // GET: api/Objectives
        [HttpGet]
        public IEnumerable<Objective> GetObjectives()
        {
            return _context.Objectives;
        }

        // GET: api/Objectives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObjective([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objective = await _context.Objectives.SingleOrDefaultAsync(m => m.Id == id);

            if (objective == null)
            {
                return NotFound();
            }

            return Ok(objective);
        }

        // PUT: api/Objectives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjective([FromRoute] int id, [FromBody] Objective objective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objective.Id)
            {
                return BadRequest();
            }

            _context.Entry(objective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(id))
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

        // POST: api/Objectives
        [HttpPost]
        public async Task<IActionResult> PostObjective([FromBody] Objective objective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Objectives.Add(objective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjective", new { id = objective.Id }, objective);
        }

        // DELETE: api/Objectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjective([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objective = await _context.Objectives.SingleOrDefaultAsync(m => m.Id == id);
            if (objective == null)
            {
                return NotFound();
            }

            _context.Objectives.Remove(objective);
            await _context.SaveChangesAsync();

            return Ok(objective);
        }

        private bool ObjectiveExists(int id)
        {
            return _context.Objectives.Any(e => e.Id == id);
        }
    }
}