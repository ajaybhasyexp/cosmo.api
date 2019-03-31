using Dapper.Contrib.Extensions;

namespace COSMO.Models.Models
{
    public class CourseFee : Base
    {
        public string FeeStructure { get; set; }

        public decimal Amount { get; set; }

        public int BranchId { get; set; }

        public int Credits { get; set; }

        public int CourseId { get; set; }

        [Write(false)]
        public string BranchName { get; set; }

        [Write(false)]
        public string CourseName { get; set; }
    }
}
