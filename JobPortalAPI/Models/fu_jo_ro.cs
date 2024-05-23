using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalAPI.Models
{
    public class fu_jo_ro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int? CityId { get; set; }

        public int JobId { get; set; }

        public int FunctionId { get; set; }
        public int RoleId { get; set; }

        public virtual Job? Jobs { get; set; }

        public virtual City? Cities { get; set; }

        public virtual Function? Functions { get; set; }

        public virtual Role? Roles { get; set; }
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