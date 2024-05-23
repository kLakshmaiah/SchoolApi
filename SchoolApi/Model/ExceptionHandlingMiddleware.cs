using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace SchoolApi.Model
{
    [NotMapped]
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (System.Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, System.Exception ex)
        {
            var number = (int)HttpStatusCode.InternalServerError;
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = number });
            Error error = new Error();
            error.ExceptionName= ex.GetType().Name;
            error.ExceptionMessage = ex.Message;
            error.CreatedOn = DateTime.Now;
            error.ExceptionStatusNumber = number.ToString();
            SchoolContext school = new SchoolContext();
            school.Errors.Add(error);
            school.SaveChanges();
            return context.Response.WriteAsync(errorMessage);
        }
    }
}
