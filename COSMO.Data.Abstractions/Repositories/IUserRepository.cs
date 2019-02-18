using COSMO.Models.UserModule;
using System.Threading.Tasks;

namespace COSMO.Data.Abstractions.Repositories
{
    /// <summary>
    /// The interface for user related repository methods.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user based on the user Identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The User object.</returns>
        Task<User> GetUser(int userId);

        /// <summary>
        /// Gets the user object by username and password.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A user object.</returns>
        Task<User> GetUser(string userName, string password);

    }
}
