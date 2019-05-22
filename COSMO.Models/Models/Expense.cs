namespace COSMO.Models.Models
{
    public class Expense: Base
    {
        public string Description { get; set; }

        public int ExpenseHeadId { get; set; }

        public decimal Amount { get; set; }

        public string Reference { get; set; }

        public int BranchId { get; set; }

        public string ExpenseHead { get; set; }
    }
}
