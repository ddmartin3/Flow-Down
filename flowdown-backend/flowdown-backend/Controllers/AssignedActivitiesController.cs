using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flowdown_backend;
using flowdown_backend.Models;

namespace flowdown_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedActivitiesController : ControllerBase
    {
        private readonly LessonContext _context;

        public AssignedActivitiesController(LessonContext context)
        {
            _context = context;
        }

        // GET: api/AssignedActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignedActivity>>> GetAssignedActivity()
        {
            return await _context.AssignedActivity.ToListAsync();
        }

        [HttpGet("{lessonId}")]
        public IEnumerable<AssignedActivity> Get([FromRoute] int lessonId)
        {
            return _context.AssignedActivity.Where(a => a.LessonId == lessonId);
        }

        // PUT: api/AssignedActivities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignedActivity(int id, AssignedActivity assignedActivity)
        {
            if (id != assignedActivity.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignedActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedActivityExists(id))
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

        // POST: api/AssignedActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AssignedActivity>> PostAssignedActivity(AssignedActivity assignedActivity)
        {
            _context.AssignedActivity.Add(assignedActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignedActivity", new { id = assignedActivity.Id }, assignedActivity);
        }

        // DELETE: api/AssignedActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignedActivity(int id)
        {
            var assignedActivity = await _context.AssignedActivity.FindAsync(id);
            if (assignedActivity == null)
            {
                return NotFound();
            }

            _context.AssignedActivity.Remove(assignedActivity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignedActivityExists(int id)
        {
            return _context.AssignedActivity.Any(e => e.Id == id);
        }
    }
}
