using COSMO.Models.UserModule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COSMO.Business.Abstractions
{
    /// <summary>
    /// The user business service class.
    /// </summary>
    public interface IUserService
    {
        User Authenticate(string username, string password);

        List<User> GetAll();

        User Save(User user);

        /// <summary>
        /// Gets a single user entity according to the identifier.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns>A user entity.</returns>
        User Get(int id);

        /// <summary>
        /// Deletes the user entity.
        /// </summary>
        /// <param name="user">The entity to delete</param>
        void Delete(User user);
    }
}
