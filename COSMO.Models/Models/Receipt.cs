using System;

namespace COSMO.Models.Models
{
    public class Receipt : Base
    {
        public decimal AmountPaid { get; set; }

        public int PaymentMethodId { get; set; }

        public string Reference { get; set; }

        public DateTime ReceiptDate { get; set; }

        public int BranchId { get; set; }

    }
}
