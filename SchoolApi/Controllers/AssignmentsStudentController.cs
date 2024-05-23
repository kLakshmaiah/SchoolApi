using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Model.IResponse;
using SchoolApi.Model;

namespace SchoolApi.Controllers
{
    [Route("api/AssignmentsStudent")]
    [ApiController]
    public class AssignmentsStudentController : ControllerBase
    {
        private readonly IAssignmentsStudent AssignmentsStudent;

        public AssignmentsStudentController(IAssignmentsStudent assignmentsStudent)
        {

            AssignmentsStudent = assignmentsStudent;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await AssignmentsStudent.GetAllAssignmentsStudents();
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return BadRequest();
            AssignmentsPerStudent response = await AssignmentsStudent.GetAssignmentsStudentById(id);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Post(AssignmentsPerStudent assignmentsPerStudent)
        {
            if (assignmentsPerStudent == null)
                return BadRequest();
            var response = await AssignmentsStudent.AddAssignmentsStudent(assignmentsPerStudent);
            if (response != null)
                return Created("Course", response);
            else
                return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Put(AssignmentsPerStudent assignmentsPerStudent)
        {
            if (assignmentsPerStudent == null)
                return BadRequest();
            AssignmentsPerStudent oldassigmentstudent = await AssignmentsStudent.GetAssignmentsStudentById(assignmentsPerStudent.AssignmentStudentsId);
            if (oldassigmentstudent != null)
            {
                oldassigmentstudent.AssignmentId = assignmentsPerStudent.AssignmentId;
                oldassigmentstudent.StudentId = assignmentsPerStudent.StudentId;
                oldassigmentstudent.IsCompleted = assignmentsPerStudent.IsCompleted;
                oldassigmentstudent.SecuredMarks = assignmentsPerStudent.SecuredMarks;
                oldassigmentstudent.UpdateOn = assignmentsPerStudent.UpdateOn;
                oldassigmentstudent.UpdateBy = assignmentsPerStudent.UpdateBy;
                oldassigmentstudent.Active = assignmentsPerStudent.Active;
                bool status = await AssignmentsStudent.UpdateAssignmentsStudent(oldassigmentstudent);
                if (status)
                    return Ok(status);
                else
                    return NotFound(status);
            }
            else
                return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int assignmetStudentId)
        {
            if (assignmetStudentId == 0)
                return BadRequest();
            else
            {
                AssignmentsPerStudent oldassignmentstudent = await AssignmentsStudent.GetAssignmentsStudentById(assignmetStudentId);
                if (oldassignmentstudent == null)
                    return NoContent();
                else
                {
                    oldassignmentstudent.UpdateOn = DateTime.Now;
                    oldassignmentstudent.UpdateBy = 1;
                    oldassignmentstudent.Active = false;
                    bool response = await AssignmentsStudent.DeleteAssignmentsStudent(oldassignmentstudent);
                    if (!response)
                        return NotFound();
                    else
                        return Ok(response);
                }
            }

        }
    }
}
