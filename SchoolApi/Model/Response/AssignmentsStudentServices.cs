using Microsoft.EntityFrameworkCore;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Model.Response
{
    public class AssignmentsStudentServices : IAssignmentsStudent
    {
        private readonly SchoolContext Db;

        public AssignmentsStudentServices(SchoolContext schoolContext)
        {
            Db = schoolContext;
        }

        async Task<AssignmentsPerStudent> IAssignmentsStudent.AddAssignmentsStudent(AssignmentsPerStudent assignmentsPerStudent)
        {
            var result = await Db.AssignmentsPerStudents.AddAsync(assignmentsPerStudent);
            await Db.SaveChangesAsync();
            return result.Entity;//this is new to me...
        }

        async Task<bool> IAssignmentsStudent.DeleteAssignmentsStudent(AssignmentsPerStudent assignmentsPerStudent)
        {
            int effectedrecord = await Db.SaveChangesAsync();
            if (effectedrecord == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        async Task<IEnumerable<AssignmentsPerStudent>> IAssignmentsStudent.GetAllAssignmentsStudents()
        {
            return await Db.AssignmentsPerStudents.Where(student => student.Active == true).OrderByDescending(c => c.CreatedOn).ToListAsync();
        }

        async Task<AssignmentsPerStudent> IAssignmentsStudent.GetAssignmentsStudentById(int assignmentStudentId)
        {
            return await Db.AssignmentsPerStudents.FirstOrDefaultAsync(student => student.AssignmentStudentsId == assignmentStudentId && student.Active == true);
        }

        async Task<bool> IAssignmentsStudent.UpdateAssignmentsStudent(AssignmentsPerStudent assignmentsPerStudent)
        {
            int response = await Db.SaveChangesAsync();
            if (response == 0)
                return false;
            else
                return true;
        }
    }
}
