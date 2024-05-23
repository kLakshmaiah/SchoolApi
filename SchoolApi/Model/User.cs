using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public string? UserEmailId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpDateBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Role Role { get; set; } = null!;
}
