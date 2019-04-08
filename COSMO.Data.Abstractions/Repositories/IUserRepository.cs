using COSMO.Models.UserModule;
using System.Collections.Generic;

namespace COSMO.Data.Abstractions.Repositories
{
    /// <summary>
    /// The interface for user related repository methods.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {

        /// <summary>
        /// Gets the user object by username and password.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A user object.</returns>
        User GetUser(string userName, string password);

        /// <summary>
        /// Gets all the users or based on branch id.
        /// </summary>
        /// <param name="branchId">The branch identfier.</param>
        /// <returns>A list of user object with branch name and userrole name.</returns>
        List<User> GetAll(int branchId);

    }
}
