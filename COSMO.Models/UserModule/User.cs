using System;

namespace COSMO.Models.UserModule
{
    /// <summary>
    /// The user entity.
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public int? BranchId { get; set; }

        public int UserRoleId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
