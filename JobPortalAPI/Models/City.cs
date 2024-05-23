﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models;

public class City
{
     [Key]
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public string CityState { get; set; } = null!;
    public bool IsActive {get;set;} = true;
    public int CreatedBy { get; set; } = 1;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int ModifiedBy { get; set; } = 1;

    public DateTime ModifiedOn { get; set; } = DateTime.Now;

    [Timestamp]
    [ConcurrencyCheck]
    public byte[] RowTimeStamp { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<EmployeeInfo> EmployeeInfos { get; set; } = new List<EmployeeInfo>();

    public virtual ICollection<fu_jo_ro> Fu_Jo_Ros { get; set; } = new List<fu_jo_ro>();
}
