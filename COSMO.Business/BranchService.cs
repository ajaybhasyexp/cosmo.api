using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business
{
    public class BranchService : IBranchService
    {
        #region Private Members

        /// <summary>
        /// The repository for branch entity.
        /// </summary>
        public IBranchRepository _branchRepository { get; set; }

        #endregion

        /// <summary>
        /// The constructor for branch service.
        /// </summary>
        /// <param name="branchRepository">The repository for injection</param>
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;

        }

        #region Public Methods

        /// <summary>
        /// Gets the branch entity based on id.
        /// </summary>
        /// <param name="id">The id to get the branch entity.</param>
        /// <returns>A single branch entity.</returns>
        public Branch Get(int id)
        {
            return _branchRepository.Get(id);
        }

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        public List<Branch> GetAll()
        {
            return _branchRepository.GetAll();
        }

        /// <summary>
        /// The method to save/update the branch entity.
        /// </summary>
        /// <param name="branch">The branch entity to save or update</param>
        /// <returns>A updated or saved entity.</returns>
        public Branch Save(Branch branch)
        {
            return _branchRepository.Save(branch);
        }

        #endregion
    }
}