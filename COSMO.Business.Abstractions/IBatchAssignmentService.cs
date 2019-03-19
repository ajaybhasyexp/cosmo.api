using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    public interface IBatchAssignmentService
    {
        /// <summary>
        /// Gets a single batchassignment entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The batch assignment entity.</returns>
        BatchAssignment Get(int id);

        List<BatchAssignment> GetAll();

        BatchAssignment Save(BatchAssignment branch);

        void Delete(BatchAssignment batchAssignment);

        List<BatchAssignVM> GetVMs(int? branchId);
    }
}
