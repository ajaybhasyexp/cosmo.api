using Dapper.Contrib.Extensions;
using System;

namespace COSMO.Models.Models
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        public string BatchName { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
