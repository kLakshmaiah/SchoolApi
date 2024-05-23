using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class AssignmentPerCourse
{
    public int AssigmentId { get; set; }

    public string? AssigmentName { get; set; }

    public string? Description { get; set; }

    public DateTime? SubmitTime { get; set; }

    public int? OralMarks { get; set; }

    public int? TotalMarks { get; set; }

    public int? CourseId { get; set; }

    public int? TrainerId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateOn { get; set; }

    public int? UpdateBy { get; set; }

    public bool? Active { get; set; }
}
