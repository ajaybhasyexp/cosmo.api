using COSMO.Models.Models;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    /// <summary>
    /// The abstarction for branch entity.
    /// </summary>
    public interface IBranchRepository
    {
        /// <summary>
        /// Saves or updates the branch entity.
        /// </summary>
        /// <param name="branch">The branch entity to save or update.</param>
        /// <returns>The saved or updated entity.</returns>
        Branch Save(Branch branch);

        /// <summary>
        /// Gets all the branch entities.
        /// </summary>
        /// <returns>A list of branch entity.</returns>
        List<Branch> GetAll();

        /// <summary>
        /// Gets a single branch entity based on the id. 
        /// </summary>
        /// <returns>A single branch entity.</returns>
        Branch Get(int id);
    }
}
