using flowdown_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace flowdown_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Lessons")]

   [ApiController]
    
    public class LessonsController : ControllerBase
    {
        readonly LessonContext context;
        public LessonsController(LessonContext context) 
        { 
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Models.Lesson> Get()
        {
            return context.Lessons;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lesson lesson)
        {

            //context.Lessons.Add(new Models.Lesson()
            //{
            //    Title = lesson.Title,
            //    Description = lesson.Description,
            //    Category = lesson.Category,
            //    Department = lesson.Department,
            //    //OwnerId = lesson.OwnerId
            //    OwnerId= userId
            //});

            var userId = HttpContext.User.Claims.First().Value;

            lesson.OwnerId = userId;

            context.Lessons.Add(lesson);

            await context.SaveChangesAsync();
            return Ok(lesson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Lesson lesson)
        {
            if(id != lesson.Id)
                return BadRequest();

            context.Entry(lesson).State= EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(lesson);
        }

    }
}
