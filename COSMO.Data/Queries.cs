namespace COSMO.Data
{
    /// <summary>
    /// The common file for queries.
    /// </summary>
    public static class Queries
    {
        public static readonly string GetUserById = "Select * from `User` where UserId = {0}";

        public static readonly string GetUserByUname = "Select * from `User` where UserName = '{0}' AND Password = '{1}'";

        public static readonly string Branch_Save = "INSERT INTO `branch`(`BranchName`,`BranchAddress`,`ContactPerson`,`ContactNumber`,`AlternativeContact`) VALUES ('{0}','{1}','{2}','{3}','{4}');";

    }
}
