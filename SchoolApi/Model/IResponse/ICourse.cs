namespace SchoolApi.Model.IResponse
{
    public interface ICourse
    {
        public Task<IEnumerable<Course>> GetAllCourses();
        public Task<Course> GetCourseById(int id);
        public Task<Course> AddCourse(Course course);
        public Task<bool> UpdateCourse(Course course);

        public Task<bool> DeleteCourse(Course course);
    }
}
