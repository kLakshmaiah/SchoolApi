using Microsoft.EntityFrameworkCore;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Model.Response
{
    public class AssignmentPerCourseServices : IAssignmentPerCourse
    {
        private readonly SchoolContext Db;

        public AssignmentPerCourseServices(SchoolContext db)
        {
            Db = db;
        }
         async Task<AssignmentPerCourse> IAssignmentPerCourse.AddAssignmentCourse(AssignmentPerCourse assignmentPerCourse)
        {
            var response = await Db.AssignmentPerCourses.AddAsync(assignmentPerCourse);
           int effecrecord = await Db.SaveChangesAsync();
            if (effecrecord > 0)
                return response.Entity;
            else
                return null;
        }

         async Task<bool> IAssignmentPerCourse.DeleteAssignmentCourse(AssignmentPerCourse assignmentPerCourse)
        {
           int response=  await Db.SaveChangesAsync();
            if(response>0)
            return true;
            else
                return false;
        }

         async Task<IEnumerable<AssignmentPerCourse>> IAssignmentPerCourse.GetAllAssignmentCourses()
        {
            var response= await Db.AssignmentPerCourses.Where(assignments=>assignments.Active==true).ToListAsync();
            if (response == null)
            {
                return null;
            }
            else
            {
                return response;
            }
        }

         async Task<AssignmentPerCourse> IAssignmentPerCourse.GetAssignmentCourseById(int assigmentId)
        {
            return await Db.AssignmentPerCourses.FirstOrDefaultAsync(assigment => assigment.AssigmentId == assigmentId && assigment.Active==true);
        }

        async Task<bool> IAssignmentPerCourse.UpdateAssignmentCourse(AssignmentPerCourse assignmentPerCourse)
        {
           int effected= await Db.SaveChangesAsync();
            if(effected>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
