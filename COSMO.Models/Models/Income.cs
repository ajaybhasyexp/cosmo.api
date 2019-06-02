using Dapper.Contrib.Extensions;
using System;

namespace COSMO.Models.Models
{
    public class Income : Base
    {
        public string Description { get; set; }

        public int IncomeHeadId { get; set; }

        public decimal Amount { get; set; }

        public string Reference { get; set; }

        public int BranchId { get; set; }

        [Write(false)]
        public string IncomeHead { get; set; }

        public int PaymentModeId { get; set; }

        public DateTime TransDate { get; set; }
    }
}