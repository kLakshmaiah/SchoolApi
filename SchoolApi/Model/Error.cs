using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class Error
{
    public int ExceptionId { get; set; }

    public string? ExceptionName { get; set; }

    public string? ExceptionMessage { get; set; }

    public string? ExceptionStatusNumber { get; set; }

    public DateTime? CreatedOn { get; set; }
}
