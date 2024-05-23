using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string? FirstnameName { get; set; }

    public string? LastName { get; set; }

    public string? Mobilenumber { get; set; }

    public string? EmailId { get; set; }

    public string? Subject { get; set; }

    public string? UserName { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdateOn { get; set; }

    public int? UpdateBy { get; set; }

    public int? CourseId { get; set; }

    public bool? Active { get; set; }
}
