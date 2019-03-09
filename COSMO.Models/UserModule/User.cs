using COSMO.Models.Models;

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

        public string Token { get; set; }

        public int? BranchId { get; set; }

        public int UserRoleId { get; set; }

        public string Role { get; set; }

        public int UserId { get; set; }

    }
}
