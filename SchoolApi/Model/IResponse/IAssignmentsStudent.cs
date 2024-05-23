namespace SchoolApi.Model.IResponse
{
    public interface IAssignmentsStudent
    {
        public Task<IEnumerable<AssignmentsPerStudent>> GetAllAssignmentsStudents();
        public Task<AssignmentsPerStudent> GetAssignmentsStudentById(int assignmentStudentId);
        public Task<AssignmentsPerStudent> AddAssignmentsStudent(AssignmentsPerStudent assignmentsPerStudent);
        public Task<bool> UpdateAssignmentsStudent(AssignmentsPerStudent assignmentsPerStudent);

        public Task<bool> DeleteAssignmentsStudent(AssignmentsPerStudent assignmentsPerStudent);
    }
}
