namespace SchoolApi.Model.IResponse
{
    public interface IStudent
    {
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<Student> GetStudentById(int studentId);
        public Task<Student> AddStudent(Student student);
        public Task<bool> UpdateStudent(Student student);
        public Task<bool> DeleteStudent(Student student);
    }
}
