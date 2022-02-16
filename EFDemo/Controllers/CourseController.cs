using EFDemo.DAL.Repositories;
using EFDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseRepository courseRepository;

        public CourseController(ICourseRepository courseRepository) => this.courseRepository = courseRepository;

        // GET /Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses([FromQuery] int pageNumber, int pageSize)
        {
            return await courseRepository.GetCourses(pageNumber, pageSize);
        }
        
        // GET /Course/{id}
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = courseRepository.GetCourse(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // GET /Course/search/{search}
        [HttpGet("search/{search}")]
        public ActionResult<IEnumerable<Course>> SearchCourses(string search)
        {
            return courseRepository.FindByCondition(c => c.Naam.Contains(search) || c.Code.Contains(search)).ToList();
        }

        // POST /Course
        [HttpPost]
        public ActionResult<Course> CreateCourse([FromBody] Course course)
        {
            if (course == null) return BadRequest("Course is null");
            if (!ModelState.IsValid) return BadRequest("Invalid model state for course");
            courseRepository.Create(course);
            return Ok(course);
        }

        // PUT /Course/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            if (course == null) return BadRequest("Course is null");
            if (!ModelState.IsValid) return BadRequest("INvalid model state for course");
            var c = courseRepository.GetCourse(id);
            courseRepository.Update(c);
            return Ok(course);
        }

        // DELETE /Course/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = courseRepository.GetCourse(id);
            if (course == null) return BadRequest("Course is null");
            courseRepository.Delete(course);
            return Ok(course);
        }
      

    }
}
