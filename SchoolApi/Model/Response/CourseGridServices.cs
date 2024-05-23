using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Model.IResponse;
using System.Web.Http;

namespace SchoolApi.Model.Response
{
    public class CourseGridServices : ICourseGrid
    {
        private readonly SchoolContext Db;

        public CourseGridServices(SchoolContext db)
        {
            Db = db;
        }

        async Task<IEnumerable<CourseGridReturn>> ICourseGrid.GetCourseGridDetails( RecordsSearch search)
        {
            var startrecord = new SqlParameter("@page_size", search.PageSize);
            var endrecord = new SqlParameter("@page_number", search.PageNumber);

            using (var command = Db.Database.GetDbConnection().CreateCommand())
            {
                try
                {
                    List<CourseGridReturn> records = new List<CourseGridReturn>();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "COURSE_GRID";
                    command.Parameters.Clear();
                    if (search.PageNumber != null && search.PageNumber != 0 && search.PageSize != null && search.PageSize != 0)
                    {
                        command.Parameters.Add(startrecord);
                    command.Parameters.Add(endrecord);
                    }
                    
                    await Db.Database.OpenConnectionAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {

                        while (reader.Read())
                        {
                            CourseGridReturn model = new CourseGridReturn();
                            model.CourseId = reader["course_id"] != DBNull.Value ? (int)reader["course_id"] : 0;
                            model.TitleName = reader["title_name"] != DBNull.Value ? (string)reader["title_name"] : string.Empty;
                            model.CouresType = reader["coures_type"] != DBNull.Value ? (string)reader["coures_type"] : string.Empty;
                            model.Stream = reader["stream"] != DBNull.Value ? (string)reader["stream"] : string.Empty;
                            model.Active = reader["active"] != DBNull.Value ? (bool?)reader["active"] : false;
                            model.StartDate = reader["start_date"] != DBNull.Value ? (DateTime?)reader["start_date"] : DateTime.MinValue;
                            model.EndDate = reader["end_date"] != DBNull.Value ? (DateTime?)reader["end_date"] : DateTime.MinValue;
                            model.CreatedOn = reader["created_on"] != DBNull.Value ? (DateTime?)reader["created_on"] : DateTime.MinValue;
                            model.CreatedBy = reader["created_by"] != DBNull.Value ? (int?)reader["created_by"] : 0;
                            model.UpdateOn = reader["update_on"] != DBNull.Value ? (DateTime?)reader["update_on"] : DateTime.MinValue;
                            model.UpdateBy = reader["update_by"] != DBNull.Value ? (int?)reader["update_by"] : 0;
                            model.TotalRecords = reader["total_records"] != DBNull.Value ? (int?)reader["total_records"] : 0;
                            records.Add(model);
                        }
                    }
                    return records;
                }
                catch (System.Exception ex) { throw new System.Exception(ex.Message); }
                finally
                {
                    await Db.Database.CloseConnectionAsync();
                }
            }
        }
    }
}
