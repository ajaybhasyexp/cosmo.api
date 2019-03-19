namespace COSMO.Data
{
    /// <summary>
    /// The common file for queries.
    /// </summary>
    public static class Queries
    {
        public static readonly string GetUserById = "Select * from `Users` where UserId = {0}";

        public static readonly string GetUserByUname = @"SELECT u.id  AS userid, 
                                                           ur.id AS Roleid, 
                                                           ur.role, 
                                                           u.profilepic, 
                                                           u.email, 
                                                           u.branchid, 
                                                           u.username, 
                                                           u.userroleid 
                                                    FROM   users u 
                                                           INNER JOIN userroles ur 
                                                                   ON u.userroleid = ur.id 
                                                    WHERE  username = '{0}' 
                                                           AND password = '{1}' ";

        public static readonly string Branch_Save = @"INSERT INTO `branchs` 
                                                    ( 
                                                                `branchname`,
                                                                `branchaddress`,
                                                                `contactperson`,
                                                                `contactnumber`,
                                                                `branchemail`,
                                                                `adminid`,
                                                                `createddate`,
                                                                `updateddate` 
                                                    )
                                                    VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}',{5},
                                                      now(),now());";

        public static readonly string BatchAssignment_get_filtered = @"SELECT ba.id
	                                                        ,ba.courseid,c.CourseName
	                                                        ,ba.batchid,b.BatchName
	                                                        ,ba.Branchid,br.BranchName
                                                        FROM batchassignments ba
                                                        INNER JOIN courses c ON ba.courseid = c.id
                                                        INNER JOIN batchs b ON ba.batchid = b.id
                                                        INNER JOIN branchs br ON ba.Branchid = br.id
                                                        WHERE ba.branchid = {0}";

        public static readonly string BatchAssignment_get = @"SELECT ba.id
	                                                        ,ba.courseid,c.CourseName
	                                                        ,ba.batchid,b.BatchName
	                                                        ,ba.Branchid,br.BranchName
                                                        FROM batchassignments ba
                                                        INNER JOIN courses c ON ba.courseid = c.id
                                                        INNER JOIN batchs b ON ba.batchid = b.id
                                                        INNER JOIN branchs br ON ba.Branchid = br.id";

    }
}
