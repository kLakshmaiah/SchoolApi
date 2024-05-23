using Microsoft.EntityFrameworkCore;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Model.Response
{
    public class StudentServices : IStudent
    {
        private readonly SchoolContext Db;

        public StudentServices(SchoolContext db)
        {
            Db = db;
        }
        async Task<Student> IStudent.AddStudent(Student student)
        {
            var response = await Db.Students.AddAsync(student);
            int status = await Db.SaveChangesAsync();
            if (status == 0)
                return null;
            else
                return response.Entity;
        }

        async Task<bool> IStudent.DeleteStudent(Student student)
        {
            int response = await Db.SaveChangesAsync();
            if (response == 0)
                return false;
            else
                return true;
        }

        async Task<IEnumerable<Student>> IStudent.GetAllStudents()
        {
            return await Db.Students.Where(s => s.Active == true).OrderByDescending(s => s.CreatedOn).ToListAsync();
        }

         async Task<Student> IStudent.GetStudentById(int studentId)
        {
            var response = await Db.Students.Where(student => student.Active == true && student.TrainerId == studentId).FirstOrDefaultAsync();
            if (response == null)
                return null;
            else
                return response;
        }

         async Task<bool> IStudent.UpdateStudent(Student student)
        {
            int response = await Db.SaveChangesAsync();
            if (response == 0)
                return false;
            else
                return true;
        }
    }
}
