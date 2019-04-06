using Dapper.Contrib.Extensions;

namespace COSMO.Models.Models
{
    public class StudentAssignment : Base
    {
        public int BatchAssignId { get; set; }

        public int StudentId { get; set; }

        public int CourseFeeId { get; set; }

        public int? ReceiptId { get; set; }

        [Write(false)]
        public int CourseId { get; set; }

        [Write(false)]
        public int BatchId { get; set; }

        [Write(false)]
        public int BranchId { get; set; }

        [Write(false)]
        public string StudentName { get; set; }

        [Write(false)]
        public string CourseName { get; set; }

        [Write(false)]
        public string BatchName { get; set; }

        [Write(false)]
        public string FeeStructureName { get; set; }
    }
}
