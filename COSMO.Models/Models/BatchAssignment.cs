namespace COSMO.Models.Models
{
    public class BatchAssignment : Base
    {
        public int BranchId { get; set; }

        public int CourseId { get; set; }

        public int BatchId { get; set; }

        public bool IsBranchWise { get; set; }
    }
}
