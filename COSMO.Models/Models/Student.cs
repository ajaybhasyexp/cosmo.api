using Dapper.Contrib.Extensions;

namespace COSMO.Models.Models
{
    public class Student : Base
    {
        public string StudentName { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public int BranchId { get; set; }        

        public int? QualificationId { get; set; }

        [Write(false)]
        public string QualificationName { get; set; }

        public int? ProfessionId { get; set; }

        [Write(false)]
        public string ProfessionName { get; set; }

        public int? SourceId { get; set; }

        [Write(false)]
        public string SourceName { get; set; }

        public bool FeesPaid { get; set; }
    }
}
