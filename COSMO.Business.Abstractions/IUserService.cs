using COSMO.Models.UserModule;
using System.Threading.Tasks;

namespace COSMO.Business.Abstractions
{
    /// <summary>
    /// The user business service class.
    /// </summary>
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
