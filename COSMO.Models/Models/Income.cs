namespace COSMO.Models.Models
{
    public class Income : Base
    {
        public string Description { get; set; }

        public int IncomeHeadId { get; set; }

        public decimal Amount { get; set; }

        public string Reference { get; set; }

        public int BranchId { get; set; }

        public string IncomeHead { get; set; }

    }
}
