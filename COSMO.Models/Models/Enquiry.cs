namespace COSMO.Models.Models
{
    public class Enquiry : Base
    {
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public int CourseId { get; set; }

        public int BranchId { get; set; }

        public string Remarks { get; set; }
    }
}
