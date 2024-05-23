using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Model;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    [Route("api/Course")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourse course;

        public CourseController(ICourse course)
        {
            this.course = course;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await course.GetAllCourses();
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id != null && id == 0)
                return NotFound();
            var response = await course.GetCourseById(id);
            if (response != null)
                return Ok(response);
            else
                return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Course newcourse)
        {
            if (newcourse == null)
                return BadRequest();
            var response = await course.AddCourse(newcourse);
            if (response != null)
                return Created("Course", response);
            else
                return BadRequest(newcourse);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Course newcourse)
        {
            if (newcourse == null)
                return BadRequest();
            Course oldCourse = await course.GetCourseById(newcourse.CourseId);
            if (oldCourse != null)
            {
                oldCourse.TitleName = newcourse.TitleName;
                oldCourse.CouresType = newcourse.CouresType;
                oldCourse.CourseFees = newcourse.CourseFees;
                oldCourse.Stream = newcourse.Stream;
                oldCourse.StartDate = newcourse.StartDate;
                oldCourse.EndDate = newcourse.EndDate;
                oldCourse.UpdateOn = newcourse.UpdateOn;
                oldCourse.UpdateBy = newcourse.UpdateBy;
                oldCourse.Active = newcourse.Active;
                bool status = await course.UpdateCourse(oldCourse);
                if (status)
                    return Ok(status);
                else
                    return NotFound(status);
            }
            else
                return BadRequest();

        }

        //[HttpDelete]
        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            if (courseId == 0)
                return BadRequest();
            else
            {
                Course olderecord = await course.GetCourseById(courseId);
                if (olderecord == null)
                    return NoContent();
                else
                {
                    olderecord.UpdateOn = DateTime.Now;
                    olderecord.UpdateBy = 1;
                    olderecord.Active = false;
                    bool response = await course.DeleteCourse(olderecord);
                    if (!response)
                        return NotFound();
                    else
                        return Ok(response);
                }
            }

        }
    }
}
