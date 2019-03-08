using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.UserModule;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace COSMO.Data.Repositories
{
    /// <summary>
    /// THe user repository.
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public UserRepository(IConfiguration config)
            : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// The common property to get connection.
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("COSMODev"));
            }
        }


        /// <summary>
        /// Gets the user using username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string userName, string password)
        {
            var sqlQuery = Queries.GetUserByUname;
            sqlQuery = string.Format(sqlQuery, userName, password);
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = conn.Query<User>(sqlQuery);
                return result.FirstOrDefault();
            }
        }
    }
}
