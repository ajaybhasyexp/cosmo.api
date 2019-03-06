using Dapper.Contrib.Extensions;
using System;

namespace COSMO.Models.Models
{
    public class StaffRole
    {
        [Key]
        public int StaffRoleId { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
