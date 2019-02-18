using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.UserModule;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace COSMO.Data.Repositories
{
    /// <summary>
    /// THe user repository.
    /// </summary>
    public class UserRepository : IUserRepository
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
        /// Gets the user object by userId.
        /// </summary>
        /// <param name="userId">The user identification.</param>
        /// <returns>A user entity.</returns>
        public async Task<User> GetUser(int userId)
        {
            var sqlQuery = Queries.GetUserById;
            sqlQuery = string.Format(sqlQuery, userId);
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<User>(sqlQuery);
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the user using username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> GetUser(string userName, string password)
        {
            var sqlQuery = Queries.GetUserByUname;
            sqlQuery = string.Format(sqlQuery, userName, password);
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<User>(sqlQuery);
                return result.FirstOrDefault();
            }
        }
    }
}
