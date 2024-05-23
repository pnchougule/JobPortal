using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models;

public class Job
{
    [Key]
    public int JobId { get; set; }

    public string? CompanyName { get; set; }

    public int? Experience { get; set; }

    public string? JobTitle { get; set; }

    public string? LinkedinUrl { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? Description { get; set; }

    public DateTime? PostedDate { get; set; }

    public string? MandatorySkills { get; set; }

    public string? OptionalSkills { get; set; }

    public string? Certification { get; set; }

    public DateTime? ExpiryOfRole { get; set; }

    public bool IsActive {get;set;} = true;
    public int CreatedBy { get; set; } = 1;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int ModifiedBy { get; set; } = 1;

    public DateTime ModifiedOn { get; set; } = DateTime.Now;

    [Timestamp]
    [ConcurrencyCheck]
    public byte[] RowTimeStamp { get; set; }
    public virtual ICollection<fu_jo_ro> Fu_Jo_Ros { get; set; } = new List<fu_jo_ro>();
}
