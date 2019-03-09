namespace COSMO.Data
{
    /// <summary>
    /// The common file for queries.
    /// </summary>
    public static class Queries
    {
        public static readonly string GetUserById = "Select * from `Users` where UserId = {0}";

        public static readonly string GetUserByUname = @"Select u.id as userid, ur.id as Roleid,ur.Role,u.Profilepic,u.Email,u.BranchId, u.UserName,u.UserRoleId from users u INNER JOIN UserRoles ur
ON u.UserRoleId = ur.Id  where UserName = '{0}' AND Password = '{1}'";

        public static readonly string Branch_Save = "INSERT INTO `branchs`(`BranchName`,`BranchAddress`,`ContactPerson`,`ContactNumber`,`BranchEmail`,`AdminId`,`CreatedDate`,`UpdatedDate`) VALUES ('{0}','{1}','{2}','{3}','{4}',{5},NOW(),NOW());";

    }
}
