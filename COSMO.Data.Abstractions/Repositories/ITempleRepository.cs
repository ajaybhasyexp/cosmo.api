using COSMO.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COSMO.Data.Abstractions.Repositories
{
    /// <summary>
    /// The interface for repository of temple related data methods.
    /// </summary>
    public interface ITempleRepository
    {
        /// <summary>
        /// Gets the Temple object according to the given Identifier.
        /// </summary>
        /// <param name="id">The identifier of the temple.</param>
        /// <returns>A temple object (async)</returns>
        Task<Temple> GetByID(int id);

        /// <summary>
        /// Gets a list of all the temple.
        /// </summary>
        /// <returns>A list of all the temple (Async)</returns>
        Task<List<Temple>> GetAll();
    }
}
