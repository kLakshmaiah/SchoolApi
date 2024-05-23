using System.Web.Http;

namespace SchoolApi.Model.IResponse
{
    public interface ICourseGrid
    {
        Task<IEnumerable<CourseGridReturn>> GetCourseGridDetails( RecordsSearch search);
    }
}
