
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models;

public class Function
{
    [Key]
    public int FunctionId { get; set; }

    public string? FunctionName { get; set; }
    public bool IsActive { get; set; } = true;
    public int CreatedBy { get; set; } = 1;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int ModifiedBy { get; set; } = 1;

    public DateTime ModifiedOn { get; set; } = DateTime.Now;
    [Timestamp]
    [ConcurrencyCheck]
    public byte[] RowTimeStamp { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
    public virtual ICollection<fu_jo_ro> Fu_Jo_Ros { get; set; } = new List<fu_jo_ro>();
}
