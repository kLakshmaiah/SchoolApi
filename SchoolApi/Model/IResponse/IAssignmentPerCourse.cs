namespace SchoolApi.Model.IResponse
{
    public interface IAssignmentPerCourse
    {
        public Task<IEnumerable<AssignmentPerCourse>> GetAllAssignmentCourses();
        public Task<AssignmentPerCourse> GetAssignmentCourseById(int assigmentId);
        public Task<AssignmentPerCourse> AddAssignmentCourse(AssignmentPerCourse assignmentPerCourse);
        public Task<bool> UpdateAssignmentCourse(AssignmentPerCourse assignmentPerCourse);
        public Task<bool> DeleteAssignmentCourse(AssignmentPerCourse assignmentPerCourse);
    }
}
