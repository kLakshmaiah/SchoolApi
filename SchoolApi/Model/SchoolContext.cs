
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Model;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignmentPerCourse> AssignmentPerCourses { get; set; }

    public virtual DbSet<AssignmentsPerStudent> AssignmentsPerStudents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-P90EDPL\\SQLEXPRESS;User Id=sa;Password=1234567890;Database=School;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentPerCourse>(entity =>
        {
            entity.HasKey(e => e.AssigmentId).HasName("PK__Assignme__0936073CA4B1215F");

            entity.ToTable("assignment_per_course");

            entity.Property(e => e.AssigmentId).HasColumnName("assigment_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.AssigmentName)
                .HasMaxLength(100)
                .HasColumnName("assigment_name");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.OralMarks).HasColumnName("oral_marks");
            entity.Property(e => e.SubmitTime)
                .HasColumnType("datetime")
                .HasColumnName("submit_time");
            entity.Property(e => e.TotalMarks).HasColumnName("total_marks");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateOn)
                .HasColumnType("datetime")
                .HasColumnName("update_on");
        });

        modelBuilder.Entity<AssignmentsPerStudent>(entity =>
        {
            entity.HasKey(e => e.AssignmentStudentsId).HasName("PK__assignme__5195C7213767B00E");

            entity.ToTable("assignments_per_student");

            entity.Property(e => e.AssignmentStudentsId).HasColumnName("assignment_students_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((0))")
                .HasColumnName("active");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.IsCompleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_completed");
            entity.Property(e => e.SecuredMarks).HasColumnName("secured_marks");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.UpdateBy).HasColumnName("Update_by");
            entity.Property(e => e.UpdateOn)
                .HasColumnType("datetime")
                .HasColumnName("Update_on");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__School__8F1FF386655CDB80");

            entity.ToTable("course");

            entity.Property(e => e.CourseId).HasColumnName("course_Id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((0))")
                .HasColumnName("active");
            entity.Property(e => e.CouresType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coures_type");
            entity.Property(e => e.CourseFees)
                .HasColumnType("money")
                .HasColumnName("Course_fees");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.Stream)
                .HasMaxLength(15)
                .HasColumnName("stream");
            entity.Property(e => e.TitleName)
                .HasMaxLength(200)
                .HasColumnName("title_name");
            entity.Property(e => e.UpdateBy).HasColumnName("Update_by");
            entity.Property(e => e.UpdateOn)
                .HasColumnType("datetime")
                .HasColumnName("Update_on");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.HasKey(e => e.ExceptionId).HasName("PK__error__C42DECC2608D3DE5");

            entity.ToTable("error");

            entity.Property(e => e.ExceptionId).HasColumnName("exception_id");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.ExceptionMessage)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("exception_message");
            entity.Property(e => e.ExceptionName)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("exception_name");
            entity.Property(e => e.ExceptionStatusNumber)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("exception_status_number");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_dbo.Role");

            entity.ToTable("Role");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__students__2A33069A36868551");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((0))")
                .HasColumnName("active");
            entity.Property(e => e.CourseId).HasColumnName("course_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.FirstnameName)
                .HasMaxLength(50)
                .HasColumnName("firstname_name");
            entity.Property(e => e.IsPaide)
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_paide");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Mobilenumber)
                .HasMaxLength(15)
                .HasColumnName("mobilenumber");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_Id");
            entity.Property(e => e.UpdateBy).HasColumnName("Update_by");
            entity.Property(e => e.UpdateOn)
                .HasColumnType("datetime")
                .HasColumnName("Update_on");
            entity.Property(e => e.UserName)
                .HasMaxLength(51)
                .HasComputedColumnSql("(substring([firstname_name],(1),(1))+[last_name])", true)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Token__3213E83F88CBCC72");

            entity.ToTable("Token");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RefreshToken).HasMaxLength(256);
            entity.Property(e => e.RefreshTokenExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__trainers__65A4B629048CB985");

            entity.ToTable("trainer");

            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.CourseId).HasColumnName("course_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("email_id");
            entity.Property(e => e.FirstnameName)
                .HasMaxLength(50)
                .HasColumnName("firstname_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Mobilenumber)
                .HasMaxLength(20)
                .HasColumnName("mobilenumber");
            entity.Property(e => e.Subject)
                .HasMaxLength(40)
                .HasColumnName("subject");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UpdateOn)
                .HasColumnType("datetime")
                .HasColumnName("update_on");
            entity.Property(e => e.UserName)
                .HasMaxLength(51)
                .HasComputedColumnSql("(substring([firstname_name],(1),(1))+[last_name])", true)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_dbo.User");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserEmailId).HasColumnName("UserEmailID");
            entity.Property(e => e.UserName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_dbo.User_dbo.Role_RoleId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
