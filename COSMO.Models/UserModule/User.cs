using COSMO.Models.Models;
using Dapper.Contrib.Extensions;

namespace COSMO.Models.UserModule
{
    /// <summary>
    /// The user entity.
    /// </summary>
    public class User : Base
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [Write(false)]
        public string Token { get; set; }

        public int? BranchId { get; set; }

        [Write(false)]
        public string BranchName { get; set; }

        public int UserRoleId { get; set; }

        [Write(false)]
        public string Role { get; set; }

        [Write(false)]
        public int UserId { get; set; }

    }
}
