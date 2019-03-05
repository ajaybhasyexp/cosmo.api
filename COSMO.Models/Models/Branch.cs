using Dapper.Contrib.Extensions;

namespace COSMO.Models.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        public string BranchName { get; set; }

        public string BranchAddress { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNumber { get; set; }

        public string BranchEmail { get; set; }

        public int? AdminId { get; set; }
    }
}
