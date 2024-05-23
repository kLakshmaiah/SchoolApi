using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Model;
using SchoolApi.Model.IResponse;

namespace SchoolApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGridController : ControllerBase
    {

        private readonly ICourseGrid CourseGrid;
        public CourseGridController(ICourseGrid courseGrid)
        {
           CourseGrid= courseGrid;
        }

        [HttpPost]
        public async Task<IEnumerable<CourseGridReturn>> CourseGridModels([FromBody] RecordsSearch search)
        {
           return await CourseGrid.GetCourseGridDetails(search);
        }


    }
}
