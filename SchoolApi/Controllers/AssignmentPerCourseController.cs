using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Model;
using SchoolApi.Model.IResponse;
using System.Net;

namespace SchoolApi.Controllers
{
    [Route("api/AssignmentPerCourse")]
    [ApiController]
    public class AssignmentPerCourseController : ControllerBase
    {
        //private readonly IAssignmentPerCourse assignmentPerCourse;

        //public AssignmentPerCourseController(IAssignmentPerCourse assignmentPerCourse)
        //{
        //    this.assignmentPerCourse = assignmentPerCourse;
        //}
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var response = await assignmentPerCourse.GetAllAssignmentCourses();
        //    if (response == null)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(response);
        //    }
        //}

        //[HttpGet("{assignementId}")]
        //public async Task<IActionResult> Get(int assignementId)
        //{
        //    if (assignmentPerCourse == null)
        //        return BadRequest();
        //    else
        //    {
        //        AssignmentPerCourse assignmentCourse = await assignmentPerCourse.GetAssignmentCourseById(assignementId);
        //        if (assignmentCourse == null)
        //            return NotFound();
        //        else
        //            return Ok(assignmentCourse);
        //    }

        //}
        //[HttpPost]
        //public async Task<IActionResult> Post(AssignmentPerCourse newassignmentPerCourse)
        //{
        //    if (newassignmentPerCourse == null)
        //        return BadRequest();
        //    var response = await assignmentPerCourse.AddAssignmentCourse(newassignmentPerCourse);
        //    if (response == null)
        //        return BadRequest();
        //    else
        //        return Created("AssignementPerCourse", response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(AssignmentPerCourse newassignmentPerCourse)
        //{
        //    if (newassignmentPerCourse == null)
        //        return BadRequest();
        //    else
        //    {
        //        AssignmentPerCourse oldassignmentpercourse = await assignmentPerCourse.GetAssignmentCourseById(newassignmentPerCourse.AssigmentId);
        //        if (oldassignmentpercourse == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            oldassignmentpercourse.AssigmentName = newassignmentPerCourse.AssigmentName;
        //            oldassignmentpercourse.Description = newassignmentPerCourse.Description;
        //            oldassignmentpercourse.SubmitTime = newassignmentPerCourse.SubmitTime;
        //            oldassignmentpercourse.OralMarks = newassignmentPerCourse.OralMarks;
        //            oldassignmentpercourse.TotalMarks = newassignmentPerCourse.TotalMarks;
        //            oldassignmentpercourse.CourseId = newassignmentPerCourse.CourseId;
        //            oldassignmentpercourse.TrainerId = newassignmentPerCourse.TrainerId;
        //            oldassignmentpercourse.UpdateBy = newassignmentPerCourse.UpdateBy;
        //            oldassignmentpercourse.UpdateOn = newassignmentPerCourse.UpdateOn;
        //            oldassignmentpercourse.Active = newassignmentPerCourse.Active;
        //            var response = await assignmentPerCourse.UpdateAssignmentCourse(oldassignmentpercourse);
        //            if (response)
        //                return Ok(response);
        //            else
        //            {
        //                return BadRequest(response);
        //            }

        //        }
        //    }

        //}
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id == 0 || id == null)
        //        return BadRequest();
        //    else
        //    {
        //        AssignmentPerCourse deleterecord = await assignmentPerCourse.GetAssignmentCourseById(id);
        //        if (deleterecord != null)
        //        {
        //            deleterecord.UpdateOn= DateTime.Now;
        //            deleterecord.UpdateBy = 1;
        //            deleterecord.Active = false;
        //            bool response = await assignmentPerCourse.DeleteAssignmentCourse(deleterecord);
        //            if (response)
        //                return Ok(response);
        //            else
        //                return BadRequest(response);
        //        }

        //        return NotFound();
        //    }

        //}
    }
}
