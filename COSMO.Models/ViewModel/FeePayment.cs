using System;

namespace COSMO.Models.ViewModel
{
    public class FeePayment
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public decimal Amount { get; set; }

        public string Reference { get; set; }

        public int PaymentModeId { get; set; }

        public int StudentAssignmentId { get; set; }

        public int UserId { get; set; }

        public DateTime ReceiptDate { get; set; }

    }
}
