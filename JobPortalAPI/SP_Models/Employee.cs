using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalAPI.SP_Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? CollegeName { get; set; }

        public string? Qualification { get; set; }

        public int? Percentage { get; set; }

        public string? Speciality { get; set; }

        public string? TechnologiesStudied { get; set; }

        public string? SoftSkill { get; set; }

        public string? Internship { get; set; }

        public string? Certification { get; set; }

        public string? EmailId { get; set; }

        public int? PhoneNumber { get; set; }

        public string? LinkedinUrl { get; set; }

        public int? CityId { get; set; }

        public string? OfferLetter { get; set; }

        public int? Experience { get; set; }

        public byte[]? GraduationMarksheet { get; set; }
        public byte[]? PassingCertificate { get; set; }
        public byte[]? AadharCard { get; set; }
        public byte[]? PANCard { get; set; }
        public byte[]? PassportDoc { get; set; }
        public byte[]? IdentityPhoto { get; set; }
        public byte[]? TenthMarksheet { get; set; }
        public byte[]? TwelthMarksheet { get; set; }
        public byte[]? Resume { get; set; }
    }
}