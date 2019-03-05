using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Business.Abstractions
{
    /// <summary>
    /// The abstraction for branch entity.
    /// </summary>
    public interface IBranchService
    {
        /// <summary>
        /// The save method for branch.
        /// </summary>
        /// <param name="branch">The entity to save or update</param>
        /// <returns>The saved or updated entity.</returns>
        Branch Save(Branch branch);

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entities.</returns>
        List<Branch> GetAll();

        /// <summary>
        /// Gets the branch entity based on the id.
        /// </summary>
        /// <param name="id">The id to get the branch.</param>
        /// <returns>A branch entity</returns>
        Branch Get(int id);
    }
}
