using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class AssignmentsPerStudent
{
    public int AssignmentStudentsId { get; set; }

    public int? AssignmentId { get; set; }

    public int? StudentId { get; set; }

    public bool? IsCompleted { get; set; }

    public int? SecuredMarks { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateOn { get; set; }

    public int? UpdateBy { get; set; }

    public bool? Active { get; set; }
}
