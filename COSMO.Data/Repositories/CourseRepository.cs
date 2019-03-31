using System.Collections.Generic;
using System.Data;
using System.Linq;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace COSMO.Data.Repositories
{
    /// <summary>
    /// The repository and methods for course entity.
    /// </summary>
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        private IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public CourseRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// Gets the courses only assigned to branch.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public List<Course> GetAssignedCourses(int branchId)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<Course>("getcourses", new { branchId = branchId }, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
