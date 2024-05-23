using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalAPI.Models
{
    public class EmployeeDocument
    {
        [Key]
        public int? DocumentId { get; set; }
        public int? EmployeeId { get; set; }

        public byte[]? GraduationMarksheet { get; set; } = null;
        public byte[]? PassingCertificate { get; set; } = null;
        public byte[]? AadharCard { get; set; } = null;
        public byte[]? PANCard { get; set; } = null;
        public byte[]? PassportDoc { get; set; } = null;
        public byte[]? IdentityPhoto { get; set; } = null;
        public byte[]? TenthMarksheet { get; set; } = null;
        public byte[]? TwelthMarksheet { get; set; } = null;
        public byte[]? Resume { get; set; } = null;
        public bool IsActive { get; set; } = true;
        public int CreatedBy { get; set; } = 1;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int ModifiedBy { get; set; } = 1;

        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        [Timestamp]
        [ConcurrencyCheck]
        public byte[] RowTimeStamp { get; set; }
    }
}