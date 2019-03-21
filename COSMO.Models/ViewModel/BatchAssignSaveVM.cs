using COSMO.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace COSMO.Models.ViewModel
{
    public class BatchAssignSaveVM
    {
        public int CourseId { get; set; }

        public int BranchId { get; set; }

        public List<Batch> Batches { get; set; }

        public bool IsBranchWise { get; set; }
    }
}
