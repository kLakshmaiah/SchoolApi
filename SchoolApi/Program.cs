using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Model;
using SchoolApi.Model.IResponse;
using SchoolApi.Model.Response;
using Serilog;
using System.Text;

namespace SchoolApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //adding Database
            builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb")));
            
            //new way to add corss policy for getting api to another project..
            builder.Services.AddCors(option => option.AddPolicy("open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            
            //Dependecy Injections
            builder.Services.AddScoped<ICourse, CourseServices>();
            builder.Services.AddScoped<ITrainer, TrainerServices>();
            builder.Services.AddScoped<IAssignmentPerCourse, AssignmentPerCourseServices>();
            builder.Services.AddScoped<IAssignmentsStudent, AssignmentsStudentServices>();
            builder.Services.AddScoped<IStudent, StudentServices>();
            builder.Services.AddScoped<ICourseGrid, CourseGridServices>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            //Adding Jwt Beare Authentication
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            { 
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
                    ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"])),
                    ClockSkew = TimeSpan.Zero //this is very important we need to understand this keyword
                };
            });

            //for Get api-history
            var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          
            var app = builder.Build();
            // Configure the HTTP request pipeline.
           

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));//Get the Exceptions are Globally
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}