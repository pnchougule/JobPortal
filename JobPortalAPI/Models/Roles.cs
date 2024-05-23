using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    public string? RoleName { get; set; }
    public bool IsActive { get; set; } = true;
    public int CreatedBy { get; set; } = 1;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int ModifiedBy { get; set; } = 1;

    public DateTime ModifiedOn { get; set; } = DateTime.Now;

    [Timestamp]
    [ConcurrencyCheck]
    public byte[] RowTimeStamp { get; set; }
    public virtual ICollection<fu_jo_ro> Designations { get; set; } = new List<fu_jo_ro>();
}
