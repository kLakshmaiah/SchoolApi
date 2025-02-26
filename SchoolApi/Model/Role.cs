﻿using System;
using System.Collections.Generic;

namespace SchoolApi.Model;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpDateBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
