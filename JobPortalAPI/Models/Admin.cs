using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models;

public class Admin
{
     [Key]
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? CompanyName { get; set; }

    public string? EmailId { get; set; }

    public string? LinkedinUrl { get; set; }

    public DateTime JoiningDate{get;set;}

    public bool IsActive {get;set;} = true;

    public int CreatedBy { get; set; } = 1;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int ModifiedBy { get; set; } = 1;

    public DateTime ModifiedOn { get; set; } = DateTime.Now;
    
    [Timestamp]
    [ConcurrencyCheck]
    public byte[] RowTimeStamp { get; set; }
    
    public int? CityId { get; set; }
    public virtual City? City { get; set; }
    
    public int? FunctionId { get; set; }
    public virtual Function? Functions { get; set; }

    public virtual ICollection<fu_jo_ro> Fu_Jo_Ros { get; set; } = new List<fu_jo_ro>();
}
