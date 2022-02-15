using EFDemo.DAL;
using EFDemo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {

        private readonly CourseContext _context;

        public CourseController(CourseContext context) => _context = context;


        // GET: /Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse() => await _context.Course.ToListAsync();

        // GET: /Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if(course == null) return NotFound();
            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Course>> PutCourse(int id, Course course)
        {
            if (id != course.Id) return BadRequest();
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null) return NotFound();
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }

    }
}
