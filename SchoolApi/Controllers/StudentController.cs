using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Model.IResponse;
using SchoolApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace SchoolApi.Controllers
{
    [Authorize]
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent studentsDetails;

        public StudentController(IStudent student)
        {
            studentsDetails = student;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respone = await studentsDetails.GetAllStudents();
            if (respone == null)
                return NoContent();
            return Ok(respone);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0 || id == null)
                return BadRequest();
            var respone = await studentsDetails.GetStudentById(id);
            if (respone == null)
                return NoContent();
            return Ok(respone);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            if (student == null)
                return BadRequest();
            var response = await studentsDetails.AddStudent(student);
            if (response == null)
                return BadRequest();
            return Created("Student", response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(Student newstudent)
        {
            if (newstudent == null)
                return BadRequest();
            var oldstudent = await studentsDetails.GetStudentById(newstudent.StudentId);
            if (oldstudent == null)
                return NotFound();
            else
            {
                oldstudent.FirstnameName = newstudent.FirstnameName;
                oldstudent.LastName = newstudent.LastName;
                oldstudent.Dob = newstudent.Dob;
                oldstudent.Mobilenumber = newstudent.Mobilenumber;
                oldstudent.EmailId = newstudent.EmailId;
                oldstudent.IsPaide = newstudent.IsPaide;
                oldstudent.CourseId = newstudent.CourseId;
                oldstudent.TrainerId = newstudent.TrainerId;
                oldstudent.Active = newstudent.Active;
                oldstudent.UpdateBy = newstudent.UpdateBy;
                oldstudent.UpdateOn = newstudent.UpdateOn;
                bool response = await studentsDetails.UpdateStudent(oldstudent);
                if (!response)
                    return BadRequest(response);
                else
                    return Ok(response);
            }

        }
        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Student delstudent = await studentsDetails.GetStudentById(id);
            if (delstudent == null)
                return NotFound();
            else
            {
                delstudent.UpdateOn = DateTime.Now;
                delstudent.UpdateBy = 1;
                delstudent.Active = false;
                bool response = await studentsDetails.DeleteStudent(delstudent);
                if (!response)
                    return BadRequest(response);
                else
                    return Ok(response);//inspect this result what we get in this result
            }
        }
    }
}
