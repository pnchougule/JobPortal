using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models;

public class EmployeeInfo
{
    [Key]
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? CollegeName { get; set; }

    public string? Qualification { get; set; } = null;

    public int? Percentage { get; set; } = null;

    public string? Speciality { get; set; } = null;

    public string? TechnologiesStudied { get; set; } = null;

    public string? SoftSkill { get; set; } = null;

    public string? Internship { get; set; } = null;

    public string? Certification { get; set; } = null;

    public string? EmailId { get; set; } = null;

    public int? PhoneNumber { get; set; } = null;

    public string? LinkedinUrl { get; set; } = null;

    public int? CityId { get; set; } = null;

    public string? OfferLetter { get; set; } = null;

    public int? Experience { get; set; } = null;
    public bool IsActive { get; set; } = true;
    public int CreatedBy { get; set; } = 1;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int ModifiedBy { get; set; } = 1;

    public DateTime ModifiedOn { get; set; } = DateTime.Now;
    [Timestamp]
    [ConcurrencyCheck]
    public byte[] RowTimeStamp { get; set; }

    public virtual City? City { get; set; }

    public List<EmployeeDocument> EmployeeDocuments { get; set; }
}
