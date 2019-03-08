using COSMO.Models.UserModule;
using System.Threading.Tasks;

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

    }
}
