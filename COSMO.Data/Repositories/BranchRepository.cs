using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace COSMO.Data.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// THe constuctor that also contains the injected dependencies.
        /// </summary>
        /// <param name="config"></param>
        public BranchRepository(IConfiguration config)
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


        public async Task<Branch> Save(Branch branch)
        {
            var sqlQuery = string.Format(Queries.Branch_Save, branch.BranchName, branch.BranchAddress, branch.ContactPerson,
                branch.ContactNumber, branch.AlternativeContact);
            using (var conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<Branch>(sqlQuery);
                return result.FirstOrDefault();
            }
        }
    }
}
