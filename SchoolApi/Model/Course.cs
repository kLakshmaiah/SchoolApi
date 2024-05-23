using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class Course
{
    public int CourseId { get; set; }

    public decimal? CourseFees { get; set; }

    public string? Stream { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateOn { get; set; }

    public int? UpdateBy { get; set; }

    public bool? Active { get; set; }

    public string? CouresType { get; set; }

    public string? TitleName { get; set; }
}
