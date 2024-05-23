using Microsoft.EntityFrameworkCore;
using SchoolApi.Model.IResponse;
namespace SchoolApi.Model.Response
{
    public class CourseServices : ICourse
    {
        private readonly SchoolContext db;

        public CourseServices(SchoolContext db)
        {
            this.db = db;
        }
        async Task<Course> ICourse.AddCourse(Course course)
        {
            var result = await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
            return result.Entity;//this is new to me...
        }

         async Task<bool> ICourse.DeleteCourse(Course course)
        {
            int effectedrecord=await db.SaveChangesAsync();
            if (effectedrecord == 0) 
            {     
              return false;
            }
            else
            {
                return true;
            }
        }

        async Task<IEnumerable<Course>> ICourse.GetAllCourses()
        {
            return await db.Courses.Where(course=>course.Active==true).OrderByDescending(c => c.CreatedOn).ToListAsync();
        }

         async Task<Course> ICourse.GetCourseById(int id)
        {
            return await db.Courses.FirstOrDefaultAsync(course=>course.CourseId==id&& course.Active==true);
        }

        async Task<bool> ICourse.UpdateCourse(Course course)
        {

            int response = await db.SaveChangesAsync();
            if(response == 0)
                return false;
            else
                return true;
        }
    }
}
