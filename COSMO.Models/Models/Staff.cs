using System;

namespace COSMO.Models.Models
{
    public class Staff: Base
    {
        //public int StaffId { get; set; }

        public int StaffRoleId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public int BranchId { get; set; }
        
    }
}
