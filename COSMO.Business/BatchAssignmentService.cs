using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class BatchAssignmentService : IBatchAssignmentService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IBatchAssignmentRepository _batchAssignmentRepository { get; set; }

        #endregion

        public BatchAssignmentService(IBatchAssignmentRepository batchAssignmentRepository)
        {
            _batchAssignmentRepository = batchAssignmentRepository;

        }

        /// <summary>
        /// Gets a single batchassignment entity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The batch assignment entity.</returns>
        public BatchAssignment Get(int id)
        {
            return _batchAssignmentRepository.Get(id);
        }

        public List<BatchAssignment> GetAll()
        {
            return _batchAssignmentRepository.GetAll();
        }

        public BatchAssignment Save(BatchAssignment branch)
        {
            return _batchAssignmentRepository.Save(branch);
        }

        public void Delete(BatchAssignment batchAssignment)
        {
            _batchAssignmentRepository.Delete(batchAssignment);
        }
    }
}
